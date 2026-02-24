<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Condomino.aspx.cs" Inherits="CondominosAppWeb.Condomino" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema Condominos: Condomino</title>
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" />
</head>
<body class="centered-page">
    <form id="form1" runat="server">
        <h2>Bienvenido Condomino</h2>
        <ul>
            <li><a href="Actividades.aspx">Ver Actividades</a></li>
            <li><a href="Logout.aspx">Salir</a></li>
        </ul>
    </form>
</body>
</html>
