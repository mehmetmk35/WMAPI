import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './admin/layout/layout.component';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { HomeComponent } from './ui/components/home/home.component';

const routes: Routes = [
{path:"admin",component:LayoutComponent,children:[
  {path:"",component:DashboardComponent} , 
  {path:"customeritems",loadChildren:()=>import("./admin/components/customeritem/customeritem.module").
    then(module=>module.CustomeritemModule)},
  {path:"stockcards",loadChildren:()=>import("./admin/components/stockcard/stockcard.module").
    then(module=>module.StockcardModule)},     
  {path:"orders",loadChildren:()=>import("./admin/components/orders/orders.module").
    then(module=>module.OrdersModule)} 
]},
  {path:"",component:HomeComponent},
  {path:"baskets",loadChildren:()=>import("./ui/components/baskets/baskets.module")
    .then(module=>module.BasketsModule)}, 
  {path:"stocks",loadChildren:()=>import("./ui/components/stocks/stocks.module")
    .then(module=>module.StocksModule)},
    {path:"register",loadChildren:()=>import("./ui/components/register/register.module")
    .then(module=>module.RegisterModule)},
    {path:"login",loadChildren:()=>import("./ui/components/login/login.module")
    .then(module=>module.LoginModule)}



];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
