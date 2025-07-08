#include <OneWire.h>
#include <DallasTemperature.h>
#include "secrets.h"
#include <WiFi.h>
#include <HTTPClient.h>
#include <ArduinoJson.h>

// Configuration
#define API_HOST "http://192.168.10.26:5126" // The IP changes with the connection and the port is the one that visual studio display in the console when running the code
#define READS_FREQUENCY 60000 // 1 min = 60000 miliseconds
#define TRAY_ID "4"
#define TOKEN "HYGERR"

String getUrl = String(API_HOST) + "/Tray/" + TRAY_ID

// Data wire is connected to GPIO4
// The PIN 4 is used to temperature
#define ONE_WIRE_BUS 4

// Setup a oneWire instance
OneWire oneWire(ONE_WIRE_BUS);

DallasTemperature sensors(&oneWire);

void setup() {
  // put your setup code here, to run once:
  pinMode(14, OUTPUT); // GPIO2 is often connected to onboard LED
  pinMode(2, OUTPUT); // This is the PIN to the UV LEDS
  pinMode(26, OUTPUT); // This is the PIN to the Water Pump
  Serial.begin(115200);
  sensors.begin();
}

void loop() {

  // Call the function that is conected to the sensor to reading the UV light
  readUV();

  // Call the function that is conected to the sensor to reading the humidity
  readHumidity();
  
  // Call the function that is conected to the sensor to reading the temperature
  readTemperature();
}

// Function to the UV light sensor
void readUV() 
{
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
}

// Function to the humidity sensor
void readHumidity() 
{
  // It it to read the humidity
  int humidityValue = analogRead(33);

  Serial.print("HU analog value: ");
  Serial.print(humidityValue);
  Serial.print(" | Voltage: ");
  Serial.println(" V");

  // Turn on and turn off the water pump
  if (humidityValue >= 3000) 
  {
    Serial.println("Turning ON Water Pump");
    digitalWrite(26, HIGH);
    delay(2000);
    Serial.println("Turning OFF Water Pump");
    digitalWrite(26, LOW);
  }
}

// Function to the temperature sensor
void readTemperature()
{
  if (sensors.getDeviceCount() == 0) 
  {
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
