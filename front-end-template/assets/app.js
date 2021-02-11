  


    var myChartCircle = new Chart('chartProgress', {
        type: 'doughnut',
        data: {
          datasets: [{
            label: 'Project A',
            percent: 73.5,
            backgroundColor: ['#5283ff']
          }]
        },
        plugins: [{
            beforeInit: (chart) => {
              const dataset = chart.data.datasets[0];
              chart.data.labels = [dataset.label];
              dataset.data = [dataset.percent, 100 - dataset.percent];
            }
          },
          {
            beforeDraw: (chart) => {
              var width = chart.chart.width,
                height = chart.chart.height,
                ctx = chart.chart.ctx;
              ctx.restore();
              var fontSize = (height / 150).toFixed(2);
              ctx.font = fontSize + "em sans-serif";
              ctx.fillStyle = "#9b9b9b";
              ctx.textBaseline = "middle";
              var text = chart.data.datasets[0].percent + "%",
                textX = Math.round((width - ctx.measureText(text).width) / 2),
                textY = height / 2;
              ctx.fillText(text, textX, textY);
              ctx.save();
            }
          }
        ],
        options: {
          maintainAspectRatio: false,
          cutoutPercentage: 85,
          rotation: Math.PI / 2,
          legend: {
            display: false,
          },
          tooltips: {
            filter: tooltipItem => tooltipItem.index == 0
          }
        }
      });
      var projectB = new Chart('projectB', {
        type: 'doughnut',
        data: {
          datasets: [{
            label: 'Project B',
            percent: 12.5,
            backgroundColor: ['#5283ff']
          }]
        },
        plugins: [{
            beforeInit: (chart) => {
              const dataset = chart.data.datasets[0];
              chart.data.labels = [dataset.label];
              dataset.data = [dataset.percent, 100 - dataset.percent];
            }
          },
          {
            beforeDraw: (chart) => {
              var width = chart.chart.width,
                height = chart.chart.height,
                ctx = chart.chart.ctx;
              ctx.restore();
              var fontSize = (height / 150).toFixed(2);
              ctx.font = fontSize + "em sans-serif";
              ctx.fillStyle = "#9b9b9b";
              ctx.textBaseline = "middle";
              var text = chart.data.datasets[0].percent + "%",
                textX = Math.round((width - ctx.measureText(text).width) / 2),
                textY = height / 2;
              ctx.fillText(text, textX, textY);
              ctx.save();
            }
          }
        ],
        options: {
          maintainAspectRatio: false,
          cutoutPercentage: 85,
          rotation: Math.PI / 2,
          legend: {
            display: false,
          },
          tooltips: {
            filter: tooltipItem => tooltipItem.index == 0
          }
        }
      });


      var optionsExpend = {
        series: [44, 55, 67, 83],
        chart: {
        height: 350,
        type: 'radialBar',
      },
      plotOptions: {
        radialBar: {
          dataLabels: {
            name: {
              fontSize: '22px',
            },
            value: {
              fontSize: '16px',
            },
            total: {
              show: true,
              label: 'Total',
              formatter: function (w) {
                // By default this function returns the average of all series. The below is just an example to show the use of custom formatter function
                return 249
              }
            }
          }
        }
      },
      labels: ['Apples', 'Oranges', 'Bananas', 'Berries'],
      };

      var chart = new ApexCharts(document.querySelector("#radiar-bar"), optionsExpend);
      chart.render();      



      var optionsDept= {
        series: [37, 75],
        chart: {
        height: 250,
        type: 'radialBar',
      },
      plotOptions: {
        radialBar: {
          dataLabels: {
            name: {
              fontSize: '22px',
            },
            value: {
              fontSize: '16px',
            },
            total: {
              show: true,
              label: 'Total',
              formatter: function (w) {
                // By default this function returns the average of all series. The below is just an example to show the use of custom formatter function
                return 37+75
              }
            }
          }
        }
      },
      labels: ['Company dept', 'Goverment dept'],
      };
      var chart = new ApexCharts(document.querySelector("#radiar-dept-bar"), optionsDept);
      chart.render();


      $('#inputDate').datepicker({
    });