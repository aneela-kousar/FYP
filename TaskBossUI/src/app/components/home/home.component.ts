import { Component, OnInit } from '@angular/core';
import { SubDomainService } from 'src/app/service/sub-domain.service';
import { SubDomain } from 'src/app/models/sub-domain.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  subDomainLst: SubDomain[] = new Array<SubDomain>();
  public show: number = 0;

  constructor(public svcSubDomain: SubDomainService) { }

  ngOnInit(): void {
  }

  onChangeDomain(clickEvent: any): void {
    this.show = clickEvent;

    this.svcSubDomain.getSubDomains(clickEvent).subscribe(data => {
      this.subDomainLst = data;
    });
  }

}
