import { Component, OnInit, Input } from '@angular/core';
import { Commute } from '../../models/commute';

@Component({
  selector: '.app-commute-item',
  templateUrl: './commute-item.component.html',
  styleUrls: ['./commute-item.component.css']
})
export class CommuteItemComponent implements OnInit {
  @Input() commute: Commute;

  constructor() { }

  ngOnInit() {
  }

}
