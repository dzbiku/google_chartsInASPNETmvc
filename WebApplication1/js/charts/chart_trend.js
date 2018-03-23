function FirstMetToGetData(chartTypeTrend) {
    $.ajax({
        url: '/Chart/GetChartDataTrend',
        data: "",
        dataType: "json",
        type: "GET",
        contentType: "application/json; chartset=utf-8",
        success: function (data) {
            chartData = data;
        },
        error: function () {
            alert("Error loading data! Please try again.");
        }
    }).done(function () {
        // after complete loading data
        google.setOnLoadCallback(function () { drawChart(chartTypeTrend); });
        drawChart(chartTypeTrend);
    });
}

$(document).ready(FirstMetToGetData('ColumnChart'));

function drawChart(chartTypeTrend) {
    var data = new google.visualization.DataTable();
    console.log('Si Sinior');
    data.addColumn('string', 'Date');
    data.addColumn('number', 'SBRK');
    data.addColumn('number', 'SLHIPA');
    data.addColumn('number', 'SLDHPA');
    data.addColumn('number', 'SOT');
    data.addColumn('number', 'SLT');

    for (var i = 0; i < chartData.length; i++) {
        data.addRow(chartData[i]);
    }

    var options = {
        title: "Trend Chart- SBRK, SLHiPA, SLDHPA, SOT and SLT",
        hAxis: { title: 'Date Time', titleTextStyle: { color: 'red' } },
        bar: { groupWidth: '50%' },
        isStacked: true
    };

    if (chartTypeTrend == 'LineChart') {
        chart = new google.visualization.LineChart(document.getElementById('chart_div'));
    }
    if (chartTypeTrend == 'ColumnChart') {
        chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
    }

    // Wait for the chart to finish drawing before calling the getImageURI() method.
    google.visualization.events.addListener(chart, 'ready', function () {
        document.getElementById('png').outerHTML = '<a href="' + chart.getImageURI() + '" download="trend' + Date.now() + '"><img border="0" src="/Imges/Wykres.png" alt="Download" width="71" height="51">Printable version</a>';
    });
    chart.draw(data, options);
}

setInterval(function () {
    FirstMetToGetData($("#myselect").val());
}, intervalTime);

$(document).ready(function () {
    $('#myselect').change(function () {
        console.log($("#myselect").val());
        FirstMetToGetData($("#myselect").val());
    });
});