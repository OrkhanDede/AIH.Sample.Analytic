import { Component, OnInit, Input } from '@angular/core';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label, Color } from 'ng2-charts';
import { CompanyAnalytic } from '../Model/CompanyAnalytic';

@Component({
  selector: 'analytic-line-chart',
  templateUrl: './analytic-line-chart.component.html',
})
export class AnalyticLineChartComponent {

  @Input() dataAnalytic: CompanyAnalytic[];

  

  lineChartProfitData: ChartDataSets[] = [
    { data: [], label: '' }
  ];
  lineChartExpenseData: ChartDataSets[] = [
    { data: [], label: '' }
  ];
  lineChartLabels: Label[] = [];

  lineChartOptions = {
    responsive: true,
  };

  lineChartProfitColors: Color[] = [
    {
      borderColor: 'black',
      backgroundColor: 'rgb(255,161,181)',
    },
  ];
  lineChartExpenseColors: Color[] = [
    {
      borderColor: 'black',
      backgroundColor: 'rgb(134,199,243)',
    },
  ];

  lineChartLegend = true;
  lineChartPlugins = [];
  lineChartType = 'line';
  

  constructor() {
  }

  ngOnInit() {
    
    var years = this.dataAnalytic.map(x => {
      return x.year.toString();
    });
    var profit = this.dataAnalytic.map(x => {
      return x.profitAmount;
    });
    var expense = this.dataAnalytic.map(x => {
      return x.expenseAmount;
    });


    this.lineChartProfitData[0].data = profit;
    this.lineChartProfitData[0].label = "profit";
    this.lineChartLabels = years;


    this.lineChartExpenseData[0].data = expense;
    this.lineChartExpenseData[0].label = "expense";
  }
}
