import { Component, OnInit } from '@angular/core';
import { AdminService } from './../../shared/admin.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-alogin',
  templateUrl: './alogin.component.html',
  styleUrls: ['./alogin.component.css']
})
export class AloginComponent implements OnInit {

  formModel = {
    UserName: '',
    Password: ''
  }

  constructor(private service: AdminService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('/ahome');
  }

  onSubmit(form: NgForm) {
    this.service.Login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/ahome');
      },
      err => {
        if (err.status == 400)
          this.toastr.error('Incorrect username or password.', 'Authentication failed.');
        else
          console.log(err);
      }
    );
  }
}
