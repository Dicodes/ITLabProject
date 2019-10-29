using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage2 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{


        //    string connectionString = WebConfigurationManager.ConnectionStrings["BookMyBusDB"].ConnectionString;
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = connectionString;

        //    try
        //    {
        //        con.Open();
        //        string cmdStr = "Select Distinct ToPlace,FromPlace from BusDetails";
        //        SqlCommand cmd = new SqlCommand(cmdStr, con);
        //        SqlDataReader reader;
        //        reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            if (!fromPlace.Items.Contains(new ListItem(reader["FromPlace"].ToString())))
        //                fromPlace.Items.Add(reader["FromPlace"].ToString());
        //            if (!toPlace.Items.Contains(new ListItem(reader["ToPlace"].ToString())))
        //                toPlace.Items.Add(reader["ToPlace"].ToString());
        //        }

        //        reader.Close();
        //    }
        //    catch (Exception err)
        //    {

        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //    if (Session["FromPlace"] != null)
        //        fromPlace.Items.FindByText(Session["FromPlace"].ToString()).Selected = true;
        //    if (Session["ToPlace"] != null)
        //        toPlace.Items.FindByText(Session["ToPlace"].ToString()).Selected = true;
        //}

    }

    protected void logout_Click(object sender, EventArgs e)
    {
        HttpCookie c = Request.Cookies["User"];
        c.Expires = DateTime.Now.AddMonths(-1);
        Response.Cookies.Add(c);
        string url = "Login.aspx";
        Response.Redirect(url);
    }


    protected void update_Click(object sender, EventArgs e)
    {
        Response.Redirect("UpdateDetails.aspx");
    }

    protected void manage_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["User"];
        string url = "ManageBookings.aspx?";
        url += "Uid=" + Server.UrlEncode(cookie["UserId"]);
        Response.Redirect(url);
    }
    //protected void View_Click(object sender, EventArgs e)
    //{
    //    Session["FromPlace"] = fromPlace.SelectedValue;
    //    Session["ToPlace"] = toPlace.SelectedValue;
    //    string url = "BusList.aspx?";
    //    url += "From=" + Server.UrlEncode(fromPlace.SelectedValue) + "&To=" + Server.UrlEncode(toPlace.SelectedValue);
    //    Response.Redirect(url);
    //}

    protected void insert_Click(object sender, EventArgs e)
    {
        Response.Redirect("InsertBus.aspx");
    }

    protected void delete_Click(object sender, EventArgs e)
    {
        Response.Redirect("DeleteBus.aspx");
    }
}
