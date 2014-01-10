<%@ Page Title="" Language="C#" MasterPageFile="~/landrupdans.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="UserLoginLbl" runat="server" Text="Bruger login"></asp:Label>
    <br />
    <asp:TextBox ID="UserNameText" runat="server">Brugernavn</asp:TextBox>
    <br />
    <asp:TextBox ID="PassWordText" runat="server">Kodeord</asp:TextBox>
    <br />
    <asp:Button ID="LoginSubmitBtn" runat="server" Text="Log ind" OnClick="LoginSubmitBtn_Click" style="height: 26px" />
    
    
    
    <%--<br />
    <asp:Label ID="Admin login" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox1" runat="server">Admin</asp:TextBox>
    <br />
    <asp:TextBox ID="TextBox2" runat="server">Kodeord</asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Log ind" />
    <br />--%>

</asp:Content>

