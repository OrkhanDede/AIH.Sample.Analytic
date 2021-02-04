import { Component,Input } from '@angular/core';
import { ChartType, ChartOptions } from 'chart.js';
import { SingleDataSet , Label, monkeyPatchChartJsLegend, monkeyPatchChartJsTooltip } from 'ng2-charts';
import { CompanyAnalytic } from "../Model/CompanyAnalytic";

@Component({
  selector: 'analytic-pie-chart',
  templateUrl: './analytic-pie-chart.component.html',
})
export class AnalyticPieChartComponent {
  title = 'Analytic Pie Charts';
  @Input() dataAnalytic: CompanyAnalytic[];
  // Pie
  public pieChartOptions: ChartOptions = {
    responsive: true,
  };
  public pieChartLabels: Label[] = ['Profit ','Expense'];
  public pieChartData: SingleDataSet = [];
  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = [];

  constructor() {
    monkeyPatchChartJsTooltip();
    monkeyPatchChartJsLegend();
  }

  ngOnInit() {
    
    var profit = this.dataAnalytic.map(x => {
      return x.profitAmount;
    });
    var expense = this.dataAnalytic.map(x => {
      return x.expenseAmount;
    });
    let sumProfit = profit.map(a => a).reduce(function (a, b) {
      return a + b;
    });
    let sumExpense = expense.map(a => a).reduce(function (a, b) {
      return a + b;
    });
    this.pieChartData[0] = sumProfit;
    this.pieChartData[1] = sumExpense;

    
  }
}
