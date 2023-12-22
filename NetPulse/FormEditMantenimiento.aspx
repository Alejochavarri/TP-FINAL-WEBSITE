<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="FormEditMantenimiento.aspx.cs" Inherits="NetPulse.FormEditMantenimiento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <asp:Label runat="server" Text="IdServicio"></asp:Label> 
    <asp:TextBox runat="server" CssClass="input-group-text"></asp:TextBox>

    <asp:Label runat="server" Text="Fecha"></asp:Label> 
    <asp:Calendar runat="server"></asp:Calendar>

     <asp:Label runat="server" Text="Tecnico a Cargo"></asp:Label> 
    <asp:TextBox runat="server" CssClass="input-group-text"></asp:TextBox>

     <asp:Label runat="server" Text="Descripcion"></asp:Label> 
    <asp:TextBox runat="server" CssClass="input-group-text"></asp:TextBox>

     <asp:Label runat="server" Text="TipoMantenimiento"></asp:Label> 
    <asp:TextBox runat="server" CssClass="input-group-text"></asp:TextBox>

     <asp:Label runat="server" Text="Comentario"></asp:Label> 
    <asp:TextBox runat="server" CssClass="input-group-text"></asp:TextBox>

     <asp:Label runat="server" Text="Estado"></asp:Label> 
    <asp:CheckBox runat="server"></asp:CheckBox>
    <div class="col-12">
    <asp:Button runat="server" Text="Guardar Cambios" />
        <asp:Button ID="Cancelar" runat="server" Text="Cancelar" type="button" class="btn btn-warning" OnClick="Cancelar_Click" />
    </div>

</asp:Content>
    

