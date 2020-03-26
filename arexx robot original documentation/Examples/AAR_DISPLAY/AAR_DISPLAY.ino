#include <LiquidCrystal_I2C.h>
#include <TimerOne.h>
#include <Wire.h>

#define LCD_DISP_OFF             0x08   /* Display aus                 	  */
#define LCD_DISP_ON              0x0C   /* Display an                     */
#define LCD_DISP_ON_CURSOR       0x0E   /* Display an, Cursor an          */
#define LCD_DISP_ON_CURSOR_BLINK 0x0F   /* Display an, Cursor blinkend    */
#define RS_bit 	  	    0				//Register Select Bit  ( high for data, low for command)
#define RW_bit		    1				//H: Read    / L: Write
#define E_bit 		    2				//Enable Bit
#define LED_bit             3				//H: LED Off / L: LED on
#define pcf8574_address 0x20
#define LCD_START_LINE1          0x00  	/* DDRAM Adresse des ersten Zeichens in Zeile 1 */
#define LCD_START_LINE2          0x40   /* DDRAM Adresse des ersten Zeichens in Zeile 2 */
#define lcd_puts_P(__s)         lcd_puts_p(PSTR(__s))

volatile boolean toggle;
volatile unsigned char count72kHz = 0;
unsigned char LEDstatus = 1; 		// 1= OFF 0=ON  

void setup(){
  Serial.begin(9600);
  Wire.begin();
  //pinMode(8, OUTPUT); //led2
  //pinMode(11, OUTPUT); //ultrasonic signal out
  pinMode(3, OUTPUT);	//right motor backward
  pinMode(10, OUTPUT);	//left motor backward
  pinMode(5, OUTPUT);   //right motor foreward
  pinMode(9, OUTPUT);   //left motor foreward
  pinMode(11,INPUT); //blue button
  pinMode(2, INPUT); //red button
  pinMode(6, INPUT); //yellow button

  Timer1.initialize(65536);         // initialize timer1, and set a 1.6 second period
  Timer1.attachInterrupt(timer_isr);  // attaches callback() as a timer overflow interrupt
  toggle = false;
  interrupts();
  
  Serial.write("Hello AAR\n");
  lcd_init(LCD_DISP_ON_CURSOR_BLINK);	//Initialisiert das Display Modul
}

void timer_isr(){
  //ISR(TIMER2_COMPB_vect){  // Interrupt service routine to output next sample to PWM
  count72kHz ++;
  if(toggle){
    digitalWrite(11, !digitalRead(11));
  }
}

void loop(){
	lcd_puts("Ich bin");				 //Gibt String aus dem RAM aus
	lcd_gotoxy(5,1);					 //Setzt Cursor auf 4. Zeichen in der 2. Zeile
	lcd_puts_P("AAR");				 //Gibt String aus dem FLASH aus
	for(;;);
}

void set_pcf8574(unsigned char byte)
{
 Wire.beginTransmission(pcf8574_address);
 Wire.write(byte); 
 Wire.endTransmission();
}

void lcd_init (unsigned char dispAttr)
{
  send_nibble(0x28);						// (Function Set) noch im 8-Bit Modus -> in 4 Bit Modus umschalten  
  lcd_command(0x28);						// (Function Set) 4 Bit, 2 Zeilen, 5x7 Schriftart
  lcd_command(dispAttr);					// (Display ON/OFF) 
  lcd_command(0x01);						// (Clear Display)
  lcd_command(0x06);						// (Entry Mode Set) Cursor Auto-Increment
}

void send_nibble(unsigned char i2cbyte)
{
  set_pcf8574(i2cbyte|(LEDstatus<<LED_bit));				//Daten anlegen
  set_pcf8574(i2cbyte|(LEDstatus<<LED_bit)|(1<<E_bit));	//Enable_bit setzen
  set_pcf8574(i2cbyte|(LEDstatus<<LED_bit));				//Enable_bit löschen
}

void lcd_command(unsigned char byte)
{
	send_nibble(byte&0xF0);  		// sende oberes Halbbyte
	send_nibble(byte<<4);			// sende unteres Halbbyte
}

void lcd_putc(unsigned char byte)
{
  send_nibble((byte&0xF0)|(1<<RS_bit)); 		// sende oberes Halbbyte, dabei RS_bit gesetzt
  send_nibble((byte<<4)  |(1<<RS_bit)); 		// sende unteres Halbbyte, dabei RS_bit gesetzt
}

void lcd_gotoxy(unsigned char x, unsigned char y)
{
  if ( y==0 ) 
    lcd_command(0x80+LCD_START_LINE1+x);
  else
    lcd_command(0x80+LCD_START_LINE2+x);
}

void lcd_puts(const char *s)
{
    register char c;

    while ( (c = *s++) ) {
        lcd_putc(c);
    }
}

void lcd_puts_p(const char *progmem_s)
{
    register char c;

    while ( (c = pgm_read_byte(progmem_s++)) ) {
        lcd_putc(c);
    }

}


