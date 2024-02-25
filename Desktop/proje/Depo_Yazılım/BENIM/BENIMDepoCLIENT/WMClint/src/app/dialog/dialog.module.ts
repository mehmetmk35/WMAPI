import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';
import {  MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { FileUploadModule } from '../services/common/file-upload/file-upload.module';
import { SelectStockImageDialogComponent } from './select-stock-image-dialog/select-stock-image-dialog.component';
 
 



@NgModule({
  declarations: [DeleteDialogComponent,SelectStockImageDialogComponent],
  imports: [
    CommonModule,
    
    MatDialogModule,MatButtonModule, 
    FileUploadModule
    
   ]
  
})
export class DialogModule { }
