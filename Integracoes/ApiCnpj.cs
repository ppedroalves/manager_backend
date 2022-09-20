using Manager.Integracoes.Models;
using RestSharp;
using System.Text.Json;

namespace Manager.Integracoes
{
    public class ApiCnpj
    {
        public DadosEmpresa BuscarDadosCnpj(string cnpj)
        {
            try
            {
                RestClientOptions options = new($"https://publica.cnpj.ws/cnpj/{cnpj}");
                RestClient client = new(options);
                RestRequest request = new() { Method = Method.Get };
                RestResponse response = client.ExecuteAsync(request).Result;
                DadosEmpresa resultado = JsonSerializer.Deserialize<DadosEmpresa>(response.Content);
                return resultado;

            }
            catch
            {
                throw;
            }


        }
    }
}
