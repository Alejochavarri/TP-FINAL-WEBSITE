<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="NetPulse.Tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:20px">
        <asp:GridView  ID="dgvListaTecnicos" runat="server" CssClass="table table-bordered table-responsive">

</asp:GridView>
        <asp:Button type="submit" class="btn btn-primary mb-3" ID="btnAgregarTecnico" runat="server" Text="Agregar Tecnico" OnClick="btnAgregarTecnico_Click" />
    </div>
    
</asp:Content>
