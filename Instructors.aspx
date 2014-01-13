<%@ Page Title="" Language="C#" MasterPageFile="~/landrupdans.Master" AutoEventWireup="true" CodeFile="Instructors.aspx.cs" Inherits="Instructors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <%--<asp:RadioButtonList ID="RadioButtonListInstructors" runat="server" DataSourceID="SqlDataSourceRadioBtnList">
        <asp:ListItem Value="1">Instrukt&#248;rnavn</asp:ListItem>
        <asp:ListItem Value="2">Stilart</asp:ListItem>
    </asp:RadioButtonList>--%>


    <asp:SqlDataSource runat="server" ID="SqlDataSourceInstructors" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand="
        SELECT 
            Instructors.InstructorImg As InstructorImg,
            CONCAT(Instructors.Firstname, ' ',  Instructors.LastName) AS InstructorName,
            Instructors.Info AS InstructorInfo,
            Instructors.Id AS InstructorId
        FROM Instructors
        ORDER BY InstructorName"></asp:SqlDataSource>

    <asp:Repeater ID="RepeaterInstructors" runat="server" DataSourceID="SqlDataSourceInstructors">

        <ItemTemplate>
            <div class="Instructors">
                <div class="InstructorImgDiv">
                    <asp:Image ID="InstructorImg" ImageUrl='<%#"/img/Instructors/resized/" +  Eval ("InstructorImg") %>' runat="server" Width="120px" />

                </div>


                <div class="InstructorNameAndStyles">
                    <h3>Navn</h3>
                    <asp:Label ID="InstruktorNameLbl" runat="server" Text='<%# Eval("InstructorName") %>'></asp:Label>
                    <h3>Stilarter</h3>
                    <asp:SqlDataSource runat="server" ID="SqlDataSourceInstructorStyles" ConnectionString='<%$ ConnectionStrings:ConnectionString %>' SelectCommand='<%#@"
                SELECT Styles.StyleName AS StyleName
                    FROM Instructors
                    INNER JOIN InstructorStyles ON InstructorStyles.FkInstructorId = Instructors.Id
                    INNER JOIN Styles ON InstructorStyles.FkStyleId = Styles.Id
                    WHERE Instructors.Id =" +  Eval ("InstructorId") +
                    "ORDER BY StyleName"%>'></asp:SqlDataSource>

                    <asp:Repeater ID="RepeaterInstructorStyles" runat="server" DataSourceID="SqlDataSourceInstructorStyles">
                        <ItemTemplate>

                            <ul>
                                <li>
                                    <asp:Label ID="InstructorStyleLbl" runat="server" Text='<%# Eval("StyleName") %>'></asp:Label></li>
                            </ul>

                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <div class="InstructorInfoDiv">
                    <h3>Info</h3>
                    <asp:Label ID="InstructorsInfo" runat="server" Text='<%# Eval("InstructorInfo") %>'></asp:Label>
                </div>


                <div class="InstructorTeamsLink">
                    <a href='<%# "TeamsByInstructor.aspx?InstructorId=" + Eval ("InstructorId")%>'>Se hold</a>
                </div>

            </div>
        </ItemTemplate>

    </asp:Repeater>

</asp:Content>

