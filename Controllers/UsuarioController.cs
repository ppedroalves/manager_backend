using Manager.Data;
using Manager.Models;
using Manager.Models.Enums;
using Manager.ViewModels;
using Manager.ViewModels.UsuarioViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manager.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        [HttpPost]
        public async Task< IActionResult> Post(
            [FromServices] Context _context, 
            [FromBody] CreateUsuarioViewModel model )
        {
            try
            {
                if(_context.Usuarios.Any(x => x.Email == model.Email))
                        return BadRequest(new ResultViewModel<Usuario>("Email ja cadastrado"));

                var usuario = new Usuario
                {
                    Id = 0,
                    Nome = model.Nome,
                    Email = model.Email,
                    Regiao = (Regiao)model.Regiao
                };

                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return Created($"/usuario/{usuario.Id}", new ResultViewModel<Usuario>(usuario));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<Usuario>("Nao foi possivel inserir o usuario"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Usuario>("Erro interno no servidor"));
            }
            
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id,
            [FromServices] Context _context)
        {
            try
            {
                var usuario = await _context
                    .Usuarios
                    .AsNoTracking()
                    .Include(x => x.Oportunidades)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if(usuario == null)
                    return NotFound(new ResultViewModel<Usuario>("Usuario nao encontrado"));

                    return Ok(new ResultViewModel<Usuario>(usuario));
            }catch
            {
                return StatusCode(500, new ResultViewModel<Usuario>("Falha interna no servidor"));
            }
        }



        [HttpGet()]
        public async Task<IActionResult> GetByEmail(
            [FromQuery] string email, [FromServices] Context _context
        ){
            try{
                var usuario = await _context
                .Usuarios
                .AsNoTracking()
                .Include(x => x.Oportunidades)
                .Where(x => x.Email == email)
                .Select(x => new ResultUsuarioViewModel{
                    Id = x.Id,
                    Nome = x.Nome,
                    Email = x.Email,
                    Disponivel = x.Disponivel,
                    Oportunidades = x.Oportunidades,
                    Regiao = x.Regiao.ToString()
                })
                .FirstOrDefaultAsync();
                if(usuario == null)
                    return NotFound(new ResultViewModel<Usuario>("Usuario nao encontrado"));

                return Ok(new ResultViewModel<ResultUsuarioViewModel>(usuario));
            }catch
            {
                return StatusCode(500, new ResultViewModel<Usuario>("Falha interna no servidor"));
            }
        }
    }
}
