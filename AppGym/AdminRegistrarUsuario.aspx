<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminRegistrarUsuario.aspx.cs" Inherits="AppGym.AdminRegistrarUsuario" %>
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

    <div class="header" style="padding-left:30px">
        <h3>Registrar Usuario</h3>
    </div>

    <div class="form-reg">
        <div class="form-reg_content">
            <div class="form-reg_datos">
                    <asp:Label ID="lbldni" CssClass="form-label" runat="server" Text="DNI"></asp:Label>
                    <asp:TextBox ID="txtDNI" CssClass="form-control" runat="server" placeholder="DNI..."></asp:TextBox>
                    <asp:Label ID="lblnameuser" CssClass="form-label" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" placeholder="Nombre de usuario..."></asp:TextBox>
                    <asp:Label ID="lblPass" CssClass="form-label" runat="server" Text="Contraseña"></asp:Label>
                    <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" placeholder="Contraseña..."></asp:TextBox>

                </div>

                <div class="form-check">
                    <asp:Label ID="lblTipoUser" CssClass="form-label" runat="server" Text="Tipo de usuario"></asp:Label>
                    <asp:RadioButtonList ID="radiobtnTipoUser" runat="server"> 
                        <asp:ListItem Text="Admin" Value="1"></asp:ListItem> 
                        <asp:ListItem Text="Cliente" Value="3"></asp:ListItem> 

                    </asp:RadioButtonList>
                </div>
        </div>     
    </div>
    <div class="acomodar-boton">
    <div class="boton">
        <asp:Button ID="btnAddUser" runat="server" CssClass="btn btn-primary" Text="Registrar" OnClick="btnAddUser_Click" />

    </div>
</div>

    
    <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
    

</asp:Content>
