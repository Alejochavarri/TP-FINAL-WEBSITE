<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NetPulse.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-5" style="text-align: left; margin: 20px">Administrador De Clientes</h1>
    <div style="margin: 20px">
        <div>
            <h3>Busqueda de Cliente</h3>
            <asp:Label Style="margin-bottom: 10px" ID="Label1" runat="server" Text="Filtrar DNI"></asp:Label>
            <div style="margin-bottom: 10px; margin-top: 10px" class="col-3">
                <label class="visually-hidden" for="inlineFormInputGroupUsername">DNI</label>
                <asp:TextBox ID="inputDNI" class="form-control" placeholder="0" runat="server"></asp:TextBox>
            </div>
            <div style="margin-top: 25px" class="col-12">
                <asp:Button ID="btnBuscarDni" runat="server" Text="Buscar" type="submit" class="btn btn-primary" OnClick="btnBuscarDni_Click" />
                <asp:Button Style="margin-left: 10px" ID="btnAgregarNuevo" runat="server" Text="Agregar Nuevo Cliente" type="submit" class="btn btn-primary" OnClick="btnAgregarNuevo_Click" />
            </div>
            <asp:Label Style="color: darkgray" ID="LabelEstado" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Label ID="LabelActivo" runat="server" Text="" Visible="false"></asp:Label>
            <%
                if (LabelActivo.Text == "Activo")
                {

            %>
            <asp:GridView ID="dgvUsuarioEncontrado" DataKeyNames="IdCliente" runat="server" CssClass="table table-bordered table-responsive table-info" AutoGenerateColumns="false" OnRowCommand="DgvListaClientesActivos_RowCommand">

                <Columns>
                    <asp:BoundField HeaderText="IdCliente" DataField="IdCliente" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Dni" DataField="Dni" />
                    <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                    <asp:BoundField HeaderText="Mail" DataField="Mail" />
                    <asp:BoundField HeaderText="Fecha Alta Servicio" DataField="FechaAlta" />

                    <asp:ButtonField HeaderText="Agregar Servicio" Text='<i class="fa-solid fa-plus"></i> Agregar' ButtonType="Link" CommandName="AgregarServicio_onClick" ControlStyle-CssClass="btn btn-secondary" />
                    <asp:ButtonField HeaderText="Detalle Cliente" Text='<i class="fa-solid fa-magnifying-glass"></i> Ver' ButtonType="Link" CommandName="Detalle_onClick" ControlStyle-CssClass="btn btn-secondary" />
                </Columns>
            </asp:GridView>
            <%} %>
        </div>
    </div>
    <div style="margin: 60px 20px">
        <h3>Usuarios Sin Servicio Asociado</h3>
        <asp:GridView ID="dgvListaClientesInactivos" DataKeyNames="IdCliente" runat="server" CssClass="table table-bordered table-responsive table-info" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvListaClientesInactivos_SelectedIndexChanged" OnRowCommand="dgvListaClientesInactivos_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="IdCliente" DataField="IdCliente" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="Dni" DataField="Dni" />
                <asp:BoundField HeaderText="Mail" DataField="Mail" />
                <asp:BoundField HeaderText="FechaAlta" DataField="FechaAlta" />

                <asp:CommandField HeaderText="Agregar Servicio" SelectText='<i class="fa-solid fa-plus"></i> Agregar' ShowSelectButton="true" ControlStyle-CssClass="btn btn-secondary"/>

                <asp:ButtonField HeaderText="Detalle Cliente" Text='<i class="fa-solid fa-magnifying-glass"></i> Ver' ButtonType="Link" CommandName="Detalle_onClick" ControlStyle-CssClass="btn btn-secondary"/>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblClientesSinServicios" runat="server" Text="No se Encontraron Usuarios Sin Servicio asociado" Visible="false"></asp:Label>
    </div>
    <div style="margin: 20px">
        <h3 style="margin: 20px 0px">Lista De Clientes</h3>
        <asp:GridView ID="dgvListaClientes" runat="server" CssClass="table table-bordered table-responsive table-success" AutoGenerateColumns="false" OnRowDataBound="dgvListaClientes_rowDataBound">
            <Columns>
                <asp:BoundField HeaderText="IdCliente" DataField="IdCliente" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Dni" DataField="Dni" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="Mail" DataField="Mail" />
                <asp:BoundField HeaderText="Fecha Alta Servicio" DataField="FechaAlta" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
