using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace HBRPractica.Vistas.Usuarios
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Implementación con la clase ServiciosVarios
            HBRPractica.Services.ServiciosUsuarios servicios = new HBRPractica.Services.ServiciosUsuarios();

            //Conexión con la base de datos
            SqlConnection conexion = new Conexion().Connection();
            using (conexion)
            {
                using (SqlCommand cmd = new SqlCommand("CRUDUsuario"))
                {
                    cmd.Connection = conexion;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tipo", "Select");
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        StringBuilder html = servicios.obtenerTablaAdministrador(dt);

                        PlaceHolderUsuarios.Controls.Add(new Literal { Text = html.ToString() });
                    }
                }
            }


        }

        protected void BtnCrear(object sender, EventArgs e)
        {
            

            Response.Redirect("~/Vistas/Usuarios/Crear.aspx");
        }



        protected void BtnBorrar(object sender, EventArgs e)
        {
            //Conexión a la base de datos.
            SqlConnection conexion = new Conexion().Connection();
            conexion.Open();

            //Implementación con la clase ServiciosUsuarios
            HBRPractica.Services.ServiciosUsuarios servicios = new HBRPractica.Services.ServiciosUsuarios();
            servicios.borrarUsuario(Convert.ToInt32(elementoID.Value), conexion, "CRUDUsuario");

            conexion.Close();

            Response.Redirect("~/Vistas/Usuarios/Lista.aspx");
        }

        protected void BtnEditar(object sender, EventArgs e)
        {
            string[] datos = elementoID.Value.Split('♥');

            Session["id"] = datos[0];
            Session["usuario"] = datos[1];
            Session["contraseña"] = datos[2];
            Session["admin"] = datos[3];


            Response.Redirect("~/Vistas/Usuarios/Editar.aspx");
        }


    }
}