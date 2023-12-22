<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="DetalleCliente.aspx.cs" Inherits="NetPulse.DetalleCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 60px 20px">
        <h3>Informacion del Cliente</h3>
        <asp:GridView ID="dgvDatosCliente" runat="server" DataKeyNames="IdCliente" CssClass="table table-bordered table-responsive table-success" AutoGenerateColumns="false" BorderColor="Green" OnRowCommand="dgvDatosCliente_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="IdCliente" DataField="IdCliente" />
                <asp:BoundField HeaderText="Cliente" DataField="Nombre" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="Mail" DataField="Mail" />
                <asp:BoundField HeaderText="Dni" DataField="Dni" />
                <asp:BoundField HeaderText="FechaAlta" DataField="FechaAlta" />
                <asp:ButtonField HeaderText="Modificaciones" Text="Modificar" ButtonType="Link" CommandName="Modificar_onClick" />

            </Columns>
        </asp:GridView>
    </div>

    <div style="margin: 60px 20px">
        <h3>Historial </h3>
        <asp:GridView ID="dgvHistorialCliente" runat="server" CssClass="table table-bordered table-responsive table-warning" AutoGenerateColumns="false" BorderColor="Yellow">
            <Columns>
                <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                <asp:BoundField HeaderText="TipoCambio" DataField="TipoCambio.Descripcion" />
            </Columns>
        </asp:GridView>
    </div>
    <div style="margin: 60px 20px">
        <asp:Button ID="btnCancelar" runat="server" type="submit" class="btn btn-primary" Text="Volver" OnClick="btnCancelar_Click" />
    </div>

</asp:Content>

