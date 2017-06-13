/**
 *  QRCode
 *
 *  A quick example of generating a QR code.
 *
 *  This prints the QR code to the serial monitor as solid blocks. Each module
 *  is two characters wide, since the monospace font used in the serial monitor
 *  is approximately twice as tall as wide.
 *
 */

#include "qrcode.h"

#define LCD_CS A3 // Chip Select goes to Analog 3
#define LCD_CD A2 // Command/Data goes to Analog 2
#define LCD_WR A1 // LCD Write goes to Analog 1
#define LCD_RD A0 // LCD Read goes to Analog 0
#define LCD_RESET A4 // Can alternately just connect to Arduino's reset pin

#include <SPI.h>          // f.k. for Arduino-1.5.2
#include "Adafruit_GFX.h"// Hardware-specific library
#include <MCUFRIEND_kbv.h>
MCUFRIEND_kbv tft;
//#include <Adafruit_TFTLCD.h>
//Adafruit_TFTLCD tft(LCD_CS, LCD_CD, LCD_WR, LCD_RD, LCD_RESET);
#define SERIALCOMMAND_DEBUG
#define  BLACK   0x0000
#define BLUE    0x001F
#define RED     0xF800
#define GREEN   0x07E0
#define CYAN    0x07FF
#define MAGENTA 0xF81F
#define YELLOW  0xFFE0
#define WHITE   0xFFFF

#include <SoftwareSerial.h>
#include <SerialCommand.h>      // Steven Cogswell ArduinoSerialCommand library from http://GitHub.com
SerialCommand     serialCommand;


void ChangeId(String text) {

           QRCode qrcode;
       uint8_t qrcodeData[qrcode_getBufferSize(3)];
    qrcode_initText(&qrcode, qrcodeData, 3, 0, text.c_str());
    Serial.print("Called");
    draw(qrcode);
}

void draw(QRCode &qrcode) {
    tft.fillScreen(WHITE);

  
    for (uint8_t y = 0; y < qrcode.size; y++) {


        // Each horizontal module
        for (uint8_t x = 0; x < qrcode.size; x++) {

            // Print each module (UTF-8 \u2588 is a solid block)
            if(qrcode_getModule(&qrcode, x, y))
              tft.fillRect(x * 8 + 20, y * 8 + 5, 8 , 8, BLACK);
        }

    }
}

void UnrecognizedCommand() {
  Serial.print("twas I ");
}

void setup() {
    Serial.begin(9600);
  
    // Start time
    uint32_t dt = millis();
  
    // Create the QR code

        QRCode qrcode;
       uint8_t qrcodeData[qrcode_getBufferSize(3)];
    qrcode_initText(&qrcode, qrcodeData, 3, 0, "TEST");
  
    // Delta time
    dt = millis() - dt;

      uint16_t ID = tft.readID(); //

  tft.begin(ID);

  draw(qrcode);
}


void loop() {
while(Serial.available()) {

String text = Serial.readString();// read the incoming data as string

Serial.println(text);
ChangeId(text);
}
}
