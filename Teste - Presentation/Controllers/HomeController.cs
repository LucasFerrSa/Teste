using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestePresentation.Models;

namespace TestePresentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly Api.IMovimentoManual _movimentoManual;
        public HomeController(Api.IMovimentoManual movimentosManual)
        {
            _movimentoManual = movimentosManual;
        }


        public async Task<ViewResult> Index()
        {
            Models.baseModel movimentos = await _movimentoManual.GetMovimentos();
            return View(movimentos);
        }

        

        [HttpPost]
        public async Task<ViewResult> Incluir(Models.MovimentoManual movimento)
        {
            await _movimentoManual.PostMovimentos(movimento);
            return View();
        }

    }
}