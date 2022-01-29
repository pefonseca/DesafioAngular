using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class LojaContextSeed
    {
        public static async Task SeedAsync(LojaContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.MarcaProdutos.Any())
                {
                    var marcasData = File.ReadAllText("../Infrastructure/Data/SeedData/marcas.json");

                    var marcas = JsonSerializer.Deserialize<List<MarcaProduto>>(marcasData);

                    foreach (var item in marcas)
                    {
                        context.MarcaProdutos.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.TipoProdutos.Any())
                {
                    var tiposData = File.ReadAllText("../Infrastructure/Data/SeedData/tipos.json");

                    var tipos = JsonSerializer.Deserialize<List<TipoProduto>>(tiposData);

                    foreach (var item in tipos)
                    {
                        context.TipoProdutos.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Produtos.Any())
                {
                    var produtosData = File.ReadAllText("../Infrastructure/Data/SeedData/produtos.json");

                    var produtos = JsonSerializer.Deserialize<List<Produto>>(produtosData);

                    foreach (var item in produtos)
                    {
                        context.Produtos.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethods.Any())
                {
                    var dmData = File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json");

                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                    foreach (var item in methods)
                    {
                        context.DeliveryMethods.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<LojaContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}