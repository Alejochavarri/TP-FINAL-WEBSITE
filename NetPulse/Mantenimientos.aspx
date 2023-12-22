<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Mantenimientos.aspx.cs" Inherits="NetPulse.Mantenimientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-5" style="text-align: left; margin: 20px">Administrador De Mantenimientos</h1>
    <div style="margin: 60px 20px">
        <h3>Busqueda de Mantenimientos</h3>
        <asp:Label Style="margin-bottom: 10px" ID="BuscarMantenimiento" runat="server" Text="Filtrar por Id Servicio"></asp:Label>
        <div style="margin-bottom: 10px; margin-top: 10px" class="col-3">
            <label class="visually-hidden" for="inlineFormInputGroupUsername">Id Servicio</label>
            <asp:TextBox ID="inputIdServicio" class="form-control" placeholder="0" runat="server"></asp:TextBox>
        </div>
        <div style="margin-bottom: 10px" class="col-12">
            <asp:Button ID="btnBuscarDni" runat="server" Text="Buscar" type="submit" class="btn btn-primary" OnClick="btnBuscarDni_Click" />
        </div>
        <asp:Label Style="color: darkgray" ID="LabelServicioEncontrado" runat="server" Text=""></asp:Label>
    </div>

    <div style="margin: 60px 20px">
        <h3>Instalaciones Pendientes </h3>
        <asp:GridView ID="dgvInstalacionesPendientes" runat="server" CssClass="table table-bordered table-responsive  table-secondary" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="IdMantenimiento" DataField="IdMantenimiento" />
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="FechaAgendado" DataField="Fecha" />
                <asp:BoundField HeaderText="TecnicoACargo" DataField="Tecnico.Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="TipoMantenimiento" DataField="TipoMantenimiento.Nombre" />
                <asp:BoundField HeaderText="Comentario" DataField="Comentarios" />
            </Columns>
        </asp:GridView>
    </div>

    <div style="margin: 40px 20px">
        <h3>Mantenimientos Pendientes</h3>
        <asp:GridView ID="dgvMantenimientosAltaPrioridad" runat="server" CssClass="table table-bordered table-responsive table-danger" AutoGenerateColumns="false" BorderColor="Red">
            <Columns>
                <asp:BoundField HeaderText="IdMantenimiento" DataField="IdMantenimiento" />
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="FechaAgendado" DataField="Fecha" />
                <asp:BoundField HeaderText="TecnicoACargo" DataField="Tecnico.Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="TipoMantenimiento" DataField="TipoMantenimiento.Nombre" />
                <asp:BoundField HeaderText="Comentario" DataField="Comentarios" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="DgvMantenimientosPendientes" runat="server" CssClass="table table-bordered table-responsive table-secondary" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="IdMantenimiento" DataField="IdMantenimiento" />
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="FechaAgendado" DataField="Fecha" />
                <asp:BoundField HeaderText="TecnicoACargo" DataField="Tecnico.Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="TipoMantenimiento" DataField="TipoMantenimiento.Nombre" />
                <asp:BoundField HeaderText="Comentario" DataField="Comentarios" />
            </Columns>
        </asp:GridView>
    </div>

    <div style="margin: 60px 20px">
        <h3>Desinstalaciones Pendientes </h3>
        <asp:GridView ID="DgvDesinstalacionesPendientes" runat="server" CssClass="table table-bordered table-responsive table-secondary" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="IdMantenimiento" DataField="IdMantenimiento" />
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="FechaAgendado" DataField="Fecha" />
                <asp:BoundField HeaderText="TecnicoACargo" DataField="Tecnico.Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="TipoMantenimiento" DataField="TipoMantenimiento.Nombre" />
                <asp:BoundField HeaderText="Comentario" DataField="Comentarios" />
            </Columns>
        </asp:GridView>
    </div>
    <hr />
    <div style="margin: 60px 20px">
        <h3>Mantenimientos Realizados </h3>
        <asp:GridView ID="DgvMantenimientosRealizados" runat="server" CssClass="table table-bordered table-responsive table-success" BorderColor="Green" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="IdMantenimiento" DataField="IdMantenimiento" />
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="FechaAgendado" DataField="Fecha" />
                <asp:BoundField HeaderText="FechaRealizado" DataField="FechaRealizado" />
                <asp:BoundField HeaderText="TecnicoACargo" DataField="Tecnico.Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="TipoMantenimiento" DataField="TipoMantenimiento.Nombre" />
                <asp:BoundField HeaderText="Comentario" DataField="Comentarios" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
