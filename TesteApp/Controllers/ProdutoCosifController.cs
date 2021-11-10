using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoCosifController : ControllerBase
    {
        private readonly Infraestructure.Interfaces.IProdutoCosif _produtoCosif;
        private readonly ILogger<ProdutoCosifController> _logger;

        public ProdutoCosifController(ILogger<ProdutoCosifController> logger, Infraestructure.Interfaces.IProdutoCosif produtoCosif)
        {
            _logger = logger;
            _produtoCosif = produtoCosif;
            _produtoCosif.create();
        }

        [HttpGet]
        public IEnumerable<Infraestructure.Model.ProdutoCosif> Get()
        {
            return (IEnumerable<Infraestructure.Model.ProdutoCosif>)_produtoCosif.GetAll();
        }


    }
}
