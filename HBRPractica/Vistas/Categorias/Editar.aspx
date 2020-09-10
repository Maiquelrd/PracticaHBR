﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="HBRPractica.Vistas.Categorias.Editar" %>
<%@ Register Src="~/Vistas/NavBar.ascx" TagName="Barra" TagPrefix="TBarra" %>



<!DOCTYPE html>

<html lang="en">
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
    <TBarra:Barra runat="server" tipo="Categoria" />
    <div style="height:50px"></div>


    <!-- Contenido -->
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-10">
                <form runat="server">
                    <div class="form-group row">
                    <label for="inputUser" class="col-sm-2 col-form-label">ID</label>
                    <div class="col-sm-5">
                        <input type="text" class="form-control"  id="inputID" placeholder="ID" maxlength="30" runat="server" disabled="disabled">
                    </div>
                    </div>
                    <div class="form-group row">
                    <label for="inputUser" class="col-sm-2 col-form-label">Nombre</label>
                    <div class="col-sm-5">
                        <input type="text" class="form-control"  id="inputNombre" placeholder="Usuario" maxlength="30" runat="server">
                    </div>
                    </div>
                    <div class="form-group row">
                    <label for="inputPassword" class="col-sm-2 col-form-label">Descripcion</label>
                    <div class="col-sm-5">
                       <input type="text" class="form-control" id="inputDescripcion" placeholder="Contraseña" runat="server">
                    </div>
                    </div>
                    <div class="form-group row">
                    <div class="col-sm-10">
                        <asp:Button class="btn btn-success" Text="Confirmar cambios"  runat="server" OnClick="BtnConfirmar"></asp:Button>
                        <asp:Button type="button" class="btn btn-danger" Text="Volver" runat="server" OnClick="BtnVolver"></asp:Button>
                    </div>
                    </div>

                     <asp:label runat="server" id="labelEstado">
        Estado </asp:label>
                </form>

            </div>
        </div>  
    </div>    

</body>
</html>
