using ProyectoFinalFaseDos.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalFaseDos.ADO
{
    public static class AdoProductoVendido
    {
        private static string _stringConnection;


        static AdoProductoVendido()
        {
            _stringConnection = @"Server=AV35351\MSSQLSERVER2022; Database=coderhouse; Trusted_Connection=True;";
        }

        public static ProductoVendido GetProductSoldById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "SELECT * FROM ProductoVendido WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int getedId = Convert.ToInt32(reader["id"]);
                    int getedStock = reader.GetInt32(2);
                    int getedProductId = reader.GetInt32(3);
                    int getedSellId = reader.GetInt32(4);

                    ProductoVendido productoVendido = new ProductoVendido(id, getedStock, getedProductId, getedSellId);

                    return productoVendido;
                }
                throw new Exception("Not found id");

            }

        }

        public static List<ProductoVendido> ListProductsSold()
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "SELECT * FROM ProductoVendido";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    int stock = reader.GetInt32(1);
                    int idProducto = reader.GetInt32(2);
                    int idVenta = reader.GetInt32(3);

                    ProductoVendido productoVendido = new ProductoVendido(id, stock, idProducto, idVenta);
                    productosVendidos.Add(productoVendido);
                }
            }

            return productosVendidos;
        }

        public static bool AddProductSold(ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta) VALUES (@stock,@idProducto,@idVenta)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@stock", productoVendido.Stock);
                command.Parameters.AddWithValue("@idProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("@idVenta", productoVendido.IdVenta);


                connection.Open();
                return command.ExecuteNonQuery() > 0;

            }
            throw new Exception("Could not add productSold");
        }

        public static int DeleteProductSold(int id)
        {
            if (id != -1)
            {
                using (SqlConnection connection = new SqlConnection(_stringConnection))
                {

                    string query = "DELETE FROM ProductoVendido WHERE id = @id";


                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();

                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new Exception("No product sold found with the provided ID.");
                    }
                    return id;
                }
            }
            else
            {
                throw new Exception("Could not delete product sold");
            }
        }

        public static bool UpdateProductSoldById(int id, ProductoVendido productoVendido)
        {
            using (SqlConnection connection = new SqlConnection(_stringConnection))
            {
                string query = "UPDATE ProductoVendido SET Stock = @stock, IdProducto = @idProduct, IdVenta = @idventa WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@stock", productoVendido.Stock);
                command.Parameters.AddWithValue("@idProduct", productoVendido.IdProducto);
                command.Parameters.AddWithValue("@idventa", productoVendido.IdVenta);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
            throw new Exception("Could not update product Sold");
        }

    }

 

}
