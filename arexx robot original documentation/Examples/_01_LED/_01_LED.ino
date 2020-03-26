/*
 Name project:   Example 1, Led test  
 Author:         Egbert Koerhuis
 Company:        Arexx Engineering
 Discription:     
 This example shows how to use the leds,
 */

void setup()  
{
  //Setup: Initalization 
  
  // set pin 8 and 13 as an output:
  pinMode (8, OUTPUT); //LED2
  pinMode (13,OUTPUT); //LED14
}

void loop()
{
  //turn led 2 on
  digitalWrite(8,HIGH);
  //turn led 14 off
  digitalWrite(13,LOW);
  //wait 100 ms
  delay(100);
  //turn led 2 off
  digitalWrite(8, LOW);
  //turn led 14 on
  digitalWrite(13, HIGH);
  //wait for 100ms
  delay(100);
  }

