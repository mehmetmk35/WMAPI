import { Injectable } from '@angular/core';
import { HttpClientService } from '../../http-client.service';
import { User } from 'src/app/entities/user';
import { Create_User } from 'src/app/contracts/User/create_user';
import { Observable, firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor( private httpservice:HttpClientService) { }
  async create(user:User):Promise<Create_User>
  {
    const observable:Observable<Create_User|User>= this.httpservice.post<Create_User|User>(
      {
          controler:"Users"
      },user);

       return await firstValueFrom(observable) as Create_User;
  }

 async login(usernameOrEmail:String,password:string,callBackFunction?:()=>void):Promise<void>
  {
   const observable:Observable<any>=this.httpservice.post(
    {
      controler:"User",
      action:"login"
    },{usernameOrEmail,password}
    ) 

    await firstValueFrom(observable);
    callBackFunction();
  }
}
