using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CondominosAppWeb.Models
{
    public class Condomino
    {
        public string TipoID { get; set; }
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string NumeroFilial { get; set; }
        public bool tieneConstruccion { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}