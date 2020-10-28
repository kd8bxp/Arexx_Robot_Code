void setup() {
  pinMode(A2, INPUT);
Serial.begin(9600);
}

void loop() {
 int sensorValue = analogRead(A2);
 float voltage = (sensorValue * 5.0 )/ 1024.0 ;
  Serial.println(voltage * 2);
}
