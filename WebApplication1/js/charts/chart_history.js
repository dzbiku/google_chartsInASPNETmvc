function FirstMetToGetDataHistory(chartType) {
    $.ajax({
        url: '/Chart/GetChartDataHistory',
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
        google.setOnLoadCallback(function () { drawChart(chartType); });
        drawChart(chartType);
    });
}
//
function drawChart(chartType) {
    var data = new google.visualization.DataTable();

    data.addColumn('string', 'Date');
    data.addColumn('number', 'Pośrednio Produkcyjne');
    data.addColumn('number', 'Bezpośrednio Produkcyjne');

    for (var i = 0; i < chartData.length; i++) {
        data.addRow(chartData[i]);
    }

    var options = {
        title: "History date- must be defined date and other params",
        //pointSize: 5,
        hAxis: { title: 'Date Time', titleTextStyle: { color: 'red' } },
        bar: { groupWidth: '50%' },
        isStacked: true,
        trendlines: {
            0: {
                color: 'purple',
                lineWidth: 10,
                opacity: 0.2,
                type: 'exponential'
            }
        },
        pieHole: 0.4
    };
    //ColumnChart
    if (chartType == 'LineChart') {
        chart= new google.visualization.LineChart(document.getElementById('chart_div'));
    }
    if (chartType == 'ColumnChart') {
        chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
    }

    // Wait for the chart to finish drawing before calling the getImageURI() method.
    google.visualization.events.addListener(chart, 'ready', function () {
        document.getElementById('png').outerHTML = '<a href="' + chart.getImageURI() + '" download="history' + Date.now() + '"><img border="0" src="/Imges/Wykres.png" alt="Download" width="71" height="51">Printable version</a>';
    });

    chart.draw(data, options);
}
//

$(document).ready(FirstMetToGetDataHistory('ColumnChart'));

setInterval(function () {
    FirstMetToGetDataHistory($("#myselect").val());
}, intervalTime);


$(document).ready(function () {
    $('#myselect').change(function () {
        //alert($(this).val());
        console.log($("#myselect").val());
        FirstMetToGetDataHistory($("#myselect").val());
    });
});