import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StocksModule } from './stocks/stocks.module';
import { HomeModule } from './home/home.module'; 
import { LoginModule } from './login/login.module';
import { TreeListComponent } from './tree-list/tree-list.component';
import { TreeListModule } from './tree-list/tree-list.module';




@NgModule({
  declarations: [
   
  
    
  ],
  imports: [
    CommonModule,
    StocksModule ,    
    HomeModule   ,
    LoginModule,
    TreeListModule
  ] 
})
export class ComponentsModule { }
