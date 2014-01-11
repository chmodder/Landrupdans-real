﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CreateUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateUserBtn_Click(object sender, EventArgs e)
    {

        // opret forbindelse til databasen

        // FELTET MELLEM [] SKAL ÆNDRES SÅ DET PASSER TIL NAVNET PÅ DIN CONNECTIONSTRING - KAN FINDES I WEB.CONFIG FILEN
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;

        // SQL strengen
        cmd.CommandText = @"
        INSERT INTO Students 
        (FirstName, LastName, Email, UserName, Password, Birthday, FkPermissionGroupId) 
        VALUES 
        (@CreateFirstName, @CreateLastName, @CreateUsername, @CreatePassword, @CreateEmail, @CreateBirthday, 1)";


        cmd.Parameters.Add("@CreateFirstName", SqlDbType.NVarChar).Value = CreateFirstNameText.Text;
        cmd.Parameters.Add("@CreateLastName", SqlDbType.NVarChar).Value = CreateLastNameText.Text;
        cmd.Parameters.Add("@CreateUsername", SqlDbType.NVarChar).Value = CreateUserNameText.Text;
        cmd.Parameters.Add("@CreatePassword", SqlDbType.NVarChar).Value = CreatePassWordText.Text;
        cmd.Parameters.Add("@CreateEmail", SqlDbType.NVarChar).Value = CreateEmailText.Text;
        cmd.Parameters.Add("@CreateBirthday", SqlDbType.DateTime).Value = Convert.ToDateTime(CreateBirthdayText.Text + '-' + CreateBirthMonthText.Text + '-' + CreateBirthYearText.Text);

        // Åben for forbindelsen til databasen
        conn.Open();

        // Udfør SQL komandoen
        cmd.ExecuteNonQuery();

        // Luk for forbindelsen til databasen
        conn.Close();

        // Besked til brugeren om at beskeden er modtaget
        MsgLbl.Text = "Tak! Vi har modtaget din besked og den vil blive behandlet indenfor 24 timer";

        CreateFirstNameText.Text = "";
        CreateLastNameText.Text = "";
        CreateUserNameText.Text = "";
        CreatePassWordText.Text = "";
        CreateEmailText.Text = "";
        CreateBirthdayText.Text = "";
        CreateBirthMonthText.Text = "";
        CreateBirthYearText.Text = "";
    }
}