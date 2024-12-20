<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="InstructorEditarClases.aspx.cs" Inherits="AppGym.InstructorEditarClases" %>
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
        <h3>Editar clases enviadas para solicitud</h3>
    </div>

    <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>

    <div>
            <asp:GridView ID="gvClases" runat="server" AutoGenerateColumns="False" OnRowCommand="gvClases_RowCommand" >
             <Columns>

                 <asp:BoundField DataField="Id" HeaderText="Clase ID" />
                 <asp:BoundField DataField="Name" HeaderText="Nombre de la clase" />
                 <asp:BoundField DataField="InstructorId" HeaderText="Instructor ID" />
                 <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
                 <asp:BoundField DataField="Dia" HeaderText="Dia" />
                 <asp:BoundField DataField="HoraInicio" HeaderText="Hora Inicio"/>
                 <asp:BoundField DataField="HoraFin" HeaderText="Hora Fin" />
                 <asp:BoundField DataField="idSalon" HeaderText="Salon Id" />
                 <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Editar"/>
                 <asp:ButtonField ButtonType="Button" CommandName="Eliminar" Text="Eliminar"/>

             </Columns>
          </asp:GridView>
    </div>

</asp:Content>
