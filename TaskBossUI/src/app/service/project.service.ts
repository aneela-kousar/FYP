import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Project } from 'src/app/models/project.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor(private http: HttpClient) { }

  formData: Project = new Project();
  readonly _url = "https://localhost:44374/api/Project";

  getProjects() {
    return this.http.get<Project[]>(this._url);
  }
  getProjectBySubDomain(selectedDomainId: number, selectedSubDomainId: number, pageId: number): Observable<any> {
    return this.http.get<Project[]>(this._url + "/" + selectedDomainId + "/" + selectedSubDomainId + "/" + pageId);
  }
  getProjectById(projectId: number): Observable<any> {
    return this.http.get<Project[]>(this._url + "/" + projectId);
  }
  postProject() {
    return this.http.post(this._url, this.formData);
  }
  applyOnProject() {
    return this.http.post(this._url, this.formData + "/0");
  }
}
