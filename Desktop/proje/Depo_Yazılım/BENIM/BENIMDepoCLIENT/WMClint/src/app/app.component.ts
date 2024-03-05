import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from './services/ui/custom-toastr.service';
import { Observable } from 'rxjs';
import { AuthService } from './services/common/auth.service';
import { Router } from '@angular/router';
declare  var $:any
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
   
  constructor(public authService:AuthService,private toastrService:CustomToastrService,private router:Router)
  {
    authService.identityCheck();
    

  }
  signOut()
  {
    localStorage.removeItem("accesToken");
    this.authService.identityCheck();
    this.router.navigate([""]);
    this.toastrService.message("Oturum Kapatılmıştır","Oturum Kapatıldı",{messageType:ToastrMessageType.Succes,positions:ToastrPosition.TopRight})
  }

  
}
// $(document).ready(()=>
// {alert("asd")})
 