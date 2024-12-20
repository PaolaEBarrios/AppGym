<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminSalones.aspx.cs" Inherits="AppGym.AdminSalones" %>
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
        <h3>Configurar salones</h3>
    </div>


<div>

   <div class="body">


        <div class="card" >
          <div class="card-body">
            <h5 class="card-title">Añadir salones</h5>
            
            <p class="card-text">Se agregan los espacios/salones que tendran disponibles los instructores para sus clases</p>
            <asp:Button ID="btnAgregar" CssClass="btn btn-primary" runat="server" Text="Agregar Salon" OnClick="btnAgregar_Click"/>
          </div>
        </div>

    


    <div class="card">
      <div class="card-body">
        <h5 class="card-title">Editar Salon</h5>
        <p class="card-text">Se podra editar o eliminar un salon</p>
        <asp:Button ID="btnEditarEliminar" CssClass="btn btn-primary" runat="server" Text="Editar/Eliminar Salon" OnClick="btnEditarEliminar_Click" />
      </div>
    </div>

    </div>

</div>



</asp:Content>
