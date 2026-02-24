<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CondominosAppWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema Condominos</title>
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" />
</head>
<body class="centered-page">
    <form id="form1" runat="server" autocomplete="off">
        <h2>Sistema Condominos</h2>
        
        <div class="form-group">
            <label>Email: </label>
            <input type="email" id="loginEmail" autocomplete="off" />

        </div>
        
        <div class="form-group">
            <label>Contraseña: </label>
            <input type="password" id="loginPassword" autocomplete="new-password" />
        </div>
        
        <button type="button" onclick="login()">Ingresar</button>
        
        <div id="mensaje"></div>
        
        <script src="Scripts/registro.js"></script>

           <div class="registro-principal-container">
       <asp:HyperLink ID="lnkRegistrar" runat="server" NavigateUrl="~/Registro.aspx" CssClass="link-registrar">
    Registro
</asp:HyperLink>

   </div>
    </form>
</body>
</html>
