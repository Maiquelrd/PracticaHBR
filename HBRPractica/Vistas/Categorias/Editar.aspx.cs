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
                        string[] datosCategorias = Session["editarCategoria"] as string[];

                        inputID.Value = datosCategorias[0].ToString();
                        inputNombre.Value = datosCategorias[1].ToString();
                        inputDescripcion.Value = datosCategorias[2].ToString();
      
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

        protected void BtnConfirmar(object sender, EventArgs e)
        {
            try
            {
                //Conexión a la base de datos.
                SqlConnection conexion = new Conexion().Connection();
                conexion.Open();

                //Implementación con la clase SericiosCategorias
                Services.SericiosCategorias servicios = new Services.SericiosCategorias();


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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
           
        }

        protected void BtnVolver(object sender, EventArgs e)
        {

            Response.Redirect("~/Vistas/Categorias/Lista.aspx");

        }
    }
}