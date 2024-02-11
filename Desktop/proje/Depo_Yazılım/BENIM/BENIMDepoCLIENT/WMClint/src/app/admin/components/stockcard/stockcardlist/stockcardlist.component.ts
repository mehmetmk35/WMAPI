import { Component, OnInit, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { BaseComponent, SpinnerType } from 'src/app/base/base.component';
import { StockList } from 'src/app/contracts/stockList/stockList';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { StockcardService } from 'src/app/services/common/model/Stock/stockcard.service';

@Component({
  selector: 'app-stockcardlist',
  templateUrl: './stockcardlist.component.html',
  styleUrls: ['./stockcardlist.component.scss']
})
export class StockcardlistComponent extends BaseComponent implements OnInit  {
  constructor(spinners:NgxSpinnerService,private StockcardS:StockcardService,private alertifyS:AlertifyService) {
      super(spinners);
  }
  @ViewChild(MatPaginator) paginator: MatPaginator;
  displayedColumns: string[] = ['stockCode', 'stockName', 'createdAt', 'CreatedBy','branchCode','delete'];
  dataSource:MatTableDataSource<StockList>=null
  async ngOnInit() {
   this.getStockList();
      
  }
  async getStockList(){   
    this.showspinner(SpinnerType.BallScaleMultiple);
    const allstocklist:{totalCount:number,stockList:StockList[]}= await this.StockcardS.read({page: this.paginator ?this.paginator.pageIndex:0,
     size:this.paginator?this.paginator.pageSize:5},()=>this.hidespinner(SpinnerType.BallScaleMultiple),(error)=>{
     this.alertifyS.message(error,{messageType:MessageType.Error,dismissOthers:true,position:Position.TopRight})
     this.hidespinner(SpinnerType.BallScaleMultiple)})
     
      
     this.dataSource=new MatTableDataSource<StockList>(allstocklist.stockList);
     // this.dataSource.paginator = this.paginator;
     this.paginator.length=allstocklist.totalCount;
  }
  async pageChange(){
    this.getStockList();
  }
   
  
 
   
  }
 