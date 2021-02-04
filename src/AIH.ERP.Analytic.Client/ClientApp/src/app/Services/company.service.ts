import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Company } from '../Model/company';
import { CompanyAnalytic } from '../Model/CompanyAnalytic';

@Injectable({
  providedIn: 'root'
})

export class CompanyService {
  private _baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }
  public getData() {
    let headers = new HttpHeaders();
    headers = headers.append('Ocp-Apim-Subscription-Key', '4a93a200d6aa42b7ab54d883dbaadfe8');
    return this.http.get<Company[]>(this._baseUrl + 'company', { headers });
  }
  public getAnalytic(ids: string[], yearFrom: number, yearTo: number) {

    

    let params = new HttpParams();

    params = params.append('YearFrom', yearFrom.toString());
    params = params.append('YearTo', yearTo.toString());
    ids.forEach((id: string) => {
      params = params.append(`ids`, JSON.stringify(id));
    });

    let headers = new HttpHeaders();
    headers = headers.append('Ocp-Apim-Subscription-Key', '4a93a200d6aa42b7ab54d883dbaadfe8');
    return this.http.get<CompanyAnalytic[]>(this._baseUrl + 'company/analytic', { params: params, headers: headers });
  }
}
