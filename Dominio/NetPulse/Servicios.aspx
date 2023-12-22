<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="NetPulse.Servicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:20px">
        <asp:GridView ID="dgvListaServicios" runat="server" CssClass="table table-bordered table-responsive " AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombre" />
                <asp:BoundField HeaderText="FormaPago" DataField="AbonoMensual.FormaPago.Nombre" />
                <asp:BoundField HeaderText="CantMegas" DataField="Plan.CantidadMegas" />
                <asp:BoundField HeaderText="Direccion" DataField="Domicilio.Direccion" />
                <asp:BoundField HeaderText="FechaAlta" DataField="FechaAlta" />
                <asp:CheckBoxField HeaderText="Estado" DataField="Estado" />
                <asp:BoundField HeaderText="Comentarios" DataField="Comentarios" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
