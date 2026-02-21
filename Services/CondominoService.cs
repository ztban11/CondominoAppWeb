using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CondominosAppWeb.Models;

namespace CondominosAppWeb.Services
{
    public static class CondominoService
    {
        private static List<Condomino> condominos = new List<Condomino>();

        public static bool EmailExists(string email)
        {
            return condominos.Any(o => o.email.ToLower() == email.ToLower());
        }

        public static void AgregarCondomino(Condomino elCondomino)
        {
            condominos.Add(elCondomino);
        }

        public static List<Condomino> GetAll()
        {
            return condominos;
        }
    }
}