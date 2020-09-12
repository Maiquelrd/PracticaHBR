using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBRPractica.Vistas.Usuarios
{
    public partial class Editar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                inputID.Value = Session["id"].ToString();
                inputUser.Value = Session["usuario"].ToString();
                inputPassword.Value = Session["contraseña"].ToString();
                checkAdmin.Checked = Session["admin"].ToString() == "True" ? true : false;
            }
            


        }

        protected void BtnConfirmar(object sender, EventArgs e)
        {
            //Conexión a la base de datos.
            SqlConnection conexion = new Conexion().Connection();
            conexion.Open();

            //Implementación con la clase ServiciosVarios
            HBRPractica.Services.ServiciosUsuarios servicios = new HBRPractica.Services.ServiciosUsuarios();


            bool respuesta = servicios.editarUsuario(inputUser.Value, inputPassword.Value, checkAdmin, Convert.ToInt32(inputID.Value) , conexion, "CRUDUsuario");

            conexion.Close();
            if (respuesta)
            {
                Response.Redirect("~/Vistas/Usuarios/Lista.aspx");
            }
            else
            {
                labelEstado.Text = "Ese usuario existe o hubo un error";
            }

            
        }

        protected void BtnVolver(object sender, EventArgs e)
        {

            Response.Redirect("~/Vistas/Usuarios/Lista.aspx");

        }
    }
}