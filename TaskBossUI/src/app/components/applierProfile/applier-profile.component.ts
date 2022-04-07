import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ProfileService } from 'src/app/service/profile.service';
import { UserService } from 'src/app/service/user.service';
import { SkillService } from 'src/app/service/skill.service';
import { DomainService } from 'src/app/service/domain.service';
import { Skill } from 'src/app/models/skill.model';
import { Domain } from 'src/app/models/domain.model';
import { ActivatedRoute, Router } from '@angular/router';
import { Profile } from 'src/app/models/profile.model';

@Component({
  selector: 'app-applier-profile',
  templateUrl: './applier-profile.component.html',
})

export class ApplierProfileComponent implements OnInit {
  skillLst: Skill[] = new Array<Skill>();
  domain: Domain = new Domain();
  profile: Profile = new Profile();

  constructor(private route: ActivatedRoute, private router: Router, public svc: ProfileService, public userService: UserService, public service: SkillService, public domainSvc: DomainService) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.svc.getProfileById(id).subscribe(data => {
      this.profile = data;
      this.svc.formData.id = this.profile.id;
      this.svc.formData.userName = this.profile.userName;
      this.svc.formData.email = this.profile.email;
      this.svc.formData.domainId = this.profile.domainId;
      this.userDomain(this.svc.formData.domainId);
      this.svc.formData.domainName = this.domain.domainName;
    });
    this.skillsList(id);
  }

  skillsList(userId: any): void {
    this.service.getSkillsByUserId(userId).subscribe(data => {
      this.skillLst = data;
    });
  }

  userDomain(domainId: any): void {
    // let domainId = this.svc.formData.domainId;

    this.domainSvc.getDomainbyId(domainId).subscribe(data => {
      this.domain = data;
      this.svc.formData.domainName = this.domain.domainName;
    });
  }

}


