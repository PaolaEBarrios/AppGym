<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminSalones-Agregar.aspx.cs" Inherits="AppGym.AdminSalones_Agregar" %>
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
        <h3>Crear/Agregar espacios o salones</h3>
    </div>

    <div>
        <asp:Label ID="lblNombreSalon" runat="server" CssClass="form-label" Text="Nombre del salon: "></asp:Label>
        <asp:TextBox ID="txtNombreDelSalon" CssClass="form-control" runat="server"></asp:TextBox>

    </div>

    <div>
        
        <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-primary" Text="Añadir salon"  OnClick="btnAgregar_Click"/>
        <asp:Button ID="btnVolverAtras" runat="server" CssClass="btn btn-primary" Text="Volver atras" OnClick="btnVolverAtras_Click"/>

    </div>
    <asp:Label ID="lblError" runat="server" CssClass="form-label" Text=""></asp:Label>

</asp:Content>
