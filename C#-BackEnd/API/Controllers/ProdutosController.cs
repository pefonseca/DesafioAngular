using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProdutosController : BaseApiController
    {
        private readonly IGenericRepository<Produto> _produtoRepo;
        private readonly IGenericRepository<MarcaProduto> _marcaProdutoRepo;
        private readonly IGenericRepository<TipoProduto> _tipoProdutoRepo;
        private readonly IMapper _mapper;

        public ProdutosController(
            IGenericRepository<Produto> produtoRepo, 
            IGenericRepository<MarcaProduto> marcaProdutoRepo, 
            IGenericRepository<TipoProduto> tipoProdutoRepo,
            IMapper mapper)
        {
            _produtoRepo = produtoRepo;
            _marcaProdutoRepo = marcaProdutoRepo;
            _tipoProdutoRepo = tipoProdutoRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProdutoDto>>> GetProdutos([FromQuery]ProdutoSpecParams produtoParams)
        {
            var spec = new ProdutosComTiposEMarcasSpecification(produtoParams);

            var countSpec = new ProdutoWithFiltersForCountSpecificication(produtoParams);

            var totalItems = await _produtoRepo.CountAsync(countSpec);

            var produtos = await _produtoRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Produto>, IReadOnlyList<ProdutoDto>>(produtos);

            return Ok(new Pagination<ProdutoDto>(produtoParams.PageIndex, produtoParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProdutoDto>> GetProduto(int id)
        {
            var spec = new ProdutosComTiposEMarcasSpecification(id);

            var produto = await _produtoRepo.GetEntityWithSpec(spec);

            if (produto == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Produto, ProdutoDto>(produto);
        }

        [HttpGet("marcas")]
        public async Task<ActionResult<IReadOnlyList<MarcaProduto>>> GetMarcaProdutos()
        {
            return Ok(await _marcaProdutoRepo.ListAllAsync());
        }

        [HttpGet("tipos")]
        public async Task<ActionResult<IReadOnlyList<TipoProduto>>> GetTipoProdutos()
        {
            return Ok(await _tipoProdutoRepo.ListAllAsync());
        }
    }
}