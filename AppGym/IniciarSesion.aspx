<%@ Page Title="" Language="C#" MasterPageFile="~/MymasterPage.Master" AutoEventWireup="true" CodeBehind="IniciarSesion.aspx.cs" Inherits="AppGym.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .login-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-color: #333;
        }

        .login-box {
            background-color: #fff;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            text-align: center;
            width: 400px;
        }

        .login-box h1 {
            margin-bottom: 30px;
            font-size: 2.5rem;
            font-weight: bold;
        }

        .form-control {
            margin-bottom: 15px;
            padding: 10px;
            border-radius: 5px;
            background-color: #222;
            color: white;
        }

        .form-control::placeholder {
            color: #888;
        }

        .btn-custom {
            background-color: #ffc107;
            color: black;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .btn-custom:hover {
            background-color: #e0a800;
        }

        .profile-circle {
            width: 100px;
            height: 100px;
            background-color: #ddd;
            border-radius: 50%;
            margin: 0 auto 20px auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-container">
        <div class="login-box">
            
            <h1>APP GYM</h1>
            <asp:TextBox ID="txtBoxUser" CssClass="form-control" runat="server" placeholder="Nombre usuario o email"></asp:TextBox>
            <asp:TextBox ID="txtBoxPass" CssClass="form-control" runat="server" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
            <asp:Button ID="InicieSesion" CssClass="btn btn-custom" runat="server" Text="Iniciar sesión" OnClick="InicieSesion_Click" />
            <asp:Label ID="lblMensajeError" runat="server" CssClass="text-danger mt-2"></asp:Label>
        </div>
    </div>
</asp:Content>
