<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminDiasHorarios-Editar.aspx.cs" Inherits="AppGym.AdminDiasHorarios_Editar" %>
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
        <asp:Label ID="lblTitulo" runat="server" Text="Editar horario"></asp:Label>

    </div>
    <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
 <div>
           <div>
               <asp:Label ID="lblPregunta" runat="server" Text="¿Que dia desea editar?"></asp:Label>
           </div>
        <asp:GridView ID="gvDiasHorarios" runat="server" AutoGenerateColumns="False" OnRowCommand="gvDiasHorarios_RowCommand">
                <Columns>

                    <asp:BoundField DataField="Dia" HeaderText="Día" />
                    <asp:BoundField DataField="horaInicio" HeaderText="Inicio" />
                    <asp:BoundField DataField="horaFin" HeaderText="Fin" />

                    <asp:ButtonField ButtonType="Button" CommandName="Editar" Text="Modificar"  />
                   
                </Columns>
        </asp:GridView>

    </div>


    <div>
        
        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-primary" Text="Volver" OnClick="btnVolver_Click" />
    </div>




</asp:Content>
