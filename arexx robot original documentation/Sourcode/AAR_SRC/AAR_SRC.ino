/*
 Name project:   Arexx Arduino Robot 
 Autor:          
 Company:        Arexx Engineering
 Discription:     
 This example shows how to use the Aruduino RP6
 */

  // inslude the SPI library:
  #include <SPI.h>
  #include <avr/interrupt.h>
  #include <avr/io.h>

  //Defines
  #define led1 1
  #define led2 2
  #define led3 4
  #define led4 8
  #define SPI_Motor_Left  16
  #define SPI_Motor_Right  32
  #define INIT_TIMER_COUNT 0
  #define RESET_TIMER2 TCNT2 = INIT_TIMER_COUNT
  #define SPEED_TIMER_BASE 500 

  // Variables 
  int SPI_Value = 1; 
  const int slaveSelectPin = 12; // set pin 12 as the slave select for the digital pot:
  byte firstSensor = 0;    // first analog sensor
  byte secondSensor = 0;   // second analog sensor
  byte thirdSensor = 0;    // digital sensor
  byte inByte = 0;
  byte inByte1 = 0;
  byte inByte2 = 0;
  byte inByte3 = 0;         // incoming serial byte
  byte inByte4 = 0;         // Second incoming serial byte
  byte inByte5 = 0;        //third incomming serial byte
  byte inByte6 = 0;
  byte inByte7 = 0;
  byte inByte8 = 0;
  
  //encoder variables
  volatile int speed_timer=0;
  byte mleft_speed=0;
  byte mright_speed=0;
  byte mleft_counter=0;
  byte mright_counter=0;

void setup()  { 
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
  
  // initialize SPI:
  SPI.begin();     

  //set motor speed to 0
  analogWrite(9, 0);           
  analogWrite(10, 0);   
 
  ledSet();
  
 //Serial.write(" - Start - ");
  
  // TIMER2 Settings
  TCCR2B =   (1 << CS22)  | (0 << CS21) | (1 << CS20); // Fosc/64 (prescaler)
  TCCR2A =   (0 << WGM20) | (1 << WGM21) | (0 << COM2A0) | (0 << COM2A1) ; //CTC mode normal port operation
  OCR2A  = 255;
  TIMSK2 |= (1<<TOIE2) | (0<<OCIE2A);
   
  //set interrupt for encoders
  attachInterrupt(1,leftsens,CHANGE);
  attachInterrupt(0,rightsens,CHANGE);
} 

void loop()  { 
  
  // if we get a valid byte, read analog ins:
  if (Serial.available() == 8) {
    //get incoming byte:
    inByte = Serial.read();
    inByte1 = Serial.read();
    inByte2 = Serial.read();
    inByte3 = Serial.read(); //control
    inByte4 = Serial.read(); //info1
    inByte5 = Serial.read(); //info2
    inByte6 = Serial.read(); //info2
    inByte7 = Serial.read(); //info2
    Serial.flush();
    Serial.write(inByte4);
    
    if (inByte = 1)
    {
      if (inByte1 = 250)
      {
              
        if (inByte2 = 8)
        {
          
          if (inByte7 = 4)
         { 
          switch (inByte3)
            {
              case 1:
              
                switch (inByte4)
                {
                        case 53: ledSet(); motor_speed(7, 0); break; // STOP
                	case 56: motor_speed(5, inByte5); break; // FOREWARD
                	case 52: motor_speed(1, inByte5); break; // LEFT
                	case 54: motor_speed(3, inByte5); break; // RIGHT
                	case 50: motor_speed(6, inByte5); break; // BACKWARD
                	case 100: LineSet(inByte5); break; //LineSensor led on/off
                }
                break;
              case 2:
                WriteDataHandler_Main();
                break;
              case 3:
                RF_Test();              
                break;
            }
          }
        }
      }
    }
    // read first analog input, divide by 4 to make the range 0-255:
    firstSensor = analogRead(A2)/4;  //battery voltage
    
    // delay 10ms to let the ADC recover:
    delay(10);
    // read second analog input, divide by 4 to make the range 0-255:
    secondSensor = analogRead(A6)/4;  //left linesensor
    // delay 10ms to let the ADC recover:
    delay(10);
    thirdSensor = analogRead(A7)/4;  //right linesensor
    // delay 10ms to let the ADC recover:
    delay(10);
   }
}

void WriteDataHandler_Main (void)
  {
    Serial.write(1);		//Start Byte: 1
    Serial.write(255);		//Addres PC: 255
    Serial.write(14);		//Length: 14
    Serial.write(254);		//Command: 254 "update data"
    Serial.write(firstSensor);	//Data 0: battery voltage
    Serial.write((byte)0x00);     		//Data 1: current motor right not avalible for AAR
    Serial.write((byte)0x00);    		//Data 2: current motor left not avalible for AAR
    Serial.write(mleft_speed);     //Data 3: speed motor left
    Serial.write(mright_speed);	//Data 4: speed motor right		
    Serial.write((byte)0x00);               //Data 5: errorbits
    Serial.write(secondSensor);    //Data 6: linesnesor left
    Serial.write(thirdSensor);     //Data 7: linesensor right
    Serial.write((byte)0x00);               //Data 8: Servo disabled
    Serial.write(4);	        //Stopbit
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

void RF_Test()
{
  delay(100);
         for(int Test_Value_RF =0; Test_Value_RF<10; Test_Value_RF++)		
	  {
        	Serial.write(1);	        //Start Byte:  		1
            	Serial.write(255);		//Addres PC:   		255 
            	Serial.write(6);		//Length: 		7 bytes 
            	Serial.write(200);		//Control Byte:	        200 (I2C test repport)
        	Serial.write((byte)0x10);	        //Data byte 0: 	        10
            	Serial.write(4);		//Stop Byte:		4 		
        	delay(250);
	  }
}

void motor_speed(int DIR, int  angle)//, unsigned char angle
{
 switch (DIR){
  case 1: analogWrite(9,angle); digitalWrite(6, LOW); digitalWrite(5, LOW); digitalWrite(10, LOW); break;//Motor left FW
  case 2: analogWrite(10,angle); digitalWrite(6, LOW); digitalWrite(5, LOW); digitalWrite(9, LOW); break;//Motor left BW
  case 3: analogWrite(5,angle);  digitalWrite(6, LOW); digitalWrite(9, LOW); digitalWrite(10, LOW); break;//Motor right FW
  case 4: analogWrite(6,angle);  digitalWrite(5, LOW); digitalWrite(9, LOW); digitalWrite(10, LOW); break;//Motor right BW
  case 5: analogWrite(9,angle); analogWrite(5,angle); digitalWrite(10, LOW);  digitalWrite(6, LOW); break; //FOREWARD
  case 6: analogWrite(10,angle); analogWrite(6,angle); digitalWrite(9, LOW);  digitalWrite(5, LOW);break; //BACKWARD
  case 7: digitalWrite(6,LOW); digitalWrite(5,LOW); digitalWrite(9, LOW); digitalWrite(10, LOW); break;
}}

void LineSet(int OnOff)
{
 if (OnOff==1) {digitalWrite(7,HIGH);}
 else if (OnOff == 0){digitalWrite(7,LOW);}
}
 
 void ledSet(){
    digitalWrite(8 ,HIGH);
    delay(3000);
    digitalWrite(8 ,LOW);
 }
