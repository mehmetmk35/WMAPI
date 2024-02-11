import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule } from '@angular/router'; 
import {MatTreeModule} from '@angular/material/tree';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { FileUploadModule } from 'src/app/services/common/file-upload/file-upload.module';



@NgModule({
  declarations: [
    HeaderComponent,
    SidebarComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    MatTreeModule,
    MatButtonModule,
    MatIconModule,
    
  ],
  exports:[HeaderComponent,SidebarComponent,FooterComponent]
})
export class ComponentsModule { }
