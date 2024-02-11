import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent } from 'src/app/base/base.component';

@Component({
  selector: 'app-stock-movement-list',
  templateUrl: './stock-movement-list.component.html',
  styleUrls: ['./stock-movement-list.component.scss']
})
export class StockMovementListComponent extends BaseComponent {
  constructor(spinner:NgxSpinnerService) {
    super(spinner);
  }
}
