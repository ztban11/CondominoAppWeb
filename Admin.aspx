<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="CondominosAppWeb.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema Condominos: Admin</title>
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" />
</head>
<body class="centered-page">
    <form id="form1" runat="server">
        <h2>Bienvenido Administrador</h2>
        <ul>
            <li><a href="Registro.aspx">Registrar Condomino</a></li>
            <li><a href="CentroMensajes.aspx">Centro de Mensajes</a></li>
            <li><a href="Actividades.aspx">Ver Actividades</a></li>
            <li><a href="Logout.aspx">Salir</a></li>
        </ul>
    </form>
</body>
</html>
