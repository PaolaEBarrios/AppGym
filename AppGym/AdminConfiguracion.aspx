<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminConfiguracion.aspx.cs" Inherits="AppGym.AdminConfiguracion" %>
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
        <h3>Configuraciones</h3>
    </div>
    <div>
        <asp:Button ID="btnCerrarSesion" runat="server" CssClass="btn btn-primary" Text="Cerrar Sesion" OnClick="btnCerrarSesion_Click" />
    </div>

    <div>

            <div class="body">


        <div class="card" >
          <div class="card-body">
            <h5 class="card-title">Agregar/Eliminar Salones</h5>
            
            <p class="card-text">Se agregan los espacios/salones que tendran disponibles los instructores para sus clases</p>
            <asp:Button ID="btnSalon" CssClass="btn btn-primary" runat="server" Text="Ir Salones" OnClick="btnSalon_Click" />
          </div>
        </div>

    


    <div class="card">
      <div class="card-body">
        <h5 class="card-title">Dias y horarios</h5>
        <p class="card-text">Se establecen los dias y horarios en los que el gimnasio estara disponible para clases</p>
        <asp:Button ID="btnDiaHorarios" CssClass="btn btn-primary" runat="server" Text="Ir a Dias Horarios" OnClick="btnDiaHorarios_Click" />
      </div>
    </div>

    </div>


     <div class="card">
      <div class="card-body">
        <h5 class="card-title">Cambiar/Restablecer contraseña</h5>
        <p class="card-text">Cambiar la contraseña o reestablecer la contraseña a la inicial</p>
        <asp:Button ID="btnContraseña" CssClass="btn btn-primary" runat="server" Text="Ir a configuracion" OnClick="btnContraseña_Click"  />
      </div>
    </div>

     <div class="card">
          <div class="card-body">
            <h5 class="card-title">Reactivar Clientes/Instructores/Usuarios</h5>
            <p class="card-text">Se podra reactivar un cliente/instructor o usuario que haya sido dado de baja</p>
            <asp:Button ID="btnReactivar" CssClass="btn btn-primary" runat="server" Text="Ir a la configuracion" OnClick="btnReactivar_Click" />
          </div>
    </div>

</div>


</asp:Content>
