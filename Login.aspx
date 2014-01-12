<%@ Page Title="" Language="C#" MasterPageFile="~/landrupdans.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label ID="UserLoginLbl" runat="server" Text="Bruger login"></asp:Label>
    <br />
    <asp:TextBox ID="UserNameText" Placeholder="Brugernavn" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="PassWordText" Placeholder="Password" runat="server" TextMode="Password">Kodeord</asp:TextBox>
    <br />
    <asp:Button ID="LoginSubmitBtn" runat="server" Text="Log ind" OnClick="LoginSubmitBtn_Click" Style="height: 26px" /><asp:CheckBox ID="chkRememberMe" runat="server" Text="Husk mig" />
    <br />

    <asp:Panel ID="PanelMsgError" runat="server" Visible="False">
        <asp:Label ID="LoginErrorMsgText" runat="server" Text="Fejl.. du blev ikke logget ind"></asp:Label>
    </asp:Panel>

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

