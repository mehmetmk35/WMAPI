import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StockCardRecordComponent } from './stock-card-record.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [StockCardRecordComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:"stockcardrecord",component:StockCardRecordComponent}
    ])
  ]
})
export class StockCardRecordModule { }
