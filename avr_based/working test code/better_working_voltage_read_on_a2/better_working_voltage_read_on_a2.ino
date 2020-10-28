/*
DC Voltmeter Using a Voltage Divider
*/

int analogInput = A2;  // Read the voltage from the divider on A0 
float vout = 0.0;      // variable for the calculated voltage 
float vin = 0.0;       // variable for the resulting voltage
float R1 = 12000.0;    // variable to store the value of R1  
float R2 = 10000.0;     // variable to store the value of R2
int raw = 0;           // variable to store the raw ADC measurement

void setup(){
   pinMode(analogInput, INPUT);  // set pin A0 to be an input
   
   Serial.begin(9600);           // start the serial monitor
   Serial.print("DC VOLTMETER"); // display a welcome message
}
void loop(){
   
   // read the value at analog input A0
   // calculate the voltage from the raw adc value
   // account for the voltage divider
   // Display the result

   raw = analogRead(analogInput);
   vout = (raw * 5.0) / 1024.0; 
   vin = vout / (R2/(R1+R2)); 
   
   Serial.print("INPUT V= ");
   Serial.println(vin,2);
   delay(500);
}
