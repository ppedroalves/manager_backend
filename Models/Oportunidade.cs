using System.Text.Json.Serialization;

namespace Manager.Models
{
    public class Oportunidade
    {

        public int Id { get; set; }

        public string Nome { get; set; }
         
        [JsonIgnore]
        public Usuario Usuario { get; set; }

        public string Cnpj { get; set; }

        public string RazaoSocial { get; set; }

        public string Descricao { get; set; }

        public float Valor { get; set; }


    }
}