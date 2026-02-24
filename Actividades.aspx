<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Actividades.aspx.cs" Inherits="CondominosAppWeb.Actividades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Actividades Condominos</title>
    <link href="<%= ResolveUrl("~/Content/styles.css") %>" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

    <div class="page-wrapper">
        <div class="page-container">
            <h2 class="page-title">Centro de Mensajes</h2>
    
    <hr class="divisor"/>

    <!-- Grid -->
    <asp:GridView ID="gvActividades" runat="server" CssClass="grid" AutoGenerateColumns="false" DataKeyNames="Id">
        
        <Columns>
            <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:BoundField DataField="PublicacionFechaInicio" HeaderText="Inicio" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
            <asp:BoundField DataField="PublicacionFechaFinal" HeaderText="Final" DataFormatString="{0:yyyy-MM-dd HH:mm}" />

        </Columns>

    </asp:GridView>

     <!-- Panel Principal: Formulario -->
     <asp:Panel ID="pnlActividades" runat="server" Visible="false" CssClass="form-panel">
         <asp:HiddenField ID="hiddenMessageId" runat="server" />

         <h3>Crear / Editar Mensaje</h3>

         <!-- Campos Comunes -->
         <asp:Label Text="Título:" runat="server" />
         <asp:TextBox ID="txtTitulo" runat="server" Width="300" />
         <br /><br />

         <asp:Label Text="Tipo:" runat="server" />

         <br /><br />

     </asp:Panel>

     <div class="regresar-container">
         <asp:HyperLink ID="lnkRegresar" runat="server" NavigateUrl="~/Condomino.aspx" CssClass="link-regresar">
      Salir
  </asp:HyperLink>

     </div>

        </div> <!-- page-container -->
        </div> <!-- "page-wrapper"-->

 </form>
</body>
</html>
