import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { SubDomain } from 'src/app/models/sub-domain.model';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class SubDomainService {

  constructor(private http: HttpClient) { }

  formData: SubDomain = new SubDomain();
  readonly _url = "https://localhost:44374/api/SubDomain/";

  getSubDomains(selectedDomainId: string): Observable<any> {
    return this.http.get(this._url + selectedDomainId);
  }
}
