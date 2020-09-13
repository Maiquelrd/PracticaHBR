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
                        inputID.Value = ViewState["id"].ToString();
                        inputNombre.Value = ViewState["nombre"].ToString();
                        inputDescripcion.Value = ViewState["descripcion"].ToString();
                        inputPrecio.Value = ViewState["precio"].ToString();

                        inputIdCat.DataSource = GetItems();
                        inputIdCat.DataTextField = "ID";
                        inputIdCat.DataValueField = "ID";
                        inputIdCat.DataBind();
                    }
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

        protected void BtnConfirmar(object sender, EventArgs e)
        {
            //Conexión a la base de datos.
            SqlConnection conexion = new Conexion().Connection();
            conexion.Open();

            //Implementación con la clase ServiciosVarios
            HBRPractica.Services.ServiciosProductos servicios = new HBRPractica.Services.ServiciosProductos();


            bool respuesta = servicios.editarProducto(inputNombre.Value, inputDescripcion.Value, Convert.ToInt32(inputID.Value), Convert.ToInt32(Request.Form["inputIdCat"]),Convert.ToDecimal(inputPrecio.Value) , conexion, "CRUDProducto");

            conexion.Close();
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
            SqlConnection conexion = new Conexion().Connection();
            SqlCommand cmd = new SqlCommand("ObtenerCategoriasID", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conexion.Open();
                da.Fill(ds);
                conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return ds;
        }
    }
}