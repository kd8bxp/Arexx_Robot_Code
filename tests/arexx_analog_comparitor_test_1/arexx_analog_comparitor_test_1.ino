volatile boolean triggered;

ISR (ANALOG_COMP_vect)
  {
  triggered = true;
  }

void setup ()
  {
  Serial.begin (9600);
  Serial.println ("Started.");
  ADCSRB = 0;           // (Disable) ACME: Analog Comparator Multiplexer Enable
  ACSR =  bit (ACI)     // (Clear) Analog Comparator Interrupt Flag
        | bit (ACIE)    // Analog Comparator Interrupt Enable
        | bit (ACIS1);  // ACIS1, ACIS0: Analog Comparator Interrupt Mode Select (trigger on falling edge)
   }  // end of setup

void loop ()
  {
  if (triggered)
    {
    Serial.println ("Triggered!"); 
    triggered = false;
    }

  }  // end of loop
