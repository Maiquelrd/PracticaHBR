using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBRPractica.Vistas.Categorias
{
    public partial class Editar : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["autenticacion"] != null)
            {
                if (Session["autenticacion"].ToString() == "Administrador")
                {
                    if (!Page.IsPostBack)
                    {
                        inputID.Value = ViewState["id"].ToString();
                        inputNombre.Value = ViewState["nombre"].ToString();
                        inputDescripcion.Value = ViewState["descripcion"].ToString();
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

        protected void BtnConfirmar(object sender, EventArgs e)
        {
            //Conexión a la base de datos.
            SqlConnection conexion = new Conexion().Connection();
            conexion.Open();

            //Implementación con la clase ServiciosVarios
            HBRPractica.Services.SericiosCategorias servicios = new HBRPractica.Services.SericiosCategorias();


            bool respuesta = servicios.editarCategoria(inputNombre.Value, inputDescripcion.Value, Convert.ToInt32(inputID.Value), conexion, "CRUDCategoria");

            conexion.Close();
            if (respuesta)
            {
                Response.Redirect("~/Vistas/Categorias/Lista.aspx");
            }
            else
            {
                labelEstado.Text = "Ese usuario existe o hubo un error";
            }


        }

        protected void BtnVolver(object sender, EventArgs e)
        {

            Response.Redirect("~/Vistas/Categorias/Lista.aspx");

        }
    }
}