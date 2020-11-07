import { Component, OnInit, Inject, forwardRef } from '@angular/core';
import { ControlValueAccessor, FormGroup, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ApplicationUserShort } from '../../../shared/common/application-user-short';

const PROJECT_PICKER_VALUE_ACCESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => UserPickerComponent),
  multi: true,
};

@Component({
  selector: 'app-user-picker',
  templateUrl: './user-picker.component.html',
  styleUrls: ['./user-picker.component.css'],
  providers: [PROJECT_PICKER_VALUE_ACCESSOR]
})
export class UserPickerComponent implements ControlValueAccessor, OnInit {

  users: ApplicationUserShort[];
  userForm: FormGroup = new FormGroup({
    id: new FormControl('')
  });
  url: string;

  constructor(private httpClient: HttpClient,
              @Inject('BASE_URL') private baseUrl: string) {
    this.url = baseUrl + "api/user/picker";
    this.updateForm();
  }

  updateForm() {
    this.httpClient.get<IApplicationUserShort[]>(this.url).subscribe((result : ApplicationUserShort[]) => {
      this.users = result.map(r => new ApplicationUserShort(r));
    }, error => console.log(error))
  }

  writeValue(obj: any): void {
    obj && this.userForm.setValue(obj, { emitEvent: false });
  }
  registerOnChange(fn: any): void {
    this.userForm.valueChanges.subscribe(fn);
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
