<%@ Page Language="VB" AutoEventWireup="false" validateRequest="false" CodeFile="RelatorioDet.aspx.vb" Inherits="Relatorios_RelatorioDet" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    	<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Visible='true' ShowParameterPrompts='false'>
        </rsweb:ReportViewer>
        <script type='text/javascript'>
            self.focus();
        </script>
    </form>
</body>
</html>

