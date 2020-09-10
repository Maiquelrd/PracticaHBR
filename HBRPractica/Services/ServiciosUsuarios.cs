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
 
        public StringBuilder obtenerTablaAdministrador(DataTable dt)
        {
            StringBuilder html = new StringBuilder();

            //Inicio de la tabla
            html.Append("<table id='example' class='table table-striped table-bordered' style='width:100%' runat='server'>\n");

            //Construyendo el header de la tabla
            html.Append("<thead>\n");
            html.Append("<tr>\n");
            foreach (DataColumn column in dt.Columns)
            {
                html.Append("<th>" + column.ColumnName + "</th>\n");
            }
            html.Append("<th> Editar </th>\n");
            html.Append("<th> Eliminar </th>\n");
            html.Append("</tr>\n");
            html.Append("</thead>\n");
            html.Append("<tbody>\n");


            //Poniendo los datos
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>\n");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>" + row[column.ColumnName] + "</td>\n");
                }
                html.Append("<td><button type='button' class='btn btn-warning' id='" + row[0] + "♥" + row[1] + "♥" + row[2] + "♥" + row[3] + "' onclick='Editar(this.id)' >Editar</button></td>\n");
                html.Append("<td><button type='button' class='btn btn-danger'  id='" + row[0] + "' onclick='Borrar(this.id)' >Eliminar</Button></td>\n");
                html.Append("</tr>\n");
            }

            //Cerrando la tabla
            html.Append("</tbody>\n");
            html.Append("</table>\n");
            return html;
        }

        public bool crearUsuario(string parametro1, string parametro2, System.Web.UI.HtmlControls.HtmlInputCheckBox parametro3, SqlConnection conn, string procedure)
        {
            if ((parametro1 != "") && (parametro2 != "") && (parametro3 != null))
            {
                SqlCommand comando = new SqlCommand("ValidarUsuario", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@usuario", parametro1);
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
                    comando.Parameters.AddWithValue("@Usuario", parametro1);
                    comando.Parameters.AddWithValue("@Contraseña", parametro2);
                    if (parametro3.Checked)
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

        public bool editarUsuario(string parametro1, string parametro2, System.Web.UI.HtmlControls.HtmlInputCheckBox parametro3, int parametro4, SqlConnection conn, string procedure)
        {
            if ((parametro1 != "") && (parametro2 != "") && (parametro3 != null))
            {

                SqlCommand comando = new SqlCommand(procedure, conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Tipo", "Update");
                comando.Parameters.AddWithValue("@Usuario", parametro1);
                comando.Parameters.AddWithValue("@Contraseña", parametro2);
                comando.Parameters.AddWithValue("@id", parametro4);
                if (parametro3.Checked)
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


    }
}