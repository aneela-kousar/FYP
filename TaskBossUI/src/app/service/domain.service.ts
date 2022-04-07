import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Domain } from 'src/app/models/domain.model';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class DomainService {

  constructor(private http: HttpClient) { }

  formData: Domain = new Domain();
  readonly _url = "https://localhost:44374/api/Domain";

  getDomains(): Observable<any> {
    return this.http.get<Domain[]>(this._url);
  }

  getDomainbyId(userId: number): Observable<any> {
    return this.http.get<Domain[]>(this._url + "/" + userId);
  }
}
