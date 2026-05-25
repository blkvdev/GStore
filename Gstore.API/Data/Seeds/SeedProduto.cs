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
    Nome = "Base Líquida Matte",
    Descricao = "Base de longa duração com acabamento matte.",
    ValorCusto = 25,
    ValorVenda = 59,
    Qtde = 50,
    Destaque = true,
    Foto = "/img/1.png"
},

new() {
    Id = 2,
    Nome = "Paleta de Sombras Nude",
    Descricao = "Paleta com tons neutros para maquiagem diária.",
    ValorCusto = 35,
    ValorVenda = 79,
    Qtde = 35,
    Destaque = false,
    Foto = "/img/2.png"
},

// Skincare
new() {
    Id = 3,
    Nome = "Sérum Vitamina C",
    Descricao = "Sérum facial antioxidante para hidratação e brilho.",
    ValorCusto = 40,
    ValorVenda = 89,
    Qtde = 28,
    Destaque = true,
    Foto = "/img/3.png"
},

new() {
    Id = 4,
    Nome = "Protetor Solar Facial FPS 70",
    Descricao = "Proteção diária contra raios UVA e UVB.",
    ValorCusto = 30,
    ValorVenda = 69,
    Qtde = 45,
    Destaque = true,
    Foto = "/img/4.png"
},

// Perfumes
new() {
    Id = 5,
    Nome = "Perfume Floral Essence",
    Descricao = "Fragrância feminina suave e elegante.",
    ValorCusto = 70,
    ValorVenda = 149,
    Qtde = 20,
    Destaque = false,
    Foto = "/img/5.png"
},

new() {
    Id = 6,
    Nome = "Perfume Night Black",
    Descricao = "Fragrância masculina intensa e sofisticada.",
    ValorCusto = 85,
    ValorVenda = 179,
    Qtde = 18,
    Destaque = true,
    Foto = "/img/6.png"
},

// Cuidados capilares
new() {
    Id = 7,
    Nome = "Shampoo Hidratante",
    Descricao = "Shampoo para cabelos secos e danificados.",
    ValorCusto = 18,
    ValorVenda = 39,
    Qtde = 60,
    Destaque = false,
    Foto = "/img/7.png"
},

new() {
    Id = 8,
    Nome = "Máscara Capilar Nutritiva",
    Descricao = "Tratamento intensivo para brilho e maciez.",
    ValorCusto = 28,
    ValorVenda = 59,
    Qtde = 42,
    Destaque = true,
    Foto = "/img/8.png"
},
            ];
            builder.Entity<Produto>().HasData(produtos);
        }
        
    }
}