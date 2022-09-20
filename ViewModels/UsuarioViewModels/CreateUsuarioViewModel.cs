using System.ComponentModel.DataAnnotations;

namespace Manager.ViewModels.UsuarioViewModels
{
    public class CreateUsuarioViewModel
    {


        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo Email é obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Regiao é obrigatorio")]
        [Range(1, 5, ErrorMessage = "O valor deve ser entre 1 e 5")]
        public int Regiao { get; set; }


    }
}
