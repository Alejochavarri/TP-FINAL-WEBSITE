<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="GestionServicio.aspx.cs" Inherits="NetPulse.GestionServicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin: 60px 20px">
        <h3>Detalle Servicio</h3>
        <asp:GridView ID="dgvDatosCliente" runat="server" CssClass="table table-bordered table-responsive table-success" AutoGenerateColumns="false" BorderColor="Green">
            <Columns>
                <asp:BoundField HeaderText="Cliente" DataField="Nombre" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="Mail" DataField="Mail" />
                <asp:BoundField HeaderText="Dni" DataField="Dni" />
                <asp:BoundField HeaderText="Fecha Alta Cliente" DataField="FechaAlta" />
            </Columns>
        </asp:GridView>

        <asp:GridView ID="DgvDomicilio" runat="server" CssClass="table table-bordered table-responsive table-success" AutoGenerateColumns="false" BorderColor="Green">
            <Columns>
                <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                <asp:BoundField HeaderText="Barrio" DataField="Barrio" />
                <asp:BoundField HeaderText="Ciudad" DataField="Ciudad" />
                <asp:BoundField HeaderText="Comentario sobre el domicilio" DataField="Comentario" />
            </Columns>
        </asp:GridView>

        <asp:GridView ID="DgvPlan" runat="server" CssClass="table table-bordered table-responsive table-success" AutoGenerateColumns="false" BorderColor="Green">
            <Columns>
                <asp:BoundField HeaderText="Nombre plan" DataField="Nombre" />
                <asp:BoundField HeaderText="Cantidad de Megas" DataField="CantidadMegas" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="DgvFormaPago" runat="server" CssClass="table table-bordered table-responsive table-success" AutoGenerateColumns="false" BorderColor="Green">
            <Columns>
                <asp:BoundField HeaderText="Forma de Pago" DataField="Nombre" />
            </Columns>
        </asp:GridView>
    </div>

    <div style="margin: 20px">
        <h3>Administrar Servicio</h3>
    </div>

    <div style="margin: 20px">
        <div class="col-6" style="margin-bottom: 20px">
            <label for="inputState" class="form-label">Modificacion / Cambio de plan / Cambio de forma de pago</label>
            <asp:DropDownList ID="DDLModificaciones" runat="server" class="form-select" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div style="margin-top: 20px; margin-bottom: 20px">
            <asp:Button ID="btnModificar" type="submit" CssClass="btn btn-primary" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
            <asp:Label ID="lblSuccess" ForeColor="Green" runat="server" Visible="false" Text="Campo Modificado Con Exito!"></asp:Label>
        </div>

        <div class="col-6" style="margin-bottom: 20px">
            <label for="inputState" class="form-label">Agendar Mantenimiento / Ver historial de Mantenimientos</label>
            <asp:DropDownList ID="DDLOtros" runat="server" class="form-select" AutoPostBack="true"></asp:DropDownList>
        </div>
        <asp:Button ID="btnGestionar" type="submit" CssClass="btn btn-primary" runat="server" Text="Gestionar" OnClick="btnGestionar_Click" />
      
        
    </div>


    <div style="margin: 60px 20px">
        <h3>Historial </h3>
        <asp:GridView ID="dgvHistorialServicio" runat="server" CssClass="table table-bordered table-responsive table-warning" AutoGenerateColumns="false" BorderColor="Yellow">
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
