import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/service/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  appTitle = 'Task Boss';
  public show = false;
  // public _userType = 0;


  constructor(public auth: UserService, private router: Router) { }

  ngOnInit() {
    if (this.auth.getLoginUserData() !== null) {
      this.isShown(this.auth.getLoginUserData().userType);
    }
    if (this.auth.getLoginUserData() != null) {
      this.auth.signIn = 'SignOut'
    }
  }

  isLogin() {
    if (this.auth.getLoginUserData() == null) {
      this.router.navigate(['/signin']);
    }
  }

  isShown(userType: number): void {
    if (userType == 2) {
      this.show = true;
    }
  }
}
