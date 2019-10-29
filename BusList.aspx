<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusList.aspx.cs" Inherits="BusList" MasterPageFile="~/MasterPage.master" Theme="Blue"%>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="css/GridViewStyle.css" rel="stylesheet" type="text/css"> 
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="Bus_GV" runat="server" DataSourceID="SqlDataSource1" AllowSorting="true" AllowPaging="true" EnablePersistedSelection="true"
            DataKeyNames="BusId" AutoGenerateColumns="false" OnRowCommand="Bus_GV_RowCommand" CssClass="mydatagrid"  PagerStyle-CssClass="pager" 
 RowStyle-CssClass="rows"  HeaderStyle-CssClass="headerGV">
            <Columns>
                <asp:BoundField DataField ="BusId" HeaderText="Bus Id" SortExpression="BusId" />
                <asp:BoundField DataField="BusName" HeaderText="Bus Name" />
                <asp:BoundField DataField="CompanyName" HeaderText="Company" SortExpression="CompanyName" />
                <asp:BoundField DataField="FromPlace" HeaderText="From" />
                <asp:BoundField DataField="ToPlace" HeaderText="To" />
                <asp:BoundField DataField="ArriveTime" HeaderText="Arrival" />
                <asp:BoundField DataField="DepartTime" HeaderText="Departure" />
                <asp:ButtonField ButtonType="Button" Text="Book" commandName="Book" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:BookMyBusDB %>" ProviderName="System.Data.SqlClient"
            SelectCommand="SELECT BusId, BusName, CompanyName, FromPlace, ToPlace, DepartTime, ArriveTime, Cost FROM BusDetails WHERE FromPlace=@FromPlace AND ToPlace=@ToPlace">
            <SelectParameters>
                <asp:QueryStringParameter Name="FromPlace" QueryStringField="From"/>
                <asp:QueryStringParameter Name="ToPlace" QueryStringField="To"/> 
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
