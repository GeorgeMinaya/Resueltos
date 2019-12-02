using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenTecnico.Net.Parte1
{
    public class ChangeString
    {
        public static string Build(string cadena)
        {
            var caracteres = cadena.ToCharArray();

            var resultado = string.Empty;

            foreach (var r in caracteres)
            {
                if (char.IsLetter(r))
                {
                    var nuevo = r + 1;

                    resultado += char.ConvertFromUtf32(nuevo);
                }
                else
                    resultado += r;
            }

            return resultado;
        }
    }
}
