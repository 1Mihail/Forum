<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Thread.aspx.cs" Inherits="Thread" %>

<asp:Content ID="ThreadContent" ContentPlaceHolderID="Content" runat="Server">
    <div id="container">
        <asp:Literal ID="EroareBazaDate" runat="server"></asp:Literal>
        <h1>
            <asp:Label ID="ThreadTitle" runat="server"></asp:Label></h1>
        <p>Creat de:
            <asp:Label ID="ThreadUser" runat="server"></asp:Label></p>
        <p>Postat in data de:
            <asp:Label ID="ThreadDate" runat="server"></asp:Label></p>
        <p>
            <asp:Label ID="ThreadContext" runat="server"></asp:Label></p>
        <a runat="server" id="EditThread">Editare</a>
        <a runat="server" id="DeleteThread">Stergere</a>
    </div>

    <asp:SqlDataSource ID="RepliesDataSource" runat="server"></asp:SqlDataSource>
    <asp:ListView ID="CategoriesListView" runat="server" DataSourceID="RepliesDataSource">
        <LayoutTemplate>
            <div runat="server" id="itemPlaceholder"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="replyContainer">
                <p>Postat in data de: <%#Eval("Date") %></p>
                <p>Creat de: <%#Eval("FirstName") %> <%#Eval("LastName") %></p>
                <p>
                    <%#Eval("Context") %>
                <p>
                    <a href="EditReply.aspx?id=<%#Eval("id") %>">Editare</a>
                    <a href="DeleteReply.aspx?id=<%#Eval("id") %>">Stergere</a>
            </div>
        </ItemTemplate>
    </asp:ListView>


    <div id="replyBox" runat="server">
        <div class="replyContainer">
            <asp:TextBox ID="Raspuns" runat="server" Height="161px" Width="1189px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="Raspunde_Click" Text="Raspunde" />
            <asp:Literal ID="Eroare" runat="server"></asp:Literal>
        </div>
    </div>


</asp:Content>

