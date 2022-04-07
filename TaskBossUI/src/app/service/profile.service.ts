import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Profile } from '../models/profile.model';
import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
})
export class ProfileService {

    constructor(private http: HttpClient) { }

    formData: Profile = new Profile();
    readonly _url = "https://localhost:44374/api/User";

    postProfile() {
        return this.http.post(this._url, this.formData);
    }
    getProfileById(id: any): Observable<any> {
        return this.http.get<Profile[]>(this._url + '/' + id);
    }
}
