import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IMarca } from '../shared/models/marca';
import { IProduto } from '../shared/models/produto';
import { ShopParams } from '../shared/models/shopParams';
import { ITipo } from '../shared/models/tipoProduto';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: false}) searchTerm: ElementRef;
  produtos: IProduto[];
  marcas: IMarca[];
  tipos: ITipo[];
  shopParams = new ShopParams();
  totalCount: number;
  sortOption = [
    {nome: 'Alfabética', value: 'nome'},
    {nome: 'Preço: Baixo a Alto', value: 'priceAsc'},
    {nome: 'Preço: Alto a Baixo', value: 'priceDesc'}
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProdutos();
    this.getMarcas();
    this.getTipos();
  }

  getProdutos() {
    this.shopService.getProdutos(this.shopParams).subscribe(response => {
      this.produtos = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }

  getMarcas() {
    this.shopService.getMarcas().subscribe(response => {
      this.marcas = [{id: 0, nome: 'All'}, ...response];
    }, error => {
      console.log(error);
    });
  }

  getTipos() {
    this.shopService.getTipos().subscribe(response => {
      this.tipos = response;
    }, error => {
      console.log(error);
    });
  }

  onMarcaSelected(marcaId: number) {
    this.shopParams.marcaId = marcaId;
    this.shopParams.pageNumber = 1;
    this.getProdutos();
  }

  onTipoSelected(tipoId: number) {
    this.shopParams.tipoId = tipoId;
    this.shopParams.pageNumber = 1;
    this.getProdutos();
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.getProdutos();
  }

  onPageChanged(event: any) {
    if (this.shopParams.pageNumber !== event) {        
      this.shopParams.pageNumber = event;
      this.getProdutos();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProdutos();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProdutos();
  }
}
