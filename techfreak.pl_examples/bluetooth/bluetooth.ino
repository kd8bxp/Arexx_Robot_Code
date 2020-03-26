/ *
Arduino-Roboter AAR-04 bluetooth control techfreak.pl for conrad.pl
* /

#include 
SoftwareSerial mySerial (8, 4); // RX, TX
char incomingByte;
void setup ()  
{
   pinMode (10, OUTPUT);
  // pin 9 left backward
  pinMode (9, OUTPUT);
  // pin 5 right foreward
  pinMode (5, OUTPUT);
  // pin 6 right backward
  pinMode (6, OUTPUT);
  // Then set the value of the signals to zero: 
  analogWrite (9, 0);   
  analogWrite (10, 0);   
  analogWrite (5, 0);   
  analogWrite (6, 0);
// Open serial communications and wait for port to open:
  Serial.begin (9600);
  while (! Serial) {
  ; // wait for serial port to connect. Needed for Leonardo only
 }
  Serial.println ("hello USB");
 // set the data rate for the SoftwareSerial port
  mySerial.begin (9600);
 mySerial.println ("Hello, BT");
}
void loop () // run over and over
{
  if (mySerial.available ())
   Serial.write (mySerial.read ());
  if (Serial.available ())
    mySerial.write (Serial.read ());
  digitalWrite (6, LOW); digitalWrite (5, LOW); // stop motors
  digitalWrite (9, LOW); digitalWrite (10, LOW); // stop motors   
  if (mySerial.available ()> 0) {// if received UART data
    incomingByte = mySerial.read (); // raed byte
     if (incomingByte == '8') { 
      digitalWrite (10, LOW); analogWrite (9,200); // ## set pin 10 to ground ## set speed left 200 backward motor
      digitalWrite (6, LOW); analogWrite (5,200); // ## set pin 5 to ground ## set speed right 200 backward       
                delay (500); }
    if (incomingByte == '4') { 
    digitalWrite (9, LOW); analogWrite (10,200); // ## set pin 9 to ground! ## set speed left motor 200 foreward
   digitalWrite (6, LOW); digitalWrite (5, LOW); // make a left turn
    delay (500); }
     if (incomingByte == '2') { 
      digitalWrite (9, LOW); analogWrite (10,200); // ## set pin 9 to ground! ## set speed left motor 200 foreward
      digitalWrite (5, LOW); analogWrite (6,200); // ## set pin 6 to ground ## set speed right 200 motor foreward
    delay (500); }
      if (incomingByte == '6') {
       digitalWrite (5, LOW); analogWrite (6,200); // ## set pin 5 to ground ## set speed right 200 backward
   digitalWrite (9, LOW); digitalWrite (10, LOW); // make a right turn
    delay (500); }
      if (incomingByte == '5') {
       digitalWrite (6, LOW); digitalWrite (5, LOW); // stop motors
   digitalWrite (9, LOW); digitalWrite (10, LOW); // stop motors   
      }
   }
}
