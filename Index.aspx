<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="IndexCategories" ContentPlaceHolderID="Content" runat="Server">
    <div id="container">
        <h1>Categorii</h1>
        <asp:SqlDataSource ID="CategoriesDataSource" runat="server" SelectCommand="select * from Categories"></asp:SqlDataSource>

        <asp:ListView ID="CategoriesListView" runat="server" DataSourceID="CategoriesDataSource">
            <LayoutTemplate>
                <table runat="server" id="table1">
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                    <tr id="Tr1" runat="server">
                        <td><a href="Forum.aspx?category=<%#Eval("Category") %>"><%#Eval("Category") %></a></td>
                        <td><%#Eval("Description") %></td>
                    </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>



