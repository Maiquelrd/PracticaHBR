<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HBRPractica.Login" %>

<!DOCTYPE html>
<html>


<head>


    <title>Loguearse</title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="Logincss.css" rel="stylesheet" type="text/css" />

</head>
<body>
    

    <asp:PlaceHolder id="Alerta" runat="server" />

  <div class="wrapper fadeInDown">
  <div id="formContent">
    

    <!-- Icono de HBR -->
    <div class="fadeIn first">
      <img src="https://media-exp1.licdn.com/dms/image/C4D1BAQFZE9CgHwkWWg/company-background_10000/0?e=2159024400&v=beta&t=uX7eFwT-mv29j4s8rrKQVJEv-YfB-QQPvTEGWIdTSuQ" id="icon" alt="User Icon" />
    </div>

    <!-- Formulario de Loguin -->
    <form runat="server">
      <asp:Textbox ID="login" class="fadeIn second" name="login" placeholder="Usuario" runat="server"></asp:Textbox>
      <asp:Textbox type="password" ID="password" class="fadeIn third" name="login" placeholder="Contraseña" runat="server"></asp:Textbox>
      
       <asp:Button class="fadeIn fourth" Text="Loguearse" onclick="BtnLoguear" runat="server"></asp:Button>

    </form>

     <!-- Boton de registro -->

    <div id="formFooter">
      <a class="underlineHover" runat="server" href="~/Vistas/Login/Register.aspx">Registrarse</a>
    </div>

  </div>
</div>

</body>
</html>
