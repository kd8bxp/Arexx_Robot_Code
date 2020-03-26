//this is not how they control the motors but seems to work, have to
//look into what they are doing here.

#define LeftP1 10
#define LeftP2 9
#define RightP1 5
#define RightP2 3

void setup() {
  // put your setup code here, to run once:
pinMode(LeftP1, OUTPUT);
pinMode(LeftP2, OUTPUT);
pinMode(RightP1, OUTPUT);
pinMode(RightP2, OUTPUT);
stop();
}

void loop() {
  // put your main code here, to run repeatedly:
//forward();
//backward();
//delay(5000);
//stop();
//delay(5000);
//leftmotorrun();
//rightmotorrun();
//rightmotorrunB();
tightRight();
delay(1000);
stop();
while(1) {}
}

void stop() {
  digitalWrite(LeftP1, LOW);
  digitalWrite(LeftP2, LOW);
  digitalWrite(RightP1, LOW);
  digitalWrite(RightP2, LOW);
}

void forward() {
  analogWrite(LeftP2, 255);
  digitalWrite(LeftP1, LOW);
  analogWrite(RightP1, 255);
  digitalWrite(RightP2, LOW);
}

void backward() {
  analogWrite(LeftP1, 255);
  digitalWrite(LeftP2, LOW);
  analogWrite(RightP2, 255);
  digitalWrite(RightP1, LOW);
}
void leftmotorrunB() {
  //backward
  analogWrite(LeftP1, 255);
  digitalWrite(LeftP2, LOW);
}

void leftmotorrun() {
  analogWrite(LeftP2, 255);
  digitalWrite(LeftP1, LOW);
}

void rightmotorrun() {
  //forward
  analogWrite(RightP1, 255);
  digitalWrite(RightP2, LOW);
}

void rightmotorrunB() {
  digitalWrite(RightP1, LOW);
  analogWrite(RightP2, 255);
}

void tightLeft() {
  analogWrite(LeftP1, 255);
  digitalWrite(LeftP2, LOW);
   analogWrite(RightP1, 255);
  digitalWrite(RightP2, LOW);
}

void tightRight() {
  analogWrite(LeftP2, 255);
  digitalWrite(LeftP1, LOW);
   analogWrite(RightP2, 255);
  digitalWrite(RightP1, LOW);
}

