import { Component, OnInit } from '@angular/core';
import { UserService } from './../../shared/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-tregister',
  templateUrl: './tregister.component.html',
  styleUrls: ['./tregister.component.css']
})
export class TregisterComponent implements OnInit {

  constructor(public service: UserService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.advisorRegister().subscribe(
      (res: any) => {
        if (res.succeeded) {
          this.service.addAdvisorInfo();
          this.service.formModel.reset();
          this.toastr.success('Account created!', 'Registration successful.');
        } else {
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('Username is already taken','Registration failed.');
                break;

              default:
              this.toastr.error(element.description,'Registration failed.');
                break;
            }
          });
        }
      },
      err => {
        console.log(err);
      }
    );
  }
}
