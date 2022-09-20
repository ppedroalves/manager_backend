using Manager.Models.Enums;
using System.Text.Json.Serialization;

namespace Manager.Models
{
    public class Usuario
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public Regiao Regiao { get; set; }

        public IList<Oportunidade> Oportunidades { get; set; }


        [JsonIgnore]
        public bool Disponivel { get; set; } = true;

     
    }

 
}
