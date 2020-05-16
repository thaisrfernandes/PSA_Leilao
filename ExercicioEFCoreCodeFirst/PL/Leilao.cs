using System;
using System.Collections.Generic;
using System.Text;

namespace TF_PSA.PL
{
    public class Leilao
    {
        public int LeilaoId { get; set; }
        public bool LanceAberto { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataFinal { get; set; }
        public String IdUsuarioResponsavel { get; set; }
        public ICollection<Item> Lote { get; set; }
        public ICollection<Lance> Lances { get; set; }

        public void novoLanceOferta(double Valor, String EmailResponsavel)
        {

        }

        public void novoLanceDemanda(double Valor, String EmailResponsavel)
        {

        }

        //implementar: abrirleilao, fecharleilao, getLances(depende do bool LanceAberto), 

    }
}
