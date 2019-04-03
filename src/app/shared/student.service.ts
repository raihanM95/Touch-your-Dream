import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Student } from './student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  formData: Student;
  stdntList : Student[];
  
  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'http://localhost:1068/api';
  
  Login(formData) {
    return this.http.post(this.BaseURI + '/Student/Login', formData);
  }

  getStudentLog() {
    return this.http.get(this.BaseURI + '/Student/Log');
  }

  getStudentList() {
    return this.http.get(this.BaseURI + '/Student/studentList')
    .toPromise()
    .then(res => this.stdntList = res as Student[]);
  }

  getStudentDetails(id){
    return this.http.get(this.BaseURI + '/Student/studentDetails/' + id)
    .toPromise()
    .then(res => this.stdntList = res as Student[]);
  }

  removeStudent(id){
    return this.http.delete(this.BaseURI + '/Student/removeStudent/' + id)
  }
}