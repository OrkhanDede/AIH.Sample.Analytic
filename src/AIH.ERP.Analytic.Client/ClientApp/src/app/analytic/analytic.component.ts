import { Component, Inject, OnInit  } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Company } from '../Model/company';
import { CompanyAnalytic } from '../Model/CompanyAnalytic';
import { CompanyService } from '../services/company.service';
import { IDropdownSettings } from 'ng-multiselect-dropdown';


@Component({
  selector: 'app-analytic',
  templateUrl: './analytic.component.html',
})
export class AnalyticComponent implements OnInit {
  public companies: Company[];
  public companyAnalytics: CompanyAnalytic[];
  public loadedAnalytic: boolean = false;
  
  public yearFrom: Date;
  public yearTo: Date;
  
  minDate: Date;
  maxDate: Date;

  dropdownList = [];
  selectedItems = [];
  dropdownSettings = {};
  

  constructor(private companyService: CompanyService) {
    
  }
  ngOnInit(): void {
    this.yearFrom = new Date(2015, 0);
    this.yearTo = new Date(2020, 0);
    this.minDate = new Date();
    this.maxDate = new Date();
    this.minDate.setDate(-2000);
    this.maxDate.setDate(-50);

    this.companyService.getData().subscribe(data => {
      this.companies = data;
      this.dropdownList = data.map(comp => ({ item_id: comp.id, item_text: comp.title }));
      this.selectedItems = this.dropdownList;
    });

   
    this.dropdownSettings = {
      singleSelection: false,
      idField: 'item_id',
      textField: 'item_text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 5,
      allowSearchFilter: true
    };

  }
  onClickGetBtn(e) {
    this.loadedAnalytic = false;
    let dateTimeFrom = new Date(this.yearFrom);
    let dateTimeTo = new Date(this.yearTo);

    let yearFrom = dateTimeFrom.getFullYear();
    let yearTo = dateTimeTo.getFullYear();
    if (yearFrom >= yearTo) return;
    if (this.selectedItems.length <= 0) return;

    let ids = this.selectedItems.map(comp => {
      return comp.item_id;
    });
    this.companyService.getAnalytic(ids, yearFrom, yearTo).subscribe(data => {
      this.companyAnalytics = data;
      this.loadedAnalytic = true;
     
    });
  }
  onItemDeSelect(item: any) {
    console.log("deselect:" + item.item_id);
  }
  onItemSelect(item: any) {
    console.log("select:" + item.item_id);
  }
  onSelectAll(items: any[]) {
    console.log("select all:" + items);
  }
}


