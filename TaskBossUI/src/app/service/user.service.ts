import { Injectable } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { formatDate } from '@angular/common';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  isAuthenticated: boolean = false;
  constructor(private http: HttpClient, private router: Router) { }

  formData: User = new User();
  readonly _url = "https://localhost:44374/api/User";
  signIn = 'SignIn';
  signUp = 'SignUp';

  getUsers() {
    return this.http.get<User[]>(this._url);
  }
  getUserById(userId: number): Observable<any> {
    return this.http.get<User[]>(this._url + "/" + userId);
  }
  postUser() {
    return this.http.post(this._url, this.formData);
  }

  loginUser(user: any): Observable<any> {
    return this.http.get<User[]>(this._url + "/" + user.email + "/" + user.password);
  }


  authincate(user: any) {
    if (this.getLoginUserData() == null) {
      this.isAuthenticated = true;
      localStorage.setItem('user[0]', JSON.stringify({ 'userId': user[0].userId, 'email': user[0].email, 'userType': user[0].userType, 'userName': user[0].userName, 'domainId': user[0].domainId, 'subDomainId': user[0].subDomainId }));
      this.signIn = 'SignOut';
      this.signUp = '';
      this.router.navigate(['']);
    }
    if (this.isAuthenticated = false) {
      this.router.navigate(['/signin']);
    }
  }

  getLoginUserData() {
    return JSON.parse(localStorage.getItem('user[0]')!);
  }
  deleteLoginUserData() {
    return localStorage.removeItem('user[0]');
  }
  signOut() {
    if (this.signIn == 'SignOut') {
      this.deleteLoginUserData();
      this.signIn = 'SignIn';
      this.signUp = 'SignUp';
    }
  }
}
