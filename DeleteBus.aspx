<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteBus.aspx.cs" Inherits="DeleteBus" MasterPageFile="~/MasterPage2.master" Theme="Blue" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel runat="server" style="text-align:center">
        <asp:SqlDataSource runat="server" ID="DS" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings: BookMyBusDB %>" SelectCommand="Select * from BusDetails"></asp:SqlDataSource>

            <asp:GridView runat="server" ID="GV" DataSourceID="DS" DataKeyNames="BusId" AutoGenerateColumns="false" OnRowCommand="GV_RowCommand">
        <Columns>
            <asp:BoundField DataField="BusId" HeaderText="Bus Id"/>
            <asp:BoundField DataField="BusName" HeaderText="Bus Name" />
            <asp:BoundField DataField="CompanyName" HeaderText="Company Name"/>
            <asp:BoundField DataField="FromPlace" HeaderText="From" />
            <asp:BoundField DataField="ToPlace" HeaderText="To" />
            <asp:BoundField DataField="DepartTime" HeaderText="Departure Time"  />
            <asp:BoundField DataField="ArriveTime" HeaderText="Arrival Time" />
            <asp:BoundField DataField="Cost" HeaderText="Cost"/>
            <asp:ButtonField ButtonType="Button" Text="Delete" commandName="Cancel" />

        </Columns>
    </asp:GridView>
        <asp:Label ID="lbl" runat="server"></asp:Label>
    </asp:Panel>
</asp:Content>
