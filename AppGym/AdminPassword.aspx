<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminPassword.aspx.cs" Inherits="AppGym.AdminPassword" %>
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
        <asp:Label ID="lblTitulo" runat="server" Text="Cambiar contraseña"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblPass" runat="server" Text="Contraseña actual: "></asp:Label>
        <asp:TextBox ID="txtPass" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="lblPassNueva" runat="server" Text="Contraseña nueva: "></asp:Label>
        <asp:TextBox ID="txtPassNueva" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="lblPassNueva2" runat="server" Text="Repita contraseña nueva: "></asp:Label>
        <asp:TextBox ID="txtPassNueva2" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnCambiarPass" runat="server" CssClass="btn btn-primary" Text="Aceptar cambio" OnClick="btnCambiarPass_Click" />
    </div>


    <div>
        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-primary" Text="Volver" OnClick="btnVolver_Click"/>
        <asp:Label ID="lblReestablecer" runat="server" Text="Reestablecer a primer contraseña"></asp:Label>
        <asp:Button ID="btnReestablecer" runat="server" CssClass="btn btn-primary" Text="Reestablecer" OnClick="btnReestablecer_Click" />
    </div>
    
</asp:Content>
