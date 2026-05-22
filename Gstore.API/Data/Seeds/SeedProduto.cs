using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gstore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Gstore.API.Data.Seeds
{
    public class SeedProduto
    {
        public SeedProduto(ModelBuilder builder)
        {
            List<Produto> produtos = [
                new() {
                    Id = 1,
                    Nome = "",
                    Descricao = "",
                    ValorCusto = 0,
                    ValorVenda = 0,
                    Qtde = 0,
                    Destaque = true,
                    Foto = "/img/produtos/1.png"

                }
            ];
            builder.Entity<Produto>().HasData(produtos);
        }
        
    }
}