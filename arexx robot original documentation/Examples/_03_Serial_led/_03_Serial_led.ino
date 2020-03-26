/*
 Name project:   Example 3, Serial led control 
 Author:         Egbert Koerhuis
 Company:        Arexx Engineering
 
 Discription:     
 This example show how to use the serial output.
 Open the serial monitor and you can set the leds by sending commands to the RP6.
 
 0 = All leds off
 1 = Led 1 on
 2 = Led 2 on
 3 = both leds on
  
 After sending the command, the AAR answer the command. 
 You are free to change the code! 
 
 */

//Variables: 
byte inByte;                          // A byte received from the serial port 

void setup()    
{
  //Setup: Initalization 
  pinMode(8, OUTPUT);
  pinMode(13,OUTPUT);
  //Bautrate of the uart is 9600
  Serial.begin(9600);
}

void loop()
{
  if (Serial.available() > 0) {

     inByte = Serial.read();  // read input from PC
     
     switch (inByte)          //switch statement
     {
     case 48:   digitalWrite(8,LOW);            //The ASCII value of '0' = 48
                digitalWrite(13,LOW);          
                Serial.write("Leds OFF");       //Return: Leds OFF
                Serial.println();
                break;
     case 49:   digitalWrite(8,HIGH);            //The ASCII value of '1' = 49
                Serial.write("Led 2: On");       //Return: Led 2: On
                Serial.println();
                break;
     case 50:   digitalWrite(13,HIGH);            //The ASCII value of '2' = 50
                Serial.write("Led 14: On");       //Return: Led 14: On
                Serial.println();
                break;
     case 51:   digitalWrite(8,HIGH);             //The ASCII value of '3' = 51
                digitalWrite(13,HIGH);
                Serial.write("Leds ON");          //Return: Leds ON
                Serial.println(); 
                break;
     }    
  }    
            
}


