using _8x8x8_LED.Helpers;
using _8x8x8_LED.Models;
using _8x8x8_LED.Models.Shapes;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace _8x8x8_LED.Views
{
    public partial class FrmMusic : Form
    {
        private readonly SerialPort serialPort;
        private readonly Cube cube;

        private int samples = 1024; // How many samples to calculate wave form from.

        private double[] eightChannels = new double[8]; // Holds 8 bytes of audio.

        private bool cubeCleared = false; // Controls whether to clear the screen if no audio is playing.
        
        private bool animate = false; // Whether to animate the visualizer.
        private int speed = 1; // Speed of animation.
        private int timeElapsed = 0; // Used to measure time against speed of animation.
        private readonly Random random = new Random();

        private readonly IWaveIn waveIn = new WasapiLoopbackCapture();

        private string currentMusicStyle = "";

        private CubeColor targetColor = CubeColor.White;

        private readonly List<CubeColor> fireColors = new List<CubeColor>() {
            CubeColor.White,
            CubeColor.White,
            CubeColor.Yellow,
            CubeColor.Yellow,
            CubeColor.RedYellow,
            CubeColor.RedYellow,
            CubeColor.Red,
            CubeColor.Red};

        private readonly List<CubeColor> rainbowColors = new List<CubeColor>() {
            CubeColor.Red,
            CubeColor.RedYellow,
            CubeColor.Yellow,
            CubeColor.Green,
            CubeColor.Cyan,
            CubeColor.Blue,
            CubeColor.BlueMagenta,
            CubeColor.Magenta};

        private readonly List<CubeColor> equalizerColors = new List<CubeColor>() {
            CubeColor.Green,
            CubeColor.Green,
            CubeColor.Green,
            CubeColor.Yellow,
            CubeColor.Yellow,
            CubeColor.Red,
            CubeColor.Red,
            CubeColor.Red};

        private bool rainbowMode = false;
        public FrmMusic(SerialPort serialPort, ref Cube cube)
        {
            InitializeComponent();
            this.serialPort = serialPort;
            this.cube = cube;
        }
        private static void WaveIn_DataAvailable(WaveInEventArgs e, ref double[] eightChannels, int samples = 8, bool mirrorRightChannelToLeft = true)
        {
            try
            {
                for (int i = 0; i < e.BytesRecorded; i += samples)
                {
                    eightChannels[0] = BitConverter.ToSingle(e.Buffer, i);
                    eightChannels[1] = BitConverter.ToSingle(e.Buffer, i + samples / 4);
                    eightChannels[2] = BitConverter.ToSingle(e.Buffer, i + (samples / 4) * 2);
                    eightChannels[3] = BitConverter.ToSingle(e.Buffer, i + (samples / 4) * 3);
                    if (mirrorRightChannelToLeft)
                    {
                        eightChannels[7] = BitConverter.ToSingle(e.Buffer, i + 4);
                        eightChannels[6] = BitConverter.ToSingle(e.Buffer, i + 4 + samples / 4);
                        eightChannels[5] = BitConverter.ToSingle(e.Buffer, i + 4 + (samples / 4) * 2);
                        eightChannels[4] = BitConverter.ToSingle(e.Buffer, i + 4 + (samples / 4) * 3);
                    }
                    else
                    {
                        eightChannels[4] = BitConverter.ToSingle(e.Buffer, i + 4);
                        eightChannels[5] = BitConverter.ToSingle(e.Buffer, i + 4 + samples / 4);
                        eightChannels[6] = BitConverter.ToSingle(e.Buffer, i + 4 + (samples / 4) * 2);
                        eightChannels[7] = BitConverter.ToSingle(e.Buffer, i + 4 + (samples / 4) * 3);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void FrmMusic_Load(object sender, EventArgs e)
        {
            chkMirrored.Checked = Properties.Settings.Default.Music_MirroredAudio;
            chkShowSilence.Checked = Properties.Settings.Default.Music_ShowSilence;
            cbResponsiveness.Text = Properties.Settings.Default.Music_Responsiveness;
            trkSamples.Value = Properties.Settings.Default.Music_Samples;
            cbMusicStyle.SelectedIndex = Properties.Settings.Default.Music_Style;
            cbColor.DataSource = Enum.GetValues(typeof(CubeColor));
            cbColor.SelectedIndex = Properties.Settings.Default.Music_Color;
            chkRainbow.Checked = Properties.Settings.Default.Music_Rainbow;
            chkShuffled.Checked = Properties.Settings.Default.Music_Shuffled;
            chkSyncMusic.Checked = true;
        }

        private void ChkSyncMusic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSyncMusic.Checked)
            {
                waveIn.DataAvailable += delegate (object sender2, WaveInEventArgs e2)
                { WaveIn_DataAvailable(e2, ref eightChannels, samples, chkMirrored.Checked); };

                waveIn.StartRecording();

                animate = true;
                bwVisualize.RunWorkerAsync();
            }
            else
            {
                waveIn.StopRecording();
                animate = false;
                bwVisualize.CancelAsync();
            }
        }

        private void ChkShowSilence_CheckedChanged(object sender, EventArgs e)
        {
            cubeCleared = false;
        }

        private void TrkSamples_Scroll(object sender, EventArgs e)
        {
            chkSyncMusic.Checked = false;
            samples = trkSamples.Value;
            lblSamples.Text = "Samples (" + samples + "):";
        }

        private void CbResponsiveness_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbResponsiveness.Text != "")
                speed = int.Parse(cbResponsiveness.SelectedItem.ToString());
        }

        private void CbMusicStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            cubeCleared = false;
            currentMusicStyle = cbMusicStyle.Text;
        }
        
        private void BwVisualize_DoWork(object sender, DoWorkEventArgs e)
        {
            while (animate)
            {
                cube.Clear();
                List<CubeColor> outputColors = new List<CubeColor>();
                outputColors.AddRange(new List<CubeColor>(Enumerable.Repeat(rainbowMode ? ColorHelper.RandomColor() : targetColor, 8).ToArray()));
                switch (currentMusicStyle)
                {
                    case "Tesla Ball":
                        TeslaBall(eightChannels, outputColors[0]);
                        break;
                    case "Floating Lines":
                        AnimatedLines(eightChannels, outputColors, false, false);
                        break;
                    case "Floating Dots":
                        AnimatedLines(eightChannels, outputColors, false, true);
                        break;
                    case "Filled Lines":
                        AnimatedLines(eightChannels, outputColors, true, false);
                        break;
                    case "Filled Dots":
                        AnimatedLines(eightChannels, outputColors, true, true);
                        break;
                    case "Centered Floating Lines":
                        AnimatedCenteredLines(eightChannels, outputColors, false, false);
                        break;
                    case "Centered Floating Dots":
                        AnimatedCenteredLines(eightChannels, outputColors, false, true);
                        break;
                    case "Centered Filled Lines":
                        AnimatedCenteredLines(eightChannels, outputColors, true, false);
                        break;
                    case "Centered Filled Dots":
                        AnimatedCenteredLines(eightChannels, outputColors, true, true);
                        break;
                    case "Filled Fire Lines":
                        outputColors = fireColors;
                        AnimatedLines(eightChannels, outputColors, true, false);
                        break;
                    case "Filled Fire Dots":
                        outputColors = fireColors;
                        AnimatedLines(eightChannels, outputColors, true, true);
                        break;
                    case "Filled Rainbow Lines":
                        outputColors = rainbowColors;
                        AnimatedLines(eightChannels, outputColors, true, false);
                        break;
                    case "Filled Rainbow Dots":
                        outputColors = rainbowColors;
                        AnimatedLines(eightChannels, outputColors, true, true);
                        break;
                    case "Filled Equalizer Lines":
                        outputColors = equalizerColors;
                        AnimatedLines(eightChannels, outputColors, true, false);
                        break;
                    case "Filled Equalizer Dots":
                        outputColors = equalizerColors;
                        AnimatedLines(eightChannels, outputColors, true, true);
                        break;
                }

                // Animate as normal if there is audio activity:
                if ((Math.Abs(eightChannels[0]) > 0.05 || Math.Abs(eightChannels[5]) > 0.05) && timeElapsed % speed == 0)
                {
                    SerialHelper.Send(serialPort, cube);
                    cubeCleared = false;
                }
                else
                {
                    if (!cubeCleared) // Animate silence only once:
                    {
                        cube.Clear();
                        if (chkShowSilence.Checked)
                        {
                            switch (currentMusicStyle)
                            {
                                case "Tesla Ball":
                                    cube.DrawPoint(3, 3, 3, outputColors[0]);
                                    cube.DrawPoint(3, 4, 3, outputColors[0]);
                                    cube.DrawPoint(4, 3, 3, outputColors[0]);
                                    cube.DrawPoint(4, 4, 3, outputColors[0]);
                                    cube.DrawPoint(3, 3, 4, outputColors[0]);
                                    cube.DrawPoint(3, 4, 4, outputColors[0]);
                                    cube.DrawPoint(4, 3, 4, outputColors[0]);
                                    cube.DrawPoint(4, 4, 4, outputColors[0]);
                                    break;
                                case "Floating Lines":
                                case "Filled Lines":
                                    cube.DrawPlane(Axis.Z, 0, outputColors[0]);
                                    break;
                                case "Floating Dots":
                                case "Filled Dots":
                                    for (int i = 0; i < cube.length; i++)
                                        cube.DrawPoint(i, 0, 0, outputColors[0]);
                                    break;
                                case "Centered Floating Lines":
                                case "Centered Filled Lines":
                                    cube.DrawPlane(Axis.Z, 3, outputColors[0]);
                                    break;
                                case "Centered Floating Dots":
                                case "Centered Filled Dots":
                                    for (int i = 0; i < cube.length; i++)
                                        cube.DrawPoint(i, 0, 3, outputColors[3]);
                                    break;
                                case "Filled Fire Lines":
                                case "Filled Rainbow Lines":
                                case "Filled Equalizer Lines":
                                    cube.DrawPlane(Axis.Z, 0, outputColors[0]);
                                    break;
                                case "Filled Fire Dots":
                                case "Filled Rainbow Dots":
                                case "Filled Equalizer Dots":
                                    for (int i = 0; i < cube.length; i++)
                                        cube.DrawPoint(i, 0, 0, outputColors[0]);
                                    break;
                            }
                        }
                        SerialHelper.Send(serialPort, cube);
                        cubeCleared = true;
                    }
                }
                timeElapsed++;
            }
        }

        private void AnimatedLines(double[] eightChannels, List<CubeColor> outputColor, bool filledUnderneath = false, bool dotted = false)
        {
            for (int i = 0; i < cube.length; i++)
            {
                if (Math.Abs(eightChannels[i]) > .05 && (filledUnderneath || Math.Abs(eightChannels[i]) <= .1))
                    if (dotted)
                        cube.DrawPoint(i, 0, 0, outputColor[0]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 0, outputColor[0]);
                if (Math.Abs(eightChannels[i]) > .1 && (filledUnderneath || Math.Abs(eightChannels[i]) <= .15))
                    if (dotted)
                        cube.DrawPoint(i, 0, 1, outputColor[1]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 1, outputColor[1]);
                if (Math.Abs(eightChannels[i]) > .15 && (filledUnderneath || Math.Abs(eightChannels[i]) <= .2))
                    if (dotted)
                        cube.DrawPoint(i, 0, 2, outputColor[2]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 2, outputColor[2]);
                if (Math.Abs(eightChannels[i]) > .2 && (filledUnderneath || Math.Abs(eightChannels[i]) <= .25))
                    if (dotted)
                        cube.DrawPoint(i, 0, 3, outputColor[3]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 3, outputColor[3]);                
                if (Math.Abs(eightChannels[i]) > .25 && (filledUnderneath || Math.Abs(eightChannels[i]) <= .3))
                    if (dotted)
                        cube.DrawPoint(i, 0, 4, outputColor[4]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 4, outputColor[4]);
                if (Math.Abs(eightChannels[i]) > .3 && (filledUnderneath || Math.Abs(eightChannels[i]) <= .4))
                    if (dotted)
                        cube.DrawPoint(i, 0, 5, outputColor[5]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 5, outputColor[5]);
                if (Math.Abs(eightChannels[i]) > .4 && (filledUnderneath || Math.Abs(eightChannels[i]) <= .5))
                    if (dotted)
                        cube.DrawPoint(i, 0, 6, outputColor[6]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 6, outputColor[6]);
                
                if (Math.Abs(eightChannels[i]) > .5)
                    if (dotted)
                        cube.DrawPoint(i, 0, 7, outputColor[7]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 7, outputColor[7]);
            }
        }
        
        private void AnimatedCenteredLines(double[] eightChannels, List<CubeColor> outputColor, bool filledUnderneath = false, bool dotted = false)
        {
            for (int i = 0; i < cube.length; i++)
            {
                // Negatives for Channel i:
                if (eightChannels[i] <= -.05 && (filledUnderneath || eightChannels[i] > -.15))
                    if (dotted)
                        cube.DrawPoint(i, 0, 3, outputColor[3]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 3, outputColor[3]);
                if (eightChannels[i] <= -.15 && (filledUnderneath || eightChannels[i] > -.25))
                    if (dotted)
                        cube.DrawPoint(i, 0, 2, outputColor[2]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 2, outputColor[2]);
                if (eightChannels[i] <= -.25 && (filledUnderneath || eightChannels[i] > -.35))
                    if (dotted)
                        cube.DrawPoint(i, 0, 1, outputColor[1]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 1, outputColor[1]);
                if (eightChannels[i] <= -.35)
                    if (dotted)
                        cube.DrawPoint(i, 0, 0, outputColor[0]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 0, outputColor[0]);

                // Positives for Channel i:
                if (eightChannels[i] >= .05 && (filledUnderneath || eightChannels[i] < .15))
                    if (dotted)
                        cube.DrawPoint(i, 0, 4, outputColor[4]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 4, outputColor[4]);
                if (eightChannels[i] >= .15 && (filledUnderneath || eightChannels[i] < .25))
                    if (dotted)
                        cube.DrawPoint(i, 0, 5, outputColor[5]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 5, outputColor[5]);
                if (eightChannels[i] >= .25 && (filledUnderneath || eightChannels[i] < .35))
                    if (dotted)
                        cube.DrawPoint(i, 0, 6, outputColor[6]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 6, outputColor[6]);
                if (eightChannels[i] >= .35)
                    if (dotted)
                        cube.DrawPoint(i, 0, 7, outputColor[7]);
                    else
                        cube.DrawStraightLine(Axis.X, i, 7, outputColor[7]);
            }
        }

        private void FrmMusic_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            if (chkSyncMusic.Checked)
            {
                waveIn.StopRecording();
                animate = false;
                bwVisualize.CancelAsync();
            }
        }

        private void TeslaBall(double[] channels, CubeColor outputColor)
        {
            int xStart = 3;
            int xEnd = 4;
            foreach (double channel in channels)
            {
                if (Math.Abs(channel) > .05 && Math.Abs(channel) <= .1)
                {
                    xStart = 3;
                    xEnd = 4;
                }
                if (Math.Abs(channel) > .1 && Math.Abs(channel) <= .15)
                {
                    xStart = 3;
                    xEnd = 4;
                }
                if (Math.Abs(channel) > .15 && Math.Abs(channel) <= .2)
                {
                    xStart = 2;
                    xEnd = 5;
                }
                if (Math.Abs(channel) > .2 && Math.Abs(channel) <= .25)
                {
                    xStart = 2;
                    xEnd = 5;
                }
                if (Math.Abs(channel) > .25 && Math.Abs(channel) <= .3)
                {
                    xStart = 1;
                    xEnd = 6;
                }
                if (Math.Abs(channel) > .3 && Math.Abs(channel) <= .4)
                {
                    xStart = 1;
                    xEnd = 6;
                }
                if (Math.Abs(channel) > .4 && Math.Abs(channel) <= .5)
                {
                    xStart = 0;
                    xEnd = 7;
                }
                if (Math.Abs(channel) > .5)
                {
                    xStart = 0;
                    xEnd = 7;
                }
            }
            cube.DrawLine(
                random.Next(xStart, xEnd + 1),
                random.Next(xStart, xEnd + 1),
                random.Next(xStart, xEnd + 1),
                random.Next(xStart, xEnd + 1),
                random.Next(xStart, xEnd + 1),
                random.Next(xStart, xEnd + 1),
                outputColor);
        }

        private void CbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetColor = (CubeColor)Enum.Parse(typeof(CubeColor), cbColor.Text);
        }

        private void ChkRainbow_CheckedChanged(object sender, EventArgs e)
        {
            rainbowMode = chkRainbow.Checked;
            cbColor.Enabled = !chkRainbow.Checked;
        }

        private void TmrShuffle_Tick(object sender, EventArgs e)
        {
            cbMusicStyle.SelectedIndex = random.Next(0, cbMusicStyle.Items.Count);
            cbColor.SelectedIndex = random.Next(1, cbColor.Items.Count); // Skip Black
        }

        private void ChkShuffled_CheckedChanged(object sender, EventArgs e)
        {
            tmrShuffle.Enabled = chkShuffled.Checked;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Music_MirroredAudio = chkMirrored.Checked;
            Properties.Settings.Default.Music_ShowSilence = chkShowSilence.Checked;
            Properties.Settings.Default.Music_Responsiveness = cbResponsiveness.Text;
            Properties.Settings.Default.Music_Samples = trkSamples.Value;
            Properties.Settings.Default.Music_Style = cbMusicStyle.SelectedIndex;
            Properties.Settings.Default.Music_Color = cbColor.SelectedIndex;
            Properties.Settings.Default.Music_Rainbow = chkRainbow.Checked;
            Properties.Settings.Default.Music_Shuffled = chkShuffled.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
