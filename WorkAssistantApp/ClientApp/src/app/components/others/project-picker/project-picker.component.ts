import { Component, OnInit, Inject, forwardRef } from '@angular/core';
import { ControlValueAccessor, FormGroup, FormControl, NG_VALUE_ACCESSOR } from '@angular/forms';
import { ProjectShort } from '../../../shared/projects/project-short';
import { HttpClient } from '@angular/common/http';

const PROJECT_PICKER_VALUE_ACCESSOR: any = {
  provide: NG_VALUE_ACCESSOR,
  useExisting: forwardRef(() => ProjectPickerComponent),
  multi: true,
};

@Component({
  selector: 'app-project-picker',
  templateUrl: './project-picker.component.html',
  styleUrls: ['./project-picker.component.css'],
  providers: [PROJECT_PICKER_VALUE_ACCESSOR]
})
export class ProjectPickerComponent implements ControlValueAccessor, OnInit {

  projects: ProjectShort[];
  projectForm: FormGroup = new FormGroup({
    id: new FormControl('')
  });
  url: string;

  constructor(private httpClient: HttpClient,
              @Inject('BASE_URL') private baseUrl: string) {
    this.url = baseUrl + "api/project/picker";
    this.updateForm();
  }

  updateForm() {
    this.httpClient.get<IProjectShort[]>(this.url).subscribe((result : ProjectShort[]) => {
      this.projects = result.map(r => new ProjectShort(r));
    }, error => console.log(error))
  }

  writeValue(obj: any): void {
    obj && this.projectForm.setValue(obj, { emitEvent: false });
  }
  registerOnChange(fn: any): void {
    this.projectForm.valueChanges.subscribe(fn);
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
