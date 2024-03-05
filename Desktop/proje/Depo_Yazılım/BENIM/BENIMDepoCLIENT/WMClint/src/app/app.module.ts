import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminModule } from './admin/admin.module';
import { UiModule } from './ui/ui.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { HttpErrorHandlerInterceptorService } from './services/common/http-error-handler-interceptor.service';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AdminModule,
    UiModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgxSpinnerModule,
    HttpClientModule,
    JwtModule.forRoot({
      config:{
                tokenGetter:()=>localStorage.getItem("accesToken"),
                allowedDomains:["localhost:7114"]  //ilgili token'ımı sadece bu domane gönder diğer başka sitelere gönderme  
            }
    })

  ],
  providers: [{ provide: "baseurl", useValue: "https://localhost:7114/api", multi: true },
              {provide:HTTP_INTERCEPTORS,useClass:HttpErrorHandlerInterceptorService,multi:true}],
              //yapılan hhtp isteklerde interceptor u devreye alıyoruz 
  bootstrap: [AppComponent]
})
export class AppModule { }
