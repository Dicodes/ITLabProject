using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["User"];
        if (cookie != null && cookie["UserName"] != "Admin")
            Response.Redirect("HomePage.aspx?");
        else if (cookie != null && cookie["UserName"] == "Admin")
            Response.Redirect("InsertBus.aspx");


    }

    protected void login_Click(object sender, EventArgs e)
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["BookMyBusDB"].ConnectionString;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connectionString;

        try
        {
            con.Open();
            string cmdstr = "Select UserId, Username, Password, Admin from UserInfo";
            SqlCommand cmd = new SqlCommand(cmdstr, con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if(reader["Username"].ToString() == user_tb1.Text && reader["Password"].ToString() == pass_tb1.Text && reader["Admin"].ToString() == "0" )
                {
                    string url = "HomePage.aspx?";
                    HttpCookie cookie = Request.Cookies["User"];
                    if (cookie == null)
                        cookie = new HttpCookie("User");
                    cookie["UserId"] = reader["UserId"].ToString();
                    cookie["UserName"] = reader["Username"].ToString();
                    cookie.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(cookie);
                    reader.Close();
                    con.Close();
                    Response.Redirect(url);
                }
                else if(reader["Username"].ToString() == user_tb1.Text && reader["Password"].ToString() == pass_tb1.Text && reader["Admin"].ToString() == "1")
                {
                    string url = "InsertBus.aspx?";
                    HttpCookie cookie = Request.Cookies["User"];
                    if (cookie == null)
                        cookie = new HttpCookie("User");
                    cookie["UserId"] = reader["UserId"].ToString();
                    cookie["UserName"] = reader["Username"].ToString();
                    cookie.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(cookie);
                    reader.Close();
                    con.Close();
                    Response.Redirect(url);

                }
            }

            reader.Close();
        }
        catch(Exception err) { user_ll1.Text = err.ToString(); }
        finally
        {
            con.Close();
        }
    }


    protected void signup_Click(object sender, EventArgs e)
    {
        string name = name_tb2.Text;
        string uname = user_tb2.Text;
        string pwd = pass_tb2.Text;

        string connectionString = WebConfigurationManager.ConnectionStrings["BookMyBusDB"].ConnectionString;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = connectionString;

        int id=0;
        try
        {
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertID";

            cmd.Connection = con;
            SqlParameter UserId = cmd.Parameters.Add("@UserId", SqlDbType.Int);
            UserId.Direction = ParameterDirection.Output;

            SqlParameter Name = cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            Name.Value = name;

            SqlParameter Username = cmd.Parameters.Add("@Username", SqlDbType.VarChar);
            Username.Value = uname;

            SqlParameter Password = cmd.Parameters.Add("@Password", SqlDbType.NVarChar);
            Password.Value = pwd;

            SqlParameter Email = cmd.Parameters.Add("@Email", SqlDbType.VarChar);
            Email.Value = email_tb2.Text;

            SqlParameter Contact = cmd.Parameters.Add("@Contact", SqlDbType.NChar);
            Contact.Value = contact_tb2.Text;

            SqlParameter Admin = cmd.Parameters.Add("@Admin", SqlDbType.NChar);
            Admin.Value = "0";

            cmd.ExecuteNonQuery();

            id = Convert.ToInt32(cmd.Parameters["@UserId"].Value);
        }
        catch (Exception err)
        {
            name_ll2.Text = "ID!!!" + id.ToString() + err.ToString();
        }
        finally { con.Close(); }
    }
}