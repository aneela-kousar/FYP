import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ProjectService } from 'src/app/service/project.service';
import { Domain } from 'src/app/models/domain.model';
import { SubDomain } from 'src/app/models/sub-domain.model';
import { DomainService } from 'src/app/service/domain.service';
import { SubDomainService } from 'src/app/service/sub-domain.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Project } from 'src/app/models/project.model';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css']
})
export class AddProjectComponent implements OnInit {
  id: number = Number(this.route.snapshot.paramMap.get('id'));
  domainLst: Domain[] = new Array<Domain>();
  subDomainLst: SubDomain[] = new Array<SubDomain>();
  userName: string = this.userService.getLoginUserData().userName;
  isProjectSaved: boolean = false;
  isDisabled: boolean = false;

  constructor(private router: Router, private route: ActivatedRoute, public service: ProjectService, public svcDomain: DomainService, public svcSubDomain: SubDomainService, public userService: UserService) { }

  ngOnInit(): void {
    this.service.formData.ownerId = this.userService.getLoginUserData().userId;
    var _userType = this.userService.getLoginUserData().userType;
    this.service.formData.ownerType = _userType;
    // if (this.id == 0) {
    //   this.service.formData.isCompleted = false;
    // }
    // else if (this.id == 1) {
    //   this.service.formData.isCompleted = true;
    // }
    if (this.id == 0 && _userType == 0) {
      this.isDisabled == true;
      this.service.formData.isCompleted = false;
    }
    if (this.id == 1 && _userType == 1) {
      this.isDisabled == true;
      this.service.formData.isCompleted = true;
    }

    // this.service.formData.isAssigned = false;
    // this.service.formData.IsPaid = false;
    this.svcDomain.getDomains().subscribe(data => {
      this.domainLst = data;
    });
  }

  onChangeDomain(domainId: any): void {
    this.svcSubDomain.getSubDomains(domainId).subscribe(data => {
      this.subDomainLst = data;
    });
  }

  save(form: NgForm) {
    this.service.postProject().subscribe(
      res => {
        this.isProjectSaved = true;
      },
      err => {
        console.log(err);
      })
  }
  navigateToHomePage() {
    this.router.navigate(['']);
  }
}
