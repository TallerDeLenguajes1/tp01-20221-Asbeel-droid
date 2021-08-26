using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Problema01.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Problema01.Controllers
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
            return View();
        }

        public string Problema1(string a)
        {
            int num1;
            string fail = "Error en el ingreso de datos. ";
            try
            {
                if (!int.TryParse(a, out num1))
                {
                    return (fail + "Es posible que el valor sea un numero muy grande o muy chico, ó que sean caracteres.");
                }
                else
                {
                    return Convert.ToString(num1 * num1);
                }
            }
            catch (Exception ex)
            {
                return "Error inesperado.\n\n" + ex.Message;
            }
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
    }
}
