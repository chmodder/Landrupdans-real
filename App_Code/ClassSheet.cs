using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClassSheet
/// </summary>
public class ClassSheet
{

    private static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

    public static DataTable TeamsByStyleConn(int StyleQueryStr)
    {
        SqlCommand sql = new SqlCommand();
        sql.Parameters.Add("@StyleQueryString", SqlDbType.Int).Value = StyleQueryStr;

        sql.CommandText = @"
            SELECT Teams.TeamName, Levels.Level, Age.StudentAge, CONCAT(Instructors.FirstName,' ', Instructors.LastName) AS Instructor, Weekdays.Day, LessonTime.TimeOfDay
            FROM Styles
            INNER JOIN Teams ON Teams.FkStyleId = Styles.Id
            INNER JOIN Instructors ON Instructors.Id = Teams.FkInstructorId
            INNER JOIN Levels ON Levels.Id = Teams.FkLevelId
            INNER JOIN Age ON Teams.FkAgeId = Age.Id
            INNER JOIN DayAndTime ON DayAndTime.FkTeamsId = Teams.Id
            INNER JOIN Weekdays ON DayAndTime.FkWeekDayId = Weekdays.Id
            INNER JOIN LessonTime ON DayAndTime.FkLessonTimeId = LessonTime.Id
            WHERE Styles.Id = @StyleQueryString
            ORDER BY Styles.StyleName";

        sql.Connection = conn;
        SqlDataAdapter da = new SqlDataAdapter(sql);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public static bool CheckIfStudentIsOnTeam(int SessionUserId, int TeamIdFromQueryString)
    {
        SqlCommand sql = new SqlCommand();
        sql.Parameters.Add("@SessionUserId", SqlDbType.Int).Value = SessionUserId;
        sql.Parameters.Add("@TeamIdFromQueryString", SqlDbType.Int).Value = TeamIdFromQueryString;

        sql.CommandText = @"
            SELECT COUNT(*)
            FROM TeamStudent
            WHERE FkStudentId = @SessionUserId
                AND FkTeamId = @TeamIdFromQueryString";

        sql.Connection = conn;
        conn.Open();
        int antal = (int)sql.ExecuteScalar();
        conn.Close();
        if (antal == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool CheckIfUserIsLoggedIn(int SessionUserId)
    {
        SqlCommand sql = new SqlCommand();
        sql.Parameters.Add("@SessionUserId", SqlDbType.Int).Value = SessionUserId;

        sql.CommandText = @"
            SELECT COUNT(*)
            FROM Students
            WHERE Id = @SessionUserId";

        sql.Connection = conn;
        conn.Open();
        int antal = (int)sql.ExecuteScalar();
        conn.Close();

        if (antal == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

//    //tjekker om bruger allerede er oprettet i systemet
//    public bool UserIsAllreadyInDB(string UserName, string Email)
//    {
//        SqlCommand sql = new SqlCommand();


//        sql.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName;
//        sql.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;


//        sql.CommandText = @"
//            SELECT COUNT(*)
//            FROM Students
//            WHERE UserName = @UserName
//            OR Email = @Email";

//        sql.Connection = conn;
//        conn.Open();
//        int antal = (int)sql.ExecuteScalar();
//        conn.Close();

//        if (antal == 1)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }

}