<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="HBRPractica.Vistas.Categorias.Lista" %>
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
  
</head>
<body>



      <!-- Barra -->
   <TBarra:Barra runat="server" tipo="Categoria" />
    <div style="height:50px"></div>
   
    <form runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <asp:Button type="button" class="btn btn-success" Text="Crear" runat="server" OnClick="BtnCrear"></asp:Button>
                    <div style="height:30px"></div>
                    <div class="table-responsive" runat="server">  
                        <asp:PlaceHolder  ID = "PlaceHolderUsuarios" runat="server" />
                        <asp:GridView ID="GridviewCategoria" runat="server" AutoGenerateColumns="false" onrowcommand="GridviewCategoria_RowCommand" CssClass="table table-condensed table-hover" UseAccessibleHeader="true"  >
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                                <asp:TemplateField HeaderText="Editar categoría">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="botonEditar" class="btn btn-warning" Text="Editar" CommandName="btnEditar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="Borrar categoría">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="botonBorrar" class="btn btn-danger" Text="Borrar" CommandName="btnBorrar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>  
    </form>
   
    

</body>
</html>
