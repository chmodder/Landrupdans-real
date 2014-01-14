using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JoinTeam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int BrugerId = Convert.ToInt32(Session["BrugerId"]);
        int TeamId = Convert.ToInt32(Request.QueryString["HoldId"]);

        //tager den gemte url og putter den ind i en anden variabel, så sessionvariblen bliver nulstillet
        string BackToLastPage = (string)Session["CurrentUrl"];
        Session["CurrentUrl"] = null;

        //smider BackToLastPage-variablen i en viewstate variabel, så den kan bruges i en anden metode udefor pageload-metoden
        ViewState["BackToLastPage"] = BackToLastPage;

        if (Session["brugerId"] != null)
        {

            if (ClassSheet.CheckIfUserAgeMatchTeamAge(BrugerId, TeamId))
            {
                ClassSheet.JoinATeam(BrugerId, TeamId);

                if (BackToLastPage != null)
                {
                   //bruger den gemte sessionvariablen til at gå tilbage til tidligere side
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
            Response.Redirect("Login.aspx");
        }
    }

    protected void BackToLastPageBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect(Convert.ToString(ViewState["BackToLastPage"]));
    }
}