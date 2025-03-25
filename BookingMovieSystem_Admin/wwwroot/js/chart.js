window.drawLineChart = (elementId, chartData, chartOptions) => {
    var ctx = document.getElementById(elementId).getContext('2d');
    new Chart(ctx, {
        type: 'line',  // Đảm bảo đây là 'line' thay vì 'pie'
        data: chartData,
        options: chartOptions
    });
};
