<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ServiciosMorosos.aspx.cs" Inherits="NetPulse.ServiciosMorosos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblEstado" Visible="false" runat="server" Text=""></asp:Label>
    <h1 class="display-5" style="text-align: left; margin: 20px">Servicios Morosos</h1>

    <%if (lblEstado.Text == "")
        {  %>

    <div style="margin: 20px">
        <h3>Busqueda de Servicios</h3>
        <asp:Label Style="margin-bottom: 10px" ID="Label1" runat="server" Text="Filtrar DNI"></asp:Label>
        <div style="margin-bottom: 10px; margin-top: 10px" class="col-3">
            <label class="visually-hidden" for="inlineFormInputGroupUsername">DNI</label>
            <asp:TextBox ID="inputDNI" class="form-control" placeholder="0" runat="server"></asp:TextBox>
        </div>
        <div style="margin-bottom: 10px" class="col-12">
            <asp:Button ID="btnBuscarDni" runat="server" Text="Buscar" type="submit" class="btn btn-primary" OnClick="btnBuscarDni_Click" />
        </div>
    </div>
    

    <div style="margin: 60px 20px">
        <h3>Lista de Deudores</h3>
        <asp:GridView ID="dgvListaDeudores" runat="server" CssClass="table table-bordered table-responsive table-danger" AutoGenerateColumns="false" BorderColor="Red" OnRowCommand="dgvListaDeudores_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombre" />
                <asp:BoundField HeaderText="FormaPago" DataField="AbonoMensual.FormaPago.Nombre" />
                <asp:BoundField HeaderText="CantMegas" DataField="Plan.CantidadMegas" />
                <asp:BoundField HeaderText="Direccion" DataField="Domicilio.Direccion" />
                <asp:BoundField HeaderText="FechaAlta" DataField="FechaAlta" />
                <asp:BoundField HeaderText="Estado" DataField="Estado.Descripcion" />
                <asp:BoundField HeaderText="Comentarios" DataField="Comentarios" />
                <asp:ButtonField HeaderText="Regularizar Situacion" Text="Regularizar" ButtonType="Link" CommandName="Activar_onClick" />
            </Columns>
        </asp:GridView>
    </div>
    <%} %>

    <%if (lblEstado.Text == "1")
        {  %>
    <div style="margin: 60px 20px">

        <asp:GridView ID="dgvAuxiliar" runat="server" CssClass="table table-bordered table-responsive table-danger" AutoGenerateColumns="false" BorderColor="Red">
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
    <div style="margin: 40px 20px;display: block; text-align: center;">
        <asp:Label ID="lblInhabilitado" runat="server" ForeColor="Green" Visible="false" Text="Servicio habilitado Con Exito!"></asp:Label>
    </div>
    <div style="margin:20px;display: block; text-align: center;">
        <asp:Button ID="btnCancelar" type="submit" Style="margin-left: 10px" CssClass="btn btn-primary" runat="server" Text="Volver" OnClick="btnCancelar_Click" />
    </div>

    <%} %>
</asp:Content>
