import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Notifications } from 'src/app/models/notification.model';
import { UserService } from 'src/app/service/user.service';
import { NotificationService } from 'src/app/service/notification.service';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css']
})
export class NotificationComponent implements OnInit {

  userId: number = this.userService.getLoginUserData().userId;
  userType: number = this.userService.getLoginUserData().userType;
  notifLst: Notifications[] = new Array<Notifications>();
  notifType: number = 0;
  isDisabled: boolean = false;
  project: Notifications = new Notifications();

  constructor(private router: Router, private route: ActivatedRoute, public service: NotificationService, public userService: UserService) { }

  ngOnInit(): void {
    // this.service.formData.userId = this.id;
    this.uncheckedProjList(1);
  }

  save(form: NgForm) {
    // this.service.postSkill().subscribe(
    //   res => {
    //     // this.skillsList(this.id);
    //     this.resetFormFields();
    //   },
    //   err => {
    //     console.log(err);
    //   }
    // )
  }
  uncheckedProjList(notifType: number): void {
    this.service.getUnckeckedNotifications(this.userId, this.notifType).subscribe(data => {
      this.notifLst = data;
    });
  }
  resetFormFields() {
    // this.service.formData.skillName = '';
    // this.service.formData.skillLevel = 0;
  }
  onSubmit(projId: number) {
    this.service.getNotificationById(projId).subscribe(data => {
      this.project = data;
      this.service.formData.id = this.project.id;
      this.service.formData.isApproved = true;
      this.service.formData.isChecked = true;
      this.service.formData.projectId = this.project.projectId;
      this.service.formData.projectDescription = this.project.projectDescription;
      this.service.formData.ownerId = this.project.ownerId;
      this.service.formData.applierId = this.project.applierId;

      this.service.approveProject(projId).subscribe(
        res => {
          this.isDisabled = true;
        },
        err => {
          console.log(err);
        }
      )
    });
  }

}
