using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace HBRPractica.Services
{
    public class ServiciosProductos
    {

        public StringBuilder obtenerTabla(DataTable dt)
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
                html.Append("</tr>\n");
            }

            //Cerrando la tabla
            html.Append("</tbody>\n");
            html.Append("</table>\n");
            return html;
        }


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
                html.Append("<td><button type='button' class='btn btn-warning' id='" + row[0] + "♥" + row[1] + "♥" + row[2] + "♥" + row[3] + "♥" + row[4] + "' onclick='Editar(this.id)' >Editar</button></td>\n");
                html.Append("<td><button type='button' class='btn btn-danger'  id='" + row[0] + "' onclick='Borrar(this.id)' >Eliminar</Button></td>\n");
                html.Append("</tr>\n");
            }

            //Cerrando la tabla
            html.Append("</tbody>\n");
            html.Append("</table>\n");
            return html;
        }

        public bool crearProducto(string nombre, string descripcion, int idCategoria, decimal precio, SqlConnection conn, string procedure)
        {
            if ((nombre != "") && (descripcion != ""))
            {

                SqlCommand comando = new SqlCommand(procedure, conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Tipo", "Insert");
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Descripcion", descripcion);
                comando.Parameters.AddWithValue("@idCat", idCategoria);
                comando.Parameters.AddWithValue("@Precio", precio);

                comando.ExecuteNonQuery();

                return true;

            }
            else
            {
                return false;
            }


        }

        public bool editarProducto(string nombre, string descripcion, int id, int idCategoria, decimal precio, SqlConnection conn, string procedure)
        {
            if ((nombre != "") && (descripcion != ""))
            {

                SqlCommand comando = new SqlCommand(procedure, conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Tipo", "Update");
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Descripcion", descripcion);
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@idCat", idCategoria);
                comando.Parameters.AddWithValue("@Precio", precio);
                comando.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }


        }

        public void borrarProducto(int id, SqlConnection conn, string procedure)
        {
            SqlCommand comando = new SqlCommand(procedure, conn);
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Tipo", "Delete");
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();


        }
    }
}