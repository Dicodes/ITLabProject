using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteBus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Int32.Parse((string)e.CommandArgument);
        int BusId = (int)GV.DataKeys[index].Values["BusId"];

        SqlConnection con = new SqlConnection();
        con.ConnectionString = WebConfigurationManager.ConnectionStrings["BookMyBusDB"].ConnectionString;
        try
        {
            con.Open();

            string cmdstr = "Select BId from Bookings where BusId=@BusId";
            SqlCommand cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@BusId", BusId);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            List<int> bookingIds = new List<int>();
            while(reader.Read())
            {
                bookingIds.Add((int)reader["BId"]);
            }

            reader.Close();

            foreach(int bid in bookingIds)
            {
                cmdstr = "Delete from TicketDetails where BId=@BId";
                cmd = new SqlCommand(cmdstr, con);
                cmd.Parameters.AddWithValue("@BId", bid);
                cmd.ExecuteNonQuery();
            }

            cmdstr = "delete from BusSeatDetails where BusId=@BusId";
            cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@BusId", BusId);
            cmd.ExecuteNonQuery();

            cmdstr = "Delete from BusDetails where BusId=@BusId";
            cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@BusId", BusId);
            cmd.ExecuteNonQuery();

            lbl.Text = "Bus "+ BusId.ToString() + " Deleted successfully";
        }
        catch(Exception err) { lbl.Text = err.ToString(); }
        finally { con.Close(); }



    }
}