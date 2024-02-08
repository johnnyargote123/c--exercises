using ProyectoFinalFaseDos.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalFaseDos.ADO
{
    public static class AdoPersonas
    {

        private static string _stringConnection;


        static AdoPersonas()
        {
            _stringConnection = @"Server=AV35351\MSSQLSERVER2022; Database=coderhouse; Trusted_Connection=True;";
        }

        public static Usuario GetUserById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "SELECT * FROM Usuario WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int getedId = Convert.ToInt32(reader["id"]);
                    string getedName = reader.GetString(1);
                    string getedLastName = reader.GetString(2);
                    string getedUserName = reader.GetString(3);
                    string getedPassword = reader.GetString(4);
                    string getedMail = reader.GetString(5);

                    Usuario usuario = new Usuario(id, getedName, getedLastName, getedUserName, getedPassword, getedMail);

                    return usuario;
                }
                throw new Exception("Not found id");

            }

        }

        public static List<Usuario> ListUsers()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "SELECT * FROM Usuario";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    string nombreUsuario = reader.GetString(3);
                    string contrasena = reader.GetString(4);
                    string mail = reader.GetString(5);

                    Usuario usuario = new Usuario(id, nombre, apellido, nombreUsuario, contrasena, mail);
                    usuarios.Add(usuario);
                }
            }

            return usuarios;
        }


        public static bool AddUser(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) VALUES (@nombre,@apellido,@nombreUsuario,@password,@mail)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("@password", usuario.Contrasena);
                command.Parameters.AddWithValue("@mail", usuario.Mail);

                connection.Open();
                return command.ExecuteNonQuery() > 0;

            }
            throw new Exception("Could not add user");
        }

        public static int DeleteUser(int id)
        {
            if (id != -1)
            {
                using (SqlConnection connection = new SqlConnection(_stringConnection))
                {

                    string query = "DELETE FROM Usuario WHERE id = @id";


                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("No user found with the provided ID.");
                    }
                    return id;
                }
            }
            else
            {
                throw new Exception("Could not delete user");
            }
        }

        public static bool UpdateUserById(int id, Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "UPDATE Usuario SET Nombre = @nombre, Apellido = @apellido, NombreUsuario = @nombreUsuario, Contraseña = @password, Mail = @mail WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("@password", usuario.Contrasena);
                command.Parameters.AddWithValue("@mail", usuario.Mail);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            throw new Exception("Could not update user");
        }
    }
}
