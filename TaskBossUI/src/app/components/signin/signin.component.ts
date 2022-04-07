import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserSkill } from 'src/app/models/user-skill.model';
import { UserSkillService } from 'src/app/service/user-skill.service';
import { UserService } from 'src/app/service/user.service';
import { User } from 'src/app/models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  user: User = new User();
  isCredentialInvalid: boolean = false;
  constructor(public service: UserService) { }

  ngOnInit(): void {
  }

  save(form: NgForm) {
    this.service.loginUser(form).subscribe(
      res => {
        this.user = res;
        this.service.authincate(this.user);
      },
      err => {
        this.isCredentialInvalid = true;
        console.log(err + "Please Enter correct email id or password");
      }
    )
  }
}
