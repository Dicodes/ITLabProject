using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BusList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Bus_GV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Int32.Parse((string)e.CommandArgument);
        int busID = (int)Bus_GV.DataKeys[index].Values["BusId"];
        string url = "BusDetailsView.aspx?";
        url += "BusId=" + Server.UrlEncode(busID.ToString());
        Response.Redirect(url);
    }
}