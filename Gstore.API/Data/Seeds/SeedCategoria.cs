using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gstore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Gstore.API.Data.Seeds
{
    public class SeedCategoria
    {
        public SeedCategoria(ModelBuilder buider)
        {
            List<Categoria> categorias = [
                new() {Id = 1, Nome = "Smartphones"},
                new() {Id = 2, Nome = "notebooks"},
                new() {Id = 3, Nome = "fone de ouvido"},
                new() {Id = 4, Nome = "carregador"},
                new() {Id = 5, Nome = "tablet"},
                
            ];
        }
    }
}