/*
 Name project:   Example 2, Serial ouput 
 Autor:          Egbert Koerhuis
 Company:        Arexx Engineering
 Discription:     
 This example shows how to use the serial output.
 Open the serial monitor and see the serial output that the microcontroller send to the PC
 */

byte Serial_Value = 47; 

void setup()  
{
  //Setup: Initalization 
  
  //Bautrate of the uart is 9600
  Serial.begin(9600);
  Serial.write("Hello AAR!\n");
}

void loop()
{
        if (Serial_Value < 96 )
        {
        Serial_Value++;
        }
        
        else
        {
          Serial.write("\n");
          Serial_Value = 48; 
        }
        
        Serial.write((byte)Serial_Value);
        // wait for 250 milliseconds to see the dimming effect    
        delay(100);  
}

