<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminPageInstructores.aspx.cs" Inherits="AppGym.AdminPageInstructores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>

        .header{

        }

        .body{
            display: flex;
            
            justify-content: space-evenly; 
            padding: 20px;
        }

        .search{

        }

        .card{
            background-color: #EFD824;
            border: 1px solid #ddd; 
            border-radius: 10px; 
            width: 250px; 
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            overflow: hidden;
            transition: transform 0.3s ease; 
        }

                /* hover en las tarjetas */
        .card:hover {
            transform: translateY(-5px); /* Levanta la tarjeta cuando el cursor pasa por encima */
        }

        /* sub clases dentro de la card */
        .card-body {
            padding: 25px;
            text-align: center;
        }

        .card-title {
            font-size: 21px;
            margin-bottom: 10px;
        }

        .card-text {
            font-size: 15px;
            margin-bottom: 20px;
        }

    </style>

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


        <div class="header"> 
              <h3>Administrar Instructor</h3>
        </div>

            <div class="search">
            <asp:TextBox ID="txtBuscarOpcion" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscarOpcion" runat="server" CssClass="btn btn-primary" Text="Buscar" />

        </div>
        
    <div class="body">


        <div class="card" >
          <div class="card-body">
            <h5 class="card-title">Agregar Instructor</h5>
            
            <p class="card-text">Añade un instructor al sistema, el cual podra registrar clases, etc</p>
            <asp:Button ID="btnRegProfesor" CssClass="btn btn-primary" runat="server" Text="Registrar" OnClick="btnRegProfesor_Click" />
          </div>
        </div>




    <div class="card">
      <div class="card-body">
        <h5 class="card-title">Modificar/Eliminar Instructor</h5>
        <p class="card-text">Se modifican los datos del Instructor o se elimina un instructor</p>
        <asp:Button ID="btnModificar" CssClass="btn btn-primary" runat="server" Text="Modificar/Eliminar" OnClick="btnModificar_Click" />
      </div>
    </div>

    </div>
<div>

</div>


</asp:Content>
