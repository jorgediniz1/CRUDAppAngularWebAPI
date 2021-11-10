using CRUDAPI.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase 
    {
        private readonly Context _context;

        public PessoasController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> PegarTodosAsync(){
            return await _context.Pessoas.ToListAsync();          
        }

        [HttpGet("{pessoaId}")]
        public async Task<ActionResult<Pessoa>> PegarPessoaPeloIdAsync(int pessoaId){
            Pessoa pessoa = await _context.Pessoas.FindAsync(pessoaId);

            if(pessoa == null)
                return NotFound();
            
            return pessoa;
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> SalvarPessoaAsync(Pessoa pessoa){
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarPessoaAsync(Pessoa pessoa){
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{pessoaId}")]
        public async Task<ActionResult> ExcluirPessoaAsync(int pessoaId){
            Pessoa pessoa = await _context.Pessoas.FindAsync(pessoaId);
            
            if(pessoa == null)
               return NotFound();
            _context.Remove(pessoa);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
    }
}