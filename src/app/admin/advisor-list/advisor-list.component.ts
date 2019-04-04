import { Component, OnInit } from '@angular/core';
import { AdvisorService } from './../../shared/advisor.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-advisor-list',
  templateUrl: './advisor-list.component.html',
  styleUrls: ['./advisor-list.component.css']
})
export class AdvisorListComponent implements OnInit {
  
  constructor(private router: Router, private service: AdvisorService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.getAdvisorList();
  }

  onDetails(){
    
  }

  onDelete(Id) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.removeAdvisor(Id)
        .subscribe(res => {
          debugger;
          this.service.getAdvisorList();
          this.toastr.warning('Deleted successfully', 'Advisor Detail Register');
        },
        err => {
          debugger;
          console.log(err);
        })
    }
  }

}
