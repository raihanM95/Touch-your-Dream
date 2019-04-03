import { Component, OnInit } from '@angular/core';
import { AdvisorService } from './../../shared/advisor.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-advisor-header',
  templateUrl: './advisor-header.component.html',
  styleUrls: ['./advisor-header.component.css']
})
export class AdvisorHeaderComponent implements OnInit {
  advisorLog;

  constructor(private router: Router, private service: AdvisorService) { }

  ngOnInit() {
    this.service.getAdvisorLog().subscribe(
      res => {
        this.advisorLog = res;
      },
      err => {
        console.log(err);
      },
    );
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/advisor/tlogin']);
  }
}
