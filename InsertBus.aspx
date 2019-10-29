<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertBus.aspx.cs" Inherits="InsertBus" MasterPageFile="~/MasterPage2.master" Theme="Blue"%>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel runat="server" style="text-align:center">
        <asp:Label ID="Label1" runat="server" Text="Bus Name: "/><asp:TextBox runat="server" ID="busName" style="margin-left: 37px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Company Name: "/><asp:TextBox runat="server" ID="companyName"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="Label3" runat="server" Text="From: "/> <asp:TextBox runat="server" ID="fromPlace" style="margin-left: 68px"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="Label4" runat="server" Text="To: " />
        <asp:TextBox runat="server" ID="toPlace" style="margin-left: 83px"></asp:TextBox>       
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Depart date(YYYY-MM-DD): "/> <asp:TextBox runat="server" ID="ddate"></asp:TextBox>
        <asp:Label ID="Label6" runat="server" Text="Depart Time(hh:mm:ss): "/> <asp:TextBox runat="server" ID="dtime"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Arrive Date(YYYY-MM-DD): "/> <asp:TextBox runat="server" ID="adate"></asp:TextBox>
        <asp:Label ID="Label8" runat="server" Text="Arrive Time(hh:mm:ss): "/> <asp:TextBox runat="server" ID="atime"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Text="Cost: "/> <asp:TextBox runat="server" ID="cost" style="margin-left: 70px"></asp:TextBox>
        <br />
        <br />
        <asp:Button runat="server" ID="insert" Text="Insert" OnClick="insert_Click" />
        <asp:Label runat="server" ID="ll" Visible="false"></asp:Label>

    </asp:Panel>
</asp:Content>

