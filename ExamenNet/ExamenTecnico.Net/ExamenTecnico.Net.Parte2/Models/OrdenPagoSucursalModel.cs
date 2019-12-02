using ExamenTecnico.Net.Parte2.BE;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenTecnico.Net.Parte2.Models
{
    public class OrdenPagoSucursalModel : OrdenPagoBE
    {
        public List<SelectListItem> Sucursales { get; set; }

        public TiposPago TipoPago { get; set; }

        public EstadosOrden Estados { get; set; }

        public enum EstadosOrden
        {
            Pagado,
            Declinado,
            Fallido,
            Anulado
        }

        public enum TiposPago
        {
            Soles,
            Dolares
        }
    }
}
