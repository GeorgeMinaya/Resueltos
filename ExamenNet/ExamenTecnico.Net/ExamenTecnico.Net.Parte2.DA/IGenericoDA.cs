using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamenTecnico.Net.Parte2.DA
{
    public interface IGenericoDA<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Create(T entity);
        
        void Update(T entity);
        
        void Delete(T entity);

        bool Exist(int id);

    }
}