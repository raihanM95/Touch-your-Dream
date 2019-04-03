import { Component, OnInit } from '@angular/core';
import { StudentService } from './../../shared/student.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-header',
  templateUrl: './student-header.component.html',
  styleUrls: ['./student-header.component.css']
})
export class StudentHeaderComponent implements OnInit {
  studentLog;

  constructor(private router: Router, private service: StudentService) { }

  ngOnInit() {
    this.service.getStudentLog().subscribe(
      res => {
        this.studentLog = res;
      },
      err => {
        console.log(err);
      },
    );
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/student/slogin']);
  }
}
