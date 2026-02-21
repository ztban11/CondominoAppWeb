using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using CondominosAppWeb.Models;

namespace CondominosAppWeb.Data
{
    public class CondominosRepositorio
    {
        private string connectionString =
        ConfigurationManager.ConnectionStrings["CondominosDB"].ConnectionString;

        public void AgregarCondomino(CondominosAppWeb.Models.Condomino elCondomino)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Condominos
                            (IdTipo, Identificacion, Nombre, Apellidos,
                             FechaNacimiento, NumeroFilial, TieneConstruccion, Email, Password)
                             VALUES
                            (@IdTipo, @Identificacion, @Nombre, @Apellidos,
                             @FechaNacimiento, @NumeroFilial, @TieneConstruccion, @Email, @Password)";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@IdTipo", elCondomino.idTipo);
                cmd.Parameters.AddWithValue("@Identificacion", elCondomino.id);
                cmd.Parameters.AddWithValue("@Nombre", elCondomino.nombre);
                cmd.Parameters.AddWithValue("@Apellidos", elCondomino.apellidos);
                cmd.Parameters.AddWithValue("@FechaNacimiento", elCondomino.fechaNacimiento);
                cmd.Parameters.AddWithValue("@NumeroFilial", elCondomino.numeroFilial);
                cmd.Parameters.AddWithValue("@TieneConstruccion", elCondomino.tieneConstruccion);
                cmd.Parameters.AddWithValue("@Email", elCondomino.email);
                cmd.Parameters.AddWithValue("@Password", elCondomino.password);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}