import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserSkill } from 'src/app/models/user-skill.model';

@Injectable({
  providedIn: 'root'
})
export class UserSkillService {

  constructor(private http: HttpClient) { }

  formData: UserSkill = new UserSkill();
  readonly _url = "https://localhost:44374/api/UserSkill";

  getUserSkills() {
    return this.http.get<UserSkill[]>(this._url);
  }

  postUserSkill(){
    return this.http.post(this._url, this.formData);
  }
}