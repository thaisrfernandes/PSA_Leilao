using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TF_PSA.PL
{
    public class Item
    {
        public int ItemId { get; set; }
        [Display(Name = "Nome do item")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Informe nome")]
        [StringLength(100,
                MinimumLength = 3,
                ErrorMessage = "Nome deve ter entre 3 e 100 caracteres!")]
        public String Nome { get; set; }

        [Display(Name = "Descrição Breve do item")]
        [DataType(DataType.Text)]
        public String DescricaoBreve { get; set; }

        [Display(Name = "Descrição completa do item")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Informe uma descrição completa do item")]
        [StringLength(1000,
                MinimumLength = 3,
                ErrorMessage = "A descrição deve ter entre 3 e 1000 caracteres!")]
        public String DescricaoCompleta { get; set; }

        [Display(Name = "Categoria do item")]
        [Required]
        [DataType(DataType.Text)]
        public CategoriaEnum Categoria { get; set; }

        [Display(Name = "Imagem do item")]
        [DataType(DataType.Text)]
        public String Imagem { get; set; }

        public int LeilaoId { get; set; }
    }
}
