#define SPEED  0x8F

int speedLeft,speedRight;
unsigned int lineData[2];
int ADOffset;

void setup()    
{
  //Setup: Initalization 
  //pin 9 left foreward
  pinMode(9, OUTPUT);
  //pin 10 left backward
  pinMode(10, OUTPUT);
  //pin 5 right foreward
  pinMode(5, OUTPUT);
  //pin 6 right backward
  pinMode(6, OUTPUT);
  //Front led
  pinMode(7,OUTPUT);
  
  //Then set the start value of the signals to zero: 
  digitalWrite(9, 0); //pin 9 to ground  
  analogWrite(10, 0);   
  analogWrite(5, 0);   
  digitalWrite(6, 0); //pin 6 to ground
  digitalWrite(7,HIGH); //FrontLED ON
  //Startup delay:
  delay(2000);
    
}

void LineLeft (void)
{
	speedLeft  += 1;
	if (speedLeft > 0xFE) speedLeft = 0xFF;
}

void LineRight (void)
{
	speedRight  += 1;
	if (speedRight > 0xFE) speedRight = 0xFF;
}
void loop()
{
   LineDemo();
}

void LineDemo(void)
{
int i;
unsigned char j;

	for (j = 0; j < 0xFF; j++) LineData(lineData);
	LineData(lineData);
	ADOffset = lineData[0] - lineData[1];
	speedLeft = speedRight = SPEED;
	for(;;) {
		LineData(lineData);
		i = (lineData[0] - lineData[1]) - ADOffset;
		if ( i > 4) {
			LineLeft();
		}
		else if ( i < -4) {
			LineRight();
		}
		else {
			speedLeft = speedRight = SPEED;
		}
		analogWrite(9,speedLeft);
                analogWrite(5,speedRight);
	} 
}
void LineData(unsigned int *linedata)
{
        linedata[0]=analogRead(A6); //left linesensor
        delay(10);
	linedata[1]=analogRead(A7); //right linesensor
        delay(10);	  
}



