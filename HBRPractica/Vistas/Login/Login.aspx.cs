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

        }

        protected void BtnLoguear(object sender, EventArgs e)
        {
            //Conexión a la base de datos.
            SqlConnection conexión = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);
            conexión.Open();

            //Implementación con la clase ServiciosVarios
            HBRPractica.Services.ServiciosVarios servicios = new HBRPractica.Services.ServiciosVarios();


            int resultado = servicios.getResultado<int>(login.Text, password.Text, conexión, "ProcLoguear");


            if(resultado >= 1)
            {
                bool resultado2 = servicios.getResultado<bool>(login.Text, password.Text, conexión, "ValidarAdmin");
                if (resultado2 == true)
                {
                    Response.Redirect("~/Vistas/Productos/Lista.aspx");
                }
                else
                {
                    Response.Redirect("~/Vistas/Productos/ListaUser.aspx");
                }
            }
            else
            {
                StringBuilder html = new StringBuilder();
                html.Append("<div class='alert alert-danger' role='alert'> El usuario o contraseña son incorrectas o hubo un problema</div>");
                Alerta.Controls.Add(new Literal { Text = html.ToString() });
            }
            conexión.Close();
        }

        protected void BtnRegistro(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/Login/Register.aspx");
        }
    }
}