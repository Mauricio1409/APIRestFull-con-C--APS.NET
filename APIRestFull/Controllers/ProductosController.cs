using APIRestFull.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APIRestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        // Simulación de una base de datos en memoria
        Productos[] productos = new Productos[]
        {
            new Productos { ID = 1, Nombre = "Cocacola", Categoria = "Bebida", Precio = 1000 },
            new Productos { ID = 2, Nombre = "Galletas de agua", Categoria = "Galletas", Precio = 1000 },
            new Productos { ID = 3, Nombre = "Caramelo", Categoria = "Golosina", Precio = 1000 }
        };

        // Endpoint para obtener todos los productos
        [HttpGet]
        public IEnumerable<Productos> GetTodosLosProductos()
        {
            return productos;
        }

        // Endpoint para obtener un producto por ID
        [HttpGet("{id}")]
        public IActionResult GetProducto(int id)
        {
            var producto = productos.FirstOrDefault(p => p.ID == id);
            if (producto == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(producto);
            }
        }
    }
}
