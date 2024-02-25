import { Component, Input } from '@angular/core';
import { NgxFileDropEntry, FileSystemFileEntry } from 'ngx-file-drop';
import { HttpClientService } from '../http-client.service';
import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { AlertifyService, MessageType, Position } from '../../admin/alertify.service';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../ui/custom-toastr.service';
import { MatDialog } from '@angular/material/dialog';
import { FileUploadDialogComponent } from 'src/app/dialog/file-upload-dialog/file-upload-dialog.component';
import { DialogService } from '../dialog/dialog.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from 'src/app/base/base.component';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent {
  constructor(private httpClientService:HttpClientService,private alertifyService:AlertifyService,private customToastrService:CustomToastrService,
              public dialog: MatDialog,private dialogService:DialogService,private spinner:NgxSpinnerService ) {}
  public files: NgxFileDropEntry[];
   @Input() options:Partial<FileUploadOptions>

  public selectedFiles(files: NgxFileDropEntry[]) {
    this.files = files;
    const fileData:FormData=new FormData();
    for(const file of files)
    (file.fileEntry as FileSystemFileEntry).file((_file:File)=>{
      fileData.append(_file.name,_file,file.relativePath)
      })
   
      this.dialogService.openDialog( {componentType:FileUploadDialogComponent,
        data:FileUploadDialogState.Yes,
        afterClosed:()=>{{
          this.spinner.show(SpinnerType.BallScaleMultiple)
          this.httpClientService.post({controler:this.options.controller,action:this.options.action,queryString:this.options.queryString,headers:new HttpHeaders({"responseType":"blob"})},fileData)
          .subscribe(data=>{
            const message:string="Dosyalar Başarıyla yüklenmiştir."
            if (this.options.isAdminPage)
            {
              this.alertifyService.message(message,
              {dismissOthers:true,
                messageType:MessageType.Success,
                position:Position.TopRight
              })
            }
            else
            {
              this.customToastrService.message(message,"Başarılı",
              {
                messageType:ToastrMessageType.Succes,
                positions:ToastrPosition.TopRight
              })
            }
            this.spinner.hide(SpinnerType.BallScaleMultiple);
          },
          (error:HttpErrorResponse)=>{
            const message:string="Dosyalar Yükleme Hata."
            if (this.options.isAdminPage)
            {
              this.alertifyService.message(message,
              {dismissOthers:true,
                messageType:MessageType.Error,
                position:Position.TopRight
              })
            }
            else
            {
              this.customToastrService.message(message,"Başarılı",
              {
                messageType:ToastrMessageType.Error,
                positions:ToastrPosition.TopRight
              })
            }
            this.spinner.hide(SpinnerType.BallScaleMultiple);
          }
          
          );
        }}
      
      })
      
     
  }

  

}
export class FileUploadOptions{
  controller?:string
  action?:string
  queryString?:string
  explanation?:string
  accept?:string
  isAdminPage?:boolean=false
}

export enum FileUploadDialogState
{
  Yes,No
}
