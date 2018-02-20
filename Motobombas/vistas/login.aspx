<%@ Page Title="" Language="C#" MasterPageFile="~/vistas/MP/MaterPage.master" AutoEventWireup="true" CodeFile="~/controladores/login.aspx.cs" Inherits="Vista_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style23 {
        color: #FFFFFF;
        font-size: x-large;
    }
        .auto-style24 {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style12" style="height: 185px">
    <tr>
        <td class="auto-style23" colspan="3">Inicio Sesion</td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style24">
            <asp:Label ID="Label1" runat="server" style="color: #FFFFFF; text-align: right" Text="Usuario:"></asp:Label>
        </td>
        <td colspan="2" style="text-align: left">
            <asp:TextBox ID="TB_usuario" runat="server" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_usuario" ErrorMessage="*" ForeColor="White" ValidationGroup="v1"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="text-align: right" class="auto-style24">
            <asp:Label ID="Label2" runat="server" style="color: #FFFFFF" Text="Clave:"></asp:Label>
        </td>
        <td colspan="2" style="text-align: left">
            <asp:TextBox ID="TB_clave" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TB_clave" ErrorMessage="*" ForeColor="White" ValidationGroup="v1"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style24">
            <asp:Button ID="Button3" runat="server" BackColor="#003366" ForeColor="White" OnClick="Button3_Click" Text="Ovidastes tu contraseña?" />
        </td>
        <td>
            <asp:Button ID="B_iniciar" runat="server" OnClick="B_iniciar_Click" style="color: #FFFFFF; background-color: #003366" Text="Iniciar" ValidationGroup="v1" />
        </td>
        <td>
            <asp:Button ID="B_registrarse" runat="server" style="color: #FFFFFF; background-color: #003366" Text="Registrarse" OnClick="B_registrarse_Click" />
        </td>
    </tr>
</table>
</asp:Content>

