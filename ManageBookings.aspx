<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageBookings.aspx.cs" Inherits="ManageBookings" MasterPageFile="~/MasterPage.master" Theme="Blue"%>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="css/GridViewStyle.css" rel="stylesheet" type="text/css"> 
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="Bus_GV" runat="server" DataSourceID="SqlDataSource1" AllowPaging="true" EnablePersistedSelection="true"
            DataKeyNames="BId" AutoGenerateColumns="false" OnRowCommand="Bus_GV_RowCommand" CssClass="mydatagrid"  PagerStyle-CssClass="pager" 
 RowStyle-CssClass="rows"  HeaderStyle-CssClass="headerGV" >
            <Columns>
                <asp:BoundField DataField="BId" HeaderText="Booking Id" />
                <asp:BoundField DataField="BusName" HeaderText="Bus Name" />
                <asp:BoundField DataField="Seats" HeaderText="Seats" />
                <asp:ButtonField ButtonType="Button" Text="Cancel" commandName="Cancel" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:BookMyBusDB %>" ProviderName="System.Data.SqlClient"
            SelectCommand="Select b.BId,b.Seats,bd.BusName from Bookings b join BusDetails bd on b.BusId = bd.BusId where b.UserId=@UserId">
            <SelectParameters>
                <asp:QueryStringParameter Name="UserId" QueryStringField="Uid"/>
            </SelectParameters>
        </asp:SqlDataSource>
         <asp:Label runat="server" ID="lbl"></asp:Label>
    </asp:Panel>
</asp:Content>