<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewThread.aspx.cs" Inherits="NewThread" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
<div id="container">
        <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
    <asp:TextBox ID="ThreadTitle" runat="server" Width="457px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Completati titlul!" ControlToValidate="ThreadTitle"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:TextBox ID="ThreadContext" runat="server" Height="304px" Width="1341px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Completati continutul!" ControlToValidate="ThreadContext"></asp:RequiredFieldValidator>
    <asp:Button ID="Button1" runat="server" Text="Trimite" OnClick="TrimiteThread_Click" />
    <asp:Literal ID="EroareBazaDate" runat="server"></asp:Literal>
</div>
</asp:Content>

