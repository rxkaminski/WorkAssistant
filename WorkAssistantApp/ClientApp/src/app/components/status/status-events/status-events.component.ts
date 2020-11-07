import { Component, Inject } from '@angular/core';
import { Status } from '../status';
import { MatDialog } from '@angular/material/dialog';
import { StatusEventAddEditComponent } from './status-event-add-edit.component';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { StatusUrl } from '../status-url';



@Component({
  selector: 'app-status-events',
  templateUrl: './status-events.component.html',
  styleUrls: ['./status-events.component.css']
})
export class StatusEventsComponent extends Status {
  displayedColumns: string[] = ['dateFrom', 'dateTo', 'eventType', 'project', 'description', 'action'];
  statusEvents: IStatusEvent[];
  url: string;

  constructor(private httpClient: HttpClient,
    private activatedRoute: ActivatedRoute,
    @Inject('BASE_URL') private baseUrl: string,
    private dialog: MatDialog) {
    super(activatedRoute);

    this.url = StatusUrl.create(this.baseUrl + "api", this.userId, "/status/event");

    this.updateEvents();
  }

  updateEvents(): void {
    this.httpClient.get<IStatusEvent[]>(this.url).subscribe(result => {
      this.statusEvents = result;
    }, error => console.log(error))
  }

  onAdd(): void {
    this.onEdit(null);
  }

  onEdit(event: IStatusEvent): void {
    const dialogRef = this.dialog.open(StatusEventAddEditComponent, {
      width: '500px',
      data: {
        id: (event != null ? event.Id : null),
        userId: this.userId
      }
    });

    dialogRef.afterClosed().subscribe(reloadEvents => {
      if (reloadEvents)
        this.updateEvents();
    });
  }

  onDelete(event: IStatusEvent): void {
    if (confirm("Delete?")) {
      this.httpClient.delete<IStatusEvent>(this.url + "/" + event.Id).subscribe(result => {
        console.log("removed");
        this.updateEvents();
      }, error => console.log(error));
    }
  }
}
