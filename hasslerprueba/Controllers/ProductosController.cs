using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaMichelNiebles.DB_Context;
using PruebaMichelNiebles.Models;

namespace PruebaMichelNiebles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            var producto = await _context.Productos.
                    Include($"{nameof(Cliente)}").ToListAsync();
            return Ok(producto);
        }

        // GET: api/Productos/5
        [HttpGet("{IdProducto}")]
        public async Task<ActionResult<Producto>> GetProducto(int IdProducto)
        {


            try
            {
                if (IdProducto == 0)
                {
                    return Ok(new { message = "Ingrese Un Id De Producto Valido" });
                }
                var factura = await _context.Productos.
                  Include($"{nameof(Cliente)}")
                  .FirstOrDefaultAsync(x => x.IdProducto == IdProducto);
                if (factura == null)
                {
                    return Ok(new { message = "No Hay Registro Con Este Id" });
                }
                else
                {

                    return factura;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Productos/5
        [HttpPut("{IdProducto}")]
        public async Task<IActionResult> PutProducto(int IdProducto, ProductoBody ProductoBody)
        {
            try
            {
                try
                {


                    
                    if (ProductoBody.IdCliente <= 0)
                    {
                        return Ok(new { message = "El Id Del Cliente No Es Valido" });
                    }
                    else
                    {
                       Producto producto = new Producto();
                        producto.IdProducto = IdProducto;
                        producto.IdCliente = ProductoBody.IdCliente;
                        producto.Nombre = ProductoBody.Nombre;
                        producto.Cantidad = ProductoBody.Cantidad;

                        _context.Update(producto);
                        await _context.SaveChangesAsync();
                        return Ok(new { message = "El Producto Se Actulizado Con Exito" });
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(IdProducto))
                {

                    return Ok(new { message = "La Factura No Fue Actulizado" });
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(ProductoBody productoBody)
        {
            try
            {                
              
                if (productoBody.Nombre == null)
                {
                    return BadRequest(new { message = "El Nombre Del Producto No Es Valido" });
                }
                else
                {
                    Producto producto = new Producto();
                    producto.Nombre = productoBody.Nombre;
                    producto.Cantidad = productoBody.Cantidad;
                    producto.Valor = productoBody.Valor;
                    producto.IdCliente = productoBody.IdCliente;
                    _context.Productos.Add(producto);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "El Producto Fue Registrado Con Exito" });

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.IdProducto == id);
        }
    }
}
