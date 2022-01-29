using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> GetProdutoByIdAsync(int id);
        Task<IReadOnlyList<Produto>> GetProdutosAsync();
        Task<IReadOnlyList<MarcaProduto>> GetMarcaProdutosAsync();
        Task<IReadOnlyList<TipoProduto>> GetTipoProdutosAsync();

    }
}