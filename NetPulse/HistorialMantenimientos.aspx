<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="HistorialMantenimientos.aspx.cs" Inherits="NetPulse.HistorialMantenimientos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 20px">
    <h3>Historial De Mantenimientos</h3>
    <asp:GridView ID="dgvListaHistorialMantenimientos" runat="server" CssClass="table table-bordered table-responsive" AutoGenerateColumns="true">

    </asp:GridView>
</div>
</asp:Content>
