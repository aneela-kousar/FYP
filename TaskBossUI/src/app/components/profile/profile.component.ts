import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ProfileService } from 'src/app/service/profile.service';
import { UserService } from 'src/app/service/user.service';
import { SkillService } from 'src/app/service/skill.service';
import { DomainService } from 'src/app/service/domain.service';
import { Skill } from 'src/app/models/skill.model';
import { Domain } from 'src/app/models/domain.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})

export class ProfileComponent implements OnInit {
  userId: number = this.userService.getLoginUserData().userId;
  userName: string = this.userService.getLoginUserData().userName;
  email: string = this.userService.getLoginUserData().email;
  domainId: number = this.userService.getLoginUserData().domainId;
  skillLst: Skill[] = new Array<Skill>();
  domain: Domain = new Domain();

  constructor(public svc: ProfileService, public userService: UserService, public service: SkillService, public domainSvc: DomainService) { }

  ngOnInit(): void {

    this.skillsList();
    this.userDomain();
  }

  skillsList(): void {
    this.service.getSkillsByUserId(this.userId).subscribe(data => {
      this.skillLst = data;
    });
  }

  userDomain(): void {
    this.domainSvc.getDomainbyId(this.domainId).subscribe(data => {
      this.domain = data;
      this.domainSvc.formData.domainName = this.domain.domainName;
    });
  }

}


