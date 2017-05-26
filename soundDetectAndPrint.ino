// demo of Starter Kit V2.0 - Grove Sound Sensor
// when sound larger than a certain value, led will on
#include <Wire.h>
#include "rgb_lcd.h"

const int pinSound = A0;               // pin of Sound Sensor
const int pinLed   = 7;                // pin of LED

int thresholdValue = 425;                 // the threshold to turn on or off the LED

rgb_lcd lcd;

const int colorR = 255;
const int colorG = 0;
const int colorB = 0;
void setup()
{
    pinMode(pinLed, OUTPUT);            //set the LED on Digital 12 as an OUTPUT

    lcd.begin(16, 1);
    lcd.setRGB(colorR, colorG, colorB);
}

void loop()
{
    int sensorValue = analogRead(pinSound);   //read the sensorValue on Analog 0
    printf("Threshold Value: %d", sensorValue);
    lcd.clear();
    lcd.print(sensorValue);
    delay(250);
    if(sensorValue>thresholdValue){
      turnOnLED();
    }
    else
    {
      turnOffLED();
    }
}

void turnOnLED()
{
  digitalWrite(pinLed,HIGH);
}

void turnOffLED()
{
  digitalWrite(pinLed,LOW);
}

