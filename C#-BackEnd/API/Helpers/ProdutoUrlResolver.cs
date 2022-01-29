using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProdutoUrlResolver : IValueResolver<Produto, ProdutoDto, string>
    {
        private readonly IConfiguration _config;
        public ProdutoUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Produto source, ProdutoDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ImagemUrl))
            {
                return _config["ApiUrl"] + source.ImagemUrl;
            }

            return null;
        }
    }
}