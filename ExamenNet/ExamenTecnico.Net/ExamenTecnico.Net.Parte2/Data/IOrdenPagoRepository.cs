using ExamenTecnico.Net.Parte2.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenTecnico.Net.Parte2.Data
{
    public interface IOrdenPagoRepository : IGenericRepository<OrdenPagoBE>
    {
        IEnumerable<SucursalBE> GetSucursales();
    }
}
