document.addEventListener('DOMContentLoaded', function () {

    // Temperature chart gradient 50 colors
    const temperatureGradientStops = [
        [0.00, "#FFFFE0"],
        [0.02, "#FFF9D4"],
        [0.04, "#FFF3C8"],
        [0.06, "#FFEDBC"],
        [0.08, "#FFE7B0"],
        [0.10, "#FFE1A4"],
        [0.12, "#FFDB98"],
        [0.14, "#FFD58C"],
        [0.16, "#FFCF80"],
        [0.18, "#FFC974"],
        [0.20, "#FFC368"],
        [0.22, "#FFBD5C"], 
        [0.24, "#FFB750"], 
        [0.26, "#FFB144"], 
        [0.28, "#FFAB38"],
        [0.30, "#FFA52C"], 
        [0.32, "#FF9F20"], 
        [0.34, "#FF9914"], 
        [0.36, "#FF9308"], 
        [0.38, "#FF8D00"],
        [0.40, "#FF8700"], 
        [0.42, "#FF8100"], 
        [0.44, "#FF7B00"], 
        [0.46, "#FF7500"], 
        [0.48, "#FF6F00"],
        [0.50, "#FF6900"], 
        [0.52, "#FF6300"], 
        [0.54, "#FF5D00"], 
        [0.56, "#FF5700"], 
        [0.58, "#FF5100"],
        [0.60, "#FF4B00"], 
        [0.62, "#FF4500"], 
        [0.64, "#FF3F00"], 
        [0.66, "#FF3900"], 
        [0.68, "#FF3300"],
        [0.70, "#F52D00"], 
        [0.72, "#EB2700"], 
        [0.74, "#E12100"], 
        [0.76, "#D71B00"], 
        [0.78, "#CD1500"],
        [0.80, "#C30F00"], 
        [0.82, "#B90900"], 
        [0.84, "#AF0300"], 
        [0.86, "#A50000"],
        [0.88, "#8B0000"],
        [0.90, "#9B0000"],
        [0.92, "#910000"], 
        [0.94, "#870000"], 
        [0.96, "#7D0000"], 
        [0.98, "#730000"], 
        [1.00, "#690000"]
    ];

    // Lighting chart gradient 100 colors
    const lightingGradientStops = [
        [0.00, "#ffccff"], [0.01, "#ffcafe"], [0.02, "#ffc6fc"], [0.03, "#ffc4fb"], [0.04, "#ffc0f9"],
        [0.05, "#ffbef8"], [0.06, "#ffbaf6"], [0.07, "#ffb6f4"], [0.08, "#ffb4f3"], [0.09, "#ffb0f1"],
        [0.10, "#ffaef0"], [0.11, "#ffaaee"], [0.12, "#ffa7ec"], [0.13, "#ffa4eb"], [0.14, "#ffa1e9"],
        [0.15, "#ff9ee8"], [0.16, "#ff9be6"], [0.17, "#ff98e5"], [0.18, "#ff95e3"], [0.19, "#ff91e2"],
        [0.20, "#ff8fe0"], [0.21, "#ff8bdf"], [0.22, "#ff89dd"], [0.23, "#ff85dc"], [0.24, "#ff82da"],
        [0.25, "#ff7fd9"], [0.26, "#ff7cd7"], [0.27, "#ff79d6"], [0.28, "#ff76d4"], [0.29, "#ff73d3"],
        [0.30, "#ff70d1"], [0.31, "#ff6ccf"], [0.32, "#ff6ace"], [0.33, "#ff66cc"], [0.34, "#fc64cd"],
        [0.35, "#f860cf"], [0.36, "#f35cd1"], [0.37, "#f05ad2"], [0.38, "#ec56d4"], [0.39, "#e854d5"],
        [0.40, "#e450d7"], [0.41, "#e04dd9"], [0.42, "#dc4ada"], [0.43, "#d847dc"], [0.44, "#d544dd"],
        [0.45, "#d041df"], [0.46, "#ce3ee0"], [0.47, "#c93be2"], [0.48, "#c437e3"], [0.49, "#c235e5"],
        [0.51, "#bd31e6"], [0.52, "#ba2fe8"], [0.53, "#b62be9"], [0.54, "#b128eb"], [0.55, "#ae25ec"],
        [0.56, "#aa22ee"], [0.57, "#a61fef"], [0.58, "#a21cf1"], [0.59, "#9f19f2"], [0.60, "#9b16f4"],
        [0.61, "#9612f6"], [0.62, "#9310f7"], [0.63, "#8e0cf9"], [0.64, "#8c0afa"], [0.65, "#8706fc"],
        [0.66, "#8202fe"], [0.67, "#8000ff"], [0.68, "#7d00fa"], [0.69, "#7b00f7"], [0.70, "#7900f2"],
        [0.71, "#7700ee"], [0.72, "#7500ea"], [0.73, "#7300e6"], [0.74, "#7100e2"], [0.75, "#6e00de"],
        [0.76, "#6d00da"], [0.77, "#6a00d6"], [0.78, "#6800d1"], [0.79, "#6600ce"], [0.80, "#6400c9"],
        [0.81, "#6200c6"], [0.82, "#6000c1"], [0.83, "#5d00bc"], [0.84, "#5c00b9"], [0.85, "#5900b4"],
        [0.86, "#5800b1"], [0.87, "#5500ac"], [0.88, "#5400a9"], [0.89, "#5100a4"], [0.90, "#4f00a0"],
        [0.91, "#4d009c"], [0.92, "#4b0098"], [0.93, "#490094"], [0.94, "#470090"], [0.95, "#44008b"],
        [0.96, "#430088"], [0.97, "#400083"], [0.98, "#3f0080"], [0.99, "#3c007b"], [1.00, "#3b0078"]
    ];

    // Moisture chart gradient 50 colors
    const blueGradientStops = [
        [0.00, "#cceeff"],
        [0.02, "#c1defc"],
        [0.04, "#b6cff9"],
        [0.06, "#abdff7"],
        [0.08, "#a0d1f4"],
        [0.10, "#95c2f2"],
        [0.12, "#8ac3ef"],
        [0.14, "#7fc4ec"],
        [0.16, "#74b6e9"],
        [0.18, "#69a7e7"],
        [0.20, "#5e99e4"],
        [0.22, "#538add"],
        [0.24, "#4a7cdb"],
        [0.26, "#416ddb"],
        [0.28, "#386fdd"],
        [0.30, "#2f6fe1"],
        [0.32, "#276ddf"],
        [0.34, "#2166dc"],
        [0.36, "#1c60d9"],
        [0.38, "#1759d6"],
        [0.40, "#1351d1"],
        [0.42, "#104acb"],
        [0.44, "#0f43c4"],
        [0.46, "#0e3dbe"],
        [0.48, "#0e37b9"],
        [0.50, "#0d32b3"],
        [0.52, "#0c2ea8"],
        [0.54, "#0b299d"],
        [0.56, "#0b2592"],
        [0.58, "#0a2387"],
        [0.60, "#0a217c"],
        [0.62, "#091f72"],
        [0.64, "#081c68"],
        [0.66, "#081a5f"],
        [0.68, "#071856"],
        [0.70, "#06164d"],
        [0.72, "#061345"],
        [0.74, "#05103c"],
        [0.76, "#040f34"],
        [0.78, "#040c2c"],
        [0.80, "#030b25"],
        [0.82, "#02091d"],
        [0.84, "#020715"],
        [0.86, "#01050e"],
        [0.88, "#010406"],
        [0.90, "#000300"],
        [0.92, "#000200"],
        [0.94, "#000100"],
        [0.96, "#000000"],
        [0.98, "#000000"],
        [1.00, "#000033"]
    ];

    // Function to generate gauge chart
    function renderGauge(value, id, colors, max, unit) {
        var chartDom = document.getElementById(id);
        if (chartDom) {
            var myChart = echarts.init(chartDom);
            var option = {
                title: {
                    show: false,
                },
                series: [
                    {
                        type: 'gauge',
                        radius: '80%',
                        center: ['50%', '60%'],
                        startAngle: 224,
                        endAngle: -44,
                        min: 0,
                        max: max,
                        splitNumber: 4,
                        axisLine: {
                            lineStyle: {
                                width: 6,
                                color: colors
                            }
                        },
                        pointer: {
                            itemStyle: {
                                color: '#fff'
                            }
                        },
                        axisTick: {
                            distance: -15,
                            length: 4,
                            lineStyle: {
                                color: '#fff',
                                width: 1
                            }
                        },
                        splitLine: {
                            distance: -20,
                            length: 8,
                            lineStyle: {
                                color: '#fff',
                                width: 2
                            }
                        },
                        axisLabel: {
                            color: '#fff',
                            distance: -12,
                            fontSize: 9
                        },
                        detail: {
                            valueAnimation: true,
                            formatter: `{value}${unit}`,
                            color: '#fff',
                            fontSize: 20,
                        },
                        data: [
                            {
                                value: value // Use function parameter
                            }
                        ]
                    }
                ]
            };
            myChart.setOption(option);
            window.addEventListener('resize', function () {
                myChart.resize();
            });
        }
    }

    // Function to create the orbit and position it around the image tray
    async function setupOrbitAndTray() {
        const container = document.getElementById('container');
        const svg = document.getElementById('orbitSVG');
        const path = document.getElementById('orbitPath');
        
        // Get the actual container dimensions (CSS handles the sizing)
        const containerRect = container.getBoundingClientRect();
        const containerSize = containerRect.width; // Use width since it's square
        
        // Set SVG size to match container
        svg.setAttribute('width', containerSize);
        svg.setAttribute('height', containerSize);

        // Arc calculations for orbit around tray, starting from right border
        const arcStartX = containerSize * 0.85; // Start at right border
        const arcStartY = containerSize * 0.25; // Adjusted start height
        const arcEndX = containerSize * 0.25; // End at left side of tray
        const arcEndY = containerSize * 0.75; // End lower for visual balance
        
        // Calculate control points for a more natural curve
        const rx = containerSize * 0.3; // Adjusted for tighter curve
        const ry = containerSize * 0.3; // Adjusted for visual balance

        
        // Create the path with a more natural curve
        const d = `M ${arcStartX} ${arcStartY} A ${rx} ${ry} 0 0 0 ${arcEndX} ${arcEndY}`;
        path.setAttribute('d', d);
        
        // Set responsive stroke width
        const strokeWidth = Math.max(2, Math.min(6, containerSize / 150));
        path.setAttribute('stroke-width', strokeWidth);

        return path; // needed for sun animation
    }

    // Function to get the exact sun position from a public API and calculate its relative position in the orbit
    async function positionSunFromTime(path) {
        const sun = document.getElementById('sun');
        const sunriseIcon = document.getElementById('sunriseIcon');
        const sunsetIcon = document.getElementById('sunsetIcon');
        const sunriseMarker = document.getElementById('sunriseMarker');
        const sunsetMarker = document.getElementById('sunsetMarker');
        const sunriseLabel = document.getElementById('sunriseTime');
        const sunsetLabel = document.getElementById('sunsetTime');

        const lat = 51.5074; // London
        const lng = -0.1278;

        try {
            const res = await fetch(`https://api.sunrise-sunset.org/json?lat=${lat}&lng=${lng}&formatted=0`);
            const data = await res.json();

            const sunrise = new Date(data.results.sunrise);
            const sunset = new Date(data.results.sunset);
            const now = new Date();

            // Convert to local time
            const toLocalTime = (utcDate) => {
                const local = new Date(utcDate);
                return local.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit', hour12: true });
            };

            sunriseLabel.textContent = toLocalTime(sunrise);
            sunsetLabel.textContent = toLocalTime(sunset);

            // Calculate sun position based on current time between sunrise and sunset
            let progress = (now - sunrise) / (sunset - sunrise);
            progress = Math.max(0, Math.min(1, progress)); // Clamp between 0 and 1

            const pathLength = path.getTotalLength();
            
            // Position sun exactly on the orbit path
            const sunPoint = path.getPointAtLength((1 - progress) * pathLength);
            sun.style.left = sunPoint.x + 'px';
            sun.style.top = sunPoint.y + 'px';
            sun.style.transform = 'translate(-50%, -50%)';

            // Position sunrise icon and label (bottom left of arc)
            const sunrisePoint = path.getPointAtLength(path.getTotalLength());
            sunriseIcon.style.left = sunrisePoint.x + 'px';
            sunriseIcon.style.top = sunrisePoint.y + 'px';
            sunriseMarker.style.left = (sunrisePoint.x - 30) + 'px'; 
            sunriseMarker.style.top = sunrisePoint.y + 'px';
            sunriseMarker.style.transform = 'translate(-100%, -50%)';

            // Position sunset icon and label (top right of arc)
            const sunsetPoint = path.getPointAtLength(0);
            sunsetIcon.style.left = sunsetPoint.x + 'px';
            sunsetIcon.style.top = sunsetPoint.y + 'px';
            sunsetMarker.style.left = (sunsetPoint.x + 30) + 'px';
            sunsetMarker.style.top = sunsetPoint.y + 'px';
            sunsetMarker.style.transform = 'translate(0, -50%)';

        } catch (error) {
            console.error('Failed to get sun position:', error);
        }
    }

    // Function to force recalculation of orbit and tray
    async function recalculateOrbit() {
        console.log('Forcing recalculation...');
        const path = await setupOrbitAndTray();
        positionSunFromTime(path);
    }

    window.onload = async () => {
        // Small delay to ensure container is properly rendered
        setTimeout(async () => {
            const path = await setupOrbitAndTray();  // Wait for the async function

            // Immediately position the sun
            positionSunFromTime(path);
        }, 100);
        
        // Add resize listener for responsiveness
        let resizeTimeout;
        window.addEventListener('resize', () => {
            clearTimeout(resizeTimeout);
            resizeTimeout = setTimeout(async () => {
                console.log('Window resized, recalculating...');
                // Force a reflow to ensure CSS has updated
                const container = document.getElementById('container');
                container.offsetHeight; // Force reflow
                const newPath = await setupOrbitAndTray();
                positionSunFromTime(newPath);
            }, 150); // Slightly longer debounce for CSS to update
        });
        
        // Also handle orientation change for mobile devices
        window.addEventListener('orientationchange', () => {
            setTimeout(async () => {
                console.log('Orientation changed, recalculating...');
                const newPath = await setupOrbitAndTray();
                positionSunFromTime(newPath);
            }, 500); // Longer delay for orientation change
        });
        
        // Force recalculation after a longer delay to handle any layout issues
        setTimeout(async () => {
            await recalculateOrbit();
        }, 1000);
    };

    async function fetchTray(trayId){
        try {
            // Using the path (query string) to my endpoint get
            const response = await fetch(`/Tray/${trayId}`, {
                method: "GET",
            });

            if (!response.ok) {
                showToast(await response.text());
                return;
            }

            // The tray fecthed from database
            const data = await response.json();
            return data;
        } catch (error) {
            showToast("Unexpected error. Please try again.");
            console.error("Error", error);
        }
    }

    async function writeLastReadingAndSettingsHeaders(){
        const params = new URLSearchParams(window.location.search);
        const trayId = params.get('id'); // 'id' is the parameter name in the URL

        // Fetch the tray data to use it below
        const data = await fetchTray(trayId);

        // Insert name tray and crop type to the frontend (above the charts)    
            document.getElementById("trayName").textContent = `${data.name}`;
            document.getElementById("cropType").innerHTML = 
                `<i class="fa-brands fa-pagelines" style="color: #1a2e05;"></i>
                ${data.cropType}`;

            // Display temperature target in the front end (below the chart)
            document.getElementById("targetTemperature").innerHTML = 
                `<i class="fa-solid fa-temperature-three-quarters" style="color: #e70d0d;"></i>
                Target: ${data.settings.temperatureCelsius}°C`;
            
            // Display light target in the front end (below the chart)
            document.getElementById("targetLight").innerHTML =
                `<i class="fa-solid fa-sun" style="color: #FFD43B;"></i>
                Target: ${data.settings.dailySolarHours}h`;

            // Display humidity target in the front end (below the chart)

            let humidity = interpretHumiditySettingsToUser(data.settings.humidity);
            document.getElementById("targetHumidity").innerHTML = 
                `<i class="fa-solid fa-droplet" style="color: #74C0FC;"></i>
                Target: ${humidity}`;
    }

    // Call the function to display tray headers and settings
    writeLastReadingAndSettingsHeaders();

    // Function to return a compreensivel target humidity to the user in the front end
    function interpretHumiditySettingsToUser(humidity){
        if (humidity === 0){
            return "Inactive";
        }
        if (humidity === 1) {
            return "Low 25%";
        }
        if (humidity === 2){
            return "Medium 50%";
        }
        if (humidity === 3){
            return "High 75%";
        }
    }

    // Format date to dd/mm/yyyy hh:mm:ss
    function formatDate(date){
        const dateObj = new Date(date);
        const formattedDate = dateObj.toLocaleString('en-GB', {
            day: '2-digit',
            month: '2-digit',
            year: 'numeric',
            hour: '2-digit',
            minute: '2-digit',
            second: '2-digit',
            hour12: false
        });

        return formattedDate;
    }

    // Fetch last readings data and display into chart gauges
    async function fetchLatest() {
        // Get id from query string
        const params = new URLSearchParams(window.location.search);
        const trayId = params.get('id'); // 'id' is the parameter name in the URL

        if (!trayId) {
            showToast("Tray ID not found in URL.");
            return;
        }

        try {
            // Using the path (query string) to my endpoint get
            const response = await fetch(`/TraySensorReading/${trayId}/latest`, {
                method: "GET",
            });

            if (!response.ok) {
                showToast(await response.text());
                return;
            }
            
            // The latest sensor readings fecthed from database
            const data = await response.json();

            // Call function to format data to dd/mm/yyyy hh:mm:ss
            let date = formatDate(data.date);

            // Insert date last reading to the frontend (above charts)
            document.getElementById("lastReading").innerHTML = 
                `<i class="fa-solid fa-clock" style="color: #301b03;"></i>
                Last reading: ${date}`;

            // Call function to generate temperature chart
            renderGauge(data.temperature, "temperatureChart", temperatureGradientStops, 40, "°C"); 

            // 3100 is the max reading the sensor reads - it means dry, no humidity
            let percentage = (3100 - data.humidity) / 10;
            percentage = percentage > 100 ? 100 : percentage; // Clamp to 100 if it exceeds 100
            percentage = (percentage <= 0 || data.humidity === 0) ? 0 : percentage;

            // Call function to generate moisture chart
            renderGauge(percentage, "moistureChart", blueGradientStops, 100, "%"); 

        } catch (error) {
            showToast("Unexpected error. Please try again.");
            console.error("Error", error);
        }
    }

    fetchLatest();

    // Function to get calculation hours light and call the function to generate light gauge chart
    async function getCalculationLightMinutes(){
        const params = new URLSearchParams(window.location.search);
        const trayId = params.get('id'); // 'id' is the parameter name in the URL

        try {
            const response = await fetch(`/TraySensorReading/${trayId}/daily-uv-time`, {
                method: "GET",
            });

            if (!response.ok) {
                showToast(await response.text());
                return;
            }
            
            const data = await response.json();
            // Fill the form fields with the data

            // Converting minutes to hours
            hours = Math.floor(data.dailyLightMinutes / 60) + (data.dailyLightMinutes % 60) / 100;
            unit = "h"

            // Calling the function to fetch tray data to use the settings to the daily solar hours
            const dataTray = await fetchTray(trayId);

            max = dataTray.settings.dailySolarHours;

            // In case daily uv light still be less than one hour, display it in minutes
            if (hours < 1 && hours !== 0){
                hours *= 100;
                unit = "m";
                max = (data.dailyLightMinutes + data.remainingLightMinutes);
            }
            else {
                // In case it is a new tray, without readings, display only the target setting to the gauge
                if (hours === 0){
                    max = dataTray.settings.dailySolarHours;
                }
            }
            
            // Generate light gauge chart
            renderGauge(hours, "lightChart", lightingGradientStops, max, unit);
        } catch (error) {
            showToast("Unexpected error. Please try again.");
            console.error("Error", error);
        }
    }

    // Call the function to calculate light hours and generate light gauge chart
    getCalculationLightMinutes()

    // This function sets up click events for your three gauge charts (temperatureChart, lightChart, moistureChart).
    function attachChartModalEvents(config = {}) {
        const chartIds = ['temperatureChart', 'lightChart', 'moistureChart'];

        chartIds.forEach(id => {
            const chartDiv = document.getElementById(id);
            if (chartDiv) {
                chartDiv.addEventListener('click', () => {
                    // Determine modal title
                    const labelMap = {
                        'temperatureChart': 'Temperature Details',
                        'lightChart': 'Light Details',
                        'moistureChart': 'Moisture Details'
                    };

                    const modalTitle = labelMap[id] || 'Chart Details';
                    document.getElementById('chartModalLabel').textContent = modalTitle;

                    // Optional callback: dynamically update modal chart
                    if (typeof config.onChartClick === 'function') {
                        config.onChartClick(id);
                    }

                    // Show the modal
                    const modal = new bootstrap.Modal(document.getElementById('chartModal'));
                    modal.show();
                });
            }
        });
    }

    // This function is calling the endpoint from the backend to fetch all sensor readings to the tray selected
    async function fetchTraySensorReadings(){
        // Get id from query string
        const params = new URLSearchParams(window.location.search);
        const trayId = params.get('id'); // 'id' is the parameter name in the URL

        try {
            // Using the path (query string) to my endpoint get
            const response = await fetch(`/TraySensorReading/${trayId}`, {
                method: "GET",
            });

            if (!response.ok) {
                showToast(await response.text());
                return;
            }

            // The tray fecthed from database
            const data = await response.json();

            const timestamps = data.map(d => formatDate(d.date));
            const readings = {
                temperature: {
                    heatingMatOn: data.map(d => d.heatingMatOn ? 10 : 0),
                    celsiusReading: data.map(d => d.temperature)
                },
                humidity: {
                    watterAdded: data.map(d => d.waterAdded ? 10 : 0),
                    humidityReading: data.map(d => {
                        let p = (3100 - d.humidity) / 10;
                        p = p > 100 ? 100 : p; // Clamp p to 100 if it exceeds 100
                        return (p <= 0 || d.humidity === 0) ? 0 : p;
                    })                 
                },
                uv: {
                    uVLedsOn: data.map(d => d.uVLedsOn ? 10 : 0),
                    uvReading: data.map(d => d.uvReading)
                }
            };

            // Call this once after your page loads or charts are initialized
            attachChartModalEvents({
                onChartClick: (chartId) => {
                    // Render a chart inside the modal
                    if (chartId === 'temperatureChart') {
                        generateChartOptionsFromSensorData(readings, "temperature", timestamps);
                    } else if (chartId === 'lightChart') {
                        generateChartOptionsFromSensorData(readings, "uv", timestamps);
                    } else if (chartId === 'moistureChart') {
                        generateChartOptionsFromSensorData(readings, "humidity", timestamps);
                    }
                }
            });

        } catch (error) {
            showToast("Unexpected error. Please try again.");
            console.error("Error", error);
        }
    }
    fetchTraySensorReadings();

    // Function to generate charts that will be displayed in the modal
    function generateChartOptionsFromSensorData(data, sensorType, timeStamps) {

        const chartDom = document.getElementById("modalChartContainer");
        if (!chartDom) return;

        // Dispose previous chart instance if exists
        if (echarts.getInstanceByDom(chartDom)) {
            echarts.getInstanceByDom(chartDom).dispose();
        }
        const chart = echarts.init(chartDom);

        // Get the sensor data for the selected type
        const sensorData = data[sensorType];
        const legends = Object.keys(sensorData); // e.g., ['celsiusReading', 'heatingMatOn']

        // The custom colors to the charts
        const colorMap = {
            celsiusReading: "#ff4683ff",
            heatingMatOn: "#ff9e44ff",
            humidityReading: "#3fc3dd",
            watterAdded: "#a8e9f0",
            uvReading: "#7F00FF",
            uVLedsOn: "#B026FF"
        };
        // Build the series array as required by ECharts
        const series = legends.map(key => ({
            name: key,
            type: 'line',
            stack: 'Total',
            areaStyle: {},
            emphasis: { focus: 'series' },
            data: sensorData[key],
            itemStyle: { color: colorMap[key] }
        }));

        const option = {
            tooltip: {
                trigger: 'axis',
                axisPointer: {
                    type: 'cross',
                    label: {
                        backgroundColor: '#6a7985'
                    }
                }
            },
            legend: {
                data: legends
            },
            toolbox: {
                feature: {
                    saveAsImage: {}
                }
            },
            grid: {
                left: '3%',
                right: '4%',
                bottom: 70,
                containLabel: true
            },
            dataZoom: [
                {
                    type: 'slider',
                    show: true,
                    xAxisIndex: 0,
                    start: 0,
                    end: 100
                },
                {
                    type: 'inside',
                    xAxisIndex: 0,
                    start: 0,
                    end: 100
                }
            ],
            xAxis: [
                {
                    type: 'category',
                    boundaryGap: false,
                    data: timeStamps
                }
            ],
            yAxis: [
                {
                    type: 'value'
                }
            ],
            series
        };

        chart.setOption(option);
        window.addEventListener('resize', () => chart.resize());
    }

});