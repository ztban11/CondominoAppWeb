<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CondominosAppWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Sistema Condominos</h2>
        
        <div class="form-group">
            <label>Email: </label>
            <input type="email" id="loginEmail" />

        </div>
        
        <div class="form-group">
            <label>Contraseña: </label>
            <input type="password" id="loginPassword" />
        </div>
        
        <button type="button" onclick="login()">Ingresar</button>
        
        <div id="mensaje"></div>
        
        <script src="Scripts/registro.js"></script>
    </form>
</body>
</html>
