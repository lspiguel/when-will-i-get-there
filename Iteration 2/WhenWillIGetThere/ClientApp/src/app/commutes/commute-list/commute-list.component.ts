import { Component, OnInit } from '@angular/core';
import { CommutesService } from '../commutes.service';

@Component({
  selector: 'app-commute-list',
  templateUrl: './commute-list.component.html',
  styleUrls: ['./commute-list.component.css']
})
export class CommuteListComponent implements OnInit {

  constructor(private commuteService: CommutesService) { }

    ngOnInit() {
        this.commuteService.refreshCommutes();
  }

}
