using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaMichelNiebles.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public String Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Valor { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
    }
    public class ProductoBody
    {
    
        public String Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Valor { get; set; }
        public int IdCliente { get; set; }
    }
}
