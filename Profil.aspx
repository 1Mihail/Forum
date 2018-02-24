<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Profil.aspx.cs" Inherits="Profil" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
<div id="container">
        <h1>Profil</h1>
    <asp:Label ID="Label1" runat="server" Text="Nume"></asp:Label>
    <asp:TextBox ID="NumeUser" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nume incomplet!" ControlToValidate="NumeUser"></asp:RequiredFieldValidator><br />

    <asp:Label ID="Label2" runat="server" Text="Prenume"></asp:Label>
    <asp:TextBox ID="PrenumeUser" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Prenume incomplet!" ControlToValidate="PrenumeUser"></asp:RequiredFieldValidator><br />

    <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
    <asp:TextBox ID="EmailUser" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Mail invalid!" ControlToValidate="EmailUser" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Completati emailul!" ControlToValidate="EmailUser"></asp:RequiredFieldValidator><br />

    <asp:Label ID="Label4" runat="server" Text="Parola"></asp:Label>
    <asp:TextBox ID="ParolaUser" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Parola incompleta!" ControlToValidate="ParolaUser"></asp:RequiredFieldValidator><br />
    <asp:Literal ID="EroareBazaDate" runat="server"></asp:Literal><br />
    <asp:Button onclick="ActualizeazaProfil_Click" runat="server" Text="Actualizeaza Profil" />
</div>
</asp:Content>

