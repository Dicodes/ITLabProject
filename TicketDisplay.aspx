<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TicketDisplay.aspx.cs" Inherits="TicketDisplay" MasterPageFile="~/MasterPage.master" Theme="Blue" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        .label{
            font-family:Candara;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <asp:Panel runat="server" style="text-align:center" BorderStyle="Solid" BackColor="#66ccff" >

        <asp:Label ID="Label1" runat="server" CssClass="label" Text="Booking Id: "/> <asp:Label ID="BId" runat="server" CssClass="label"/>
        <br />
        <asp:Label ID="Label2" runat="server" CssClass="label" Text="Seat No: "/> <asp:Label ID="seatNos" runat="server" Font-Names="Candara"/>
        <br />
        <asp:Label ID="Label3" runat="server" CssClass="label" Text="Bus Company: "/> <asp:Label runat="server" ID="BusCompany" Font-Names="Candara"/>
        <br />
        <asp:Label ID="Label4" runat="server" CssClass="label" Text="Boarding: "/> <asp:Label runat="server" ID="fromPlace" Font-Names="Candara"/>
        <br />
        <asp:Label ID="Label5" runat="server" CssClass="label" Text="Date of Departure: "/> <asp:Label runat="server" ID="departOn" Font-Names="Candara" />
        <br />
        <asp:Label ID="Label6" runat="server" CssClass="label" Text="Departure time: "/> <asp:Label runat="server" ID="deptTime" Font-Names="Candara"/>
        <br />
        <asp:Label ID="Label7" runat="server" CssClass="label" Text="Cost: "/> <asp:Label ID="Cost" runat="server" Text="Rs." Font-Names="Candara"/>


    </asp:Panel>
</asp:Content>


