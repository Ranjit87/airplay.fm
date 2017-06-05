<%@ Page Title="" Language="C#" MasterPageFile="~/sqlmusic.Master" AutoEventWireup="true" CodeBehind="EditChart.aspx.cs" Inherits="SQLMusicManagement.EditChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="margin-left: 10px">Edit Chart
    </h1>
    <asp:Panel ID="pnlSuccess" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblSuccess" runat="server" Text="Label added succcessfully" ForeColor="Green" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" Style="margin-bottom: 20px; margin-top: 10px" Visible="false">
        <asp:Label ID="lblError" runat="server" Text="Company already exists" ForeColor="Red" Font-Italic="true"></asp:Label>
    </asp:Panel>
    <div id="container" style="margin-top: 20px; margin-left: 10px">
        <asp:HiddenField ID="hf" runat="server" />
        <span>Settimana</span><br />
        <asp:DropDownList ID="ddlSettimana" runat="server" CssClass="inp-form" Style="width: 415px; height: 32px">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="reqddlWeek" runat="server" ControlToValidate="ddlSettimana" ErrorMessage="Required"></asp:RequiredFieldValidator>
        <br />
        <br />
        <table>
            <tr>
                <td>Posizione</td>
                <td>Artista</td>
                <td>Titolo</td>
                <td>Anno</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_1" runat="server"></asp:Label></td>
                <td>
                    <asp:TextBox runat="server" CssClass="txtArt" Style="padding: 5px" ID="txtArt_1"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" CssClass="txtTit" Style="padding: 5px" ID="txtTit_1"></asp:TextBox></td>
                <td>
                    <asp:TextBox runat="server" CssClass="txtEtt" Style="padding: 5px" ID="txtEtt_1"></asp:TextBox></td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Button ID="btn" runat="server" Text="Submit" CssClass="form-submit" OnClick="btn_Click" />
        <asp:Button ID="btncancel" runat="server" Text="Canecl" CssClass="form-reset" CausesValidation="false" OnClick="btncancel_Click" />

    </div>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .ui-widget-content a {
            font-size: 15px!important;
        }
    </style>
    <script type="text/javascript">
        $(".txtArt").keyup(function () {
            var txtArt = $(this).attr('id');
            var Arr = txtArt.split('_');
            var fieldName = Arr[2];
            var fieldID = Arr[3];

            $('#' + txtArt).autocomplete({
                source: function (request, response) {
                    var customer = new Array();
                    $.ajax({
                        url: "EditChart.aspx/GetArtistList",
                        data: "{'artist':'" + document.getElementById('' + txtArt + '').value + "'}",
                        dataType: 'json',
                        contentType: "application/json; charset=utf-8",
                        type: 'POST',
                        success: function (data) {
                            if (data.d.length > 0) {
                                for (var i = 0; i < data.d.length ; i++) {
                                    customer[i] = { value: data.d[i].SongID, label: data.d[i].ArtistName };
                                }
                                response(customer);
                            }
                            else {
                                alert('Nessun record trovato');
                                $('#' + txtArt).val("");
                            }
                        }
                    });
                },
                select: function (event, ui) {
                    var IsExist = -1;
                    $(".txtArt").each(function () {
                        if (this.value == ui.item.label) {
                            IsExist = 1;
                        }
                    });
                    if (IsExist == 1) {
                        alert("Artista already exist.");
                        $('#' + txtArt).val("");
                    }
                    else {
                        $('#' + txtArt).val(ui.item.label);
                    }
                    return false;
                },
                minLength: 2
            });
        });

        $(".txtTit").keyup(function () {
            var txtTit = $(this).attr('id');
            var Arr = txtTit.split('_');
            var fieldName = Arr[2];
            var fieldID = Arr[3];
            var ArtistVal = document.getElementById('ctl00_ContentPlaceHolder1_txtArt_' + fieldID + '').value;
            var TitleVal = document.getElementById('' + txtTit + '').value;
            if (ArtistVal != "") {
                $('#' + txtTit).autocomplete({
                    source: function (request, response) {
                        var customer = new Array();
                        $.ajax({
                            url: "EditChart.aspx/GetTitleList",
                            data: "{ 'artist': '" + ArtistVal + "', 'title': '" + TitleVal + "' }",
                            dataType: 'json',
                            contentType: "application/json; charset=utf-8",
                            type: 'POST',
                            success: function (data) {
                                if (data.d.length > 0) {
                                    for (var i = 0; i < data.d.length ; i++) {
                                        customer[i] = { value: data.d[i].SongID, label: data.d[i].TitleName };
                                    }
                                    response(customer);
                                }
                                else {
                                    alert('Nessun record trovato');
                                    $('#' + txtTit).val("");
                                }
                            }
                        });
                    },
                    select: function (event, ui) {
                        var IsExist = -1;
                        $(".txtTit").each(function () {
                            if (this.value == ui.item.label) {
                                IsExist = 1;
                            }
                        });
                        if (IsExist == 1) {
                            alert("Titolo already exist.");
                            $('#' + txtTit).val("");
                        }
                        else {
                            $('#' + txtTit).val(ui.item.label);
                        }
                        return false;
                    },
                    minLength: 1
                });
            }
            else {
                alert("Please enter Artista");
                $('#' + txtTit).val("");
            }
        });

        $(".txtEtt").keyup(function () {
            var txtEtt = $(this).attr('id');
            var Arr = txtEtt.split('_');
            var fieldName = Arr[2];
            var fieldID = Arr[3];
            var ArtistVal = document.getElementById('ctl00_ContentPlaceHolder1_txtArt_' + fieldID + '').value;
            var TitleVal = document.getElementById('ctl00_ContentPlaceHolder1_txtTit_' + fieldID + '').value;
            var EtichettaVal = document.getElementById('' + txtEtt + '').value;
            if (ArtistVal != "" && TitleVal != "") {
                $('#' + txtEtt).autocomplete({
                    source: function (request, response) {

                        var customer = new Array();
                        $.ajax({
                            url: "EditChart.aspx/GetTitleList",
                            data: "{ 'artist': '" + ArtistVal + "', 'title': '" + TitleVal + "', 'etichetta': '" + EtichettaVal + "' }",
                            dataType: 'json',
                            contentType: "application/json; charset=utf-8",
                            type: 'POST',
                            success: function (data) {
                                if (data.d.length > 0) {
                                    for (var i = 0; i < data.d.length ; i++) {
                                        customer[i] = { value: data.d[i].SongID, label: data.d[i].lableName };
                                    }
                                    response(customer);
                                }
                                else {
                                    alert('Nessun record trovato');
                                    $('#' + txtEtt).val("");
                                }
                            }
                        });
                    },
                    select: function (event, ui) {
                        $('#' + txtEtt).val(ui.item.label);
                        return false;
                    },
                    minLength: 1
                });
            }
            else {
                if (ArtistVal == "") {
                    alert("Please enter Artista");
                }
                else if (TitleVal == "") {
                    alert("Please enter Titolo");
                }
                $('#' + txtEtt).val("");
            }
        });



    </script>
</asp:Content>
