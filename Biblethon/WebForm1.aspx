<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Biblethon.Master"
    CodeBehind="WebForm1.aspx.cs" Inherits="Biblethon.WebForm1" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="accordion" style="padding: 5px;">
        <a id="0" href="" onclick="Acc(this)">
            <h4>
                Tab 1</h4>
        </a>
        <div>
            panel 1
            <asp:Button ID="Button2" runat="server" Text="Button" onclick="Button2_Click" /></div>
        <a id="1" href="" onclick="Acc(this)">
            <h4>
                Tab 2</h4>
        </a>
        <div>
            panel 2
            <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" /></div>
        <a id="2" href="" onclick="Acc(this)">
            <h4>
                Tab 3</h4>
        </a>
        <div>
            panel 3
            <asp:Button ID="Button3" runat="server" Text="Button" onclick="Button3_Click" /></div>
        <a id="3" href="" onclick="Acc(this)">
            <h4>
                Tab 4</h4>
        </a>
        <div>
            panel 4
            <asp:Button ID="Button4" runat="server" Text="Button" onclick="Button4_Click" /></div>
    </div>
    <input id="hid" runat="server" type="hidden" value="0" />
    <script type="text/javascript">
        $(document).ready(function () {
            var actindex = parseInt($("#<%=hid.ClientID %>").val());
            $("#accordion").accordion({

                event: 'click',

                active: actindex,

                autoheight: true,

                change: function (event, ui) { debugger; gCurrentIndex = $(this).find("h4").index(ui.newHeader[0]); }
            });
        });
        function Acc(val1) {
            //debugger;
            var i =parseInt(val1.id);
            $("#<%=hid.ClientID %>").val(i);
        }
    </script>
</asp:Content>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 
<head>
 
    <title>Demo Accordion</title>
 
    <style type="text/css" > #accordion{padding:5px;width:50%;} </style>
 
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/themes/start/jquery-ui.css" type="text/css" media="all" />
 
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js" type="text/javascript"></script> 

    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.2/jquery-ui.js" type="text/javascript"></script> 

    <script type="text/javascript" >

        var gCurrentIndex = 0; // global variable to keep the current index;

        var ACCORDION_PANEL_COUNT = 3; //global variable for panel count. Here 3 is for zero based accordion index



        $(document).ready(function () {

            wizard = $("#accordion").accordion({

                event: 'click',

                active: 0,

                autoheight: true,

                animated: "bounceslide",

                icons: { 'header': 'ui-icon-plus', 'headerSelected': 'ui-icon-minus' },

                change: function (event, ui) { debugger; gCurrentIndex = $(this).find("h4").index(ui.newHeader[0]); }

            });



            //Bind event for previous and next buttons

            $('.previous,.next').click(function () {

                var index = 0;

                if ($(this).hasClass('next')) {

                    index = gCurrentIndex + 1;

                    if (index > ACCORDION_PANEL_COUNT) {

                        index = ACCORDION_PANEL_COUNT;

                    }

                }

                else {

                    index = gCurrentIndex - 1;

                    if (index < 0) {

                        index = 0;

                    }

                }



                //Call accordion method to set the active panel

                wizard.accordion("activate", index);

            });

        });
 
  </script>
 
  </head>
 
    <body>
 
        <div id="accordion" style="padding:5px;">
 
            <h4><a href="#">Tab1 1</a></h4>
 
            <div>panel 1</div>
 
            <h4><a href="#">Tab 2</a></h4>
 
            <div>panel 2</div>
 
            <h4><a href="#">Tab 3</a></h4>
 
            <div>panel 3</div>
 
            <h4><a href="#">Tab 4</a></h4>
 
            <div>panel 4</div>
 
        </div>
 
        <input class="previous" type="button" value="Previous" />
 
        <input class="next" type="button" value="Next" />
 
    </body>
 
</html>
--%>
