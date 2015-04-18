using NorthWind.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAO
{
    public class TbClienteDAO
    {
        public static List<TbClienteBE> SelectAll()
        {
            string ConnectionString =
            ConfigurationManager.ConnectionStrings["Northwind"].ToString();
            string sql = "Select CodCliente, Nombre, Ruc from TbCliente";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;
                    List<TbClienteBE> Clientes = new List<TbClienteBE>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TbClienteBE objCliente = new TbClienteBE(
                                Convert.ToString(reader.GetSqlDecimal(0)),
                                reader.GetString(1),
                                reader.GetString(2));
                            Clientes.Add(objCliente);
                        }
                    }
                    return Clientes;
                }
            }
        }        
    }
}
