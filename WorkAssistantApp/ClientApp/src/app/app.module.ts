import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';


import { SubMenuComponent } from './components/sub-menu/sub-menu.component';
import { DayStartHourComponent } from './components/others/day-start-hour/day-start-hour.component';
import { ProjectPickerComponent } from './components/others/project-picker/project-picker.component';
import { StatusEventTypePickerComponent } from './components/others/status-event-type-picker/status-event-type-picker.component';
import { UserPickerComponent } from './components/others/user-picker/user-picker.component';


import { StatusCurrentComponent } from './components/status/status-current/status-current.component';
import { StatusEventsComponent } from './components/status/status-events/status-events.component';
import { StatusEventAddEditComponent } from './components/status/status-events/status-event-add-edit.component';
import { StatusProjectsComponent } from './components/status/status-projects/status-projects.component';
import { StatusHistoryComponent } from './components/status/status-history/status-history.component';

import { ProjectShortTableComponent } from './components/status/status-projects/project-short-table/project-short-table.component';
import { ProjectsViewComponent } from './components/projects/projects-view/projects-view.component';
import { ProjectAddEditComponent } from './components/projects/projects-view/project-add-edit.component';


import { DefaultDatePipe } from './pipe/default-date.pipe';
import { StatusesViewComponent } from './components/statuses/statuses-view/statuses-view.component';
import { StatusesBottomSheetComponent } from './components/statuses/statuses-bottom-sheet/statuses-bottom-sheet.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,

    SubMenuComponent,
    DayStartHourComponent,
    ProjectPickerComponent,
    StatusEventTypePickerComponent,
    UserPickerComponent,
    
    StatusCurrentComponent,
    StatusEventsComponent,
    StatusEventAddEditComponent,
    StatusProjectsComponent,
    StatusHistoryComponent,


    ProjectShortTableComponent,
    ProjectsViewComponent,
    ProjectAddEditComponent,

    DefaultDatePipe,

    StatusesViewComponent,

    StatusesBottomSheetComponent,
  ],
  entryComponents: [
    StatusEventAddEditComponent,
    ProjectAddEditComponent,
    StatusesBottomSheetComponent
  ],

  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: StatusesViewComponent, pathMatch: 'full' },
      { path: 'status', redirectTo: "status/current" , pathMatch: 'full' },
      { path: 'status/current', component: StatusCurrentComponent },
      { path: 'status/events', component: StatusEventsComponent },
      { path: 'status/projects', component: StatusProjectsComponent },
      { path: 'status/history', component: StatusHistoryComponent },

      { path: 'user/:userId/status', redirectTo: "user/:userId/status/current" , pathMatch: 'full' },
      { path: 'user/:userId/status/current', component: StatusCurrentComponent },
      { path: 'user/:userId/status/events', component: StatusEventsComponent },
      { path: 'user/:userId/status/projects', component: StatusProjectsComponent },
      { path: 'user/:userId/status/history', component: StatusHistoryComponent },


      { path: 'projects', redirectTo: "projects/view", pathMatch: 'full' },
      { path: 'projects/view', component: ProjectsViewComponent },

    ]),
    BrowserAnimationsModule,

    MaterialModule
  ],
  providers: [
    
  ],



  bootstrap: [AppComponent]
})
export class AppModule { }

