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
    public class MovimentoManualController : ControllerBase
    {
        private readonly Infraestructure.Interfaces.IMovimentoManual _MovimentacaoManual;
        private readonly ILogger<MovimentoManualController> _logger;

        public MovimentoManualController(ILogger<MovimentoManualController> logger, Infraestructure.Interfaces.IMovimentoManual movimentacaoManual)
        {
            _logger = logger;
            _MovimentacaoManual = movimentacaoManual;
            _MovimentacaoManual.create();

        }

        [HttpGet]
        public IEnumerable<MovimentoManual> Get()
        {
            return (IEnumerable<MovimentoManual>)_MovimentacaoManual.GetAll();
        }

        [HttpPost]
        public async Task<MovimentoManual> Post(MovimentoManual movimento)
        {
            return await _MovimentacaoManual.Post(movimento);
        }
    }
}
