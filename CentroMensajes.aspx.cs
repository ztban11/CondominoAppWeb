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
    public partial class CentroMensajes : System.Web.UI.Page
    {
        private readonly MensajeService _service = new MensajeService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlFormulario.Visible = false;
                CargarMensajes();
            }
        }

        private void CargarMensajes()
        {
            gvMensajes.DataSource = _service.ObtenerMensajesTodos();
            gvMensajes.DataBind();
        }

        // =========================
        // Botón: Nuevo
        // =========================
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            pnlFormulario.Visible = true;
        }

        // =========================
        // Seleccionar: Tipo
        // =========================
        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            EsconderPaneles();

            switch (ddlTipo.SelectedValue)
            {
                case "Reunion":
                    pnlReunion.Visible = true;
                    break;

                case "SocialActivity":
                    pnlSocial.Visible = true;
                    break;

                case "Reminder":
                    pnlRecordatorio.Visible = true;
                    break;
            }
        }

        // =========================
        // Botón: Salvar
        // =========================
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Mensaje elMensaje = ConstructorMensaje();

                if (!string.IsNullOrEmpty(hiddenMessageId.Value))
                {
                    elMensaje.Id = Convert.ToInt32(hiddenMessageId.Value);
                    _service.ModificarMensaje(elMensaje);
                }
                else
                {
                    _service.CrearMensaje(elMensaje);
                    desplegarMsjExito("Mensaje almacenado satisfactoriamente.");
                }

                hiddenMessageId.Value = string.Empty;
                pnlFormulario.Visible = false;
                CargarMensajes();
            }
            catch (Exception ex)
            {
                desplegarMsjError(ex.Message);
            }
        }

        // =========================
        // Construcción de Mensaje
        // =========================
        private CondominosAppWeb.Models.Mensaje ConstructorMensaje()
        {
            Mensaje elMensaje = new Mensaje();

            elMensaje.Titulo = txtTitulo.Text;
            elMensaje.Tipo = ddlTipo.SelectedValue;

            elMensaje.PublicacionFechaInicio = DateTime.Parse(txtFechaReunion.Text);
            elMensaje.PublicacionFechaFinal = DateTime.Parse(txtFechaReunion.Text).AddDays(1);

            elMensaje.CreadoPorUsuarioId = 1; // temporal académico

            if (elMensaje.Tipo == "Reunion")
            {
                elMensaje.FechaReunion = DateTime.Parse(txtFechaReunion.Text);
                elMensaje.Agenda = txtAgenda.Text;
            }

            if (elMensaje.Tipo == "ActividadSocial")
            {
                elMensaje.ActividadFechaInicio = DateTime.Parse(txtActividadFechaInicio.Text);
                elMensaje.ActividadFechaFinal = DateTime.Parse(txtActividadFechaFinal.Text);
            }

            if (elMensaje.Tipo == "Recordatorio")
            {
                elMensaje.DescripcionRecordatorio = txtRecordatorio.Text;
            }

            return elMensaje;
        }

        // =========================
        // Operaciones UI
        // =========================
        private void EsconderPaneles()
        {
            pnlReunion.Visible = false;
            pnlSocial.Visible = false;
            pnlRecordatorio.Visible = false;
        }

        private void LimpiarFormulario()
        {
            txtTitulo.Text = "";
            ddlTipo.SelectedIndex = 0;

            txtFechaReunion.Text = "";
            txtAgenda.Text = "";

            txtActividadFechaInicio.Text = "";
            txtActividadFechaFinal.Text = "";

            txtRecordatorio.Text = "";

            EsconderPaneles();
        }

        private void desplegarMsjExito(string elMensaje)
        {
            Response.Write("<script>alert('" + elMensaje + "');</script>");
        }

        private void desplegarMsjError(string elMensaje)
        {
            Response.Write("<script>alert('Error: " + elMensaje + "');</script>");
        }

        protected void gvMensajes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvMensajes.DataKeys[index].Value);

            if (e.CommandName == "Borrar")
            {
                _service.BorrarMensaje(id);
                CargarMensajes();
            }

            if (e.CommandName == "Modificar")
            {
                CargarMensajesModificar(id);
            }
        }

        protected void gvMensajes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

                if (status == "Publicado")
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Green;

                if (status == "NoPublicado")
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Orange;

                if (status == "Expirado")
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
            }
        }

        private void CargarMensajesModificar(int elId)
        {
            var unMensaje = _service.ObtenerMensajeID(elId);

            if (unMensaje != null)
            {
                hiddenMessageId.Value = unMensaje.Id.ToString();

                txtTitulo.Text = unMensaje.Titulo;
                ddlTipo.SelectedValue = unMensaje.Tipo;

                txtActividadFechaInicio.Text = unMensaje.PublicacionFechaInicio.ToString("yyyy-MM-ddTHH:mm");
                txtActividadFechaFinal.Text = unMensaje.PublicacionFechaFinal.ToString("yyyy-MM-ddTHH:mm");

                if (unMensaje.FechaReunion.HasValue)
                    txtFechaReunion.Text = unMensaje.FechaReunion.Value.ToString("yyyy-MM-ddTHH:mm");

                pnlFormulario.Visible = true;
            }
        }
    }
}