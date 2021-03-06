﻿using System;
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
            Response.Redirect(ResolveClientUrl("~/Login.aspx"));
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
        Response.Redirect(ResolveClientUrl("~/Default.aspx"));
    }

    protected void SearchBtn_OnClick(object sender, EventArgs e)
    {
        //optional SearchParameters:
        //- searchstring
        //- day
        //- time
        //- checkboxItems

        //1) Create searchString (SQL) based on search settings
        //2) Search
        string SqlSearchQuery =
            @"SELECT TeamName, StyleName, Description, FirstName, LastName, Info, Level, StudentAge  FROM Teams
                                  INNER JOIN Styles ON Styles.Id = Teams.FkStyleId
                                  INNER JOIN Instructors ON Instructors.Id = Teams.FKInstructorId
                                  INNER JOIN Age ON Age.Id = Teams.FkAgeId
                                  INNER JOIN Levels ON Levels.Id = Teams.FkLevelId";
        //Add to string using "SqlSearchQuery += 'something to add'"

        string SearchText = SearchTbx.Text;
        //testing
        //Response.Write(SearchText);

        //string QueryString = SqlQueryBuilder(SearchText);
        //RunSearch(QueryString);
        //Response.Write(QueryString);

        //Searchstring used
        #region SearchString
        if (SearchText.Length > 0)
        {
            #region NoCheckboxIsChecked
            //No checkbox is checked
            if (SearchCbl.SelectedItem == null)
            {
                //CHECK DATE AND TIME
                //Day OR Time NOT checked:
                if (DayDdl.SelectedItem.Value == "0" && TimeDdl.SelectedItem.Value == "0")
                {
                    //Ask for input
                    Response.Write("1) Nu skal alle hold, hvor instruktør-navnet, instruktør-info, aktivitet-navn eller aktivitet-beskrivelse indeholder søgestrengen vises");
                }

                //Day OR Time IS checked
                else if (DayDdl.SelectedValue != "0" && TimeDdl.SelectedItem.Value != "0")
                {
                    //Search teams on selected Day AND Time.
                    Response.Write("2) Nu skal alle hold, hvor <br/>(instruktør-navnet, instruktør-info, aktivitet-navn eller aktivitet-beskrivelse - Det kan også være andre tabeller, da der ikke er checkbox-filter på søgningen)<br/> indeholder søgestrengen vises OG hvor Tid og dato svarer til det valgte");
                }

                //Only Day IS Checked
                else if (DayDdl.SelectedValue != "0")
                {
                    //Search teams on the selected day (Order by timeOfDay)
                    Response.Write("3) Nu skal alle hold, hvor <br/>(instruktør-navnet, instruktør-info, aktivitet-navn eller aktivitet-beskrivelse - Det kan også være andre tabeller, da der ikke er checkbox-filter på søgningen)<br/> indeholder søgestrengen vises OG hvor Tid svarer til det valgte");
                }

                // ONLY Time IS checked //
                else
                {
                    //Search teams on the selected time (Order by weekday)
                    Response.Write("4) Nu skal alle hold, hvor <br/>(instruktør-navnet, instruktør-info, aktivitet-navn eller aktivitet-beskrivelse - Det kan også være andre tabeller, da der ikke er checkbox-filter på søgningen)<br/> indeholder søgestrengen vises OG hvor dato svarer til det valgte");
                }


            }
            #endregion

            #region SomethingIsChecked
            //Some checkbox is checked
            else
            {
                //CHECK DATE AND TIME
                //Day OR Time not checked:
                if (DayDdl.SelectedItem.Value == "0" && TimeDdl.SelectedItem.Value == "0")
                {
                    //Hvis IKKE begge felter ("Aktivitet" og "Instruktør") er hakket af
                    if (SearchCbl.SelectedItem.Value != "Activity" && SearchCbl.SelectedItem.Value != "Instructor")
                    {
                         switch (SearchCbl.SelectedItem.Value)
                        {
                            //Search for all Activities
                            case "Activity":
                                Response.Write("5) Nu skal hold, hvor aktivitet-navnet indeholder søgestrengen vises");
                                break;

                            //Search for all Instructors
                            case "Instructor":
                                Response.Write("6) Nu skal hold, hvor instruktør-navnet indeholder søgestrengen vises");
                                break;
                        }
                    }

                    else
                    {
                        //Search all Activities AND Instructors  
                        Response.Write("6,5) Nu skal alle hold, hvor instruktør-navnet, instruktør-info, aktivitet-navn eller aktivitet-beskrivelse indeholder søgestrengen vises");
                    }

                    #region OldCode
                    ////Both Activity AND Instructor is checked
                    //if (SearchCbl.SelectedItem.Value == "Activity" && SearchCbl.SelectedItem.Value == "Instructor")
                    //{
                    //    //Search all Activities AND Instructors?  
                    //    Response.Write("Nu skal alle Aktiviteter og instruktører vises? ");
                    //}
                    ////Only Activity is checked
                    //else if (SearchCbl.SelectedItem.Value == "Activity")
                    //{
                    //    //Search for all Activities
                    //    Response.Write("Nu skal alle Aktiviteter vises? ");
                    //}
                    ////Only Instructors is checked
                    //else
                    //{
                    //    //Search for all Instructors
                    //    Response.Write("Nu skal alle instruktører vises? ");
                    //} 
                    #endregion
                }

                //Both Day AND Time is checked
                else if (DayDdl.SelectedValue != "0" && TimeDdl.SelectedItem.Value != "0")
                {
                    //Hvis IKKE begge felter ("Aktivitet" og "Instruktør") er hakket af
                    if (!(SearchCbl.SelectedItem.Value == "Activity" && SearchCbl.SelectedItem.Value == "Instructor"))
                    {
                        switch (SearchCbl.SelectedItem.Value)
                        {
                            //Search for all Activities on selected Day AND Time
                            case "Activity":
                                Response.Write("7) Nu skal hold, hvor aktivitet-navnet eller aktivitet-beskrivelsen indeholder søgestrengen vises OG hvor Tid og dato svarer til det valgte ");
                                break;

                            //Search for all Instructors
                            case "Instructor":
                                Response.Write("8) Nu skal hold, hvor instruktør-navnet eller instruktør-info indeholder søgestrengen vises OG hvor Tid og dato svarer til det valgte  ");
                                break;
                        }
                    }


                    //Hvis begge felter ER hakket af ("Aktivitet" og "Instruktør")
                    else
                    {
                        //Search all Activities AND Instructors that has a team?  
                        Response.Write("9) Nu skal alle hold, hvor instruktør-navnet, instruktør-info, aktivitet-navn eller aktivitet-beskrivelse indeholder søgestrengen vises OG hvor Tid og dato svarer til det valgte");
                    }
                }

                //Day is Checked
                else if (DayDdl.SelectedValue != "0")
                {
                    //Hvis IKKE begge felter ("Aktivitet" og "Instruktør") er hakket af
                    if (!(SearchCbl.SelectedItem.Value == "Activity" && SearchCbl.SelectedItem.Value == "Instructor"))
                    {
                        switch (SearchCbl.SelectedItem.Value)
                        {
                            //Search for all Activities on selected Day
                            case "Activity":
                                Response.Write("10) Nu skal hold, hvor aktivitet-navnet eller aktivitet-beskrivelsen indeholder søgestrengen vises OG hvor dato svarer til det valgte ");
                                break;

                            //Search for all Instructors
                            case "Instructor":
                                Response.Write("11) Nu skal hold, hvor instruktør-navnet eller instruktør-info indeholder søgestrengen vises OG hvor dato svarer til det valgte  ");
                                break;
                        }
                    }


                    //Hvis begge felter ER hakket af ("Aktivitet" og "Instruktør")
                    else
                    {
                        //Search all Activities AND Instructors that has a team?  
                        Response.Write("12) Nu skal alle hold, hvor instruktør-navnet, instruktør-info, aktivitet-navn eller aktivitet-beskrivelse indeholder søgestrengen vises OG hvor dato svarer til det valgte");
                    }
                }

                //Time is checked //
                else
                {
                    //Hvis IKKE begge felter ("Aktivitet" og "Instruktør") er hakket af
                    if (!(SearchCbl.SelectedItem.Value == "Activity" && SearchCbl.SelectedItem.Value == "Instructor"))
                    {
                        switch (SearchCbl.SelectedItem.Value)
                        {
                            //Search for all Activities on selected Day
                            case "Activity":
                                Response.Write("13) Nu skal hold, hvor aktivitet-navnet eller aktivitet-beskrivelsen indeholder søgestrengen vises OG hvor tid svarer til det valgte ");
                                break;

                            //Search for all Instructors
                            case "Instructor":
                                Response.Write("14) Nu skal hold, hvor instruktør-navnet eller instruktør-info indeholder søgestrengen vises OG hvor tid svarer til det valgte  ");
                                break;
                        }
                    }


                    //Hvis begge felter ER hakket af ("Aktivitet" og "Instruktør")
                    else
                    {
                        //Search all Activities AND Instructors that has a team?  
                        Response.Write("15) Nu skal alle hold, hvor instruktør-navnet, instruktør-info, aktivitet-navn eller aktivitet-beskrivelse indeholder søgestrengen vises OG hvor tid svarer til det valgte");
                    }
                }
            }
            #endregion
        }
        #endregion

    }

    private string SqlQueryBuilder(string searchText)
    {
        //Searchstring empty
        #region SearchString
        if (searchText.Length > 0)
        {
            #region NothingIsChecked
            //Nothing is checked
            if (SearchCbl.SelectedItem.Value == null)
            {
                //CHECK DATE AND TIME
                //Day OR Time not checked:
                if (DayDdl.SelectedItem.Value == "0" && TimeDdl.SelectedItem.Value == "0")
                {
                    //Ask for input
                    Response.Write("Søger efter ALLE hold, der indeholder søgeordet");
                }

                //Both is checked
                else if (DayDdl.SelectedValue != "0" && TimeDdl.SelectedItem.Value != "0")
                {
                    //Search teams on selected Day AND Time.
                    Response.Write("Du har søgt på hold der køres på flg tidspunkter:" + "Dag-value=" + DayDdl.SelectedValue + ", Tids-value=" + TimeDdl.SelectedValue);
                }

                //Day is Checked
                else if (DayDdl.SelectedValue != "0")
                {
                    //Search teams on the selected day (Order by timeOfDay)
                    Response.Write("Du har søgt på alle hold der køres flg. dag: Dag-value" + DayDdl.SelectedValue);
                }

                //Time is checked //
                else
                {
                    //Search teams on the selected time (Order by weekday)
                    Response.Write("Du har søgt på alle hold der køres flg. tid: tid-value" + TimeDdl.SelectedValue);
                }


            }
            #endregion

            #region SomethingIsChecked
            //Something is checked
            else
            {
                //CHECK DATE AND TIME
                //Day OR Time not checked:
                if (DayDdl.SelectedItem.Value == "0" && TimeDdl.SelectedItem.Value == "0")
                {
                    //Hvis IKKE begge felter ("Aktivitet" og "Instruktør") er hakket af
                    if (!(SearchCbl.SelectedItem.Value == "Activity" && SearchCbl.SelectedItem.Value == "Instructor"))
                    {
                        switch (SearchCbl.SelectedItem.Value)
                        {
                            //Search for all Activities
                            case "Activity":
                                Response.Write("Nu skal alle Aktiviteter vises? ");
                                break;

                            //Search for all Instructors
                            case "Instructor":
                                Response.Write("Nu skal alle instruktører vises? ");
                                break;
                        }
                    }
                }

                //Both Day AND Time is checked
                else if (DayDdl.SelectedValue != "0" && TimeDdl.SelectedItem.Value != "0")
                {
                    //Hvis IKKE begge felter ("Aktivitet" og "Instruktør") er hakket af
                    if (!(SearchCbl.SelectedItem.Value == "Activity" && SearchCbl.SelectedItem.Value == "Instructor"))
                    {
                        switch (SearchCbl.SelectedItem.Value)
                        {
                            //Search for all Activities on selected Day AND Time
                            case "Activity":
                                Response.Write("Nu skal alle Aktiviteter vises for den valgte dag og tid? ");
                                break;

                            //Search for all Instructors
                            case "Instructor":
                                Response.Write("Nu skal alle instruktører vises, der har hold på den valgte dag og tid? ");
                                break;
                        }
                    }


                    //Hvis begge felter ER hakket af ("Aktivitet" og "Instruktør")
                    else
                    {
                        //Search all Activities AND Instructors that has a team?  
                        Response.Write("Nu skal alle Aktiviteter og instruktører der har hold på den valgte dag og tid vises? ");
                    }
                }

                //Day is Checked
                else if (DayDdl.SelectedValue != "0")
                {
                    //Search teams on the selected day (Order by timeOfDay)
                    Response.Write("Du har søgt på alle hold der køres flg. dag: Dag-value" + DayDdl.SelectedValue);
                }

                //Time is checked //
                else
                {
                    //Search teams on the selected time (Order by weekday)
                    Response.Write("Du har søgt på alle hold der køres flg. tid: tid-value" + TimeDdl.SelectedValue);
                }
            }
            #endregion
        }
        #endregion

        return "";
    }
}
