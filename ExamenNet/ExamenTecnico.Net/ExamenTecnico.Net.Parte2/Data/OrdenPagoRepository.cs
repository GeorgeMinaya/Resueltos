using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenTecnico.Net.Parte2.BE;
using ExamenTecnico.Net.Parte2.DA;

namespace ExamenTecnico.Net.Parte2.Data
{
    public class OrdenPagoRepository : IOrdenPagoRepository
    {
        readonly OrdenPagoDA OrdenPago;
        public OrdenPagoRepository()
        {
            OrdenPago = new OrdenPagoDA();
        }
        public void Create(OrdenPagoBE entity)
        {
            OrdenPago.Create(entity);
        }

        public void Delete(OrdenPagoBE entity)
        {
            OrdenPago.Delete(entity);
        }

        public bool Exist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrdenPagoBE> GetAll()
        {
            return OrdenPago.GetAll();
        }

        public OrdenPagoBE GetById(int id)
        {
            return OrdenPago.GetById(id);
        }

        public IEnumerable<SucursalBE> GetSucursales()
        {
            var sucursal = new SucursalDA();

            return sucursal.GetAll();
        }

        public void Update(OrdenPagoBE entity)
        {
            OrdenPago.Update(entity);
        }
    }
}
