import { Component, OnInit, Output } from '@angular/core';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { FileUploadOptions } from 'src/app/services/common/file-upload/file-upload.component';
@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {
  constructor(private alertify:AlertifyService) {}
  //fileUploadOptions
  @Output() fileUploadOptions:Partial<FileUploadOptions>={
    action:"upload",
    controller:"stockCard",
    isAdminPage:true,
    explanation:"Resimleri Yükleyin Veya Seçin",
    accept:".png, .jpg, .jpeg, .json"
  }
  //fileUploadOptions
  ngOnInit(): void {
   this.alertify.message("test1",{position:Position.BottomCenter ,messageType:MessageType.Message})
  }

}


