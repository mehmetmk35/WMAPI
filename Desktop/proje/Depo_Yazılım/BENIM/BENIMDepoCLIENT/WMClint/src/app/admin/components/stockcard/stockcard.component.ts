import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent } from 'src/app/base/base.component';

@Component({
  selector: 'app-stockcard',
  templateUrl: './stockcard.component.html',
  styleUrls: ['./stockcard.component.scss']
})
export class StockcardComponent extends BaseComponent {
  constructor(spinner:NgxSpinnerService) {
    super(spinner);
  }
}
