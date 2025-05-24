using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Prog5_2c_2025.Models;

namespace Prog5_2c_2025.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var estudiante = new Estudiante(1, "Juan Perez", 85);
            return View(estudiante);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Sumar 2 numeros
        public IActionResult Suma2()
        {
            return View();
        }
        public IActionResult add2()
        {
            int num1 = Convert.ToInt32(HttpContext.Request.Form["tx1"].ToString());
            int num2 = Convert.ToInt32(HttpContext.Request.Form["tx2"].ToString());
            int result = num1 + num2;
            ViewBag.SumResult2 = result.ToString();
            return View("Suma2");
        }
        #endregion Sumar 2 numeros

        #region Calculadora basica
        public IActionResult bCalc()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Suma()
        {
            try
            {
                int num1 = Convert.ToInt32(HttpContext.Request.Form["n1"].ToString());
                int num2 = Convert.ToInt32(HttpContext.Request.Form["n2"].ToString());
                ViewBag.Result = "Resultado de la suma: " + (num1 + num2).ToString();
            }
            catch (Exception)
            {
                ViewBag.Result = "Datos erroneos ingresados.";
            }
            return View("bCalc");
        }

        [HttpPost]
        public IActionResult Resta()
        {
            try
            {
                int num1 = Convert.ToInt32(HttpContext.Request.Form["n1"].ToString());
                int num2 = Convert.ToInt32(HttpContext.Request.Form["n2"].ToString());
                ViewBag.Result = "Resultado de la resta: " + (num1 - num2).ToString();
            }
            catch (Exception)
            {
                ViewBag.Result = "Datos erroneos ingresados.";
            }
            return View("bCalc");
        }
        [HttpPost]
        public IActionResult Multiplicacion()
        {
            try
            {
                int num1 = Convert.ToInt32(HttpContext.Request.Form["n1"].ToString());
                int num2 = Convert.ToInt32(HttpContext.Request.Form["n2"].ToString());
                ViewBag.Result = "Resultado de la multiplicaci�n: " + (num1 * num2).ToString();
            }
            catch (Exception)
            {
                ViewBag.Result = "Datos erroneos ingresados.";
            }
            return View("bCalc");
        }
        [HttpPost]
        public IActionResult Division()
        {
            try
            {
                decimal num1 = Convert.ToDecimal(HttpContext.Request.Form["n1"].ToString());
                decimal num2 = Convert.ToDecimal(HttpContext.Request.Form["n2"].ToString());
                decimal f = num1 / num2;
                ViewBag.Result = "Resultado de la divisi�n: " + f.ToString();
            }
            catch (Exception)
            {
                ViewBag.Result = "Datos erroneos ingresados.";
            }
            return View("bCalc");
        }

        #endregion Calculadora basica
    }
}
