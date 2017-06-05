<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SQLMusicManagement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SQL MUSIC MANAGEMENT - LOGIN</title>
    <link rel="stylesheet" href="css/screen.css" type="text/css" media="screen" title="default" />
    <!--  jquery core -->
    <script src="js/jquery/jquery-1.4.1.min.js" type="text/javascript"></script>

    <!-- Custom jquery scripts -->
    <script src="js/jquery/custom_jquery.js" type="text/javascript"></script>

    <!-- MUST BE THE LAST SCRIPT IN <HEAD></HEAD></HEAD> png fix -->
    <script src="js/jquery/jquery.pngFix.pack.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).pngFix();
        });
    </script>
</head>

<body id="login-bg">
    <form id="form1" runat="server">
        <div id="login-holder">

            <!-- start logo -->
            <div id="logo-login">
                
            </div>
            <!-- end logo -->

            <div class="clear"></div>

            <!--  start loginbox ................................................................................. -->
            <div id="loginbox">

                <!--  start login-inner -->
                <div id="login-inner">

                    <div style="margin-bottom: 10px">
                        <asp:Label runat="server" ID="lblError" ForeColor="Red" Visible="false" Font-Italic="true"></asp:Label>                       
                    </div>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>Username</th>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="login-inp"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <th>Password</th>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="login-inp"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <th></th>
                            <td valign="top">
                                <input type="checkbox" class="checkbox-size" id="login-check" /><label for="login-check">Remember me</label></td>
                        </tr>
                        <tr>
                            <th></th>
                            <td>
                                <asp:Button ID="btn" runat="server" Text="Login" CssClass="submit-login" OnClick="btn_Click" /></td>
                        </tr>
                    </table>
                </div>
                <!--  end login-inner -->
                <div class="clear"></div>
            </div>
            <!--  end loginbox -->



        </div>
    </form>
</body>
</html>
