import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'http://localhost:1068/api';

  formModel = this.fb.group({
    FullName: [''],
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })

  });

  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('ConfirmPassword');
    
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value)
        confirmPswrdCtrl.setErrors({ passwordMismatch: true });
      else
        confirmPswrdCtrl.setErrors(null);
    }
  }

  advisorRegister() {
    var body = {
      FullName: this.formModel.value.FullName,
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      Password: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.BaseURI + '/Advisor/Register', body);
  }

  addAdvisorInfo(){
    var body = {
        FullName: this.formModel.value.FullName,
        
        Email: this.formModel.value.Email
      };
      return this.http.post(this.BaseURI + '/Advisor/addAdvisorInfo', body);
  }

  studentRegister() {
    var body = {
      FullName: this.formModel.value.FullName,
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      Password: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.BaseURI + '/Student/Register', body);
  }

  addStudentInfo(){
    var body = {
        FullName: this.formModel.value.FullName,
        
        Email: this.formModel.value.Email
      };
      return this.http.post(this.BaseURI + '/Student/addStudentInfo', body);
  }
}
