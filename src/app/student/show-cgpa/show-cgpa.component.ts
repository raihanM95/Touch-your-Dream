import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-show-cgpa',
  templateUrl: './show-cgpa.component.html',
  styleUrls: ['./show-cgpa.component.css']
})
export class ShowCgpaComponent implements OnInit {

  LineChart=[];

  constructor() { }

  ngOnInit() {
    // Line chart:
    this.LineChart = new Chart('lineChart', {
      type: 'line',
      data: {
        labels: ["1st", "2nd", "3rd", "4th", "5th", "6th","7th","8th","9th","10th","11th","12th"],
        datasets: [{
          label: 'CGPA',
          data: [3.9, 3.7, 3.8, 3.6, 3.8, 3.7, 3.7, 3.5, 3.7, 3, 3.5, 4],
          fill:false,
          lineTension:0.2,
          borderColor:"red",
          borderWidth: 1
        }]
      }, 
      options: {
        title:{
          text:"Semester wise CGPA scalse",
          display:true
        },
        scales: {
          yAxes: [{
            ticks: {
              beginAtZero:true
            }
          }]
        }
      }
    });
  }
}
