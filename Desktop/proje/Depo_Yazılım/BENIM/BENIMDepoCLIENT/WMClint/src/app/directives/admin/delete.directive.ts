import { HttpErrorResponse } from '@angular/common/http';
import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from 'src/app/base/base.component';
import { DeleteDialogComponent, DeleteState } from 'src/app/dialog/delete-dialog/delete-dialog.component';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { DialogService } from 'src/app/services/common/dialog/dialog.service';
import { HttpClientService } from 'src/app/services/common/http-client.service';
import { StockcardService } from 'src/app/services/common/model/Stock/stockcard.service';
declare  var $:any

@Directive({
  selector: '[Delete]'
})

export class DeleteDirective   {
//ElementRef directive ile çağırdığım HTML nesnesini temsil eder
  constructor(private element:ElementRef,
              private _render:Renderer2,
              private HttpClientService:HttpClientService,
              private spinner:NgxSpinnerService,
              public dialog: MatDialog,
              private alertify:AlertifyService,
              private dialogService:DialogService)  
             

  {
     
    const img:HTMLImageElement=_render.createElement("img");
    img.setAttribute("src","../../../assets/delete.png");
    img.setAttribute("style","cursor:pointer;");
    img.width=25;
    img.height=25;
    _render.appendChild(element.nativeElement,img);
    
  }
  @Input() id :string;
  @Input() controller :string;
  @Output() listCallBack:EventEmitter<any> = new EventEmitter();
  @HostListener("click")
    async onclick()
    {
      this.dialogService.openDialog({componentType:DeleteDialogComponent,
      data:DeleteState.Yes,
      afterClosed:async()=>{
    
        this.spinner.show(SpinnerType.BallScaleMultiple)
        const td :HTMLTableCellElement=this.element.nativeElement;
  
          this.HttpClientService.delete({controler:this.controller},this.id).subscribe(a=>{
            $(td.parentElement).animate({
              opacity:0,
              left:"+=50",
              height:"toogle"
            }
            ,700,()=>{
              this.alertify.message("Silme İşlemi başarılı",{messageType:MessageType.Success,position:Position.TopRight})
              this.listCallBack.emit();
            });
          },(error:HttpErrorResponse)=>{
            this.alertify.message("Silme İşlemi Sırasında Hata",{messageType:MessageType.Error,position:Position.TopRight})
            this.spinner.hide(SpinnerType.BallScaleMultiple)
          })     
      }
      })
    
      
    }

     
}

