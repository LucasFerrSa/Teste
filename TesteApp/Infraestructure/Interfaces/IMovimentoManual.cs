using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteApp.Infraestructure.Model;

namespace TesteApp.Infraestructure.Interfaces
{
    public interface IMovimentoManual
    {
        Task create();
        IEnumerable<Model.MovimentoManual> GetAll();

        Task<MovimentoManual> Post(Model.MovimentoManual movimento);

    }
}
