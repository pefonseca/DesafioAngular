using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProdutoWithFiltersForCountSpecificication : BaseSpecification<Produto>
    {
        public ProdutoWithFiltersForCountSpecificication(ProdutoSpecParams produtoParams)
            : base(x => 
                (string.IsNullOrEmpty(produtoParams.Search) || x.Nome.ToLower().Contains(produtoParams.Search)) &&
                (!produtoParams.MarcaId.HasValue || x.MarcaProdutoId == produtoParams.MarcaId) &&
                (!produtoParams.TipoId.HasValue || x.TipoProdutoId == produtoParams.TipoId)
            )
        {

        }
    }
}