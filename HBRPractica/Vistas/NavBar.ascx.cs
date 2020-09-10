using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBRPractica.Vistas
{
    public partial class NavBar : System.Web.UI.UserControl
    {
        public string Tipo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Tipo == "Usuario")
            {
                liUsuario.Attributes["class"] = "nav-item active";
            }
            else if(Tipo == "Categoria")
            {
                liCategoria.Attributes["class"] = "nav-item active";
            }
            else if (Tipo == "Producto")
            {
                liProducto.Attributes["class"] = "nav-item active";
            }
        }
    }
}