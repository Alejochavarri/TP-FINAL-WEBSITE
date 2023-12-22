<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="NetPulse.Tecnicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-5" style="text-align: left; margin: 20px">Administrador De Tecnicos</h1>
    <div style="margin:20px">
        <asp:GridView  ID="dgvListaTecnicos" runat="server" CssClass="table table-bordered table-responsive table-success">

</asp:GridView>
        <asp:Button type="submit" class="btn btn-primary mb-3" ID="btnAgregarTecnico" runat="server" Text="Agregar Tecnico" OnClick="btnAgregarTecnico_Click" />
    </div>
    
</asp:Content>
