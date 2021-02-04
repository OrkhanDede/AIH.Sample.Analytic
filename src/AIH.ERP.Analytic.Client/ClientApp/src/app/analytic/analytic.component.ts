import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Company } from '../Model/company';
import { CompanyAnalytic } from '../Model/CompanyAnalytic';
import { CompanyService } from '../services/company.service';  

@Component({
  selector: 'app-analytic',
  templateUrl: './analytic.component.html',
})
export class AnalyticComponent {
  public companies: Company[];
  public companyAnalytics: CompanyAnalytic[];
  public loadedAnalytic: boolean = false;
  public selectedCompanyId: number = 0;
  public yearFrom: string;
  public yearTo: string;
  minDate: Date;
  maxDate: Date;
  constructor(private companyService: CompanyService) {
    this.minDate = new Date();
    this.maxDate = new Date();
    this.minDate.setDate(-2000);
    this.maxDate.setDate(-50);
     companyService.getData().subscribe(data => {
       this.companies = data;
     });
  }
  onChangeSelectListItem(e) {
    this.loadedAnalytic = false;
    this.selectedCompanyId = e.target.value;
  }
  onClickGetBtn(e) {
    this.loadedAnalytic = false;
    let dateTimeFrom = new Date(this.yearFrom);
    let dateTimeTo = new Date(this.yearTo);

    let yearFrom = dateTimeFrom.getFullYear();
    let yearTo = dateTimeTo.getFullYear();
    if (yearFrom >= yearTo) return;
    

    this.companyService.getAnalytic(this.selectedCompanyId,yearFrom, yearTo).subscribe(data => {
      this.companyAnalytics = data;
      this.loadedAnalytic = true;
      console.log(this.companyAnalytics);
    });
  }
}


