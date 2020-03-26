
#define interruptPin 3
volatile int count;
#define apin A0

void setup() {
  // put your setup code here, to run once:
pinMode(9, OUTPUT);
pinMode(interruptPin, INPUT_PULLUP);
pinMode(apin, INPUT);
analogWrite(9, 255);
attachInterrupt(1, left, CHANGE);
Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
Serial.print("Left: ");
Serial.println(count);
//Serial.println(digitalRead(apin));
delay(500);
}

void left() {
  count++;
}

