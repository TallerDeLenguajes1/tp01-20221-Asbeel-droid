using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Problema03.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Problema03.APIs;
using System.Net;
using System.IO;
using System.Text.Json;

namespace Problema03.Controllers
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

        public string Problema3()
        {
            string url = $"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            string ListProvincias = "";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader != null)
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();

                                ApiProvincias ProvinciasArg = JsonSerializer.Deserialize<ApiProvincias>(responseBody);
                                //List<Provincia> prov = ProvinciasArg.provincias;
                                
                                for (int i=0; i < ProvinciasArg.provincias.Count; i++)
                                {
                                    ListProvincias += ProvinciasArg.provincias[i].nombre + " -> id: " + ProvinciasArg.provincias[i].id + "\n";
                                }
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return "Error con el servicio web, " + ex.Message ;
            }
            catch (Exception ex)
            {
                return "Error inesperado" + ex.Message;
            }

            return ListProvincias;
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
