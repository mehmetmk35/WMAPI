import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BarcodeComponent } from './barcode.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    BarcodeComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:"barcode",component:BarcodeComponent}
    ])
  ]
})
export class BarcodeModule { }
