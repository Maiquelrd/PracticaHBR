using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBRPractica.Services
{
    public class ServiciosVarios
    {
        public dynamic getResultado<T>(string parametro1, string parametro2, SqlConnection conn, string procedure)
        {
            SqlCommand comando = new SqlCommand(procedure, conn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", parametro1);
            comando.Parameters.AddWithValue("@password", parametro2);


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

        public void borrarElemento(int id, SqlConnection conn, string procedure)
        {
            SqlCommand comando = new SqlCommand(procedure, conn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Tipo", "Delete");
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();


        }

    }


}