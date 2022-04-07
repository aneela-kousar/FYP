import { Injectable } from '@angular/core';
import { Skill } from 'src/app/models/skill.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SkillService {

  constructor(private http: HttpClient) { }

  formData: Skill = new Skill();
  readonly _url = "https://localhost:44374/api/Skill/";

  // getSkills() {
  //   return this.http.get<Skill[]>(this._url);
  // }
  getSkillsByUserId(userId: number): Observable<any> {
    return this.http.get<Skill[]>(this._url + userId);
  }
  postSkill() {
    return this.http.post(this._url, this.formData);
  }
}