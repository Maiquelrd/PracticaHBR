using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HBRPractica.Services
{
    public class ServiciosLogin
    {
        public dynamic getUsuario<T>(string usuario, string password, SqlConnection conn, string procedure)
        {
            SqlCommand comando = new SqlCommand(procedure, conn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", usuario);
            comando.Parameters.AddWithValue("@password", password);


            if (typeof(T) == typeof(int))
            {
                int resultado = (Int32)comando.ExecuteScalar();
                return resultado;
            }
            else
            {
                return (bool)comando.ExecuteScalar();
            }
        }
    }
}