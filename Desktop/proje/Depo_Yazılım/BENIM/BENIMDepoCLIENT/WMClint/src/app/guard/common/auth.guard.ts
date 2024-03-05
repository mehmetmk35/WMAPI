 //  npm i @auth0/angular-jwt   => tüm isteklerin header kısmına bear.. ve toekn ı ekleyecek  yapılacak  tüm isteklerin yetkilendirilmesi sağlacanaktır
// APP MODULE JwtModule ekliyoruz  
 
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt'
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../services/ui/custom-toastr.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { SpinnerType } from '../../base/base.component';
import { AuthService, _isAuthenticated } from '../../services/common/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private jwtHelper: JwtHelperService, private router: Router, private toastrService: CustomToastrService, private spinner: NgxSpinnerService) {

  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    this.spinner.show(SpinnerType.BallScaleMultiple);
    // const token: string = localStorage.getItem("accessToken");

    // //const decodeToken = this.jwtHelper.decodeToken(token);
    // //const expirationDate: Date = this.jwtHelper.getTokenExpirationDate(token);
    // let expired: boolean;
    // try {
    //  expired = this.jwtHelper.isTokenExpired(token);
    // } catch {
    //  expired = true;
    // }

    if (!_isAuthenticated) {
      this.router.navigate(["login"], { queryParams: { returnUrl: state.url } }); //state.url  ile loginden sonra kaldığımız sayfadan devam etmemizi sağlar 
      this.toastrService.message("Oturum açmanız gerekiyor!", "Yetkisiz Erişim!", {
        messageType: ToastrMessageType.Warning,
        positions: ToastrPosition.TopRight
      })
    }


    this.spinner.hide(SpinnerType.BallScaleMultiple);

    return true;
  }

}
 