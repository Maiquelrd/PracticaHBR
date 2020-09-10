﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBRPractica.Vistas.Productos
{
    public partial class Crear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                inputIdCat.DataSource = GetItems();
                inputIdCat.DataTextField = "ID";
                inputIdCat.DataValueField = "ID";
                inputIdCat.DataBind();

            }

        }

        protected void BtnCrear(object sender, EventArgs e)
        {
            //Conexión a la base de datos.
            SqlConnection conexión = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);
            conexión.Open();

            //Implementación con la clase ServiciosVarios
            HBRPractica.Services.ServiciosProductos servicios = new HBRPractica.Services.ServiciosProductos();


            bool respuesta = servicios.crearProducto(inputNombre.Value, inputDescripcion.Value, Convert.ToInt32(Request.Form["inputIdCat"]), Convert.ToDecimal(inputPrecio.Value), conexión, "CRUDProducto");

            conexión.Close();

            if (respuesta)
            {
                Response.Redirect("~/Vistas/Productos/Lista.aspx");
            }
            else
            {
                labelEstado.Text = "Ese usuario existe o hubo un error";
            }
        }

        protected void BtnVolver(object sender, EventArgs e)
        {

            Response.Redirect("~/Vistas/Productos/Lista.aspx");

        }

        public DataSet GetItems()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("ObtenerCategoriasID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                da.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return ds;
        }

    }
}