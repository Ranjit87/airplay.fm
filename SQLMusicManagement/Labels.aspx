<%@ Page Title="" Language="C#" MasterPageFile="~/sqlmusic.Master" AutoEventWireup="true" CodeBehind="Labels.aspx.cs" Inherits="SQLMusicManagement.Labels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Labels
    </h1>
    <br />
    <br />
    <div id="container">
        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" CssClass="Grid"
            AlternatingRowStyle-CssClass="alt" Width="100%" OnRowCommand="grd_RowCommand" Style="font-weight: bold" AllowPaging="True" AllowSorting="True"
            EmptyDataText="No Record Found" OnPageIndexChanging="grd_PageIndexChanging" OnDataBound="grd_DataBound"
            OnSorting="grd_Sorting" PageSize="100">
            <RowStyle CssClass="gradeB" />
            <Columns>
                <asp:TemplateField SortExpression="TITLE" HeaderText="Title">
                    <ItemTemplate>
                        <asp:HiddenField ID="hf" runat="server" Value='<%#Eval("Id") %>' />
                        <asp:Label ID="lbltitle" runat="server" Text='<%#Eval("TITLE") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField SortExpression="Data" HeaderText="First-Play Display">
                    <ItemTemplate>
                        <asp:CheckBox ID="Data" runat="server" Enabled="false" Checked='<%#Eval("Data") %>'></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" CommandArgument='<%#Eval("Id") %>' CommandName="_Edit">
                            <img src="images/edit.png" />
                        </asp:LinkButton>&nbsp;&nbsp;|
                        <asp:LinkButton ID="lnkdelete" runat="server" ToolTip="Delete" CommandArgument='<%#Eval("Id") %>' CommandName="_delete" OnClientClick="return confirm('You want to delete');">
                            <img src="images/delete.png" />
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div>
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
        </div>
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
