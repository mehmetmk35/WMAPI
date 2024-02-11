import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StocksModule } from './stocks/stocks.module';
import { HomeModule } from './home/home.module';
import { BarcodeModule } from './stocks/barcode/barcode.module';




@NgModule({
  declarations: [
   
  ],
  imports: [
    CommonModule,
    StocksModule ,    
    HomeModule   
  ]
})
export class ComponentsModule { }
