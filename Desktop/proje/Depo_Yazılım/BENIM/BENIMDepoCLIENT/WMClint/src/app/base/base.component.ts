import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
 
export class BaseComponent {
constructor(private spinner:NgxSpinnerService) {}
 showspinner(spinnerTypeName:SpinnerType){
  this.spinner.show(spinnerTypeName);
 }
 hidespinner(spinnerTypeName:SpinnerType){
  this.spinner.hide(spinnerTypeName)
  
 }

}
export enum SpinnerType{
  BallScaleMultiple="x1",
  BallSpinClockwiseFadeRotating="x2",
  LineSpinFadeRotating="x3"

}
