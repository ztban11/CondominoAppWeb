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
        public static string RegistrarCondomino(Condomino elCondomino)
        {
            if (CondominoService.EmailExists(elCondomino.Email))
            {
                return "Email ya se encuentra registrado.";
            }

            CondominoService.AddOwner(elCondomino);
            return "Registro satisfactorio!";
        }
    }
}