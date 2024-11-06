using System.ComponentModel.DataAnnotations;

namespace webPessoa.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Campo de preenchimento obrigatório")]
        public int Numero{ get; set; }
        [Required(ErrorMessage = "Campo de preenchimento obrigatório")]
        [Display(Name ="DDD")]
        
        public int Ddd { get; set; }
        [Required(ErrorMessage = "Cadastrar número diferente do cadastrado anteriormente")]
        public int Tipo { get; set; }
        public Telefonetipo TipoObj { get; set; } = new Telefonetipo(); 
    }
}
