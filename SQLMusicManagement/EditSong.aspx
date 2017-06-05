<%@ Page Title="" Language="C#" MasterPageFile="~/sqlmusic.Master" AutoEventWireup="true" CodeBehind="EditSong.aspx.cs" Inherits="SQLMusicManagement.EditSong" %>

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
        <br />
        <br />
        <div style="float: left; width: 100%; margin-bottom: 20px">
            <div style="float: left; width: 100px">
                <span style="font-weight: bold">Artist:</span>
            </div>
            <asp:TextBox ID="lblArtist" runat="server" CssClass="inp-form"></asp:TextBox>
            <br />
            <br />
            <div style="float: left; width: 100px">
                <span style="font-weight: bold">Title:</span>
            </div>
            <asp:TextBox ID="lblTitle" runat="server" CssClass="inp-form"></asp:TextBox>
            <br />
            <br />
            <div style="float: left; width: 100px">
                <span style="font-weight: bold">Author:</span>
            </div>
            <asp:TextBox ID="lblAuthor" runat="server" CssClass="inp-form"></asp:TextBox>
            <br />
            <br />
            <div style="float: left; width: 100px">
                <span style="font-weight: bold">Publisher:</span>
            </div>
            <asp:TextBox ID="lblPublisher" runat="server" CssClass="inp-form"></asp:TextBox>
            <br />
            <br />
            <div style="float: left; width: 100px">
                <span style="font-weight: bold">Label:</span>
            </div>
            <asp:DropDownList ID="ddlLabel" runat="server" CssClass="inp-form" Style="width: 415px; height: 32px"></asp:DropDownList>
            <div style="float: left; width: 100px">
                <span style="font-weight: bold">Promoter:</span>
            </div>
            <asp:DropDownList ID="ddlPromoter" runat="server" CssClass="inp-form" Style="width: 415px; height: 32px"></asp:DropDownList>
            <br />
            <br />
            <div style="float: left; width: 100px">
                <span style="font-weight: bold">Company:</span>
            </div>
            <asp:DropDownList ID="ddlCompany" runat="server" CssClass="inp-form" Style="width: 415px; height: 32px">
            </asp:DropDownList>
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
                <div style="float: left; width: 100px">
                    <span style="font-weight: bold">Version:</span>
                </div>
                <asp:TextBox ID="lblVersion" runat="server" ValidationGroup="Version" CssClass="inp-form"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv" runat="server" ErrorMessage="Required" ControlToValidate="lblVersion" ValidationGroup="Version"></asp:RequiredFieldValidator>
                <br />
                <br />
                 <div style="float: left; width: 100px">
                    <span style="font-weight: bold">Duration:</span>
                </div>
                <asp:TextBox ID="txtDuration" runat="server" CssClass="inp-form"></asp:TextBox>
                <br />
                <br />
                <div style="float: left; width: 100px">
                    <span style="font-weight: bold">ISRC:</span>
                </div>
                <asp:TextBox ID="txtISRC" runat="server" CssClass="inp-form"></asp:TextBox>
                <br />
                <br />
                <div style="float: left; width: 100px">
                    <span style="font-weight: bold">Radio Date:</span>
                </div>
                <asp:TextBox ID="lblRadio" runat="server" CssClass="inp-form"></asp:TextBox>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="lblRadio" Format="dd/MM/yyyy"></asp:CalendarExtender>
                <br />
                <br />
                <div style="float: left; width: 100px">
                    <span style="font-weight: bold">Genre:</span>
                </div>
                <%--<asp:TextBox ID="lblGenre" runat="server" CssClass="inp-form"></asp:TextBox>--%>
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
                <div style="float: left; width: 100px">
                    <span style="font-weight: bold">Language:</span>
                </div>
                <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="inp-form" Style="width: 415px; height: 32px">
                    <asp:ListItem Text="int" Value="0">
                    </asp:ListItem>
                    <asp:ListItem Text="ita" Value="1">
                    </asp:ListItem>
                </asp:DropDownList><br />
                <br />
                <div style="float: left; width: 100px">
                    <span style="font-weight: bold">TvShow:</span>
                </div>
                <asp:TextBox ID="lblTvShow" runat="server" CssClass="inp-form"></asp:TextBox>
                <br />
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

        <asp:Panel ID="pnlButtons" runat="server" Visible="true">
            <asp:Button ID="btnHome" runat="server" Text="Home" Style="padding: 5px" OnClick="btnHome_Click" />
            <asp:Button ID="btnSave" runat="server" Text="Save to SQL" Style="padding: 5px" OnClick="btnSave_Click" ValidationGroup="Version" />
        </asp:Panel>
    </div>
</asp:Content>
