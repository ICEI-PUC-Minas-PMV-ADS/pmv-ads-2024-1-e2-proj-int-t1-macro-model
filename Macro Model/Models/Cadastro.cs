using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Macro_Model.Models
{
    [Table("Cadastro")]
    public class Cadastro
    {
        [Key]
        [Display(Name = "CPF ")]
        [Required(ErrorMessage = "Obrigatório informar CPF.")]
        [MaxLength(11,  ErrorMessage = "Somente números.")]
        public string Cpf {  get; set; }


        [Display(Name ="Nome ")]
        [Required(ErrorMessage = "Obrigatório")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres.")]
        public string Nome { get; set; }


        [Display(Name = "E-mail ")]
        [Required(ErrorMessage = "Obrigatório informar e-mail.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; }


		[Display(Name = "Senha ")]
		[Required(ErrorMessage = "Obrigatório informar uma senha.")]
		[MaxLength(200, ErrorMessage = "Somente números , máximo de 200 caracteres.")]
		[DataType(DataType.Password)]
		public string Senha { get; set; }


		[Display(Name = "Perfil ")]
		public Perfil Perfil { get; set; }


		public string produtoId { get; set; }


		[ForeignKey("produtoId")]
		public Produto Produto { get; set; }


	}
}
public enum Perfil
{
	Admin,
	User
}

