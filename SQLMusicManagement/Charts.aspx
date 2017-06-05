<%@ Page Title="" Language="C#" MasterPageFile="~/sqlmusic.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Charts.aspx.cs" Inherits="SQLMusicManagement.Charts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Emergenti
    </h1>
    <br />
    <br />
    <asp:Panel ID="pnlSuccess" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblSuccess" runat="server" Text="Chart added succcessfully" ForeColor="Green" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblError" runat="server" Text="Chart already exists" ForeColor="Red" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <div style="float: left; width: 100%">
        <div style="float: left;">Search By Artist or Title: </div>
        <div style="float: left;">
            <asp:TextBox ID="txtSearch" CssClass="inp-form" runat="server"></asp:TextBox>
        </div>
        <div style="float: left; margin-left: 10px">
            <asp:Button ID="btnSearch" CausesValidation="false" runat="server" Text="Submit" CssClass="form-submit" OnClick="btnSearch_Click" />
        </div>
        <div style="float: right; margin-left: 100px">
            <asp:Button ID="btnAddNewChart" CausesValidation="false" runat="server" Text="Add New Chart" Style="padding: 5px" OnClick="btnAddNewChart_Click" />
        </div>
    </div>
    <div id="container" style="float: left; width: 100%">
        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_RowCommand" CssClass="Grid"
            OnRowDataBound="grd_RowDataBound" Style="font-weight: bold" AllowPaging="True" AllowSorting="True"
            EmptyDataText="No Record Found" OnPageIndexChanging="grd_PageIndexChanging" OnDataBound="grd_DataBound"
            OnSorting="grd_Sorting" PageSize="100">
            <Columns>
                <asp:TemplateField SortExpression="ID" HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="ID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                        <asp:HiddenField ID="hf" runat="server" Value='<%#Eval("ID") %>' />
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>               
                <asp:TemplateField SortExpression="Settimana" HeaderText="Settimana">
                    <ItemTemplate>
                        <asp:Label ID="Settimana" runat="server" Text='<%#Eval("Settimana") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="Posizione" HeaderText="Posizione">
                    <ItemTemplate>
                        <asp:Label ID="Posizione" runat="server" Text='<%#Eval("Posizione") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField SortExpression="Artista" HeaderText="Artista">
                    <ItemTemplate>
                        <asp:Label ID="Artista" runat="server" Text='<%#Eval("Artista") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="35%" />
                </asp:TemplateField>
                 <asp:TemplateField SortExpression="Titolo" HeaderText="Titolo">
                    <ItemTemplate>
                        <asp:Label ID="Titolo" runat="server" Text='<%#Eval("Titolo") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="35%" />
                </asp:TemplateField>
                 <asp:TemplateField SortExpression="Anno" HeaderText="Anno">
                    <ItemTemplate>
                        <asp:Label ID="Etichetta" runat="server" Text='<%#Eval("Anno") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="5%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkedit" runat="server" ToolTip="Edit" CommandArgument='<%#Eval("ID") %>' CommandName="_Edit">
                            <img src="images/edit.png" />
                        </asp:LinkButton>
                        <asp:LinkButton ID="lnkdelete" runat="server" ToolTip="Delete" CommandArgument='<%#Eval("ID") %>' CommandName="_delete" OnClientClick="return confirm('You want to delete');">
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
