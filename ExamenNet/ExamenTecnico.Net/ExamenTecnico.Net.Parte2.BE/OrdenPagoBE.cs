using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenTecnico.Net.Parte2.BE
{
    public class OrdenPagoBE
    {
        public int Id { get; set; }
        public decimal Monto { get; set; }
        public bool Moneda { get; set; }
        public int Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdSucursal { get; set; }
        public string NombreSucursal { get; set; }
    }
}
