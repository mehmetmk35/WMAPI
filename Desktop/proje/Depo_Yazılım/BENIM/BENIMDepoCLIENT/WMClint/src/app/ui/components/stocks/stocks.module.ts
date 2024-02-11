import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StocksComponent } from '../stocks/stocks.component'; 
import { BarcodeModule } from './barcode/barcode.module';
import { StockCardRecordModule } from './stock-card-record/stock-card-record.module';
import { StockMovementListModule } from './stock-movement-list/stock-movement-list.module';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    StocksComponent
     
  ],
  imports: [
    CommonModule,
    BarcodeModule,
    StockCardRecordModule,
    StockMovementListModule,
    RouterModule.forChild([
      {path:"",component:StocksComponent}
    ])
  ]
})
export class StocksModule { }
