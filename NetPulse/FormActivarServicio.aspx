<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="FormActivarServicio.aspx.cs" Inherits="NetPulse.FormActivarServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 60px 20px">
        <h3>Servicio A Activar</h3>
        <asp:GridView ID="dgvDatosCliente" runat="server" CssClass="table table-bordered table-responsive table-success" AutoGenerateColumns="false" BorderColor="Green">
            <Columns>
                <asp:BoundField HeaderText="Cliente" DataField="Nombre" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="Mail" DataField="Mail" />
                <asp:BoundField HeaderText="Dni" DataField="Dni" />
                <asp:BoundField HeaderText="FechaAlta" DataField="FechaAlta" />
            </Columns>
        </asp:GridView>

        <asp:GridView ID="DgvDomicilio" runat="server" CssClass="table table-bordered table-responsive table-success" AutoGenerateColumns="false" BorderColor="Green">
            <Columns>
                <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                <asp:BoundField HeaderText="Barrio" DataField="Barrio" />
                <asp:BoundField HeaderText="Ciudad" DataField="Ciudad" />
                <asp:BoundField HeaderText="Comentario" DataField="Comentario" />
            </Columns>
        </asp:GridView>

        <asp:GridView ID="DgvPlan" runat="server" CssClass="table table-bordered table-responsive table-success" AutoGenerateColumns="false" BorderColor="Green">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Cant Megas" DataField="CantidadMegas" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
            </Columns>
        </asp:GridView>
    </div>

    <div style="margin: 20px">
        <asp:Button ID="btnActivarServicio" runat="server" type="submit" class="btn btn-success" Text="Aceptar" OnClick="btnActivarServicio_Click" />
        <asp:Button ID="btnModificarServicio" runat="server" type="submit" class="btn btn-warning" Text="Modificar" OnClick="btnModificarServicio_Click" />
        <asp:Button ID="btnCancelar" runat="server" type="submit" class="btn btn-primary" Text="Volver" OnClick="btnCancelar_Click" />
    </div>

    <div style="margin:20px">
        <asp:Label ID="lblServicioActivo" ForeColor="Green" runat="server" Text="Servicio Activado con Exito, " Visible="false"></asp:Label>
        <asp:Label ID="lblInstalacion" ForeColor="Green" runat="server" Text="Se Agendo un Mantenimiento de Tipo Instalacion" Visible="false"></asp:Label>
    </div>
</asp:Content>
