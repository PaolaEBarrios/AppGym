<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminPageUsuarios.aspx.cs" Inherits="AppGym.AdminPageUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    
    <style>
        
        .body-contenedor {
            display: flex;
            flex-wrap: wrap;
            justify-content: space-evenly; 
            padding: 20px;
        }

        /* Estilo para las tarjetas */
        .card {
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

        /* Busqueda y titulo */
        .header {
            text-align: center;
            margin: 20px 0;
        }

        .header h3 {
            font-size: 1.8em;
            color: #333;
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


<div class ="header"> 
        <asp:Label ID="lblFecha" runat="server" CssClass="text-muted"></asp:Label>

        <h3>Administrar Usuarios/Clientes</h3>
       <asp:TextBox ID="txtBuscarOpcion" CssClass="form-control" runat="server"></asp:TextBox>
       <asp:Button ID="btnBuscarOpcion" runat="server" CssClass="btn btn-primary" Text="Buscar" />
     </div>

<div class="body-contenedor">


                <div>
                    <div class="card" >
                      <div class="card-body">
                        <h5 class="card-title">Agregar Usuario</h5>
            
                        <p class="card-text">Crear usuario para ingresar al sistema con nombre user y contraseña</p>
                        <asp:Button ID="btnRegUsuario" CssClass="btn btn-primary" runat="server" Text="Registrar" OnClick="btnRegUsuario_Click" />
                      </div>
                    </div>

                </div>

                <div>
                <div class="card" >
                  <div class="card-body">
                    <h5 class="card-title">Agregar Cliente</h5>
                    <p class="card-text">Crear un cliente para poder incribirse a concurrir al gimnasio, tomar clases, etc.</p>
                    <asp:Button ID="btnRegCliente" CssClass="btn btn-primary" runat="server" Text="Registrar" OnClick="btnRegCliente_Click" />
                  </div>
                </div>

            </div>
                <div>
                <div class="card" >
                  <div class="card-body">
                    <h5 class="card-title">Modificar/Eliminar Usuario</h5>
                    <p class="card-text">Modificar o eliminar un Usuario</p>
                    <asp:Button ID="btnAdmiUsuario" CssClass="btn btn-primary" runat="server" Text="Administrar" OnClick="btnAdmiUsuario_Click" />
                  </div>
                </div>

            </div>
                <div>
                <div class="card" >
                  <div class="card-body">
                    <h5 class="card-title">Modificar/Eliminar Cliente</h5>
                    <p class="card-text">Modificar o eliminar un Cliente</p>
                    <asp:Button ID="btnAdmiCliente" CssClass="btn btn-primary" runat="server" Text="Administrar" OnClick="btnAdmiCliente_Click" />
                  </div>
                </div>

            </div>
    </div>


</asp:Content>
