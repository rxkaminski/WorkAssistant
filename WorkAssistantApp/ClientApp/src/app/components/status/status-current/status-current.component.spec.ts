import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatusCurrentComponent } from './status-current.component';

describe('StatusCurrentComponent', () => {
  let component: StatusCurrentComponent;
  let fixture: ComponentFixture<StatusCurrentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StatusCurrentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatusCurrentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
