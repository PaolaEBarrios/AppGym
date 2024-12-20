<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminReactivar-Instructor.aspx.cs" Inherits="AppGym.AdminReactivar_Instructor" %>
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
        <h3>Reactivar Instructor</h3>
    </div>
    <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
        <div >
         <asp:GridView ID="gvInstructor" runat="server" AutoGenerateColumns="False" OnRowCommand="gvInstructor_RowCommand" >
             <Columns>
                 <asp:BoundField DataField="Id" HeaderText="InstructorId" />
                 <asp:BoundField DataField="DNI" HeaderText="DNI" />
                 <asp:BoundField DataField="Name" HeaderText="Nombre" />
                 <asp:BoundField DataField="Lastname" HeaderText="Apellido" />
                 <asp:BoundField DataField="State" HeaderText="Estado" />

                 <asp:ButtonField ButtonType="Button" CommandName="Activar" Text="Activar"  />

             </Columns>
          </asp:GridView>
  </div>

</asp:Content>
