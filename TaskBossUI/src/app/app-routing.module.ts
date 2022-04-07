import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from 'src/app/components/home/home.component';
import { SignupComponent } from 'src/app/components/signup/signup.component';
import { SigninComponent } from 'src/app/components/signin/signin.component';
import { AddProjectComponent } from 'src/app/components/add-project/add-project.component';
import { CatalogueComponent } from 'src/app/components/catalogue/catalogue.component';
import { ViewProjectComponent } from 'src/app/components/view-project/view-project.component';
import { SkillsComponent } from 'src/app/components/skills/skills.component';
import { ProfileComponent } from 'src/app/components/profile/profile.component';
import { NotificationComponent } from 'src/app/components/notifications/notification.component';
import { ApplierProfileComponent } from 'src/app/components/applierProfile/applier-profile.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'findwork', component: CatalogueComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'signin', component: SigninComponent },
  { path: 'notification', component: NotificationComponent },
  { path: 'postjob/:id', component: AddProjectComponent },
  { path: 'catalogue/:id', component: CatalogueComponent },
  { path: 'skills/:id', component: SkillsComponent },
  { path: 'project/:id', component: ViewProjectComponent },
  { path: 'profile/:id', component: ProfileComponent },
  { path: 'applierprofile/:id', component: ApplierProfileComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
