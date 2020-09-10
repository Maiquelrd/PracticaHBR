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

namespace HBRPractica.Vistas.Productos
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Implementación con la clase ServiciosVarios
            HBRPractica.Services.ServiciosProductos servicios = new HBRPractica.Services.ServiciosProductos();

            //Conexión con la base de datos
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("CRUDProducto"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tipo", "Select");
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        StringBuilder html = servicios.obtenerTablaAdministrador(dt);

                        PlaceHolderProductos.Controls.Add(new Literal { Text = html.ToString() });
                    }
                }
            }


        }

        protected void BtnCrear(object sender, EventArgs e)
        {


            Response.Redirect("~/Vistas/Productos/Crear.aspx");
        }



        protected void BtnBorrar(object sender, EventArgs e)
        {
            //Conexión a la base de datos.
            SqlConnection conexión = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);
            conexión.Open();

            //Implementación con la clase ServiciosVarios
            HBRPractica.Services.ServiciosVarios servicios = new HBRPractica.Services.ServiciosVarios();


            servicios.borrarElemento(Convert.ToInt32(elementoID.Value), conexión, "CRUDProducto");

            conexión.Close();

            Response.Redirect("~/Vistas/Productos/Lista.aspx");
        }

        protected void BtnEditar(object sender, EventArgs e)
        {
            string[] datos = elementoID.Value.Split('♥');

            Session["id"] = datos[0];
            Session["idcat"] = datos[1];
            Session["nombre"] = datos[2];
            Session["descripcion"] = datos[3];
            Session["precio"] = datos[4];


            Response.Redirect("~/Vistas/Productos/Editar.aspx");
        }
    }
}