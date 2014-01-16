<%@ Page Title="" Language="C#" MasterPageFile="~/landrupdans.Master" AutoEventWireup="true" CodeFile="TeamsByStyle.aspx.cs" Inherits="TeamsByStyle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <asp:GridView ID="GridViewTeamsByStyle" AllowSorting="true" OnSorting="GridViewTeamsByStyle_Sorting" runat="server"  AutoGenerateColumns="False">
        <Columns>

            <asp:BoundField DataField="TeamName" HeaderText="Holdnavn" SortExpression="TeamName"></asp:BoundField>
            <asp:BoundField DataField="Level" HeaderText="Niveau" SortExpression="Level"></asp:BoundField>
            <asp:BoundField DataField="StudentAge" HeaderText="Aldersgruppe" SortExpression="StudentAge"></asp:BoundField>
            <asp:TemplateField HeaderText="Instruktør" SortExpression="instructor">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("instructor")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Day" HeaderText="Dag" SortExpression="DayId"></asp:BoundField>
            <asp:BoundField DataField="TimeOfDay" HeaderText="Tid" SortExpression="TimeId"></asp:BoundField>

        </Columns>
    </asp:GridView>

</asp:Content>

