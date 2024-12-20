<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminSalones-Editar.aspx.cs" Inherits="AppGym.AdminSalones_Editar" %>
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
        <h3>Editar Nombre del salon</h3>
    </div>
    <div>
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <asp:Label ID="lblCartelID" runat="server" CssClass="form-label" Text="Salon Id: "></asp:Label>
        <asp:Label ID="lblIdSalon" CssClass="form-control" runat="server" Text=""></asp:Label>

        <asp:Label ID="lblNombre" runat="server" CssClass="form-label" Text="Nombre del salon: "></asp:Label>
        <asp:TextBox ID="txtNombreSalon" CssClass="form-control" runat="server"></asp:TextBox>

    </div>
    <div>
        <asp:Button ID="btnEditar" runat="server" CssClass="btn btn-primary" Text="Editar" OnClick="btnEditar_Click"/>
        <asp:Button ID="btnVolverAtras" CssClass="btn btn-primary" runat="server" Text="Volver atras"  OnClick="btnVolverAtras_Click"/>
    </div>
</asp:Content>
