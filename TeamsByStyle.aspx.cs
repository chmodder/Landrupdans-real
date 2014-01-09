using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TeamsByStyle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Laver en variabel med style-querystring'en og konverterer den til en integer
        int StyleQueryStr = Convert.ToInt32(Request.QueryString["StyleId"]);

        //Opretter en datasource til Gridviewet, kalder metoden TeamsByStyleConn i ClassSheet'et og bruger Querystring-variablen StyleQueryStr's værdi som input
        GridViewTeamsByStyle.DataSource = ClassSheet.TeamsByStyleConn(StyleQueryStr);

        //Databinder til gridviewet
        GridViewTeamsByStyle.DataBind();
    }
}