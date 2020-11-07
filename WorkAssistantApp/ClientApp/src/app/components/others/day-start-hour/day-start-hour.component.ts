import { Component, forwardRef,  Input, Inject } from '@angular/core';
import { NG_VALUE_ACCESSOR, FormGroup, FormControl, ControlValueAccessor } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { StartHour } from '../../../shared/common/start-hour';

const SELECT_VALUE_ACCESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => DayStartHourComponent),
  multi: true,
};

@Component({
  selector: 'app-day-start-hour',
  templateUrl: './day-start-hour.component.html',
  styleUrls: ['./day-start-hour.component.css'],
  providers: [SELECT_VALUE_ACCESSOR]
})
export class DayStartHourComponent implements ControlValueAccessor {
  @Input() dayLabel: string;
  startHours: StartHour[];
  url: string;

  startHourForm: FormGroup = new FormGroup({
    id: new FormControl('')
  });

  constructor(private httpClient: HttpClient,
              @Inject('BASE_URL') private baseUrl: string) {
    this.url = baseUrl + "api/status/current/starthours";
    this.updateForm();
  }

  updateForm() {
    this.httpClient.get<IStartHour[]>(this.url).subscribe((result: IStartHour[]) => {
      this.startHours = result.map(r => new StartHour(r));
    }, error => console.log(error))
  }

  writeValue(value: any): void {
    value && this.startHourForm.setValue(value, { emitEvent: false });
  }
  registerOnChange(fn: any): void {
    this.startHourForm.valueChanges.subscribe(fn);
  }
  registerOnTouched(fn: any): void {
    //throw new Error("Method not implemented.");
  }
  setDisabledState?(isDisabled: boolean): void {
    //throw new Error("Method not implemented.");
  }
}
