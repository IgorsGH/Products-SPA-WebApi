import { Component, OnInit } from '@angular/core';
import {ProductService} from './shared/product.service';

@Component({
  selector: 'app-productsdata',
  templateUrl: './productsdata.component.html',
  styleUrls: ['./productsdata.component.css'],
  providers: [ProductService]
})

export class ProductsdataComponent implements OnInit {

  constructor(private productService : ProductService)
  { }

  ngOnInit() {
  }

}
