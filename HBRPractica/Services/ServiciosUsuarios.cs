using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace HBRPractica.Services
{
    public class ServiciosUsuarios
    {
 
        public bool crearUsuario(string usuario, string password, System.Web.UI.HtmlControls.HtmlInputCheckBox esAdmin, SqlConnection conn, string procedure)
        {
            if ((usuario != "") && (password != ""))
            {
                SqlCommand comando = new SqlCommand("ValidarUsuario", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@usuario", usuario);
                int resultado = (Int32)comando.ExecuteScalar();
                if (resultado > 0)
                {
                    return false;
                }
                else
                {
                    comando = new SqlCommand(procedure, conn);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Tipo", "Insert");
                    comando.Parameters.AddWithValue("@Usuario", usuario);
                    comando.Parameters.AddWithValue("@Contraseña", password);
                    if (esAdmin.Checked)
                    {
                        comando.Parameters.AddWithValue("@Admin", 1);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@Admin", 0);
                    }
                    comando.ExecuteNonQuery();
                    return true;
                }
            }
            else
            {
                return false;
            }


        }

        public bool editarUsuario(string usuario, string password, System.Web.UI.HtmlControls.HtmlInputCheckBox esAdmin, int id, SqlConnection conn, string procedure)
        {
            if ((usuario != "") && (password != ""))
            {

                SqlCommand comando = new SqlCommand(procedure, conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Tipo", "Update");
                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Contraseña", password);
                comando.Parameters.AddWithValue("@id", id);
                if (esAdmin.Checked)
                {
                    comando.Parameters.AddWithValue("@Admin", 1);
                }
                else
                {
                    comando.Parameters.AddWithValue("@Admin", 0);
                }
                comando.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }


        }

        public void borrarUsuario(int id, SqlConnection conn, string procedure)
        {
            SqlCommand comando = new SqlCommand(procedure, conn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Tipo", "Delete");
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();


        }


    }
}