import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HubConnectionState } from '@microsoft/signalr';

@Injectable({
  providedIn: 'root'
})
// npm install @microsoft/signalr
export class SignalRService {

  private _connection: HubConnection //bağlantımı tutacak 
  get connection(): HubConnection {
    return this._connection;
  }

  start(hubUrl: string) //başlatılmış bir hub vericek
  {
    if (!this.connection || this.connection?.state == HubConnectionState.Disconnected) {
      const builder: HubConnectionBuilder = new HubConnectionBuilder();
      const hubConnection = builder.withUrl(hubUrl)
        .withAutomaticReconnect()
        .build();

      //bağlantıyı başlatalım
      hubConnection.start()
        .then(() => console.log("başlantı başarılı Hub")) 
        .catch(error => setTimeout(() => { this.start(hubUrl), 2000 }));//başarısız ise 2s bir tekrar istek at bağlatıyı sağla 
        this._connection = hubConnection;//diper çalışmalarda bu bağlantıyı alıyorz lazım olucak 
      
        
    }
    //bağlantı olduğunda ama bağlantıda koptuğunda işlem yapılmak isteniyor ise 
    this._connection.onreconnected(connectionId=>console.log("Reconnected"))//bağlı olduğu bilgisayarın connectionId sini veriyor bize 
    this._connection.onreconnecting(error=>console.log("onreconnecting")); 
    this._connection.onclose(error=>console.log("close Reconnectionn"));//bağlanmayı tekrardan denendi ama bağlantı sağlanamadığı durumda kullanılır 
     
  }
  invoke(procedureName:string,message:string,successCallBack?:(value)=>void,errorCallBack?:(error)=>void) 
  //client'ta yapılan bir işlem sonrası diğer client'lara event  fırlatması 
  //procedureName  tetiklemesini isteğimiz metod adı olması lazım  Backend'teki HubServices tekı metod adı olması lazım
  {
    this.connection.invoke(procedureName,message)
    .then(successCallBack)
    .catch(errorCallBack);
  }


  // "..." c#daki params'a karşılık geliyor 
  on(procedureName:string,callBack:(...message:any)=>void) //Serverdan gelen mesajlar RunTime'da yakalatacak ve messajı verecek 
  {
this.connection.on(procedureName,callBack)
  }
}
