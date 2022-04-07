import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SkillService } from 'src/app/service/skill.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Skill } from 'src/app/models/skill.model';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-skills',
  templateUrl: './skills.component.html',
  styleUrls: ['./skills.component.css']
})
export class SkillsComponent implements OnInit {
  id: number = Number(this.route.snapshot.paramMap.get('id'));
  skillLst: Skill[] = new Array<Skill>();

  constructor(private router: Router, private route: ActivatedRoute, public service: SkillService, public userService: UserService) { }

  ngOnInit(): void {
    this.service.formData.userId = this.id;
  }

  save(form: NgForm) {
    this.service.postSkill().subscribe(
      res => {
        this.skillsList(this.id);
        this.resetFormFields();
      },
      err => {
        console.log(err);
      }
    )
  }
  skillsList(userId: any): void {
    this.service.getSkillsByUserId(userId).subscribe(data => {
      this.skillLst = data;
    });
  }
  resetFormFields() {
    this.service.formData.skillName = '';
    this.service.formData.skillLevel = 0;
  }
  onSubmit() {
    this.router.navigate(['/signin']);
  }
}
