/*
 Name project:   Arexx Arduino Robot 
 Autor:          Egbert
 Company:        Arexx Engineering
 Discription:    Selftest for AAR v1.2
 */
#include <SPI.h>
#include <avr/interrupt.h>
#include <avr/io.h>
#include "pins_arduino.h"
#include <SoftPWM.h>
#include <SoftPWM_timer.h>
#include <TimerOne.h>

int temp;
int startbit;
int cases=0;           //start condition to print the menu.  
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

void setup(){
  //Set baudrate to 9600
  Serial.begin(9600);

  //set pin I/O
  pinMode(A1, INPUT);	//encoder right
  pinMode(A0, INPUT);	//encoder left
  pinMode(5, OUTPUT);	//right motor foreward
  pinMode(9, OUTPUT);	//left motor foreward
  pinMode(7, OUTPUT);	//red line sensor
  pinMode(3, OUTPUT);	//right motor backward
  pinMode(10, OUTPUT);	//left motor backward
  pinMode(8, OUTPUT);  //statusled
  pinMode(A2, INPUT);	//battery sensor
  pinMode(A5, INPUT);   //Ultrasonic sensor
  pinMode(A6, INPUT);	//linesensor left
  pinMode(A7, INPUT);	//linesensor right
  pinMode(6, INPUT);    //PD6
  pinMode(11, OUTPUT);   //OC2

  interrupts(); //enable interrupts

    //set motor speed to 0
  SoftPWMSet(3,0);
  SoftPWMSet(5,0);
  SoftPWMSet(9,0);
  SoftPWMSet(10,0);  

  // TIMER1 Settings
  Timer1.initialize(1600000);         // initialize timer1, and set a 1.6 second period
  Timer1.attachInterrupt(timer_isr);  // attaches callback() as a timer overflow interrupt

  SoftPWMBegin();
  SoftPWMSet(3,0);
  SoftPWMSet(5,0);
  SoftPWMSet(9,0);
  SoftPWMSet(10,0);

  PCattachInterrupt(A0,leftsens,CHANGE);
  PCattachInterrupt(A1,rightsens,CHANGE);
}
void loop(){

  switch (cases){

  case 0:                                                            //start condition   
    Serial.begin(9600);

    Serial.print("\n\n\nBienvenue !\nCe programme sert a la calibration des moteurs et des senseurs\ndu robot.\n");  
    Serial.print("\nChoisir une option:\n\n");
    Serial.print("1. Calibration des senseurs de ligne\n");
    Serial.print("2. Calibration des moteurs\n");

    cases = retrieve_data();
    break;

  case 10:                                                          //new line sent by pc
    cases = retrieve_data();
    break;

  case 49:                                                          //caracter 1 sent by pc
    linesensortest();
    cases=0;
    break;

  case 50:                                                          //character 2 sent by pc
    motortest(); 
    cases=0;
    break;

  default:                                                          //if wrong number received                                            
    Serial.print("Entree invalide, veuillez entrer 1 ou 2 !\n");
    cases = retrieve_data();
    break;
  }   
}

int retrieve_data(){                                    //reads the data that is sent as last
  int inputByte;
  int counter;
  int availablebytes;
  while(1){
    if ( Serial.available() > 0){                      // any data waiting?
      break;                                         // if not, stop function.
    }
  }
  availablebytes = Serial.available();                 // if data available, read the data.
  for(counter=0;counter < availablebytes;counter++){    
    inputByte = Serial.read();                    // make sure the last data in the buffer is used. 
  };                                               // recommend only to use this method in this selftest.
  return inputByte;
}

void timer_isr() {
  speed_timer++;
  if(speed_timer > SPEED_TIMER_BASE) {
    if (mright_counter > 255) {
      mright_counter=255;
    }
    mright_speed = mright_counter;
    if (mleft_counter > 255) {
      mleft_counter=255;
    }
    mleft_speed = mleft_counter;
    mright_counter = 0;
    mleft_counter = 0;
    speed_timer = 0;
  }
};

void rightsens()  //external interrupt right encoder
{
  PCdetachInterrupt(A1);  
  mright_counter++;
  PCattachInterrupt(A1,rightsens,CHANGE);  
}

void leftsens()  //external interrupt left encoder
{
  PCdetachInterrupt(A0);
  mleft_counter++;
  PCattachInterrupt(A0,leftsens,CHANGE);
}

void motortest(){

  /*  3=RBW 5=RFW 9=LFW 10=LBW
   *  SoftPWMSet(3,0);
   *  SoftPWMSet(5,0);
   *  SoftPWMSet(9,0);
   *  SoftPWMSet(10,0);
   */

  int temp;
  while(1){
    Serial.print("\nCe programme sert a calibrer la vitesse de rotation des moteurs.\nAssurez-vous que le robot NE PEUT PAS BOUGER !!!\nLes roues ne doivent pas etre en contact avec le sol.\n\n1. Demarrer le test.\n");
    while(1){
      temp = retrieve_data();
      if(temp == 49){  //49 en ASCII correspond au chiffre 1
        break;
      }
      else Serial.print("Please enter 1 to start the test.\n");
    };
    /* Motortest when motors go forwards*/
    SoftPWMSet(3,0);
    SoftPWMSet(5,200);
    SoftPWMSet(9,200);
    SoftPWMSet(10,0);
    delay(200);
    for(temp=80;temp<255;temp++){            //increase motor pwm slowly
      SoftPWMSet(3,0);
      SoftPWMSet(5,temp);
      SoftPWMSet(9,temp);
      SoftPWMSet(10,0);
      delay(100); 
    }

    for (int i=0; i <= 4; i++){
      Serial.print("\nVitesse moteur gauche: ");
      Serial.print(mleft_speed);
      Serial.print("   Moteur droit: ");
      Serial.print(mright_speed);
      delay(500);
    }
      
    //delay(2000);                            //motor goes full power for two seconds
    SoftPWMSet(3,0);                        //turn off motors
    SoftPWMSet(5,0);
    SoftPWMSet(9,0);
    SoftPWMSet(10,0);
    delay(1000);                            //wait for one second

    /* Motortest when motors go backwards*/
    SoftPWMSet(3,200);
    SoftPWMSet(5,0);
    SoftPWMSet(9,0);
    SoftPWMSet(10,200);
    delay(200);
    for(temp=80;temp<255;temp++){            //increase motor pwm slowly
      SoftPWMSet(3,temp);
      SoftPWMSet(5,0);
      SoftPWMSet(9,0);
      SoftPWMSet(10,temp);
      delay(100); 
    }
    
    for (int i=0; i <= 4; i++){
      Serial.print("\nVitesse marche arriere moteur gauche: ");
      Serial.print(mleft_speed);
      Serial.print("   Moteur droit: ");
      Serial.print(mright_speed);
      delay(500);
    }
    
    //delay(2000);                            //motor goes full power for two seconds
    SoftPWMSet(3,0);                        //turn off motors
    SoftPWMSet(5,0);
    SoftPWMSet(9,0);
    SoftPWMSet(10,0);
    delay(1000);                            //wait for one second

    Serial.print("\nAvez-vous pu noter les valeurs?\n1. Oui.\n2. Non, recommencer.\n");
    while(1){
      temp = retrieve_data();              //wait for answer
      if (temp == 50 | temp == 49){       //is it a 1 or 2?
        break;
      }
      else Serial.print("Veuillez entrer 1 ou 2 !\n");
    }
    if (temp == 49){                        //if '1' is received, end this case.
      break;
    }                             //if '2' is reveived, the case will start again.
  }
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
    delay(500);                             //print two values in one second.
  }
}

void linesensortest(){
  int left=0;
  int right=0;
  /* print intro text */
  Serial.print("Ce programme sert a calibrer les senseurs de ligne.\n");
  Serial.print("Placez les senseurs sur du blanc puis sur du noir, et notez les valeurs renvoyees.\n");
  Serial.print("Appuyez sur ENTER pour terminer le test.\n");
  digitalWrite(7,HIGH);                     //allumer la LED rouge
  while(1){
    if( Serial.available() > 1){            //check if ENTER is pressed
      digitalWrite(7,LOW);                  //eteindre la LED rouge
      break;
    }
    left = analogRead(A6);
    right = analogRead(A7);
    
    Serial.print("LEFT: ");
    Serial.print(left);
    Serial.print("    ");
    Serial.print("RIGHT: ");
    Serial.print(right);
    Serial.print("    \n");
    
    delay(500);
  }

}




