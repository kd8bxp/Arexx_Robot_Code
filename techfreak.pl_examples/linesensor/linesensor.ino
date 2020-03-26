/ *
Arduino-Roboter AAR-04 linesensor / linetracker techfreak.pl for conrad.pl
* /

void setup ()    
{
  // Setup: Initalization 
  // pin 10 left foreward
  pinMode (10, OUTPUT);
  // pin 9 left backward
  pinMode (9, OUTPUT);
  // pin 5 right foreward
  pinMode (5, OUTPUT);
  // pin 6 right backward
  pinMode (6, OUTPUT);
  // lED
  pinMode (7, OUTPUT);

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
void l () {
 digitalWrite (10, LOW); analogWrite (9,100); // ## set pin 9 to ground! ## set speed left motor 200 foreward
 digitalWrite (6, LOW); digitalWrite (5, LOW); // make a left turn
 delay (10);
}
void r () {
 digitalWrite (6, LOW); analogWrite (5,100); // ## set pin 5 to ground ## set speed right 200 backward
 digitalWrite (9, LOW); digitalWrite (10, LOW); // make a right turn
 delay (10);
}

void linesensor () {
  int left = 0;
  int right = 0;
  left = analogRead (A6);
  right = analogRead (A7);

  if (left <150) {                         
      Serial.print ("LEFT: BLACK");
r ();
      }
      else {
        Serial.print ("LEFT: WHITE");
      // delay (10);
      }

 if (right <150) {                         
      Serial.print ("RIGHT: BLACK \ n");
l ();
      }
      else {
        Serial.print ("RIGHT: WHITE \ n");
        // delay (10);

      }

}

void loop ()
{

   linesensor ();

}
