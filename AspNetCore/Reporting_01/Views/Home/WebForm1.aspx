<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" AutoEventWireup="true" ValidateRequest="false" EnableEventValidation="false" ViewStateEncryptionMode="Never" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected override void OnLoad(EventArgs e)
    {
        var reportServerUrlString = "http://localhost/ReportServer";
        var reportPath =
            "/InsuranceReport/ListsForInsuranceCompany"
            //"/OS/ForDeliveryByGroupAndRoom"
            ;

        ReportViewer1.ServerReport.ReportServerUrl = new Uri(reportServerUrlString);
        ReportViewer1.ServerReport.ReportPath = reportPath;

        //var parameters = new List<ReportParameter> {new ReportParameter("vOrderDate", DateTime.Now.ToString())};
        //ReportViewer1.ServerReport.SetParameters(parameters);

        base.OnLoad(e);
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Title</title>
    <style type="text/css">
        html, body, form, #div1, #ReportViewer1
        {
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="post">
        <div id="div1">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1"
                                runat="server"
                                ProcessingMode="Remote"
                                Height="100%"
                                Width="100%"
                                AsyncRendering="false"
                                SizeToReportContent="false"
                                Font-Names="Verdana"
                                Font-Size="8pt"
                                WaitMessageFont-Names="Verdana"
                                WaitMessageFont-Size="14pt"
                                ShowRefreshButton="false"
                                ShowBackButton="false"
                                KeepSessionAlive="False"
                                >
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
