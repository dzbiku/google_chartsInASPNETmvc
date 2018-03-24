google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(drawChartColumn);
google.charts.setOnLoadCallback(drawChartPie);
google.charts.setOnLoadCallback(drawChartLine);

function drawChartColumn() {
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Data');
    data.addColumn('number', 'value1');
    data.addColumn('number', 'value2');
    data.addRows([
        ['2000', 2, 37],
        ['2001', 3, 24],
        ['2002', 4, 41],
        ['2003', 10, 24],
        ['2004', 1, 41],
        ['2005', 30, 24],

    ]);

    var options = {
        title: 'S-70l Carry Forward Labor Hours By Position (PZL) as of @DateTime.Now',
        hAxis: { title: 'Temporary', titleTextStyle: { color: 'red' } },
        bar: { groupWidth: '75%' },
        isStacked: true
    };

    var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
    chart.draw(data, options);
}

//pie chart
function drawChartPie() {
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Data');
    data.addColumn('number', 'value1');
    data.addColumn('number', 'value2');
    data.addRows([
        ['2000', 2, 37],
        ['2001', 3, 24],
        ['2002', 4, 41],
        ['2003', 10, 24],
        ['2004', 1, 41],
        ['2005', 30, 24],

    ]);

    var options = {
        title: 'S-70l Carry Forward Labor Hours By Position (PZL) as of @DateTime.Now',
        hAxis: { title: 'Temporary', titleTextStyle: { color: 'red' } }
    };

    var chart = new google.visualization.PieChart(document.getElementById('chart_div_pie'));
    chart.draw(data, options);
}

//line chart
function drawChartLine() {
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Data');
    data.addColumn('number', 'value1');
    data.addColumn('number', 'value2');
    data.addRows([
        ['2000', 2, 37],
        ['2001', 3, 24],
        ['2002', 4, 41],
        ['2003', 10, 24],
        ['2004', 1, 41],
        ['2005', 30, 24],

    ]);

    var options = {
        title: 'S-70l Carry Forward Labor Hours By Position (PZL) as of @DateTime.Now',
        hAxis: { title: 'Temporary', titleTextStyle: { color: 'red' } }
    };

    var chart = new google.visualization.LineChart(document.getElementById('chart_div_line'));
    chart.draw(data, options);
}