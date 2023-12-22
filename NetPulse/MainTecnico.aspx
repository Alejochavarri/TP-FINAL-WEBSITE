<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTecnico.Master" AutoEventWireup="true" CodeBehind="MainTecnico.aspx.cs" Inherits="NetPulse.MainTecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="margin: 20px;">

        <h3>Instalaciones Pendientes</h3>

        <asp:GridView ID="dgvPendienteInstalacion" DataKeyNames="IdServicio" runat="server" CssClass="table table-bordered table-responsive table-warning " AutoGenerateColumns="false" OnRowCommand="dgvPendienteInstalacion_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="IdMantenimiento" DataField="IdMantenimiento" />
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                <asp:BoundField HeaderText="TecnicoACargo" DataField="Tecnico.Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="TipoMantenimiento" DataField="TipoMantenimiento.Nombre" />
                <asp:BoundField HeaderText="Comentario" DataField="Comentarios" />
                <asp:CheckBoxField HeaderText="Estado" DataField="EstadoRealizacion" />

                <asp:ButtonField HeaderText="Info Del Usuario" Text='Ver <i class="fa-solid fa-bars"></i>' ButtonType="Link" CommandName="Info_onClick" ControlStyle-CssClass="btn btn-secondary" />
                <asp:ButtonField HeaderText="Finalizar Mantenimiento" Text='Finalizar <i class="fa-solid fa-check"></i>' ButtonType="Link" CommandName="Finalizar_onClick" ControlStyle-CssClass="btn btn-primary" />
            </Columns>
        </asp:GridView>
    </div>



    <div style="margin: 20px;">
        <h3>Mantenimientos Pendientes</h3>


        <asp:GridView ID="dgvPrioridadAlta" DataKeyNames="IdServicio" runat="server" CssClass="table table-bordered table-responsive table-danger " AutoGenerateColumns="false" OnRowCommand="dgvListaMantenimientosPendientes_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="IdMantenimiento" DataField="IdMantenimiento" />
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                <asp:BoundField HeaderText="TecnicoACargo" DataField="Tecnico.Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="TipoMantenimiento" DataField="TipoMantenimiento.Nombre" />
                <asp:BoundField HeaderText="Comentario" DataField="Comentarios" />
                <asp:CheckBoxField HeaderText="Estado" DataField="EstadoRealizacion" />

                <asp:ButtonField HeaderText="Info Del Usuario" Text='Ver <i class="fa-solid fa-bars"></i>' ButtonType="Link" CommandName="Info_onClick" ControlStyle-CssClass="btn btn-secondary" />
                <asp:ButtonField HeaderText="Finalizar Mantenimiento" Text='Finalizar <i class="fa-solid fa-check"></i>' ButtonType="Link" CommandName="Finalizar_onClick" ControlStyle-CssClass="btn btn-primary" />
            </Columns>
        </asp:GridView>
    </div>


    <div style="margin:20px;">
        <asp:GridView ID="dgvPrioridadBaja" DataKeyNames="IdServicio" runat="server" CssClass="table table-bordered table-responsive table-primary  " AutoGenerateColumns="false" OnRowCommand="dgvPrioridadBaja_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="IdMantenimiento" DataField="IdMantenimiento" />
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                <asp:BoundField HeaderText="TecnicoACargo" DataField="Tecnico.Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="TipoMantenimiento" DataField="TipoMantenimiento.Nombre" />
                <asp:BoundField HeaderText="Comentario" DataField="Comentarios" />
                <asp:CheckBoxField HeaderText="Estado" DataField="EstadoRealizacion" />

                <asp:ButtonField HeaderText="Info Del Usuario" Text='Ver <i class="fa-solid fa-bars"></i>' ButtonType="Link" CommandName="Info_onClick" ControlStyle-CssClass="btn btn-secondary" />
                <asp:ButtonField HeaderText="Finalizar Mantenimiento" Text='Finalizar <i class="fa-solid fa-check"></i>' ButtonType="Link" CommandName="Finalizar_onClick" ControlStyle-CssClass="btn btn-primary" />
            </Columns>
        </asp:GridView>
    </div>


    <div style="margin: 20px;">
        <h3>Desinstalaciones Pendientes</h3>
        <asp:GridView ID="dgvDesinstalacionesPendientes" DataKeyNames="IdServicio" runat="server" CssClass="table table-bordered table-responsive table-primary  " AutoGenerateColumns="false" OnRowCommand="dgvDesinstalacionesPendientes_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="IdMantenimiento" DataField="IdMantenimiento" />
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                <asp:BoundField HeaderText="TecnicoACargo" DataField="Tecnico.Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="TipoMantenimiento" DataField="TipoMantenimiento.Nombre" />
                <asp:BoundField HeaderText="Comentario" DataField="Comentarios" />
                <asp:CheckBoxField HeaderText="Estado" DataField="EstadoRealizacion" />

                <asp:ButtonField HeaderText="Info Del Usuario" Text='Ver <i class="fa-solid fa-bars"></i>' ButtonType="Link" CommandName="Info_onClick" ControlStyle-CssClass="btn btn-secondary" />
                <asp:ButtonField HeaderText="Finalizar Mantenimiento" Text='Finalizar <i class="fa-solid fa-check"></i>' ButtonType="Link" CommandName="Finalizar_onClick" ControlStyle-CssClass="btn btn-primary" />
            </Columns>
        </asp:GridView>
    </div>

    <hr>


    <div style="margin: 20px;">
        <h3>Mantenimientos Realizados</h3>
        <asp:GridView ID="dgvListaMantenimientosRealizados" runat="server" CssClass="table table-bordered table-responsive table-success " AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="IdMantenimiento" DataField="IdMantenimiento" />
                <asp:BoundField HeaderText="IdServicio" DataField="IdServicio" />
                <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                <asp:BoundField HeaderText="FechaRealizado" DataField="FechaRealizado" />
                <asp:BoundField HeaderText="TecnicoACargo" DataField="Tecnico.Nombre" />
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="TipoMantenimiento" DataField="TipoMantenimiento.Nombre" />
                <asp:BoundField HeaderText="Comentario" DataField="Comentarios" />
                <asp:CheckBoxField HeaderText="Estado" DataField="EstadoRealizacion" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
