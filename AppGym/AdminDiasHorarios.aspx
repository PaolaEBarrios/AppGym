<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminDiasHorarios.aspx.cs" Inherits="AppGym.AdminDiasHorarios" %>
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
        <h3>Dias y horarios</h3>
    </div>
    <div>

            <div class="body">


        <div class="card" >
          <div class="card-body">
            <h5 class="card-title">Agregar Dias y horarios</h5>
            
            <p class="card-text">Se agregan los dias y horarios en los que el gimnasio estara disponible</p>
            <asp:Button ID="btnAgregar" CssClass="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
          </div>
        </div>

    


    <div class="card">
      <div class="card-body">
        <h5 class="card-title">Editar Dias y horarios</h5>
        <p class="card-text">Editar los dias y horarios en los que el gimnasio estara disponible</p>
        <asp:Button ID="btnEditar" CssClass="btn btn-primary" runat="server" Text="Editar" OnClick="btnEditar_Click" />
      </div>
    </div>

    </div>

</div>

</asp:Content>
