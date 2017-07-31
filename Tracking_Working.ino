// Matt Winchester
// Sonic Sensor Range Finder Prototype Code
// 2017

#include <Servo.h>
#include <Wire.h>

// Constants
int left_trig = 10;
int left_echo = 11;

int right_trig = 3;
int right_echo = 2;

int mid_trig = 7;
int mid_echo = 6;

int pan_pin = 9;
int tilt_pin = 8;

int LEFT_MIN = 10000;
int MID_MIN = 10000;
int RIGHT_MIN = 10000;

int FIRE_TIMER_MS = 2500;

int OUTLIER_THRESHOLD = 300;

int WARN_BLINK_MS = 2000;
int FIRE_BLINK_MS = 200;
int turning_direction;
// 0 - left
// 1 - stop
// 2 - right

int current_mode;
// 0 - spin
// 1 - track

long time_since_track_event; //millis
long previous_lock = 0;
long time_of_last_blink = 0; 

float warn_distance = 100;
//float fire_distance = ;

int warning_pin = 13; //on board LED
int LED_STATE = HIGH;

int current_tilt;

Servo pan, tilt;

unsigned long left_duration, right_duration, mid_duration;
float left_cm, right_cm, mid_cm;

int current_time = 0;

void wait_for_usb_disconnect()
{
  delay(5000);
}

void setup() {
  //Serial.begin(9600);

  wait_for_usb_disconnect();

  pinMode(left_trig, OUTPUT);
  pinMode(left_echo, INPUT);
  pinMode(right_trig, OUTPUT);
  pinMode(right_echo, INPUT);
  pinMode(mid_trig, OUTPUT);
  pinMode(mid_echo, INPUT);

  pinMode(warning_pin, OUTPUT);

  pan.attach(pan_pin);
  tilt.attach(tilt_pin);
  safe_tilt(90);

  current_mode = 0;
  turning_direction = 0;

}

void print_distances()
{
  Serial.print("Left: ");
  Serial.println(left_cm);
  
  Serial.print("Right: ");
  Serial.println(right_cm);
  
  Serial.print("Center: ");
  Serial.println(mid_cm);

  
}


void safe_tilt(int angle)
{

  if (angle > 110)
    angle = 110;

    if (angle < 80)
    angle = 80;

      // ie from 90 to 100
  if (angle > current_tilt) 
  {
     for(int i = current_tilt; i <= angle; i++)
     {
      tilt.write(i);
      delay(50);
     }
  }

  // ie 100 to 90
  else if (angle < current_tilt) 
  {
     for(int i = current_tilt; i >= angle; i--)
     {
      tilt.write(i);
      delay(50);
     }
  }

  current_tilt = angle;
  //tilt.write(angle);
}


void loop() {

  if (current_mode == 0)
  {
    spin();
  }
  else if (current_mode == 1)
  {
    track();
  }
  
}

void spin()
{
  turn_left();  
  read_middle();

  if(mid_cm < warn_distance)
  {
    digitalWrite(warning_pin, HIGH);
  }
  else
  {
    digitalWrite(warning_pin, LOW);
  }
  

  if(mid_cm < warn_distance)
  {
    //Go into tracking mode!

  stop_turning();
  change_to_track();
    
    current_mode = 1;
   time_since_track_event = millis();
   previous_lock = time_since_track_event;
  }
    //spin until themiddle sensoe sees something in the warning distance, then track
}

void change_to_track()
{
  digitalWrite(warning_pin, HIGH);
  delay(500);
  digitalWrite(warning_pin, LOW);
  delay(100);
 digitalWrite(warning_pin, HIGH);
  delay(500);

}

void blink_warn()
{
  if ( millis() - time_of_last_blink > WARN_BLINK_MS)
  {
    if(LED_STATE == LOW)
    {
      LED_STATE = HIGH;
    }
    else if (LED_STATE == HIGH)
    {
      LED_STATE = LOW;
    }
    digitalWrite(warning_pin, LED_STATE);
    time_of_last_blink = millis();
  }
}

void track()
{
  blink_warn();
  //blink the warning light
  read_all();

  //check to make sure something is still visible
  if( left_cm < warn_distance || right_cm < warn_distance || mid_cm < warn_distance )
  {
    time_since_track_event = millis();
  }
  
  // read left, right, and mid. compare them, then turn in the closest direction. 

  if(left_cm < right_cm && left_cm < mid_cm)
  {
    turn_left();
    previous_lock = 0;
    //left is the least, turn to the left slowly
  }

  else if(right_cm < left_cm && right_cm < mid_cm)
  {
    turn_right();
    previous_lock = 0;
    //right is the least, turn to the right slowly
  }

  else if(mid_cm < left_cm && mid_cm < right_cm)
  {
      stop_turning();
      //First sighting
      if (previous_lock == 0)
      {
        previous_lock = millis(); 
      }

      else if( millis() - previous_lock > FIRE_TIMER_MS)
      {
        fire();
        previous_lock = millis();
      }
      
    delay(100);
  
  }
  

  // 10 seconds with no events, go back to spinning
  if(millis() - time_since_track_event > 10000)
  {
    digitalWrite(warning_pin, HIGH);
    current_mode = 0;
    change_to_spin();
  }

}

void change_to_spin()
{
  int i = 0;
  for (i = 0; i < 20; i++)
  {
    digitalWrite(warning_pin, HIGH);
    delay(20);
    digitalWrite(warning_pin, LOW);
    delay(10);
  }
  
}

void read_all()
{
  read_left();
  read_right();
  read_middle();
}

void fire()
{
  
}

void turn_right()
{
  pan.write(80);
}

void turn_left()
{
  if(turning_direction == 1)
  {
      return;
  }
  
  pan.write(100);
  turning_direction == 1;
}

void stop_turning()
{
  pan.write(90);
}

float microsecondsToCentimeters(unsigned long microseconds)
{
  return (((float)microseconds * 0.034) / 2.0);
}



void read_left()
{
  
  digitalWrite(left_trig, LOW);
  delayMicroseconds(2);
  digitalWrite(left_trig, HIGH);
  delayMicroseconds(10);
  digitalWrite(left_trig, LOW);
  left_duration = pulseIn(left_echo, HIGH);
  float new_value = microsecondsToCentimeters(left_duration);
  left_cm = (new_value < OUTLIER_THRESHOLD) ? new_value : left_cm;

}

void read_right()
{

  digitalWrite(right_trig, LOW);
  delayMicroseconds(2);
  digitalWrite(right_trig, HIGH);
  delayMicroseconds(10);
  digitalWrite(right_trig, LOW);
  right_duration = pulseIn(right_echo, HIGH);
  float new_value = microsecondsToCentimeters(right_duration);
  right_cm = (new_value < OUTLIER_THRESHOLD) ? new_value : right_cm;
   

}

void read_middle()
{
  digitalWrite(mid_trig, LOW);
  delayMicroseconds(2);
  digitalWrite(mid_trig, HIGH);
  delayMicroseconds(10);
  digitalWrite(mid_trig, LOW);
  mid_duration = pulseIn(mid_echo, HIGH);

  float new_value = microsecondsToCentimeters(mid_duration);
  mid_cm = (new_value < OUTLIER_THRESHOLD) ? new_value : mid_cm;
}

