﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminUpdateInstructor2.aspx.cs" Inherits="AppGym.AdminUpdateInstructor2" %>
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
        <h3>Modificar/Eliminar Instructor</h3>
    </div>
    <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>

    <div>
        ¿Desea Eliminar/Modificar al Instructor? 
    </div>
        <div style="max-width: 400px; margin: auto;">
            <div style="margin-bottom: 10px;">
             <asp:Label ID="lblId" CssClass="form-label" runat="server" Text="ID INSTRUCTOR: "></asp:Label>

             </div>

        <div style="margin-bottom: 10px;">
            <asp:Label ID="lblDni" CssClass="form-label" runat="server" Text="DNI"></asp:Label>
            <asp:TextBox ID="txtDni" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div style="margin-bottom: 10px;">
            <asp:Label ID="lblNombre" CssClass="form-label" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div style="margin-bottom: 10px;">
            <asp:Label ID="lblApellido" CssClass="form-label"  runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    
    <div style="text-align: center; margin-top: 20px;">
        <asp:Button ID="btnModificar" CssClass="btn btn-primary" runat="server" Text="Modificar" OnClick="btnModificar_Click"/>
    </div>
    <div style="text-align: center; margin-top: 10px;">
        <asp:Label ID="lblEliminar" CssClass="form-label" runat="server" Text="Eliminar Instructor"></asp:Label>
        <asp:Button ID="btnEliminar" CssClass="btn btn-primary" runat="server" Text="Eliminar" OnClick="btnEliminar_Click"/>
    </div>
</asp:Content>
