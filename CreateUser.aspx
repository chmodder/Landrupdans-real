<%@ Page Title="" Language="C#" MasterPageFile="~/landrupdans.Master" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


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
    <asp:RegularExpressionValidator ID="RegularExpressionEmail" runat="server" ErrorMessage="Det skal være en gyldig emailadresse!" ControlToValidate="CreateEmailText" ValidationExpression="^[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,5}$"></asp:RegularExpressionValidator>
    <asp:TextBox ID="CreateEmailText" Placeholder="Email" required="required" runat="server" TextMode="Email"></asp:TextBox>
    <br />

    <asp:RangeValidator ID="RangeValidatorBirthDay" runat="server" ControlToValidate="CreateBirthdayText" MinimumValue="1" MaximumValue="31" ErrorMessage="Du skal skrive et tal mellem 1 og 31"></asp:RangeValidator>
    <asp:TextBox ID="CreateBirthdayText" Placeholder="Fødselsdag" required="required" runat="server" TextMode="DateTime"></asp:TextBox>

    <asp:RangeValidator ID="RangeValidatorBirthMonth" runat="server" ControlToValidate="CreateBirthMonthText" MinimumValue="1" MaximumValue="12" ErrorMessage="Du skal skrive et tal mellem 1 og 12"></asp:RangeValidator>
    <asp:TextBox ID="CreateBirthMonthText" Placeholder="Fødselsmåned" required="required" runat="server" TextMode="DateTime"></asp:TextBox>

    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="CreateBirthYearText" ValidationExpression="^\[12][0-9]{3}$" ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>
    <asp:TextBox ID="CreateBirthYearText" Placeholder="Fødselsår" required="required" runat="server" TextMode="DateTime"></asp:TextBox>
    <br />
    <asp:Button ID="CreateUserBtn" runat="server" Text="Opret bruger" OnClick="CreateUserBtn_Click" />
    <br />
    <asp:Label ID="MsgLbl" runat="server" Text=""></asp:Label>
</asp:Content>

