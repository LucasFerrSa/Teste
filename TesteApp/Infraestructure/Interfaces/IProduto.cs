using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApp.Infraestructure.Interfaces
{
    public interface IProduto
    {
        Task create();
        IEnumerable<Model.Produto> GetAll();
    }
}
