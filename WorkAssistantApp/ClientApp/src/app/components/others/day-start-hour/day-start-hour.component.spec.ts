import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DayStartHourComponent } from './day-start-hour.component';

describe('DayStartHourComponent', () => {
  let component: DayStartHourComponent;
  let fixture: ComponentFixture<DayStartHourComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DayStartHourComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DayStartHourComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
