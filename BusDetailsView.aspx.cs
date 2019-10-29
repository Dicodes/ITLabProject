using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BusDetailsView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        DataSet Bus_ds = new DataSet();
        DataSet Seat_ds = new DataSet();
        if (!IsPostBack)
        {
            string busId = Request.QueryString["BusId"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["BookMyBusDB"].ConnectionString;
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM BusDetails WHERE BusId=@BusId", con);
            cmd1.Parameters.AddWithValue("@BusId", busId);
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM BusSeatDetails WHERE BusId=@BusId", con);
            cmd2.Parameters.AddWithValue("@BusId", busId);
            try
            {
                con.Open();
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd1);
                SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
                adapter1.Fill(Bus_ds, "BusDetails");

                adapter2.Fill(Seat_ds, "BusSeatDetails");
            }
            catch(Exception err) { }
            finally{ con.Close(); }
            from_ll.Text = Bus_ds.Tables["BusDetails"].Rows[0]["FromPlace"].ToString();
            to_ll.Text = Bus_ds.Tables["BusDetails"].Rows[0]["ToPlace"].ToString();
            departon_ll.Text = Bus_ds.Tables["BusDetails"].Rows[0]["DepartTime"].ToString().Split()[0];
            departtime_ll.Text = Bus_ds.Tables["BusDetails"].Rows[0]["DepartTime"].ToString().Split()[1];
            arriveon_ll.Text = Bus_ds.Tables["BusDetails"].Rows[0]["ArriveTime"].ToString().Split()[0];
            arrivetime_ll.Text = Bus_ds.Tables["BusDetails"].Rows[0]["ArriveTime"].ToString().Split()[1];
            cost_ll.Text = Bus_ds.Tables["BusDetails"].Rows[0]["Cost"].ToString();



            for (int i = 1; i <= 13; i++)
            {
                string seatnos = "s" + i.ToString();
                if (Seat_ds.Tables["BusSeatDetails"].Rows[0][seatnos].ToString() == "1")
                {
                    //from_ll.Text = seatnos;
                    ImageButton seat_button = (ImageButton)this.Master.FindControl("ContentPlaceHolder1").FindControl(seatnos);
                    seat_button.ImageUrl = @"~/Images/booked_seat.jpg";
                }
            }

        }

    }

    protected void seat_Click(object sender, EventArgs e)
    {
        ImageButton seat = (ImageButton)sender;
        if (seat.ImageUrl == "~/Images/booked_seat.jpg")
        {
            status_ll1.Visible = true;
            status_ll.Visible = false;
            status_ll1.Text = "Seat not available";
        }
        else if(seat.ImageUrl == "~/Images/available_seat.jpg")
        {
            seat.ImageUrl = "~/Images/selected_seat.jpg";
            status_ll1.Visible = false;
            status_ll.Visible = true;
            status_ll.Text += seat.ID.ToString()+" ";
        }
        else if(seat.ImageUrl == "~/Images/selected_seat.jpg")
        {
            seat.ImageUrl = "~/Images/available_seat.jpg";
            string txt = status_ll.Text;
            txt = txt.Substring(0, txt.Length - 3);
            status_ll1.Visible = false;
            status_ll.Visible = true;
            status_ll.Text = txt;
        }
        
    }

    protected void BookTicket_Click(object sender, EventArgs e)
    {
        List<int> bookings = new List<int>(new int[13]);
        int Seats = 0;
        string selected = status_ll.Text;
        string sno="";
        List<string> seatNos = new List<string>();
        for(int i=0;i<selected.Length;i++)
        {
            if(Char.IsDigit(selected[i]))
            {
                if (Char.IsDigit(selected[i+1]))
                {
                    string num = selected[i].ToString() + selected[i + 1].ToString();
                    int index = int.Parse(num);
                    bookings[index - 1] = 1;
                    sno += selected[i].ToString();
                    i = i + 1;
                }
                else
                {

                    int index = int.Parse(selected[i].ToString());
                    bookings[index - 1] = 1;

                }
                Seats += 1;
            }

            if (selected[i]==' ')
            {
                seatNos.Add(sno);
                sno = "";
            }
            else
            sno += Char.ToUpper(selected[i]);


        }

        if (Seats == 0)
        {
            status_ll.Text = "Please select a seat";
            return;
        }

        HttpCookie cookie = Request.Cookies["User"];

        int userId = int.Parse(cookie["UserId"]);
        int busId = int.Parse(Request.QueryString["BusId"]);
        int bookingId = 0;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = WebConfigurationManager.ConnectionStrings["BookMyBusDB"].ConnectionString;
        try
        {
            con.Open();

            string cmdstr = "Select SeatsAvailable from BusDetails where BusId=@BusId";
            SqlCommand cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@BusId", busId);
            SqlDataReader reader;
            int currentSeats = 13;
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                currentSeats = int.Parse(reader["SeatsAvailable"].ToString());
            }
            reader.Close();

            cmdstr = "Update BusDetails Set SeatsAvailable=@Seats where BusId=@BusId";
            cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@Seats", currentSeats - Seats);
            cmd.Parameters.AddWithValue("@BusId", busId);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertBooking";
            cmd.Connection = con;

            SqlParameter BId = cmd.Parameters.Add("@BId", SqlDbType.Int);
            BId.Direction = ParameterDirection.Output;

            SqlParameter UserId = cmd.Parameters.Add("@UserId", SqlDbType.Int);
            UserId.Value = userId;

            SqlParameter BusId = cmd.Parameters.Add("@BusId", SqlDbType.Int);
            BusId.Value = busId;

            SqlParameter seats = cmd.Parameters.Add("@Seats", SqlDbType.Int);
            seats.Value = Seats;

            cmd.ExecuteNonQuery();

            bookingId = Convert.ToInt32(cmd.Parameters["@BId"].Value);

            

            for(int i=0;i< Seats;i++)
            {
                cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertTicketDetails";
                cmd.Connection = con;

                SqlParameter TicketId = cmd.Parameters.Add("@TicketId", SqlDbType.Int);
                TicketId.Direction = ParameterDirection.Output;

                SqlParameter UId = cmd.Parameters.Add("@UserId", SqlDbType.Int);
                UId.Value = userId;

                SqlParameter Bid = cmd.Parameters.Add("@BId", SqlDbType.Int);
                Bid.Value = bookingId;

                SqlParameter SeatNo = cmd.Parameters.Add("@SeatNo", SqlDbType.VarChar);
                SeatNo.Value = seatNos[i];

                cmd.ExecuteNonQuery();

            }

            cmdstr = "Select S1, S2, S3, S4, S5, S6, S7, S8, S9, S10, S11, S12, S13 from BusSeatDetails where BusId=@BusId";
            cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@BusId", busId);
            reader = cmd.ExecuteReader();
            while(reader.Read())
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

            cmdstr = "Update BusSeatDetails set S1=@S1, S2=@S2, S3=@S3, S4=@S4, S5=@S5, S6=@S6, S7=@S7, S8=@S8, S9=@S9, S10=@S10, S11=@S11, S12=@S12, S13=@S13 where BusId=@BusId";
            cmd = new SqlCommand(cmdstr, con);
            cmd.Parameters.AddWithValue("@S1", bookings[0]);
            cmd.Parameters.AddWithValue("@S2", bookings[1]);
            cmd.Parameters.AddWithValue("@S3", bookings[2]);
            cmd.Parameters.AddWithValue("@S4", bookings[3]);
            cmd.Parameters.AddWithValue("@S5", bookings[4]);
            cmd.Parameters.AddWithValue("@S6", bookings[5]);
            cmd.Parameters.AddWithValue("@S7", bookings[6]);
            cmd.Parameters.AddWithValue("@S8", bookings[7]);
            cmd.Parameters.AddWithValue("@S9", bookings[8]);
            cmd.Parameters.AddWithValue("@S10", bookings[9]);
            cmd.Parameters.AddWithValue("@S11", bookings[10]);
            cmd.Parameters.AddWithValue("@S12", bookings[11]);
            cmd.Parameters.AddWithValue("@S13", bookings[12]);
            cmd.Parameters.AddWithValue("@BusId", busId);
            cmd.ExecuteNonQuery();
        }
        catch(Exception err) { status_ll.Text = err.ToString(); }
        finally { con.Close(); }

        string url = "TicketDisplay.aspx?";
        url += "BId=" + Server.UrlEncode(bookingId.ToString());
        Response.Redirect(url);


    }
}