<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminRegistrarInstructor.aspx.cs" Inherits="AppGym.AdminRegistrarInstructor" %>
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

    .form-detalle{
        padding:10px;
        margin-top:10px;

        width:200px;
        
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

    <div class="header" style="padding-left:30px">
        <h3>Registrar Instructor</h3>
    </div>

    <div class="form-reg">
        <div class="form-reg_content">

        
                <div class="form-reg_datos">
                        <asp:Label ID="lblDNI" runat="server" CssClass="form-label" Text="DNI"></asp:Label>
                        <asp:TextBox ID="txtDNI" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:Label ID="lblNombre" CssClass="form-label" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:Label ID="lblApellido" CssClass="form-label" runat="server" Text="Apellido"></asp:Label>
                        <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

        
        
                <div class="form-detalle">
                    <asp:Label ID="lblDetalles" runat="server" Text="Detalles"></asp:Label>
                    <asp:TextBox ID="txtDetalle" CssClass="form-control" runat="server" style="height:20vh"></asp:TextBox>
                </div>
        
        </div>
    </div>
    

    <div class="acomodar-boton">
        <asp:Button ID="btnRegistrar" CssClass="btn btn-primary" runat="server" Text="Registrar" OnClick="btnRegistrar_Click"/>
    </div>
        
    
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>


</asp:Content>
