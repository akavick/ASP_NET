<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxWebForm_1.aspx.cs" Inherits="Empty.AjaxWebForm_1" %>

<%@ Import Namespace="System.Globalization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>boom</title>

    <script>
        window.onload = function ()
        {
            const aj = new XMLHttpRequest();
            aj.onreadystatechange = function ()
            {
                if (aj.readyState === 4)
                {
                    if (aj.status === 200)
                    {
                        document.getElementById("TimerFromHandler").innerHTML = aj.responseText;
                    }
                }
            }

            function jsTimer()
            {
                Empty.WebServiceTimer.GetDateTime(
                    function (result) 
                    {
                        //onComplete
                        const dateResultFromHandler = result.toLocaleDateString() + " " + result.toLocaleTimeString();
                        document.getElementById("TimerFromWebService").innerHTML = dateResultFromHandler;
                    },
                    function (error)
                    {
                        //onError
                        document.getElementById("TimerFromWebService").innerHTML = error._message;
                    });

                const curDate = new Date(Date.now());
                const dateResult = curDate.toLocaleDateString() + " " + curDate.toLocaleTimeString();
                document.getElementById("TimerPureJS").innerHTML = dateResult;

                aj.open("GET", "HandlerTimer.ashx");
                aj.send(null);

                setTimeout(jsTimer, 1000);
            }

            jsTimer();
        }
    </script>

</head>

<body>
    <form id="form1" runat="server">

        <div id="Container">

            <div id="TimerPureJS"></div>

            <div id="TimerFromWebService"></div>

            <div id="TimerFromHandler"></div>

            <asp:ScriptManager ID="Sm" runat="server">
                <Services>
                    <asp:ServiceReference Path="~/WebServiceTimer.asmx" />
                </Services>
            </asp:ScriptManager>

            <asp:UpdatePanel ID="UPanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Timer ID="AspTimer" runat="server" Interval="1000" />
                    <%= DateTime.Now.ToString(CultureInfo.CurrentCulture) %>
                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="UPanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Timer ID="AspTimer2" runat="server" Interval="1000" OnTick="AspTimer2_Tick" />
                    <asp:Label ID="AnotherTimer" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>

    </form>
</body>
</html>
