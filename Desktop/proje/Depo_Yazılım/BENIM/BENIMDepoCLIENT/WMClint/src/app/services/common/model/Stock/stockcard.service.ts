import { Injectable } from '@angular/core';
import { HttpClientService } from '../../http-client.service';
import { Stock } from 'src/app/contracts/stock';
import { HttpErrorResponse } from '@angular/common/http';
import { StockList } from 'src/app/contracts/stockList/stockList';
import { Observable, firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StockcardService {

  constructor( private httpservice:HttpClientService) { }

  create(stockcard:Stock,callBack?:any,errorCallBack?:any ){
  
    this.httpservice.post<Stock>({controler:"StockCard"},stockcard)
    .subscribe(result=>{
      callBack();
       
    },(errorResponse?:HttpErrorResponse)=>{
      const _error:Array<{key:string,value:Array<string>}>=errorResponse.error;
      let message="";
      try {
        _error.forEach((v,index)=>
        {
           v.value.forEach((_v,_index)=>{
            message=`${_v}<br>`
           });
        });
      } catch (error) {
        message="Kayıt esnasında hata"
      }
     
      errorCallBack(message);
    });
  }
  //toPromise obervableye dönüştürdüm ve http ile attığım isteği beklemiş oldum 
   async read(paginator:Partial<Paginator>,succesCallBack?:()=>void,errorCallBack?:(errormesage:string)=>void,):Promise<{totalCount:number,stockList:StockList[]}>
   {
   const stockCardList:Promise<{totalCount:number,stockList:StockList[]}>= this.httpservice.get<{totalCount:number,stockList:StockList[]}>({controler:"StockCard",queryString:`Page=${paginator.page}&size=${paginator.size}`}).toPromise()
  
   stockCardList.then(x=>succesCallBack()).catch((errormesage:HttpErrorResponse)=>errorCallBack(errormesage.message) );
  return await stockCardList;
  }

   async delete(stockCode:string)
  {
     const deleteObservable :Observable<any> =this.httpservice.delete<any>({controler:"StockCard"},stockCode);

     await firstValueFrom(deleteObservable);
  }
}
export  class Paginator{
  page:number;
  size:number;
}
