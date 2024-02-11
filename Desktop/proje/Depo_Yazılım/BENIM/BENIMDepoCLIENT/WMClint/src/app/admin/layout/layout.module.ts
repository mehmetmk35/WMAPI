import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { ComponentsModule } from './components/components.module';
import { RouterModule } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav';
import { FileUploadModule } from 'src/app/services/common/file-upload/file-upload.module';




@NgModule({
  declarations: [
    LayoutComponent
  ],
  imports: [
    CommonModule,
    ComponentsModule,
    RouterModule,
    MatSidenavModule,
    FileUploadModule
  ],
  exports: [
  LayoutComponent
  ]
})
export class LayoutModule { }

