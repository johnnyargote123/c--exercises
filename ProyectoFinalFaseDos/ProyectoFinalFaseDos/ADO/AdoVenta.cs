using ProyectoFinalFaseDos.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalFaseDos.ADO
{
    public static class AdoVenta
    {

        private static string _stringConnection;


        static AdoVenta()
        {
            _stringConnection = @"Server=AV35351\MSSQLSERVER2022; Database=coderhouse; Trusted_Connection=True;";
        }

        public static Venta GetSellById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "SELECT * FROM Venta WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int getedId = Convert.ToInt32(reader["id"]);
                    string getedCommet = reader.GetString(1);
                    int getedUserId = reader.GetInt32(2);

                    Venta producto = new Venta(id, getedCommet, getedUserId);

                    return producto;
                }
                throw new Exception("Not found id");

            }

        }

        public static List<Venta> ListSells()
        {
            List<Venta> ventas = new List<Venta>();

            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "SELECT * FROM Venta";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string comentarios = reader.GetString(1);
                    int idUsuario = reader.GetInt32(2);

                    Venta venta = new Venta(id, comentarios, idUsuario);
                    ventas.Add(venta);
                }
            }

            return ventas;
        }
        public static bool AddSell(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "INSERT INTO Venta (Comentarios,IdUsuario) VALUES (@comentarios,@idUsuario)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("@idUsuario", venta.IdUsuario);
       

                connection.Open();
                return command.ExecuteNonQuery() > 0;

            }
            throw new Exception("Could not add Sell");
        }

        public static int DeleteSell(int id)
        {
            if (id != -1)
            {
                using (SqlConnection connection = new SqlConnection(_stringConnection))
                {

                    string query = "DELETE FROM Venta WHERE id = @id";


                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("No sell found with the provided ID.");
                    }
                    return id;
                }
            }
            else
            {
                throw new Exception("Could not delete sell");
            }
        }

        public static bool UpdateSellById(int id, Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "UPDATE Venta SET Comentarios = @comentarios, IdUsuario = @idUsuario WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("@idUsuario", venta.IdUsuario);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            throw new Exception("Could not update product");
        }
    }
}
