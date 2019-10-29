<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Theme="sunset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-image: url('Images/bg.jpg');
            background-repeat: no-repeat;
            background-attachment: fixed;
        }
        .auto-style1 {
            position:absolute;
            width:100%;
            height: 100%;
        }
        .LeftPanel {
            position: relative;
            float:left;
            left:50px;
            top:40px;
            width:40%;
            height:60%;
        }
        .RightPanel {
            position: relative;
            float:right;
            right:50px;
            top:40px;
            width:40%;
            height:60%;
        }
        .user_style1 {
            position:absolute;
            left:45%;
            top:35%;
        }
        .pass_style1 {
            position:absolute;
            left:45%;
            top:45%;
        }
        .button_style1{
            position:absolute;
            left:40%;
            top:55%;
        }
        .user_ll_style1{
            position:absolute;
            left:30%;
            top:35%;
        }
        .pass_ll_style1{
            position:absolute;
            left:30%;
            top:45%;
        }
        .name_style2{
            position:absolute;
            top:25%;
            left:45%;
        }
        .name_ll_style2{
            position:absolute;
            top:25%;
            left:20%;
        }
        .user_style2{
            position:absolute;
            top:35%;
            left:45%;
        }
        .user_ll_style2{
            position:absolute;
            top:35%;
            left:20%;
        }
        .pass_style2{
            position:absolute;
            top:45%;
            left:45%;
        }
        .pass_ll_style2{
            position:absolute;
            top:45%;
            left:20%;
        }
        .rpass_style2{
            position:absolute;
            top:55%;
            left:45%;
        }
        .rpass_ll_style2{
            position:absolute;
            top:55%;
            left:20%;
        }
        .email_style2{
            position:absolute;
            top:65%;
            left:45%;
        }
        .email_ll_style2{
            position:absolute;
            top:65%;
            left:20%;
        }
        .contact_style2{
            position:absolute;
            top:75%;
            left:45%;
        }
        .contact_ll_style2{
            position:absolute;
            top:75%;
            left:20%;
        }
        .button_style2{
            position:absolute;
            top:85%;
            left:30%;
        }
        </style>
</head>
<body style="height: 456px">
    <form id="form1" runat="server">
    <div class="auto-style1">
        <asp:Panel ID="Panel1" runat="server" CssClass="LeftPanel">

            <asp:Label ID="pass_ll1" runat="server" Text="Password" CssClass="pass_ll_style1"></asp:Label>
            <asp:TextBox ID="user_tb1" runat="server" CssClass="user_style1" ></asp:TextBox>

            <asp:RequiredFieldValidator runat="server" ControlToValidate="user_tb1" ErrorMessage="Please Enter Name" Display="None" ValidationGroup="Login"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ControlToValidate="user_tb1" runat="server" ValidationGroup="Login" ErrorMessage="Enter only name" Display="None" ValidationExpression="[a-z A-Z]+"></asp:RegularExpressionValidator>

            <asp:TextBox ID="pass_tb1" runat="server" TextMode="Password" CssClass="pass_style1" ></asp:TextBox>

            <asp:RequiredFieldValidator runat="server" Display="None" ErrorMessage="Please Enter Password" ValidationGroup="Login" ControlToValidate="pass_tb1"></asp:RequiredFieldValidator>

            <asp:Button ID="login" runat="server" Text="Sign in" ValidationGroup="Login" CssClass="button_style1" OnClick="login_Click" />
            <asp:Label ID="user_ll1" runat="server" Text="Username" CssClass="user_ll_style1"></asp:Label>
            <asp:ValidationSummary runat="server" ValidationGroup="Login" ShowMessageBox="true" ShowSummary="false" />
        </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" CssClass="RightPanel">
            <asp:Label ID="name_ll2" runat="server" Text="Name" CssClass="name_ll_style2"></asp:Label>
            <asp:TextBox ID="name_tb2" runat="server" CssClass="name_style2"></asp:TextBox>
            <asp:Label ID="user_ll2" runat="server" Text="Username" CssClass="user_ll_style2"></asp:Label>
            <asp:TextBox ID="user_tb2" runat="server" CssClass="user_style2"></asp:TextBox>
            <asp:Label ID="pass_ll2" runat="server" Text="Password" CssClass="pass_ll_style2"></asp:Label>
            <asp:TextBox ID="pass_tb2" runat="server" TextMode="Password" CssClass="pass_style2"></asp:TextBox>
            <asp:Label ID="rpass_ll2" runat="server" Text="Re-enter Password" CssClass="rpass_ll_style2"></asp:Label>
            <asp:TextBox ID="rpass_tb2" runat="server" TextMode="Password" CssClass="rpass_style2"></asp:TextBox>
            <asp:Label ID="email_ll2" runat="server" Text="Email-id" CssClass="email_ll_style2"></asp:Label>
            <asp:TextBox ID="email_tb2" runat="server" CssClass="email_style2"></asp:TextBox>
            <asp:Label ID="contact_ll2" runat="server" Text="Contact" CssClass="contact_ll_style2"></asp:Label>
            <asp:TextBox ID="contact_tb2" runat="server" CssClass="contact_style2"></asp:TextBox>

            <asp:Button ID="signup" runat="server" Text="Sign Up" CssClass="button_style2" ValidationGroup="signup" OnClick="signup_Click"/>

            <asp:RequiredFieldValidator runat="server" ControlToValidate="name_tb2" ValidationGroup="signup" Display="None" ErrorMessage="Name is required"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="user_tb2" ValidationGroup="signup" Display="None" ErrorMessage="Username is required"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="email_tb2" ValidationGroup="signup" Display="None" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="contact_tb2" ValidationGroup="signup" Display="None" ErrorMessage="Contact is required"></asp:RequiredFieldValidator>

            <asp:RequiredFieldValidator runat="server" ControlToValidate="pass_tb2" ValidationGroup="signup" Display="None" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="rpass_tb2" ValidationGroup="signup" Display="None" ErrorMessage="Password doesn't match"></asp:RequiredFieldValidator>

            <asp:CompareValidator runat="server" ValidationGroup="signup" ControlToValidate="rpass_tb2" ControlToCompare="pass_tb2" ErrorMessage="Password does not match" Display="None"></asp:CompareValidator>

            <asp:RegularExpressionValidator runat="server" ValidationGroup="signup" ControlToValidate="user_tb2" ValidationExpression="[a-z A-Z]+" ErrorMessage="Invalid username" Display="None"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator runat="server" ValidationGroup="signup" ControlToValidate="email_tb2" ValidationExpression="[a-zA-Z0-9]+@[a-zA-Z]+\.[a-zA-Z]+" ErrorMessage="Invalid email" Display="None"></asp:RegularExpressionValidator>
            <asp:RegularExpressionValidator runat="server" ValidationGroup="signup" ControlToValidate="contact_tb2" ValidationExpression="[0-9]{10}" ErrorMessage="Invalid contact" Display="None"></asp:RegularExpressionValidator>

           <%-- <asp:RegularExpressionValidator runat="server" ValidationGroup="signup" ControlToValidate="pass_tb2" ValidationExpression="\w{4-10}" ErrorMessage="Password must be 4-10 characters long" Display="None"></asp:RegularExpressionValidator>--%>

            <asp:ValidationSummary runat="server" ValidationGroup="signup" ShowMessageBox="true" ShowSummary="false" />
         </asp:Panel>           
        <asp:Image ID="Image1" runat="server" ImageUrl="Images/logo.png" style="z-index: 1; left: 380px; top: 7px; position: absolute"/>
    </div>
        
    </form>
</body>
</html>
