/*
 Name project:   Example 4, RP6 Motor control
 Author:         Egbert Koerhuis
 Company:        Arexx Engineering
 Discription:     
 This Example Program shows how to control the Motors.
 Make sure that the AAR can __NOT__ move when uploading the program!
 After uploading the program, the AAR will wait 2 seconds before the program start. 
 
 >>> DO NOT FORGET TO REMOVE THE USB CABLE, after uploading the program.
 
 ATTENTION: THE ROBOT MOVES AROUND IN THIS EXAMPLE! PLEASE PROVIDE ABOUT
 1m x 1m OR MORE FREE SPACE FOR THE ROBOT! 

 You are free to change the code! 
 */

void setup()    
{
  //Setup: Initalization 
  //pin 10 left foreward
  pinMode(10, OUTPUT);
  //pin 9 left backward
  pinMode(9, OUTPUT);
  //pin 5 right foreward
  pinMode(5, OUTPUT);
  //pin 6 right backward
  pinMode(6, OUTPUT);
    
  //Then set the start value of the signals to zero: 
  analogWrite(9, 0);   
  analogWrite(10, 0);   
  analogWrite(5, 0);   
  analogWrite(6, 0);
  
  //Startup delay:
  delay(2000);
    
}

void loop()
{
   digitalWrite(9,LOW); analogWrite(10,200); //##set pin 9 to ground!## set speed left motor 200 foreward 
   digitalWrite(5,LOW); analogWrite(6,200);  //##set pin 6 to ground!## set speed right motor 200 foreward 
   delay(5000); //drive for 5000ms
   digitalWrite(9,LOW); analogWrite(10,200); //##set pin 9 to ground!## set speed left motor 200 foreward
   digitalWrite(6,LOW); digitalWrite(5,LOW); //make a left turn
   delay(5000); //drive for 5000ms
   digitalWrite(10,LOW); analogWrite(9,200); //##set pin 10 to ground!## set speed left motor 200 backward 
   digitalWrite(6,LOW); analogWrite(5,200);  //##set pin 5 to ground!## set speed right motor 200 backward
   delay(5000);  //drive for 5000ms
   digitalWrite(5,LOW); analogWrite(6,200); //##set pin 5 to ground!## set speed right motor 200 backward
   digitalWrite(9,LOW); digitalWrite(10,LOW); //make a right turn
   delay(5000); //drive for 5000ms   
   digitalWrite(6,LOW); digitalWrite(5,LOW); //stop motors
   digitalWrite(9,LOW); digitalWrite(10,LOW); //stop motors   
}


