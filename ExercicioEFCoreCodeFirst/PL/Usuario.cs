using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TF_PSA.PL
{
    public class Usuario
    {
        public String UsuarioId { get; set; }

        [Display(Name = "Nome")]
        [Required]
        [DataType(DataType.Text)]
        public String Nome { get; set; }

        [Display(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Display(Name = "CPF")]
        [RegularExpression(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})",
                ErrorMessage = "cpf invalido!")]
        public String Cpf { get; set; }

        [Display(Name = "CNPJ")]
        [RegularExpression(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})",
                ErrorMessage = "cnpj invalido!")]
        public String Cnpj { get; set; }

        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        public String Telefone { get; set; }
    }
}
