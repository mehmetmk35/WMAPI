import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from './services/ui/custom-toastr.service';
import { Observable } from 'rxjs';
declare  var $:any
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'WMClint';
  constructor(private toastrService:CustomToastrService)
  {
   toastrService.message("test1","test2") 
    

  }
  

  
}
// $(document).ready(()=>
// {alert("asd")})
 