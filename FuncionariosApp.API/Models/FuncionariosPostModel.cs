using System.ComponentModel.DataAnnotations;

namespace FuncionariosApp.API.Models
{
    public class FuncionariosPostModel
    {
        [MinLength(10,ErrorMessage = "O nome deve conter, no mínimo, 10 caracteres.")]
        [MaxLength(150,ErrorMessage = "O nome deve conter, no máximo, 150 caracteres.")]
        [Required(ErrorMessage = "É obrigatório o preenchimento do nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É obrigatório o preenchimento da Matrícula")]
        [RegularExpression(@"^\d{6}$",ErrorMessage = "A matrícula deve conter, apenas, 6 dígitos.'")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "É obrigatório o preenchimento do CPF")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter, apenas, 11 dígitos.'")]
        public string Cpf { get; set; }
    }
}
