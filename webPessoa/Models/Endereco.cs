using System.ComponentModel.DataAnnotations;

namespace webPessoa.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campode de preenchimento obrigatório")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; } = string.Empty;

        public int? Numero { get; set; }
        public int? Cep { get; set; }
        public  string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado{ get; set; } = string.Empty;
    }
}
