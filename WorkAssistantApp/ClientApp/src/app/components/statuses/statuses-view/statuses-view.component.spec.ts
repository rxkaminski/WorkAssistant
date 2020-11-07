import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatusesViewComponent } from './statuses-view.component';

describe('StatusesComponent', () => {
  let component: StatusesViewComponent;
  let fixture: ComponentFixture<StatusesViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [StatusesViewComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatusesViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
