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
        public StringBuilder obtenerTablaAdministrador(DataTable dt)
        {
            StringBuilder html = new StringBuilder();

            //Inicio de la tabla
            html.Append("<table id='example' class='table table-striped table-bordered' style='width:100%' runat='server'>\n");

            //Creando el header de la tabla
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


            //Poniendo los datos en Rows.
            foreach (DataRow row in dt.Rows)
            {
                html.Append("<tr>\n");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<td>" + row[column.ColumnName] + "</td>\n");
                }
                ///Botones editar y borrar
                html.Append("<td><button type='button' class='btn btn-warning' id='" + row[0] + "♥" + row[1] + "♥" + row[2] + "' onclick='Editar(this.id)' >Editar</button></td>\n");
                html.Append("<td><button type='button' class='btn btn-danger'  id='" + row[0] + "' onclick='Borrar(this.id)' >Eliminar</Button></td>\n");
                html.Append("</tr>\n");
            }

            //Finalizando la tabla
            html.Append("</tbody>\n");
            html.Append("</table>\n");
            return html;
        }

        public bool crearCategoria(string parametro1, string parametro2, SqlConnection conn, string procedure)
        {
            if ((parametro1 != "") && (parametro2 != ""))
            {

                SqlCommand comando = new SqlCommand(procedure, conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Tipo", "Insert");
                comando.Parameters.AddWithValue("@Nombre", parametro1);
                comando.Parameters.AddWithValue("@Descripcion", parametro2);
                
                comando.ExecuteNonQuery();

                return true;
                
            }
            else
            {
                return false;
            }


        }

        public bool editarCategoria(string parametro1, string parametro2, int parametro3, SqlConnection conn, string procedure)
        {
            if ((parametro1 != "") && (parametro2 != ""))
            {

                SqlCommand comando = new SqlCommand(procedure, conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Tipo", "Update");
                comando.Parameters.AddWithValue("@Nombre", parametro1);
                comando.Parameters.AddWithValue("@Descripcion", parametro2);
                comando.Parameters.AddWithValue("@id", parametro3);
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