using ProyectoFinalFaseDos.Database.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalFaseDos.ADO
{
    public static class AdoProductos
    {
        private static string _stringConnection;


        static AdoProductos()
        {
            _stringConnection = @"Server=AV35351\MSSQLSERVER2022; Database=coderhouse; Trusted_Connection=True;";
        }

        public static Producto GetProductById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "SELECT * FROM Producto WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int getedId = Convert.ToInt32(reader["id"]);
                    string getedDescription = reader.GetString(1);
                    double getedPrice = Convert.ToDouble(reader.GetDecimal(2));
                    double getedSalePrice = Convert.ToDouble(reader.GetDecimal(3));
                    int getedStock = reader.GetInt32(4);
                    int getedUserId = reader.GetInt32(5);

                    Producto producto = new Producto(id, getedDescription, getedPrice, getedSalePrice, getedStock, getedUserId);

                    return producto;
                }
                throw new Exception("Not found id");

            }

        }

        public static List<Producto> ListProducts()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "SELECT * FROM Producto";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string descripcion = reader.GetString(1);
                    double costo = Convert.ToDouble(reader.GetDecimal(2));
                    double precioVenta = Convert.ToDouble(reader.GetDecimal(3));
                    int stock = reader.GetInt32(4);
                    int idUsuario = reader.GetInt32(5);

                    Producto producto = new Producto(id, descripcion, costo, precioVenta, stock, idUsuario);
                    productos.Add(producto);
                }
            }

            return productos;
        }

        public static bool AddProduct(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "INSERT INTO Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario) VALUES (@descripciones,@costo,@precioVenta,@stock,@idUsuario)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@descripciones", producto.Descripcion);
                command.Parameters.AddWithValue("@costo", producto.Costo);
                command.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@stock", producto.Stock);
                command.Parameters.AddWithValue("@idUsuario", producto.idUsuario);

                connection.Open();
                return command.ExecuteNonQuery() > 0;

            }
            throw new Exception("Could not add product");
        }


        public static int DeleteProduct(int id)
        {
            if (id != -1)
            {
                using (SqlConnection connection = new SqlConnection(_stringConnection))
                {

                    string query = "DELETE FROM Producto WHERE id = @id";


                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("No product found with the provided ID.");
                    }
                    return id;
                }
            }
            else
            {
                throw new Exception("Could not delete product");
            }
        }

        public static bool UpdateProductById(int id, Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "UPDATE Producto SET Descripciones = @descripciones, Costo = @costo, PrecioVenta = @precioVenta, Stock = @stock, IdUsuario = @idUsuario WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@descripciones", producto.Descripcion);
                command.Parameters.AddWithValue("@costo", producto.Costo);
                command.Parameters.AddWithValue("@precioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("@stock", producto.Stock);
                command.Parameters.AddWithValue("@idUsuario", producto.idUsuario);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            throw new Exception("Could not update product");
        }
    }
}
