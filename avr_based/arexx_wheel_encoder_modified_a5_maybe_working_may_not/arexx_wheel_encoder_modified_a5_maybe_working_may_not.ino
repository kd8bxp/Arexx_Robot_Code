#include "src/PinChangeInterrupt/PinChangeInterrupt.h"

volatile int speed_timer=0;
byte mleft_speed=0;
byte mright_speed=0;
int mleft_counter=0;
int mright_counter=0;

//the wheel encoders appear to be on Analog Pins not interrupt pins...weird


void setup() {
  Serial.begin(9600);

  //set pin I/O
  pinMode(A5, INPUT);  //encoder left 
  pinMode(A1, INPUT);  //encoder right 
  //set interrupt for encoders
  attachPCINT(digitalPinToPCINT(A5),leftsens,CHANGE);
  attachPCINT(digitalPinToPCINT(A1),rightsens,CHANGE); 
}

void loop() {
  // put your main code here, to run repeatedly:
  unsigned long valueright;
  unsigned long valueleft;
  
  /* This is the encoder test. The test uses the arduino function PulseIn() to measure time of the encoderpulse.
  /  the duration of the pulse gives the actual motor speed.                                                    */
  Serial.print("\n Welcome to the encoder test. \n\n This test will print the duration of the encoderpulses to the screen.");
  Serial.print("\n The values are microseconds. \n\nPress ENTER to terminate the encoder test\n ");

  /* Start the Motors */
  analogWrite(5,200);
  analogWrite(9,200);
  
  /*Infinite Loop */
  while(1){
   if( Serial.available() > 1){            //check if ENTER is pressed
   analogWrite(5,0);                       //Turn off motors
   analogWrite(9,0);  
   break;}
  // valueright = analogRead(A1);          //pin A1 is connected to the encoder on the left
  // valueleft =analogRead(A5);            //pin A5 is connected to the encoder on the right
   Serial.print("\nLeft value: ");
   Serial.print(mleft_counter,DEC);
   Serial.print("   Right value: ");
   Serial.print(mright_counter,DEC);
   //Serial.print(valueright, DEC);
         digitalWrite(8,HIGH);
  // delay(500);                             //print two values in one second.
  }
}


void leftsens()  //external interrupt left encoder
{
  detachPCINT(digitalPinToPCINT(A5));
  mleft_counter++;
  attachPCINT(digitalPinToPCINT(A5),leftsens,CHANGE);
}

void rightsens()  //external interrupt right encoder
{
  detachPCINT(digitalPinToPCINT(A1));  
  mright_counter++;
  attachPCINT(digitalPinToPCINT(A1),rightsens,CHANGE);  
}
