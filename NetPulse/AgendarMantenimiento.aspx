<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AgendarMantenimiento.aspx.cs" Inherits="NetPulse.AgendarMantenimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-5" style="text-align: left; margin: 10px">Datos Mantenimiento </h1>
    
    <h3 class="display-5" style="text-align: left; margin: 10px">Tecnico a cargo</h3>
    <div class="row g-3" style="margin: 20px">
        <div class="col-12">
            <asp:DropDownList ID="DDLTecnicos" runat="server" class="form-control" AutoPostBack="true"></asp:DropDownList>
        </div>

    </div>
    <h3 class="display-5" style="text-align: left; margin: 10px">Tipo de mantenimiento</h3>
    <div class="row g-3" style="margin: 20px">
        <div class="col-12">
            <asp:DropDownList ID="DDLTipoMantenimiento" runat="server" class="form-control" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>
    
    <div class="row g-3" style="margin: 20px">
        <asp:TextBox type="text" class="form-control" ID="inputDescripcionMantenimiento" placeholder="Descripcion del mantenimiento a realizar" runat="server"></asp:TextBox>
    </div>
    <div class="col-12">
    <asp:Button  ID="btnAgendarMantenimiento" runat="server" Text="Agendar" type="submit" class="btn btn-primary" OnClick="btnAgendarMantenimiento_Click" />
        <asp:Button ID="Cancelar" runat="server" Text="Cancelar" type="button" class="btn btn-warning" OnClick="Cancelar_Click" />

    </div>
</asp:Content>
