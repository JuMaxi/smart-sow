#include <OneWire.h>
#include <DallasTemperature.h>

// Data wire is connected to GPIO4
#define ONE_WIRE_BUS 4

// Setup a oneWire instance
OneWire oneWire(ONE_WIRE_BUS);

DallasTemperature sensors(&oneWire);

void setup() {
  // put your setup code here, to run once:
  pinMode(14, OUTPUT); // GPIO2 is often connected to onboard LED
  pinMode(2, OUTPUT); // This is the PIN to the UV LEDS
  Serial.begin(115200);
  sensors.begin();
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

  Serial.print("UV Analog value: ");
  Serial.print(rawValue);
  Serial.print(" | Voltage: ");
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

  Serial.print("HU analog value: ");
  Serial.print(humidityValue);
  Serial.print(" | Voltage: ");
  Serial.println(" V");

  if (sensors.getDeviceCount() == 0) {
    Serial.println("No DS18B20 sensors found!");
  }
  else
  {
    Serial.print("Temperature: ");
    sensors.requestTemperatures(); // Send command to get temperatures
    delay(1000);
    float temperatureC = sensors.getTempCByIndex(0);
    Serial.println(temperatureC);
  }
}
