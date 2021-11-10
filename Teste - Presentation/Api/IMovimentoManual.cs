using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestePresentation.Api
{
    public interface IMovimentoManual
    {
        Task<Models.baseModel> GetMovimentos();
        Task PostMovimentos(Models.MovimentoManual movimento);
        
    }
}