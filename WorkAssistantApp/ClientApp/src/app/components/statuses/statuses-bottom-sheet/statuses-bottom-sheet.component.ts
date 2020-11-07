import { Component, Inject } from '@angular/core';
import { MatBottomSheetRef } from '@angular/material/bottom-sheet';
import { MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';

@Component({
  selector: 'app-statuses-bottom-sheet',
  templateUrl: './statuses-bottom-sheet.component.html',
  styleUrls: ['./statuses-bottom-sheet.component.css']
})
export class StatusesBottomSheetComponent {

  constructor(private _bottomSheetRef: MatBottomSheetRef<StatusesBottomSheetComponent>,
    @Inject(MAT_BOTTOM_SHEET_DATA) private data: IStatuses
  ) { }


}
