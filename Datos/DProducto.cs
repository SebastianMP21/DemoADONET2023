using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;


namespace Datos
{
    public class DProducto
    {
        private string connectionString = "Data Source=LAB707-14\\SQLEXPRESS02;Initial Catalog=producto;Integrated Security=True;";

        public List<Producto> Listar()
        {
            //Realizamos la conexión
            SqlConnection connection = null;
            SqlParameter param = null;
            SqlCommand command = null;
            List<Producto> productos = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                productos = new List<Producto>();

                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.id = (int)reader["´id"];
                    producto.nombre = reader["nombre"].ToString();
                    producto.precio = (float)reader["precio"];
                    productos.Add(producto);
                }
                connection.Close();
                //Muestro la información
                return productos;

            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            finally
            { 
                connection = null;
                command = null;
                param = null;
                Region region = null;
            }

        }

        public void Insertar(Producto producto)
        {
            try {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertarProductos3", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id", producto.id);
                    command.Parameters.AddWithValue("@producto", producto.nombre);
                    command.Parameters.AddWithValue("@Code", producto.precio);
                    command.Parameters.AddWithValue("@Code", producto.nombre);

                }
            }
        }
    }
}
