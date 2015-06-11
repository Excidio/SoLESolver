using Services;
using Services.SoLEAlgorithms.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly SoLESolverService _SoLEService;

        public HomeController()
        {
            _SoLEService = new SoLESolverService(new GaussianEliminationStrategy());
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(double[][] sole)
        {
            if (sole != null)
            {
                var weight = sole.Length;
                var height = sole.Max(x => x.Length);

                double[,] arraySole = new double[weight, height];
                for (var i = 0; i < weight; i++)
                {
                    for (var j = 0; j < sole[i].Length; j++)
                    {
                        arraySole[i, j] = sole[i][j];
                    }
                }

                ViewBag.SoLE = _SoLEService.SolveSoLE(arraySole);

                return PartialView("_calculate");
            }

            return Content("Ошибка ввода!");
        }
    }
}
