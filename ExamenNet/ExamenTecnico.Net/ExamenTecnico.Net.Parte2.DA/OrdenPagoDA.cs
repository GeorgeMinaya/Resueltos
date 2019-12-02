using ExamenTecnico.Net.Parte2.BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTecnico.Net.Parte2.DA
{
    public class OrdenPagoDA : IGenericoDA<OrdenPagoBE>
    {
        public void Create(OrdenPagoBE entity)
        {
            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                var sql = $"Insert into OrdenPago " +
                    $"Select '{ entity.Monto }', '{ entity.Moneda }', { entity.Estado }, '{ DateTime.Today }', { entity.IdSucursal }";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    var i = cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(OrdenPagoBE entity)
        {
            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                var sql = $"Delete from OrdenPago where IdOrdenPago = { entity.Id } ";

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

        public IEnumerable<OrdenPagoBE> GetAll()
        {
            var ordenes = new List<OrdenPagoBE>();

            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                var sql = $"Select a.IdOrdenPago, b.Nombre, a.FechaRegistro, a.Estado, a.Moneda, a.Monto " +
                        $"from OrdenPago a " +
                        $"inner join Sucursal b on a.IdSucursal = b.IdSucursal ";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var abc = reader.GetValue(2);

                        ordenes.Add(new OrdenPagoBE
                        {
                            Id = reader.GetInt32(0),
                            NombreSucursal = reader.GetString(1),
                            FechaRegistro = DateTime.Parse($"{ reader.GetValue(2) }"),
                            Estado = reader.GetInt32(3),
                            Moneda = reader.GetBoolean(4),
                            Monto = reader.GetDecimal(5)
                        });
                    }
                }
            }

            return ordenes;
        }

        public OrdenPagoBE GetById(int id)
        {
            var orden = new OrdenPagoBE();

            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                var sql = $"Select a.IdOrdenPago, b.Nombre, a.FechaRegistro, a.Estado, a.Moneda, a.Monto " +
                       $"from OrdenPago a " +
                       $"inner join Sucursal b on a.IdSucursal = b.IdSucursal " +
                       $"where IdOrdenPago = { id }";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var abc = reader.GetValue(2);

                        orden = new OrdenPagoBE
                        {
                            Id = reader.GetInt32(0),
                            NombreSucursal = reader.GetString(1),
                            FechaRegistro = DateTime.Parse($"{ reader.GetValue(2) }"),
                            Estado = reader.GetInt32(3),
                            Moneda = reader.GetBoolean(4),
                            Monto = reader.GetDecimal(5)
                        };
                    }
                }
            }

            return orden;
        }

        public void Update(OrdenPagoBE entity)
        {
            using (var cn = new SqlConnection(ConexionSQL.DB_Bancos()))
            {
                cn.Open();

                var sql = $"Update OrdenPago " +
                    $"set Estado = '{ entity.Estado }'" +
                    $"where IdOrdenPago = { entity.Id }";

                using (var cmd = new SqlCommand(sql, cn))
                {
                    var i = cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
