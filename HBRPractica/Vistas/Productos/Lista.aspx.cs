using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBRPractica.Vistas.Productos
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["autenticacion"] != null)
            {
                if (Session["autenticacion"].ToString() == "Administrador")
                {

                    if (!Page.IsPostBack)
                    {

                        //Conexión con la base de datos
                        SqlConnection conexion = new Conexion().Connection();
                        using (conexion)
                        {
                            using (SqlCommand cmd = new SqlCommand("CRUDProducto"))
                            {
                                cmd.Connection = conexion;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@tipo", "Select");
                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {
                                    DataTable dt = new DataTable();
                                    sda.Fill(dt);

                                    GridviewProductos.DataSource = dt;
                                    GridviewProductos.DataBind();

                                }
                            }
                        }
                    }

                }
                else
                {
                    if (!Page.IsPostBack)
                    {

                        //Conexión con la base de datos
                        SqlConnection conexion = new Conexion().Connection();
                        using (conexion)
                        {
                            using (SqlCommand cmd = new SqlCommand("CRUDProducto"))
                            {
                                cmd.Connection = conexion;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@tipo", "Select");
                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {
                                    DataTable dt = new DataTable();
                                    sda.Fill(dt);

                                    GridviewProductos.DataSource = dt;
                                    GridviewProductos.DataBind();

                                }
                            }
                        }


                        GridviewProductos.Columns[5].Visible = false;
                        GridviewProductos.Columns[6].Visible = false;

                    }
                }

            }
            else
            {
                Response.Redirect("~/Vistas/Login/Login.aspx");
            }


        }

        protected void BtnCrear(object sender, EventArgs e)
        {


            Response.Redirect("~/Vistas/Productos/Crear.aspx");
        }


        protected void GridviewUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnEditar")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                GridViewRow row = GridviewProductos.Rows[index];
                string[] datosProducto = new string[] { row.Cells[0].Text, row.Cells[1].Text, row.Cells[2].Text, row.Cells[3].Text, row.Cells[4].Text };

                Session["editarProducto"] = datosProducto;


                Response.Redirect("~/Vistas/Productos/Editar.aspx");
            }
            else if (e.CommandName == "btnBorrar")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                GridViewRow row = GridviewProductos.Rows[index];

                //Conexión a la base de datos.
                SqlConnection conexion = new Conexion().Connection();
                conexion.Open();

                //Implementación con la clase ServiciosProductos
                Services.ServiciosProductos servicios = new Services.ServiciosProductos();
                servicios.borrarProducto(Convert.ToInt32(row.Cells[0].Text), conexion, "CRUDProducto");

                conexion.Close();

                Response.Redirect("~/Vistas/Productos/Lista.aspx");

            }
        }
    }
}