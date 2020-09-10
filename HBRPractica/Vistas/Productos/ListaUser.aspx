<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaUser.aspx.cs" Inherits="HBRPractica.Vistas.Productos.ListaUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Practica HBR</title>

      <!-- Metatags requeridos -->
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
      
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="~/datatable/bootstrap/css/bootstrap.min.css"/>
    <!-- CSS personalizado --> 
    <link rel="stylesheet" href="~/datatable/main.css"/>  
      
      
    <!--datables CSS básico-->
    <link rel="stylesheet" type="text/css" href="~/datatable/datatables/datatables.min.css"/>
    <!--datables estilo bootstrap 4 CSS-->  
    <link rel="stylesheet"  type="text/css" href="~/datatable/datatables/DataTables-1.10.18/css/dataTables.bootstrap4.min.css"/>

</head>
<body>



      <!-- Barra -->
    <nav class="navbar navbar-expand-md navbar-dark bg-dark">
    <div class="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2">
        <ul class="navbar-nav mr-auto">
            <li class="nav-item active" id="liProducto" runat="server">
                <a class="nav-link" onclick="document.location='/Vistas/Productos/ListaUser'">Productos</a>
            </li>
        </ul>
    </div>
    <div class="mx-auto order-0">
        <a class="navbar-brand mx-auto" href="#">HBR</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".dual-collapse2">
            <span class="navbar-toggler-icon"></span>
        </button>
    </div>
    <div class="navbar-collapse collapse w-100 order-3 dual-collapse2">
        <ul class="navbar-nav ml-auto">
            <li class="nav-item">
                <a class="nav-link" onclick="document.location='/Vistas/Login/Login'">Cerrar sesión</a>
            </li>
        </ul>
    </div>
    </nav>
    <div style="height:50px"></div>


    <form runat="server">
        <asp:ScriptManager runat="server"
       ID="ScriptManager1" 
       EnablePageMethods="true"
       EnablePartialRendering="true"/>
    
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div style="height:30px"></div>
                    <div class="table-responsive" runat="server">  
                        <asp:PlaceHolder  ID = "PlaceHolderProductos" runat="server" />
                    </div>
                </div>
            </div>
        </div>  


    </form>
   
    
      
       

     <!-- jQuery, Popper.js, Bootstrap JS -->
    <script src="<%=ResolveUrl("~/datatable/jquery/jquery-3.3.1.min.js") %>"></script>
    <script src="<%=ResolveUrl("~/datatable/popper/popper.min.js") %>"></script>
    <script src="<%=ResolveUrl("~/datatable/bootstrap/js/bootstrap.min.js") %>"></script>

    <!-- datatables JS -->
    <script type="text/javascript" src="<%=ResolveUrl("~/datatable/datatables/datatables.min.js") %>"></script>    
     
    <script type="text/javascript" src="<%=ResolveUrl("~/datatable/main.js") %>"></script>  

</body>
</html>
