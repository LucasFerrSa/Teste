using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApp.Infraestructure.Interfaces
{
    public interface IProdutoCosif
    {
        Task create();
        IEnumerable<Model.ProdutoCosif> GetAll();
    }
}
