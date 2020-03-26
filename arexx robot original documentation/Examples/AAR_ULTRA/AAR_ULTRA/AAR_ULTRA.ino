#include <SoftPWM.h>
#include <SoftPWM_timer.h>
#include <TimerOne.h>
#include <avr/interrupt.h>
#include <avr/io.h>
#include "pins_arduino.h"

volatile unsigned char count72kHz = 0;
volatile boolean toggle;
void setup(){
  Serial.begin(9600);

  pinMode(8, OUTPUT); //led2
  pinMode(11, OUTPUT); //ultrasonic signal out
  pinMode(3, OUTPUT);	//right motor backward
  pinMode(10, OUTPUT);	//left motor backward
  pinMode(5, OUTPUT);   //right motor foreward
  pinMode(9, OUTPUT);   //left motor foreward

  SoftPWMBegin();
  SoftPWMSet(3,0);
  SoftPWMSet(5,0);
  SoftPWMSet(9,0);
  SoftPWMSet(10,0);

  /*  TCCR2A = (1 << WGM21) | (1 << COM2A0);
   TCCR2B = (1 << CS20);
   OCR2A  = 0xDC; // 36kHz @16MHz
   TIMSK2 |= (1 << OCIE2B); // 36kHz counter for sleep
   
   sei();//enable interrupts*/
  interrupts();
  Timer1.initialize(65536);
  Timer1.attachInterrupt(timer_isr);
  toggle=true;
  Serial.write("Hello AAR\n");
}

void timer_isr(){
  //ISR(TIMER2_COMPB_vect){  // Interrupt service routine to output next sample to PWM
  count72kHz ++;
  if(toggle){
    digitalWrite(11, !digitalRead(11));
  }
}

void loop(){
  int pos, i;
  int posmarker;
  LocalInit();
  while(true){
    posmarker = 0;
    Ping(10); //send burst with ultrasonic signal
    for(pos = 0; pos < 100; pos++) {
      delay(10);
      if((ACSR & (1 << ACI)) != 0) { //check if the compare interrupt flag is set
        if(posmarker == 0) { 
          posmarker = pos; 
        }
      }
      ACSR |= (1 << ACI);
    }
    Serial.write(posmarker);
    if(posmarker > 10) {
      digitalWrite(8,HIGH);
      SoftPWMSet(3,200);
      SoftPWMSet(5,0);
      SoftPWMSet(9,0);
      SoftPWMSet(10,200);
    }
    else {
      digitalWrite(8, LOW);
      SoftPWMSet(3,0);
      SoftPWMSet(5,200);
      SoftPWMSet(9,200);
      SoftPWMSet(10,0);
      //delay(200);
    }
    PingStop();//turn of the ultrasonic signal
  }
}

void LocalInit(void)
{
  // Change Oscillator-frequency of Timer 2
  // to 40kHz, no toggling of IO-pin:
  /*TCCR2A = _BV(WGM21);
   TCCR2B = _BV(CS20);
   OCR2A = 0xC7;					// 40kHz @16MHz crystal*/
  Timer1.initialize(62944);
  toggle=false;
  ADCSRA = 0x00;				// ADC off
  // Analog comparator:
  ACSR = 0x02;					// Generate interrupt on falling edge
  ADMUX = 0x05;					// Multiplexer for comparator to
  // ADC pin 3
  ADCSRB |= _BV(ACME);		// Enable muliplexing of comparator
  pinMode(6, INPUT);            // Port D Pin 6 is input!
}

void Ping(unsigned char length)
{
  count72kHz = 0;
 /* TCCR2A = _BV(WGM21) | _BV(COM2A0);
  TCCR2B = _BV(CS20);*/
  // Toggling of IO-Pin on
  toggle=true;
  // generate the Chirp
  while(count72kHz < length) {
    Timer1.initialize((0xC7 + length / 2 - count72kHz)*256);
  }
}

void PingStop(){
 /* TCCR2A = _BV(WGM21);
  TCCR2B = _BV(CS20);      // Toggling of IO-Pin off*/
  toggle = false;
  Timer1.initialize(0xDC*256);		     // set frequency to 36kHz @16MHz 
}










