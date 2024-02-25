import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StocksModule } from './stocks/stocks.module';
import { HomeModule } from './home/home.module'; 
import { LoginModule } from './login/login.module';




@NgModule({
  declarations: [
   
  ],
  imports: [
    CommonModule,
    StocksModule ,    
    HomeModule   ,
    LoginModule
  ]
})
export class ComponentsModule { }
