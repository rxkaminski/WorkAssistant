import { Component, Inject } from '@angular/core';
import { Status } from '../status';
import { ActivatedRoute } from '@angular/router';
import { StatusUrl } from '../status-url';

@Component({
  selector: 'app-status-projects',
  templateUrl: './status-projects.component.html',
  styleUrls: ['./status-projects.component.css']
})
export class StatusProjectsComponent extends Status {

  panelOpenState = false;
  managmendProjects: IProjectShort[];
  projects: IProjectShort[];

  mangmendProjectsUrl: string;
  projectsUrl: string;

  constructor(private activatedRoute: ActivatedRoute,
    @Inject('BASE_URL') private baseUrl: string) {
    super(activatedRoute);

    this.mangmendProjectsUrl = StatusUrl.create(baseUrl + "api", this.userId, "/project/managedBy");
    this.projectsUrl = StatusUrl.create(baseUrl + "api", this.userId, "/status/event/projectFor");
  }

}
