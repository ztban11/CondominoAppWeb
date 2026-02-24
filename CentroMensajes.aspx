<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CentroMensajes.aspx.cs" Inherits="CondominosAppWeb.CentroMensajes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Centro de Mensajes</title>
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" />
</head>
<body>
   <form id="form1" runat="server">

       <div class="page-wrapper">
           <div class="page-container">
               <h2 class="page-title">Centro de Mensajes</h2>

        <!-- Botón: Nuevo Mensaje -->
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Mensaje" CssClass="btn-primary" OnClick="btnNuevo_Click" />
       
       <hr class="divisor"/>

       <!-- Grid -->
       <asp:GridView ID="gvMensajes" runat="server" CssClass="grid" AutoGenerateColumns="false" DataKeyNames="Id"
           OnRowCommand="gvMensajes_RowCommand" OnRowDataBound="gvMensajes_RowDataBound">
           
           <Columns>
               <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
               <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
               <asp:BoundField DataField="Status" HeaderText="Status" />
               <asp:BoundField DataField="PublicacionFechaInicio" HeaderText="Inicio" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
               <asp:BoundField DataField="PublicacionFechaFinal" HeaderText="Final" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
               <asp:ButtonField Text="Modificar" CommandName="Modificar" ButtonType="Button" />
               <asp:ButtonField Text="Borrar" CommandName="Borrar" ButtonType="Button" />

           </Columns>

       </asp:GridView>

        <!-- Panel Principal: Formulario -->
        <asp:Panel ID="pnlFormulario" runat="server" Visible="false" CssClass="form-panel">
            <asp:HiddenField ID="hiddenMessageId" runat="server" />

            <h3>Crear / Editar Mensaje</h3>

            <!-- Campos Comunes -->
            <asp:Label Text="Título:" runat="server" />
            <asp:TextBox ID="txtTitulo" runat="server" Width="300" />
            <br /><br />

            <asp:Label Text="Tipo:" runat="server" />
            <asp:DropDownList ID="ddlTipo" runat="server" 
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
                <asp:ListItem Text="Seleccionar:" Value="" />
                <asp:ListItem Text="Reunión" Value="Reunion" />
                <asp:ListItem Text="Actividad Social" Value="ActividadSocial" />
                <asp:ListItem Text="Recordatorio" Value="Recordatorio" />
            </asp:DropDownList>

            <br /><br />

            <!-- Paneles Dinámicos -->

            <asp:Panel ID="pnlReunion" runat="server" Visible="false">
                <h4>Detalles Reunión</h4>
                Fecha:
                <asp:TextBox ID="txtFechaReunion" runat="server" TextMode="DateTimeLocal"/>
                <br />
                Agenda:
                <asp:TextBox ID="txtAgenda" runat="server" />
            </asp:Panel>

            <asp:Panel ID="pnlSocial" runat="server" Visible="false">
                <h4>Detalles Actividad Social</h4>
                Fecha Inicio:
                <asp:TextBox ID="txtActividadFechaInicio" runat="server" TextMode="DateTimeLocal"/>
                <br />
                Fecha Final:
                <asp:TextBox ID="txtActividadFechaFinal" runat="server" TextMode="DateTimeLocal"/>
            </asp:Panel>

            <asp:Panel ID="pnlRecordatorio" runat="server" Visible="false">
                <h4>Detalles Recordatorio</h4>
                Descripción:
                <asp:TextBox ID="txtRecordatorio" runat="server" />
            </asp:Panel>

            <br />

            <asp:Button ID="btnSalvar" runat="server" Text="Guardar" CssClass="btn-success" OnClick="btnSalvar_Click" />

        </asp:Panel>

        <div class="regresar-container">
            <asp:HyperLink ID="lnkRegresar" runat="server" NavigateUrl="~/Admin.aspx" CssClass="link-regresar">
         Salir
     </asp:HyperLink>

        </div>

           </div> <!-- page-container -->
           </div>

    </form>
</body>
</html>
