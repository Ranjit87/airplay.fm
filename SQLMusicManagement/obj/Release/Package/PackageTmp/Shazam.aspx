﻿<%@ Page Title="" Language="C#" MasterPageFile="~/sqlmusic.Master" AutoEventWireup="true" CodeBehind="Shazam.aspx.cs" Inherits="SQLMusicManagement.Shazam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Import Songs
    </h1>
    <asp:Panel ID="pnlSuccess" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblSuccess" runat="server" Text="Songs added succcessfully" ForeColor="Green" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblError" runat="server" Text="Error occured." ForeColor="Red" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <div id="container" style="margin-top: 20px">
        <script type="text/javascript">
            function getName() {
                if (Page_ClientValidate()) {
                    var filename;

                    var fullPath = document.getElementById('<%= filename.ClientID %>').value;
                    var hf = document.getElementById('<%= hfname.ClientID %>');
                    if (fullPath) {

                        var startIndex = (fullPath.indexOf('\\') >= 0 ? fullPath.lastIndexOf('\\') : fullPath.lastIndexOf('/'));
                        filename = fullPath.substring(startIndex);
                        //alert(filename.indexOf('\\')); alert(filename.indexOf('/'));
                        if (filename.indexOf('\\') === 0 || filename.indexOf('/') === 0) {
                            filename = filename.substring(1);
                        }
                        hf.value = filename;
                        //document.getElementById('<%= filename.ClientID %>').value = "";
                    }
                }
            }
        </script>
        <asp:HiddenField ID="hfname" runat="server" />
        <span style="width:80px; float:left">Week</span>
        <asp:TextBox runat="server" ID="txtWeek"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqtxtWeek" runat="server" ControlToValidate="txtWeek" ErrorMessage="Required"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cmpValidtxtWeek" runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtWeek" ErrorMessage="Value must be a whole number" />
        <br /><br />
        <span style="width:80px; float:left">Year</span>
        <asp:TextBox runat="server" ID="txtYear"></asp:TextBox>
        <asp:RequiredFieldValidator ID="reqtxtYear" runat="server" ControlToValidate="txtYear" ErrorMessage="Required"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cmpValidtxtYear" runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtYear" ErrorMessage="Value must be a whole number" />
        <br /><br />
        <span style="width:80px; float:left">Import File</span>
        <asp:FileUpload ID="filename" runat="server" CssClass="inp-form"></asp:FileUpload>
        <asp:RequiredFieldValidator ID="reqFile" runat="server" ControlToValidate="filename" ErrorMessage="Required"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btn" runat="server" Text="Submit" CssClass="form-submit" OnClick="btn_Click" OnClientClick="getName()" />
        <asp:Button ID="btjcancel" runat="server" Text="Canecl" CssClass="form-reset" CausesValidation="false" OnClick="btjcancel_Click" />

    </div>
</asp:Content>
