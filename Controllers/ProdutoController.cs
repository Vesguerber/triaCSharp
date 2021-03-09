using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TriaCSharp.Data;
using TriaCSharp.Models;

namespace TriaCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IRepository _repoProduto;

        public ProdutoController(IRepository repo) {
            _repoProduto = repo;
        }

        [HttpGet]
        public async  Task <IActionResult> Get()
        {
            try
            {
                var result = await _repoProduto.GetAllProdutosAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

    }
}
