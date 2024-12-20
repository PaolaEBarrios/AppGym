<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminRegistrarCliente.aspx.cs" Inherits="AppGym.AdminRegistrarCliente" %>
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

        <div class="form-reg">

            <div class="form-reg_content">

                <div class="form-reg_datos">
                    <asp:Label ID="lbldni" runat="server" CssClass="form-label" Text="DNI"></asp:Label>
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="DNI..."></asp:TextBox>
                    <asp:Label ID="lblNombre" runat="server" CssClass="form-label" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                    <asp:Label ID="lblApellido" runat="server" CssClass="form-label" Text="Apellido"></asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Apellido"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" CssClass="form-label" Text="Observacion"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Observaciones..."></asp:TextBox>

                </div>

            
            
                <div class="form-check">
                 <asp:Label ID="lblMembresia" runat="server" Text="Membresia"></asp:Label>
                        <asp:RadioButtonList ID="radiobtnPase" runat="server"> 
                        <asp:ListItem Text="Clases" Value="1"></asp:ListItem> 
                        <asp:ListItem Text="Mensual" Value="2"></asp:ListItem> 
                        <asp:ListItem Text="Otro" Value="3"></asp:ListItem> 

                </asp:RadioButtonList>
                </div>
            </div>


</div>
    <div class="acomodar-boton">
         <asp:Button ID="btnAddCliente" runat="server" CssClass="btn btn-primary" Text="Registrar" OnClick="btnAddCliente_Click"/>
    </div>
       
    
    <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>


</asp:Content>
