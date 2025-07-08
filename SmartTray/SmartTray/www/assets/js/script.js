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
    [0.00, "#000000"],
    [0.01, "#020202"],
    [0.02, "#050505"],
    [0.03, "#070707"],
    [0.04, "#0a0a0a"],
    [0.05, "#0c0c0c"],
    [0.06, "#0f0f0f"],
    [0.07, "#111111"],
    [0.08, "#141414"],
    [0.09, "#161616"],
    [0.10, "#191919"],
    [0.11, "#1b1b1b"],
    [0.12, "#1e1e1e"],
    [0.13, "#202020"],
    [0.14, "#232323"],
    [0.15, "#252525"],
    [0.16, "#282828"],
    [0.17, "#2a2a2a"],
    [0.18, "#2d2d2d"],
    [0.19, "#2f2f2f"],
    [0.20, "#323232"],
    [0.21, "#343434"],
    [0.22, "#373737"],
    [0.23, "#393939"],
    [0.24, "#3c3c3c"],
    [0.25, "#3e3e3e"],
    [0.26, "#414141"],
    [0.27, "#434343"],
    [0.28, "#464646"],
    [0.29, "#484848"],
    [0.30, "#4b4b4b"],
    [0.31, "#4d4d4d"],
    [0.32, "#505050"],
    [0.33, "#525252"],
    [0.34, "#555555"],
    [0.35, "#575757"],
    [0.36, "#5a5a5a"],
    [0.37, "#5c5c5c"],
    [0.38, "#5f5f5f"],
    [0.39, "#616161"],
    [0.40, "#646464"],
    [0.41, "#666666"],
    [0.42, "#696969"],
    [0.43, "#6b6b6b"],
    [0.44, "#6e6e6e"],
    [0.45, "#707070"],
    [0.46, "#737373"],
    [0.47, "#757575"],
    [0.48, "#787878"],
    [0.49, "#7a7a7a"],
    [0.50, "#7d7d7d"],
    [0.51, "#808080"],
    [0.52, "#828282"],
    [0.53, "#858585"],
    [0.54, "#878787"],
    [0.55, "#8a8a8a"],
    [0.56, "#8c8c8c"],
    [0.57, "#8f8f8f"],
    [0.58, "#919191"],
    [0.59, "#949494"],
    [0.60, "#969696"],
    [0.61, "#999999"],
    [0.62, "#9b9b9b"],
    [0.63, "#9e9e9e"],
    [0.64, "#a0a0a0"],
    [0.65, "#a3a3a3"],
    [0.66, "#a5a5a5"],
    [0.67, "#a8a8a8"],
    [0.68, "#aaaaaa"],
    [0.69, "#adadad"],
    [0.70, "#afafaf"],
    [0.71, "#b2b2b2"],
    [0.72, "#b4b4b4"],
    [0.73, "#b7b7b7"],
    [0.74, "#b9b9b9"],
    [0.75, "#bcbcbc"],
    [0.76, "#bebebe"],
    [0.77, "#c1c1c1"],
    [0.78, "#c3c3c3"],
    [0.79, "#c6c6c6"],
    [0.80, "#c8c8c8"],
    [0.81, "#cbcbcb"],
    [0.82, "#cdcdcd"],
    [0.83, "#d0d0d0"],
    [0.84, "#d2d2d2"],
    [0.85, "#d5d5d5"],
    [0.86, "#d7d7d7"],
    [0.87, "#dadada"],
    [0.88, "#dcdcdc"],
    [0.89, "#dfdfdf"],
    [0.90, "#e1e1e1"],
    [0.91, "#e4e4e4"],
    [0.92, "#e6e6e6"],
    [0.93, "#e9e9e9"],
    [0.94, "#ebebeb"],
    [0.95, "#eeeeee"],
    [0.96, "#f0f0f0"],
    [0.97, "#f3f3f3"],
    [0.98, "#f5f5f5"],
    [0.99, "#f8f8f8"],
    [1.00, "#ffffff"]
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
                            formatter: `{value} ${unit}`,
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
            const sunPoint = path.getPointAtLength(progress * pathLength);
            sun.style.left = sunPoint.x + 'px';
            sun.style.top = sunPoint.y + 'px';
            sun.style.transform = 'translate(-50%, -50%)';

            // Position sunrise icon and label
            const sunrisePoint = path.getPointAtLength(0.05 * pathLength);
            // Position the icon exactly on the orbit
            sunriseIcon.style.left = sunrisePoint.x + 'px';
            sunriseIcon.style.top = sunrisePoint.y + 'px';
            // Position the label outside the orbit
            sunriseMarker.style.left = (sunrisePoint.x + 30) + 'px';
            sunriseMarker.style.top = sunrisePoint.y + 'px';
            sunriseMarker.style.transform = 'translate(0, -50%)';

            // Position sunset icon and label
            const sunsetPoint = path.getPointAtLength(0.95 * pathLength);
            // Position the icon exactly on the orbit
            sunsetIcon.style.left = sunsetPoint.x + 'px';
            sunsetIcon.style.top = sunsetPoint.y + 'px';
            // Position the label outside the orbit
            sunsetMarker.style.left = (sunsetPoint.x - 30) + 'px';
            sunsetMarker.style.top = sunsetPoint.y + 'px';
            sunsetMarker.style.transform = 'translate(-100%, -50%)';

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

        } catch (error) {
            showToast("Unexpected error. Please try again.");
            console.error("Error", error);
        }
    }

    // Function to return a compreensivel target humidity to the user in the front end
    function interpretHumiditySettingsToUser(humidity){
        if (humidity === 0){
            return "Inactive";
        }
        if (humidity === 1) {
            return "Low 25% to 50%";
        }
        if (humidity === 2){
            return "Medium 50% to 75%";
        }
        if (humidity === 3){
            return "High 75% to 100%";
        }
    }

    // Formate date to dd/mm/yyyy hh:mm:ss
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

        fetchTray(trayId);

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
            let percentage = (3100 - data.humidity) / 10

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
            
            // Generate light gauge chart
            renderGauge(hours, "lightChart", lightingGradientStops, (data.targetLightMinutes/60), "h");
        } catch (error) {
            showToast("Unexpected error. Please try again.");
            console.error("Error", error);
        }
    }

    // Call the function to calculate light hours and generate light gauge chart
    getCalculationLightMinutes()

    function renderLargeTemperatureAreaChart(domId, timestamps, temperatures) {
        const chart = echarts.init(document.getElementById(domId));

        const option = {
            tooltip: {
                trigger: 'axis',
                position: function (pt) {
                    return [pt[0], '10%'];
                }
            },
            title: {
                left: 'center',
                text: 'Large Area Chart'
            },
            toolbox: {
                feature: {
                    dataZoom: {
                        yAxisIndex: 'none'
                    },
                    restore: {},
                    saveAsImage: {}
                }
            },
            xAxis: {
                type: 'category',
                boundaryGap: false,
                data: timestamps
            },
            yAxis: {
                type: 'value',
                boundaryGap: [0, '100%']
            },
            dataZoom: [
                {
                    type: 'inside',
                    start: 0,
                    end: 10
                },
                {
                    start: 0,
                    end: 10
                }
            ],
            series: [
                {
                    name: 'Temperature',
                    type: 'line',
                    symbol: 'none',
                    sampling: 'lttb',
                    itemStyle: {
                        color: 'rgb(255, 70, 131)'
                    },
                    areaStyle: {
                        color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [
                            {
                                offset: 0,
                                color: 'rgb(255, 158, 68)'
                            },
                            {
                                offset: 1,
                                color: 'rgb(255, 70, 131)'
                            }
                        ])
                    },
                    data: temperatures
                }
            ]
        };

        chart.setOption(option);
        window.addEventListener('resize', () => chart.resize());
    }
    
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

    // Function to testing chart 
    const timestamps = [];
    const temperatures = [];

    let currentTime = new Date('2025-07-08T00:00:00'); // fixed start time
    let currentTemp = 22 + Math.random() * 3;

    for (let i = 0; i < 1000; i++) {
        const hh = currentTime.getHours().toString().padStart(2, '0');
        const mm = currentTime.getMinutes().toString().padStart(2, '0');
        timestamps.push(`${hh}:${mm}`);

        const change = (Math.random() - 0.5) * 0.8;
        currentTemp += change;
        temperatures.push(parseFloat(currentTemp.toFixed(2)));

        currentTime = new Date(currentTime.getTime() + 5 * 60 * 1000); // advance by 5 minutes
    }


    // Call this once after your page loads or charts are initialized
    attachChartModalEvents({
        onChartClick: (chartId) => {
            // Optional: render a chart inside the modal
            if (chartId === 'temperatureChart') {
                renderLargeTemperatureAreaChart('modalChartContainer', timestamps, temperatures);
            } else if (chartId === 'lightChart') {
                renderLargeTemperatureAreaChart('modalChartContainer', ['10:00', '10:10'], [300, 320]);
            } else if (chartId === 'moistureChart') {
                renderLargeTemperatureAreaChart('modalChartContainer', ['10:00', '10:10'], [40, 38]);
            }
        }
    });


    
});