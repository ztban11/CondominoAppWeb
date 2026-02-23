using CondominosAppWeb.Models;
using CondominosAppWeb.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            gvMensajes.DataSource = _service.ObtenerMensajesActivos();
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

                _service.CrearMensaje(elMensaje);

                desplegarMsjExito("Mensaje almacenado satisfactoriamente.");

                pnlFormulario.Visible = false;
            }
            catch (Exception ex)
            {
                desplegarMsjError(ex.Message);
            }
            CargarMensajes();
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
            if (e.CommandName == "DeleteMessage")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvMensajes.DataKeys[index].Value);

                _service.BorrarMensaje(id);
                CargarMensajes();
            }
        }
    }
}