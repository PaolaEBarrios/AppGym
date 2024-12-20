<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminUpdateCliente4.aspx.cs" Inherits="AppGym.AdminUpdateCliente4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <style>

    .header{

    }

    .form-reg {
        display: flex;
        align-items:center;
        justify-content:center;
        margin:0px;
        padding-top:20px;
        height:50vh;

    }

    .form-reg_content{
        display:flex;
        background-color:#EFD824;
        padding:50px;
        border-radius:15px;
        border:3px solid black
    }

    .form-reg_datos{
        
    }

    .form-check{
        margin-top:30px;
        
    }

    .acomodar-boton{
        display:flex;
        align-items:center;
        justify-content:center;
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

    <div>
        <h3>Eliminar cliente</h3>
    </div>

    <div>
        <p>Se elimino el cliente : </p>
        <asp:Label ID="lblId" runat="server" Text="Cliente ID: "></asp:Label>
        <asp:Label ID="lblContentId" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblDni" runat="server" Text="DNI: "></asp:Label>
        <asp:Label ID="lblContentDni" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblNombre" runat="server" Text="Nombre: " ></asp:Label>
        <asp:Label ID="lblContentNombre" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblApellido" runat="server" Text="Apellido: "></asp:Label>
        <asp:Label ID="lblContentApellido" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="btnInicio" runat="server" Text="Inicio" OnClick="btnInicio_Click" />
    </div>

    <asp:Label  ID="lblError" Text="" runat="server" />


</asp:Content>
