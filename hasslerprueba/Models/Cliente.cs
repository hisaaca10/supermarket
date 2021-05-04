using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaMichelNiebles.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public Int64 Telefono { get; set; }
        public Int64 Celular { get; set; }
    }
}
