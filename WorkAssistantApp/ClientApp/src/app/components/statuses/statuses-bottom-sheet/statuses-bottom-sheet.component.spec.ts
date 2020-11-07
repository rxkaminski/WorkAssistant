import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatusesBottomSheetComponent } from './statuses-bottom-sheet.component';

describe('StatusesBottomSheetComponent', () => {
  let component: StatusesBottomSheetComponent;
  let fixture: ComponentFixture<StatusesBottomSheetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StatusesBottomSheetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatusesBottomSheetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
