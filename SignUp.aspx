<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<div id="container">
        <asp:Label runat="server">Nume: </asp:Label><br />
    <asp:TextBox ID="Nume" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Va rugam sa completati numele!" ControlToValidate="Nume"></asp:RequiredFieldValidator><br>

    <asp:Label runat="server">Prenume: </asp:Label><br />
    <asp:TextBox ID="Prenume" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Va rugam sa completati prenumele!" ControlToValidate="Prenume"></asp:RequiredFieldValidator><br>
    
    <asp:Label runat="server">Email: </asp:Label><br />
    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Mail invalid!" ControlToValidate="Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Va rugam sa completati emailul!" ControlToValidate="Email"></asp:RequiredFieldValidator><br>
    
    <asp:Label runat="server">Parola: </asp:Label><br />
    <asp:TextBox ID="Parola" runat="server" TextMode="Password"></asp:TextBox><br>
    <asp:Label runat="server">Confirmare parola: </asp:Label><br />
    <asp:TextBox ID="ConfirmareParola" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Va rugam sa completati parola!" ControlToValidate="Parola"></asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Parolele nu coincid!" ControlToCompare="Parola" ControlToValidate="ConfirmareParola"></asp:CompareValidator><br>
    
    <asp:Button ID="AdaugaUser" OnClick="AdaugareIntrare_Click" runat="server" Text="Trimite" />
    <asp:Literal ID="EroareBazaDate" runat="server"></asp:Literal>
</div>
</asp:Content>

