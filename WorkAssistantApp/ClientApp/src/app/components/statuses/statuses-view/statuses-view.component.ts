import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatBottomSheet, MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { StatusesBottomSheetComponent } from '../statuses-bottom-sheet/statuses-bottom-sheet.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-statuses-view',
  templateUrl: './statuses-view.component.html',
  styleUrls: ['./statuses-view.component.css']
})
export class StatusesViewComponent {
  displayedColumns: string[] = ['name', 'project', 'statusDescription', 'action'];
  statuses: IStatuses[];
  url: string;
  lastUpdated: Date;

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private _bottomSheet: MatBottomSheet,
    private router: Router) {


    this.url = this.baseUrl + "api/statuses";

    this.updateStatuses();
  }

  updateStatuses(): void {
    this.httpClient.get<IStatuses[]>(this.url).subscribe(result => {
      this.statuses = result;
    });
  }

  openBottomSheet(statuses: IStatuses): void {
    this._bottomSheet.open(StatusesBottomSheetComponent, {
      data: statuses
    });
  }

  onShowUser(userId: number) {
    this.router.navigate(["user/" + userId + "/status"]);
  }

}
