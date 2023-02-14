<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptMostruariodet.aspx.vb" Inherits="reports_rptMostruariodet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XM Promotores - Yes Mobile</title>
    <link rel=Stylesheet href='arquivos/stylesheet.css'>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table>
            <tr>
                <td>
                  <table cellpadding='0' cellspacing='0'>
                   <tr>
                    <td width=0 height=0></td>
                    <td width=88></td>
                    <td width=708></td>
                    <td width=136></td>
                   </tr>
                   <tr>
                    <td height=2></td>
                    <td colspan=2></td>
                    <td rowspan=3 align=left valign=top><img width=136 height=50
                    src='arquivos/logoyes.jpg'></td>
                   </tr>
                   <tr>
                    <td height=46></td>
                    <td align=left valign=top><img width=88 height=46 src=arquivos/logolg.jpg ></td>
                   </tr>
                   <tr>
                    <td height=2></td>
                   </tr>
                  </table>
                  <span style='mso-ignore:vglayout2'>
                  <table cellpadding=0 cellspacing=0>
                   <tr>
                    <td colspan=20 rowspan=4 height=68 class=xl84 width=891 style='height:51.0pt;
                    width:668pt'><span style='mso-spacerun:yes'>  </span>MOSTRUÁRIOS FAST SHOP</td>
                   </tr>
                  </table>
                  </span>
                </td>
            </tr>
        </table>
        <asp:Literal runat='server' ID='ltrRelatorio'></asp:Literal>

    </div>
    </form>
</body>
</html>
