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
            if (!Page.IsPostBack)
            {
                inputID.Value = Session["id"].ToString();
                inputNombre.Value = Session["nombre"].ToString();
                inputDescripcion.Value = Session["descripcion"].ToString();
            }



        }

        protected void BtnConfirmar(object sender, EventArgs e)
        {
            //Conexión a la base de datos.
            SqlConnection conexión = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);
            conexión.Open();

            //Implementación con la clase ServiciosVarios
            HBRPractica.Services.SericiosCategorias servicios = new HBRPractica.Services.SericiosCategorias();


            bool respuesta = servicios.editarCategoria(inputNombre.Value, inputDescripcion.Value, Convert.ToInt32(inputID.Value), conexión, "CRUDCategoria");

            conexión.Close();
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