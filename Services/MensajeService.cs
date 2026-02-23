using CondominosAppWeb.Data;
using CondominosAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace CondominosAppWeb.Services
{
    public class MensajeService
    {
        private readonly MensajesRepositorio _repositorio;

        public MensajeService()
        {
            _repositorio = new MensajesRepositorio();
        }

        // =========================
        // Crear Mensaje
        // =========================
        public void CrearMensaje(CondominosAppWeb.Models.Mensaje elMensaje)
        {
            ValidarMensaje(elMensaje);

            elMensaje.Status = "NoPublicado";
            elMensaje.FechaCreacion = DateTime.Now;

            _repositorio.Insertar(elMensaje);
        }

        // =========================
        // Publicar Mensaje
        // =========================
        public void PublicarMensaje(int elId)
        {
            var elMensaje = _repositorio.ObtenerPorId(elId);

            if (elMensaje == null)
                throw new Exception("Mensaje no encontrado.");

            ValidarFechaPublicacion(elMensaje);

            elMensaje.Status = "Publicado";

            _repositorio.Modificar(elMensaje);
        }

        // =========================
        // Obtener mensajes activos
        // =========================
        public List<CondominosAppWeb.Models.Mensaje> ObtenerMensajesActivos()
        {
            return _repositorio.ObtenerMensajesActivos();
        }

        // =========================
        // Obtener todos los mensajes
        // =========================
        public List<Mensaje> ObtenerMensajesTodos()
        {
            return _repositorio.ObtenerTodosMsjs();
        }

        // =========================
        // Obtener mensaje por Id
        // =========================
        public Mensaje ObtenerMensajeID(int elID)
        {
            return _repositorio.ObtenerPorId(elID);
        }

        // =========================
        // Modificar
        // =========================
        public void ModificarMensaje(CondominosAppWeb.Models.Mensaje elMensaje)
        {
            _repositorio.Modificar(elMensaje);
        }

        // =========================
        // Borrar
        // =========================
        public void BorrarMensaje(int elId)
        {
            var elMensaje = _repositorio.ObtenerPorId(elId);

            if (elMensaje == null)
                throw new Exception("Mensaje no encontrado.");

            if (elMensaje.PublicacionFechaFinal < DateTime.Now)
                throw new Exception("No es posible borrar mensajes expirados.");

            _repositorio.Borrar(elId);
        }

        // =========================
        // Validaciones
        // =========================
        private void ValidarMensaje(CondominosAppWeb.Models.Mensaje elMensaje)
        {
            if (string.IsNullOrWhiteSpace(elMensaje.Titulo))
                throw new Exception("El título es requerido.");

            if (elMensaje.PublicacionFechaInicio >= elMensaje.PublicacionFechaFinal)
                throw new Exception("Fecha de publicación debe ser anterior a fecha de finalización.");

            if (elMensaje.Tipo == "Reunion")
                ValidaReunion(elMensaje);

            if (elMensaje.Tipo == "ActividadSocial")
                ValidaActividadSocial(elMensaje);

            if (elMensaje.Tipo == "Recordatorio")
                ValidaRecordatorio(elMensaje);
        }

        private void ValidaReunion(CondominosAppWeb.Models.Mensaje elMensaje)
        {
            if (!elMensaje.FechaReunion.HasValue)
                throw new Exception("La fecha de reunión es requerida.");

            if (string.IsNullOrWhiteSpace(elMensaje.Agenda))
                throw new Exception("Agenda de reunión es requerida.");

            if (!string.IsNullOrWhiteSpace(elMensaje.LinkVirtual))
            {
                if (!Uri.IsWellFormedUriString(elMensaje.LinkVirtual, UriKind.Absolute))
                    throw new Exception("Link virtual debe ser un URL válido.");
            }
        }

        private void ValidaActividadSocial(CondominosAppWeb.Models.Mensaje elMensaje)
        {
            if (!elMensaje.ActividadFechaInicio.HasValue ||
                !elMensaje.ActividadFechaFinal.HasValue)
                throw new Exception("Las fechas de la actividad son requeridas.");

            if (elMensaje.ActividadFechaInicio >= elMensaje.ActividadFechaFinal)
                throw new Exception("Fecha de actividad debe ser anterior a fecha de finalización.");
        }

        private void ValidaRecordatorio(CondominosAppWeb.Models.Mensaje elMensaje)
        {
            if (string.IsNullOrWhiteSpace(elMensaje.DescripcionRecordatorio))
                throw new Exception("Descripción de recordatorio es requerido.");
        }

        private void ValidarFechaPublicacion(Mensaje elMensaje)
        {
            if (elMensaje.PublicacionFechaInicio > DateTime.Now)
                throw new Exception("No se puede publicar antes de la fecha de inicio.");
        }
    }
}