import { NgModule } from '@angular/core';

import { MatSliderModule, MatSlider } from '@angular/material/slider';
import { MatTabsModule } from '@angular/material/tabs';
import { MatIconModule } from '@angular/material/icon';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSelectModule } from '@angular/material/select';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialogModule } from '@angular/material/dialog';
import { MatExpansionModule } from '@angular/material/expansion';

import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { MatBottomSheetModule } from '@angular/material/bottom-sheet';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';

const MaterialComponents = [MatSliderModule,
  MatTabsModule,
  MatIconModule,
  MatSlideToggleModule,
  MatInputModule,
  MatDatepickerModule,
  MatSelectModule,
  MatCardModule,
  MatButtonModule,
  MatTableModule,
  MatTooltipModule,
  MatDialogModule,
  MatExpansionModule,
  MatBottomSheetModule,
  MatDividerModule,
  MatListModule,

  MatMomentDateModule
]

@NgModule({
  imports: [MaterialComponents],
  exports: [MaterialComponents],
  providers: [
    MatDatepickerModule,
    MatMomentDateModule,
    //{ provide: MAT_DATE_LOCALE, useValue: 'en-GB' },
    //{ provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE] },
    //{ provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
    { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: true } }
  ]
})
export class MaterialModule { }
