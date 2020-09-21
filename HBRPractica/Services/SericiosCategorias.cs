using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace HBRPractica.Services
{
    public class SericiosCategorias
    {

        public bool crearCategoria(string nombre, string descripcion, SqlConnection conn, string procedure)
        {
            if ((nombre != "") && (descripcion != ""))
            {

                SqlCommand comando = new SqlCommand(procedure, conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Tipo", "Insert");
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Descripcion", descripcion);
                
                comando.ExecuteNonQuery();

                return true;
                
            }
            else
            {
                return false;
            }


        }

        public bool editarCategoria(string nombre, string descripcion, int id, SqlConnection conn, string procedure)
        {
            if ((nombre != "") && (descripcion != ""))
            {

                SqlCommand comando = new SqlCommand(procedure, conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Tipo", "Update");
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Descripcion", descripcion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }


        }

        public void borrarCategoria(int id, SqlConnection conn, string procedure)
        {
            SqlCommand comando = new SqlCommand(procedure, conn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Tipo", "Delete");
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();


        }
    }
}