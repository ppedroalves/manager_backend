using System.Text.Json.Serialization;

namespace Manager.Integracoes.Models
{
    public class DadosEmpresa
    {


        [JsonPropertyName("razao_social")]
        public string RazaoSocial { get; set; }


        [JsonPropertyName("estabelecimento")]
        public Estabelecimento Estabelecimento { get; set; }

  
    }

    public class Estabelecimento
    {

        [JsonPropertyName("atividade_principal")]
        public AtividadePrincipal AtividadePrincipal { get; set; }

        [JsonPropertyName("estado")]
        public Estado Estado { get; set; }
    }

    public class AtividadePrincipal
    {

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }
    }

    public class Estado
    {

        [JsonPropertyName("ibge_id")]
        public int IbgeId { get; set; }
    }
}
