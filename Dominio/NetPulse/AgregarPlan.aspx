<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AgregarPlan.aspx.cs" Inherits="NetPulse.AgregarPlan1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-5" style="text-align: left; margin: 20px">Nuevo Plan </h1>
    <div class="row g-3" style="margin: 50px">
    <div class="col-6">
        <label for="inputCantMegas" class="form-label">CantMegas</label>
        <asp:TextBox type="text" class="form-control" ID="inputCantMegas" placeholder="0" runat="server"></asp:TextBox>
    </div>
    <div class="col-6">
        <label for="inputPrecio" class="form-label">Precio</label>
        <asp:TextBox type="text" class="form-control" ID="inputPrecio" placeholder="$" runat="server"></asp:TextBox>
    </div>

    <div class="col-12">
        <asp:Button ID="btnAgregarPlan" runat="server" Text="Agregar" type="submit" class="btn btn-primary" OnClick="btnAgregarPlan_Click" />
            <asp:Button ID="Cancelar" runat="server" Text="Cancelar" type="button" class="btn btn-warning" OnClick="Cancelar_Click" />

    </div>
</div>
</asp:Content>
