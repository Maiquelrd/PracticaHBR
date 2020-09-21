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

            if (Session["autenticacion"] != null)
            {
                if (Session["autenticacion"].ToString() == "Administrador")
                {
                    if (!Page.IsPostBack)
                    {
                        string[] datosUsuario = Session["editarUsuario"] as string[];

                        inputID.Value = datosUsuario[0].ToString();
                        inputUser.Value = datosUsuario[1].ToString();
                        inputPassword.Value = datosUsuario[2].ToString();
                        checkAdmin.Checked = datosUsuario[3].ToString() == "True" ? true : false;
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

                //Implementación con la clase ServiciosUsuarios
                Services.ServiciosUsuarios servicios = new Services.ServiciosUsuarios();


                bool respuesta = servicios.editarUsuario(inputUser.Value, inputPassword.Value, checkAdmin, Convert.ToInt32(inputID.Value), conexion, "CRUDUsuario");

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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
  
        }

        protected void BtnVolver(object sender, EventArgs e)
        {

            Response.Redirect("~/Vistas/Usuarios/Lista.aspx");

        }
    }
}