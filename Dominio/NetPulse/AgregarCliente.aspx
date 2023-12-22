<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="NetPulse.AgregarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-5" style="text-align: left; margin: 20px">Nuevo Cliente </h1>
    <div class="row g-3" style="margin: 100px">
        <div class="col-md-6">
            <label for="inputName" class="form-label">Nombre</label>
            <asp:TextBox type="text" class="form-control" ID="inputName" placeholder="Nombre, Apellido" runat="server"></asp:TextBox>
            
        </div>
        <div class="col-md-6">
            <label for="inputTelefono" class="form-label">Telefono</label>
            <asp:TextBox type="text" class="form-control" ID="inputTelefono" placeholder="11-1234-5678" runat="server"></asp:TextBox>
        </div>
        <div class="col-6">
            <label for="inputEmail" class="form-label">Email</label>
            <asp:TextBox type="text" class="form-control" ID="inputEmail" placeholder="someone@example.com" runat="server"></asp:TextBox>
        </div>
        <div class="col-6">
            <label for="inputDNI" class="form-label">DNI</label>
            <asp:TextBox type="text" class="form-control" ID="inputDNI" placeholder="XX-XXX-XXX" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label for="FechaAlta" class="form-label">FechaAlta</label>
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </div>

        <div class="col-12">
            <div class="form-check">
                <asp:CheckBox ID="chbActivo" runat="server" CssClass="form-check-input"/>
                <label class="form-check-label" for="gridCheck">
                    Activo
                </label>
            </div>
        </div>
        <div class="col-12">

            <asp:Button ID="agregarCliente" runat="server" Text="Crear" type="submit" class="btn btn-primary" OnClick="agregarCliente_Click" />
            <asp:Button ID="Cancelar" runat="server" Text="Cancelar" type="button" class="btn btn-warning" OnClick="Cancelar_Click" />

        </div>
        <div>
            <asp:Label ID="lblclienteAgregado" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
