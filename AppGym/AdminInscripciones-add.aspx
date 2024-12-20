<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminInscripciones-add.aspx.cs" Inherits="AppGym.AdminInscripciones_add" %>
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
        <asp:Label ID="lblTitulo" runat="server" Text="Inscripcion a clase"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <div>
            <asp:Label ID="lblDni" runat="server" Text="Dni: "></asp:Label>
            <asp:TextBox ID="txtDni" runat="server"></asp:TextBox>
            <asp:Label ID="lblDniExtraido" runat="server" Text=""></asp:Label>
        </div>

        <asp:Label ID="lblCartelNombre" runat="server" Text="Nombre cliente: "></asp:Label>
        <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblCartelApellido" runat="server" Text="Apellido cliente: "></asp:Label>
        <asp:Label ID="lblApellido" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblCartelEstado" runat="server" Text="Estado del cliente: "></asp:Label>
        <asp:Label ID="lblEstado" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Button ID="btnBuscarCliente" CssClass="btn btn-primary" runat="server" Text="Buscar Cliente y buscar clases disponibles" OnClick="btnBuscarCliente_Click" />
    </div>
    <div>
        <asp:GridView ID="gvClasesDisponibles" runat="server" AutoGenerateColumns="false" OnRowCommand="gvClasesDisponibles_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID Clase" />
                <asp:BoundField DataField="Name" HeaderText="Nombre Clase" />
                <asp:BoundField DataField="Dia" HeaderText="Día" />
                <asp:BoundField DataField="HoraInicio" HeaderText="Inicio" />
                <asp:BoundField DataField="HoraFin" HeaderText="Fin" />
                <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
                <asp:BoundField DataField="Inscriptos" HeaderText="Inscritos" />
                <asp:ButtonField Text="Inscribir" CommandName="Inscribir" ButtonType="Button" />
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>
