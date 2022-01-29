import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ShopComponent } from './shop.component';
import { ProdutoDetailsComponent } from './produto-details/produto-details.component';

const routes: Routes = [
  {path: '', component: ShopComponent},
  {path: ':id', component: ProdutoDetailsComponent, data: {breadcrumb: {alias: 'produtoDetails'}}}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ShopRoutingModule { }
