import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Company } from '../Model/company';
import { CompanyAnalytic } from '../Model/CompanyAnalytic';

@Injectable({
  providedIn: 'root'
})

export class CompanyService {
  private  _baseUrl: string;
  constructor(private http: HttpClient,@Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }
  public getData() {
    let headers = new HttpHeaders();
    headers = headers.append('Ocp-Apim-Subscription-Key', '4a93a200d6aa42b7ab54d883dbaadfe8');
    return this.http.get<Company[]>(this._baseUrl + 'company', {headers});
  }
  public getAnalytic(id: number, yearFrom: number, yearTo: number) {
    let headers = new HttpHeaders();
    headers = headers.append('Ocp-Apim-Subscription-Key', '4a93a200d6aa42b7ab54d883dbaadfe8');
    return this.http.get<CompanyAnalytic[]>(this._baseUrl + `company/analytic?Id=${id}&YearFrom=${yearFrom}&YearTo=${yearTo}`,
      {headers});
  }
}
