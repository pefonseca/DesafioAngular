using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProdutosComTiposEMarcasSpecification : BaseSpecification<Produto>
    {
        public ProdutosComTiposEMarcasSpecification(ProdutoSpecParams produtoParams) 
            : base(x => 
                (string.IsNullOrEmpty(produtoParams.Search) || x.Nome.ToLower().Contains(produtoParams.Search)) &&
                (!produtoParams.MarcaId.HasValue || x.MarcaProdutoId == produtoParams.MarcaId) &&
                (!produtoParams.TipoId.HasValue || x.TipoProdutoId == produtoParams.TipoId)
            )
        {
            AddInclude(x => x.TipoProduto);
            AddInclude(x => x.MarcaProduto);
            AddOrderBy(x => x.Nome);
            ApplyPaging(produtoParams.PageSize * (produtoParams.PageIndex - 1), produtoParams.PageSize);

            if (!string.IsNullOrEmpty(produtoParams.Sort))
            {
                switch (produtoParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Preco);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Preco);
                        break;
                    default:
                        AddOrderBy(n => n.Nome);
                        break;
                }
            }
        }

        public ProdutosComTiposEMarcasSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.TipoProduto);
            AddInclude(x => x.MarcaProduto);
        }
    }
}