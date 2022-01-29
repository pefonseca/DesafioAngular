import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from 'src/app/basket/basket.service';
import { IProduto } from 'src/app/shared/models/produto';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-produto-details',
  templateUrl: './produto-details.component.html',
  styleUrls: ['./produto-details.component.scss']
})
export class ProdutoDetailsComponent implements OnInit {
  produto: IProduto;
  quantidade = 1;

  constructor(
    private shopService: ShopService, 
    private activateRoute: ActivatedRoute, 
    private bcService: BreadcrumbService,
    private basketService: BasketService) { }

  ngOnInit(): void {
    this.loadProduto();
    this.bcService.set('@produtoDetails', 'Carregando...');
  }

  addItemToBasket() {
    this.basketService.addItemToBasket(this.produto, this.quantidade);
  }

  incrementQuantity() {
    this.quantidade++;
  }

  decrementQuantity() {
    if (this.quantidade > 1) {
      this.quantidade--;
    }
  }

  loadProduto() {
    this.shopService.getProduto(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(produto => {
      this.produto = produto;
      this.bcService.set('@produtoDetails', produto.nome);
    }, error => {
      console.log(error);
    });
  }
}
