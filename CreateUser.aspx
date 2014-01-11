<%@ Page Title="" Language="C#" MasterPageFile="~/landrupdans.Master" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <asp:Label ID="CreateUserLbl" runat="server" Text="Opret bruger"></asp:Label>
    <br />
    <asp:TextBox ID="CreateFirstNameText" Placeholder="Fornavn" required="required" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="CreateLastNameText" Placeholder="Efternavn" required="required" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="CreateUserNameText" Placeholder="Brugernavn" required="required" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="CreatePassWordText" Placeholder="Password" required="required" runat="server" TextMode="Password">Kodeord</asp:TextBox>
    <br />
    <asp:TextBox ID="CreateEmailText" Placeholder="Email" required="required" runat="server" TextMode="Email"></asp:TextBox>
    <br />
    <asp:TextBox ID="CreateBirthdayText" Placeholder="Fødselsdag" required="required" runat="server" TextMode="DateTime"></asp:TextBox>
    <br />
    <asp:Button ID="CreateUserBtn" runat="server" Text="Opret bruger" OnClick="CreateUserBtn_Click" />

</asp:Content>

