import { Component, OnInit } from '@angular/core';

import { ProductService } from '../shared/product.service';
import { NgForm } from '@angular/forms';
import {ToastrService} from 'ngx-toastr';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(private productService : ProductService,
  private toastr : ToastrService
  ) { }

  ngOnInit() {
    this.resetForm();
  }

  onSubmit(form : NgForm){
    if(form.value.ProductId == null){
      this.productService.postProduct(form.value)
      .subscribe( data => {
        this.resetForm(form);
        this.productService.getProductList();
        this.toastr.success('New Record Added Successfully', 'webApp4');
      })
    }
    else{
      this.productService.putProduct(form.value.ProductId, form.value)
      .subscribe( data => {
        this.resetForm(form);
        this.productService.getProductList();
        this.toastr.info('Record Updeted Successfully', 'webApp4');
      })
    } 
  }

  resetForm(form? : NgForm){
    if(form!=null)
    {
      form.reset();
    }
    this.productService.selectedProduct = {
      ProductId : null,
      ProductName : '',
      ProductTypeId : null,
      ProductTypeName : ''
    }
  }

}
