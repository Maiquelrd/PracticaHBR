<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="HBRPractica.Vistas.Usuarios.Lista" %>
<%@ Register Src="~/Vistas/NavBar.ascx" TagName="Barra" TagPrefix="TBarra" %>


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
    <TBarra:Barra runat="server" tipo="Usuario" />
    <div style="height:50px"></div>
    <form runat="server">
        <asp:ScriptManager runat="server"
       ID="ScriptManager1" 
       EnablePageMethods="true"
       EnablePartialRendering="true"/>
    
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <asp:Button type="button" class="btn btn-success" Text="Crear" runat="server" OnClick="BtnCrear"></asp:Button>
                <div style="height:30px"></div>
                <div class="table-responsive" runat="server">  
                    <asp:PlaceHolder  ID = "PlaceHolderUsuarios" runat="server" />
                    <div style="display: none;">
                        <asp:Button type="button" ID="botonBorrar" runat="server" class="btn btn-primary" onclick="BtnBorrar"></asp:Button>
                         <asp:Button type="button" ID="botonEditar" runat="server" class="btn btn-primary" onclick="BtnEditar"></asp:Button>
                    </div>
                    <asp:HiddenField ID="elementoID" runat="server"></asp:HiddenField>  
                </div>
            </div>
        </div>
    </div>  

        <!-- Scripts necesarios para que funcionen los botones de borrar y editar autogenerados -->
        <script type="text/javascript">
       
            function Borrar(id) {
                var button = document.getElementById('botonBorrar');
                document.getElementById('elementoID').value = id;
                button.click();
            }
            function Editar(id) {
                var button = document.getElementById('botonEditar');
                document.getElementById('elementoID').value = id;
                button.click();
            }
        </script>
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
