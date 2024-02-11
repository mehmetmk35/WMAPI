import { FlatTreeControl } from '@angular/cdk/tree';
import { Component } from '@angular/core';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';

interface sidebar {
  name: string;
  children?: sidebar[];
}

const TREE_DATA: sidebar[] = [
  {name: 'dashboard'},
  {name: 'customeritems'},
  {name: 'orders'},
  {name: 'stockcards',
  children: [
      {name: 'barcode',
          // children: [{name: 'test2'}, {name: 'test43'}],
      }      
    ],
    
  },
  {name:"Home"}
];
interface ExampleFlatNode {
  expandable: boolean;
  name: string;
  level: number;
   
   
   
}
 
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {
   
  private _transformer = (node: sidebar, level: number) => {
    
  
    return {
      expandable: !!node.children && node.children.length > 0,
      name: node.name,
      level: level 
      };
  };

  treeControl = new FlatTreeControl<ExampleFlatNode>(
    node => node.level,
    node => node.expandable,
    
  );

  treeFlattener = new MatTreeFlattener(
    this._transformer,
    node => node.level,
    node => node.expandable,
    node => node.children,
    
  );

  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);

  constructor() {
    this.dataSource.data = TREE_DATA;
     
  }

  hasChild = (_: number, node: ExampleFlatNode) => node.expandable;

  logNode(node: sidebar): void {
    console.log('Clicked Node:', node);
  }
}
