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
  constructor(private companyService: CompanyService) {
     companyService.getData().subscribe(data => {
       this.companies = data;
     });
  }
  onChangeSelectListItem(e) {
    this.loadedAnalytic = false;
    if (e.target.value == "0") {
       return;
    }
    this.selectedCompanyId = e.target.value;
  }
  onClickGetBtn(e) {
    this.loadedAnalytic = false;
    let dateTimeFrom = new Date(this.yearFrom);
    let dateTimeTo = new Date(this.yearTo);

    let yearFrom = dateTimeFrom.getFullYear();
    let yearTo = dateTimeTo.getFullYear();
    if (yearFrom >= yearTo) return;
    
    if (this.selectedCompanyId == 0) {
      return;
    }
    this.companyService.getAnalytic(this.selectedCompanyId,yearFrom, yearTo).subscribe(data => {
      this.companyAnalytics = data;
      this.loadedAnalytic = true;
      console.log(this.companyAnalytics);
    });
  }
}


