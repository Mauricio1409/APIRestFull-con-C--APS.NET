using APIRestFull.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace APIRestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        // Simulación de una base de datos en memoria usando una lista
        private static List<Productos> productos = new List<Productos>
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
                return NotFound(new { Message = "Producto no encontrado" });
            }
            return Ok(producto);
        }

        // Endpoint para agregar un nuevo producto
        [HttpPost]
        public IActionResult AgregarProducto([FromBody] Productos producto)
        {
            if (producto == null)
            {
                return BadRequest(new { Message = "Producto no puede ser nulo" });
            }

            // Simula la asignación de un nuevo ID
            producto.ID = productos.Max(p => p.ID) + 1;
            productos.Add(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = producto.ID }, producto);
        }
        [HttpPut]
        public IActionResult ModificarNombre(int id, [FromBody]string nombre)
        {
            var indice = productos.FindIndex(p => p.ID == id);
            if(indice == -1)
            {
                return BadRequest(new { Menssage = "El Id ingresado no corresponde a ningun producto" });

            }
            productos[indice].Nombre = nombre;
            return Ok();

            
        }
        [HttpDelete]
        public IActionResult EliminarProducto(int id)
        {
            var producto = productos.FirstOrDefault(p => p.ID == id);
            if (producto == null)
            {
                return BadRequest(new { Menssage = "No se encontro el producto a eliminar" });
            }
            productos.Remove(producto);
            return NoContent();
        }

    }
}
