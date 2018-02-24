<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Administrator.aspx.cs" Inherits="Administrator" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
<div id="container">
        <h1>Panou de administrare</h1>
    <h2>Categorii</h2>
    <asp:SqlDataSource ID="CategoriesDS" runat="server" SelectCommand="select * from Categories"></asp:SqlDataSource>
    <asp:ListView ID="CategoriesListView" runat="server" DataSourceID="CategoriesDS">
        <LayoutTemplate>
            <table runat="server" id="table1">
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr id="Tr1" runat="server">
                <td><%#Eval("Category") %></td>
                <td><%#Eval("Description") %></td>
                <td>
                    <a href="DeleteCategory.aspx?category=<%#Eval("Category") %>">Sterge</a>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <h3>Adauga categorie noua:</h3>
    <asp:Label ID="Label1" runat="server" Text="Nume:"></asp:Label>
    <asp:TextBox ID="NumeCategorie" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label2" runat="server" Text="Descriere:"></asp:Label>
    <asp:TextBox ID="DescriereCategorie" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" Text="Creeaza categorie" OnClick="CreeazaCategorie_Click" />
    <asp:Literal ID="EroareBazaDate" runat="server"></asp:Literal>
    <h2>Utilizatori</h2>
    <asp:SqlDataSource ID="UsersDS" runat="server" SelectCommand="select * from users"></asp:SqlDataSource>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="UsersDS">
        <LayoutTemplate>
            <table runat="server" id="table1">
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr id="Tr1" runat="server">
                <td><%#Eval("FirstName") %></td>
                <td><%#Eval("LastName") %></td>
                <td><%#Eval("Email") %></td>
                <td><%#Eval("Role") %></td>
                <td>
                    <a href="EditUserRole.aspx?id=<%#Eval("id") %>">Modifica rol</a>
                </td>
                <td>
                    <a href="DeleteUser.aspx?id=<%#Eval("id") %>">Sterge utilizator</a>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</div>
</asp:Content>

