﻿using System;
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
    public partial class ListaUser : System.Web.UI.Page
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

                        StringBuilder html = servicios.obtenerTabla(dt);

                        PlaceHolderProductos.Controls.Add(new Literal { Text = html.ToString() });
                    }
                }
            }


        }
    }
}