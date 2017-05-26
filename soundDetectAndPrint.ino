// demo of Starter Kit V2.0 - Grove Sound Sensor
// when sound larger than a certain value, led will on
#include <Wire.h>
#include "rgb_lcd.h"

const int pinButton = 8;

const int pinSound1 = A0;               // pin of Sound Sensor
const int pinSound2 = A1;
const int pinLed   = 7;                // pin of LED

int thresholdValue = 400;                 // the threshold to turn on or off the LED

int sensorOneHigh = 0;
int sensorOneAvg = 0;
int sensorOneSum = 0;

int sensorTwoHigh = 0;
int sensorTwoAvg = 0;
int sensorTwoSum = 0;

int recordings = 0;

rgb_lcd lcd;

const int colorR = 255;
const int colorG = 0;
const int colorB = 255;

void setup()
{
    pinMode(pinLed, OUTPUT);            //set the LED on Digital 12 as an OUTPUT
    
    pinMode(pinButton, INPUT);
    
    lcd.begin(16, 2);
    lcd.setRGB(colorR, colorG, colorB);
}

void loop()
{
    int sensorValue = analogRead(pinSound1);   //read the sensorValue on Analog 0
    int sensorValue2 = analogRead(pinSound2);
    
    if(sensorValue > sensorOneHigh)
    {
      sensorOneHigh = sensorValue;
    }

    if(sensorValue2 > sensorTwoHigh)
    {
      sensorTwoHigh = sensorValue2;
    }

    recordings++;

    sensorOneSum += sensorValue;
    sensorTwoSum += sensorValue2;
    
    sensorOneAvg = sensorOneSum/recordings;
    sensorTwoAvg = sensorTwoSum/recordings;

    if(sensorValue>thresholdValue){
      turnOnLED();
    }
    else
    {
      turnOffLED();
    }

    lcd.clear();

    lcd.setCursor(0, 0);
    lcd.print("SO");
    lcd.print(sensorValue);
    
    lcd.setCursor(6, 0);
    lcd.print(" H");
    lcd.print(sensorOneHigh);
    
    lcd.setCursor(11, 0);
    lcd.print(" A");
    lcd.print(sensorOneAvg);

    lcd.setCursor(0, 1);
    lcd.print("ST");
    lcd.print(sensorValue2);
    
    lcd.setCursor(6, 1);
    lcd.print(" H");
    lcd.print(sensorTwoHigh);
    
    lcd.setCursor(11, 1);
    lcd.print(" A");
    lcd.print(sensorTwoAvg);

    if(digitalRead(pinButton))
    {
      digitalWrite(pinLed, HIGH);
      
      sensorOneSum = 0;
      sensorTwoSum = 0;

      sensorOneAvg = 0;
      sensorTwoAvg = 0;

      sensorOneHigh = 0;
      sensorTwoHigh = 0;
      
      recordings = 0;
    }
    
    delay(250);
}

void turnOnLED()
{
  digitalWrite(pinLed,HIGH);
}

void turnOffLED()
{
  digitalWrite(pinLed,LOW);
}

