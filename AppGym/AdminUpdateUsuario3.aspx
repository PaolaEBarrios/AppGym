<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminUpdateUsuario3.aspx.cs" Inherits="AppGym.AdminUpdateUsuario3" %>
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
        <h3>Eliminar Usuario</h3>
    </div>
    <div>
        <p>
            ¿Seguro desea eliminar a el usuario?
        </p>

        <p>UserId: </p>
        <asp:Label ID="lblIdUsuario" runat="server" Text=""></asp:Label>
        <p>Nombre de usuario: </p>
        <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
        <p>DNI: </p>
        <asp:Label ID="lblDni" runat="server" Text=""></asp:Label>
        <p>Tipo de Usuario: </p>
        <asp:Label ID="lbltipo" runat="server" Text="Tipo de Usuario" Enabled="false"></asp:Label>

        <asp:Button ID="btnConfirmar" runat="server" Text="Eliminar" OnClick="btnConfirmar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"/>
    </div>

</asp:Content>
