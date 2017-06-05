<%@ Page Title="" Language="C#" MasterPageFile="~/sqlmusic.Master" AutoEventWireup="true" CodeBehind="Recognized.aspx.cs" Inherits="SQLMusicManagement.Recognized" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Import Recognized
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
        <span>Import File</span><br />
        <asp:FileUpload ID="filename" runat="server" CssClass="inp-form"></asp:FileUpload>
        <asp:RequiredFieldValidator ID="reqFile" runat="server" ControlToValidate="filename" ErrorMessage="Required"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btn" runat="server" Text="Submit" CssClass="form-submit" OnClick="btn_Click" OnClientClick="getName()" />
        <asp:Button ID="btjcancel" runat="server" Text="Canecl" CssClass="form-reset" CausesValidation="false" OnClick="btjcancel_Click" />
    </div>
    <div id="Div1" runat="server" style="float: left; width: 100%; display: none">
        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" CssClass="Grid"
            Style="font-weight: bold; width: 100%" AllowPaging="True" OnPageIndexChanging="grd_PageIndexChanging" AllowSorting="False"
            EmptyDataText="No Record Found" PageSize="1000" OnDataBound="grd_DataBound">
            <Columns>
                <asp:TemplateField SortExpression="IdSong" HeaderText="Id Song">
                    <ItemTemplate>
                        <asp:Label ID="IdSong" runat="server" Text='<%#Eval("IdSong") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="16%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="IdRadio" HeaderText="Id Radio">
                    <ItemTemplate>
                        <asp:Label ID="IdRadio" runat="server" Text='<%#Eval("IdRadio") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="16%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="FingerprintingTime" HeaderText="FingerprintingTime">
                    <ItemTemplate>
                        <asp:Label ID="FingerprintingTime" runat="server" Text='<%#Eval("FingerprintingTime") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="17%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="FingerprintingDetails" HeaderText="FingerprintingDetails">
                    <ItemTemplate>
                        <asp:Label ID="FingerprintingDetails" runat="server" Text='<%#Eval("FingerprintingDetails") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="17%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="Point" HeaderText="Point">
                    <ItemTemplate>
                        <asp:Label ID="Point" runat="server" Text='<%#Eval("Point") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="17%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="ParentSongId" HeaderText="ParentSongId">
                    <ItemTemplate>
                        <asp:Label ID="ParentSongId" runat="server" Text='<%#Eval("ParentSongId") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="17%" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div>
            <asp:ImageButton ID="imgPageFirst" runat="server" Style="float: left; padding: 5px;"
                AlternateText="First"
                CommandArgument="First" CausesValidation="false" CommandName="Page"
                OnCommand="imgPageFirst_Command"></asp:ImageButton>
            <asp:ImageButton ID="imgPagePrevious" Style="float: left; padding: 5px;"
                runat="server" AlternateText="Previous"
                CommandArgument="Prev" CausesValidation="false" CommandName="Page"
                OnCommand="imgPagePrevious_Command"></asp:ImageButton>
            <asp:DropDownList ID="ddCurrentPage" runat="server" Style="float: left; margin-top: 5px"
                CssClass="Normal" AutoPostBack="True"
                OnSelectedIndexChanged="ddCurrentPage_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Label ID="lblOf" runat="server" Text="of" CssClass="Normal" Style="float: left; padding: 5px;"></asp:Label>
            <asp:Label ID="lblTotalPage" runat="server" CssClass="Normal" Style="float: left; padding: 5px;"></asp:Label>
            <asp:ImageButton ID="imgPageNext" runat="server" Style="float: left; padding: 5px;"
                AlternateText="Next" CausesValidation="false"
                CommandArgument="Next" CommandName="Page"
                OnCommand="imgPageNext_Command"></asp:ImageButton>
            <asp:ImageButton ID="imgPageLast" runat="server" Style="float: left; padding: 5px;"
                AlternateText="Last" CausesValidation="false"
                CommandArgument="Last" CommandName="Page"
                OnCommand="imgPageLast_Command"></asp:ImageButton>
        </div>
    </div>
    <div id="divBtnSave" style="float: left; width: 100%; display: none" runat="server">
        <br />
        <br />
        <asp:Button ID="btnSaveData" runat="server" Text="Save" Style="padding: 10px" CausesValidation="false" OnClientClick="if ( ! deleteConfirmation()) return false;" OnClick="btnSaveData_Click" />
        <br />
        <br />
        <br />
    </div>
    <script type="text/javascript">
        function deleteConfirmation() {
            return confirm("Are you sure you want to save this record?");
        }

    </script>
    <style>
        .Grid {
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
            font-family: Calibri;
            color: #474747;
        }

            .Grid td {
                padding: 2px;
                border: solid 1px #c1c1c1;
            }

            .Grid th {
                padding: 4px 2px;
                color: #fff;
                background: #363670 url(Images/grid-header.png) repeat-x top;
                border-left: solid 1px #525252;
                font-size: 0.9em;
            }

                .Grid th a {
                    color: #fff;
                }

            .Grid .alt {
                background: #fcfcfc url(Images/grid-alt.png) repeat-x top;
            }

            .Grid .pgr {
                background: #363670 url(Images/grid-pgr.png) repeat-x top;
            }

                .Grid .pgr table {
                    margin: 3px 0;
                }

                .Grid .pgr td {
                    border-width: 0;
                    padding: 0 6px;
                    border-left: solid 1px #666;
                    font-weight: bold;
                    color: #fff;
                    line-height: 12px;
                }

                .Grid .pgr a {
                    color: Gray;
                    text-decoration: none;
                }

                    .Grid .pgr a:hover {
                        color: #000;
                        text-decoration: none;
                    }
    </style>
</asp:Content>
