<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="InstructorEliminarSolicitud.aspx.cs" Inherits="AppGym.InstructorEliminarSolicitud" %>
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
        <h3>Eliminar solicitud de clase</h3>
    </div>

    <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>

    <div>
        <asp:Label ID="lblPregunta" runat="server" Text="¿Desea eliminar esta solicitud permanentemente? "></asp:Label>
    </div>
    
    <div>
        <asp:Label ID="lblIdCartel" runat="server" Text="Id de la clase: "></asp:Label>
        <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblCartelNombre" runat="server" Text="Nombre de la clase: "></asp:Label>
        <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblCartelDia" runat="server" Text="Dia de la clase: "></asp:Label>
        <asp:Label ID="lblDia" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblCartelHoraInicio" runat="server" Text="Hora inicio: "></asp:Label>
        <asp:Label ID="lblHoraInicio" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblCartelHorafin" runat="server" Text="Hora fin: "></asp:Label>
        <asp:Label ID="lblHoraFin" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblCartelCapacidad" runat="server" Text="Capacidad: "></asp:Label>
        <asp:Label ID="lblCapacidad" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblCartelSalon" runat="server" Text="Salon: "></asp:Label>
        <asp:Label ID="lblSalon" runat="server" Text=""></asp:Label>

    </div>
    <div>
        <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-primary" Text="Eliminar solicitud" OnClick="btnEliminar_Click" />
        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-primary" Text="Volver " OnClick="btnVolver_Click" />
    </div>

</asp:Content>
