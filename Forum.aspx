<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Forum.aspx.cs" Inherits="Forum" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="container">
        <h1>Subiecte: </h1>
        <asp:SqlDataSource ID="PostsDataSource" runat="server"></asp:SqlDataSource>

        <h3 id="newTopic">
            <asp:LinkButton ID="DiscutieNoua" OnClick="DiscutieNoua_Click" runat="server">Discutie noua</asp:LinkButton></h3>

        <asp:ListView ID="PostsListView" runat="server" DataSourceID="PostsDataSource">
            <LayoutTemplate>
                <table runat="server" id="table1">
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr id="Tr1" runat="server">
                    <td><a href="Thread.aspx?id=<%#Eval("Id") %>"><%#Eval("Title") %></a></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <asp:Button ID="Button1" OnClick="SortareAsc" runat="server" Text="Asc" />
        <asp:Button ID="Button2" OnClick="SortareDesc" runat="server" Text="Desc" />
    </div>
</asp:Content>

