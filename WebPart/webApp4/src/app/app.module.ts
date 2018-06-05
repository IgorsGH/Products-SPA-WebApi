import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {FormsModule} from '@angular/forms';
import {HttpModule} from '@angular/http';
import { ToastrModule } from 'ngx-toastr';
import {RouterModule, Routes} from '@angular/router';

import { AppComponent } from './app.component';
import { ProductsdataComponent } from './productsdata/productsdata.component';
import { ProductComponent } from './productsdata/product/product.component';
import { ProductListComponent } from './productsdata/product-list/product-list.component';

import { ProducttypesdataComponent } from './producttypesdata/producttypesdata.component';
import { ProducttypesComponent } from './producttypesdata/producttypes/producttypes.component';

const appRoutes:Routes = [
  {path: 'producttypespage', component:ProducttypesdataComponent},
  {path:'productsdata', component: ProductsdataComponent},
  {path: '', component: ProductsdataComponent, pathMatch: 'full'},
  {path: '**', component:  ProductsdataComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    ProductsdataComponent,
    ProductComponent,
    ProductListComponent,
    ProducttypesdataComponent,
    ProducttypesComponent
  ],
  imports: [
    BrowserModule,
    FormsModule, 
    HttpModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
