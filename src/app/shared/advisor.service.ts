import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { AdvisorListComponent } from '../admin/advisor-list/advisor-list.component';
import { Advisor } from './advisor.model';

@Injectable({
  providedIn: 'root'
})
export class AdvisorService {
  formData: Advisor;
  advList : Advisor[];
  
  constructor(private fb: FormBuilder, private http: HttpClient) { }
  readonly BaseURI = 'http://localhost:1068/api';
  
  getAdvisorList() {
    return this.http.get(this.BaseURI + '/Advisor/advisorList')
    .toPromise()
    .then(res => this.advList = res as Advisor[]);
  }

  getAdvisorDetails(id){
    return this.http.get(this.BaseURI + '/Advisor/advisorDetails/' + id)
    .toPromise()
    .then(res => this.advList = res as Advisor[]);
  }

  removeAdvisor(id){
    return this.http.delete(this.BaseURI + '/Advisor/removeAdvisor/' + id)
  }
}