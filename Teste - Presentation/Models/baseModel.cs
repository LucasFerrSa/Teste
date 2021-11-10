using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestePresentation.Models;

namespace TestePresentation.Models
{
    public class baseModel
    {
        public List<MovimentoManual> MovimentoManual { get; set; }
        public List<Produto> Produto { get; set; }
        public List<ProdutoCosif> ProdutoCosif { get; set; }
    }
}