using Manager.Models;

namespace Manager.Controllers
{
    public class ResultUsuarioViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Regiao { get; set; }

        public IList<Oportunidade> Oportunidades { get; set; }

        public bool Disponivel { get; set; } 

    }
}