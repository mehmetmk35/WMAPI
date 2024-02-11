import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StockcardModule } from './stockcard/stockcard.module';
import { CustomeritemModule } from './customeritem/customeritem.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { OrdersModule } from './orders/orders.module';
import { BarcodeModule } from './stockcard/barcode/barcode.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    StockcardModule,
    CustomeritemModule,
    DashboardModule,
    OrdersModule,
    BarcodeModule
  ]
})
export class ComponentsModule { }
