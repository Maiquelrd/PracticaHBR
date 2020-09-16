using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.DynamicData;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace HBRPractica.Vistas.Usuarios
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
                            using (SqlCommand cmd = new SqlCommand("CRUDUsuario"))
                            {
                                cmd.Connection = conexion;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@tipo", "Select");
                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {
                                    DataTable dt = new DataTable();
                                    sda.Fill(dt);

                                    GridviewUsuarios.DataSource = dt;
                                    GridviewUsuarios.DataBind();

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
            

            Response.Redirect("~/Vistas/Usuarios/Crear.aspx");
        }


        protected void GridviewUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnEditar")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                GridViewRow row = GridviewUsuarios.Rows[index];
                string[] datosUsuario = new string[] { row.Cells[0].Text, row.Cells[1].Text, row.Cells[2].Text, row.Cells[3].Text };

                Session["editarUsuario"] = datosUsuario;


                Response.Redirect("~/Vistas/Usuarios/Editar.aspx");
            }
            else if (e.CommandName == "btnBorrar")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                GridViewRow row = GridviewUsuarios.Rows[index];

                //Conexión a la base de datos.
                SqlConnection conexion = new Conexion().Connection();
                conexion.Open();

                //Implementación con la clase ServiciosUsuarios
                Services.ServiciosUsuarios servicios = new Services.ServiciosUsuarios();
                servicios.borrarUsuario(Convert.ToInt32(row.Cells[0].Text), conexion, "CRUDUsuario");

                conexion.Close();

                Response.Redirect("~/Vistas/Usuarios/Lista.aspx");

            }
        }
    }
}