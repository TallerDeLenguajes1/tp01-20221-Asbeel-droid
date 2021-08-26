using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problema03.APIs
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Parametros
    {
        public List<string> campos { get; set; }
    }

    public class Provincia
    {
        public string id { get; set; }
        public string nombre { get; set; }
    }

    public class ApiProvincias
    {
        public int cantidad { get; set; }
        public int inicio { get; set; }
        public Parametros parametros { get; set; }
        public List<Provincia> provincias { get; set; }
        public int total { get; set; }
    }


}
