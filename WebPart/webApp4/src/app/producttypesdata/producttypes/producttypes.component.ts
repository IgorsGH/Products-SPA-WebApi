import { Component, OnInit } from '@angular/core';

import { ProducttypeService } from '../shared/producttype.service';

@Component({
  selector: 'app-producttypes',
  templateUrl: './producttypes.component.html',
  styleUrls: ['./producttypes.component.css']
})

export class ProducttypesComponent implements OnInit {

  constructor(private productTypeService : ProducttypeService) { } 

  ngOnInit() {
    this.productTypeService.getProductTypeList();
  }

}
