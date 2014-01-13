<%@ Page Title="" Language="C#" MasterPageFile="~/landrupdans.Master" AutoEventWireup="true" CodeFile="TeamsByInstructor.aspx.cs" Inherits="TeamsByInstructor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:SqlDataSource runat="server" ID="SqlDataSourceTeamsByInstructor" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="
        SELECT 
            Teams.Id AS TeamId,
                Teams.TeamName AS TeamName,
            Styles.StyleName AS StyleName,
            Levels.Level AS Level,
                Levels.Id AS LevelId,
            Age.StudentAge AS Age,
                Age.Id AS AgeId,
            Weekdays.Day AS WeekDay,
                Weekdays.Id AS DayId,
            LessonTime.TimeOfDay AS Time,
                LessonTime.Id AS TimeId
        FROM Teams
        INNER JOIN Styles ON Styles.Id = Teams.FkStyleId
        INNER JOIN Levels ON Levels.Id = Teams.FkLevelId
        INNER JOIN Age ON Age.Id =Teams.FkAgeId
        INNER JOIN DayAndTime ON DayAndTime.FkTeamsId = Teams.Id
        INNER JOIN Weekdays ON Weekdays.Id = DayAndTime.FkWeekdayId
        INNER JOIN LessonTime ON LessonTime.Id = DayAndTime.FkLessonTimeId
        WHERE Teams.FkInstructorId = @InstructorId
        ORDER BY TeamName">

        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="InstructorId" Name="InstructorId" DbType="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TeamId" DataSourceID="SqlDataSourceTeamsByInstructor" AllowPaging="True" AllowSorting="True">

        <Columns>
            <asp:BoundField DataField="TeamName" HeaderText="Holdnavn" SortExpression="TeamName"></asp:BoundField>
            <asp:BoundField DataField="StyleName" HeaderText="Dansestil" SortExpression="StyleName"></asp:BoundField>
            <asp:BoundField DataField="Level" HeaderText="Niveau" SortExpression="LevelId"></asp:BoundField>
            <asp:BoundField DataField="Age" HeaderText="Aldersgruppe" SortExpression="AgeId"></asp:BoundField>
            <asp:BoundField DataField="WeekDay" HeaderText="Ugedag" SortExpression="DayId"></asp:BoundField>
            <asp:BoundField DataField="Time" HeaderText="Tid" SortExpression="TimeId"></asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex='<%# JoinQuitPanelToggle((Session["BrugerId"]), Eval("TeamId")) %>'>

                        <asp:View ID="JoinTeamFromWeekSchedulePnl" runat="server">
                            <a href='<%#"JoinTeam.aspx?HoldId=" + Eval ("TeamId")%>'>Tilmeld</a>
                        </asp:View>

                        <asp:View ID="QuitTeamFromWeekSchedulePnl" runat="server">
                            <a href='<%#"QuitTeam.aspx?HoldId=" + Eval ("TeamId")%>'>Frameld</a>
                        </asp:View>

                    </asp:MultiView>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>




</asp:Content>



