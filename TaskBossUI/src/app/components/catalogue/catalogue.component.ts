import { Component, OnInit } from '@angular/core';
import { ProjectService } from 'src/app/service/project.service';
import { Project } from 'src/app/models/project.model';
import { SubDomainService } from 'src/app/service/sub-domain.service';
import { SubDomain } from 'src/app/models/sub-domain.model';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-catalogue',
  templateUrl: './catalogue.component.html',
  styleUrls: ['./catalogue.component.css']
})
export class CatalogueComponent implements OnInit {
  subDomainLst: SubDomain[] = new Array<SubDomain>();
  projectLst: Project[] = new Array<Project>();
  public show: number = 0;
  public showProj: number = 0;
  pageId: number = 0;

  constructor(public svcSubDomain: SubDomainService, public service: ProjectService, private router: Router, private route: ActivatedRoute) {

  }

  ngOnInit(): void {
    this.pageId = Number(this.route.snapshot.paramMap.get('id'));
  }

  onChangeDomain(clickEvent: any): void {
    this.show = clickEvent;
    this.svcSubDomain.getSubDomains(clickEvent).subscribe(data => {
      this.subDomainLst = data;
    });
  }

  projectsList(domainId: any, subDomainId: any): void {
    this.showProj = domainId;
    this.service.getProjectBySubDomain(domainId, subDomainId, this.pageId).subscribe(data => {
      this.projectLst = data;
    });
  }

  showDetails(projectId: any): void {
    console.log("show project detail");
  }

}
