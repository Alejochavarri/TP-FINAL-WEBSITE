<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ActivarServicio.aspx.cs" Inherits="NetPulse.ActivarServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-5" style="text-align: left; margin: 20px">Agregar Servicio</h1>

    <div class="col-12" style="margin: 20px 20px">

        <asp:Label ID="lblDireccion" Style="margin: 10px 0px; display: block; font-size: x-large" Visible="false" runat="server" Text="Agregar Domicilio"></asp:Label>
        <asp:Button ID="AgregarDireccion" runat="server" Text="Agregar" type="submit" CssClass="btn btn-primary" Visible="false" OnClick="AgregarDireccion_Click" />
    </div>
    <div class="col-3" style="margin: 20px 20px">
        <asp:Label ID="lblPlan" Style="margin: 10px 0px; display: block; font-size: x-large" Visible="false" runat="server" Text="Agregar Plan"></asp:Label>

        <asp:Button ID="AgregarPlan" runat="server" Text="Agregar" type="submit" CssClass="btn btn-primary" Visible="false" OnClick="AgregarPlan_Click" />
    </div>
    <div class="col-3" style="margin: 20px 20px">
        <asp:Label ID="lblFDP" Style="margin: 10px 0px; display: block; font-size: x-large" Visible="false" runat="server" Text="Agregar Forma de Pago"></asp:Label>
        <asp:Button ID="AgregarFormaDePago" runat="server" Text="Agregar" type="submit" CssClass="btn btn-primary" Visible="false" OnClick="AgregarFormaDePago_Click" />
    </div>

    <div style="margin: 20px">

        <asp:GridView ID="DgvDatos" runat="server" CssClass="table table-bordered table-responsive table-success" AutoGenerateColumns="false" BorderColor="Green">
            <Columns>
                <asp:BoundField HeaderText="Direccion" DataField="Domicilio.Direccion" />
                <asp:BoundField HeaderText="Barrio" DataField="Domicilio.Barrio" />
                <asp:BoundField HeaderText="Ciudad" DataField="Domicilio.Ciudad" />
                <asp:BoundField HeaderText="Comentario" DataField="Domicilio.Comentario" />

                <asp:BoundField HeaderText="Plan" DataField="Plan.Nombre" />
                <asp:BoundField HeaderText="CantMegas" DataField="Plan.CantidadMegas" />
                <asp:BoundField HeaderText="Precio" DataField="Plan.Precio" />

                <asp:BoundField HeaderText="Forma Pago" DataField="AbonoMensual.FormaPago.Nombre" />
            </Columns>
        </asp:GridView>

    </div>

    <div class="col-3" style="margin: 60px 20px; display: block">
        <asp:Button ID="btnFinalizar" runat="server" Text="Agregar Servicio" type="submit" CssClass="btn btn-primary" OnClick="Finalizar_Click" Visible="false" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" type="submit" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" type="submit" CssClass="btn btn-primary" Visible="false" OnClick="btnVolver_Click" />
    </div>

    <div style="margin: 20px">
        <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Visible="false" Text="Servicio Agregado Con Exito!"></asp:Label>
    </div>


</asp:Content>

