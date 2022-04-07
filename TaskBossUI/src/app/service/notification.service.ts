import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Notifications } from 'src/app/models/notification.model';
import { Observable } from 'rxjs';
import { Notification } from 'rxjs/internal/Notification';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private http: HttpClient) { }
  formData: Notifications = new Notifications();
  readonly _url = "https://localhost:44374/api/AppliedProject/";

  getNotificationss(): Observable<any> {
    return this.http.get<Notifications[]>(this._url);
  }
  getUnckeckedNotifications(userId: number, notifType: number): Observable<any> {
    return this.http.get<Notifications[]>(this._url + userId + "/" + notifType);
  }
  getNotificationById(projId: number): Observable<any> {
    return this.http.get<Notifications[]>(this._url + projId);
  }
  applyOnProject() {
    return this.http.post(this._url, this.formData);
  }
  approveProject(projId: number) {
    return this.http.put(this._url + projId, this.formData);
  }
}