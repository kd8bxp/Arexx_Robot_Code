#include <avr/interrupt.h>
#include <avr/io.h>

volatile int value = 0;
volatile int left = 0;
volatile int right = 0;

//uint8_t PCLAST = 0;
char PCLAST;

void setup()
{
pinMode(A0, INPUT);
digitalWrite(A0, HIGH);
cli();
PCICR |= 0b00000010; // Enables Ports B and C Pin Change Interrupts
//PCMSK0 |= 0b00000001; // PCINT0
PCMSK1 |= 0b0000011; // PCINT11
sei();

Serial.begin(9600);

//analogWrite(5,200);
analogWrite(9, 200);

}

void loop()
{
Serial.print("Left ");
Serial.print(left);
Serial.print(" Right: ");
Serial.println(right);
//Serial.println(value);
//delay(500);
}

ISR(PCINT0_vect)
{
value++;
}

/*ISR(PCINT1_vect)
{
    uint8_t PCNOW;
    PCNOW = PINC ^ PCLAST;
    PCLAST = PINC;
 
//switch (PCNOW){
//case (1 << PINC1):
if (PCNOW & (1<<PINC0)) {
left++;
}
//break;
//case (1 << PINC0):
if (PCNOW & (1<<PINC1)) {
right++;
}
//break;
//default:
//break;
//}
}*/

/*ISR(PCINT1_vect) {
  char PCNOW = PINC ^ PCLAST;
  PCLAST = PINC;
  if(bitRead(PCNOW, 1)) right++;
  if(bitRead(PCNOW, 0)) left++;
}*/

ISR(PCINT1_vect){
char PCNOW = (PINC ^ PCLAST) & 3;
PCLAST = PINC;
switch (PCNOW){
case(1):      //A0 pin changed
left++;
break;
case(2):      // A1 pin changed
right++;
break;
default:       // A0 and A1 changed
//right++;
//left++;
break;
}
}

