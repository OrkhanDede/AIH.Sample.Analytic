import { Component, OnInit, Input   } from '@angular/core';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';
import { CompanyAnalytic } from '../Model/CompanyAnalytic';

@Component({
  selector: 'analytic-bar-chart',
  templateUrl: './analytic-bar-chart.component.html',
})
export class AnalyticBarChartComponent {

  @Input() dataAnalytic: CompanyAnalytic[];

  title = 'Analytic Bar Charts';

  public barChartOptions: ChartOptions = {
    responsive: true,
  };
  public barChartLabels: Label[];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [];

  public barChartData: ChartDataSets[] = [
    { data: [], label: 'Profit' },
    { data: [], label: 'Expense' }
  ];

  constructor() {
  }

  ngOnInit() {
    console.log("BAR-init");
    var years = this.dataAnalytic.map(x => {
      return x.year.toString();
    });
    var profit = this.dataAnalytic.map(x => {
      return x.profitAmount;
    });
    var expense = this.dataAnalytic.map(x => {
      return x.expenseAmount;
    });
    this.barChartData[0].data = profit;
    this.barChartData[1].data = expense;

    this.barChartLabels = years;
  }
}
