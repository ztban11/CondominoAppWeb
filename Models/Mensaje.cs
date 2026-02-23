using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CondominosAppWeb.Models
{
    public class Mensaje
    {
        public int Id { get; set; }

        // =========================
        // Campos comunes
        // =========================
        public string Titulo { get; set; }
        public string Tipo { get; set; } // Reunion, ActividadSocial, Recordatorio
        public DateTime PublicacionFechaInicio { get; set; }
        public DateTime PublicacionFechaFinal { get; set; }
        public string Status { get; set; } // NoPublicado, Publicado, Expirado

        public int CreadoPorUsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }

        // =========================
        // Campos Reunión
        // =========================
        public DateTime? FechaReunion { get; set; }
        public int? DuracionEstimadaMinutos { get; set; }
        public string Agenda { get; set; }
        public string LocacionFisica { get; set; }
        public string LinkVirtual { get; set; }

        // =========================
        // Campos Actividad Social
        // =========================
        public DateTime? ActividadFechaInicio { get; set; }
        public DateTime? ActividadFechaFinal { get; set; }
        public string LocacionActividad { get; set; }
        public string FormatoActividad { get; set; } // Formal, Informal
        public string Instrucciones { get; set; }

        // =========================
        // Recordatorio
        // =========================
        public string DescripcionRecordatorio { get; set; }
    }
}