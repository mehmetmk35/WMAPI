import { Injectable } from '@angular/core';
import { HttpClientService } from '../../http-client.service';
import { User } from 'src/app/entities/user';
import { Create_User } from 'src/app/contracts/User/create_user';
import { Observable, firstValueFrom, observable } from 'rxjs';
import { Token } from 'src/app/contracts/User/token';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from 'src/app/services/ui/custom-toastr.service';
import { TokenResponse } from 'src/app/contracts/User/tokenResponse';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor( private httpservice:HttpClientService,private toastrService:CustomToastrService) { }
  async create(user:User):Promise<Create_User>
  {
    const observable:Observable<Create_User|User>= this.httpservice.post<Create_User|User>(
      {
          controler:"Users"
      },user);

       return await firstValueFrom(observable) as Create_User;
  }

 async login(usernameOrEmail:String,password:string,callBackFunction?:()=>void):Promise<any>
  {
   const observable:Observable<any|TokenResponse>=this.httpservice.post<any|TokenResponse>(
    {
      controler:"Auth",
      action:"Login"
    },{usernameOrEmail,password}
    ) 

    const tokenResponse:TokenResponse = await firstValueFrom(observable) as TokenResponse;
    if(tokenResponse)
      // local storageye token ekliyoruz
      localStorage.setItem("accessToken",tokenResponse.token.accessToken);
      localStorage.setItem("refreshToken",tokenResponse.token.refreshToken);
      // localStorage.setItem("expirationToken",token.expiration.toString());
      this.toastrService.message("Giriş Başarılı","Giriş",{messageType:ToastrMessageType.Succes,positions:ToastrPosition.TopLeft})

    callBackFunction();
  }
  async refreshToken(refreshToken:string,callBackFunction?:()=>void):Promise<any>
  {
    const observable:Observable<any|TokenResponse>=this.httpservice.post(
    {
      action:"refreshtoken",
      controler:"auth"    
    },{refreshToken:refreshToken});

    const tokenResponse:TokenResponse=await firstValueFrom(observable) as TokenResponse;
    if (tokenResponse) 
    {
      localStorage.setItem("accessToken",tokenResponse.token.accessToken);
      localStorage.setItem("refreshToken",tokenResponse.token.refreshToken);      
     
    }
    callBackFunction();
  }
}
