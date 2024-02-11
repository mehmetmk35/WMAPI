import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomeritemComponent } from './customeritem.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    CustomeritemComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:"",component:CustomeritemComponent}
    ])
  ]
 
})
export class CustomeritemModule { }
