<%@ Page Title="" Language="C#" MasterPageFile="~/sqlmusic.Master" AutoEventWireup="true" CodeBehind="Promoter.aspx.cs" Inherits="SQLMusicManagement.Promoter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Companies
    </h1>
    <br />
    <br />
    <asp:Panel ID="pnlSuccess" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblSuccess" runat="server" Text="Promoter added succcessfully" ForeColor="Green" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblError" runat="server" Text="Promoter already exists" ForeColor="Red" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <div style="float: left; width: 100%;">
        <div style="float: left;">Search By : </div>
        <div style="float: left;">
            From:
        </div>
        <div style="float: left;">
            <asp:DropDownList ID="ddlFrom" runat="server" CssClass="inp-form" Style="width: 180px; height: 32px">
            </asp:DropDownList>
            <asp:HiddenField ID="hdnID" runat="server" />
            <asp:RequiredFieldValidator ID="reqddlFrom" runat="server" ControlToValidate="ddlFrom" ErrorMessage="Required"></asp:RequiredFieldValidator>
        </div>
        <div style="float: left;">
            To:
        </div>
        <div style="float: left;">
            <asp:DropDownList ID="ddlTo" runat="server" CssClass="inp-form" Style="width: 180px; height: 32px">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqddlTo" runat="server" ControlToValidate="ddlTo" ErrorMessage="Required"></asp:RequiredFieldValidator>
        </div>
        <div style="float: left; margin-left: 10px">
            <asp:Button ID="btnSearch" CausesValidation="false" runat="server" Text="Submit" CssClass="form-submit" OnClick="btnSearch_Click" />
        </div>
        <div style="float: left; margin-left: 150px">
            <asp:Button ID="btnComplete" CausesValidation="false" runat="server" Text="Complete Report" Style="padding:5px;" OnClick="btnComplete_Click" />
        </div>
    </div>
    <div id="container" style="float: left; width: 100%">
        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_RowCommand" CssClass="Grid"
            Style="font-weight: bold; width: 100%" AllowPaging="True" AllowSorting="False"
            EmptyDataText="No Record Found" PageSize="100">
            <Columns>
                <asp:TemplateField SortExpression="Title" HeaderText="Promoters">
                    <ItemTemplate>
                        <asp:HiddenField ID="hf" runat="server" Value='<%#Eval("Id") %>' />
                        <asp:Label ID="Promoters" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="55%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="TotalSongs" HeaderText="Total Songs">
                    <ItemTemplate>
                        <asp:Label ID="TotalSongs" runat="server" Text='<%#Eval("TotalSongs") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="15%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="IdSong" HeaderText="From idSong">
                    <ItemTemplate>
                        <asp:Label ID="FromidSong" runat="server" Text='<%#Eval("IdSong") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="20%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDetail" runat="server" ToolTip="Details" CommandArgument='<%#Eval("Id") %>' CommandName="_detail">
                            <img src="images/add.png" />
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%--<div>
            <asp:ImageButton ID="imgPageFirst" runat="server" Style="float: left; padding: 5px;"
                AlternateText="First"
                CommandArgument="First" CommandName="Page"
                OnCommand="imgPageFirst_Command"></asp:ImageButton>
            <asp:ImageButton ID="imgPagePrevious" Style="float: left; padding: 5px;"
                runat="server" AlternateText="Previous"
                CommandArgument="Prev" CommandName="Page"
                OnCommand="imgPagePrevious_Command"></asp:ImageButton>
            <asp:DropDownList ID="ddCurrentPage" runat="server" Style="float: left; margin-top: 5px"
                CssClass="Normal" AutoPostBack="True"
                OnSelectedIndexChanged="ddCurrentPage_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:Label ID="lblOf" runat="server" Text="of" CssClass="Normal" Style="float: left; padding: 5px;"></asp:Label>
            <asp:Label ID="lblTotalPage" runat="server" CssClass="Normal" Style="float: left; padding: 5px;"></asp:Label>
            <asp:ImageButton ID="imgPageNext" runat="server" Style="float: left; padding: 5px;"
                AlternateText="Next"
                CommandArgument="Next" CommandName="Page"
                OnCommand="imgPageNext_Command"></asp:ImageButton>
            <asp:ImageButton ID="imgPageLast" runat="server" Style="float: left; padding: 5px;"
                AlternateText="Last"
                CommandArgument="Last" CommandName="Page"
                OnCommand="imgPageLast_Command"></asp:ImageButton>
        </div>--%>
    </div>
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

