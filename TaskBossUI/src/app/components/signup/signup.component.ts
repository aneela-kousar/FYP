import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/service/user.service';
import { SubDomain } from 'src/app/models/sub-domain.model';
import { SubDomainService } from 'src/app/service/sub-domain.service';
import { Domain } from 'src/app/models/domain.model';
import { DomainService } from 'src/app/service/domain.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  // userLst: User[] = new Array<User>();
  domainLst: Domain[] = new Array<Domain>();
  subDomainLst: SubDomain[] = new Array<SubDomain>();
  isAccountInvalid: boolean = false;
  userData: any;


  constructor(private router: Router, public service: UserService, public svcDomain: DomainService, public svcSubDomain: SubDomainService) { }

  ngOnInit(): void {
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
    var checkUser = form.value.userType;

    //passuser  sign up data to db 
    this.service.postUser().subscribe(
      res => {
        if (checkUser == 1) {
          this.userData = <User[]>res;
          this.router.navigate(['/skills/' + this.userData.userId]);
          console.log(res);
        }
        if (checkUser == 2) {
          this.router.navigate(['/signin']);
          console.log(res);
        }
      },
      err => {
        console.log(err);
        this.isAccountInvalid = true;
      }
    )
  }

}
