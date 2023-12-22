<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Mantenimientos.aspx.cs" Inherits="NetPulse.Mantenimientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:20px">
        <asp:GridView ID="dgvListaMantenimientos" runat="server" CssClass="table table-bordered table-responsive " AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="IdMantenimiento" DataField="IdMantenimiento" />
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                <asp:BoundField HeaderText="TecnicoACargo" DataField="Tecnico.Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="TipoMantenimiento" DataField="TipoMantenimiento.Nombre" />
                <asp:BoundField HeaderText="Comentario" DataField="Comentarios" />
                <asp:CheckBoxField HeaderText="Estado" DataField="EstadoRealizacion" />
                <asp:ButtonField HeaderText="Modificar" ButtonType="Button" Text="Edit" />
                <asp:ButtonField HeaderText="Eliminar" ButtonType="Button" Text=" X " />
            </Columns>
        </asp:GridView>
        <asp:Button ID="ButtonAgregar" runat="server" Text=" + " OnClick="ButtonAgregar_Click" />
    </div>

</asp:Content>
