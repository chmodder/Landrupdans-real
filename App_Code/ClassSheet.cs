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
        conn.Close();
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


    public static void JoinATeam(int BrugerId, int TeamId)
    {
        SqlCommand sql = new SqlCommand();
        sql.Parameters.Add("@BrugerId", SqlDbType.Int).Value = BrugerId;
        sql.Parameters.Add("@TeamId", SqlDbType.Int).Value = TeamId;


        sql.CommandText = @"
            INSERT INTO TeamStudent (FkStudentId, FkTeamId)
            VALUES (@BrugerId, @TeamId)";

        sql.Connection = conn;
        conn.Open();
        sql.ExecuteNonQuery();
        conn.Close();
    }

    public static void QuitATeam(int BrugerId, int TeamId)
    {
        SqlCommand sql = new SqlCommand();
        sql.Parameters.Add("@BrugerId", SqlDbType.Int).Value = BrugerId;
        sql.Parameters.Add("@TeamId", SqlDbType.Int).Value = TeamId;


        sql.CommandText = @"
            DELETE FROM TeamStudent
            WHERE FkStudentId = @BrugerId
            AND FkTeamId = @TeamId";

        sql.Connection = conn;
        conn.Open();
        sql.ExecuteNonQuery();
        conn.Close();
    }

    public static bool CheckIfUserAgeMatchTeamAge(int BrugerId, int TeamId)
    {
        SqlCommand sql = new SqlCommand();
        sql.Parameters.Add("@SessionUserId", SqlDbType.Int).Value = BrugerId;

        sql.CommandText = @"
            SELECT Students.Birthday AS Birthday
            FROM Students
            WHERE Students.Id = @SessionUserId";

        sql.Connection = conn;
        conn.Open();
        SqlDataReader reader = sql.ExecuteReader();
        reader.Read();
        DateTime UserBirthday = Convert.ToDateTime(reader["Birthday"]);
        conn.Close();
        DateTime Today = DateTime.Now;

        //Udregner brugerens alder til int
        int UserAge = Today.Year - UserBirthday.Year;

        int TeamAge = GetTeamAge(TeamId);

        switch (TeamAge)
        {
            case 1:
                TeamAge = 3 | 4 | 5;
                break;
            case 2:
                TeamAge = 6 | 7 | 8;
                break;
            case 3:
                TeamAge = 9 | 10 | 11 | 12 | 13 | 14;
                break;
            case 4:
                TeamAge = 15 | 16 | 17 | 18;
                break;
            case 5:
                TeamAge = 19;
                break;
            
        }


        if ((TeamAge != UserAge) | (TeamAge == 19 && UserAge < 19))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private static int GetTeamAge(int TeamId)
    {
        SqlCommand sql = new SqlCommand();
        sql.Parameters.Add("@TeamIdFromQueryString", SqlDbType.Int).Value = TeamId;

        sql.CommandText = @"
            SELECT Teams.FkAgeId AS Age
            FROM Teams
            WHERE Teams.Id = @TeamIdFromQueryString";

        sql.Connection = conn;
        conn.Open();
        SqlDataReader reader = sql.ExecuteReader();
        reader.Read();

        int TeamAge = Convert.ToInt32(reader["Age"]);
        conn.Close();
        return TeamAge;
    }

}