<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateDetails.aspx.cs" Inherits="UpdateDetails" MasterPageFile="~/MasterPage2.master" Theme="Blue"%>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <link href="css/GridViewStyle.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <asp:SqlDataSource runat="server" ID="DS1" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings: BookMyBusDB %>" SelectCommand="Select * from BusDetails" UpdateCommand="Update BusDetails set Cost=@Cost where BusId=@BusId">
    </asp:SqlDataSource>

    <asp:GridView runat="server" ID="GV" DataSourceID="DS1" DataKeyNames="BusId" AutoGenerateColumns="false" AutoGenerateEditButton="true" CssClass="mydatagrid"  PagerStyle-CssClass="pager" 
 RowStyle-CssClass="rows"  HeaderStyle-CssClass="headerGV">
        <Columns>
            <asp:BoundField DataField="BusId" HeaderText="Bus Id" ReadOnly="true" />
            <asp:BoundField DataField="BusName" HeaderText="Bus Name" ReadOnly="true"/>
            <asp:BoundField DataField="CompanyName" HeaderText="Company Name" ReadOnly="true" />
            <asp:BoundField DataField="FromPlace" HeaderText="From" ReadOnly="true"/>
            <asp:BoundField DataField="ToPlace" HeaderText="To" ReadOnly="true"/>
            <asp:BoundField DataField="DepartTime" HeaderText="Departure Time" ReadOnly="true" />
            <asp:BoundField DataField="ArriveTime" HeaderText="Arrival Time" ReadOnly="true"/>
            <asp:BoundField DataField="Cost" HeaderText="Cost" />
        </Columns>
    </asp:GridView>
</asp:Content>


