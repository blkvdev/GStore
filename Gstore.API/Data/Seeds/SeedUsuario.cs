using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Gstore.API.Data.Seeds
{
    public class SeedUsuario
    {
        public SeedUsuario(ModelBuilder builder)
        {
            #region Perfil
            List<IdentityRole> perfis = [
                new() {
                    Id= "5c72032b-8faf-46b4-a7a4-d6602afc1ffd",
                    Name= "Administrador",
                    NormalizedName= "ADMINISTRADOR"
                },
                 new() {
                    Id= "c80f1e97-3486-4e32-9083-07f43fa5d8ad",
                    Name= "Cliente",
                    NormalizedName= "CLIENTE"
                },
            ];
            builder.Entity<IdentityRole>().HasData(perfis);
            #endregion

            #region Usuários
            #endregion

            #region Usuário Perfil
            #endregion
            
        }
    }
}