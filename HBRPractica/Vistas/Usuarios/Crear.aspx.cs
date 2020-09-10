﻿using System;
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

        }

        protected void BtnCrear(object sender, EventArgs e)
        {
            //Conexión a la base de datos.
            SqlConnection conexión = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString);
            conexión.Open();

            //Implementación con la clase ServiciosVarios
            HBRPractica.Services.ServiciosUsuarios servicios = new HBRPractica.Services.ServiciosUsuarios();


            bool respuesta = servicios.crearUsuario(inputUser.Value, inputPassword.Value, checkAdmin, conexión, "CRUDUsuario");

            conexión.Close();

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