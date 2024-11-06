using apipessoa2.Models;
using apipessoa2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace apipessoa2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaDAO _pessoaDAO;
        public PessoaController(PessoaDAO pessoaDAO)
        {
            _pessoaDAO = pessoaDAO;
        }

        [HttpGet]
        public IEnumerable<Pessoa> GetAll()
        { 
            return _pessoaDAO.consulteTodas();
        }

        [HttpGet("{id}")]
        public ActionResult<Pessoa> Get(int id)
        {
            var pessoa = _pessoaDAO.consulte(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            else 
            {
                return Ok(pessoa);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]Pessoa pessoa) 
        {
            if (pessoa == null) 
            {
                return BadRequest("Favor informar os dados da pessoa");
            }

            var id = _pessoaDAO.insira(pessoa);
            pessoa.Id = id;
            return CreatedAtAction(nameof(Get), new { id = pessoa.Id }, pessoa);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Pessoa pessoa) 
        {
            if(pessoa == null || pessoa.Id != id) 
            {
                return BadRequest("Informações de atualização incorretas.");
            }

            var existePessoa = _pessoaDAO.consulte(id);
            if(existePessoa == null) 
            {
                return NotFound();
            }

            _pessoaDAO.Altere(pessoa);
            return Ok("Registro Atualizado com Sucesso.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var pessoa = _pessoaDAO.consulte(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            else 
            {
                _pessoaDAO.Exclua(id);
                return Ok("Pessoa removida para base de dados com sucesso.");
            }
        }
    }
}
