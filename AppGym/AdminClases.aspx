<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminClases.aspx.cs" Inherits="AppGym.AdminClases" %>
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
        <h3>Clases</h3>
    </div>

        <div class="body">


        <div class="card" >
          <div class="card-body">
            <h5 class="card-title">Clases solicitadas</h5>
            
            <p class="card-text">En esta opcion podra confirmar las clases solicitadas por los instructores o rechazarlas</p>
            <asp:Button ID="btnConfirmar" CssClass="btn btn-primary" runat="server" Text="Confirmar/rechazar" OnClick="btnConfirmar_Click"/>
          </div>
        </div>




    <div class="card">
      <div class="card-body">
        <h5 class="card-title">Clases en actividad</h5>
        <p class="card-text">Se podra ver las clases en ejecucion y en caso de necesitar eliminar se podra en esta pagina</p>
        <asp:Button ID="btnVerClases" CssClass="btn btn-primary" runat="server" Text="Ver clases" OnClick="btnVerClases_Click" />
      </div>
    </div>

    </div>


</asp:Content>
