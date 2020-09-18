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

        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["autenticacion"] != null)
            {
                if (Session["autenticacion"].ToString() == "Administrador")
                {

                    if (!Page.IsPostBack)
                    {

                        LoadData();
                    }

                }
                else
                {
                    if (!Page.IsPostBack)
                    {

                        LoadData();
                        GridviewProductos.Columns[1].Visible = false;
                        GridviewProductos.Columns[6].Visible = false;
                        GridviewProductos.Columns[7].Visible = false;
                        BotonCrear.Visible = false;

                    }
                }

            }
            else
            {
                Response.Redirect("~/Vistas/Login/Login.aspx");
            }


        }

        private void LoadData()
        {
            //Conexión con la base de datos
            SqlConnection conexion = new Conexion().Connection();
            using (conexion)
            {
                using (SqlCommand cmd = new SqlCommand("CRUDProducto"))
                {
                    cmd.Connection = conexion;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tipo", "SelectCat");
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);

                        GridviewProductos.DataSource = dt;
                        GridviewProductos.DataBind();

                    }
                }
            }
        }

        protected void BtnCrear(object sender, EventArgs e)
        {


            Response.Redirect("~/Vistas/Productos/Crear.aspx");
        }


        protected void GridviewUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnEditar")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                GridViewRow row = GridviewProductos.Rows[index];
                string[] datosProducto = new string[] { row.Cells[0].Text, row.Cells[1].Text, row.Cells[3].Text, row.Cells[4].Text, row.Cells[5].Text };

                Session["editarProducto"] = datosProducto;


                Response.Redirect("~/Vistas/Productos/Editar.aspx");
            }
            else if (e.CommandName == "btnBorrar")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());

                GridViewRow row = GridviewProductos.Rows[index];

                //Conexión a la base de datos.
                SqlConnection conexion = new Conexion().Connection();
                conexion.Open();

                //Implementación con la clase ServiciosProductos
                Services.ServiciosProductos servicios = new Services.ServiciosProductos();
                servicios.borrarProducto(Convert.ToInt32(row.Cells[0].Text), conexion, "CRUDProducto");

                conexion.Close();

                Response.Redirect("~/Vistas/Productos/Lista.aspx");

            }
        }

        protected void FiltrarPorNombre(object sender, EventArgs e)
        {
            LoadData();
            if(FiltroNombre.Text != "")
            {
                DataView dv = new DataView(dt, "Nombre LIKE'%" + FiltroNombre.Text + "%'", "Nombre desc", DataViewRowState.CurrentRows);
                GridviewProductos.DataSource = dv;
                GridviewProductos.DataBind();
            }
           
        }

        protected void FiltrarPorCategoria(object sender, EventArgs e)
        {
            LoadData();
            if (FiltroCategoria.Text != "")
            {
                DataView dv = new DataView(dt, "Categoria LIKE'%" + FiltroCategoria.Text + "%'", "Categoria desc", DataViewRowState.CurrentRows);
                GridviewProductos.DataSource = dv;
                GridviewProductos.DataBind();
            }

        }
    }
}