<%@ Page Title="" Language="C#" MasterPageFile="~/sqlmusic.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Songs.aspx.cs" Inherits="SQLMusicManagement.Songs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Songs
    </h1>
    <br />
    <br />
    <asp:Panel ID="pnlSuccess" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblSuccess" runat="server" Text="Label added succcessfully" ForeColor="Green" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblError" runat="server" Text="Company already exists" ForeColor="Red" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <div style="float: left; width: 100%">
        <div style="float: left;">Search By Artist or Title: </div>
        <div style="float: left;">
            <asp:TextBox ID="txtSearch" CssClass="inp-form" runat="server"></asp:TextBox>
        </div>
        <div style="float: left; margin-left: 10px">
            <asp:Button ID="btnSearch" CausesValidation="false" runat="server" Text="Submit" CssClass="form-submit" OnClick="btnSearch_Click" />
        </div>
    </div>
    <div id="container" style="float: left; width: 100%">
        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_RowCommand" CssClass="Grid"
            OnRowDataBound="grd_RowDataBound" Style="font-weight: bold" AllowPaging="True" AllowSorting="True"
            EmptyDataText="No Record Found" OnPageIndexChanging="grd_PageIndexChanging" OnDataBound="grd_DataBound"
            OnSorting="grd_Sorting" PageSize="100">
            <Columns>
                <asp:TemplateField SortExpression="IdSong" HeaderText="IdSong">
                    <ItemTemplate>
                        <asp:Label ID="IdSong" runat="server" Text='<%#Eval("IdSong") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="ParentSongId" HeaderText="ParentSongId">
                    <ItemTemplate>
                        <asp:Label ID="ParentSongId" runat="server" Text='<%#Eval("ParentSongId") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="8%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title, Artist, Version">
                    <ItemTemplate>
                        <asp:HiddenField ID="hf" runat="server" Value='<%#Eval("idsong") %>' />
                        <asp:Label ID="lbltitle" Style="font-weight: normal; Font-Size: 14px;" runat="server" Text='<%#Eval("TITLE") %>'></asp:Label><br />
                        <asp:Label ID="ARTIST" Style="font-weight: bold; Font-Size: 14px;" runat="server" Text='<%#Eval("ARTIST") %>'></asp:Label><br />
                        <asp:Label ID="Version" Style="font-weight: normal;" runat="server" Text='<%#Eval("Version") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="35%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="FileName" HeaderText="File Name">
                    <ItemTemplate>
                        <asp:Label ID="FileName" runat="server" Text='<%#Eval("FileName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="25%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="FullName" HeaderText="Company">
                    <ItemTemplate>
                        <asp:Label ID="Company" runat="server" Text='<%#Eval("FullName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="7%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="LABEL" HeaderText="LABEL">
                    <ItemTemplate>
                        <asp:Label ID="label" runat="server" Text='<%#Eval("lbl") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="FirstPlayDate" HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="FirstPlayDate" runat="server" Text='<%# Eval("FirstPlayDate")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="RadioDate" HeaderText="Radio Date">
                    <ItemTemplate>
                        <asp:Label ID="RadioDate" runat="server" Text='<%# Eval("RadioDate") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" CommandArgument='<%#Eval("idsong") %>' CommandName="_Edit">
                            <img src="images/edit.png" />
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkdetail" runat="server" ToolTip="Add New Version" CommandArgument='<%#Eval("idsong") %>' CommandName="_detail">
                            <img src="images/add.png" />
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkdelete" runat="server" ToolTip="Delete" CommandArgument='<%#Eval("idsong") %>' CommandName="_delete" OnClientClick="return confirm('You want to delete');">
                            <img src="images/delete.png" />
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="10%" />
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
