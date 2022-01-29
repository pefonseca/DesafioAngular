import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProdutoItemComponent } from './produto-item/produto-item.component';
import { SharedModule } from '../shared/shared.module';
import { ProdutoDetailsComponent } from './produto-details/produto-details.component';
import { ShopRoutingModule } from './shop-routing.module';



@NgModule({
  declarations: [
    ShopComponent,
    ProdutoItemComponent,
    ProdutoDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ShopRoutingModule
  ]
})
export class ShopModule { }
