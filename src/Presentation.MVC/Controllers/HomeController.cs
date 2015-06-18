using Services;
using Services.SoLEAlgorithms.ImplementationSoLEParserStrategy;
using Services.SoLEAlgorithms.ImplementationSoLESolverStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly SoLESolverService _SoLESolverService;
        private readonly SoLEParserService _SoLEParserService;

        public HomeController()
        {
            _SoLESolverService = new SoLESolverService(new GaussianEliminationStrategy());
            _SoLEParserService = new SoLEParserService(new MyParseStrategy());
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(string sole)
        {
            if (!string.IsNullOrEmpty(sole))
            {
                var equations = sole.Trim().ToLower().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                if (_SoLEParserService.Parse(equations))
                {
                    ViewBag.SoLENumbers = _SoLESolverService.SolveSoLE(_SoLEParserService.GetExtractedSoLENumbers());
                    ViewBag.SoLEVariables = _SoLEParserService.GetExtractedSoLEVariables().ToArray();

                    return PartialView("_calculate");
                }
            }

            return Content("Ошибка ввода!");
        }
    }
}
