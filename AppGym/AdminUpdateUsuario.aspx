<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminUpdateUsuario.aspx.cs" Inherits="AppGym.AdminUpdateUsuario" %>
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
        <h3>Modificar/Eliminar Usuario</h3>

    </div>
    <div>
        <div>
            <div>
                <asp:Label ID="lblUserId" runat="server" Text="UserId: "></asp:Label>
                <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
            </div>
            
            <asp:Label ID="lblDni" runat="server" Text="DNI"></asp:Label>
            <asp:TextBox ID="txtdni" runat="server"></asp:TextBox>
            <asp:Label ID="lblUsername" runat="server" Text="Nombre de Usuario"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <asp:Label ID="lblPass" runat="server" Text="Contraseña"></asp:Label>
            <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblTipoUser" runat="server" Text="Tipo de usuario"></asp:Label>
                <asp:RadioButtonList ID="radiobtnTipoUser" runat="server" Enabled="false"> 
                <asp:ListItem Text="Admin" Value="1"></asp:ListItem> 
                <asp:ListItem Text="Cliente" Value="3"></asp:ListItem> 
                <asp:ListItem Text="Instructor" Value="2"></asp:ListItem> 

            </asp:RadioButtonList>
        </div>
        <div>
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Usuario" OnClick="btnEliminar_Click" />
        </div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            
        <div>

        </div>

    </div>


    

</asp:Content>
