<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="NetPulse.Servicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-5" style="text-align: left; margin: 20px">Administrador De Servicios</h1>
    <div style="margin: 60px 20px">
        <h3>Busqueda de Servicios</h3>
        <asp:Label Style="margin-bottom: 10px" ID="Label1" runat="server" Text="Filtrar DNI"></asp:Label>
        <div style="margin-bottom: 10px; margin-top: 10px" class="col-3">
            <label class="visually-hidden" for="inlineFormInputGroupUsername">DNI</label>
            <asp:TextBox ID="inputDNI" class="form-control" placeholder="0" runat="server"></asp:TextBox>
        </div>
        <div style="margin-bottom: 10px" class="col-12">
            <asp:Button ID="btnBuscarDni" runat="server" Text="Buscar" type="submit" CssClass="btn btn-primary" OnClick="btnBuscarDni_Click" />
        </div>
        <asp:Label Style="color: darkgray" ID="LabelEstado" runat="server" Text="Disponibilidad..."></asp:Label>
        <div style="margin: 20px 0px">
            <asp:GridView ID="dgvServicioEncontrado" runat="server" CssClass="table table-bordered table-responsive table-info" AutoGenerateColumns="false" OnRowCommand="DgvListaServiciosEncontrados_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                    <asp:BoundField HeaderText="Nombre" DataField="Cliente.Nombre" />
                    <asp:BoundField HeaderText="Domicilio" DataField="Domicilio.Direccion" />
                    <asp:BoundField HeaderText="Dni" DataField="Cliente.Dni" />
                    <asp:BoundField HeaderText="Telefono" DataField="Cliente.Telefono" />
                    <asp:BoundField HeaderText="Fecha Alta Servicio" DataField="FechaAlta" />
                    <asp:BoundField HeaderText="Estado" DataField="Estado.Descripcion" />
                    <asp:ButtonField HeaderText="Gestionar" Text='<i class="fa-solid fa-pen-to-square"></i> Gestionar' ButtonType="Link" CommandName="Modificar_onClick" ControlStyle-CssClass="btn btn-primary" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div style="margin: 60px 20px">
        <h3>Lista de Servicios Activos</h3>
        <asp:GridView ID="DgvListaActivos" runat="server" CssClass="table table-bordered table-responsive table-success" BorderColor="Green" AutoGenerateColumns="false" OnRowCommand="DgvListaServiciosActivos_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombre" />
                <asp:BoundField HeaderText="FormaPago" DataField="AbonoMensual.FormaPago.Nombre" />
                <asp:BoundField HeaderText="CantMegas" DataField="Plan.CantidadMegas" />
                <asp:BoundField HeaderText="Direccion" DataField="Domicilio.Direccion" />
                <asp:BoundField HeaderText="FechaAlta" DataField="FechaAlta" />
                <asp:BoundField HeaderText="Estado" DataField="Estado.Descripcion" />
                <asp:BoundField HeaderText="Comentarios" DataField="Comentarios" />
                <asp:ButtonField HeaderText="Gestionar" Text='<i class="fa-solid fa-pen-to-square"></i> Gestionar' ButtonType="Link" CommandName="btnGestionar_OnClick" ControlStyle-CssClass="btn btn-primary" />
            </Columns>
        </asp:GridView>
    </div>
    <div style="margin: 60px 20px">
        <h3>Lista de Servicios Desinstalados</h3>
        <asp:GridView ID="dgvDesinstalados" runat="server" CssClass="table table-bordered table-responsive table-danger" BorderColor="Red" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombre" />
                <asp:BoundField HeaderText="FormaPago" DataField="AbonoMensual.FormaPago.Nombre" />
                <asp:BoundField HeaderText="CantMegas" DataField="Plan.CantidadMegas" />
                <asp:BoundField HeaderText="Direccion" DataField="Domicilio.Direccion" />
                <asp:BoundField HeaderText="FechaAlta" DataField="FechaAlta" />
                <asp:BoundField HeaderText="Estado" DataField="Estado.Descripcion" />
                <asp:BoundField HeaderText="Comentarios" DataField="Comentarios" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
