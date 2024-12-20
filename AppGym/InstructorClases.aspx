<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="InstructorClases.aspx.cs" Inherits="AppGym.InstructorClases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                     <nav class="navbar navbar-expand-lg bg-body-tertiary">
                      <div class="container-fluid">
                        <a class="navbar-brand" href="InstructorPageInicio.aspx">APP GYM</a>
                        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
                          <span class="navbar-toggler-icon"></span>
                        </button>
                        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
                          <div class="navbar-nav">
                            <a class="nav-link active" aria-current="page" href="InstructorClases.aspx">Clases</a>
                            <a class="nav-link" aria-current="page" href="InstructorPerfil.aspx">Perfil</a>
                            <a class="nav-link" href="InstructorConfiguracion.aspx">Configuracion</a>

                          </div>
                        </div>
                      </div>
                </nav>

        <div>
            <asp:Label ID="lblFechaInicio" runat="server" CssClass="text-muted"></asp:Label>
        </div>

        <div>
            <h3>Administrar Clases</h3>
        </div>

        <div class="body-contenedor">


                <div>
                    <div class="card" >
                      <div class="card-body">
                        <h5 class="card-title">Crear clase</h5>
            
                        <p class="card-text">Crea una clase para ser enviada como solicitud al administrador</p>
                        <asp:Button ID="btnCrear" CssClass="btn btn-primary" runat="server" Text="Crear" OnClick="btnCrear_Click" />
                      </div>
                    </div>

                </div>

                <div>
                <div class="card" >
                  <div class="card-body">
                    <h5 class="card-title">Mis Clases</h5>
                    <p class="card-text">Se visualizan las clases confirmadas y en curso propias</p>
                    <asp:Button ID="btnMisClases" CssClass="btn btn-primary" runat="server" Text="Visualizar" OnClick="btnMisClases_Click" />
                  </div>
                </div>

            </div>
                <div>
                <div class="card" >
                  <div class="card-body">
                    <h5 class="card-title">Editar Clases</h5>
                    <p class="card-text">Editar las clases que no fueron aprobadas o que no fueron enviadas</p>
                    <asp:Button ID="btnEditar" CssClass="btn btn-primary" runat="server" Text="Editar" OnClick="btnEditar_Click" />
                  </div>
                </div>

            </div>
              
    </div>


</asp:Content>
