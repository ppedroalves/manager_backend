using Manager.Data;
using Manager.Integracoes;
using Manager.Integracoes.Models;
using Manager.Models;
using Manager.Models.Enums;
using Manager.Util;
using Manager.ViewModels;
using Manager.ViewModels.UsuarioViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OportunidadeController : ControllerBase
    {


        private readonly Context _context;

        public OportunidadeController(Context context)
        {
            _context = context;
        }
        


        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] CreateOportunidadeViewModel model,
            [FromServices] ApiCnpj _api, [FromServices] Context _context)
        {
            try
            { 
                string cnpjFormatado = FormataCNPJ.SemFormatacao(model.Cnpj);
                if (cnpjFormatado.Length != 14)
                    return BadRequest(new ResultViewModel<Oportunidade>("CNPJ invalido"));

                DadosEmpresa informacao = _api.BuscarDadosCnpj(cnpjFormatado);
                if (informacao.Estabelecimento == null)
                    return BadRequest(new ResultViewModel<Oportunidade>("Alguma coisa deu errado"));

                int regiao = informacao.Estabelecimento.Estado.IbgeId / 10;

                List<Usuario> usuarios = _context.Usuarios.Where(x => x.Regiao == (Regiao)regiao).ToList();

                var oportunidade = new Oportunidade
                {
                    Id = 0,
                    Cnpj = cnpjFormatado,
                    Descricao = informacao.Estabelecimento.AtividadePrincipal.Descricao,
                    Nome = model.Nome,
                    RazaoSocial = informacao.RazaoSocial,
                    Usuario = DefinirDonoOportunidade(usuarios),
                    Valor = model.Valor
                };

             
                await _context.Oportunidades.AddAsync(oportunidade);
                await _context.SaveChangesAsync();

                return Created($"/oportunidade/{oportunidade.Id}", new ResultViewModel<Oportunidade>(oportunidade));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest( new ResultViewModel<Oportunidade>(ex.Message));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Oportunidade>("Falha interna no servidor"));
            }
     

        }

        public   Usuario DefinirDonoOportunidade(List<Usuario> usuarios)
        {
            if (usuarios.Count == 0)
                throw new ArgumentNullException("Nenhum vendedor cadastrado para a regiao");
              
            if(usuarios.Count == 1)
                return usuarios.FirstOrDefault();

            if(usuarios.All(c => c.Disponivel == false))
            {
                usuarios.ForEach(usuario => usuario.Disponivel = true);
            }

            Usuario usuario = usuarios.PickRandom();
            usuario.Disponivel = false;
            _context.Usuarios.Update(usuario);


            return usuario;

           
        }
    }
}
