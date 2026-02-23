using CondominosAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace CondominosAppWeb.Data
{
    public class MensajesRepositorio
    {
        private readonly string _connectionString;

        public MensajesRepositorio()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["CondominosDB"].ConnectionString;
        }

        // =========================
        // Insertar
        // =========================
        public void Insertar(CondominosAppWeb.Models.Mensaje elMensaje)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Mensajes
                                (Titulo, Tipo, PublicacionFechaInicio,
                                PublicacionFechaFinal, Status, CreadoPorUsuarioId,
                                 FechaReunion, DuracionEstimadaMinutos,
                                 Agenda, LocacionFisica, LinkVirtual,
                                 ActividadFechaInicio, ActividadFechaFinal,
                                 LocacionActividad, FormatoActividad,
                                 Instrucciones, DescripcionRecordatorio)
                                VALUES
                                (@Titulo, @Tipo, @PublicacionFechaInicio,
                                @PublicacionFechaFinal, @Status, @CreadoPorUsuarioId,
                                 @FechaReunion, @DuracionEstimadaMinutos,
                                 @Agenda, @LocacionFisica, @LinkVirtual,
                                 @ActividadFechaInicio, @ActividadFechaFinal,
                                 @LocacionActividad, @FormatoActividad,
                                 @Instrucciones, @DescripcionRecordatorio)";

                SqlCommand cmd = new SqlCommand(query, conn);

                AddParameters(cmd, elMensaje);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // =========================
        // Modificar
        // =========================
        public void Modificar(CondominosAppWeb.Models.Mensaje elMensaje)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"UPDATE Messages SET
                        Titulo = @Titulo,
                        Tipo = @Tipo,
                        PublicacionFechaInicio = @PublicacionFechaInicio,
                        PublicacionFechaFinal = @PublicacionFechaFinal,
                        Status = @Status,
                        FechaReunion = @FechaReunion,
                        DuracionEstimadaMinutos = @DuracionEstimadaMinutos,
                        Agenda = @Agenda,
                        LocacionFisica = @LocacionFisica,
                        LinkVirtual = @LinkVirtual,
                        ActividadFechaInicio = @ActividadFechaInicio,
                        ActividadFechaFinal = @ActividadFechaFinal,
                        LocacionActividad = @LocacionActividad,
                        FormatoActividad = @FormatoActividad,
                        Instrucciones = @Instrucciones,
                        DescripcionRecordatorio = @DescripcionRecordatorio
                        WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);

                AddParameters(cmd, elMensaje);
                cmd.Parameters.AddWithValue("@Id", elMensaje.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // =========================
        // Obtener Mensajes activos
        // =========================
        public List<CondominosAppWeb.Models.Mensaje> ObtenerMensajesActivos()
        {
            List<CondominosAppWeb.Models.Mensaje> listadoMensajes = new List<CondominosAppWeb.Models.Mensaje>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"SELECT * FROM Mensajes
                                 WHERE Status = 'Publicado'
                                 AND PublicacionFechaInicio <= GETDATE()
                                 AND PublicacionFechaFinal >= GETDATE()
                                 ORDER BY PublicacionFechaInicio DESC";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listadoMensajes.Add(MapMessage(reader));
                    }
                }
            }

            return listadoMensajes;
        }

        // =========================
        // Obtener por ID
        // =========================
        public CondominosAppWeb.Models.Mensaje ObtenerPorId(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Mensajes WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapMessage(reader);
                    }
                }
            }

            return null;
        }

        // =========================
        // Obtener todos los mensajes
        // =========================
        public List<Mensaje> ObtenerTodosMsjs()
        {
            List<Mensaje> listadoMsjs = new List<Mensaje>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Mensajes ORDER BY PublicacionFechaInicio DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listadoMsjs.Add(MapMessage(reader));
                    }
                }
            }
            return listadoMsjs;
        }

        // =========================
        // Borrar
        // =========================
        public void Borrar(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Mensajes WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // =========================
        // Agregado de Parámetros y MapeoMensaje
        // =========================

        private void AddParameters(SqlCommand cmd, CondominosAppWeb.Models.Mensaje elMensaje)
        {
            cmd.Parameters.AddWithValue("@Titulo", elMensaje.Titulo);
            cmd.Parameters.AddWithValue("@Tipo", elMensaje.Tipo);
            cmd.Parameters.AddWithValue("@PublicacionFechaInicio", elMensaje.PublicacionFechaInicio);
            cmd.Parameters.AddWithValue("@PublicacionFechaFinal", elMensaje.PublicacionFechaFinal);
            cmd.Parameters.AddWithValue("@Status", elMensaje.Status);
            cmd.Parameters.AddWithValue("@CreadoPorUsuarioId", elMensaje.CreadoPorUsuarioId);

            cmd.Parameters.AddWithValue("@FechaReunion", (object)elMensaje.FechaReunion ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DuracionEstimadaMinutos", (object)elMensaje.DuracionEstimadaMinutos ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Agenda", (object)elMensaje.Agenda ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LocacionFisica", (object)elMensaje.LocacionFisica ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LinkVirtual", (object)elMensaje.LinkVirtual ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@ActividadFechaInicio", (object)elMensaje.ActividadFechaInicio ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ActividadFechaFinal", (object)elMensaje.ActividadFechaFinal ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LocacionActividad", (object)elMensaje.LocacionActividad ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@FormatoActividad", (object)elMensaje.FormatoActividad ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Instrucciones", (object)elMensaje.Instrucciones ?? DBNull.Value);

            cmd.Parameters.AddWithValue("@DescripcionRecordatorio", (object)elMensaje.DescripcionRecordatorio ?? DBNull.Value);
        }

        private CondominosAppWeb.Models.Mensaje MapMessage(SqlDataReader reader)
        {
            return new CondominosAppWeb.Models.Mensaje
            {
                Id = Convert.ToInt32(reader["Id"]),
                Titulo = reader["Titulo"].ToString(),
                Tipo = reader["Tipo"].ToString(),
                PublicacionFechaInicio = Convert.ToDateTime(reader["PublicacionFechaInicio"]),
                PublicacionFechaFinal = Convert.ToDateTime(reader["PublicacionFechaFinal"]),
                Status = reader["Status"].ToString(),
                CreadoPorUsuarioId = Convert.ToInt32(reader["CreadoPorUsuarioId"]),
                FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),

                FechaReunion = reader["FechaReunion"] as DateTime?,
                DuracionEstimadaMinutos = reader["DuracionEstimadaMinutos"] as int?,
                Agenda = reader["Agenda"].ToString(),
                LocacionFisica = reader["LocacionFisica"].ToString(),
                LinkVirtual = reader["LinkVirtual"].ToString(),

                ActividadFechaInicio = reader["ActividadFechaInicio"] as DateTime?,
                ActividadFechaFinal = reader["ActividadFechaFinal"] as DateTime?,
                LocacionActividad = reader["LocacionActividad"].ToString(),
                FormatoActividad = reader["FormatoActividad"].ToString(),
                Instrucciones = reader["Instrucciones"].ToString(),

                DescripcionRecordatorio = reader["DescripcionRecordatorio"].ToString()
            };
        }
    }
}