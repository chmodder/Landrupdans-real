using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                UserNameText.Text = Request.Cookies["UserName"].Value;
                PassWordText.Attributes["value"] = Request.Cookies["Password"].Value;
            }
        }
    }
    protected void LoginSubmitBtn_Click(object sender, EventArgs e)
    {
        if (chkRememberMe.Checked)
        {
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
        }
        else
        {
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

        }
        Response.Cookies["UserName"].Value = UserNameText.Text.Trim();
        Response.Cookies["Password"].Value = PassWordText.Text.Trim();

        // opret forbindelse til databasen
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        // SQL strengen
        cmd.CommandText = @"
        SELECT * FROM Students
        WHERE Students.UserName LIKE @UserName
            AND Students.PassWord LIKE @Password";

        // Tilføj parametrer (input fra brugeren / TextBox fra .aspx siden) til din SQL streng
        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserNameText.Text;
        cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = PassWordText.Text;

        // Åben for forbindelsen til databasen
        conn.Open();

        // Udfør SQL komandoen
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            // Gem informationer om login i Session
            Session["BrugerId"] = reader["Id"];


            // Send brugeren videre
            Response.Redirect("StudentPages/Default.aspx");
        }

        else
        {
            // Vis fejlmeddelelse
            PanelMsgError.Visible = true;
        }

        // Luk for forbindelsen til databasen
        conn.Close();
    }
}