import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutModule } from './layout/layout.module';
import { ComponentsModule } from './components/components.module';
import { DialogModule } from '../dialog/dialog.module';
 



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    LayoutModule,
    ComponentsModule ,
    DialogModule
     
  ],
  exports:[
    LayoutModule
  ]
})
export class AdminModule { }
