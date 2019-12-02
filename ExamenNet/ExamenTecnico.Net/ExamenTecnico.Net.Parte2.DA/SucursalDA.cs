using ExamenTecnico.Net.Parte2.BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ExamenTecnico.Net.Parte2.DA
{
    public class SucursalDA : IGenericoDA<SucursalBE>
    {
        public void Create(SucursalBE entity)
        {
            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                var sql = $"Insert into Sucursal " +
                    $"Select '{ entity.Nombre }', '{ entity.Direccion }', '{ DateTime.Today }', {entity.IdBanco}";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    var i = cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(SucursalBE entity)
        {
            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                var sql = $"Delete from Sucursal where IdSucursal = { entity.Id } ";

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

        public IEnumerable<SucursalBE> GetAll()
        {
            var sucursales = new List<SucursalBE>();

            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                var sql = $"Select a.IdSucursal, a.Nombre, a.Direccion, a.FechaRegistro, b.IdBanco, b.Nombre " +
                            $"from Sucursal a " +
                            $"inner join Banco b on a.IdBanco = b.IdBanco";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var abc = reader.GetValue(2);

                        sucursales.Add(new SucursalBE
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Direccion = reader.GetString(2),
                            FechaRegistro = DateTime.Parse($"{ reader.GetValue(3) }"),
                            IdBanco = reader.GetInt32(4),
                            NombreBanco = reader.GetString(5)
                        });
                    }
                }
            }

            return sucursales;
        }

        public SucursalBE GetById(int id)
        {
            var sucursal = new SucursalBE();

            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                var sql = $"Select a.IdSucursal, a.Nombre, a.Direccion, a.FechaRegistro, b.IdBanco, b.Nombre " +
                            $"from Sucursal a " +
                            $"inner join Banco b on a.IdBanco = b.IdBanco " +
                            $"where IdSucursal = { id }";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var abc = reader.GetValue(2);

                        sucursal = new SucursalBE
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Direccion = reader.GetString(2),
                            FechaRegistro = DateTime.Parse($"{ reader.GetValue(3) }"),
                            IdBanco = reader.GetInt32(4),
                            NombreBanco = reader.GetString(5)
                        };
                    }
                }
            }

            return sucursal;
        }

        public void Update(SucursalBE entity)
        {
            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                var sql = $"Update Sucursal " +
                    $"set Nombre = '{ entity.Nombre }', Direccion = '{ entity.Direccion }', IdBanco = { entity.IdBanco }" +
                    $"where IdSucursal = { entity.Id }";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    var i = cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
