<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBar.ascx.cs" Inherits="HBRPractica.Vistas.NavBar" %>


<nav class="navbar navbar-expand-md navbar-dark bg-dark">
    <div class="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2">
        <ul class="navbar-nav mr-auto">
            <li class="nav-item" id="liProducto" runat="server">
                <a class="nav-link" onclick="document.location='/Vistas/Productos/Lista'">Productos</a>
            </li>
            <li class="nav-item" id="liCategoria" runat="server">
                <a class="nav-link" onclick="document.location='/Vistas/Categorias/Lista'">Categorías</a>
            </li>
            <li class="nav-item" id="liUsuario" runat="server">
                <a class="nav-link" onclick="document.location='/Vistas/Usuarios/Lista'">Usuarios</a>
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