using Gstore.API.Models;
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
        
            List<Usuario> usuarios = [
                new Usuario() {
                    Id = "5c72032b-8faf-46b4-a7a4-d6602afc1ffd",
                    Email = "admin@gstore.com",
                    NormalizedEmail = "ADMIN@GSTORE.COM",
                    UserName = "admin@gstore.com",
                    NormalizedUserName = "ADMIN@GSTORE.COM",
                    LockoutEnabled = true,
                    EmailConfirmed = true,
                    Nome = "administrador",
                    DataNascimento = DateTime.Parse("05/05/1981"),
                    Foto = ""
                    
                },
             
            ];
            foreach (var usuario in usuarios)
            {
                PasswordHasher<Usuario> passwordHasher = new();
                usuario.PasswordHash = passwordHasher.HashPassword(usuario, "123456");
            }
            builder.Entity<Usuario>().HasData(usuarios);
            #endregion

            #region Usuário Perfil
            List<IdentityUserRole<string>> userRoles = [
                new () {
                    UserId = usuarios[0].Id,
                    RoleId = perfis[0].Id
                }
            ];
            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            #endregion
            
        }
    }
}