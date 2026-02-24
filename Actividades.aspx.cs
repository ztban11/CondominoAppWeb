using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using CondominosAppWeb.Models;
using CondominosAppWeb.Services;

namespace CondominosAppWeb
{
    public partial class Actividades : System.Web.UI.Page
    {
        private readonly MensajeService _serviceActividades = new MensajeService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlActividades.Visible = false;
                CargarMensajesActividades();
            }
        }

        private void CargarMensajesActividades()
        {
            gvActividades.DataSource = _serviceActividades.ObtenerMensajesTodos();
            gvActividades.DataBind();
        }

    }
}