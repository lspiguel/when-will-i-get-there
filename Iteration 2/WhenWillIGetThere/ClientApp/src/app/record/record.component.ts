import { Component, OnInit } from '@angular/core';
import { CommutesService } from '../services/commutes.service';

@Component({
  selector: 'app-record',
  templateUrl: './record.component.html',
  styleUrls: ['./record.component.css']
})
export class RecordComponent implements OnInit {

    constructor(private commuteService: CommutesService) { }

    ngOnInit() {
        this.commuteService.refreshRoutes();
  }

}
