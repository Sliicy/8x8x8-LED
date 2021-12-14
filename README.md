# 8x8x8-LED
Project for controlling an 8x8x8 LED/RGB matrix cube over USB.

<img src="/Screenshots/Logo.png" alt="8x8x8 LED Logo" width="100"/>

## About this Project
This project was inspired by [Tomazas' firmware](https://github.com/tomazas/ledcube8x8x8) for controlling 8x8x8 LED Cubes, as well as [Aguegu's Java program](https://github.com/aguegu/DotMatrixJava) used to control the cube in real-time.

This project consists of a series of mini applets that can be used to display various animations on both Monochrome and RGB cubes.

## Video Demo RGB
[![8x8x8 RGB Cube](https://img.youtube.com/vi/DU16Db5-o1E/0.jpg)](https://www.youtube.com/watch?v=DU16Db5-o1E)


## Examples
The following are some videos of various animations in action:

### Music Visualizer
There are a bunch of different styles to choose from, each animating the cube based on music being played (some are briefly shown below via the Monochrome Cube).

![Music](/Screenshots/Music.gif)
![Fire Music](/Screenshots/Fire-Music.png)

### Marquee
You can type any message into the textbox, and the cube will continuously scroll the text into view.

![Marquee](/Screenshots/Marquee.gif)

### Clock
This will display the current time on the cube.

![Clock using RGB Cube](/Screenshots/Clock.png)
![Clock Demonstrating Standard Time](/Screenshots/Standard-Time.jpg)

### Pong Game
This will let you play the classic 'Pong Game' with a friend.

![Clock Demonstrating Army Time](/Screenshots/Pong.png)

### Image Viewer
This will let you open an image and project it onto the cube.

![Circle](/Screenshots/Image-Viewer.jpg)
![Drawing a Circle](/Screenshots/Image-Viewer.png)
![Heart](/Screenshots/Heart.png)
![Smiley Face](/Screenshots/Smiley.png)

### Video Player
This will let you open an image and animate it onto the cube.

![Clock Demonstrating Army Time](/Screenshots/Video.gif)

### Rain Animation
This will display rain droplets.

![Clock Demonstrating Army Time](/Screenshots/Rain.gif)

### Ball Animation
This will display bouncing balls (optionally syncable to music being played).

![Clock Demonstrating Army Time](/Screenshots/Balls.gif)

### Not Pictured
- Lamp - Lights up the cube at specified times (like a nightlight).
- Lightning - Bolts of lightning travel around the cube sporatically.
- Snake - Simple snake game.

## How to Build
<details>
  <summary>iCubeSmart 3D8-S-DIP board (Monochrome version)</summary>

  ## How to Build for the iCubeSmart 3D8-S-DIP board (Monochrome version)
  The schematic for the board I used can be found [here](https://github.com/Sliicy/ledcube8x8x8/blob/master/schematics/iCubeSmart%20Schematic.pdf). Rather than building the PCB and all, I simply purchased a ready-to-assemble board on [Amazon](https://www.amazon.com/Icubesmart-Animation-Electronic-Teenagers-Activities/dp/B07GRDRPST).

1) After purchasing and assembling the board, I connected TXD, RXD, and Ground (skipping 5V until later) to the USB to TTL adapter it shipped with, and used the STC program (https://github.com/Sliicy/ledcube8x8x8/blob/master/tools/stc-isp-15xx-v6.85.zip) to flash the cube. My particular settings were as follows:
 * MCU Type: STC12C5A60S2
 * COM Port: Select the one that has CH340
 * Min Baud Rate: 9600
 * Max Baud Rate: 9600


![STC Settings](https://user-images.githubusercontent.com/23116873/127097458-40155d32-88da-4519-a718-3c50a148ca29.png)

2) Press on 'Open Code File', and select the .hex or .ihx file to flash to the cube. I modified Tomazas' existing firmware to get it to work with my board, which can be downloaded here: https://github.com/Sliicy/ledcube8x8x8/blob/master/firmware/v2-sdcc-icubesmart/firmware.ihx
3) Before continuing, I first clicked on 'Check MCU' just to make sure that the cube was properly being recognized. After clicking on the button, I connected 5V at this point, and then the board was recognized (MCU ID : D17EC59205195F, MCU type: STC12C5A60S2, F/W version: 7.1.4I).
4) After confirming that the board was being read properly, I disconnected 5V again, and clicked on 'Download/Program', and then reconnected the 5V, to get the cube to flash the firmware.
5) At this point, the cube should be flashed, and the cube should be able to talk to the program.

## Note about using the iCubeSmart Monochrome Cube
Since I have a slightly different cube than the aformentioned cube in [Tomazas' firmware](https://github.com/tomazas/ledcube8x8x8), I had to fork my own version, and modify the firmware to get it to work. [Here](https://github.com/Sliicy/ledcube8x8x8) is a link to the project (I'm using the [v2-sdcc-icubesmart](https://github.com/Sliicy/ledcube8x8x8/tree/master/firmware/v2-sdcc-icubesmart)). Just flash the .ihx file as a regular .hex using the [STC flashing tool](https://github.com/tomazas/ledcube8x8x8/tree/master/tools).
</details>
<details>
  <summary>iCubeSmart 3D8RGB board (RGB version)</summary>

  ## How to Build for the iCubeSmart 3D8RGB board (RGB version)
This cube's motherboard features a separately mounted yellow board, controlled by a GD32F103RET6 microcontroller (similar to the STM32 series).

There is a YouTube video that explains the process of setting up Arduino with the STM32: https://www.youtube.com/watch?v=Myon8H111PQ

1) Install Arduino IDE
2) Install STM32 Cube Programmer (https://www.st.com/en/development-tools/stm32cubeprog.html). Arduino requires this installed to be able to flash to it.
3) Add the following URL to Additional Board Manager URLs (File > Preferences):
https://github.com/stm32duino/BoardManagerFiles/raw/main/package_stmicroelectronics_index.json
4) In Tools > Boards Manager, install the latest version of STM32 (2.1.0+)
5) Open the "8x8x8_RGB_LED_iCubeSmart.ino"
6) Select "Generic STM32F1 series" under Tools > Board
7) Select "Generic F103RETx" under Tools > Board part number
8) Select "STM32CubeProgrammer (Serial)" under Tools > Upload Method
9) Beneath the 8x8x8 board (on the smaller yellow board), ensure the Download switch is set to 0 (Boot1=0), and the Run switch is set to 0 (Boot0=0)
10) Power the cube with both the 5V 2A cable, as well as the 4 USB cables to the USB to TTL:
* GND to GND
* TXD to TXD
* RXD to RXD
* 5V to 5V
* Jumper connecting both 3V3 and VCC
11) Press Reset Button and then "Upload" in Arduino
12) Toggle both switches on the yellow board so that the Download switch is set to 1 (Boot0=1) and Run switch is set to 1 (Boot1=1)
13) The cube should now be ready for UART Serial Communication
</details>



## How to Run
1) Simply download the latest release [here](https://github.com/Sliicy/8x8x8-LED/releases/). Extract the .zip file and run '8x8x8 LED.exe'.
2) When using for the first time, after opening the program, head to the 2nd tab titled 'Settings', then the subsection 'Connection', and ensure the COM port has the right port selected for the cube.
3) Make sure the appropriate cube is selected (Monochrome or RGB).
4) For the Monochrome version, the baud rate is 19200 bps. For the RGB version, the baud rate is 2000000 bps. Both versions use 8 Data bits, 1 Stop bits, and no Parity.
5) Next, press the 'Connect' button at the bottom.
6) If done correctly, there shouldn't be any error messages. You can also send a test packet in the 'Send Packet' subsection, to light up all the LEDs.
7) Finally, you will want to ensure that the orientation is correct, so press the 'Calibrate Cube' button in the 'Rotation' subsection of Settings, to calibrate the cube.
8) These connection settings are automatically saved. Once done with this step, head over to the 'Menu' tab, select an applet, and then open it.

## Future Development
Anyone is welcome to provide suggestions, improvements, changes, bugs found, etc.
