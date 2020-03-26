#include <avr/interrupt.h>
#include <avr/io.h>
#include "pins_arduino.h"

volatile unsigned char count72kHz = 0;

void setup(){
  Serial.begin(9600);

  pinMode(8, OUTPUT); //led2
  pinMode(11, OUTPUT); //ultrasonic signal out
  pinMode(3, OUTPUT);	//right motor backward
  pinMode(10, OUTPUT);	//left motor backward
  pinMode(5, OUTPUT);   //right motor foreward
  pinMode(9, OUTPUT);   //left motor foreward
  pinMode(6, OUTPUT);
  pinMode(2, INPUT);

  TCCR2A = (1 << WGM21) | (1 << COM2A0);
  TCCR2B = (1 << CS20);
  OCR2A  = 0xDC; // 36kHz @16MHz
  TIMSK2 |= (1 << OCIE2B); // 36kHz counter for sleep

  sei();//enable interrupts

  Serial.write("Hello AAR\n");
}


ISR(TIMER2_COMPB_vect){  // Interrupt service routine to output next sample to PWM
  count72kHz ++;
}

void loop (){
  unsigned char oscillation;
  digitalWrite(6,LOW);
  while(true){
    count72kHz = 0;
    oscillation = false;
    while(count72kHz<100){
      if(digitalRead(2)==0){
        oscillation=true;
      }
      if (oscillation){
        digitalWrite(6,LOW);
      }
      else{
        digitalWrite(6,HIGH);
      }
    }
  }
}













