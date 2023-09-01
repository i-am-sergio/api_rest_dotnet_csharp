using Microsoft.AspNetCore.Http.Features;
using MySql.Data.MySqlClient;
using rest_dotnet_csharp.connections;
using rest_dotnet_csharp.models;

namespace rest_dotnet_csharp.data
{
    class ProductData
    {
        ConnectionDB connectionDB = new ConnectionDB();
        public async Task<List<ProductModel>> MostrarProductos()
        {
            var lista = new List<ProductModel>();
            using (MySqlConnection connection = new MySqlConnection(connectionDB.getConnectionString()))
            {
                try
                {
                    await connection.OpenAsync();
                    Console.WriteLine("Conexión exitosa a la base de datos.");
                    var cmd = new MySqlCommand("SELECT * FROM productos",connection);
                    var result = await cmd.ExecuteReaderAsync();
                    
                    while(await result.ReadAsync()){
                        var item = new ProductModel();
                        item.id = (int) result["id"];
                        item.descripcion = (string) result["descripcion"];
                        item.precio = (decimal) result["precio"];
                        lista.Add(item);
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                }
            }
            return lista;
        }
    }
}