'use strict';
function legendClickCallback(event) {
    event = event || window.event;

    var target = event.target || event.srcElement;
    while (target.nodeName !== 'LI') {
        target = target.parentElement;
    }
    var parent = target.parentElement;
    var chartId = parseInt(parent.classList[0].split("-")[0], 10);
    var chart = Chart.instances[chartId];
    var index = Array.prototype.slice.call(parent.children).indexOf(target);
    var meta = chart.getDatasetMeta(index);
    if (meta.hidden === null) {
        meta.hidden = !chart.data.datasets[index].hidden;
        target.classList.add('hidden-lable');
    } else {
        target.classList.remove('hidden-lable');
        meta.hidden = null;
    }
    chart.update();
}
var ctx = document.getElementById("canvas-chart");
var myLegendContainer = document.getElementById("myChartLegend");

var myChart = new Chart(ctx, config);
myLegendContainer.innerHTML = myChart.generateLegend();
var legendItems = myLegendContainer.getElementsByTagName('li');
for (var i = 0; i < legendItems.length; i += 1) {
    legendItems[i].addEventListener("click", legendClickCallback, false);
}