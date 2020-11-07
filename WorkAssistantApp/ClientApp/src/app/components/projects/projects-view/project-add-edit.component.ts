import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CorrectDate } from '../../../shared/common/correct-date';


@Component({
  selector: 'project-add-edit',
  templateUrl: 'project-add-edit.component.html',
})
export class ProjectAddEditComponent {
  isEdit: boolean;
  title: string;
  actionButtonText: string;
  formGroup: FormGroup;

  project: IProject;

  constructor(
    private httpClient: HttpClient,
    public dialogRef: MatDialogRef<ProjectAddEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { id: number },
    @Inject('BASE_URL') private baseUrl: string) {

    this.isEdit = data.id != null;

    this.createForm();

    if (this.isEdit) {
      this.title = "Edit project";
      this.actionButtonText = "Update";

      var url = this.baseUrl + "api/project/" + this.data.id;
      this.httpClient.get<IProject>(url).subscribe(result => {
        this.project = result;
        this.updateForm(result);
      });
    }
    else {
      this.title = "Add new project";
      this.actionButtonText = "Add";

    }
  }

  createForm() {
    this.formGroup = new FormGroup({
      number: new FormControl(''),
      title: new FormControl(''),
      description: new FormControl(''),
      start: new FormControl(''),
      end: new FormControl(''),
      projectManager: new FormControl(''),
      created: new FormControl(''),
      modified: new FormControl('')
    });
  }

  updateForm(project: IProject) {
    this.formGroup.setValue({
      number: project.Number,
      title: project.Title,
      description: project.Description,
      start: project.Start != null ? new Date(project.Start) : null,
      end: project.End != null ? new Date(project.End) : null,
      projectManager: {
        id: project.ProjectManager != null ? project.ProjectManager.Id : ''
      },

      created: project.CreatedById + " / " + project.CreatedAt,
      modified: project.ModifiedById + " / " + project.ModifiedAt,
    });
  }

  onSave(): void {

    var tmpProject = <IProject>{};
    tmpProject.Number = this.formGroup.value.number;
    tmpProject.Title = this.formGroup.value.title;
    tmpProject.Description = this.formGroup.value.description;
    tmpProject.Start = CorrectDate.correct(this.formGroup.value.start);
    tmpProject.End = CorrectDate.correct(this.formGroup.value.end);
    tmpProject.ProjectManagerId = this.formGroup.value.projectManager.id ? this.formGroup.value.projectManager.id : null;

    var url = this.baseUrl + "api/project";

    if (this.isEdit) {
      tmpProject.Id = this.project.Id;

      this.httpClient.post<IProject>(url, tmpProject).subscribe(result => {
        console.log("saved");

        this.dialogRef.close();
      }, error => console.log(error));

    } else {

      this.httpClient.put<IProject>(url, tmpProject).subscribe(result => {
        console.log("added");

        this.dialogRef.close();
      }, error => console.log(error));

    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
