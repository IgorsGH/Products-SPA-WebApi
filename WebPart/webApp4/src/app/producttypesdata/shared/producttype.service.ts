import { Injectable } from '@angular/core';

import {Producttype} from './producttype.model';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class ProducttypeService {

  productTypeList : Producttype [];

  constructor(private http : Http) {}

 getProductTypeList(){
   this.http.get('http://localhost:52087/api/ProductType').map((data : Response)=>{
     return data.json() as Producttype[];
   }).toPromise().then(x=>{
         this.productTypeList = x;
       })
 }
 
}
