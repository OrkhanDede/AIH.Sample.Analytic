import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgHttpLoaderModule } from 'ng-http-loader';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';




import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AnalyticComponent } from './analytic/analytic.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AnalyticPieChartComponent } from './analytic-pie-chart/analytic-pie-chart.component';
import { AnalyticBarChartComponent } from './analytic-bar-chart/analytic-bar-chart.component';
import { AnalyticLineChartComponent } from './analytic-line-chart/analytic-line-chart.component';



import { CompanyService } from './services/company.service';

import { ChartsModule, ThemeService } from 'ng2-charts'

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// RECOMMENDED
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AnalyticComponent,
    AnalyticPieChartComponent,
    AnalyticBarChartComponent,
    AnalyticLineChartComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ChartsModule,
    BrowserAnimationsModule,
    BsDatepickerModule.forRoot(),
    NgHttpLoaderModule.forRoot(),
    NgMultiSelectDropDownModule.forRoot(),

    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'analytic', component: AnalyticComponent },
      { path: 'fetch-data', component: FetchDataComponent }
    ])
  ],
  exports: [
    AnalyticComponent,
    AnalyticPieChartComponent,
    AnalyticBarChartComponent
  ],
  providers: [ThemeService, CompanyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
