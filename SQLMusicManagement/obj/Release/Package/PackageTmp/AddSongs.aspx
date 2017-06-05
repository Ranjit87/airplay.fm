<%@ Page Title="" Language="C#" MasterPageFile="~/sqlmusic.Master" AutoEventWireup="true" CodeBehind="AddSongs.aspx.cs" Inherits="SQLMusicManagement.AddSongs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <script src="js/jq/jquery-1.7.1.min.js"></script>
    <script>
        $(document).ready(function () {

            $('ul.tabs li').click(function () {
                var tab_id = $(this).attr('data-tab');

                $('ul.tabs li').removeClass('current');
                $('.tab-content').removeClass('current');

                $(this).addClass('current');
                $("#" + tab_id).addClass('current');
            })

        });


    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ScriptManager1" runat="server"></asp:ToolkitScriptManager>
    <h1>Add Song
    </h1>
    <asp:Panel ID="pnlSuccess" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblSuccess" runat="server" Text="Label added succcessfully" ForeColor="Green" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblError" runat="server" Text="Please select a file first" ForeColor="Red" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <div id="container" style="margin-top: 20px">
        <asp:HiddenField ID="hf" runat="server" />


        <ul class="tabs">
            <li class="tab-link current" data-tab="tab-1">General Info</li>
            <li class="tab-link" data-tab="tab-2">Song Details</li>
        </ul>

        <div id="tab-1" class="tab-content current" style="float: left; width: 100%">
            <div style="width: 60%; float: left;">
                <script type="text/javascript">
                    function getName() {
                        if (Page_ClientValidate()) {
                            var filename;

                            var fullPath = document.getElementById('<%= filename.ClientID %>').value;
                            var hf = document.getElementById('<%= hfname.ClientID %>');
                            if (fullPath) {
                                var startIndex = (fullPath.indexOf('\\') >= 0 ? fullPath.lastIndexOf('\\') : fullPath.lastIndexOf('/'));
                                filename = fullPath.substring(startIndex);

                                if (filename.indexOf('\\') === 0 || filename.indexOf('/') === 0) {
                                    filename = filename.substring(1);
                                }
                                hf.value = filename;
                                document.getElementById('<%= filename.ClientID %>').value = "";
                            }
                        }
                    }
                </script>
                <span>File Name</span><br />
                <asp:FileUpload ID="filename" runat="server" CssClass="inp-form" />
                <br />
                <br />
                <span>Artist</span><br />
                <asp:TextBox ID="txtArtist" runat="server" CssClass="inp-form"></asp:TextBox>
                <asp:RequiredFieldValidator ID="reqcomp" runat="server" ControlToValidate="txtArtist" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                    ServiceMethod="GetArtist"
                    ServicePath="DBService.asmx"
                    MinimumPrefixLength="2"
                    CompletionInterval="100"
                    EnableCaching="false"
                    CompletionSetCount="10"
                    TargetControlID="txtArtist"
                    FirstRowSelected="false"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </asp:AutoCompleteExtender>
                <br />
                <br />
                <span>Title</span><br />
                <asp:TextBox ID="txtTitle" runat="server" CssClass="inp-form"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle" ErrorMessage="Required"></asp:RequiredFieldValidator>
                <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
                    ServiceMethod="GetTitle"
                    ServicePath="DBService.asmx"
                    MinimumPrefixLength="2"
                    CompletionInterval="100"
                    EnableCaching="false"
                    CompletionSetCount="10"
                    TargetControlID="txtTitle"
                    FirstRowSelected="false"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
                </asp:AutoCompleteExtender>
                <br />
                <br />
                <span>Author</span><br />
                <asp:TextBox ID="txtAuthor" runat="server" CssClass="inp-form"></asp:TextBox>
                <br />
                <br />
                <span>Publisher</span><br />
                <asp:TextBox ID="txtPublisher" runat="server" CssClass="inp-form"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" Style="padding: 5px" CausesValidation="false" />
                <br />
                <br />
                <span>Company</span><br />
                <asp:DropDownList ID="ddlCompany" runat="server" CssClass="inp-form" Style="width: 415px; height: 32px">
                </asp:DropDownList>
                &nbsp;&nbsp;<asp:Button ID="btnCompany" runat="server" Text="Add Company" OnClick="btnCompany_Click" Style="padding: 5px" CausesValidation="false" />
                <br />
                <br />
                <span>Label</span><br />
                <asp:DropDownList ID="ddlLabel" runat="server" CssClass="inp-form" Style="width: 415px; height: 32px">
                </asp:DropDownList>&nbsp;&nbsp;<asp:Button ID="btnLabel" runat="server" Text="Add Label" OnClick="btnLabel_Click" Style="padding: 5px" CausesValidation="false" />
                <br />
                <br />
                <span>Promoter</span><br />
                <asp:DropDownList ID="ddlPromoter" runat="server" CssClass="inp-form" Style="width: 415px; height: 32px">
                </asp:DropDownList>&nbsp;&nbsp;
                <%--<asp:Button ID="btnPromoter" runat="server" Text="Add Promoter" OnClick="btnPromoter_Click" Style="padding: 5px" CausesValidation="false" />--%>
                <br />
                <br />
            </div>
            <div style="width: 36%; float: left;">
                <asp:Panel ID="pnlSearch" runat="server" Visible="false">
                    <h1>Related Songs</h1>
                    <br />

                    <ul>
                        <asp:Repeater ID="rpt" runat="server">
                            <ItemTemplate>

                                <li><%# Eval("idsong") %>&nbsp;&nbsp; <%# Eval("Artist") %>&nbsp; -- &nbsp; <%# Eval("Title") %> &nbsp;&nbsp;&nbsp;&nbsp; 
                                <asp:HyperLink ID="gk" runat="server" NavigateUrl='<%# "EditSong.aspx?id=" + Eval("idsong") %>' Text="Edit"></asp:HyperLink>
                                </li>

                                <br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </asp:Panel>
                <asp:Panel ID="pnlAddLabel" runat="server" Visible="false">
                    <h1>Add New Label</h1>
                    <br />
                    <span>Label</span><br />
                    <asp:TextBox ID="txtLable" ValidationGroup="label" runat="server" CssClass="inp-form"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="label" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLable" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <span>First-Play Display</span><br />
                    <asp:DropDownList ID="ddlFirst" runat="server" CssClass="inp-form" Style="width: 415px; height: 32px">
                        <asp:ListItem Text="No" Value="1">
                        </asp:ListItem>
                        <asp:ListItem Text="Yes" Value="0">
                        </asp:ListItem>
                    </asp:DropDownList><br />
                    <br />
                    <asp:Button ID="Button1" runat="server" ValidationGroup="label" Text="Submit" OnClick="Button1_Click" CssClass="form-submit" />
                    <asp:Button ID="Button2" runat="server" Text="Canecl" OnClick="Button2_Click" CssClass="form-reset" CausesValidation="false" />
                </asp:Panel>
                <asp:Panel ID="pnlComapny" runat="server" Visible="false">
                    <h1>Add New Company</h1>
                    <br />
                    <span>Short Name</span><br />
                    <asp:TextBox ID="txtcompany" ValidationGroup="cmp" runat="server" CssClass="inp-form"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="cmp" ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtcompany" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <span>Full Name</span><br />
                    <asp:TextBox ID="txtFullName" ValidationGroup="cmp" runat="server" CssClass="inp-form"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="cmp" ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFullName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <span>First-Play Display</span><br />
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="inp-form" Style="width: 415px; height: 32px">
                        <asp:ListItem Text="No" Value="1">
                        </asp:ListItem>
                        <asp:ListItem Text="Yes" Value="0">
                        </asp:ListItem>
                    </asp:DropDownList><br />
                    <br />
                    <asp:Button ID="btnCompsub" runat="server" ValidationGroup="cmp" Text="Submit" OnClick="btnCompsub_Click" CssClass="form-submit" />
                    <asp:Button ID="btncompCan" runat="server" Text="Canecl" OnClick="btncompCan_Click" CssClass="form-reset" CausesValidation="false" />
                </asp:Panel>
            </div>
        </div>
        <div id="tab-2" class="tab-content" style="float: left; width: 100%">
            <span>Version</span><br />
            <asp:TextBox ID="txtVersion" runat="server" CssClass="inp-form"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtVersion" ErrorMessage="Required"></asp:RequiredFieldValidator>
            <br />
            <br />
            <span>Duration</span><br />
            <asp:TextBox ID="txtDuration" runat="server" CssClass="inp-form"></asp:TextBox>
            <br />
            <br />
            <span>ISRC</span><br />
            <asp:TextBox ID="txtISRC" runat="server" CssClass="inp-form"></asp:TextBox>
            <br />
            <br />
            <%--<span>Genre</span><br />
            <asp:TextBox ID="txtGenre" runat="server" CssClass="inp-form"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGenre" ErrorMessage="Required"></asp:RequiredFieldValidator>
            <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server"
                ServiceMethod="GetGenre"
                ServicePath="DBService.asmx"
                MinimumPrefixLength="2"
                CompletionInterval="100"
                EnableCaching="false"
                CompletionSetCount="10"
                TargetControlID="txtGenre"
                FirstRowSelected="false"
                CompletionListCssClass="autocomplete_completionListElement"
                CompletionListItemCssClass="autocomplete_listItem"
                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </asp:AutoCompleteExtender>--%>
            <span>Genre</span><br />
            <asp:DropDownList ID="ddlGenre" runat="server" CssClass="inp-form" Style="width: 415px; height: 32px">
                <asp:ListItem Text="Pop" Value="0">
                </asp:ListItem>
                <asp:ListItem Text="Rock" Value="1">
                </asp:ListItem>
                <asp:ListItem Text="Dance" Value="2">
                </asp:ListItem>
                <asp:ListItem Text="Hip Hop / Rap" Value="3">
                </asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <%--<span>Language</span><br />
            <asp:TextBox ID="txtLanguage" runat="server" CssClass="inp-form"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLanguage" ErrorMessage="Required"></asp:RequiredFieldValidator>
            <asp:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server"
                ServiceMethod="GetLanguage"
                ServicePath="DBService.asmx"
                MinimumPrefixLength="2"
                CompletionInterval="100"
                EnableCaching="false"
                CompletionSetCount="10"
                TargetControlID="txtLanguage"
                FirstRowSelected="false"
                CompletionListCssClass="autocomplete_completionListElement"
                CompletionListItemCssClass="autocomplete_listItem"
                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </asp:AutoCompleteExtender>--%>
            <span>Language</span><br />
            <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="inp-form" Style="width: 415px; height: 32px">
                <asp:ListItem Text="int" Value="0">
                </asp:ListItem>
                <asp:ListItem Text="ita" Value="1">
                </asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <span>Radio Date</span><br />
            <asp:TextBox ID="txtRadioDate" runat="server" CssClass="inp-form"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRadioDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtRadioDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
            <br />
            <br />
            <span>First-Plays View</span><br />
            <asp:DropDownList ID="ddlFirstPlayView" runat="server" CssClass="inp-form" Style="width: 415px; height: 32px">
                <asp:ListItem Text="Yes" Value="0">
                </asp:ListItem>
                <asp:ListItem Text="No" Value="1">
                </asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <span>Absolute Beginner</span><br />
            <asp:DropDownList ID="ddlAbsoluteBeginner" runat="server" CssClass="inp-form" Style="width: 415px; height: 32px">
                <asp:ListItem Text="No" Value="1">
                </asp:ListItem>
                <asp:ListItem Text="Yes" Value="0">
                </asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <span>Alternative Charts</span><br />
            <asp:CheckBox ID="chkAlternativeCharts" runat="server" />
            <br />
            <br />
            <asp:HiddenField ID="hfname" runat="server" />
            <span>TV Show</span><br />
            <asp:TextBox ID="txtTVShow" runat="server" CssClass="inp-form"></asp:TextBox>
            <asp:AutoCompleteExtender ID="AutoCompleteExtender5" runat="server"
                ServiceMethod="GetTvShows"
                ServicePath="DBService.asmx"
                MinimumPrefixLength="2"
                CompletionInterval="100"
                EnableCaching="false"
                CompletionSetCount="10"
                TargetControlID="txtTVShow"
                FirstRowSelected="false"
                CompletionListCssClass="autocomplete_completionListElement"
                CompletionListItemCssClass="autocomplete_listItem"
                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
            </asp:AutoCompleteExtender>
            <br />

        </div>


        <%--<asp:TabContainer runat="server" ID="Tabs" ActiveTabIndex="1"
            Width="100%" Style="margin-bottom: 10px">
            <asp:TabPanel runat="server" ID="Panel1" HeaderText="General Info" TabIndex="0">
                <ContentTemplate>
                   
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel runat="server" ID="TabPanel2" HeaderText="Song Details" TabIndex="1">
                <ContentTemplate>
                    
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>--%>
        <div style="float: left; width: 100%; height: 15px"></div>
        <asp:Button ID="Button10" CausesValidation="true" runat="server" Text="Submit" OnClick="btn_Click" CssClass="form-submit" OnClientClick="getName()" />
        <asp:Button ID="Button11" runat="server" Text="Canecl" OnClick="btjcancel_Click" CssClass="form-reset" CausesValidation="false" />

    </div>
    <style>
        .autocomplete_completionListElement {
            margin: 0px!important;
            background-color: white;
            color: windowtext;
            border: buttonshadow;
            border-width: 1px;
            border-style: solid;
            overflow: auto;
            font-family: Tahoma;
            font-size: medium;
            text-align: left;
            list-style-type: none;
            line-height: 1;
            position: relative;
            cursor: pointer;
        }
        /* AutoComplete highlighted item */
        .autocomplete_highlightedListItem {
            background-color: #ffff99;
            color: black;
            padding: 1px;
        }

        /* AutoComplete item */
        .autocomplete_listItem {
            background-color: window;
            color: windowtext;
            padding: 1px;
        }


        <style > body {
            margin-top: 100px;
            font-family: 'Trebuchet MS', serif;
            line-height: 1.6;
        }

        .container {
            width: 800px;
            margin: 0 auto;
        }



        ul.tabs {
            margin: 0px;
            padding: 0px;
            list-style: none;
        }

            ul.tabs li {
                background: none;
                color: #222;
                display: inline-block;
                padding: 10px 15px;
                cursor: pointer;
            }

                ul.tabs li.current {
                    background: #ededed;
                    color: #222;
                }

        .tab-content {
            display: none;
            background: #ededed;
            padding: 15px;
        }

            .tab-content.current {
                display: inherit;
            }
    </style>
</asp:Content>













