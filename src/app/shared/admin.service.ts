import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'http://localhost:1068/api';

  Login(formData) {
    return this.http.post(this.BaseURI + '/Admin/Login', formData);
  }

  getAdminInfo() {
    return this.http.get(this.BaseURI + '/Admin/Info');
  }
}
