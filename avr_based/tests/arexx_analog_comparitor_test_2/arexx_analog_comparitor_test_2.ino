volatile unsigned int encoderPos = 0;

void setup() {                
ACSR =
  (0<<ACD) |   // Analog Comparator: Enabled
  (0<<ACBG) |   // Analog Comparator Bandgap Select: AIN0 is applied to the positive input
  (0<<ACO) |   // Analog Comparator Output: Off
  (1<<ACI) |   // Analog Comparator Interrupt Flag: Clear Pending Interrupt
  (1<<ACIE) |   // Analog Comparator Interrupt: Enabled
  (0<<ACIC) |   // Analog Comparator Input Capture: Disabled
  (1<<ACIS1) | (1<ACIS0);   // Analog Comparator Interrupt Mode: Comparator Interrupt on Rising Output Edge  
  
  Serial.begin(9600); 
}

void loop() {

  Serial.print("encoderPos=");
  Serial.println(encoderPos);

  delay(300);  
  
}
  
ISR(ANALOG_COMP_vect)
{
  // This is the interrupt handler
  encoderPos++;
  if (encoderPos > 32000) encoderPos=1;
}
