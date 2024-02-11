import { Component, EventEmitter, Output } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { Stock } from 'src/app/contracts/stock';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { StockcardService } from 'src/app/services/common/model/Stock/stockcard.service';


@Component({
  selector: 'app-stockcardcreate',
  templateUrl: './stockcardcreate.component.html',
  styleUrls: ['./stockcardcreate.component.scss']
})
export class StockcardcreateComponent extends BaseComponent {
  constructor(spiner: NgxSpinnerService, private stockcardservice: StockcardService, private alertify: AlertifyService) {
    super(spiner)
  }



  create(stockcode: HTMLInputElement, stockname: HTMLInputElement, createdby: HTMLInputElement, branchno: HTMLInputElement, companyname: HTMLInputElement) {
    this.showspinner(SpinnerType.BallScaleMultiple)
    const createstockcard: Stock = new Stock();
    createstockcard.stockCode = stockcode.value;
    createstockcard.stockname = stockname.value
    createstockcard.createdBy = createdby.value;
    createstockcard.BranchCode = parseInt(branchno.value);
    createstockcard.CompanyName = companyname.value;
    this.stockcardservice.create(createstockcard, () => {
      this.alertify.message("başarılı", { dismissOthers: true, messageType: MessageType.Success, position: Position.BottomCenter })

      this.hidespinner(SpinnerType.BallScaleMultiple)

    }, errorMesage => {

      this.alertify.message(errorMesage, { position: Position.TopRight, messageType: MessageType.Error, dismissOthers: true });
      this.hidespinner(SpinnerType.BallScaleMultiple)
    })
  }

}
