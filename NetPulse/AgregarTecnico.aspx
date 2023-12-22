<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AgregarTecnico.aspx.cs" Inherits="NetPulse.AgregarTecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-5" style="text-align: left; margin: 20px">Nuevo Tecnico </h1>
    <div class="row g-3" style="margin: 50px">
        <div class="col-md-6">
            <label for="inputNombre" class="form-label">Nombre</label>
            <asp:TextBox type="text" class="form-control" ID="inputNombre" placeholder="Apellido, Nombre" runat="server"></asp:TextBox>

        </div>
        <div class="col-md-6">
            <label for="inputContacto" class="form-label">Contacto</label>
            <asp:TextBox type="text" class="form-control" ID="inputContacto" placeholder="Datos de Contacto" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </div>


        <div class="col-12">
            <asp:Button ID="btnAgregarTecnico" runat="server" Text="Agregar" type="submit" class="btn btn-primary" OnClick="btnAgregarTecnico_Click" />
            <asp:Button ID="Cancelar" runat="server" Text="Cancelar" type="button" class="btn btn-warning" OnClick="Cancelar_Click" />

        </div>
        <div>
            <asp:Label ID="lblTecnicoAgregado" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
