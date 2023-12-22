<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Modificaciones.aspx.cs" Inherits="NetPulse.Modificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="labelCheck" runat="server" Text="" Visible="false"></asp:Label>

    <%if (labelCheck.Text == "1")
        {  %>

    <div style="margin: 20px">
        <h3>Domicilio</h3>
    </div>

    <div class="row g-3" style="margin: 20px">
        <div class="col-md-6">
            <label for="inputDireccion" class="form-label">Direccion</label>
            <asp:TextBox type="text" class="form-control" ID="inputDireccion" placeholder="Calle 123" runat="server"></asp:TextBox>
        </div>

        <div class="col-md-6">
            <label for="inputBarrio" class="form-label">Barrio</label>
            <asp:TextBox type="text" class="form-control" ID="inputBarrio" placeholder="Barrio" runat="server"></asp:TextBox>
        </div>

        <div class="col-6">
            <label for="inputCiudad" class="form-label">Ciudad</label>
            <asp:TextBox type="text" class="form-control" ID="inputCiudad" placeholder="Ciudad" runat="server"></asp:TextBox>
        </div>

        <div class="col-6">
            <label for="inputComentarios" class="form-label">Comentarios</label>
            <asp:TextBox type="text" class="form-control" ID="inputComentarios" placeholder="Especificaciones sobre el domicilio..." runat="server"></asp:TextBox>
        </div>

    </div>
    <asp:Button ID="btnDireccion" Style="margin: 20px" type="submit" CssClass="btn btn-primary" runat="server" Text="Modificar" OnClick="btnDireccion_Click" />
    <%} %>

    <%if (labelCheck.Text == "2")
        {  %>

    <div style="margin: 20px">
        <h3>Plan Elegido</h3>
    </div>

    <div class="row g-3" style="margin: 20px">

        <div class="col-12">
            <label for="inputState" class="form-label">Plan</label>
            <asp:DropDownList ID="DDLPlanes" runat="server" class="form-select" AutoPostBack="true"></asp:DropDownList>
        </div>

        <div class="col-6">
            <label for="inputIdPlan" class="form-label">ID</label>
            <asp:TextBox type="text" class="form-control" ID="inputIdPlan" placeholder="someone@example.com" aria-label="Disabled input" ReadOnly="true" runat="server"></asp:TextBox>
        </div>

        <div class="col-6">
            <label for="inputCantMegas" class="form-label">CantMegas</label>
            <asp:TextBox type="text" class="form-control" ID="inputCantMegas" placeholder="XX-XXX-XXX" aria-label="Disabled input" ReadOnly="true" runat="server"></asp:TextBox>
        </div>

        <div class="col-6">
            <label for="inputPrecio" class="form-label">Precio</label>
            <asp:TextBox type="text" class="form-control" ID="inputPrecio" placeholder="XX-XXX-XXX" aria-label="Disabled input" ReadOnly="true" runat="server"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="Button1" Style="margin: 20px" type="submit" CssClass="btn btn-primary" runat="server" Text="Modificar" OnClick="btnPlan_Click" />
    <%} %>

    <%if (labelCheck.Text == "3")
        { %>

    <div style="margin: 20px">
        <h3>Forma de Pago</h3>
    </div>

    <div class="row g-3" style="margin: 20px">
        <div class="col-12">
            <label for="inputPago" class="form-label">Medio de pago</label>
            <asp:DropDownList ID="DDLMedioDePago" runat="server" class="form-select" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>
    <asp:Button ID="btnFDP" Style="margin: 20px" type="submit" CssClass="btn btn-primary" runat="server" Text="Modificar" OnClick="btnFDP_Click" />
    <%} %>

    <%if (labelCheck.Text == "4")
        {  %>

    <div style="margin:20px">
        <h3>Inhabilitar Servicio</h3>
        <asp:GridView ID="DgvServicio" runat="server" CssClass="table table-bordered table-responsive table-primary" BorderColor="Black" AutoGenerateColumns="false" >
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
    <div style="margin: 40px 20px">
        <asp:Button ID="btnBaja" type="submit" CssClass="btn btn-danger" runat="server" Text="Inhabilitar Servicio" OnClick="btnBaja_Click" />
        <asp:Button ID="btnCancelar" type="submit" Style="margin-left: 10px" CssClass="btn btn-success" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        <asp:Label ID="lblInhabilitado" runat="server" ForeColor="Red" Visible="false" Text="Servicio Inhabilitado Con Exito!"></asp:Label>
    </div>




    <%} %>
</asp:Content>
