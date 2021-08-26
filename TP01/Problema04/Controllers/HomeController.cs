using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Problema04.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Problema04.Controllers
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

        public string Problema4(string a, string b)
        {
            float num1, num2;
            string fail = "Error en el ingreso de datos. ";
            try
            {
                if (!float.TryParse(a, out num1))
                {
                    return (fail + "Es posible que el PRIMER valor (o ambos), sea un numero muy grande o muy chico, ó que sean caracteres.");
                }
                else
                {
                    if (!float.TryParse(b, out num2))
                    {
                        return (fail + "Es posible que el SEGUNDO, valor sea un numero muy grande o muy chico, ó que sean caracteres.");
                    }
                    else
                    {
                        if (num2 == 0)
                        {
                            return fail + "No se puede efectuar la division por cero.";
                        }
                        else
                        {
                            return Convert.ToString( num1 / num2);
                        }
                    }
                }
            }
            catch (OverflowException ex)
            {
                return "Es posible que el resultado de la operacion aritmetica sea muy grande o muy pequeño.\n" + ex.Message;
            }
            catch (Exception ex)
            {
                return "Error inesperado\n\n" + ex.Message;
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
