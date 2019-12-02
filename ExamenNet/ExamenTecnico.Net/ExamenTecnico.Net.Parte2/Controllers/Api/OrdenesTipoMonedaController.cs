using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenTecnico.Net.Parte2.Data;
using ExamenTecnico.Net.Parte2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenTecnico.Net.Parte2.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesTipoMonedaController : ControllerBase
    {
        private readonly IOrdenPagoRepository OrdenPagoRepository;

        public OrdenesTipoMonedaController(IOrdenPagoRepository ordenPagoRepository)
        {
            this.OrdenPagoRepository = ordenPagoRepository;
        }

        [HttpGet]
        [Route("GetAllTipoMoneda/{tipoMoneda}")]
        public IActionResult GetAllTipoMoneda(string tipoMoneda)
        {
            // Soles = 0 = false
            // Dolares = 1 = true

            var tipo = nameof(OrdenPagoSucursalModel.TiposPago.Soles).ToUpperInvariant().Equals(tipoMoneda.ToUpperInvariant());

            var lista = OrdenPagoRepository.GetAll().Where(x => x.Moneda.Equals(!tipo));
            
            return Ok(lista);
        }        
    }
}