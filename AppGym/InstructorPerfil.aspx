<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="InstructorPerfil.aspx.cs" Inherits="AppGym.InstructorPerfil" %>
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

</asp:Content>
