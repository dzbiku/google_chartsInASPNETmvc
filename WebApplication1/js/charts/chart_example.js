google.charts.load('current', { 'packages': ['corechart'] });
google.charts.load("current", { packages: ["imageareachart"] });
google.charts.load('current', { 'packages': ['annotationchart'] });


google.charts.setOnLoadCallback(drawChartColumn);
google.charts.setOnLoadCallback(drawChartPie);
google.charts.setOnLoadCallback(drawChartLine);
google.charts.setOnLoadCallback(drawChartArea);
google.charts.setOnLoadCallback(drawChartBubble); 
google.charts.setOnLoadCallback(drawChartAnnotation);


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
        title: 'S-70l Carry Forward Labor Hours By Position (PZL)',
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
        title: 'S-70l Carry Forward Labor Hours By Position (PZL)',
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
        title: 'S-70l Carry Forward Labor Hours By Position (PZL)',
        hAxis: { title: 'Temporary', titleTextStyle: { color: 'red' } }
    };

    var chart = new google.visualization.LineChart(document.getElementById('chart_div_line'));
    chart.draw(data, options);
}


//image area chart
//ImageAreaChart
function drawChartArea() {
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
        title: 'S-70l Carry Forward Labor Hours By Position (PZL)',
        hAxis: { title: 'Temporary', titleTextStyle: { color: 'red' } }
    };

    var chart = new google.visualization.ImageAreaChart(document.getElementById('chart_div_area'));
    chart.draw(data, options);
}

//Bubble chart
function drawChartBubble() {
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
        title: 'S-70l Carry Forward Labor Hours By Position (PZL)',
        hAxis: { title: 'Temporary', titleTextStyle: { color: 'red' } },
        bubble: { textStyle: { fontSize: 11 } }
    };

    var chart = new google.visualization.BubbleChart(document.getElementById('chart_div_bubble'));
    chart.draw(data, options);
}

//gantt
function drawChartAnnotation() {
    var data = new google.visualization.DataTable();
    data.addColumn('date', 'Date');
    data.addColumn('number', 'Kepler-22b mission');
    data.addColumn('string', 'Kepler title');
    data.addColumn('string', 'Kepler text');
    data.addColumn('number', 'Gliese 163 mission');
    data.addColumn('string', 'Gliese title');
    data.addColumn('string', 'Gliese text');
    data.addRows([
        [new Date(2314, 2, 15), 12400, undefined, undefined,
            10645, undefined, undefined],
        [new Date(2314, 2, 16), 24045, 'Lalibertines', 'First encounter',
            12374, undefined, undefined],
        [new Date(2314, 2, 17), 35022, 'Lalibertines', 'They are very tall',
            15766, 'Gallantors', 'First Encounter'],
        [new Date(2314, 2, 18), 12284, 'Lalibertines', 'Attack on our crew!',
            34334, 'Gallantors', 'Statement of shared principles'],
        [new Date(2314, 2, 19), 8476, 'Lalibertines', 'Heavy casualties',
            66467, 'Gallantors', 'Mysteries revealed'],
        [new Date(2314, 2, 20), 0, 'Lalibertines', 'All crew lost',
            79463, 'Gallantors', 'Omniscience achieved']
    ]);

    var options = {
        title: 'S-70l Carry Forward Labor Hours By Position (PZL)',
        hAxis: { title: 'Temporary', titleTextStyle: { color: 'red' } },
        displayAnnotations: true
    };

    var chart = new google.visualization.AnnotationChart(document.getElementById('chart_div_Annotation'));
    chart.draw(data, options);
}