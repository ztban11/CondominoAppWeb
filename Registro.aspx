<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CondominosAppWeb.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro Condomino</title>
    <link rel="stylesheet" href="Content/styles.css" />
</head>
<body>
    <h2>Registro Condomino</h2>

    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />



        <div class="form-group">
            <label>Tipo Identificación</label>
            <select id="idType">
                <option value="">Seleccionar:</option>
                <option>Física</option>
                <option>DIMEX</option>
                <option>Pasaporte</option>
            </select>
            <span class="error" id="errorIdType"></span>
        </div>

        <div class="form-group">
            <label>Identificación</label>
            <input type="text" id="id"/>
            <span class="error" id="errorId"></span>
        </div>

        <div class="form-group">
            <label>Nombre</label>
            <input type="text" id="nombre"/>
            <span class="error" id="errorNombre"></span>
        </div>

         <div class="form-group">
            <label>Apellidos</label>
            <input type="text" id="apellidos" />
            <span class="error" id="errorApellidos"></span>
        </div>

        <div class="form-group">
            <label>Fecha de Nacimiento</label>
            <input type="date" id="fechaNacimiento" />
             <span class="error" id="errorFechaNacimiento"></span>
        </div>
        
        <div class="form-group">
            <label>Número de Filial</label>
            <input type="text" id="numeroFilial"/>
            <span class="error" id="errorNumeroFilial"></span>
        </div>
        
        <div class="form-group">
            <label>¿Tiene construcción?</label>
            <select id="tieneConstruccion">
                <option value="">Seleccionar:</option>
                <option value="true">Sí</option>
                <option value="false">No</option>
            </select>
             <span class="error" id="errorTieneConstruccion"></span>
        </div>

        <div class="form-group">
            <label>Email:</label>
            <input type="email" id="email"/>
            <span class="error" id="errorEmail"></span>
        </div>
        
        <div class="form-group">
            <label>Contraseña</label>
            <input type="password" id="password"/>
            <span class="error" id="errorPassword"></span>
        </div>
        
        <div class="form-group">
            <label>Confirmar contraseña</label>
            <input type="password" id="confirmPassword"/>
            <span class="error" id="errorConfirmarPassword"></span>
        </div>

        <div class="form-group">
            <input type="checkbox" id="terminos" />
             <label>¿Acepta Términos?</label>
             <span class="error" id="errorTerminos"></span>
        </div>

        <button type="button" onclick="registroCondomino()">Registro</button>

        <div id="mensaje"></div>
    </form>
    <script src="Scripts/registro.js"></script>
</body>
</html>
