#include <OneWire.h>
#include <DallasTemperature.h>
#include "secrets.h"
#include <WiFi.h>
#include <HTTPClient.h>
#include <ArduinoJson.h>

// Configuration
#define API_HOST "https://smartsow-d54bd7aaa207.herokuapp.com" // This is the heroku deployed link
#define READS_FREQUENCY 60000 // 1 min = 60000 miliseconds
#define TRAY_ID "1"


// URL
String getUrl = String(API_HOST) + "/Tray/" + TRAY_ID + "/arduino" + "?token=" + TOKEN;
String postUrl = String(API_HOST) + "/TraySensorReading/" + TRAY_ID + "/arduino" + "?token=" + TOKEN;

// Creating variables to store the tray settings data retrieved from database
int temperature = 0;
int humidity = 0;
int uvLight = 0;
int remainingUvLight = 0;
int currentHour = 0; // This variable is used to verify if it is time to start checking UV light. 

// Variables to sensor readings (http post)
float temperatureReading = 0;
bool heatingMatOn = false;
int humidityReading = 0;
bool waterAdded = false;
int uvReading = 0;
bool uvLedsOn = false;

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
}


// This function call the endpoint from the backend to fecth the tray settings from database
void fetchTraySettings() {
  // Send GET Request
  if (WiFi.status() == WL_CONNECTED) {
    Serial.println("WiFi is connected, proceeding with HTTP GET");

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

        Serial.printf("My settings: ");
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

// This function call the endpoint from the backend to store tray sensor readings to the database
void storeSensorReadingsToDataBase() {
  if (WiFi.status() == WL_CONNECTED) {
    HTTPClient http;
    http.begin(postUrl);
    http.addHeader("Content-Type", "application/json");

    // Build JSON Payload
    StaticJsonDocument<512> postDoc;
    postDoc["temperature"] = temperatureReading;
    postDoc["humidity"] = humidityReading;
    postDoc["uvReading"] = uvReading;
    postDoc["waterAdded"] = waterAdded;
    postDoc["uvLedsOn"] = uvLedsOn;
    postDoc["heatingMatOn"] = heatingMatOn;

    String jsonString;
    serializeJson(postDoc, jsonString);
    Serial.println(jsonString);

    int httpResponseCode = http.POST(jsonString);
    if (httpResponseCode > 0) {
      String response = http.getString();
      Serial.println("POST Response:");
      Serial.println(response);
    } else {
      Serial.printf("POST Request failed, code: %d\n", httpResponseCode);
    }

    http.end();
  }
}

// In this loop the functions to read sensors are called and it is compared with the user tray settings to turn on or off water, leds, heatings
// A function to fetch tray settings (http get) is called
// A function to store sensor readings (http post) is called
void loop() {
  // Call the function to get user tray settings from database (http get)
  fetchTraySettings();

  // Check if it is equal or more than 7am. If so, start checking the Uv light.
  if (currentHour >= 7) {
    // Call the function that is conected to the sensor to reading the UV light
      readUV();
  }

  // Call the function that is conected to the sensor to reading the humidity
  readHumidity();

  // Call the function that is conected to the sensor to reading the temperature
  readTemperature();

  // Call the function to store the sensors readings into the database
  storeSensorReadingsToDataBase();

  delay(READS_FREQUENCY);
}

// Function to the UV light sensor
void readUV() {
  // It is reading the UV sensor
  uvReading = analogRead(32);  // Read raw analog value

  Serial.print("UV Analog value: ");
  Serial.print(uvReading);

  // It is to turn on or turn off the UV light
  if (uvReading == 0 && remainingUvLight > 0) {
    Serial.println("Turning ON UV Leds");
    digitalWrite(2, HIGH);
    uvLedsOn = true;
  }
  else {
    Serial.println("Turning OFF UV Leds");
    digitalWrite(2, LOW);
    uvLedsOn = false;
  }
}

// Function to the humidity sensor
void readHumidity() {
  // It it to read the humidity
  humidityReading = analogRead(33);

  Serial.println("Humidity analog value: ");
  Serial.println(humidityReading);

  // Turn on and turn off the water pump
  // Check if the current humidity reading is less than the setting humidity, if so, turn on the water pumps
  if (humidityReading < humidity) {
    Serial.println("Turning ON Water Pump");
    digitalWrite(26, HIGH);
    delay(2000);
    Serial.println("Turning OFF Water Pump");
    digitalWrite(26, LOW);
    waterAdded = true;
  } else {
    waterAdded = false;
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
    temperatureReading = sensors.getTempCByIndex(0);
    Serial.println(temperatureReading);

    // Check if the current temperature read is less than the target temperature. If so, turn on the heating mat
    if (temperatureReading < temperature){
      Serial.println("Turning ON Heating Mat");
      digitalWrite(17, HIGH);
      heatingMatOn = true;
    } else {
      Serial.println("Turning OFF Heating Mat");
      digitalWrite(17, LOW);
      heatingMatOn = false;
    }
  }

  
}

