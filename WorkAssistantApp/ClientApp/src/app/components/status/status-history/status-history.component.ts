import { Component } from '@angular/core';
import { Status } from '../status';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-status-history',
  templateUrl: './status-history.component.html',
  styleUrls: ['./status-history.component.css']
})
export class StatusHistoryComponent extends Status{

  constructor(private activatedRoute: ActivatedRoute) {
      super(activatedRoute);
  }

}
