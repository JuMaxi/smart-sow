

document.addEventListener('DOMContentLoaded', function () {
    renderGauge(23, "Temperature", "temperatureChart"); // Call with your desired value
    renderGauge(60, "Moisture", "moistureChart"); // Call with your desired value
    renderGauge(12, "Light", "lightChart"); // Call with your desired value

    // Function to generate gauge chart
    function renderGauge(value, text, id) {
        var chartDom = document.getElementById(id);
        if (chartDom) {
            var myChart = echarts.init(chartDom);
            var option = {
                title: {
                    text: text,
                    left: 'center',
                    top: 10,
                    textStyle: {
                        color: '#fff',
                        fontSize: 18
                    }
                },
                series: [
                    {
                        type: 'gauge',
                        startAngle: 200,
                        endAngle: -20,
                        min: 0,
                        max: 40,
                        splitNumber: 4,
                        axisLine: {
                            lineStyle: {
                                width: 6,
                                color: [
                                    [0.5, '#91cc75'],
                                    [0.75, '#fac858'],
                                    [1, '#ee6666']
                                ]
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
                            formatter: '{value} °C',
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
});