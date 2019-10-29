using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManageBookings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Bus_GV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Int32.Parse((string)e.CommandArgument);
        int BId = (int)Bus_GV.DataKeys[index].Values["BId"];

        SqlConnection con = new SqlConnection();
        con.ConnectionString = WebConfigurationManager.ConnectionStrings["BookMyBusDB"].ConnectionString;
        try
        {
            con.Open();
            string cmdstr = "Select BusId from Bookings where BId=@BId";
            SqlCommand cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@BId", BId);

            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            int busId = 0, seats = 0;
            while (reader.Read())
            {
                busId = (int)reader["BusId"];
            }
            reader.Close();

            cmdstr = "Select SeatsAvailable from BusDetails where BusId=@BusId";
            cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@BusId", busId);
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                seats = (int)reader["SeatsAvailable"];
            }
            reader.Close();
            cmdstr = "Select SeatNo from TicketDetails where BId=@BId";
            cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@BId", BId);
            List<string> SeatNos = new List<string>();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SeatNos.Add(reader["SeatNo"].ToString());
            }
            reader.Close();

            List<int> Selected = new List<int>();

            foreach (string s in SeatNos)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (Char.IsDigit(s[i]))
                    {
                        if (i+1<s.Length && Char.IsDigit(s[i + 1]))
                        {
                            string num = s[i].ToString() + s[i + 1].ToString();
                            int n = int.Parse(num);
                            Selected.Add(n);
                            i = i + 1;
                        }
                        else
                        {

                            int n = int.Parse(s[i].ToString());
                            Selected.Add(n);

                        }
                    }
                }
            }

            cmdstr = "Select S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12, S13 from BusSeatDetails where BusId=@BusId";
            cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@BusId", busId);
            reader = cmd.ExecuteReader();
            List<int> bookings = new List<int>(new int[13]);
            while (reader.Read())
            {
                if ((int)reader["S1"] == 1)
                    bookings[0] = 1;
                if ((int)reader["S2"] == 1)
                    bookings[1] = 1;
                if ((int)reader["S3"] == 1)
                    bookings[2] = 1;
                if ((int)reader["S4"] == 1)
                    bookings[3] = 1;
                if ((int)reader["S5"] == 1)
                    bookings[4] = 1;
                if ((int)reader["S6"] == 1)
                    bookings[5] = 1;
                if ((int)reader["S7"] == 1)
                    bookings[6] = 1;
                if ((int)reader["S8"] == 1)
                    bookings[7] = 1;
                if ((int)reader["S9"] == 1)
                    bookings[8] = 1;
                if ((int)reader["S10"] == 1)
                    bookings[9] = 1;
                if ((int)reader["S11"] == 1)
                    bookings[10] = 1;
                if ((int)reader["S12"] == 1)
                    bookings[11] = 1;
                if ((int)reader["S13"] == 1)
                    bookings[12] = 1;
            }
            reader.Close();

            foreach (int i in Selected)
                bookings[i - 1] = 0;

            cmdstr = "Update BusSeatDetails set S1=@s1, S2=@s2, S3=@s3, S4=@s4, S5=@s5, S6=@s6, S7=@s7, S8=@s8, S9=@s9, S10=@s10, S11=@s11,S12=@s12,S13=@s13 where BusId=@BusID";
            cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@s1", bookings[0]);
            cmd.Parameters.AddWithValue("@s2", bookings[1]);
            cmd.Parameters.AddWithValue("@s3", bookings[2]);
            cmd.Parameters.AddWithValue("@s4", bookings[3]);
            cmd.Parameters.AddWithValue("@s5", bookings[4]);
            cmd.Parameters.AddWithValue("@s6", bookings[5]);
            cmd.Parameters.AddWithValue("@s7", bookings[6]);
            cmd.Parameters.AddWithValue("@s8", bookings[7]);
            cmd.Parameters.AddWithValue("@s9", bookings[8]);
            cmd.Parameters.AddWithValue("@s10", bookings[9]);
            cmd.Parameters.AddWithValue("@s11", bookings[10]);
            cmd.Parameters.AddWithValue("@s12", bookings[11]);
            cmd.Parameters.AddWithValue("@s13", bookings[12]);
            cmd.Parameters.AddWithValue("@BusId", busId);
            cmd.ExecuteNonQuery();

            cmdstr = "delete from TicketDetails where BId=@BId";
            cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@BId", BId);
            cmd.ExecuteNonQuery();

            seats += SeatNos.Count();
            cmdstr = "Update BusDetails set SeatsAvailable=@SeatsAvailable where BusId=@BusId";
            cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@SeatsAvailable", seats);
            cmd.Parameters.AddWithValue("@BusId", busId);
            cmd.ExecuteNonQuery();

            cmdstr = "delete from Bookings where BId=@BId";
            cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@BId", BId);
            cmd.ExecuteNonQuery();
        }
        catch(Exception err) { lbl.Text = err.ToString(); }
        finally { con.Close(); }
    }
}