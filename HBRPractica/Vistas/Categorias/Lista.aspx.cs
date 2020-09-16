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

namespace HBRPractica.Vistas.Categorias
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
                            using (SqlCommand cmd = new SqlCommand("CRUDCategoria"))
                            {
                                cmd.Connection = conexion;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@tipo", "Select");
                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {
                                    DataTable dt = new DataTable();
                                    sda.Fill(dt);

                                    GridviewCategoria.DataSource = dt;
                                    GridviewCategoria.DataBind();

                                }
                            }
                        }
                    }

                }
                else
                {
                    Response.Redirect("~/Vistas/Productos/Lista.aspx");
                }

            }
            else
            {
                Response.Redirect("~/Vistas/Login/Login.aspx");
            }


        }

        protected void BtnCrear(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/Categorias/Crear.aspx");
        }


        protected void GridviewCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnEditar")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                GridViewRow row = GridviewCategoria.Rows[index];
                string[] datosCategoria = new string[] { row.Cells[0].Text, row.Cells[1].Text, row.Cells[2].Text};

                Session["editarCategoria"] = datosCategoria;


                Response.Redirect("~/Vistas/Categorias/Editar.aspx");
            }
            else if (e.CommandName == "btnBorrar")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                GridViewRow row = GridviewCategoria.Rows[index];

                //Conexión a la base de datos.
                SqlConnection conexion = new Conexion().Connection();
                conexion.Open();

                //Implementación con la clase SericiosCategorias
                Services.SericiosCategorias servicios = new Services.SericiosCategorias();
                servicios.borrarCategoria(Convert.ToInt32(row.Cells[0].Text), conexion, "CRUDCategoria");

                conexion.Close();

                Response.Redirect("~/Vistas/Categorias/Lista.aspx");

            }
        }
    }
}