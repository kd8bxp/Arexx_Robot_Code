void setup() {
  Serial.begin(9600);
  
  pinMode(5, OUTPUT);	//right motor foreward
  pinMode(9, OUTPUT);	//left motor foreward
  pinMode(7, OUTPUT);	//red line sensor
  pinMode(3, OUTPUT);	//right motor backward
  pinMode(10, OUTPUT);	//left motor backward
  
}

void loop() {
  Serial.println("Right Forward");
  
  for (int i = 185; i< 255; i++) {
    analogWrite(5, i);
    Serial.println(i);
    delay(100);
    
  }
  delay(5000);
  analogWrite(5,0);
  
  Serial.println("Left Forward");
  for (int i = 145; i< 255; i++) {
    analogWrite(9, i);
    Serial.println(i);
    delay(100);
  }
  delay(5000);
  analogWrite(9,0);
  
  Serial.println("Left Backward");
  for (int i = 160; i< 255; i++) {
    analogWrite(10, i);
    Serial.println(i);
    delay(100);
  }
  delay(5000);
  analogWrite(10,0);
  
  Serial.println("Right Backward");
  for (int i = 145; i< 255; i++) {
    analogWrite(3, i);
    Serial.println(i);
    delay(100);
  }
  delay(5000);
  analogWrite(3, 0);
  delay(5000);
}
