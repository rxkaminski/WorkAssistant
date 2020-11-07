import { Component, Inject } from '@angular/core';
import { Projects } from '../projects';
import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';
import { ProjectAddEditComponent } from './project-add-edit.component';

@Component({
  selector: 'app-projects',
  templateUrl: './projects-view.component.html',
  styleUrls: ['./projects-view.component.css']
})
export class ProjectsViewComponent extends Projects {
  displayedColumns: string[] = ['number', 'title', 'start', 'end', 'action'];

  projects: IProject[];
  url: string;

  constructor(private httpClient: HttpClient,
    @Inject('BASE_URL') private baseUrl: string,
    private dialog: MatDialog) {
    super();

    this.url = baseUrl + "api/project";
    this.updateProjects();
  }

  updateProjects(): void {
    this.httpClient.get<IProject[]>(this.url).subscribe(result => {
      this.projects = result;
    })
  }

  onAdd(): void {
    this.onEdit(null);
  }

  onEdit(project: IProject): void {
    const dialogRef = this.dialog.open(ProjectAddEditComponent, {
      width: '500px',
      data: {
        id: (project != null ? project.Id : null)
      }
    });

    dialogRef.afterClosed().subscribe(reloadProjects => {
      if (reloadProjects)
        this.updateProjects();
    });
  }

  onDelete(project: IProject): void {
    if (confirm("Delete?")) {
      this.httpClient.delete<IProject>(this.url + "/" + project.Id).subscribe(result => {
        console.log("removed");
        this.updateProjects();
      }, error => console.log(error));
    }
  }

}
