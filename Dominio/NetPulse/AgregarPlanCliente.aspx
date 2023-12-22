<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AgregarPlanCliente.aspx.cs" Inherits="NetPulse.AgregarPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-5" style="text-align: left; margin: 20px">Nuevo Plan </h1>
    <div class="row g-3" style="margin: 100px">
        <div class="col-12">
            <label for="inputState" class="form-label">Plan</label>
            <asp:DropDownList ID="DDLPlanes" runat="server" class="form-select" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="col-6">
            <label for="inputIdPlan" class="form-label">ID</label>
            <asp:TextBox type="text" class="form-control" ID="inputIdPlan" placeholder="someone@example.com" ReadOnly="true" runat="server"></asp:TextBox>
        </div>
        <div class="col-6">
            <label for="inputCantMegas" class="form-label">CantMegas</label>
            <asp:TextBox type="text" class="form-control" ID="inputCantMegas" placeholder="XX-XXX-XXX" ReadOnly="true" runat="server"></asp:TextBox>
        </div>
        <div class="col-6">
            <label for="inputPrecio" class="form-label">Precio</label>
            <asp:TextBox type="text" class="form-control" ID="inputPrecio" placeholder="XX-XXX-XXX" ReadOnly="true" runat="server"></asp:TextBox>
        </div>
        <div class="col-12">
            <asp:Button ID="btnAgregarPlan" runat="server" Text="Agregar" type="submit" class="btn btn-primary" OnClick="btnAgregarPlan_Click" />
        </div>
    </div>
</asp:Content>
