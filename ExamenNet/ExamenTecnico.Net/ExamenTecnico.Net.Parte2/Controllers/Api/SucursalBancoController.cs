using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenTecnico.Net.Parte2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamenTecnico.Net.Parte2.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalBancoController : ControllerBase
    {
        private readonly ISucursalRepository SucursalRepository;

        public SucursalBancoController(ISucursalRepository sucursalRepository)
        {
            this.SucursalRepository = sucursalRepository;
        }

        [HttpGet]
        [Route("GetAllBanco/{IdBanco}")]
        [Produces("application/xml")]
        public IActionResult GetAllBanco(int IdBanco)
        {
            var lista = SucursalRepository.GetAll().Where(x => x.IdBanco.Equals(IdBanco));

            return Ok(lista);
        }
    }
}