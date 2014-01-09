<%@ Page Title="" Language="C#" MasterPageFile="~/landrupdans.Master" AutoEventWireup="true" CodeFile="WeekProgram.aspx.cs" Inherits="WeekProgram" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="

        SELECT Weekdays.Day, Weekdays.Id AS Weekdays
        FROM Weekdays 
        ORDER BY Weekdays.Id"></asp:SqlDataSource>

    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
        <ItemTemplate>

            <div class="HoldKolonne">

                <h2><%# Eval ("Day") %></h2>

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand='<%#@"
                    SELECT Teams.Id AS TeamId, Weekdays.Id, Styles.StyleName AS StyleName, Age.StudentAge AS StudentAge, LessonTime.TimeOfDay AS TimeOfDay                                   
                    FROM Teams
                    INNER JOIN Styles ON Styles.Id = Teams.FkStyleId
                    INNER JOIN DayAndTime ON DayAndTime.FkTeamsId = Teams.Id
                    INNER JOIN Weekdays ON DayAndTime.FkWeekDayId = Weekdays.Id
                    INNER JOIN LessonTime ON DayAndTime.FkLessonTimeId = LessonTime.Id
                    INNER JOIN Age ON Age.Id = Teams.FkAgeId
                    LEFT JOIN Levels ON Teams.FkLevelId = Levels.Id
                    WHERE Weekdays.Id =" 
                        +  Eval("Weekdays") +
                    "AND Levels.Id =" + Request.QueryString["LevelId"] +
                    "ORDER BY LessonTime.Id"%>'>


                    <%--<SelectParameters>
                        <asp:QueryStringParameter QueryStringField="LevelId" Type="String" Name="LevelId" />
                    </SelectParameters>--%>

                </asp:SqlDataSource>

                <asp:Repeater ID="Repeater2" runat="server" DataSourceID="SqlDataSource2">

                    <ItemTemplate>
                        <div class="HoldIndhold">
                            <ul>
                                <li>kl. <%# Eval ("TimeOfDay") %></li>
                                <li><%# Eval ("StyleName") %></li>
                                <li>Aldersgruppe: <%# Eval ("StudentAge") %></li>

                                <asp:Panel ID="JoinTeamFromWeekSchedulePnl" runat="server">
                                <li><a href='<%#"JoinTeam.aspx?HoldId=" + Eval ("TeamId")%>'> Tilmeld</a></li>
                                </asp:Panel>

                            </ul>
                        </div>
                    </ItemTemplate>

                </asp:Repeater>

            </div>

        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

