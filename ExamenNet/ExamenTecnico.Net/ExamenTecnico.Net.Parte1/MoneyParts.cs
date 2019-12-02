using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamenTecnico.Net.Parte1
{
    public class MoneyParts
    {
        readonly static decimal[] denominaciones = new decimal[] { 0.05M, 0.1M, 0.2M, 0.5M, 1, 2, 5, 10, 20, 50, 100, 200 };

        public static string Build(string cadena)
        {
            var monto = decimal.Parse(cadena);

            var resultado = new List<List<decimal>>();

            foreach (var moneda in denominaciones.Where(x => x <= monto))
            {
                var iguales = new List<decimal>();

                if (monto % moneda == 0)
                {
                    var ciclo = monto / moneda;

                    for (int i = 0; i < ciclo; i++)
                    {
                        iguales.Add(moneda);
                    }
                }
                else
                {
                    var ciclo = (int)(monto / moneda);

                    for (int i = 0; i < ciclo; i++)
                    {
                        iguales.Add(moneda);
                    }

                    var faltante = monto - iguales.Sum();

                    if (denominaciones.Contains(faltante))
                        iguales.Add(faltante);
                    else
                    {
                        var unaMenos = denominaciones.LastOrDefault(x => x < moneda);

                        do
                        {
                            ciclo = (int)(faltante / unaMenos);

                            for (int i = 0; i < ciclo; i++)
                            {
                                iguales.Add(unaMenos);
                            }

                            faltante = monto - iguales.Sum();

                            unaMenos = denominaciones.LastOrDefault(x => x < unaMenos);

                        } while (faltante != 0);
                    }
                }

                if (iguales.Count > 0)
                    resultado.Add(iguales);
            }

            return Imprimir(resultado);
        }

        static string Imprimir(IEnumerable<IEnumerable<decimal>> combinaciones)
        {
            var resultado = string.Empty;

            var lista = new List<string>(from r in combinaciones
                                         select $"[{string.Join(",", r)}]{Environment.NewLine}");

            return string.Join(",", lista);
        }
    }
}
