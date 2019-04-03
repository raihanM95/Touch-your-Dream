import { Component, OnInit } from '@angular/core';
import { StudentService } from './../../shared/student.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {

  constructor(private router: Router, private service: StudentService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.getStudentList();
  }

  onDelete(Id) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.removeStudent(Id)
        .subscribe(res => {
          debugger;
          this.service.getStudentList();
          this.toastr.warning('Deleted successfully', 'Student Detail Register');
        },
        err => {
          debugger;
          console.log(err);
        })
    }
  }

}
