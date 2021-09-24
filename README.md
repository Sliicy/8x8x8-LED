# 8x8x8-LED
Project that can control an 8x8x8 LED matrix cube and display anything on it.

<img src="/Screenshots/Logo.png" alt="8x8x8 LED Logo" width="100"/>

## About this Project

This project was inspired by [Tomazas' firmware](https://github.com/tomazas/ledcube8x8x8) for controlling 8x8x8 LED Cubes, as well as [Aguegu's Java program](https://github.com/aguegu/DotMatrixJava) used to control the cube in real-time.

This project consists of a series of mini applets that can be used to display various animations on any cube that adheres to the same data standards Tomazas created.

## How to Run

1) Simply download the latest release [here](https://github.com/Sliicy/8x8x8-LED/releases/). Extract the .zip file and run '8x8x8 LED.exe'.
2) When using for the first time, after opening the program, head to the 2nd tab titled 'Settings', then the subsection 'Connection', and ensure the COM port has the right port selected for the cube.
3) The recommended baud rate is 19200, with 8 Data bits, 1 Stop bits, and no Parity.
4) Next, press the 'Connect' button at the bottom.
5) If done correctly, there won't be any error messages. You can also send a test packet in the 'Send Packet' subsection, to light up all the LEDs.
6) Finally, you will want to ensure that the orientation is correct, so press the 'Calibrate Cube' button in the 'Rotation' subsection of Settings, to calibrate the cube.
7) These connection settings are automatically saved. Once done with this step, head over to the 'Menu' tab, select an applet, and then open it.

## Note about using the iCubeSmart

Since I have a slightly different cube than the aformentioned cube in [Tomazas' firmware](https://github.com/tomazas/ledcube8x8x8), I had to fork my own version, and modify the firmware to get it to work. [Here](https://github.com/Sliicy/ledcube8x8x8) is a link to the project (I'm using the [v2-sdcc-icubesmart](https://github.com/Sliicy/ledcube8x8x8/tree/master/firmware/v2-sdcc-icubesmart)). Just flash the .ihx file as a regular .hex using the [STC flashing tool](https://github.com/tomazas/ledcube8x8x8/tree/master/tools).

## Examples
The following are some videos of various animations in action:

### Music Visualizer
There are 9 different styles to choose from, each animating the cube based on music being played.

![Music](/Screenshots/Music.gif)
![Music Visualizer](/Screenshots/Music-Screenshot.png)

### Marquee
You can type any message into the textbox, and the cube will continuously scroll the text into view.

![Marquee](/Screenshots/Marquee.gif)

### Clock
This will display the current time on the cube.

![Clock Demonstrating Standard Time](/Screenshots/Standard-Time.jpg)
![Clock Demonstrating Army Time](/Screenshots/Army-Time.jpg)

### Snake Game
This will let you play the classic 'Snake Game' (it currently is a little buggy).

![Clock Demonstrating Army Time](/Screenshots/Snake.gif)

### Pong Game
This will let you play the classic 'Pong Game' with a friend.

![Clock Demonstrating Army Time](/Screenshots/Pong.gif)

### Image Viewer
This will let you open an image and project it onto the cube.

![Clock Demonstrating Army Time](/Screenshots/Image-Viewer.jpg)
![Clock Demonstrating Army Time](/Screenshots/Image-Viewer.png)

### Video Player
This will let you open an image and animate it onto the cube.

![Clock Demonstrating Army Time](/Screenshots/Video.gif)

### Rain Animation
This will display rain droplets.

![Clock Demonstrating Army Time](/Screenshots/Rain.gif)

### Ball Animation
This will display bouncing balls (optionally syncable to music being played).

![Clock Demonstrating Army Time](/Screenshots/Balls.gif)

## Future Development

Anyone is welcome to provide suggestions, improvements, changes, bugs found, etc. Furthermore, I might decide to add support for RGB cubes in the near future.
