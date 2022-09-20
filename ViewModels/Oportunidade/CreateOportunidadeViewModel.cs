using System.ComponentModel.DataAnnotations;

namespace Manager.ViewModels.UsuarioViewModels
{
    public class CreateOportunidadeViewModel
    {


        [Required(ErrorMessage = "O campo CNPJ é obrigatorio")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatorio")]
        public float Valor { get; set; }
    }
}
