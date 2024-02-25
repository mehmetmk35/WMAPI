import { Component, Inject, Output } from '@angular/core';
import { BaseDialog } from '../base/base-dialog';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FileUploadOptions } from 'src/app/services/common/file-upload/file-upload.component';
 
 

@Component({
  selector: 'app-select-stock-image-dialog',
  templateUrl: './select-stock-image-dialog.component.html',
  styleUrls: ['./select-stock-image-dialog.component.scss']
})
export class SelectStockImageDialogComponent extends BaseDialog<SelectStockImageDialogComponent> {
 
constructor(dialogRef:MatDialogRef<SelectStockImageDialogComponent>,
            @Inject(MAT_DIALOG_DATA) public data:SelectStockImageState | string)  
            {super(dialogRef)}


@Output() options:Partial<FileUploadOptions>={ 
  accept:".png, .jpg, .jpeg, .gif" ,
  controller:"StockCard",
  action:"Upload",
  explanation:"Stok Resimlerini Seçin Veya Sürükleyin"
  ,isAdminPage:true,
  queryString:`StockCode=${this.data}`

}

}
export enum SelectStockImageState
{
  Close
}
