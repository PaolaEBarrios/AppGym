﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="InstructorEditarClases-clase.aspx.cs" Inherits="AppGym.InstructorEditarClases_clase" %>
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
        <asp:Label ID="lblTitulo" runat="server" Text="Editar la clase:  "></asp:Label>

    </div>


    <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

    </div>

    <div>
        <asp:Label ID="lblCartelId" runat="server" Text="ID de la clase: "></asp:Label>
        <asp:Label ID="lblId" runat="server" Text=""></asp:Label>

            <asp:Label ID="lblClase" runat="server" CssClass="form-label" Text="Nombre de la clase: "></asp:Label>
        <asp:TextBox ID="txtClase" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="lblCapacidad" runat="server" CssClass="form-label" Text="Capacidad: "></asp:Label>
        <asp:TextBox ID="txtCapacidad"  onkeydown="return (event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode == 8 || event.keyCode == 46"  CssClass="form-control" runat="server"  MaxLength="2"></asp:TextBox>




        <asp:Label ID="lblDias" runat="server" CssClass="form-label" Text="Dias "></asp:Label>
        <asp:DropDownList ID="ddlDias" runat="server">
            <asp:ListItem Text="Lunes" Value="Lunes"></asp:ListItem>
            <asp:ListItem Text="Martes" Value="Martes"></asp:ListItem>
            <asp:ListItem Text="Miércoles" Value="Miercoles"></asp:ListItem>
            <asp:ListItem Text="Jueves" Value="Jueves"></asp:ListItem>
            <asp:ListItem Text="Viernes" Value="Viernes"></asp:ListItem>
            <asp:ListItem Text="Sábado" Value="Sabado"></asp:ListItem>
            <asp:ListItem Text="Domingo" Value="Domingo"></asp:ListItem>
        </asp:DropDownList>



        <asp:Label ID="lblHorarioInicio" runat="server" CssClass="form-label" Text="Hora inicio: "></asp:Label>
        <asp:DropDownList ID="ddlHoras" runat="server">

            <asp:ListItem Text="05" Value="05" />
            <asp:ListItem Text="06" Value="06" />
            <asp:ListItem Text="07" Value="07" />
            <asp:ListItem Text="08" Value="08" />
            <asp:ListItem Text="09" Value="09" />
            <asp:ListItem Text="10" Value="10" />
            <asp:ListItem Text="11" Value="11" />
            <asp:ListItem Text="12" Value="12" />
            <asp:ListItem Text="13" Value="13" />
            <asp:ListItem Text="14" Value="14" />
            <asp:ListItem Text="15" Value="15" />
            <asp:ListItem Text="16" Value="16" />
            <asp:ListItem Text="17" Value="17" />
            <asp:ListItem Text="18" Value="18" />
            <asp:ListItem Text="19" Value="19" />
            <asp:ListItem Text="20" Value="20" />
            <asp:ListItem Text="21" Value="21" />
            <asp:ListItem Text="22" Value="22" />
            <asp:ListItem Text="23" Value="23" />

        </asp:DropDownList>

        <asp:DropDownList ID="ddlMinutos" runat="server">
            <asp:ListItem Text="00" Value="00" />
            <asp:ListItem Text="15" Value="15" />
            <asp:ListItem Text="30" Value="30" />
            <asp:ListItem Text="45" Value="45" />
        </asp:DropDownList>



        <asp:Label ID="lblHoraFin" runat="server" CssClass="form-label" Text="Hora fin: "></asp:Label>
        <asp:DropDownList ID="ddlHorasFin" runat="server">
            
            <asp:ListItem Text="05" Value="05" />
            <asp:ListItem Text="06" Value="06" />
            <asp:ListItem Text="07" Value="07" />
            <asp:ListItem Text="08" Value="08" />
            <asp:ListItem Text="09" Value="09" />
            <asp:ListItem Text="10" Value="10" />
            <asp:ListItem Text="11" Value="11" />
            <asp:ListItem Text="12" Value="12" />
            <asp:ListItem Text="13" Value="13" />
            <asp:ListItem Text="14" Value="14" />
            <asp:ListItem Text="15" Value="15" />
            <asp:ListItem Text="16" Value="16" />
            <asp:ListItem Text="17" Value="17" />
            <asp:ListItem Text="18" Value="18" />
            <asp:ListItem Text="19" Value="19" />
            <asp:ListItem Text="20" Value="20" />
            <asp:ListItem Text="21" Value="21" />
            <asp:ListItem Text="22" Value="22" />
            <asp:ListItem Text="23" Value="23" />

        </asp:DropDownList>

        <asp:DropDownList ID="ddlMinutosFin" runat="server">
            <asp:ListItem Text="00" Value="00" />
            <asp:ListItem Text="15" Value="15" />
            <asp:ListItem Text="30" Value="30" />
            <asp:ListItem Text="45" Value="45" />
        </asp:DropDownList>

    </div>
    <div>
        <asp:Label ID="lblSalon" runat="server" Text="Elige el salon: "></asp:Label>
        <asp:DropDownList ID="ddlSalones" runat="server" >
        </asp:DropDownList>

    </div>

    <div>

        <asp:Button ID="btnEditar" runat="server" Text="Editar y enviar" CssClass="btn btn-primary" OnClick="btnEditar_Click" />
        <asp:Button ID="btnVolver" CssClass="btn btn-primary" runat="server" Text="Volver" OnClick="btnVolver_Click" />
    
    </div>

</asp:Content>