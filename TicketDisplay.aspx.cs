using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TicketDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["BookMyBusDB"].ConnectionString;
            int bookingID = int.Parse(Request.QueryString["BId"]);
            BId.Text = bookingID.ToString();
            int BusId=0, Seats=0;
            try
            {
                con.Open();
                string cmdstr = " select SeatNo from TicketDetails where BId=@BId";
                SqlCommand cmd = new SqlCommand(cmdstr, con);
                cmd.Parameters.AddWithValue("@BId", bookingID);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    seatNos.Text += reader["SeatNo"].ToString() + " ";
                }
                reader.Close();

                cmdstr = "Select BusId,Seats from Bookings where BId=@BId";
                cmd = new SqlCommand(cmdstr, con);
                cmd.Parameters.AddWithValue("@BId", bookingID);
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    BusId = int.Parse(reader["BusId"].ToString());
                    Seats = int.Parse(reader["Seats"].ToString());
                }
                reader.Close();

                cmdstr = "select BusName, FromPlace, DepartTime, Cost from BusDetails where BusId=@BusId";
                cmd = new SqlCommand(cmdstr, con);
                cmd.Parameters.AddWithValue("@BusId", BusId);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    fromPlace.Text = reader["FromPlace"].ToString();
                    departOn.Text = reader["DepartTime"].ToString().Split()[0];
                    deptTime.Text = reader["DepartTime"].ToString().Split()[1];
                    BusCompany.Text = reader["BusName"].ToString();
                    decimal cost = (decimal)reader["Cost"];
                    cost = cost * Seats;
                    Cost.Text += cost.ToString();
                }
                reader.Close();
            }
            catch(Exception err) { BId.Text = err.ToString(); }
            finally { con.Close(); }
        }

    }
}