/* selftest for arexx arduino robot
   version 1.0  
*/
//#include "ArexxArduinoLib.h"
//#include <SPI.h>
#include <avr/interrupt.h>
#include <avr/io.h>
  
int temp;
int startbit;
int cases=0;           //start condition to print the menu.  
//encoder variables
volatile int speed_timer=0;
byte mleft_speed=0;
byte mright_speed=0;
int mleft_counter=0;
int mright_counter=0;
 
#define INIT_TIMER_COUNT 0
#define RESET_TIMER2 TCNT2 = INIT_TIMER_COUNT
#define SPEED_TIMER_BASE 500 
#define leftforward 10;
#define leftbackward 9;
#define rightforward 5;
#define rightbackward 3;

void setup(){
  //Set baudrate to 9600
  Serial.begin(9600);

  //set pin I/O
  pinMode(2, INPUT);	//encoder right
  pinMode(3, INPUT);	//encoder left
  pinMode(5,OUTPUT);	//right motor foreward
  pinMode(6,OUTPUT);	//right motor backward
  pinMode(7,OUTPUT);	//red line sensor
  pinMode(9, OUTPUT);	//left motor foreward
  pinMode(10, OUTPUT);	//left motor backward
  pinMode(8, OUTPUT);  //statusled
  pinMode(A2, INPUT);	//battery sensor
  pinMode(A6, INPUT);	//linesensor left
  pinMode(A7, INPUT);	//linesensor right
  
  //use external reference
  //analogReference(DEFAULT);
  
  //set motor speed to 0
  analogWrite(9, 0);           
  analogWrite(10, 0);   
  
  // TIMER2 Settings
  TCCR2B =   (1 << CS22)  | (0 << CS21) | (1 << CS20); // Fosc/64 (prescaler)
  TCCR2A =   (0 << WGM20) | (1 << WGM21) | (0 << COM2A0) | (0 << COM2A1) ; //CTC mode normal port operation
  OCR2A  = 255;
  TIMSK2 |= (1<<TOIE2) | (0<<OCIE2A);
   
  //set interrupt for encoders
  attachInterrupt(1,leftsens,CHANGE);
  attachInterrupt(0,rightsens,CHANGE); 
}
 void loop(){
    
    switch (cases){
      
        case 0:                                                            //start condition   
        Serial.begin(9600);
        Serial.print("\nWelcome to the arexx arduino robot.\nThis selftest will test all of the standard hardware\non the robot.\n");  
        Serial.print("\nChoose from one of the selftest options:\n\n");
        Serial.print("1. Run all selftests\n");
        Serial.print("2. Run all led tests\n");
        Serial.print("3. Run motor tests\n");
        Serial.print("4. Run encoder tests\n"); 
        Serial.print("5. Linesensor test\n");
        cases = retrieve_data();
        break;
        
        case 10:                                                          //new line sent by pc
        cases = retrieve_data();
        break;
        
        case 49:                                                          //caracter 1 sent by pc
        ledtest();                                                        //option 1 is run all tests
        motortest();
        encodertest();
        cases=0;
        break;
        
        case 50:                                                          //character 2 sent by pc
        ledtest();                                                        //option 2 is run the led test
        cases=0;
        break;
        
        case 51:                                                          //character 3 sent by pc
        motortest();                                                      //option 3 is run the motortests
        cases=0;
        break;
        
        case 52:                                                          //Character 4 sent by pc
        encodertest();                                                    //option 4 is the encoder test.
        cases=0;
        break;
        
        case 53:                                                          //Character 5 sent by pc
        linesensortest();                                                    //option 5 is the linesensor test.
        cases=0;
        break;
        
        default:                                                          //if wrong number received                                            
        Serial.print("The robot has received an invalid number, please enter 1 - 5\n");
        cases = retrieve_data();
        break;
    }   
}

void leftsens()  //external interrupt left encoder
{
  detachInterrupt(1);
  mleft_counter++;
  attachInterrupt(1,leftsens,CHANGE);
}

void rightsens()  //external interrupt right encoder
{
  detachInterrupt(0);  
  mright_counter++;
  attachInterrupt(0,rightsens,CHANGE);  
};

int retrieve_data(){                                    //reads the data that is sent as last
  int inputByte;
  int counter;
  int availablebytes;
  while(1){
    if ( Serial.available() > 0){                      // any data waiting?
        break;                                         // if not, stop function.
        }
  }
  availablebytes = Serial.available();                 // if data available, read the data.
      for(counter=0;counter < availablebytes;counter++){    
         inputByte = Serial.read();                    // make sure the last data in the buffer is used. 
      };                                               // recommend only to use this method in this selftest.
  return inputByte;
}

ISR(TIMER2_OVF_vect) {
  speed_timer++;
    if(speed_timer > SPEED_TIMER_BASE) {
        if (mright_counter > 255) mright_counter=255;
  	mright_speed = mright_counter;
        if (mleft_counter > 255) mleft_counter=255;
  	mleft_speed = mleft_counter;
  	mright_counter = 0;
  	mleft_counter = 0;
  	speed_timer = 0;
   }
};

void ledtest(){
  int temp;
  while(1){
  Serial.print("\nWelcome to the led test.\nThe leds will start flashing.\nPlease verify if all leds are flashing...\n");
  for(temp=0;temp<30;temp++){
  digitalWrite(7,HIGH);
  digitalWrite(8,HIGH);
  digitalWrite(13,HIGH);
  delay(100);
  digitalWrite(7,LOW);
  digitalWrite(8,LOW);
  digitalWrite(13,LOW);
  delay(100);
  }
  Serial.print("\nDid all leds flash?\n1. Yes It's fine.\n2. No, run the test again. \n");
  while(1){
    temp = retrieve_data();                    //wait for data.
    if (temp == 50 | temp == 49){              
      break;}
    else Serial.print("Please enter 1 or 2\n");
  }
  if (temp == 49){                             //if '1' is received, the case will end.
      break;}                                  //if '2' is received, the case will start again.
  }
}

void motortest(){
  int temp;
  while(1){
  Serial.print("\nWelcome to the motor test.\nPlease be sure that the robot CANNOT MOVE\nThe weels must be off the floor when you start the test.\n\n1. Start the motor test.\n");
  while(1){
    temp = retrieve_data();
      if(temp == 49){  break;}
      else Serial.print("Please enter 1 to start the test.\n");
  };
  /* Motortest when motors go forwards*/
  analogWrite(5,200);                      //compensate starting current right motor.
  analogWrite(9,200);                      //compensate starting current left motor.
  delay(200);
  for(temp=80;temp<255;temp++){            //increase motor pwm slowly
   analogWrite(5,temp);
   analogWrite(9,temp);
   delay(100); 
  }
  delay(2000);                            //motor goes full power for two seconds
  digitalWrite(5,LOW);                    //turn off motors.
  digitalWrite(9,LOW);
  delay(1000);                            //wait for one second
  
  /* Motortest when motors go backwards*/
  analogWrite(6,200);                      //compensate starting current right motor.
  analogWrite(10,200);                     //compensate starting current left motor.
  delay(200);
  for(temp=80;temp<255;temp++){            //increase motor pwm slowly
   analogWrite(6,temp);
   analogWrite(10,temp);
   delay(100); 
  }
  delay(2000);                            //motor goes full power for two seconds
  digitalWrite(6,LOW);                    //turn off motors.
  digitalWrite(10,LOW);
  delay(1000);                            //wait for one second
  
  Serial.print("\nDid both motors work?\n1. Yes It's fine.\n2. No, run the test again. \n");
  while(1){
     temp = retrieve_data();              //wait for answer
      if (temp == 50 | temp == 49){       //is it a 1 or 2?
        break;}
      else Serial.print("Please enter 1 or 2\n");
  }
  if (temp == 49){                        //if '1' is received, end this case.
      break;}                             //if '2' is reveived, the case will start again.
  }
}

void encodertest(){
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
   //valueright = analogRead(A1);          //pin A1 is connected to the encoder on the left
   //valueleft =analogRead(A0);            //pin A0 is connected to the encoder on the right
   Serial.print("\nLeft value: ");
   Serial.print(mleft_speed*2,DEC);
   Serial.print("   Right value: ");
   Serial.print(mright_speed*2,DEC);
         digitalWrite(8,HIGH);
   delay(500);                             //print two values in one second.
  }
}

void linesensortest(){
  int left=0;
  int right=0;
  /* print intro text */
  Serial.print("This test will test the linesensors\n");
  Serial.print("Move the sensors over the line and press enter to retrieve new value\n\n");
  Serial.print("Press ENTER to terminate the test\n");
  digitalWrite(7,HIGH);                     //start the red led
  while(1){
    if( Serial.available() > 1){            //check if ENTER is pressed
    digitalWrite(7,LOW);                     //stop the red led
    break;}
    left = analogRead(A6);
    right = analogRead(A7);
//  Serial.print("Left: ");
//  Serial.print(left);
//  Serial.print("  Right: ");
//  Serial.print(right);
//  Serial.print("\n");
    if(left < 60){                          //this is the good value for the prototype, factory version can be different
      Serial.print("LEFT: BLACK    ");}
      else Serial.print("LEFT: WHITE    ");
    if(right < 60){                         //this is the good value for the prototype, factory version can be different
      Serial.print("RIGHT: BLACK    \n");}
      else Serial.print("RIGHT: WHITE    \n");
    delay(500);
  }
  
}

