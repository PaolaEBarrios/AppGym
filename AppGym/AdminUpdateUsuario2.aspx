<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminUpdateUsuario2.aspx.cs" Inherits="AppGym.AdminUpdateUsuario2" %>
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
        <h3>Editar/Eliminar Usuarios</h3>
    </div>

    <div>
        <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" OnRowCommand="gvUsuarios_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="UserId" />
                <asp:BoundField DataField="DNI" HeaderText="DNI" />
                <asp:BoundField DataField="UserName" HeaderText="Username" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />

                <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Modificar"  />
                <asp:ButtonField ButtonType="Button" CommandName="Eliminar" Text="Eliminar" />
            </Columns>
        </asp:GridView>
    </div>
    

</asp:Content>
