import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StockMovementListComponent } from './stock-movement-list.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [StockMovementListComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:"Stockcardmovement",component:StockMovementListComponent}
    ])
  ]
})
export class StockMovementListModule { }
