import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent } from 'src/app/base/base.component';
import { Stock } from 'src/app/contracts/stock';
import { HttpClientService } from 'src/app/services/common/http-client.service';

@Component({
  selector: 'app-stocks',
  templateUrl: './stocks.component.html',
  styleUrls: ['./stocks.component.scss']
})
export class StocksComponent extends BaseComponent implements OnInit  {
  constructor(spinner:NgxSpinnerService,  private httpClientService:HttpClientService) {
    super(spinner);
  }
  ngOnInit(): void {
      //this.httpClientService.get<Stock[]>({controler:"StockCardRecord"}).subscribe(a=>console.log(a));
       
      //  this.httpClientService.post({controler:"test"}
      //  ,{
      //   name:"test2",
      //   stock:"test2",
      //   price:15}).subscribe()

      //  this.httpClientService.put({controler:"test"}
      //  ,{
      //   name:"test2",
      //   stock:"test2",
      //   price:15}).subscribe()

        //  this.httpClientService.delete({controler:"test"},"test").subscribe()
        //this.httpClientService.get({baseurl:"https://jsonplaceholder.typicode.com",controler:"posts"}).subscribe(a=>console.log(a));
        // this.httpClientService.get({fullEndPoint:"https://jsonplaceholder.typicode.com/posts"}).subscribe(a=>console.log(a));
         
  }
}
