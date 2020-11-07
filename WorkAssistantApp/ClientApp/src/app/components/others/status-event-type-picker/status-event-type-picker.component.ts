import { Component, OnInit, forwardRef, Inject } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor, FormGroup, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

const STATUS_EVENT_TYPE_VALUE_ACCESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => StatusEventTypePickerComponent),
  multi: true
};

@Component({
  selector: 'app-status-event-type-picker',
  templateUrl: './status-event-type-picker.component.html',
  styleUrls: ['./status-event-type-picker.component.css'],
  providers: [STATUS_EVENT_TYPE_VALUE_ACCESSOR]
})
export class StatusEventTypePickerComponent implements ControlValueAccessor, OnInit {
  statusEventType: IStatusEventType[];
  statusEventTypeForm: FormGroup = new FormGroup({
    id: new FormControl('')
  });
  url: string;

  constructor(private httpClient: HttpClient,
              @Inject('BASE_URL') private baseUrl: string
  ) {
    this.url = baseUrl + 'api/status/event/types';
    this.updateForm();
  }
  updateForm() {
    this.httpClient.get<IStatusEventType[]>(this.url).subscribe(result => {
      this.statusEventType = result;
    })
  }

  writeValue(obj: any): void {
    obj && this.statusEventTypeForm.setValue(obj, { emitEvent: false });
  }
  registerOnChange(fn: any): void {
    this.statusEventTypeForm.valueChanges.subscribe(fn);
  }
  registerOnTouched(fn: any): void {
    //throw new Error("Method not implemented.");
  }
  setDisabledState?(isDisabled: boolean): void {
    //throw new Error("Method not implemented.");
  }

  ngOnInit() {
  }

}
