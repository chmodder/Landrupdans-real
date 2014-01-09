<%@ Page Title="" Language="C#" MasterPageFile="~/landrupdans.Master" AutoEventWireup="true" CodeFile="Styles.aspx.cs" Inherits="Styles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:SqlDataSource runat="server" ID="SqlDataSourceStyles" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="

        SELECT 
            Styles.Id AS Id,
            Styles.StyleName AS Stilart, 
	        Styles.Description AS Beskrivelse, 
	        Styles.ImageName AS Billede, 
	        Instructors.FirstName AS FirstName, 
	        Instructors.LastName AS LastName
        FROM Styles 
        LEFT JOIN InstructorStyles ON Styles.Id = InstructorStyles.FkStyleId 
        LEFT JOIN Instructors ON Instructors.Id = InstructorStyles.FkInstructorId
        ORDER BY Styles.StyleName">

    </asp:SqlDataSource>

    <asp:GridView ID="GridViewStyles" runat="server" DataSourceID="SqlDataSourceStyles" AllowSorting="True" AllowPaging="True" PageSize="7" AutoGenerateColumns="False">
        <Columns>
            <asp:ImageField DataImageUrlField="Billede" DataImageUrlFormatString="~\img\Styles\Resized\{0}" ControlStyle-Height="60 px" ControlStyle-Width="60 px"></asp:ImageField>
            <asp:BoundField DataField="Stilart" HeaderText="Stilart" SortExpression="Stilart"></asp:BoundField>
            <asp:BoundField HeaderText="Beskrivelse" SortExpression="Beskrivelse" DataField="Beskrivelse"></asp:BoundField>
            <asp:TemplateField HeaderText="Instruktør" SortExpression="FirstName">
                <ItemTemplate><asp:Label ID="Label1" runat="server" Text='<%#Eval("Firstname")+ " " + Eval("LastName")%>' ></asp:Label></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="" SortExpression="">
                <ItemTemplate><asp:HyperLink NavigateUrl='<%#"TeamsByStyle.aspx?StyleId=" + Eval("Id") %>' Text="Se hold" runat="server"></asp:HyperLink></ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>


</asp:Content>
