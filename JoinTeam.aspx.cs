using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JoinTeam : System.Web.UI.Page
{
    //private string BackToLastPage;

    protected void Page_Load(object sender, EventArgs e)
    {
        //int BrugerId = Convert.ToInt32(Session["BrugerId"]);
        //int TeamId = Convert.ToInt32(Request.QueryString["HoldId"]);
        
        ////SE HER DITLEV
        //BackToLastPage = (string)Session["CurrentUrl"];

        ////Makes new variable from saved Session url, and then resets sessionurl.
        //Session["CurrentUrl"] = null;

        //if (Session["brugerId"] != null)
        //{

        //    if (ClassSheet.CheckIfUserAgeMatchTeamAge(BrugerId, TeamId))
        //    {
        //        ClassSheet.JoinATeam(BrugerId, TeamId);

        //        if (BackToLastPage != null)
        //        {
        //           //Uses the new savedUrl variable to go back to last page.
        //        Response.Redirect(BackToLastPage); 
        //        }
        //        else
        //        {
        //            Response.Redirect("Default.aspx");
        //        }                
        //    }

        //    else
        //    {
        //        AgeNotOk.Text = "Du har ikke den rigtige alder til dette hold";
        //    }
        //}
        //else
        //{
        //    Response.Redirect("Login.aspx");
        //}
    }

    //NOT WORKING...
    protected void BackToLastPageBtn_Click(object sender, EventArgs e)
    {
        //SE HER DITLEV
        
        //Response.Write(BackToLastPage);
        Response.Write((string)Session["CurrentUrl"]);
    }
}