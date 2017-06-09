// demo of Starter Kit V2.0 - Grove Sound Sensor
// when sound larger than a certain value, led will on
#include <Wire.h>
#include <Servo.h>
#include "rgb_lcd.h"

Servo myservo;

const int pinButton = 8;                // pin of reset button (digital)
const int pinRotary = A2;

const int pinSound1 = A0;               // pin of Sound Sensor 1 (analog)
const int pinSound2 = A1;               // pin of sound sensor 2 (analog)
const int pinLed   = 7;                // pin of LED (digital)

int thresholdValue = 400;                 // the threshold to turn on or off the LED

//used to display the highest value each sensor has recorded
int sensorOneHigh = 0;
int sensorTwoHigh = 0;

/**
    Old stuff used to display helpful information
    probably not necessary anymore though might be later
    for fine tuning the sound sensor threshold
**/
//int sensorOneAvg = 0;
//int sensorOneSum = 0;

//int sensorTwoAvg = 0;
//int sensorTwoSum = 0;

//int recordings = 0;

rgb_lcd lcd;                //lcd object

//decides to color of the lcd
const int colorR = 255;
const int colorG = 0;
const int colorB = 255;

void setup()
{
    pinMode(pinLed, OUTPUT);            //set the LED on Digital 12 as an OUTPUT
    pinMode(pinButton, INPUT);          //set thee button on digital 8 is an input
    pinMode(pinRotary, INPUT);
    
    //myservo.attach(9);
    //myservo.write(90);
    //myservo.detach();
    
    
    
    lcd.begin(16, 2);                   //turns on the LCD screen and determines number of columns and rows
    lcd.setRGB(colorR, colorG, colorB); //sets the color of the LCD to that of the colors declared earlier
}

void loop()
{
    int sensorValue = analogRead(pinSound1);   //read the sensorValue on Analog 0
    int sensorValue2 = analogRead(pinSound2);   //read the sensorValue on Analog 1

    int calibratedThreshold = thresholdValue + rotaryAdjustThreshold();
    
    //Turns on the servo (turning it to low probably turns it off and stops the jittering i might be an idiot)
    //analogWrite(pinServo, HIGH);          
    //myservo.write(90);
    //This just checks if the current sound recorded is higher than teh previous one, if so update sensorOneHigh
    if(sensorValue > sensorOneHigh)
    {
      sensorOneHigh = sensorValue;
      writeSensor1High(sensorOneHigh);
    }
    
    //This just checks if the current sound recorded is higher than teh previous one, if so update sensorOneHigh
    if(sensorValue2 > sensorTwoHigh)
    {
      sensorTwoHigh = sensorValue2;
      writeSensor2High(sensorTwoHigh);
    }
    

    //recordings++;             Was used in determining the average sound in a room
    
    //Was used to keep and up to date number for the total sum and use that for determining the average
    //sensorOneSum += sensorValue;
    //sensorTwoSum += sensorValue2;
    
    //detemines the average - not used anymore due to weird issues i didn't want to solve - not sure how much it helped anyway
    //sensorOneAvg = sensorOneSum/recordings;
    //sensorTwoAvg = sensorTwoSum/recordings;

    
    if(sensorValue > calibratedThreshold){           //checks if a recorded sound from mic 1 exceeds the target threshold
      turnOnLED();                              //turns on the LED indicator
      leftVRight(sensorValue, sensorValue2);    //takes the sound level from each mic and will determine which side was louder as a rudimentary directional test
      adjustServo(sensorValue, sensorValue2);
    }
    else if(sensorValue2 > calibratedThreshold)      //checks if a recorded sound from mic 2 exceeds the target threshold
    {
      turnOnLED();                              //turns on the LED indicator
      leftVRight(sensorValue, sensorValue2);    //takes the sound level from each mic and will determine which side was louder as a rudimentary directional test
      adjustServo(sensorValue, sensorValue2);
    }
    else                                        //if no sound exceeds the threshold value do something
    {   
      turnOffLED();                             //turn off LED indicator
    }
    
    
    //writeSensor1High(sensorOneHigh);            //Calls a function to write the highest recorded sound from sensor 2 to the lcd
    //writeSensor2High(sensorTwoHigh);            //Calls a function to write the highest recorded sound from sensor 2 to the lcd
    
    /**
        Left over stuff from dusplaying the average and current sound level
        currently unneeded in current testing but might be useful again in the future
    **/
    //writeSensor1Current(sensorValue);
    //writeSensor1Average(sensorOneAvg);

    //writeSensor2Current(sensorValue2);
    //writeSensor2Average(sensorTwoAvg);
    
    
    //reads the current state of the button
    if(digitalRead(pinButton))              //if the button is pushed then do something
    {
      digitalWrite(pinLed, HIGH);           // turn on the lED
      
      reset();                              // calls a function to reset the experiment
    }
    
    
}

/*
 *
 *  Start of functions
 *
 *
 *
*/

/*
 * Data Based Functions
 * 1. Rests the data for another test
*/

//resets data for anopther test
void reset()
{
  sensorOneHigh = 0;
  sensorTwoHigh = 0;
  /*
   * Old stuff from previous testing that isn't needed for now but might be in the future
  sensorOneSum = 0;
  sensorTwoSum = 0;
  sensorOneAvg = 0;
  sensorTwoAvg = 0;
  recordings = 0;
  */
}

int largerNumber(int numberOne, int numberTwo)
{
  if(numberOne>numberTwo)
  {
    return numberOne;
  }
  else
  {
    return numberTwo;
  }
}

int smallerNumber(int numberOne, int numberTwo)
{
  if(numberOne<numberTwo)
  {
    return -numberOne;
  }
  else
  {
    return numberTwo;
  }
}

/*
 * Sound Related Functions
 * 1. Determines if sound was heard from the left or right of the device
*/

//takes in 2 ints and compares them - just a rudimentary algorithm to check where the sound came from, def a placeholder
void leftVRight(int sensorValue, int sensorValue2)
{
  int largerNumber = 0;                         //variable to hold which the larger number
  
  if(sensorValue > sensorValue2)                //checks if sensor 1 is larger than sensor 2
  {
    largerNumber = sensorValue;                 //sets greater to be equal to sensor
    lcd.setCursor(9, 0);                        //sets cursor location to position 9 on the first row of the lcd
    lcd.print("S-Left");                        //prints some ui information that tells the user the sound came from the left
  }
  else if( sensorValue2 > sensorValue)          //checks if sensor 2 is larger than sensor 1
  {
    largerNumber = sensorValue2;                //sets grater to be equal to sensor
    lcd.setCursor(9, 0);                        //sets the cursor location to position 9 on the first row of the lcd
    lcd.print("S-Right");                       //prints some ui information that tells the user the sound came from the right
  }
  
  //needs to be made into its own function and put in the lcd related functions section
  lcd.setCursor(9, 1);                          //sets the cursor to position 9 on the second row
  lcd.print(largerNumber);                      //prints whichever number was larger
  delay(500);                                   //delays the program so user can read the data - needs to be increased
  lcd.setCursor(9,0);                                  //clears lcd so info doesnt stay there and get confuesd with future tests
  lcd.print("       ");
  lcd.setCursor(9, 1);
  lcd.print("       ");
}


/*
 * Servo Related Functions
 * 1. Turns the direction of the main servo
 *
*/
void adjustServo(int sensorValue, int sensorValue2)
{
  float ratio = 0.0;                                          //ratio of the sensor values
  float angle = 0.0;                                          //angle of the servo arm
  float firstThing = 0.0;
  float secondThing = 0.0;
  
  lcd.clear();

  myservo.attach(9);

  writeSensor1Value(sensorValue);
  writeSensor2Value(sensorValue2);

  ratio = (float)smallerNumber(sensorValue, sensorValue2)/(float)largerNumber(sensorValue, sensorValue2);                             //determines the ratio by taking the seonc d senso divided by the first
  
  //angle = 90;
  //+ (90*(1-ratio));
  
  //angle = (ratio * 90);                                       //multiplies the ratio by 90 to give the new angle of servo

  //myservo.write(angle);

  writeServoPosition();
  
  myservo.detach();
}

/*
 * Rotary Related Functions 
 * 
 */

int rotaryAdjustThreshold()
{
  
  return map(analogRead(pinRotary), 0, 1023, 0, 300);
}
/*
 * LED Based Functions
 * 1. Turn on the LED
 * 2. Turn off the LED
 */
//function that turns on the led
void turnOnLED()
{
  digitalWrite(pinLed,HIGH);                        //turns on the led
}
//function that turns off the led
void turnOffLED()
{
  digitalWrite(pinLed,LOW);                         //turns off the led
}


/*
 * LCD Based Functions
 * 1. Write the high of sensor 1 to the LCD
 * 2. Write the high of sensor 2 to the LCD
*/
//function to write the highest recorded sound of sensor 1, takes in an int as an argument
void writeSensor1High(int sensorOneHigh){
  lcd.setCursor(0, 0);                              //sets the cursor of the lcd to the first spot of the first row
  lcd.print("H1: ");                                //just some user info tag the information
  lcd.print(sensorOneHigh);                         //prints the int passed to the function
}
//function to write the highest recorded sound of sensor 2, takes in an int as an argument
void writeSensor2High(int sensorTwoHigh){
  lcd.setCursor(0, 1);                              //sets the cursor of the lcd to the first spot of the second row
  lcd.print("H2: ");                                //just some user info top tag the information
  lcd.print(sensorTwoHigh);                         //prints the int passed to the function
}
//function to write the current value of sensor 1 on the lcd
void writeSensor1Value(int sensorValue)
{
  lcd.setCursor(0,0);
  lcd.print("S1: ");
  lcd.print(sensorValue);
}
//function to write teh current value of senso 2 on the lcd
void writeSensor2Value(int sensorValue2)
{
  lcd.setCursor(0,1);
  lcd.print("S2: ");
  lcd.print(sensorValue2);
}
//fuction to print servo position in degrees
void writeServoPosition()
{
  lcd.setCursor(9, 1);
  lcd.print(myservo.read());
}

void writeRotaryAngle()
{
  lcd.setCursor(0, 0);
  lcd.print("      ");
  lcd.setCursor(0, 0);
  lcd.print(analogRead(pinRotary));
}
/*
 * Old functions that write the current sound level and average for each mic onto the lcd screen
 * they've been phased out as they currently aren't needed but I'm keeping them here for possible
 * future use
 *
void writeSensor1Current(int sensorValue)
{
  lcd.setCursor(0, 0);
  lcd.print("SO");
  lcd.print(sensorValue);
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
void writeSensor2Average(int SensorTwoAvg){
  lcd.setCursor(11, 1);
  lcd.print(" A");
  lcd.print(sensorTwoAvg);
}
*/
