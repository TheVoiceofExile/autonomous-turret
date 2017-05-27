// demo of Starter Kit V2.0 - Grove Sound Sensor
// when sound larger than a certain value, led will on
#include <Wire.h>
#include <Servo.h>
#include "rgb_lcd.h"

//Servo myservo;

const int pinButton = 8;

const int pinServo = A2;

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
    //myservo.attach(A3);

    //myservo.write(90);
    
    
    
    lcd.begin(16, 2);
    lcd.setRGB(colorR, colorG, colorB);
}

void loop()
{
    int sensorValue = analogRead(pinSound1);   //read the sensorValue on Analog 0
    int sensorValue2 = analogRead(pinSound2);

    analogWrite(pinServo, HIGH);
    
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

    if(sensorValue > thresholdValue){
      turnOnLED();
      leftVRight(sensorValue, sensorValue2);
    }
    else if(sensorValue2 > thresholdValue)
    {
      turnOnLED();
      leftVRight(sensorValue, sensorValue2);
    }
    else
    {
      turnOffLED();
    }

    //writeSensor1Current(sensorValue);
    writeSensor1High(sensorOneHigh);
    //writeSensor1Average(sensorOneAvg);

    //writeSensor2Current(sensorValue2);
    writeSensor2High(sensorTwoHigh);
    //writeSensor2Average(sensorTwoAvg);
    
    

    if(digitalRead(pinButton))
    {
      digitalWrite(pinLed, HIGH);
      
      reset();
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

void leftVRight(int sensorValue, int sensorValue2)
{
  int greater = 0;
  
  if(sensorValue > sensorValue2)
  {
    greater = sensorValue;
    lcd.setCursor(9, 0);
    lcd.print("S-Left");
  }
  else if( sensorValue2 > sensorValue)
  {
    greater = sensorValue2;
    lcd.setCursor(9, 0);
    lcd.print("S-Right");
  }

  lcd.setCursor(9, 1);
  lcd.print(greater);
  delay(500);
  lcd.clear();
}

void adjustServo(int sensorValue, int sensorValue2)
{
  float ratio = 0;
  float angle = 0;

  ratio = ((float)sensorValue2)/((float)sensorValue2);

  angle = ratio * 90;

  if(ratio < 90)
  {
    
  }
}

void reset()
{
  sensorOneSum = 0;
  sensorTwoSum = 0;

  sensorOneAvg = 0;
  sensorTwoAvg = 0;

  sensorOneHigh = 0;
  sensorTwoHigh = 0;

  recordings = 0;
}

void writeSensor1Current(int sensorValue)
{
  lcd.setCursor(0, 0);
  lcd.print("SO");
  lcd.print(sensorValue);
}

void writeSensor1High(int sensorOneHigh){
  lcd.setCursor(0, 0);
  lcd.print("H1: ");
  lcd.print(sensorOneHigh);
}

void writeSensor1Average(int sensorOneAvg){
  lcd.setCursor(11, 0);
  lcd.print(" A");
  lcd.print(sensorOneAvg);
}

void writeSensor2Current(int sensorValue2){
  lcd.setCursor(0, 1);
  lcd.print("ST");
  lcd.print(sensorValue2);
}

void writeSensor2High(int sensorTwoHigh){
  lcd.setCursor(0, 1);
  lcd.print("H2: ");
  lcd.print(sensorTwoHigh);
}

void writeSensor2Average(int SensorTwoAvg){
  lcd.setCursor(11, 1);
  lcd.print(" A");
  lcd.print(sensorTwoAvg);
}

