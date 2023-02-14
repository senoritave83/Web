<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptTotalMostruariosDet.aspx.vb" Inherits="reports_rptTotalMostruariosDet" %>
<%@ Register assembly="Xceed.Chart.Server, Version=4.2.100.0, Culture=neutral, PublicKeyToken=ba83ff368b7563c6" namespace="Xceed.Chart.Server" tagprefix="xceedchart" %>
<%@ Register src="../controls/XMTitulo.ascx" tagname="XMTitulo" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Relatório Fast Shop - Total de Mostruários</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id='MainArea'>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class='MainHeader'>
                    &nbsp;
                </td>
            </tr>
            <tr valign="top">
                <td width="100%" class='MainContent'>
                    <uc2:XMTitulo ID="XMTitulo1" runat="server" Imagem="~/imagens/logo_default.png" />
                </td>
           </tr>
           <tr>
            <td width="100%" class='MainContent'>
                <div>
                        <xceedchart:ChartServerControl ID="ChartServerControl1" runat="server"></xceedchart:ChartServerControl>
                </div>
            </td>
           </tr>
            <tr height=20px>
                <td colspan="3">
                    <div id='MainFooter'>&copy;<%=Year(now)%> XM Sistemas Distribu&iacute;dos Ltda. Todos os direitos reservados.</div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>