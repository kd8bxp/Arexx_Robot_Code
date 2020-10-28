
#include "src/SoftPWM/SoftPWM.h"
#include "src/SoftPWM/SoftPWM_timer.h"
#include <avr/interrupt.h>
#include <avr/io.h>
#include "src/TimerOne/TimerOne.h"
#include "pins_arduino.h"

//encoder variables
volatile int speed_timer;
int mleft_speed;
int mright_speed;
int mleft_counter;
int mright_counter;
#define SPEED_TIMER_BASE (1)
//#define SPEED_TIMER_BASE 520 

volatile uint8_t *port_to_pcmask[] = {
  &PCMSK0,
  &PCMSK1,
  &PCMSK2
};

static int PCintMode[24];
typedef void (*voidFuncPtr)(void);
volatile static voidFuncPtr PCintFunc[24] = { 
  NULL };
volatile static uint8_t PCintLast[3];


/*
 * attach an interrupt to a specific pin using pin change interrupts.
 */
void PCattachInterrupt(uint8_t pin, void (*userFunc)(void), int mode) {
  uint8_t bit = digitalPinToBitMask(pin);
  uint8_t port = digitalPinToPort(pin);
  uint8_t slot;
  volatile uint8_t *pcmask;

  // map pin to PCIR register
  if (port == NOT_A_PORT) {
    return;
  } 
  else {
    port -= 2;
    pcmask = port_to_pcmask[port];
  }

  // -- Fix by Baziki. In the original sources it was a little bug, which cause analog ports to work incorrectly.
  if (port == 1) {
    slot = port * 8 + (pin - 14);
  }
  else {
    slot = port * 8 + (pin % 8);
  }
  // --Fix end
  PCintMode[slot] = mode;
  PCintFunc[slot] = userFunc;
  // set the mask
  *pcmask |= bit;
  // enable the interrupt
  PCICR |= 0x01 << port;
}

void PCdetachInterrupt(uint8_t pin) {
  uint8_t bit = digitalPinToBitMask(pin);
  uint8_t port = digitalPinToPort(pin);
  volatile uint8_t *pcmask;

  // map pin to PCIR register
  if (port == NOT_A_PORT) {
    return;
  } 
  else {
    port -= 2;
    pcmask = port_to_pcmask[port];
  }

  // disable the mask.
  *pcmask &= ~bit;
  // if that's the last one, disable the interrupt.
  if (*pcmask == 0) {
    PCICR &= ~(0x01 << port);
  }
}

// common code for isr handler. "port" is the PCINT number.
// there isn't really a good way to back-map ports and masks to pins.
static void PCint(uint8_t port) {
  uint8_t bit;
  uint8_t curr;
  uint8_t mask;
  uint8_t pin;

  // get the pin states for the indicated port.
  curr = *portInputRegister(port+2);
  mask = curr ^ PCintLast[port];
  PCintLast[port] = curr;
  // mask is pins that have changed. screen out non pcint pins.
  if ((mask &= *port_to_pcmask[port]) == 0) {
    return;
  }
  // mask is pcint pins that have changed.
  for (uint8_t i=0; i < 8; i++) {
    bit = 0x01 << i;
    if (bit & mask) {
      pin = port * 8 + i;
      // Trigger interrupt if mode is CHANGE, or if mode is RISING and
      // the bit is currently high, or if mode is FALLING and bit is low.
      if ((PCintMode[pin] == CHANGE
        || ((PCintMode[pin] == RISING) && (curr & bit))
        || ((PCintMode[pin] == FALLING) && !(curr & bit)))
        && (PCintFunc[pin] != NULL)) {
        PCintFunc[pin]();
      }
    }
  }
}

SIGNAL(PCINT0_vect) {
  PCint(0);
}
SIGNAL(PCINT1_vect) {
  PCint(1);
}
SIGNAL(PCINT2_vect) {
  PCint(2);
}


void setup() {
  Serial.begin(9600);
  // put your setup code here, to run once:
  //set pin I/O
  pinMode(A1, INPUT);  //encoder right
  pinMode(A2, INPUT); //encoder left //Probably Not A2 (??)
  pinMode(5, OUTPUT);  //right motor foreward
  pinMode(9, OUTPUT); //left motor foreward
  pinMode(3, OUTPUT);  //right motor backward
  pinMode(10, OUTPUT);  //left motor backward
 interrupts(); //enable interrupts

// TIMER1 Settings
 //Timer1.initialize(1600000);         // initialize timer1, and set a 1.6 second period
   Timer1.initialize(160000);
  Timer1.attachInterrupt(timer_isr);  // attaches callback() as a timer overflow interrupt

  SoftPWMBegin();
  SoftPWMSet(3,0);
  SoftPWMSet(5,0);
  SoftPWMSet(9,0);
  SoftPWMSet(10,0);

  PCattachInterrupt(A2,leftsens,CHANGE);
  PCattachInterrupt(A1,rightsens,CHANGE);


}

void loop() {
  // put your main code here, to run repeatedly:
encodertest();
}

void encodertest(){
  /* This is the encoder test.*/
  Serial.print("\n Welcome to the encoder test. \n\n This test will print the duration of the encoderpulses to the screen.");
  Serial.print("\n The values are microseconds. \n\nPress ENTER to terminate the encoder test\n ");

  /* Start the Motors */
  SoftPWMSet(3,0);
  SoftPWMSet(5,200);
  SoftPWMSet(9,200);
  SoftPWMSet(10,0);

  /*Infinite Loop */
  while(1){
    if( Serial.available() > 1){            //check if ENTER is pressed
      SoftPWMSet(3,0);
      SoftPWMSet(5,0);
      SoftPWMSet(9,0);
      SoftPWMSet(10,0); 
      break;
    }
    Serial.print("\nLeft value: ");
    Serial.print(mleft_speed);
    Serial.print("   Right value: ");
    Serial.print(mright_speed);
    //delay(500);                             //print two values in one second.
  }
}

void rightsens()  //external interrupt right encoder
{
  PCdetachInterrupt(A1);  
  mright_counter++;
  PCattachInterrupt(A1,rightsens,CHANGE);  
}

void leftsens()  //external interrupt left encoder
{
  PCdetachInterrupt(A2);
  mleft_counter++;
  PCattachInterrupt(A2,leftsens,CHANGE);
}

void timer_isr() {
  speed_timer++;
  
    if (mright_counter > 255) {
      mright_counter=255;
      mright_speed = mright_counter;
      mright_counter = 0;
    }
    
    if (mleft_counter > 255) {
      mleft_counter=255;
      mleft_speed = mleft_counter;
      mleft_counter = 0;
    }
 if(speed_timer > SPEED_TIMER_BASE) {
    mright_speed = mright_counter;
    mleft_speed = mleft_counter;
    mright_counter = 0;
    mleft_counter = 0;
    speed_timer = 0;
  }
};
