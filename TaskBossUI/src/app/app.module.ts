import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { SigninComponent } from './components/signin/signin.component';
import { SignupComponent } from './components/signup/signup.component';
import { HomeComponent } from './components/home/home.component';
import { AddProjectComponent } from './components/add-project/add-project.component';
import { CatalogueComponent } from './components/catalogue/catalogue.component';
import { SkillsComponent } from './components/skills/skills.component';
import { ViewProjectComponent } from './components/view-project/view-project.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ApplierProfileComponent } from './components/applierProfile/applier-profile.component';
import { NotificationComponent } from 'src/app/components/notifications/notification.component';

@NgModule({
  declarations: [
    AppComponent,
    SignupComponent,
    SigninComponent,
    HomeComponent,
    CatalogueComponent,
    AddProjectComponent,
    ViewProjectComponent,
    SkillsComponent,
    ProfileComponent,
    ApplierProfileComponent,
    NotificationComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
