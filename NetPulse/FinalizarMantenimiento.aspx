<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTecnico.Master" AutoEventWireup="true" CodeBehind="FinalizarMantenimiento.aspx.cs" Inherits="NetPulse.FinalizarMantenimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 20px">
        <h3>Finalizar Mantenimiento</h3>
    </div>
    <div style="margin:20px">
        <div class="mb-3">
            <label for="InputComentarios" class="form-label">Comentarios... (Opcional)</label>
            <asp:TextBox type="text" class="form-control" id="TextComentarios" runat="server" MaxLength="255"></asp:TextBox>                   
        </div>
        <div class="col-12">
        <asp:Button type="submit" class="btn btn-primary" ID="btnFinalizar" runat="server" Text="Registrar Visita" OnClick="btnFinalizar_Click" />
        <asp:Button ID="Cancelar" runat="server" Text="Cancelar" type="button" class="btn btn-warning" OnClick="Cancelar_Click" />
        </div>

    </div>
</asp:Content>

