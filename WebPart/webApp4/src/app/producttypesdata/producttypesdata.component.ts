import { Component, OnInit } from '@angular/core';

import { ProducttypeService } from './shared/producttype.service';

@Component({
  selector: 'app-producttypesdata',
  templateUrl: './producttypesdata.component.html',
  styleUrls: ['./producttypesdata.component.css'],
  providers: [ ProducttypeService ]
})

export class ProducttypesdataComponent implements OnInit {

  constructor(private productTypeService : ProducttypeService) {}

  ngOnInit(){}
}