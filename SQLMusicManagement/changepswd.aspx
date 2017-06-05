<%@ Page Title="" Language="C#" MasterPageFile="~/sqlmusic.Master" AutoEventWireup="true" CodeBehind="changepswd.aspx.cs" Inherits="SQLMusicManagement.changepswd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Change Password
    </h1>
    <asp:Panel ID="pnlSuccess" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblSuccess" runat="server" Text="Password changed succcessfully" ForeColor="Green" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblError" runat="server" Text="Old password is incorrect" ForeColor="Red" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <div id="container" style="margin-top: 20px">
        <asp:HiddenField ID="hf" runat="server" />
        <span>Old Password</span><br />
        <asp:TextBox ID="txtOld" runat="server" CssClass="inp-form" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqcomp" runat="server" ControlToValidate="txtOld" ErrorMessage="Required"></asp:RequiredFieldValidator>
        <br />
        <br />
        <span>New Password</span><br />
        <asp:TextBox ID="txtNew" runat="server" CssClass="inp-form" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNew" ErrorMessage="Required"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtNew" ControlToCompare="txtConfirm" ErrorMessage="Password doesn't match"></asp:CompareValidator>
        <br />
        <br />
        <span>Confirm New Password</span><br />
        <asp:TextBox ID="txtConfirm" runat="server" CssClass="inp-form" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfirm" ErrorMessage="Required"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="sswd" runat="server" ControlToValidate="txtConfirm" ControlToCompare="txtNew" ErrorMessage="Password doesn't match"></asp:CompareValidator>
        <br />
        <br />
        <asp:Button ID="btn" runat="server" Text="Submit" OnClick="btn_Click" CssClass="form-submit" />
        <asp:Button ID="btjcancel" runat="server" Text="Canecl" OnClick="btjcancel_Click" CssClass="form-reset" CausesValidation="false" />

    </div>
</asp:Content>
