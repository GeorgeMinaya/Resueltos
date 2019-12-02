using ExamenTecnico.Net.Parte2.BE;
using ExamenTecnico.Net.Parte2.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenTecnico.Net.Parte2.Data
{
    public class SucursalRepository : ISucursalRepository
    {
        readonly SucursalDA Sucursal;
        public SucursalRepository()
        {
            Sucursal = new SucursalDA();
        }

        public void Create(SucursalBE entity)
        {
            Sucursal.Create(entity);
        }

        public void Delete(SucursalBE entity)
        {
            Sucursal.Delete(entity);
        }

        public bool Exist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SucursalBE> GetAll() => Sucursal.GetAll();

        public SucursalBE GetById(int id) => Sucursal.GetById(id);

        public void Update(SucursalBE entity)
        {
            Sucursal.Update(entity);
        }

        public IEnumerable<BancoBE> GetBancos()
        {
            var banco = new BancoDA();

            return banco.GetAll();
        }
    }
}
