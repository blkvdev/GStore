using Gstore.API.Data;
using Gstore.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Asn1.Cms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Conexão com o banco de dados
string conexao = builder.Configuration.GetConnectionString("Conexao");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(conexao)
);

//Configuração do serviço de autenticaçaõ e autorização - Identity
builder.Services.AddIdentity<Usuario, IdentityRole>(options =>
{
    //Configuração da senha 
    options.Password.RequiredLength =6;
    options.Password.RequiredUniqueChars =0;
    // Configuração de bloqueio
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    // Configuração de usuário
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// Serviços JWT
var jwsSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwsSettings["SecretKey"];

builder.Services.AddAuthentication().AddJwtBearer();


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
