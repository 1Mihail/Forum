<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditThread.aspx.cs" Inherits="EditThread" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
<div id="container">
        <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
    <asp:TextBox ID="ThreadTitle" runat="server" Width="457px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Completati titlul!" ControlToValidate="ThreadTitle"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:TextBox ID="ThreadContext" runat="server" Height="304px" Width="1341px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Completati continutul!" ControlToValidate="ThreadContext"></asp:RequiredFieldValidator>
    
    <asp:SqlDataSource ID="CategoriesDS" runat="server" SelectCommand="select Category from Categories"></asp:SqlDataSource>
    <asp:DropDownList ID="CategoriesDD" runat="server" DataSourceID="CategoriesDS" DataTextField="Category" DataValueField="Category"></asp:DropDownList>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Actualizeaza" OnClick="Editare_Click" />
    <asp:Literal ID="EroareBazaDate" runat="server"></asp:Literal>
</div>
</asp:Content>

