<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusDetailsView.aspx.cs" Inherits="BusDetailsView" MasterPageFile="~/MasterPage.master" Theme="Blue"%>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table style="text-align:center">
        <tr style="text-align:left">
            <td style="text-align:left" >
               <strong> <asp:Label ID="lblheat" runat="server" Text="Check Status Now!" Font-Size= "X-Large"  
                    ForeColor="#F7990D"></asp:Label>
                    </strong>
           <br /> </td>
        </tr>
    </table>
   
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <table>
                <!-- Main Table -->
                <tr>
                    <td class="auto-style1">
                        <!-- Left Table -->
                        <table style="border-collapse: collapse; border-spacing: 0px; padding:0px; width: 95%" border="0">
                            <tbody>
                                <tr>
                                    <!--Center -->
                                    <td style="text-align:center" class="style1">                                        
                                            <table style="margin-left: 122px; width: 328px; border-collapse:collapse; border-spacing: 0px; padding: 0px; text-align:center; height: 118px; z-index: 1; left: 33px; top: 70px; position: absolute; margin-top: 0px;"
                                                border="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="formtext" style="width:37%; height:27px">
                                                            From:
                                                        </td>
                                                        <td style="width: 63%; text-align:left; height:27px">
                                                            <asp:Label ID="from_ll" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formtext" style="width: 37%; height: 27px">
                                                            To:
                                                        </td>
                                                        <td style="width:63%; text-align:left; height:27px">
                                                                <asp:Label ID="to_ll" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formtext" style="width:37%; height:27px">
                                                            Depart on :
                                                        </td>
                                                        <td style="width:63%; text-align:left; height:27px">
                                                        <asp:Label ID="departon_ll" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formtext" style="width:37%; height:27px">
                                                           Depart Time :
                                                        </td>
                                                        <td style="width:63%; text-align:left; height:27px">
                                                            <asp:Label ID="departtime_ll" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formtext" style="height:27%; width:37%">
                                                            &nbsp; Arrive on:</td>
                                                        <td style="text-align:left; height:27px; width:63%">
                                                            &nbsp;<asp:Label ID="arriveon_ll" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formtext" style="height:27%; width:37%">
                                                            &nbsp; Arrive Time:</td>
                                                        <td style="text-align:left; height:27px; width:63%">
                                                            &nbsp;<asp:Label ID="arrivetime_ll" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formtext" style="height:27%; width:37%">
                                                            &nbsp; Cost:</td>
                                                        <td style="text-align:left; height:27px; width:63%">
                                                            &nbsp;<asp:Label ID="cost_ll" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                    </td>
                                    <!--Center Side End -->
                                    <!--Right Side open -->
                                    <td style="width:55%; padding-top:15px">
                                        <asp:Panel ID="pnl1" runat="server">
                                            <asp:Table border="0" ID="seattable" runat="server">
                                                <asp:TableRow>
                                                    <asp:TableCell ID="TableCell1" class="seatCell" valign="middle" runat="server">
                                                        <asp:ImageButton ID="s1" ImageUrl="~/Images/available_seat.jpg" runat="server" OnClick="seat_Click"/>s1</asp:TableCell>
                                                    <asp:TableCell ID="TableCell2" class="seatCell" valign="middle" runat="server">
                                                        <asp:ImageButton ID="s2" ImageUrl="~/Images/available_seat.jpg" runat="server" OnClick="seat_Click"/>s2</asp:TableCell>
                                                    <asp:TableCell ID="TableCell3" class="seatCell" valign="middle" runat="server">
                                                        <asp:ImageButton ID="s3" ImageUrl="~/Images/available_seat.jpg" runat="server" OnClick="seat_Click"/>s3</asp:TableCell>
                                                    <asp:TableCell ID="TableCell4" class="seatCell" valign="middle" runat="server">
                                                        <asp:ImageButton ID="s4" ImageUrl="~/Images/available_seat.jpg" runat="server" OnClick="seat_Click"/>s4</asp:TableCell>
                                                    <asp:TableCell ID="TableCell5" class="seatCell" valign="middle" runat="server">
                                                        <asp:ImageButton ID="s5" ImageUrl="~/Images/available_seat.jpg" runat="server" OnClick="seat_Click"/>s5</asp:TableCell>
                                                    <asp:TableCell ID="TableCell6" class="seatCell" valign="middle" runat="server">
                                                        <asp:ImageButton ID="s6" ImageUrl="~/Images/available_seat.jpg" runat="server" OnClick="seat_Click"/>s6</asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell ID="TableCell21" runat="server">&nbsp; </asp:TableCell>
                                                    <asp:TableCell ID="TableCell22" runat="server">&nbsp; </asp:TableCell>
                                                    <asp:TableCell ID="TableCell23" runat="server">&nbsp; </asp:TableCell>
                                                    <asp:TableCell ID="TableCell24" runat="server">&nbsp; </asp:TableCell>
                                                    <asp:TableCell ID="TableCell25" runat="server">&nbsp; </asp:TableCell>
                                                    <asp:TableCell ID="TableCell7" class="seatCell" valign="middle" runat="server">
                                                        <asp:ImageButton ID="s7" ImageUrl="~/Images/available_seat.jpg" runat="server" OnClick="seat_Click"/>s7</asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell ID="TableCell8" class="seatCell" valign="middle" runat="server">
                                                        <asp:ImageButton ID="s8" ImageUrl="~/Images/available_seat.jpg" runat="server" OnClick="seat_Click"/>s8</asp:TableCell>
                                                    <asp:TableCell ID="TableCell9" class="seatCell" valign="middle" runat="server">
                                                        <asp:ImageButton ID="s9" ImageUrl="~/Images/available_seat.jpg" runat="server" OnClick="seat_Click"/>s9</asp:TableCell>
                                                    <asp:TableCell ID="TableCell10" class="seatCell" valign="middle" runat="server">
                                                        <asp:ImageButton ID="s10" ImageUrl="~/Images/available_seat.jpg" runat="server" OnClick="seat_Click"/>s10</asp:TableCell>
                                                    <asp:TableCell ID="TableCell11" class="seatCell" valign="middle" runat="server">
                                                        <asp:ImageButton ID="s11" ImageUrl="~/Images/available_seat.jpg" runat="server" OnClick="seat_Click"/>s11</asp:TableCell>
                                                    <asp:TableCell ID="TableCell12" class="seatCell" valign="middle" runat="server">
                                                        <asp:ImageButton ID="s12" ImageUrl="~/Images/available_seat.jpg" runat="server" OnClick="seat_Click"/>s12</asp:TableCell>
                                                    <asp:TableCell ID="TableCell13" class="seatCell" valign="middle" runat="server">
                                                        <asp:ImageButton ID="s13" ImageUrl="~/Images/available_seat.jpg" runat="server" OnClick="seat_Click" />s13</asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
                                        </asp:Panel>
                                        <%--// Start--%>
                                        <table id="logoIndicator" runat="server"  >
                                        <tr><td>&nbsp;</td></tr>
                                            <tr style="text-align:center"><td style="width:125px">
                                                <asp:Label ID="status_ll" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Label ID="status_ll1" runat="server" Text="" Visible="false"></asp:Label>

                                                </td>
                                                <td>
                                                    <asp:Image ID="imgbo" ImageUrl="~/Images/booked_seat.jpg" runat="server" 
                                                        Height="23px" Width="31px" />
                                                    </td><td style="font-size:medium;color:Navy">
                                                    <asp:Literal ID ="litbooked" Text = "Booked" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:Image ID="imgav2" ImageUrl="~/Images/available_seat.jpg" runat="server" 
                                                        Height="23px" Width="31px" />
                                                    </td><td style="font-size:medium;color:Navy">
                                                    <asp:Literal ID ="Literal1" Text = "Available" runat="server" />
                                                </td>
                                                
                                            </tr>
                                        </table>
                                    </td>
                                    <!--Right Side End -->
                                </tr>
                            </tbody>
                        </table>
                        <!-- end of Center-->
                    </td>
                </tr>
            </table>
            <!-- Main Table End -->
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel runat="server" style="text-align:center">
                <asp:Button runat="server" ID="BookTicket" Text="BookMyBus!" OnClick="BookTicket_Click" />
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 1284px;
        }
        .auto-style2 {
            width: 1284px;
            height: 110px;
        }
    </style>
</asp:Content>

