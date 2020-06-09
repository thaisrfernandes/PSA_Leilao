using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TF_PSA.PL
{
    public class Leilao
    {
        public int LeilaoId { get; set; }

        [Display(Name = "Valor do Leilão")]
        [Required(ErrorMessage = "Informe o valor do leilão")]
        public double Preco { get; set; }

        [Display(Name = "Inicio do Leilão")]
        //[DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Informe uma data")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Fim do Leilão")]
        //[DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Informe uma data")]
        public DateTime DataFinal { get; set; }
        
        public String IdUsuarioResponsavel { get; set; }

        public TipoLeilao Categoria { get; set; }
        
        public TipoLance CategoriaDeLance { get; set; }

        public ICollection<Item> Lote { get; set; }

        public ICollection<Lance> Lances { get; set; }

        
    }
}
