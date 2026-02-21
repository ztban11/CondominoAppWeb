using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CondominosAppWeb.Models
{
    public class Condomino
    {
        public Condomino() { }
        public string idTipo { get; set; }
        public string id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string numeroFilial { get; set; }
        public bool tieneConstruccion { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}