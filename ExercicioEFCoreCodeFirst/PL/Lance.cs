using System;
using System.Collections.Generic;
using System.Text;

namespace TF_PSA.PL
{
    public class Lance
    {
        public DateTime Data { get; set; }
        public int LanceId { get; set; }
        public double Valor { get; set; }
        public String EmailUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int LeilaoId { get; set; }
        public Leilao Leilao { get; set; }
    }
}
