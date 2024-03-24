import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TreeListComponent } from './tree-list.component';
import {  DxTreeListModule } from 'devextreme-angular';
 
 



@NgModule({
  declarations: [TreeListComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:"",component:TreeListComponent}
    ]),
    
     
    DxTreeListModule
  ] 
  
  
 
})
export class TreeListModule { }
