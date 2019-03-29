import { Component, OnInit } from '@angular/core';
import { AdminService } from './../../shared/admin.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin-header',
  templateUrl: './admin-header.component.html',
  styleUrls: ['./admin-header.component.css']
})
export class AdminHeaderComponent implements OnInit {
  adminDetails;

  constructor(private router: Router, private service: AdminService) { }

  ngOnInit() {
    this.service.getAdminInfo().subscribe(
      res => {
        this.adminDetails = res;
      },
      err => {
        console.log(err);
      },
    );
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/admin/alogin']);
  }
}
