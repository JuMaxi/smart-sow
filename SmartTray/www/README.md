# Smart Sow
[Click here to live link!](https://smartsow-d54bd7aaa207.herokuapp.com/index.html)

---
Smart Sow is an indoor seed germination assistant that uses IoT and web technologies to automate plant care. Each seedling tray is equipped with temperature, humidity, and UV light sensors. The system compares real-time readings to user-defined thresholds and automatically activates UV LEDs, watering pumps, or heating mats as needed.

> This project is ideal for tech-savvy gardening enthusiasts who want to combine sustainability, electronics, and automation.

---

![Homepage](./assets/images/readme/home-page.png)  
*Figure 1 – Home Page*

---

## Tech Stack

- **Backend**: C#, .NET, ASP.NET, Entity Framework
- **Frontend**: JavaScript, HTML, CSS, Bootstrap
- **Database**: PostgreSQL
- **Microcontroller**: ESP32 (C/C++ using Arduino IDE)
- **Deployment**: Heroku
- **Charts**: ECharts.js

---

## Key Features

- Secure user authentication with hashed and salted passwords
- Tray registration and configuration:
  - Humidity level (Low, Medium, High)
  - Temperature threshold (°C)
  - UV light hours
- Real-time sensor monitoring
- Automated control of:
  - UV LEDs
  - Water pump
  - Heating mat
- Sensor history tracking with charts
- Interactive gauge and bar charts
- Deactivation of trays when crops are transplanted
- Secure tray-token pairing between backend and ESP32

---

## Login Required

All features—tray registration, sensor monitoring, automation, and charts—require the user to be logged in. Without authentication, access to system features is restricted.

![Homepage-login](./assets/images/readme/home-page-login.png)  
*Figure 2 - Home page without login, see the button to login*

![login-page](./assets/images/readme/login.png)
*Figure 3 - login form*

Once logged in, users gain full access to all features, including tray registration, real-time monitoring, historical charts, and system configuration.

![Homepage-loggedIn](./assets/images/readme/user-menu.png)  
*Figure 3 - After logged in, user menu is displayed*

---

## Modal Charts

The modal charts provide the most insightful and up-to-date data in the entire application. They reflect the real-time environment inside each seedling tray by displaying detailed historical sensor readings.

When a user clicks on any gauge chart (e.g., temperature, humidity, or UV light), a stacked bar chart appears in a modal window. This chart shows:

- All recorded readings from the selected sensor
- Timestamps when automatic actions (e.g., heating mat, UV LEDs, or water pump) were triggered

For example, clicking the temperature gauge will open a modal showing a timeline of temperature readings for that tray, alongside the exact moments the heating mat was turned **on** (`10`) or **off** (`0`). Internally, these values are represented as `true` or `false` (1 or 0), but are scaled to `10` for better visibility within the stacked chart.

### Chart Scales and Data Normalization:

- **Temperature Chart**:
  - Max value: **40°C**
  - This default scale is suitable for cooler climates like the UK. In hotter regions, this value may need to be increased for accurate visualization.
  
- **Humidity and UV Light Charts**:
  - Max value: **100%**
  - Raw sensor readings are processed and translated into percentage values to make them more meaningful and intuitive for users.

- **Humidity**: Displayed:
  - Low: < 50%
  - Medium: < 75%
  - High: 100%

- **UV Light**: A daily exposure counter that resets at 7 AM by default to track artificial UV lighting. Users can customize the reset time in the Arduino code to better suit their needs.

### Gauge charts 
Display the most recent sensor readings — including temperature, humidity, and UV light — in a clear and intuitive format, giving users an instant snapshot of their tray's current conditions.

![gauge-charts](./assets/images/readme/display-tray.png)  
*Figure 4 - Last tray reading sensors, gauge charts and sun real position*

### Stacked bar charts 
Display the activation history of all automated components — including watering, heating, and UV LEDs — alongside sensor readings for a comprehensive overview of the tray’s environment.

![temperature-chart](./assets/images/readme/temperature-chart.png)  
*Figure 5 – Temperature historical stack bar chart*

![uv-light-chart](./assets/images/readme/uv-light-chart.png)  
*Figure 6 – Uv Light historical stack bar chart*
**Note:** During the days these readings were taken, there was no natural sunlight due to heavy cloud cover. As a result, the UV sensor readings remained at 0, while the UV LEDs were activated (value: 10) to compensate for the lack of sunlight.

![humidity-chart](./assets/images/readme/humidity-chart.png)  
*Figure 7 – Humidity historical stack bar chart*

---

## My Trays

- View real-time status and history
- Edit tray settings
- Deactivate trays when no longer needed

![My Trays Page](./assets/images/readme/my-trays.png)  
*Figure 3 – Tray Management Page*

---

## User Flow

**Register Account**  
Name, email, postcode, password (hashed + salted)  
   ![create-account](./assets/images/readme/create-account.png)

**Edit Account**
Name, email, postcode. 
(Password future implementation) 
   ![edit-account](./assets/images/readme/edit-account.png)

**Register Tray**  
Tray name, crop type, sowing date, thresholds  
![register-tray](./assets/images/readme/register-tray.png)

**Edit Tray**  
Tray name, crop type, sowing date, thresholds  
![edit-tray](./assets/images/readme/edit-tray.png)

**Configure ESP32**  
Copy tray token and upload Arduino code  
![My Trays](./assets/images/readme/my-trays.png)

**Monitor Trays**  
Real-time readings and automation

**View Charts**  
Historical data and sensor trends
[See charts details here](#modal-charts)

**Logout**
Displayed in the user menu, when logged in.
[See login requirements and details here → login-required](#login-required)


## Materials Required

- Seedling tray, seeds, and soil
- ESP32 microcontroller
- Temperature sensor
- Humidity sensor
- UV light sensor
- Water pump + tubing + water container
- UV LEDs
- Heating mat (use with a relay and handle 230V safely)
- Relay module
- Breadboard or soldered circuit
- USB power supply or power bank
- Jumper wires

See [electronics.md](./electronics.md) for detailed specs and wiring diagrams.

---

## Setup & Installation Guide

### 1. Prerequisites

Install the following:

- [.NET 8+ SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Git](https://git-scm.com/)

---

### 2. Clone the Repository

```bash
git clone https://github.com/your-username/smart-sow.git
cd smart-sow
```

---

### 3. Backend Setup (.NET API)

1. Open `appsettings.json`
2. Set your PostgreSQL connection string

Then:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

---

### 4. Frontend Setup

- The frontend is static (HTML, CSS, JS, Bootstrap)
- Served directly by the ASP.NET backend — no build step needed

---

## ESP32 Configuration

[See detailed electronics setup & wiring instructions here → electronics.md](electronics.md)
---

---

## Future Improvements

- Unit tests and input validation for backend
- Features for users:
  - Change password
  - Delete account
- Sunlight estimation via postcode APIs

---

## Important Notes

- This is a **prototype**, not a commercial product
- Handle 230V appliances (heating mats) with **extreme caution**
- Designed for users with basic programming and electronics experience

---

## UI Preview


---

## License



---

## Author

Developed with love by a passionate gardener and developer who believes in combining sustainability with smart tech.