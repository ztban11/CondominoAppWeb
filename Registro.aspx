<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CondominosAppWeb.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro Condomino</title>
    <link rel="stylesheet" href="Content/styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />
        <h2>Registro Condomino</h2>

        <select id="idType">
            <option value="">Seleccione Tipo Identificación</option>
            <option>Física</option>
            <option>DIMEX</option>
            <option>Pasaporte</option>
        </select>

        <input type="text" id="id" placeholder="Identificación" />
        <input type="text" id="nombre" placeholder="Nombre" />
        <input type="text" id="apellidos" placeholder="Apellidos" />
        <input type="date" id="fechaNacimiento" />
        <input type="text" id="numeroFilial" placeholder="Número de filial" />

        <label>
            <input type="checkbox" id="tieneConstruccion" />
            ¿Tiene construcción?
        </label>

        <input type="email" id="email" placeholder="Email" />
        <input type="password" id="password" placeholder="Contraseña" />
        <input type="password" id="confirmPassword" placeholder="Confirmar contraseña" />

        <label>
            <input type="checkbox" id="terminos" />
            ¿Acepta Términos?
        </label>

        <button type="button" onclick="registroCondomino()">Registro</button>

        <div id="mensaje"></div>
    </form>
    <script src="Scripts/registro.js"></script>
</body>
</html>
