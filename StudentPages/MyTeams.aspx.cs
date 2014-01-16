using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StudentPages_MyTeams : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["CurrentUrl"] = Request.Url.ToString();
    }

    protected int JoinQuitPanelToggle(Object SessionUserId, object TeamIdFromQueryString)
    {
        int sessionId = Convert.ToInt32(SessionUserId);
        int TeamId = Convert.ToInt32(TeamIdFromQueryString);

        if (ClassSheet.CheckIfStudentIsOnTeam(sessionId, TeamId))
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}