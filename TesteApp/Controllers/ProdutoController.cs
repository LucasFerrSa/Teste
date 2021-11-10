using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteApp.Infraestructure.Model;

namespace TesteApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly Infraestructure.Interfaces.IProduto _produto;
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger, Infraestructure.Interfaces.IProduto produto)
        {
            _logger = logger;
            _produto = produto;
            _produto.create();
        }

        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            return (IEnumerable<Produto>) _produto.GetAll();
        }


    }
}
