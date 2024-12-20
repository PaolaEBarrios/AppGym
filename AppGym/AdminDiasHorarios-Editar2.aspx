<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="AdminDiasHorarios-Editar2.aspx.cs" Inherits="AppGym.AdminDiasHorarios_Editar2" %>
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
        <h3>Editar horario</h3>
    </div>


    <div>
 <div>
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>



    <div class="card" style="width: 18rem;">
      <div class="card-body">
            <div>
              

                
                <asp:Label ID="lblSeleccionDia" runat="server" Text="Dia: "></asp:Label>
                <asp:Label ID="lblDia" runat="server" Text=""></asp:Label>

            </div>
        
          <div>
              <div>
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
                    
              </div>

              <div>
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

          </div>
        
        
          <asp:Button ID="btnAddHora" CssClass="btn btn-primary" runat="server" Text="Modificar hora" OnClick="btnAddHora_Click"/>
      </div>
    </div> 

</div>

    <div>
           
        <asp:GridView ID="gvDiasHorarios" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Dia" HeaderText="Día" />
                    <asp:BoundField DataField="Hora" HeaderText="Horario" />
                    
                    
                </Columns>
        </asp:GridView>

    </div>


    <div>
        
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
    </div>

</asp:Content>
