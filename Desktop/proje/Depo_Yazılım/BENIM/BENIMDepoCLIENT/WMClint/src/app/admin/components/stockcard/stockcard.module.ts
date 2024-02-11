import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StockcardComponent } from './stockcard.component';
import { RouterModule } from '@angular/router';
import { BarcodeModule } from './barcode/barcode.module';
import {MatSidenavModule} from '@angular/material/sidenav';
import { StockcardcreateComponent } from './stockcardcreate/stockcardcreate.component';
import { StockcardlistComponent } from './stockcardlist/stockcardlist.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatSelectModule} from '@angular/material/select';
import {MatTableModule} from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { DeleteDirective } from 'src/app/directives/admin/delete.directive'; 
import { DeleteDialogComponent } from 'src/app/dialog/delete-dialog/delete-dialog.component';
 
 
 


@NgModule({
  declarations: [
    StockcardComponent,
    StockcardcreateComponent,
    StockcardlistComponent,
    DeleteDirective,
    
   

  ],
  imports: [
    CommonModule,
    BarcodeModule,
    MatSidenavModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatTableModule,
    MatPaginatorModule,
     
  
    
    RouterModule.forChild([
      {path:"",component:StockcardComponent },
      {path:"stockcardcreate",component:StockcardcreateComponent },
      {path:"stockcardlist",component:StockcardlistComponent }
    ])
  ]
 
})
export class StockcardModule { }
