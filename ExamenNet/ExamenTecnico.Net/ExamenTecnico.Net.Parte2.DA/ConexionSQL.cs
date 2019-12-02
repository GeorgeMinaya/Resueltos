using System;

namespace ExamenTecnico.Net.Parte2.DA
{
    public class ConexionSQL
    {
         public static string DB_Bancos() => @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog="+ 
                  System.IO.Directory.GetCurrentDirectory() + @"\BD_BANCOS.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
