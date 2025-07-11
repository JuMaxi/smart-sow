#include <OneWire.h>
#include <DallasTemperature.h>
#include "secrets.h"
#include <WiFi.h>
#include <HTTPClient.h>
#include <ArduinoJson.h>

// Configuration
#define API_HOST "http://192.168.10.26:5000" // The IP changes with the connection and the port is the one that visual studio display in the console when running the code
#define READS_FREQUENCY 60000 // 1 min = 60000 miliseconds
#define TRAY_ID "4"


// URL
String getUrl = String(API_HOST) + "/Tray/" + TRAY_ID + "/arduino" + "?token=" + TOKEN;

// Creating variables to store the tray settings data retrieved from database
int temperature = 0;
int humidity = 0;
int uvLight = 0;

// Data wire is connected to GPIO4
// The PIN 4 is used to temperature
#define ONE_WIRE_BUS 4

// Setup a oneWire instance
OneWire oneWire(ONE_WIRE_BUS);

DallasTemperature sensors(&oneWire);

// This function call the endpoint from the backend to fecth the tray settings from database
void fetchTraySettings() {
  // Send GET Request
  if (WiFi.status() == WL_CONNECTED) {
    Serial.println("✅ WiFi is connected, proceeding with HTTP GET");

    HTTPClient http;
    
    Serial.println("My url: ");
    Serial.println(getUrl);

    http.begin(getUrl);

    int httpResponseCode = http.GET();

    // Check if http response is not empty or with error
    if (httpResponseCode > 0) {
      String response = http.getString();
      Serial.println("GET Response:");
      Serial.println(response);

      // Parse JSON - 512 is the size to the dictionary
      StaticJsonDocument<512> doc;
      DeserializationError error = deserializeJson(doc, response);


      // If the data was fetched, we have here a dict 
      if (!error) {
        temperature = doc["temperatureCelsius"] | 0;
        humidity = doc["humidity"] | 0;
        uvLight = doc["dailySolarHours"] | 0;

        Serial.printf("Temperature: %d\n", temperature);
        Serial.printf("Humidity: %d\n", humidity);
        Serial.printf("Uv Light: %d\n", uvLight);
      }
      else {
        Serial.println("Failed to parse GET JSON");
      }
    }
    else {
      Serial.printf("GET Request failed, code: %d\n", httpResponseCode);
    }

    http.end();
  }
}


void setup() {
  // put your setup code here, to run once:
  pinMode(14, OUTPUT); // GPIO2 is often connected to onboard LED
  pinMode(2, OUTPUT); // This is the PIN to the UV LEDS
  pinMode(26, OUTPUT); // This is the PIN to the Water Pump
  Serial.begin(115200);
  delay(1000);
  sensors.begin();

  // Connect to WIFI
  WiFi.begin(WIFI_NAME, WIFI_PASSWORD);
  Serial.print("Connecting to WiFi");
  while (WiFi.status() != WL_CONNECTED){
    delay(500);
    Serial.print(".");
  }
  Serial.println("\nConnected to WiFi");
  Serial.println(WiFi.status()); // Should print 3 (WL_CONNECTED)

  fetchTraySettings();
}


void loop() {

  // Call the function that is conected to the sensor to reading the UV light
  readUV();

  // Call the function that is conected to the sensor to reading the humidity
  readHumidity();
  
  // Call the function that is conected to the sensor to reading the temperature
  readTemperature();
}

int interpretHumiditySetting() {
  if (humidity == 1) {
    return 2700;
  }
    
  if (humidity == 2) {
    return 2500;
  }
  
  if (humidity == 3) {
    return 2100;
  }

  return humidity;
}

// Function to the UV light sensor
void readUV() {
  // It is reading the UV sensor
  int rawValue = analogRead(32);  // Read raw analog value

  Serial.print("UV Analog value: ");
  Serial.print(rawValue);
  Serial.print(" | Voltage: ");
  Serial.println(" V");

  // It is to turn on or turn off the UV light
  if (rawValue == 0) {
    Serial.println("Turning ON UV Leds");
    digitalWrite(2, HIGH);
  }
  else {
    Serial.println("Turning OFF UV Leds");
    digitalWrite(2, LOW);
  }
}


// Function to the humidity sensor
void readHumidity() {
  // It it to read the humidity
  int humidityValue = analogRead(33);

  Serial.print("HU analog value: ");
  Serial.print(humidityValue);
  Serial.print(" | Voltage: ");
  Serial.println(" V");

  // Call the function to return the setting to humidity
  int humiditySetting = interpretHumiditySetting();

  // Turn on and turn off the water pump
  // Check if the current humidity reading is less than the setting humidity, if so, turn on the water pumps
  if (humidityValue < humiditySetting) {
    Serial.println("Turning ON Water Pump");
    digitalWrite(26, HIGH);
    delay(2000);
    Serial.println("Turning OFF Water Pump");
    digitalWrite(26, LOW);
  }
}

// Function to the temperature sensor
void readTemperature() {
  if (sensors.getDeviceCount() == 0) {
    Serial.println("No DS18B20 sensors found!");
  }
  else {
    Serial.print("Temperature: ");
    sensors.requestTemperatures(); // Send command to get temperatures
    delay(1000);
    float temperatureC = sensors.getTempCByIndex(0);
    Serial.println(temperatureC);
  }
}

