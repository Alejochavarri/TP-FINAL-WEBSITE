<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="NetPulse.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="margin:20px">
        <asp:GridView  ID="dgvListaPlanes" runat="server" CssClass="table table-bordered table-responsive">

</asp:GridView>
            <asp:Button type="submit" class="btn btn-primary mb-3" ID="btnAgregarPlan" runat="server" Text="Agregar Plan" OnClick="btnAgregarPlan_Click" />
    </div>
</asp:Content>
