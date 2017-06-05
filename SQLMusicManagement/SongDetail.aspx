<%@ Page Title="" Language="C#" MasterPageFile="~/sqlmusic.Master" AutoEventWireup="true" CodeBehind="SongDetail.aspx.cs" Inherits="SQLMusicManagement.SongDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSuccess" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblSuccess" runat="server" Text="Label added succcessfully" ForeColor="Green" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblError" runat="server" Text="Please select a file first" ForeColor="Red" Font-Italic="true"></asp:Label>
    </asp:Panel>
    
    <asp:ToolkitScriptManager ID="sm" runat="server"></asp:ToolkitScriptManager>
    <div id="container" style="margin-top: 20px; margin-left: 20px">
        <h1>Song Details</h1>
        <br /><br />
        <div style="float: left; width: 100%; margin-bottom: 20px">
            <div style="float:left; width:100px">
            <span style="font-weight: bold">Artist:</span> </div>
            <asp:Label ID="lblArtist" runat="server"></asp:Label>
            <br />
            <br />
            <div style="float:left; width:100px">
            <span style="font-weight: bold">Title:</span> </div>
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
            <br />
            <br />
            <div style="float:left; width:100px">
            <span style="font-weight: bold">Author:</span> </div>
            <asp:Label ID="lblAuthor" runat="server"></asp:Label>
            <br />
            <br />
            <div style="float:left; width:100px">
            <span style="font-weight: bold">Publisher:</span> </div>
            <asp:Label ID="lblPublisher" runat="server"></asp:Label>
            <br />
            <br />
            <div style="float:left; width:100px">
            <span style="font-weight: bold">Label:</span> </div>
            <asp:Label ID="lblLabel" runat="server"></asp:Label>
            <br />
            <br />
            <div style="float:left; width:100px">
            <span style="font-weight: bold">Company:</span> </div>
            <asp:Label ID="lblCompany" runat="server"></asp:Label>
            <br />
            <br />
        </div>
        <hr />
        <div style="float: left; width: 100%; margin-top: 20px">
            <div style="width: 40%; float: left">
                <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" BorderWidth="0px" OnRowDataBound="grd_RowDataBound" OnRowCommand="grd_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="File Name">
                            <ItemTemplate>
                                <asp:HiddenField ID="hf" runat="server" Value='<%# Eval("IdSong") %>' />
                                <asp:LinkButton ID="lnk" runat="server" Text='<%# Eval("FileName") %>' CommandName="_select" CommandArgument='<%# Eval("IdSong") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div style="width: 60%; float: left">
                <div style="border-bottom: 1px solid black; width: 90px"><span>Version Details</span></div>
                <br />
                <asp:HiddenField ID="hf" runat="server" />
                <asp:HiddenField ID="hfprevid" runat="server" />
                <div style="float:left; width:100px">
                <span style="font-weight: bold">Version:</span> </div>
            <asp:TextBox ID="lblVersion" runat="server" ValidationGroup="Version" CssClass="inp-form"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv" runat="server" ErrorMessage="Required" ControlToValidate="lblVersion" ValidationGroup="Version"></asp:RequiredFieldValidator>
                <br />
                <br />
                <div style="float:left; width:100px">
                <span style="font-weight: bold">Duration:</span> </div>
            <asp:TextBox ID="lblDuration" runat="server" CssClass="inp-form"></asp:TextBox>
                <br />
                <br />
                <div style="float:left; width:100px">
                <span style="font-weight: bold">ISRC:</span> </div>
            <asp:TextBox ID="lblISRC" runat="server" CssClass="inp-form"></asp:TextBox>
                <br />
                <br />
                <div style="float:left; width:100px">
                <span style="font-weight: bold">Radio Date:</span> </div>
            <asp:TextBox ID="lblRadio" runat="server" CssClass="inp-form"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="lblRadio" Format="dd/MM/yyyy"></asp:CalendarExtender>
                <br />
                <br />
                <div style="float:left; width:100px">
                <span style="font-weight: bold">Genre:</span> </div>
            <asp:TextBox ID="lblGenre" runat="server" CssClass="inp-form"></asp:TextBox><br />
                <br />
                <div style="float:left; width:100px">
                <span style="font-weight: bold">Language:</span> </div>
            <asp:TextBox ID="lblLanguage" runat="server" CssClass="inp-form"></asp:TextBox><br />
                <br />
                <div style="float:left; width:100px">
                <span style="font-weight: bold">TvShow:</span> </div>
            <asp:TextBox ID="lblTvShow" runat="server" CssClass="inp-form"></asp:TextBox><br />
                <br />
                <span style="font-weight: bold">Absolute Beginners:</span> &nbsp;&nbsp;            
            <asp:CheckBox ID="chkAbsoluteBegin" runat="server" />
                <br />
                <br />
                <span style="font-weight: bold">Alternative Charts:</span> &nbsp;&nbsp;            
            <asp:CheckBox ID="chkAlternativeCharts" runat="server" />
                <br />
                <br />
                <span style="font-weight: bold">First Plays View:</span> &nbsp;&nbsp;
            <asp:CheckBox ID="chkFirstPlay" runat="server"></asp:CheckBox><br />
                <br />
            </div>
        </div>

        <asp:Panel ID="pnlButtons" runat="server" Visible="false">
            <asp:Button ID="btnHome" runat="server" Text="Home" Style="padding: 5px" OnClick="btnHome_Click" />
            <asp:Button ID="AddNewVersion" runat="server" Text="Add New Version" Style="padding: 5px" OnClick="AddNewVersion_Click" />
            <asp:Button ID="EditSong" runat="server" Text="Edit Song" Style="padding: 5px" OnClick="EditSong_Click" />
        </asp:Panel>
        <asp:Panel ID="pnlSave" runat="server" Visible="false">
            <script type="text/javascript">
                function getName() {
                    if (Page_ClientValidate()) {
                        var filename;

                        var fullPath = document.getElementById('<%= uploadfile.ClientID %>').value;
                        var hf = document.getElementById('<%= hfname.ClientID %>');
                        if (fullPath) {
                            var startIndex = (fullPath.indexOf('\\') >= 0 ? fullPath.lastIndexOf('\\') : fullPath.lastIndexOf('/'));
                            filename = fullPath.substring(startIndex);
                            if (filename.indexOf('\\') === 0 || filename.indexOf('/') === 0) {
                                filename = filename.substring(1);
                            }
                            hf.value = filename;
                            document.getElementById('<%= uploadfile.ClientID %>').value = "";
                        }
                    }
                }
            </script>
            <asp:FileUpload ID="uploadfile" Style="padding: 5px" runat="server" />
            <asp:HiddenField ID="hfname" runat="server" />
            <asp:Button ID="btnUpload" runat="server" Text="Add Version" Style="padding: 5px" OnClick="btnUpload_Click" OnClientClick="getName()" /><br />
            <br />
            <asp:Button ID="btnSave" runat="server" Text="Save New Version(s) to SQL" Style="padding: 5px" OnClick="btnSave_Click" ValidationGroup="Version" />
        </asp:Panel>
    </div>
</asp:Content>
