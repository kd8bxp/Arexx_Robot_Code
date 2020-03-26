/*
 HC-SR04 Ping distance sensor:
 VCC is arduino 5v 
 GND to arduino GND
 Echo is Arduino pin 7 
 Trig is Arduino pin 8
 
 This sketch originates from Virtualmix: http://goo.gl/kJ8Gl
 Has been modified by Winkle ink here: http://winkleink.blogspot.com.au/2012/05/arduino-hc-sr04-ultrasonic-distance.html
 And modified further by ScottC here: http://arduinobasics.blogspot.com/
 on 10 Nov 2012.
 */

#define echoPin 4 // Echo Pin
#define trigPin 8 // Trigger Pin
#define LEDPin 13 // Onboard LED

int maximumRange = 20; // Maximum range needed
int minimumRange = 0; // Minimum range needed
long duration, distance; // Duration used to calculate distance

int randNumber = 0;

void setup () {
 Serial.begin (9600);
 pinMode (trigPin, OUTPUT);
 pinMode (echoPin, INPUT);
 pinMode (LEDPin, OUTPUT); // Use LED indicator (if required)
 
 // Setup: Initalization 
 // pin 10 left foreward
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
 Serial.begin (9600);
 Serial.print ("\ ntechfreak.pl - Robot Test AREXX for conrad.pl \ n"); 
 digitalWrite (7, HIGH);  
 // Startup delay:
 delay (2000);

 
}

 void loop () {
 / * The following trigPin / echoPin cycle is used to determine the
 distance of the nearest object by bouncing the soundwaves off of it. * /
 digitalWrite (trigPin, LOW); 
 delayMicroseconds (2); 

 digitalWrite (trigPin, HIGH);
 delayMicroseconds (10); 
 
 digitalWrite (trigPin, LOW);
 duration = pulseIn (echoPin, HIGH);
 
 // Calculate the distance (in cm) based on the speed of sound.
 distance = duration / 58.2;
 randNumber = 0;

 if (distance <= maximumRange) {
 / * Send a negative number to the computer and turn the LED ON 
 to indicate "out of range" * /
 Serial.println ( "- 1");
 digitalWrite (LEDPin, HIGH); 
 
// digitalWrite (6, LOW); digitalWrite (5, LOW); // stop motors
// digitalWrite (9, LOW); digitalWrite (10, LOW); // stop motors   
// delay (10);
 // digitalWrite (9, LOW); analogWrite (10,200); // foreward
// digitalWrite (5, LOW); analogWrite (6,200); // foreward
 // delay (10);
 
 digitalWrite (6, LOW); digitalWrite (5, LOW); // stop motors
 digitalWrite (9, LOW); digitalWrite (10, LOW); // stop motors  
 delay (10);
 digitalWrite (9, LOW); analogWrite (10,200); // left motor foreward
 digitalWrite (6, LOW); digitalWrite (5, LOW); // make a left turn
 delay (500); 
 digitalWrite (6, LOW); digitalWrite (5, LOW); // stop motors
 digitalWrite (9, LOW); digitalWrite (10, LOW); // stop motors
 }

 else {
 / * Send the distance to the computer dùng Serial protocol, và
 Turn LED OFF to indicate successful reading. * /
 Serial.println (distance);
 digitalWrite (LEDPin, LOW); 
 
 // forward
 
 digitalWrite (10, LOW); analogWrite (9,200); // ## set pin 10 to ground ## set speed left 200 backward motor
 digitalWrite (6, LOW); analogWrite (5,200); // ## set pin 5 to ground ## set speed right 200 backward       
 // delay (10);
 
 }
 
 // Delay 50ms before next reading.
 delay (10);
}
