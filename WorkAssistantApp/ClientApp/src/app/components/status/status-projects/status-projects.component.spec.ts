import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatusProjectsComponent } from './status-projects.component';

describe('StatusProjectsComponent', () => {
  let component: StatusProjectsComponent;
  let fixture: ComponentFixture<StatusProjectsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StatusProjectsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatusProjectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
