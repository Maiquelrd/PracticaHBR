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

namespace HBRPractica
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["autenticacion"] = null;

            }
            
        }

        protected void BtnLoguear(object sender, EventArgs e)
        {
            //Conexión a la base de datos.
            SqlConnection conexion = new Conexion().Connection();
            conexion.Open();

            //Implementación con la clase ServiciosLogin
            Services.ServiciosLogin servicios = new Services.ServiciosLogin();
            int resultadoUsuario = servicios.getUsuario<int>(login.Text, password.Text, conexion, "ProcLoguear");


            if(resultadoUsuario >= 1)
            {
                bool resultado2 = servicios.getUsuario<bool>(login.Text, password.Text, conexion, "ValidarAdmin");
                if (resultado2 == true)
                {
                    Session["autenticacion"] = "Administrador";
                    Response.Redirect("~/Vistas/Productos/Lista.aspx");
                }
                else
                {
                    Session["autenticacion"] = "Usuario";
                    Response.Redirect("~/Vistas/Productos/Lista.aspx");
                }
            }
            else
            {
                StringBuilder html = new StringBuilder();
                html.Append("<div class='alert alert-danger' role='alert'> El usuario o contraseña son incorrectas o hubo un problema</div>");
                Alerta.Controls.Add(new Literal { Text = html.ToString() });
            }
            conexion.Close();
        }
    }
}