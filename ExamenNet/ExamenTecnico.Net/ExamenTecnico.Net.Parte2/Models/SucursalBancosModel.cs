using ExamenTecnico.Net.Parte2.BE;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenTecnico.Net.Parte2.Models
{
    public class SucursalBancosModel : SucursalBE
    {
        public List<SelectListItem> Bancos { get; set; }
    }
}
