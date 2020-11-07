import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Status } from '../status';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { CorrectDate } from '../../../shared/common/correct-date';
import { StatusUrl } from '../status-url';

@Component({
  selector: 'app-status-current',
  templateUrl: './status-current.component.html',
  styleUrls: ['./status-current.component.css']
})
export class StatusCurrentComponent extends Status {
  statusCurrent: IStatusCurrent;
  formGroup: FormGroup;
  isDaysRange: boolean;
  url: string;

  constructor(private httpClient: HttpClient,
    private activatedRoute: ActivatedRoute,
    @Inject('BASE_URL') private baseUrl: string) {
    super(activatedRoute);

    this.createForm();

    this.url = StatusUrl.create(this.baseUrl + "api", this.userId, "/status/current");

    this.updateStatus();
  }

  updateStatus(): void {
    this.httpClient.get<IStatusCurrent>(this.url).subscribe(result => {
      this.statusCurrent = result;
      this.updateForm();
    }, error => console.log(error));
  }

  onSave(): void {

    var tmpStatusCurrent = <IStatusCurrent>{};
    tmpStatusCurrent.StatusDescription = this.formGroup.value.status;
    tmpStatusCurrent.StatusAvailableUse = this.formGroup.value.isDaysRange;
    tmpStatusCurrent.StatusAvailableFrom = CorrectDate.correct(this.formGroup.value.dateFrom);
    tmpStatusCurrent.StatusAvailableTo = CorrectDate.correct(this.formGroup.value.dateTo);
    tmpStatusCurrent.StartHourOnMondayId = this.formGroup.value.startHourOnMonday.id;
    tmpStatusCurrent.StartHourOnTuesdayId = this.formGroup.value.startHourOnTuesday.id;
    tmpStatusCurrent.StartHourOnWednesdayId = this.formGroup.value.startHourOnWednesday.id;
    tmpStatusCurrent.StartHourOnThursdayId = this.formGroup.value.startHourOnThursday.id;
    tmpStatusCurrent.StartHourOnFridayId = this.formGroup.value.startHourOnFriday.id;

    var urlUpdate = StatusUrl.create(this.baseUrl + "api", this.userId, "/status/current");
    this.httpClient.post<IStatusCurrent>(urlUpdate, tmpStatusCurrent).subscribe(result => {
      this.statusCurrent = result;
      this.updateForm();
    }, error => console.log(error));

  }

  createForm() {
    this.formGroup = new FormGroup({
      status: new FormControl(''),
      isDaysRange: new FormControl(false),
      dateFrom: new FormControl(''),
      dateTo: new FormControl(''),
      startHourOnMonday: new FormControl(''),
      startHourOnTuesday: new FormControl(''),
      startHourOnWednesday: new FormControl(''),
      startHourOnThursday: new FormControl(''),
      startHourOnFriday: new FormControl(''),
      modified: new FormControl(''),
    });
  }

  updateForm() {
    this.formGroup.setValue({
      status: this.statusCurrent.StatusDescription,
      isDaysRange: this.statusCurrent.StatusAvailableUse,
      dateFrom: this.statusCurrent.StatusAvailableFrom,
      dateTo: this.statusCurrent.StatusAvailableTo,
      startHourOnMonday: {
        id: this.statusCurrent.StartHourOnMondayId
      },
      startHourOnTuesday: {
        id: this.statusCurrent.StartHourOnTuesdayId
      },
      startHourOnWednesday: {
        id: this.statusCurrent.StartHourOnWednesdayId
      },
      startHourOnThursday: {
        id: this.statusCurrent.StartHourOnThursdayId
      },
      startHourOnFriday: {
        id: this.statusCurrent.StartHourOnFridayId
      },
      modified: this.statusCurrent.ModifiedById + " / " + this.statusCurrent.ModifiedAt,
    });
  }

}
