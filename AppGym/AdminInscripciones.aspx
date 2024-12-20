<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminInscripciones.aspx.cs" Inherits="AppGym.AdminInscripciones" %>
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
        <h3>Reservaciones</h3>
    </div>
    <div>
        <p>Se podra registrar un cliente a una clase, o mas. Eliminar un cliente a una clase, y modificar.</p>
    </div>
    <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>


    <div>
                <div class="body">


        <div class="card" >
          <div class="card-body">
            <h5 class="card-title">Inscribir cliente</h5>
            
            <p class="card-text">Inscribir un cliente activo a una clase activa</p>
            <asp:Button ID="btnIrInscripcion" CssClass="btn btn-primary" runat="server" Text="Ir a inscripcion" OnClick="btnIrInscripcion_Click"/>
          </div>
        </div>




    <div class="card">
      <div class="card-body">
        <h5 class="card-title">Eliminar inscripcion de cliente</h5>
        <p class="card-text">Se eliminar la inscripcion de un cliente a una clase</p>
        <asp:Button ID="btnEliminarInscripcion" CssClass="btn btn-primary" runat="server" Text="Eliminar inscripcion" OnClick="btnEliminarInscripcion_Click" />
      </div>
    </div>

    </div>

    </div>

</asp:Content>
