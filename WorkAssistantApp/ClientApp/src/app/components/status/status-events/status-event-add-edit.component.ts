import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CorrectDate } from '../../../shared/common/correct-date';
import { StatusUrl } from '../status-url';


@Component({
  selector: 'status-event-add-edit',
  templateUrl: 'status-event-add-edit.component.html',
})
export class StatusEventAddEditComponent {
  isEdit: boolean;
  title: string;
  actionButtonText: string;
  formGroup: FormGroup;

  statusEvent: IStatusEvent;

  constructor(
    private httpClient: HttpClient,
    public dialogRef: MatDialogRef<StatusEventAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { id: number, userId: number },
    @Inject('BASE_URL') private baseUrl: string) {

    this.isEdit = data.id != null;

    this.createForm();

    if (this.isEdit) {
      this.title = "Edit event";
      this.actionButtonText = "Update";

      var url = StatusUrl.create(this.baseUrl + "api", data.userId, "/status/event/" + this.data.id);
      this.httpClient.get<IStatusEvent>(url).subscribe(result => {
        this.statusEvent = result;
        this.updateForm(result);
      });
    }
    else {
      this.title = "Add new event";
      this.actionButtonText = "Add";

    }
  }

  createForm() {
    this.formGroup = new FormGroup({
      from: new FormControl(''),
      to: new FormControl(''),
      type: new FormControl(''),
      project: new FormControl(''),
      description: new FormControl(''),
      created: new FormControl(''),
      modified: new FormControl(''),
    });
  }

  updateForm(statusEvent: IStatusEvent) {
    this.formGroup.setValue({
      from: statusEvent.From != null ? new Date(statusEvent.From) : null,
      to: statusEvent.To != null ? new Date(statusEvent.To) : null,
      type: {
        id: statusEvent.Type != null ? statusEvent.Type.Id : ''
      },
      project: {
        id: statusEvent.Project != null ? statusEvent.Project.Id : ''
      },
      description: statusEvent.Description,

      created: statusEvent.CreatedById + " / " + statusEvent.CreatedAt,
      modified: statusEvent.ModifiedById + " / " + statusEvent.ModifiedAt,
    });
  }

  onSave(): void {

    var tmpStatusEvent = <IStatusEvent>{};
    tmpStatusEvent.From = CorrectDate.correct(this.formGroup.value.from);
    tmpStatusEvent.To = CorrectDate.correct(this.formGroup.value.to);
    tmpStatusEvent.TypeId = this.formGroup.value.type.id;
    tmpStatusEvent.ProjectId = this.formGroup.value.project.id;
    tmpStatusEvent.Description = this.formGroup.value.description;

    var url = StatusUrl.create(this.baseUrl + "api", this.data.userId, "/status/event");

    if (this.isEdit) {
      tmpStatusEvent.Id = this.statusEvent.Id;

      this.httpClient.post<IStatusEvent>(url, tmpStatusEvent).subscribe(result => {
        console.log("saved");

        this.dialogRef.close();
      }, error => console.log(error));

    } else {

      this.httpClient.put<IStatusEvent>(url, tmpStatusEvent).subscribe(result => {
        console.log("added");

        this.dialogRef.close();
      }, error => console.log(error));

    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
