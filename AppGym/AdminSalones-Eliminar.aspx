<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminSalones-Eliminar.aspx.cs" Inherits="AppGym.AdminSalones_Eliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                         <nav class="navbar navbar-expand-lg bg-body-tertiary">
                      <div class="container-fluid">
                        <a class="navbar-brand" href="#">APP GYM</a>
                        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                          <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                          <div class="navbar-nav">
                            <a class="nav-link active" aria-current="page" href="AdminPageUsuarios.aspx">Usuarios/Clientes</a>
                            <a class="nav-link" aria-current="page" href="AdminPageInstructores.aspx">Instructores</a>
                            <a class="nav-link" href="AdminClases.aspx">Clases</a>
                            <a class="nav-link" href="AdminInscripciones.aspx">Inscripciones</a>
                            <a class="nav-link" href="AdminConfiguracion.aspx">Configuracion</a>
                          </div>
                        </div>
                      </div>
        </nav>


    <div>
        <h3>Eliminar salon</h3>
    </div>
    <div>
        <asp:Label ID="lblError" CssClass="form label" runat="server" Text=""></asp:Label>

    </div>
    <div>
        <asp:Label ID="lblPregunta" runat="server" Text="¿Desea eliminar permanentemente el salon?"></asp:Label>
    </div>
    <div>

        <asp:Label ID="lblCartelId" runat="server" CssClass="form label" Text="ID del Salon: "></asp:Label>
        <asp:Label ID="lblId" runat="server" CssClass="form label" Text=""></asp:Label>
        <asp:Label ID="lblCartelNombre" runat="server"  CssClass="form label" Text="Nombre del salon: "></asp:Label>
        <asp:Label ID="lblNombre" CssClass="form label" runat="server" Text=""></asp:Label>
        
    </div>
    <div>
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />

    </div>

</asp:Content>
