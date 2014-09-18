<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="SearchBox">
            <asp:Button CssClass="SearchBtn" ID="SearchBtn" runat="server" Text="Ok" OnClick="SearchBtn_OnClick" />
            <asp:TextBox CssClass="SearchBox" ID="SearchTbx" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="AdvSearchBtn" runat="server" Text="Søgefiltre" />
            <asp:Panel ID="AdvSearch" runat="server">
                <asp:CheckBoxList ID="SearchCbl" runat="server">
                    <asp:ListItem Value="Activity">Aktivitet</asp:ListItem>
                    <asp:ListItem Value="Instructor">Instruktør</asp:ListItem>
                </asp:CheckBoxList>
                <br />
                <asp:DropDownList ID="DayDdl" runat="server" DataSourceID="DaySqlDs" AppendDataBoundItems="True" DataTextField="Day" DataValueField="Id">
                    <asp:ListItem Value="0" Enabled="True">Alle dage</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource runat="server" ID="DaySqlDs" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT [Id], [Day] FROM [Weekdays]"></asp:SqlDataSource>
                <asp:DropDownList ID="TimeDdl" runat="server" DataSourceID="TimeSqlDs" AppendDataBoundItems="True" DataTextField="TimeOfDay" DataValueField="Id">
                    <asp:ListItem Value="0" Enabled="True">Alle tider</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource runat="server" ID="TimeSqlDs" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="SELECT [Id], [TimeOfDay] FROM [LessonTime]"></asp:SqlDataSource>
                <asp:Button ID="TestBtn" runat="server" Text="Test" OnClick="TestBtn_Click" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
