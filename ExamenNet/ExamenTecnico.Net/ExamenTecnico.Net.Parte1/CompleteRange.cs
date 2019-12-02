using System.Collections.Generic;
using System.Linq;

namespace ExamenTecnico.Net.Parte1
{
    public class CompleteRange
    {
        public static string Build(string cadena)
        {
            if (cadena.Contains(","))
            {
                var numeros = new List<int>(cadena.Split(",").Select(x => int.Parse(x.Trim())));

                var maximo = numeros.Max();

                var lista = Enumerable.Range(1, maximo);

                return string.Join(',', lista);
            }
            else
                return "No ha ingresado ningúna coma [,]";
            
        }
    }
}
