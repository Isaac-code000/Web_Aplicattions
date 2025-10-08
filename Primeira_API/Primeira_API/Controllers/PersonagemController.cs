using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Primeira_API.Data;
using Primeira_API.Models;

using Microsoft.EntityFrameworkCore;



namespace Primeira_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonagemController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public PersonagemController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> NewPersonagem([FromBody] Personagem personagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _appDbContext.DbPersonagem.Add(personagem);

            await _appDbContext.SaveChangesAsync();
            return Ok(personagem);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personagem>>> GetPersonagens()
        {
            var personagens = await _appDbContext.DbPersonagem.ToListAsync();
            return Ok(personagens);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Personagem>> GetPersonagem(int id)
        {
            Personagem personagem = await _appDbContext.DbPersonagem.FindAsync(id);
            if (personagem == null) {
                return NotFound("Personagem não encontrado =( ");
            }
            return Ok(personagem);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonagem(int id,[FromBody]Personagem atualizado)
        {
            var atual = await _appDbContext.DbPersonagem.FindAsync(id);
            if (atual == null) {
                return NotFound("O personagem nao existe");
            }
            _appDbContext.Entry(atual).CurrentValues.SetValues(atualizado);
            await _appDbContext.SaveChangesAsync();
            return StatusCode(201,atual);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonagem(int id)
        {
           var personagem = await _appDbContext.DbPersonagem.FindAsync(id);
           if (personagem == null) return NotFound("O personagem nao existe");
          
           _appDbContext.DbPersonagem.Remove(personagem);
           await _appDbContext.SaveChangesAsync();
           return Ok(personagem);
        }
    }
}
