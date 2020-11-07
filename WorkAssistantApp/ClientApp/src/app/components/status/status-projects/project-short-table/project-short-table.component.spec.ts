import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectShortTableComponent } from './project-short-table.component';

describe('ProjectShortTableComponent', () => {
  let component: ProjectShortTableComponent;
  let fixture: ComponentFixture<ProjectShortTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectShortTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectShortTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
