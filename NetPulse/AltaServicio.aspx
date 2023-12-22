<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AltaServicio.aspx.cs" Inherits="NetPulse.AltaServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:20px">
        <h3>Historial de modificaciones</h3>
    </div>
    <asp:Button ID="Button1" runat="server" style="margin:20px;display:block" type="submit" class="btn btn-primary" Text="Modificaciones de Clientes" />
     <asp:Button ID="Button2" runat="server" style="margin:20px;display:block" type="submit" class="btn btn-primary" Text="Modificaciones de Servicios" />
     <asp:Button ID="Button3" runat="server" style="margin:20px;display:block" type="submit" class="btn btn-primary" Text="Modificaciones de Planes" />
     <asp:Button ID="Button4" runat="server" style="margin:20px;display:block" type="submit" class="btn btn-primary" Text="Modificaciones de Tecnicos" />
     <asp:Button ID="Button5" runat="server" style="margin:20px;display:block" type="submit" class="btn btn-primary" Text="Modificaciones de Mantenimientos" />



</asp:Content>



