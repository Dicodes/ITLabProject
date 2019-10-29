using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InsertBus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void insert_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = WebConfigurationManager.ConnectionStrings["BookMyBusDB"].ConnectionString;
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertBusDetails";

            cmd.Connection = con;
            SqlParameter UserId = cmd.Parameters.Add("@BusId", SqlDbType.Int);
            UserId.Direction = ParameterDirection.Output;

            SqlParameter BusName = cmd.Parameters.Add("@BusName", SqlDbType.VarChar);
            BusName.Value = busName.Text;

            SqlParameter CName = cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar);
            CName.Value = companyName.Text;

            SqlParameter fplace = cmd.Parameters.Add("@FromPlace", SqlDbType.VarChar);
            fplace.Value = fromPlace.Text;

            SqlParameter tplace = cmd.Parameters.Add("@ToPlace", SqlDbType.VarChar);
            tplace.Value = toPlace.Text;

            DateTime depart = Convert.ToDateTime(ddate.Text +" "+ dtime.Text);

            SqlParameter dep = cmd.Parameters.Add("@DepartTime", SqlDbType.DateTime);
            dep.Value = depart;

            DateTime arrive = Convert.ToDateTime(adate.Text +" "+ atime.Text);

            SqlParameter arr = cmd.Parameters.Add("@ArriveTime", SqlDbType.DateTime);
            arr.Value = arrive;

            SqlParameter seats = cmd.Parameters.Add("@SeatsAvailable", SqlDbType.Int);
            seats.Value = 13;

            SqlParameter costs = cmd.Parameters.Add("@Cost", SqlDbType.Money);
            costs.Value = Convert.ToDecimal(cost.Text);

            cmd.ExecuteNonQuery();

            int busid = Convert.ToInt32(cmd.Parameters["@BusId"].Value);

            string cmdstr = "Insert into BusSeatDetails (BusId) Values (@BusId)";
            cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@BusId", busid);
            cmd.ExecuteNonQuery();

            ll.Visible = true;
            ll.Text = "Successfully inserted!";
        }
        catch (Exception err) { ll.Visible = true; ll.Text = err.ToString(); }
        finally { con.Close(); }
    }
}