<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminUpdateInstructor4.aspx.cs" Inherits="AppGym.AdminUpdateInstructor4" %>
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
      <p>Se elimino el instructor: </p>
  </div>
    <div>
        <asp:Label ID="lblMostrarId" runat="server" Text="Instructor Id: "></asp:Label>
        <asp:Label ID="lblId" runat="server" Text=""></asp:Label>

        <asp:Label ID="lblMostrarDni" runat="server" Text="DNI:  "></asp:Label>
        <asp:Label ID="lblDni" runat="server" Text=""></asp:Label>

        <asp:Label ID="lblMostrarNombre" runat="server" Text="Nombre: "></asp:Label>
        <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>

        <asp:Label ID="lblMostrarApellido" runat="server" Text="Apellido: "></asp:Label>
        <asp:Label ID="lblApellido" runat="server" Text=""></asp:Label>
        <asp:Button ID="btnInicio" runat="server" Text="Inicio" OnClick="btnInicio_Click" />

    </div>

    


</asp:Content>
