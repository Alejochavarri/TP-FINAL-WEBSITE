<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AgregarDomicilio.aspx.cs" Inherits="NetPulse.AgregarDomicilio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="display-5" style="text-align: left; margin: 20px">Nuevo Domicilio </h1>
    <div class="row g-3" style="margin: 50px">
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
            <asp:TextBox type="text" class="form-control" ID="inputComentarios" placeholder="Comentarios..." runat="server"></asp:TextBox>
        </div>
       
        
        <div class="col-12">
            <asp:Button ID="btnAgregarDomicilio" runat="server" Text="Agregar" type="submit" class="btn btn-primary"  />
        </div>
    </div>
</asp:Content>
