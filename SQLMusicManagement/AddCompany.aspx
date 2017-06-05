<%@ Page Title="" Language="C#" MasterPageFile="~/sqlmusic.Master" AutoEventWireup="true" CodeBehind="AddCompany.aspx.cs" Inherits="SQLMusicManagement.AddCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add/Edit Company
    </h1>
    <asp:Panel ID="pnlSuccess" runat="server" style="margin-bottom:20px; margin-top:10px" Visible="false">
        <asp:Label ID="lblSuccess" runat="server" Text="Label added succcessfully" ForeColor="Green" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" style="margin-bottom:20px; margin-top:10px" Visible="false">
        <asp:Label ID="lblError" runat="server" Text="Company already exists" ForeColor="Red" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <div id="container" style="margin-top: 20px">
        <asp:HiddenField ID="hf" runat="server" />
        <span>Short Name</span><br />
        <asp:TextBox ID="txtcompany" runat="server" CssClass="inp-form"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqcomp" runat="server" ControlToValidate="txtcompany" ErrorMessage="Required" ></asp:RequiredFieldValidator>
        <br />
        <br />
        <span>Full Name</span><br />
        <asp:TextBox ID="txtFullName" runat="server" CssClass="inp-form"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullName" ErrorMessage="Required" ></asp:RequiredFieldValidator>
        <br />
        <br />
        <span>First-Play Display</span><br />
        <asp:DropDownList ID="ddlFirst" runat="server"  CssClass="inp-form" style="width:415px; height:32px">
            <asp:ListItem Text="Yes" Value="0">
            </asp:ListItem>
            <asp:ListItem Text="No" Value="1">
            </asp:ListItem>            
        </asp:DropDownList><br />
        <br />
        <asp:Button ID="btn" runat="server" Text="Submit" OnClick="btn_Click" CssClass="form-submit" />
        <asp:Button ID="btjcancel" runat="server" Text="Canecl" OnClick="btjcancel_Click" CssClass="form-reset" CausesValidation="false" />

    </div>
</asp:Content>
