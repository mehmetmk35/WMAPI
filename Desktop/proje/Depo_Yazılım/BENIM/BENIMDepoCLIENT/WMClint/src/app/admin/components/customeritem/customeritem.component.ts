import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent } from 'src/app/base/base.component';

@Component({
  selector: 'app-customeritem',
  templateUrl: './customeritem.component.html',
  styleUrls: ['./customeritem.component.scss']
})
export class CustomeritemComponent extends BaseComponent {
  constructor(spinner:NgxSpinnerService) {
    super(spinner);
  }
}
