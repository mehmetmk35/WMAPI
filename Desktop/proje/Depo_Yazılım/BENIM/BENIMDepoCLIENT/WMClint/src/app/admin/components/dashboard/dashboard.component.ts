import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent } from 'src/app/base/base.component';
import { HubUrl } from 'src/app/contracts/hub-url';
import { ReceiveFunctions } from 'src/app/contracts/receive-functions';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { SignalRService } from 'src/app/services/common/signalr.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent extends BaseComponent implements OnInit {
  constructor(private alertify:AlertifyService,spinner:NgxSpinnerService,private signalRService:SignalRService) {
    super(spinner);
    signalRService.start(HubUrl.CreatedStockCardHub);//HubRegistration da hangi endpoint ise 
  }
  ngOnInit(): void {
   
    this.signalRService.on(ReceiveFunctions.StockCardAddMessageReceiveFunction,meesage=>
      {     
        
        this.alertify.message(meesage,{position:Position.TopRight,messageType:MessageType.Success})
      
      })
  }
}
