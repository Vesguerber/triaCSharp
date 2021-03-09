using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TriaCSharp.Data;
using TriaCSharp.Models;

namespace TriaCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IRepository _repo;

        public ClienteController(IRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        public async  Task <IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllClientesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("names")]
        public async  Task <IActionResult> GetNome()
        {
            try
            {
                var result = await _repo.GetAllClientesNameAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{ClienteId}")]
        public async  Task <IActionResult> GetClienteById(int ClienteId)
        {
            try
            {
                var result = await _repo.GetClienteAsyncById(ClienteId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async  Task <IActionResult> Post(Cliente model)
        {
            try
            {
                _repo.Add(model);
                
                if(await _repo.SaveChangesAsync())
                    return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest("Erro não esperado");
        }

        [HttpPut("{ClienteId}")]
        public async  Task <IActionResult> Put(int ClienteId, Cliente model)
        {
            try
            {
                
                var cliente = await _repo.GetClienteAsyncById(ClienteId);
                if(cliente == null) return NotFound();


                _repo.Update(model);
                
                if(await _repo.SaveChangesAsync())
                    return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest("Erro não esperado");
        }

        [HttpDelete("{ClienteId}")]
        public async  Task <IActionResult> Delete(int ClienteId)
        {
            try
            {
                
                var cliente = await _repo.GetClienteAsyncById(ClienteId);
                if(cliente == null) return NotFound();


                _repo.Delete(cliente);
                
                if(await _repo.SaveChangesAsync())
                    return Ok("Deletado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest("Erro não esperado");
        }
    }
}
