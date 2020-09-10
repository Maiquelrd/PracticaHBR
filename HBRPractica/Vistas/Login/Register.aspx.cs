using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBRPractica.Vistas.Login
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void BtnCrear(object sender, EventArgs e)
        {
            if(password.Text == repPassword.Text)
            {
                //Conexión a la base de datos.
                SqlConnection conexión = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);
                conexión.Open();

                //Implementación con la clase ServiciosVarios
                HBRPractica.Services.ServiciosUsuarios servicios = new HBRPractica.Services.ServiciosUsuarios();
                System.Web.UI.HtmlControls.HtmlInputCheckBox checkAdmin = new System.Web.UI.HtmlControls.HtmlInputCheckBox();


                bool respuesta = servicios.crearUsuario(login.Text, password.Text, checkAdmin, conexión, "CRUDUsuario");

                conexión.Close();

                if (respuesta)
                {
                    Response.Redirect("~/Vistas/Login/Login.aspx");
                }
                else
                {
                    StringBuilder html = new StringBuilder();
                    html.Append("<div class='alert alert-danger' role='alert'> Este usuario ya existe o hubo un problema</div>");
                    Alerta.Controls.Add(new Literal { Text = html.ToString() });
                }
            }
            else
            {
                StringBuilder html = new StringBuilder();
                html.Append("<div class='alert alert-danger' role='alert'> Las contraseñas no coinciden</div>");
                Alerta.Controls.Add(new Literal { Text = html.ToString() });
            }
            
        }

        protected void BtnVolver(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/Login/Login.aspx");
        }





    }
}