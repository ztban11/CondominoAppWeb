using CondominosAppWeb.Data;
using CondominosAppWeb.Models;
using CondominosAppWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CondominosAppWeb
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string RegistrarCondomino(CondominosAppWeb.Models.Condomino elCondomino)
        {
            if (CondominoService.EmailExists(elCondomino.email))
            {
                return "Email ya se encuentra registrado.";
            }

            CondominosRepositorio repositorio = new CondominosRepositorio();
            repositorio.AgregarCondomino(elCondomino);
            return "Registro satisfactorio!";
        }
    }
}