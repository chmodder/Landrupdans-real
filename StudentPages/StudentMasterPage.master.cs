using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentPages_StudentMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Tjekker om man er logget ind. Ellers skal brugeren sendes til loginsiden.
        int SessionUserId = Convert.ToInt32(Session["BrugerId"]);
        if (!ClassSheet.CheckIfUserIsLoggedIn(SessionUserId))
        {
            Response.Redirect("/Login.aspx");
        }

        MultiView1.DataBind();
        MultiView2.DataBind();
    }


    protected int UserLoggedInMultiviewToggle(Object SessionUserId)
    {
        int sessionId = Convert.ToInt32(SessionUserId);

        if (ClassSheet.CheckIfUserIsLoggedIn(sessionId))
        {
            return 1;
        }
        else
        {
            return 0;
        }

    }

    protected void LogOutBtn_Click(object sender, EventArgs e)
    {
        Session["BrugerId"] = null;
        Response.Redirect("/Default.aspx");
    }
}
