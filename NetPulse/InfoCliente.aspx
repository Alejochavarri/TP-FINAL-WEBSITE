<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTecnico.Master" AutoEventWireup="true" CodeBehind="InfoCliente.aspx.cs" Inherits="NetPulse.InfoCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:20px">
        <h3>Informacion del Usuario</h3>
    </div>
    
    <div style="margin:20px">
    <asp:GridView ID="dgvUsuario" DataKeyNames="IdServicio" runat="server" CssClass="table table-bordered table-responsive" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField HeaderText="Nombre" DataField="Cliente.Nombre" />
        <asp:BoundField HeaderText="Ciudad" DataField="Domicilio.Ciudad" />
        <asp:BoundField HeaderText="Barrio" DataField="Domicilio.Barrio" />
        <asp:BoundField HeaderText="Domicilio" DataField="Domicilio.Direccion" />
        <asp:BoundField HeaderText="Dni" DataField="Cliente.Dni" />
        <asp:BoundField HeaderText="Telefono" DataField="Cliente.Telefono" />
        <asp:BoundField HeaderText="CantMegas" DataField="Plan.CantidadMegas" />    
        

    </Columns>
</asp:GridView>

        <asp:Button ID="Cancelar" runat="server" Text="Volver" type="button" class="btn btn-warning" OnClick="Cancelar_Click" />

    </div>
    

</asp:Content>
