using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenTecnico.Net.Parte2.BE
{
    public class SucursalBE
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdBanco { get; set; }
        public string NombreBanco { get; set; }

    }
}
