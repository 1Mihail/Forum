<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditReply.aspx.cs" Inherits="EditReply" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="container">
        <asp:TextBox ID="Raspuns" runat="server" Height="173px" Width="1098px"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Completati raspunsul!" ControlToValidate="Raspuns"></asp:RequiredFieldValidator>
        <asp:Literal ID="EroareBazaDate" runat="server"></asp:Literal>
        <asp:Button ID="Button1" OnClick="ActualizareRaspuns_Click" runat="server" Text="Actualizeaza Raspuns" />
    </div>
</asp:Content>

