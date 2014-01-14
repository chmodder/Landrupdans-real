using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JoinTeam : System.Web.UI.Page
{
    //This helped me http://stackoverflow.com/questions/21121766/defining-and-adding-value-to-variable-from-session-variable

    //Defining Go back variable
    private string BackToLastPage { get { return (Session["CurrentUrl"] == null) ? "" : Session["CurrentUrl"].ToString(); } }

    protected void Page_Load(object sender, EventArgs e)
    {
        int BrugerId = Convert.ToInt32(Session["BrugerId"]);
        int TeamId = Convert.ToInt32(Request.QueryString["HoldId"]);

        //Adding value to go back variable from sessionurl
        //BackToLastPage = (string)Session["CurrentUrl"];

        

        if (Session["brugerId"] != null)
        {

            if (ClassSheet.CheckIfUserAgeMatchTeamAge(BrugerId, TeamId))
            {
                ClassSheet.JoinATeam(BrugerId, TeamId);

                if (BackToLastPage != null)
                {
                    //Uses the new savedUrl variable to go back to last page.
                    Response.Redirect(BackToLastPage);
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }

            else
            {
                AgeNotOk.Text = "Du har ikke den rigtige alder til dette hold";
            }
        }
        else
        {
            //Not saving last page. Need to find solution.
            Response.Redirect("Login.aspx");
        }
    }

    //NOT WORKING...
    protected void BackToLastPageBtn_Click(object sender, EventArgs e)
    {
        //YOU SHOULD SET THE CURRENT URL TO NULL HERE.
        string tempUrl = BackToLastPage;
        Session["CurrentUrl"] = null;
        Response.Redirect(tempUrl);
    }
}