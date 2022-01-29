using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly LojaContext _context;
        public ProdutoRepository(LojaContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<MarcaProduto>> GetMarcaProdutosAsync()
        {
            return await _context.MarcaProdutos
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Produto>> GetProdutosAsync()
        {
            var typeId = 1;

            var produtos = _context.Produtos.Where(x => x.TipoProdutoId == typeId).Include(x => x.TipoProduto).ToListAsync();

            return await _context.Produtos
                .Include(m => m.MarcaProduto)
                .Include(t => t.TipoProduto)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<TipoProduto>> GetTipoProdutosAsync()
        {
            return await _context.TipoProdutos.ToListAsync();
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
           return await _context.Produtos
                .Include(m => m.MarcaProduto)
                .Include(t => t.TipoProduto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}