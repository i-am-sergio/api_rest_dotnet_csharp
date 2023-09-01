using Microsoft.AspNetCore.Mvc;
using rest_dotnet_csharp.data;
using rest_dotnet_csharp.models;


namespace rest_dotnet_csharp.controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductController
    {
        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> Get()
        {
            var productData = new ProductData();
            var lista = await productData.MostrarProductos();
            return lista;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductModel newProduct)
        {
            var productData = new ProductData();
            await productData.InsertarProducto(newProduct);
            return new CreatedAtActionResult("Get", "Product", null, null); // Devuelve 201 Created
        }

    }
}