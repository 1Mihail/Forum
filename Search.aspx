<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
<div id="container">
    <h1>Cauta</h1>
        <asp:TextBox runat="server" ID="Data"></asp:TextBox><br />
    <asp:Button ID="Button1" runat="server" OnClick="Search_Click" Width="20%" Style="float: left" Text="Cautare" />

    <br />
    <br />
    <br />
    <h4>Rezultate cautare</h4>
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
</div>
</asp:Content>

