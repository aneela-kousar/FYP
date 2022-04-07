import { Component, OnInit, ViewChild } from '@angular/core';
import { ProjectService } from 'src/app/service/project.service';
import { Project } from 'src/app/models/project.model';
import { ActivatedRoute, Router } from '@angular/router';
import { DomainService } from 'src/app/service/domain.service';
import { UserService } from 'src/app/service/user.service';
import { NotificationService } from 'src/app/service/notification.service';
// import { Notifications } from 'src/app/models/notification.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-view-project',
  templateUrl: './view-project.component.html',
  styleUrls: ['./view-project.component.css']
})
export class ViewProjectComponent implements OnInit {
  project: Project = new Project();
  userName: string = this.userService.getLoginUserData().userName;
  isDisabled: boolean = false;

  constructor(public service: NotificationService, public projService: ProjectService, private route: ActivatedRoute, private router: Router, public domainSvc: DomainService, public userService: UserService) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.getProject(id);
    // if (this.project.projectId == id) {
    //   this.isDisabled == true;
    // }
    this.service.formData.applierId = this.userService.getLoginUserData().userId;
  }
  getProject(id: number): void {
    this.projService.getProjectById(id).subscribe(data => {
      this.domainSvc
      this.project = data;
      this.service.formData.projectId = this.project.projectId;
      this.service.formData.projectDescription = this.project.description;
      this.service.formData.ownerId = this.project.ownerId;
    });
  }
  navigateToHomePage() {
    this.router.navigate(['']);
  }

  save(formData: NgForm) {
    this.isDisabled = true;
    this.service.applyOnProject().subscribe(
      res => {
        this.router.navigate(['/notification']);
      },
      err => {
        console.log(err);
      }
    )

  }
}
