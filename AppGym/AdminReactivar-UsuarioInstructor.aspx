<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminReactivar-UsuarioInstructor.aspx.cs" Inherits="AppGym.AdminReactivar_UsuarioInstructor" %>
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
        <h3>Reactivar Usuario/Instructor o Cliente</h3>
    </div>

    <div>

      <div class="body">


        <div class="card" >
          <div class="card-body">
            <h5 class="card-title">Reactivar Instructor</h5>
            
            <p class="card-text">Se podra reactivar a un instructor dado de baja</p>
            <asp:Button ID="btnReactivarInstructor" CssClass="btn btn-primary" runat="server" Text="Ir a reactivar" OnClick="btnReactivarInstructor_Click" />
          </div>
        </div>

    


    <div class="card">
      <div class="card-body">
        <h5 class="card-title">Reactivar Usuario</h5>
        <p class="card-text">Se podra reactivar algun cliente que haya sido dado de baja</p>
        <asp:Button ID="btnReactivarUser" CssClass="btn btn-primary" runat="server" Text="Ir a reactivar" OnClick="btnReactivarUser_Click"/>
      </div>
    </div>

    </div>


    
    

</div>

</asp:Content>
