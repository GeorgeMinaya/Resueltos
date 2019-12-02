using ExamenTecnico.Net.Parte2.BE;
using ExamenTecnico.Net.Parte2.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenTecnico.Net.Parte2.Data
{
    public class BancoRepository : IBancoRepository
    {
        readonly BancoDA Banco;
        public BancoRepository()
        {
            Banco = new BancoDA();
        }

        public void Create(BancoBE entity)
        {
            Banco.Create(entity);
        }

        public void Delete(BancoBE entity)
        {
            Banco.Delete(entity);
        }

        public bool Exist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BancoBE> GetAll() => Banco.GetAll();

        public BancoBE GetById(int id) => Banco.GetById(id);

        public void Update(BancoBE entity)
        {
            Banco.Update(entity);
        }
    }
}
