import { Component, enableProdMode } from '@angular/core';
import { Employee, Service } from '../tree-list.service';
 
 
@Component({
  selector: 'app-tree-list',
  templateUrl: './tree-list.component.html',
  styleUrls: ['./tree-list.component.scss'],
 
  preserveWhitespaces: true,
})
export class TreeListComponent {
  employees: Employee[];

  constructor(service: Service) {
    this.employees = service.getEmployees();
  }
}
