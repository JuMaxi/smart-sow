void setup() {
  // put your setup code here, to run once:
  pinMode(14, OUTPUT); // GPIO2 is often connected to onboard LED
  pinMode(2, OUTPUT); // This is the PIN to the UV LEDS
  Serial.begin(115200);
}

void loop() {
  // put your main code here, to run repeatedly:
  Serial.println("Turning ON");
  digitalWrite(14, HIGH); // Turn LED on
  delay(500);
  Serial.println("Turning OFF");
  digitalWrite(14, LOW);  // Turn LED off
  delay(500);


  // It is reading the UV sensor
  int rawValue = analogRead(32);  // Read raw analog value
  float voltage = rawValue * (5.0 / 1023.0);  // Convert to voltage (assuming 5V)

  Serial.print("UV Analog value: ");
  Serial.print(rawValue);
  Serial.print(" | Voltage: ");
  Serial.print(voltage, 2);
  Serial.println(" V");

  // It is to turn on or turn off the UV light
  if (rawValue == 0){
    Serial.println("Turning ON UV Leds");
    digitalWrite(2, HIGH);
  }
  else {
    Serial.println("Turning OFF UV Leds");
    digitalWrite(2, LOW);
  }
  
  // It it to read the humidity
  int humidityValue = analogRead(33);
  float voltage2 = humidityValue * (5.0 / 1023.0);

  Serial.print("HU analog value: ");
  Serial.print(humidityValue);
  Serial.print(" | Voltage: ");
  Serial.print(voltage2, 2);
  Serial.println(" V");

  
}
