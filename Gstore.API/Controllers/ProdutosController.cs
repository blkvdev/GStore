using Gstore.API.Data;
using Gstore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gstore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> GetProdutos()
    {
        return Ok(
            _context.Produtos
                .Include(p => p.categoria)
                .ToList()
        );
    }

    [HttpGet("{id}")]
    public ActionResult<Produto> GetProduto(int id)
    {
        var produto = _context.Produtos
            .Include(p => p.categoria)
            .FirstOrDefault(p => p.Id == id);

        if (produto == null)
            return NotFound("Produto não localizado");

        return Ok(produto);
    }

    [HttpPost]
    public ActionResult<Produto> PostProduto([FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Confira os dados enviados!");

        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return CreatedAtAction(
            nameof(GetProduto),
            new { id = produto.Id },
            produto
        );
    }

    [HttpPut("{id}")]
    public ActionResult PutProduto(int id, [FromBody] Produto produto)
    {
        if (id != produto.Id)
            return BadRequest("Confira os dados enviados!");

        var oldProduto = _context.Produtos.Find(id);

        if (oldProduto == null)
            return NotFound("Produto não localizado");

        oldProduto.CategoriaId = produto.CategoriaId;
        oldProduto.Nome = produto.Nome;
        oldProduto.Descricao = produto.Descricao;
        oldProduto.Qtde = produto.Qtde;
        oldProduto.ValorCusto = produto.ValorCusto;
        oldProduto.ValorVenda = produto.ValorVenda;
        oldProduto.Destaque = produto.Destaque;
        oldProduto.Foto = produto.Foto;

        _context.Entry(oldProduto).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduto(int id)
    {
        var produto = _context.Produtos.Find(id);

        if (produto == null)
            return NotFound("Produto não localizado");

        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return NoContent();
    }
}