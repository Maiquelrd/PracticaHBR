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

            if(!Page.IsPostBack)
            {

                if (Session["autenticacion"] != null)
                {
                    if (Session["autenticacion"].ToString() == "Administrador")
                    {
                        //Implementación con la clase ServiciosCategorias
                        HBRPractica.Services.SericiosCategorias servicios = new HBRPractica.Services.SericiosCategorias();

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

                                    StringBuilder html = servicios.obtenerTablaAdministrador(dt);

                                    PlaceHolderCategoria.Controls.Add(new Literal { Text = html.ToString() });
                                }
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Vistas/Productos/ListaUser.aspx");
                    }

                }
                else
                {
                    Response.Redirect("~/Vistas/Login/Login.aspx");
                }



            }
        }

        protected void BtnCrear(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/Categorias/Crear.aspx");
        }



        protected void BtnBorrar(object sender, EventArgs e)
        {
            //Conexión con la base de datos
            SqlConnection conexion = new Conexion().Connection();
            conexion.Open();

            //Implementación con la clase ServiciosCategorías
            HBRPractica.Services.SericiosCategorias servicios = new HBRPractica.Services.SericiosCategorias();
            servicios.borrarCategoria(Convert.ToInt32(elementoID.Value), conexion, "CRUDCategoria");


            conexion.Close();

            Response.Redirect("~/Vistas/Categorias/Lista.aspx");
        }

        protected void BtnEditar(object sender, EventArgs e)
        {
            string[] datos = elementoID.Value.Split('♥');

            ViewState["id"] = datos[0];
            ViewState["nombre"] = datos[1];
            ViewState["descripcion"] = datos[2];


            Response.Redirect("~/Vistas/Categorias/Editar.aspx");
        }
    }
}