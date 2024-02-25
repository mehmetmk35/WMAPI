import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { UserService } from 'src/app/services/common/model/user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends BaseComponent {
  constructor(private userService:UserService, spinner:NgxSpinnerService) 
  { super(spinner)}
   async login(usernameOrEmail:string,userpassword:string)
  {
    this.showspinner(SpinnerType.LineSpinFadeRotating)
     await this.userService.login(usernameOrEmail,userpassword,()=>this.hidespinner(SpinnerType.LineSpinFadeRotating));
  }
}
