<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AltaServicio.aspx.cs" Inherits="NetPulse.AltaServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-5" style="text-align: left; margin: 20px">Alta de Servicio </h1>


    <div style="margin: 40px 20px">

        <h3>Busqueda de Usuario</h3>

        <asp:Label style="margin-bottom:10px" ID="Label1" runat="server" Text="Filtrar DNI"></asp:Label>

        <div style="margin-bottom:10px;margin-top:10px" class="col-3">
            <label class="visually-hidden" for="inlineFormInputGroupUsername">DNI</label>
            <input type="text" class="form-control" id="inlineFormInputGroupUsername" placeholder="DNI">
        </div>

        <div style="margin-bottom:10px" class="col-12">
            <asp:Button ID="btnBuscarDni" runat="server" Text="Buscar" type="submit" class="btn btn-primary" OnClick="btnBuscarDni_Click" />
        </div>

        <asp:Label Style="color: darkgray" ID="Label2" runat="server" Text="Disponibilidad..."></asp:Label>

    </div>

    <div style="margin: 20px">
        <h3>Usuarios Inactivos</h3>
        <asp:GridView ID="dgvListaClientesInactivos" runat="server" CssClass="table table-bordered table-responsive" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="IdCliente" DataField="IdCliente" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="Dni" DataField="Dni" />
                <asp:BoundField HeaderText="FechaAlta" DataField="FechaAlta" />
                <asp:ButtonField HeaderText="Activar Servicio" ButtonType="Button" Text="Activar"/>

            </Columns>
        </asp:GridView>
    </div>

   
    <div style="margin: 40px 20px">

         <h3>Funcionalidades</h3>

        <asp:Button Style="margin: 20px 0px; display: block; margin-bottom: 20px" ID="btnAgregarNuevo" runat="server" Text="Agregar Nuevo" type="submit" class="btn btn-primary" OnClick="btnAgregarNuevo_Click" />

        <asp:Button Style="margin: 20px 0px; display: block; margin-bottom: 20px" ID="btnAgregarPlan" runat="server" Text="AgregarPlan" type="submit" class="btn btn-primary" OnClick="btnAgregarPlan_Click" />

        <asp:Button Style="margin: 20px 0px; display: block; margin-bottom: 20px" ID="btnAgregarDomicilio" runat="server" Text="AgregarDomicilio" type="submit" class="btn btn-primary" OnClick="btnAgregarDomicilio_Click" />
    </div>

</asp:Content>



