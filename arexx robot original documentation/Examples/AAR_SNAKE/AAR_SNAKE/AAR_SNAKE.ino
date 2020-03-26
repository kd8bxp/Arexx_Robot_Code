#include <avr/interrupt.h>
#include <avr/io.h>
#include "pins_arduino.h"

volatile unsigned char count72kHz = 0;
#define THRESH1 20
#define THRESH2 80
#define THRESH3 200
#define IR_LEFT	  _BV(MUX0) | _BV(MUX1)	//ADC3
#define IR_RIGHT  _BV(MUX1)
#define ADC4 _BV(REFS0) | _BV(REFS1) |  _BV(MUX2)
#define ADC5 _BV(REFS0) | _BV(REFS1) |  _BV(MUX2) | _BV(MUX0)
void setup(){
  Serial.begin(9600);

  pinMode(8, OUTPUT);   //led2
  pinMode(11, OUTPUT);  //36kHz signal out
  pinMode(3, OUTPUT);	//right motor backward
  pinMode(10, OUTPUT);	//left motor backward
  pinMode(5, OUTPUT);   //right motor foreward
  pinMode(9, OUTPUT);   //left motor foreward

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

void loop(){
  unsigned int tdata[2];
  unsigned int speed;
  signed int diff, sum;
  while(true){
    ThermalData(tdata);
    sum=tdata[0]+tdata[1];
	//check the intesity of the heat source
    if(sum>THRESH1){
      speed=140;
      if(sum>THRESH2){
        speed=200;
        if(sum>THRESH3){
          speed=255;
        }
      }
	  //check the direction of the heat source
      diff=((signed)tdata[0]-(signed)tdata[1])*32/sum;
      if(diff>5){//turn left
        analogWrite(3, 0);
        analogWrite(10, 0);
        analogWrite(5, speed);
        analogWrite(9, 0);
        //Serial.print(diff,DEC);
        //Serial.write("\n");
      }
      else if(diff<(-5)){//turn right
        analogWrite(3, 0);
        analogWrite(10, 0);
        analogWrite(5, 0);
        analogWrite(9, speed);
        //Serial.print(diff,DEC);
        //Serial.write("\n");
      }
      else{//go foreward
        analogWrite(3, 0);
        analogWrite(10, 0);
        analogWrite(5, speed);
        analogWrite(9, speed);
        //Serial.print(diff,DEC);
        //Serial.write("\n");
      }
    }
    else{//stop motors
        analogWrite(3, 0);
        analogWrite(10, 0);
        analogWrite(5, 0);
        analogWrite(9, 0);
        //Serial.print(diff,DEC);
        //Serial.write("\n");
    }
  }
}

void ThermalData(unsigned int *data){
  ADMUX = ADC5;//_BV(REFS0) | _BV(REFS1) | _BV(IR_LEFT); //Select ADC left pyro
  ADCSRA |= _BV(ADSC); //Start ADC
  while(!(ADCSRA & _BV(ADIF))); //wait until the adc is ready
  ADCSRA |= _BV(ADIF); //reset ADC interrupt vector
  data[0] = (ADCL +(ADCH <<8))/4; //get ADC value
  ADMUX = ADC4;//_BV(REFS0) | _BV(REFS1) | _BV(IR_RIGHT); //select ADC right pyro
  ADCSRA |= _BV(ADSC); //Start ADC
  while(!(ADCSRA & _BV(ADIF))); //wait until the adc is ready
  ADCSRA |= _BV(ADIF); //reset ADC interrupt vector
  data[1] = (ADCL + (ADCH<<8))/4; //get ADC value
}













