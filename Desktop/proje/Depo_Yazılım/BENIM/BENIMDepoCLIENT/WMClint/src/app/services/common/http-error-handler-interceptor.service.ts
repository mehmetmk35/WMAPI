import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpStatusCode } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, of } from 'rxjs';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../ui/custom-toastr.service';
import { UserService } from './model/user/user.service';

@Injectable({
  providedIn: 'root'
})
export class HttpErrorHandlerInterceptorService implements HttpInterceptor{

  constructor(private customToastrService:CustomToastrService,private userService:UserService) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
      return next.handle(req).pipe(catchError(  error=>
        {
          switch (error.status) {
            case HttpStatusCode.Unauthorized:
              this.customToastrService.message("Bu işlemi yapmaya yetkiniz bulunmamaktadır","Yetkisiz Kullanıcı",
                                              {messageType:ToastrMessageType.Error,positions:ToastrPosition.TopFulWidth})
               this.userService.refreshToken(localStorage.getItem("refreshToken")).then(data=>
                {
                  //await ile bekletemedim çumki  catchError türünden dolayı 
                })
             break;
            case HttpStatusCode.InternalServerError:
              this.customToastrService.message("Sunucuya Erişilmiyor","Sunucuya Erişimde Hata",
                                              {messageType:ToastrMessageType.Error,positions:ToastrPosition.TopFulWidth})
              break;
            case HttpStatusCode.BadRequest:
              this.customToastrService.message("Geçersiz İstek Yapıldı","Geçersiz istek",
                                              {messageType:ToastrMessageType.Error,positions:ToastrPosition.TopFulWidth})
              break;
            case HttpStatusCode.NotFound:
              this.customToastrService.message("Sayfa Bulunamadı","Hata",
                                              {messageType:ToastrMessageType.Error,positions:ToastrPosition.TopFulWidth})
              break;
          
            default:
              this.customToastrService.message("Beklenmeyen bir hata meydana gelmiştir","Hata",
                                              {messageType:ToastrMessageType.Error,positions:ToastrPosition.TopFulWidth})
              break;
          }
           
          return of(error)
        }
       
        ))  //isteğe bağlan eğer hata var ise catchError tetiklen ve hatayı yakala
  }
}
