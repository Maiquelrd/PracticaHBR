using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBRPractica.Vistas.Login
{
    public partial class Crear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["autenticacion"] != null)
            {
                if (Session["autenticacion"].ToString() == "Administrador")
                {

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

        protected void BtnCrear(object sender, EventArgs e)
        {
            //Conexión a la base de datos.
            SqlConnection conexion = new Conexion().Connection();
            conexion.Open();

            //Implementación con la clase ServiciosUsuarios
            Services.ServiciosUsuarios servicios = new Services.ServiciosUsuarios();


            bool respuesta = servicios.crearUsuario(inputUser.Value, inputPassword.Value, checkAdmin, conexion, "CRUDUsuario");

            conexion.Close();

            if(respuesta)
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