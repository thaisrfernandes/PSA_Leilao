using System;
using System.Collections.Generic;
using System.Text;

namespace TF_PSA.PL
{
    public class Item
    {
        public int ItemId { get; set; }
        public String DescricaoBreve { get; set; }
        public String DescricaoCompleta { get; set; }
        public Categoria Categoria { get; set; }
    }
}
