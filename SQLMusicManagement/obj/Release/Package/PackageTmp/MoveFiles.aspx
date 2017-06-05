<%@ Page Title="" Language="C#" MasterPageFile="~/sqlmusic.Master" AutoEventWireup="true" CodeBehind="MoveFiles.aspx.cs" Inherits="SQLMusicManagement.MoveFiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add/Edit Labels
    </h1>
    <asp:Panel ID="pnlSuccess" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblSuccess" runat="server" Text="Label added succcessfully" ForeColor="Green" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblError" runat="server" Text="Title already exists" ForeColor="Red" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <div id="container" style="margin-top: 20px">
        <asp:HiddenField ID="hf" runat="server" />
        <span>Folder Path</span><br />
        <asp:TextBox ID="txtFolderPath" runat="server" style="width:400px  !Important;height: 25px;padding: 6px 6px 0 6px;"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqcomp" runat="server" ControlToValidate="txtFolderPath" ErrorMessage="Required"></asp:RequiredFieldValidator>
        <br />
        <br />
        
        <asp:Button ID="btn" runat="server" Text="Move all files to drop box" style="padding:5px" OnClick="btn_Click" />

    </div>
</asp:Content>
