using lottery.Domain.Repository;
using lottery.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace lottery.Persistence
{
    public class ProductReposityImpl : IProductReposity
    {

 

        public void saveProduct(Product product)
        {
            // Establecer la cadena de conexión
            string connectionString = "Server=(local); Database=lottery; Integrated Security=true; Encrypt=false;";

            // Establecer la conexión a la base de datos utilizando la cadena de conexión
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Definir la consulta SQL para insertar el producto en la tabla Products
                    string sql = "INSERT INTO Product (Name, Price) VALUES (@Name, @Price)";

                    // Crear un objeto SqlCommand para ejecutar la consulta SQL
                    using (var command = new SqlCommand(sql, connection))
                    {
                        // Agregar parámetros a la consulta SQL para el nombre y el precio del producto
                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Price", product.Price);

                        // Ejecutar la consulta SQL
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("Producto guardado correctamente en la base de datos.");
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante la operación de guardado
                    Console.WriteLine($"Error al guardar el producto en la base de datos: {ex.Message}");
                }
            }
        }
    }
}
