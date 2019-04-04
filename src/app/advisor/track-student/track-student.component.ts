import { Component, OnInit } from '@angular/core';
import { MapsService } from './../../shared/maps.service'

@Component({
  selector: 'app-track-student',
  templateUrl: './track-student.component.html',
  styleUrls: ['./track-student.component.css']
})
export class TrackStudentComponent implements OnInit {

  lat: string = '';
  lng: string = '';

  location: Object;

  constructor(private map: MapsService) { }

  ngOnInit() {
    this.map.getLocation().subscribe(data => {
      console.log(data);
      this.lat = data.latitude;
      this.lng = data.longitude;
    })
  }

}
