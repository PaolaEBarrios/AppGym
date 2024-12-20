<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="InstructorConfiguracion.aspx.cs" Inherits="AppGym.InstructorConfiguracion" %>
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
        <h3>Cambiar contraseña</h3>
    </div>
    <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>

    <div>

        <asp:Label ID="lblContraseñaActual" runat="server" Text="Contraseña actual: "></asp:Label>
        <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
        <asp:Label ID="lblContraseñanueva" runat="server" Text="Contraseña Nueva: "></asp:Label>
        <asp:TextBox ID="txtPassNueva" runat="server"></asp:TextBox>
        <asp:Label ID="lblRepetirNueva" runat="server" Text="Reperir contraseña nueva: "></asp:Label>
        <asp:TextBox ID="txtPassNueva2" runat="server"></asp:TextBox>

    </div>

    <div>
        <asp:Button ID="btnCambiar" CssClass="btn btn-primary" runat="server" Text="Confirmar nuevo" OnClick="btnCambiar_Click" />
    </div>
</asp:Content>
