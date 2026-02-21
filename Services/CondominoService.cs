using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CondominosAppWeb.Models;

namespace CondominosAppWeb.Services
{
    public static class CondominoService
    {
        private static List<CondominosAppWeb.Models.Condomino> condominos = new List<CondominosAppWeb.Models.Condomino>();

        public static bool EmailExists(string email)
        {
            return condominos.Any(o => o.email.ToLower() == email.ToLower());
        }

        public static void AgregarCondomino(CondominosAppWeb.Models.Condomino elCondomino)
        {
            condominos.Add(elCondomino);
        }

        public static List<CondominosAppWeb.Models.Condomino> GetAll()
        {
            return condominos;
        }
    }
}