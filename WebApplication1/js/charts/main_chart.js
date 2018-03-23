var chartData; // globar variable for hold chart data
var intervalTime = 90000;
var chart;
google.charts.load('current', { 'packages': ['corechart'] });

window.onload = function () {
    var timeInMinutes = intervalTime / 1000, // 60* 5
        display = document.querySelector('#timer');
    startTimer(timeInMinutes, display);
};

function startTimer(duration, display) {
    var timer = duration, minutes, seconds;
    setInterval(function () {
        minutes = parseInt(timer / 60, 10);
        seconds = parseInt(timer % 60, 10);

        minutes = minutes < 10 ? "0" + minutes : minutes;
        seconds = seconds < 10 ? "0" + seconds : seconds;

        display.textContent = minutes + ":" + seconds;

        if (--timer < 0) {
            timer = duration;
        }
    }, 1000);
}