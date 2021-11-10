using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApp.Infraestructure.Model
{
    public class ProdutoCosif
    {
        public string COD_PRODUTO { get; set; }
        public string COD_COSIF { get; set; }
        public string COD_CLASSIFICACAO { get; set; }
        public string STA_STATUS { get; set; }
    }
}
