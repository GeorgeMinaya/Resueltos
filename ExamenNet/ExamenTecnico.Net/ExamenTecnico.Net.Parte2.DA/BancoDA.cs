using ExamenTecnico.Net.Parte2.BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTecnico.Net.Parte2.DA
{
    public class BancoDA : IGenericoDA<BancoBE>
    {
        public void Create(BancoBE entity)
        {
            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                var sql = $"Insert into Banco " +
                    $"Select '{ entity.Nombre }', '{ entity.Direccion }', '{ DateTime.Today }'";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    var i = cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(BancoBE entity)
        {
            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                var sql = $"Delete from Banco where IdBanco = { entity.Id } ";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    var i = cmd.ExecuteNonQuery();
                }
            }
        }

        public bool Exist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BancoBE> GetAll()
        {
            var bancos = new List<BancoBE>();

            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                using (var cmd = new SqlCommand("Select IdBanco, Nombre, Direccion, FechaRegistro from Banco", cn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var abc = reader.GetValue(2);

                        bancos.Add(new BancoBE
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1), 
                            Direccion = reader.GetString(2),
                            FechaRegistro = DateTime.Parse($"{ reader.GetValue(3) }")
                        });
                    }
                }
            }

            return bancos;
        }

        public BancoBE GetById(int id)
        {
            var banco = new BancoBE();

            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                using (var cmd = new SqlCommand($"Select Nombre, Direccion, FechaRegistro from Banco where IdBanco = { id }", cn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var abc = reader.GetValue(2);

                        banco = new BancoBE
                        {
                            Nombre = reader.GetString(0),
                            Direccion = reader.GetString(1),
                            FechaRegistro = DateTime.Parse($"{ reader.GetValue(2) }")
                        };
                    }
                }
            }

            return banco;
        }

        public void Update(BancoBE entity)
        {
            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                var sql = $"Update Banco " +
                    $"set Nombre = '{ entity.Nombre }', Direccion = '{ entity.Direccion }'" +
                    $"where IdBanco = { entity.Id }";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    var i = cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
