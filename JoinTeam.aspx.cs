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
        if (Session["brugerId"] != null)  
        {
            
            int BrugerId = Convert.ToInt32(Session["BrugerId"]);
            int TeamId = Convert.ToInt32(Request.QueryString["HoldId"]);

            ClassSheet.JoinATeam(BrugerId, TeamId);

            //tager den gemte url og putter den ind i en anden variabel, så sessionvariblen bliver nulstillet
            string BackToLastPage = (string)Session["CurrentUrl"];
            Session["CurrentUrl"] = null;
            Response.Redirect(BackToLastPage);
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}