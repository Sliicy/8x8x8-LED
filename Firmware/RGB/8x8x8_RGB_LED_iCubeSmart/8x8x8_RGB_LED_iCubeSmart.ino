/*
 * This library contains instructions used for controlling an 8x8x8 RGB LED Cube over USB-Serial UART.
 * The board used (from iCubeSmart) can be found at: https://www.amazon.com/dp/B09CYV765C
 * 
 * The Cube is represented by a multi-dimensional array, consisting of:
 * multiple cubes (referred to as colorDepth),
 * each cube containing 8 vertical levels (Z-Axis),
 * and each level containing 24 bytes (Y-Axis, and each byte controls the corresponding X-Axis).
 * 
 * Multiple cubes are rendered to add the ability to mix colors (alternating between yellow + red creates orange).
 * Using 8 colors (Black, White, Red, Green, Blue, Cyan, Magenta, & Yellow), a color depth of 2 yields 36 different color combinations.
 *
 * The cube is updated over UART Serial, with the following data structure:
 * HEADER + PAYLOAD
 * 
 * The Header is 6 bytes, and the payload is 48 bytes, totalling 54 bytes.
 * This was done due to limitations in Arduino's Serial Buffer (it cannot normally read more than 64 bytes at once).
 * 
 * The Header always starts with 0x00, 0xFF, 0x00, 0x00, and is followed by a byte which corresponds to the depth being rendered (0, 1, etc.),
 * followed by another byte which corresponds to the level being rendered (0, 2, 4, or 6).
 * 
 * Example:
 * 
 * To update the entire cube to Red, assuming the colorDepth is set to 1, the following 2 payloads need to be sent (in either order):

0x00, 0xFF, 0x00, 0x00,                                                 // Header
0x00,                                                                   // Color Depth = 0
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, // Payload
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,


0x00, 0xFF, 0x00, 0x00,                                                 // Header
0x01,                                                                   // Color Depth = 1
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, // Same Payload as before
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,

 */

// Onboard LEDs:
#define LED_Red       PB8
#define LED_Green     PB9

// TX/RX Ports for Serial UART:
#define RX            PA10
#define TX            PA9

// Onboard Buttons:
#define Button_Start  PC0     // Start/Pause Button
#define Button_Next   PC1     // Next Button
#define Button_Cycle  PC2     // Cycle Mode Button

// Shift Register (MBI5024):
#define SPI_Clock     PA5     // SPI Clock - Clock input terminal for data shift
#define SPI_MOSI      PA7     // SPI MOSI - Serial-data input to the shift register
#define LE            PC4     // LE - Data strobe input terminal (latch pin)
#define OE            PC5     // OE - Output enable terminal

// Demultiplexer (74HC138):
#define A0            PB0     // A0
#define A1            PB1     // A1
#define A2            PB10    // A2
#define ENABLE_PIN    PB11    // Enable Pin

// Instance of Serial used for UART:
HardwareSerial Serial1(RX, TX);

// Retains the state of different buttons being pressed:
int buttonPressCountStart = 0;
int buttonPressCountNext = 0;
int buttonPressCountCycle = 0;

// Contains the state of any button being pressed:
bool startButtonPressed = false;
bool nextButtonPressed = false;
bool cycleButtonPressed = false;
const int BUTTON_PRESS_THRESHOLD = 2;

// Number of "cubes" that cube cycles between.
/*
 * For example, a color depth of 1 can only produce 7 colors: red, green, blue, violet, cyan, yellow, and white.
 * The higher the depth, the more "cubes" that the cube is rendering.
 */
const int colorDepth = 2;

// Height of cube (Z-Axis):
const int height = 8;

// Number of rows front-to-back (Y-Axis):
const int yAxisRows = 8;

// Number of primary colors: Red, Green, Blue:
const int primaryColors = 3;

// The Y-Axis is responsible for lighting up different primary colors (in this case, 24 states):
const int yAxisStates = primaryColors * yAxisRows;

/* Contains the max value each Serial read should store (consisting of 2x color layers +
 *  1 byte prepended corresponding to color depth to update):
 */
const byte numBytes = yAxisStates * height + 1;
byte receivedBytes[numBytes]; // Array that holds incoming data to paint the cube.
bool newData = false; // Controls whether incoming data has finished being read.
byte header[] = {0x00, 0xFF, 0x00, 0x00}; // The header used to delineate incoming data.

int targetColorDepth = 0; // Contains the destination color layer that is to be rendered.

// The Cube, represented by a multidimensional array of bytes (each byte lighting up an X-Axis row of LEDs).
/*
 * If a byte is set to 0, the entire row is off.
 * If a byte is 1, the leftmost LED is on.
 * If a byte is 255, the entire row is on.
 */
byte cube[colorDepth][height][yAxisStates] =
{{
// G  G  B  B  R  R  G  G  B  B  R  R  G  G  B  B  R  R  G  G  B  B  R  R
{0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255}, // Red
{0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255}, // Red+Yellow
{255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255}, // Yellow
{255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0}, // Green
{255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0}, // Cyan
{0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0}, // Blue
{0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255}, // Magenta
{255, 255, 255, 0, 0, 0, 255, 255, 255, 0, 0, 0, 255, 255, 255, 0, 0, 0, 255, 255, 255, 0, 0, 0}, // White
},{
{0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255}, // Red
{255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255}, // Yellow+Red
{255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255}, // Yellow
{255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0}, // Green
{255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0}, // Cyan
{0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0, 0, 0, 255, 255, 0, 0}, // Blue
{0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255, 0, 0, 255, 255, 255, 255}, // Magenta
{0, 0, 0, 255, 255, 255, 0, 0, 0, 255, 255, 255, 0, 0, 0, 255, 255, 255, 0, 0, 0, 255, 255, 255}, // White
}};

void setup() {

  // Onboard LEDs:
  pinMode(LED_Red, OUTPUT);
  pinMode(LED_Green, OUTPUT);

  // Buttons:
  pinMode(Button_Start, INPUT);
  pinMode(Button_Next, INPUT);
  pinMode(Button_Cycle, INPUT);

  // Shift Register:
  pinMode(SPI_Clock, OUTPUT);
  pinMode(SPI_MOSI, OUTPUT);
  pinMode(LE, OUTPUT);
  pinMode(OE, OUTPUT);

  // Demultiplexer:
  pinMode(A0, OUTPUT);
  pinMode(A1, OUTPUT);
  pinMode(A2, OUTPUT);
  pinMode(ENABLE_PIN, OUTPUT);

  // Open serial port and listen:
  Serial1.begin(38400);
}

// Switches electricity to the requested Z-Axis (0 - 7):
void switchToLayerZ(int z) {
  // Map the z-axis layer to the correct A0, A1, A2 values
  digitalWrite(A0, z & 1); // LSB
  digitalWrite(A1, (z >> 1) & 1);
  digitalWrite(A2, (z >> 2) & 1);
}

// Clear entire layer:
void clearCurrentLayer() {
  digitalWrite(LE, LOW);
  for (int i = 0; i < yAxisStates; i++) 
    shiftOut(SPI_MOSI, SPI_Clock, LSBFIRST, 0);
  digitalWrite(LE, HIGH);
}

// Method responsible for reading bytes from Serial and rendering parts of the cube:
void readIncomingBytes() {
    static boolean recvInProgress = false;  // Controls whether the cube is currently receiving data.
    static byte ndx = 0;                    // Index of current incoming byte.
    int triggerStart = 0;                   // Keeps track of whether the entire header was read from Serial.
    byte rb;                                // Current byte being read from Serial.

    while (Serial1.available() > 0 && newData == false) {
        rb = Serial1.read();
        if (recvInProgress == true) {
            if (ndx < numBytes - 1) {
                receivedBytes[ndx] = rb;
                ndx++;
                if (ndx >= numBytes) ndx = numBytes - 1;
            } else if (ndx == numBytes - 1) {
                receivedBytes[ndx] = rb;
                recvInProgress = false;
                ndx = 0;
                newData = true;
            }
        } else if (rb == header[triggerStart] && triggerStart == sizeof(header)) {
          recvInProgress = true;
          triggerStart = 0;
        } else if (rb == header[triggerStart] && triggerStart < sizeof(header)) {
          triggerStart++;
          if (triggerStart == sizeof(header)) {
            recvInProgress = true;
            triggerStart = 0;
          }
        } else {
          triggerStart = 0;
        }
    }
}

void handleButtonPress(int buttonState, int &pressCount, int colorValue, bool cycleEffect) {
  if (buttonState == LOW) { // LOW = Pressed
    pressCount++;
    if (pressCount > BUTTON_PRESS_THRESHOLD) {
      paintCube(colorValue);
      if (cycleEffect) {
        randomizeCube();
      }
    }
  }
}

// Paints the entire cube whatever value is given (0 - 255):
void paintCube(int value) {
  for (int c = 0; c < colorDepth; c++) {
    for (int z = 0; z < height; z++) {
      for (int y = 0; y < yAxisStates; y++) {
        cube[c][z][y] = value;
      }
    }
  }
}

// Function to randomize the cube values
void randomizeCube() {
    for (int color = 0; color < colorDepth; ++color) {
        for (int heightIdx = 0; heightIdx < height; ++heightIdx) {
            for (int yAxis = 0; yAxis < yAxisStates; ++yAxis) {
                cube[color][heightIdx][yAxis] = rand() % 256; // Random value between 0 and 255
            }
        }
    }
}

void loop() {
  startButtonPressed = digitalRead(Button_Start);
  nextButtonPressed = digitalRead(Button_Next);
  cycleButtonPressed = digitalRead(Button_Cycle);

  handleButtonPress(startButtonPressed, buttonPressCountStart, 255, false);
  handleButtonPress(nextButtonPressed, buttonPressCountNext, 0, false);
  handleButtonPress(cycleButtonPressed, buttonPressCountCycle, 0, true);
  
  renderCube();
  readAndUpdateCube();
}

void renderCube() {
  // Loop through color depth and Z-axis layers
  for (int c = 0; c < colorDepth; c++) {
    for (int z = 0; z < height; z++) {
      clearCurrentLayer();
      switchToLayerZ(z);
      digitalWrite(LE, LOW);
      
      // Render each Y-axis layer
      for (int y = 0; y < yAxisStates; y++) {
        // Render each X-axis byte-layer
        shiftOut(SPI_MOSI, SPI_Clock, LSBFIRST, cube[c][z][y]);
      }
      digitalWrite(LE, HIGH);
    }
  }
}

void readAndUpdateCube() {
  readIncomingBytes();
  if (newData) {
    targetColorDepth = receivedBytes[0];
    updateCubeWithNewData();
    newData = false;
  }
}

void updateCubeWithNewData() {
  // Update the cube with the received bytes
  for (int z = 0; z < height; z++) {
    for (int y = 0; y < yAxisStates; y++) {
      cube[targetColorDepth][z][y] = receivedBytes[z * 24 + y + 1];
    }
  }
}
