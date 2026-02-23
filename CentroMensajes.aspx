<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CentroMensajes.aspx.cs" Inherits="CondominosAppWeb.CentroMensajes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   <form id="form1" runat="server">

        <h2>Centro de Mensajes</h2>

        <!-- Botón: Nuevo Mensaje -->
        <asp:Button ID="btnNuevo" runat="server" 
            Text="Nuevo Mensaje"
            OnClick="btnNuevo_Click" />
        <hr />
       
       <!-- Grid -->
       <asp:GridView ID="gvMensajes" runat="server" AutoGenerateColumns="false" Width="100%" DataKeyNames="Id" OnRowCommand="gvMensajes_RowCommand">
           
           <Columns>
               <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
               <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
               <asp:BoundField DataField="Status" HeaderText="Status" />
               <asp:BoundField DataField="PublicacionFechaInicio" HeaderText="Inicio" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
               <asp:BoundField DataField="PublicacionFechaFinal" HeaderText="Final" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
               
               <asp:ButtonField Text="Borrar" CommandName="BorrarMensaje" ButtonType="Button" />

           </Columns>

       </asp:GridView>

        <!-- Panel: Formulario -->
        <asp:Panel ID="pnlFormulario" runat="server" Visible="false">

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

            <asp:Button ID="btnSalvar" runat="server"
                Text="Save"
                OnClick="btnSalvar_Click" />

        </asp:Panel>
    </form>
</body>
</html>
