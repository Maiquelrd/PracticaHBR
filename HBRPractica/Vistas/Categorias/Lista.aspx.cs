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

namespace HBRPractica.Vistas.Categorias
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Implementación con la clase ServiciosCategorias
            HBRPractica.Services.SericiosCategorias servicios = new HBRPractica.Services.SericiosCategorias();

            //Conexión con la base de datos
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("CRUDCategoria"))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tipo", "Select");
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        StringBuilder html = servicios.obtenerTablaAdministrador(dt);

                        PlaceHolderCategoria.Controls.Add(new Literal { Text = html.ToString() });
                    }
                }
            }


        }

        protected void BtnCrear(object sender, EventArgs e)
        {


            Response.Redirect("~/Vistas/Categorias/Crear.aspx");
        }



        protected void BtnBorrar(object sender, EventArgs e)
        {
            //Conexión a la base de datos.
            SqlConnection conexión = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);
            conexión.Open();

            //Implementación con la clase ServiciosVarios
            HBRPractica.Services.ServiciosVarios servicios = new HBRPractica.Services.ServiciosVarios();


            servicios.borrarElemento(Convert.ToInt32(elementoID.Value), conexión, "CRUDCategoria");

            conexión.Close();

            Response.Redirect("~/Vistas/Categorias/Lista.aspx");
        }

        protected void BtnEditar(object sender, EventArgs e)
        {
            string[] datos = elementoID.Value.Split('♥');

            Session["id"] = datos[0];
            Session["nombre"] = datos[1];
            Session["descripcion"] = datos[2];


            Response.Redirect("~/Vistas/Categorias/Editar.aspx");
        }
    }
}