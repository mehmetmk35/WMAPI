import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { AuthService } from 'src/app/services/common/auth.service';
import { UserService } from 'src/app/services/common/model/user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends BaseComponent {
  constructor(private userService:UserService, spinner:NgxSpinnerService,private authService:AuthService,
              private activatedRoute:ActivatedRoute,
              private router:Router) 
  { super(spinner)}
   async login(usernameOrEmail:string,userpassword:string)
  {
    this.showspinner(SpinnerType.LineSpinFadeRotating)
     await this.userService.login(usernameOrEmail,userpassword,()=>
  {
      this.authService.identityCheck();
      this.activatedRoute.queryParams.subscribe(params=>
      {
        const returnUrl:string=params["returnUrl"];
        if (returnUrl)
              this.router.navigate([returnUrl])
      })
      this.hidespinner(SpinnerType.LineSpinFadeRotating)

  });
  }
}
