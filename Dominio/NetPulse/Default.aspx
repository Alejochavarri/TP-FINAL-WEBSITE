<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NetPulse.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin:20px">
        <asp:GridView ID="dgvListaClientes" runat="server" CssClass="table table-bordered table-responsive  ">

        </asp:GridView>

    </div>
    

</asp:Content>
