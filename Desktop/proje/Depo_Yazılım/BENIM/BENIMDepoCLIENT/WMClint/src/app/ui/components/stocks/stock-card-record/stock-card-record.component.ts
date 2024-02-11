import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent } from 'src/app/base/base.component';

@Component({
  selector: 'app-stock-card-record',
  templateUrl: './stock-card-record.component.html',
  styleUrls: ['./stock-card-record.component.scss']
})
export class StockCardRecordComponent extends BaseComponent {
  constructor(spinner:NgxSpinnerService) {
    super(spinner);
  }
}
