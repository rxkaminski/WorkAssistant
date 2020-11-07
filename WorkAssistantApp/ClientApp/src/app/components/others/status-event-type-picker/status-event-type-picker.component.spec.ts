import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatusEventTypePickerComponent } from './status-event-type-picker.component';

describe('StatusEventTypePickerComponent', () => {
  let component: StatusEventTypePickerComponent;
  let fixture: ComponentFixture<StatusEventTypePickerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StatusEventTypePickerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatusEventTypePickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
