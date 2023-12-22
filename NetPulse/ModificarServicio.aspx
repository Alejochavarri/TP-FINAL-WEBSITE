<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ModificarServicio.aspx.cs" Inherits="NetPulse.ModificarServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin: 20px">
        <h3>Modificar Servicios</h3>
    </div>

    <div class="col-3" style="margin: 20px 20px; display: block">
        <asp:Button ID="ModificarDireccion" runat="server" Text="Modificar Direccion" type="submit" CssClass="btn btn-primary" OnClick="ModificarDireccion_Click" />
    </div>
    <div class="col-3" style="margin: 20px 20px; display: block">
        <asp:Button ID="ModificarPlan" runat="server" Text="Modificar Plan" type="submit" CssClass="btn btn-primary" OnClick="ModificarPlan_Click" />
    </div>
    <div class="col-3" style="margin: 20px 20px; display: block">
        <asp:Button ID="ModificarFormaDePago" runat="server" Text="Modificar Forma de Pago" type="submit" CssClass="btn btn-primary" OnClick="ModificarFormaDePago_Click" />
    </div>
    <div class="col-3" style="margin: 20px 20px; display: block">
        <asp:Button ID="DardeBaja" runat="server" Text="Baja del Servicio" type="submit" CssClass="btn btn-primary" OnClick="DardeBaja_Click" />
    </div>
    <div class="col-3" style="margin: 20px 20px; display: block">
        <asp:Button ID="btnAgendarMantenimiento" runat="server" Text="Registrar Reclamo" type="submit" CssClass="btn btn-primary" Enabled="true" OnClick="btnAgendarMantenimiento_Click" />
    </div>

</asp:Content>
