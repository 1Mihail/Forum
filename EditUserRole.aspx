<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditUserRole.aspx.cs" Inherits="EditUserRole" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="container">
        <h1 id="userEmail" runat="server"></h1>
        <asp:SqlDataSource ID="RoleDS" runat="server" SelectCommand="select distinct Role from Users"></asp:SqlDataSource>
        <asp:DropDownList ID="RoleDD" runat="server" DataSourceID="RoleDS" DataTextField="Role" DataValueField="Role"></asp:DropDownList>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Actualizeaza" OnClick="EditareRol_Click" />
        <asp:Literal ID="EroareBazaDate" runat="server"></asp:Literal>
    </div>
</asp:Content>

