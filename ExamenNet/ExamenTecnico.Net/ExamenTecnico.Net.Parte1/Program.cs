using System;

namespace ExamenTecnico.Net.Parte1
{
    class Program
    {
        static void Main(string[] args)
        {
            string entrada;

            do
            {
                Menu();

                entrada = Console.ReadLine();

                if (entrada.Equals("1"))
                {
                    Console.Clear();
                    Console.WriteLine("------------------------- Change String ----------------------------");
                    Console.WriteLine("Reemplazar cada letra de la cadena con la letra siguiente en el alfabeto");
                    Console.WriteLine("Ingrese la cadena : ");
                    Console.WriteLine($"Resultado : { ChangeString.Build(Console.ReadLine()) }");
                    Console.WriteLine("");
                }
                else if (entrada.Equals("2"))
                {
                    Console.Clear();
                    Console.WriteLine("------------------------- Complete Range ----------------------------");
                    Console.WriteLine("El algoritmo debe completar si faltan números en la colección en el rango dado.Finalmente devolver la colección completa y ordenada de manera ascendente.");
                    Console.WriteLine("Ingrese los números separados por una coma [,]: ");
                    Console.WriteLine($"Resultado : { CompleteRange.Build(Console.ReadLine()) }");
                    Console.WriteLine("");
                }
                else if (entrada.Equals("3"))
                {
                    Console.Clear();
                    Console.WriteLine("------------------------- MoneyParts ----------------------------");
                    Console.WriteLine("Que reciba como parámetro una cadena con un monto en soles y devuelva todas las combinaciones posibles en un arreglo.");
                    Console.WriteLine("Ingrese el monto : ");
                    Console.WriteLine($"Resultado : { MoneyParts.Build(Console.ReadLine()) }");
                    Console.WriteLine("");
                }
                else
                    Console.Clear();

            } while (!entrada.Equals("4"));
        }

        static void Menu()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("----------------------- Examen Técnico ------------------------");
            Console.WriteLine("------------------------- Parte 01 ----------------------------");
            Console.WriteLine("ChangeString .............[1]");
            Console.WriteLine("CompleteRange ............[2]");
            Console.WriteLine("MoneyParts ...............[3]");
            Console.WriteLine("Salir ....................[4]");
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Escoga el número del ejercicio : ");
        }
    }
}
