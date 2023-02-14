<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptResPOPDet.aspx.vb" Inherits="reports_rptResPOPDet" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns:v='urn:schemas-microsoft-com:vml'
xmlns:o='urn:schemas-microsoft-com:office:office'
xmlns:x='urn:schemas-microsoft-com:office:excel'>
<head runat="server">
<style>
.TabelaPOPItem
	{padding:0px;
	color:maroon;
	font-size:9.0pt;
	font-weight:300;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	text-align:left;
	white-space:nowrap;
	border-left:1px solid black;
	border-top:1px solid black;
	border-bottom:1px solid black}
.TabelaPOPValue
	{padding:0px;
	color:black;
	font-size:9.0pt;
	font-weight:300;
	font-style:normal;
	text-decoration:none;
	font-family:Arial, sans-serif;
	text-align:center;
	white-space:nowrap;
	border:1px solid black}
.TabelaPOP
	{padding:0px;
	color:maroon;
	font-size:10.0pt;
	font-weight:bold;
	font-style:normal;
	font-family:Arial, sans-serif;
	text-align:center;
	vertical-align:middle;
	white-space:nowrap;}
#tblResult
{
	
}
.TituloColunaLojas
	{
	color:white;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	text-align:center;
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:none;
	border-left:.5pt solid black;
	background:#333333;
}
.TituloColunaItens
	{
	color:white;
	font-size:9.0pt;
	font-weight:300;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	text-align:center;
	writing-mode: tb-rl; filter: flipH() flipV();
			/*
	border-top:.5pt solid black;
	border-right:none;
	border-bottom:none;
	border-left:.5pt solid black;
		*/
    width:50px;
	background:#333333;}
.LinhaLoja
	{padding:0px;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	text-align:center;
	vertical-align:bottom;
	border-top:.5pt solid black;
	border-right:.5pt solid black;;
	border-bottom:.5pt solid black;
	border-left:.5pt solid black;
	white-space:nowrap;}
.LinhaItem
	{padding:0px;
	color:windowtext;
	font-size:10.0pt;
	font-weight:400;
	font-style:normal;
	text-decoration:none;
	font-family:Arial;
	text-align:center;
	vertical-align:bottom;
	border-top:.5pt solid black;
	border-right:.5pt solid black;
	border-bottom:none;
	border-left:none;
	white-space:nowrap;}
</style>
<title>Relat&#243;rio Resumo POP</title>
</head>
<body>
<table width="100%" cellpadding="1" cellspacing="1">
	<tr valign="middle">
		<td>
			<img src="../imagens/img_logo.gif" id="ctl00_XMTitulo1_imgImagem" border="0" />
		</td>
		<td width="100%">
			<span id="ctl00_XMTitulo1_lblTitulo" style="font-family:Verdana;text-transform:uppercase;text-align:left;">Relat&#243;rio Resumo POP Institucional</span><br/>
			<img src='../imagens/pt.gif' id='imgLinha'><br/>
			<span id="ctl00_XMTitulo1_lblDescricao" style="font-family:Verdana;font-size:8pt;text-align:left;">Visualiza&ccedil;&atilde;o do Relat&#243;rio Resumo POP Institucional</span>
		</td>
		<td align="right"><img src='../imagens/xmpromotores.jpg'/></td>
	</tr>
	<tr>
	    <td colspan='3' align='left'>
            <span id="ctl00_XMTitulo1_SiteMapPath1" style="font-family:Arial;font-size:0.6em;"><span style="color:#507CD1;font-weight:bold;">Home</span><span style="color:#507CD1;font-weight:bold;"> : </span><span style="color:#284E98;font-weight:bold;">Relat&#243;rios</span><span style="color:#507CD1;font-weight:bold;"> : </span><span style="color:#333333;font-weight:bold;">Resumo POP Institucional</span></span>
	    </td>
	</tr>
</table>
<br />
<asp:Literal runat="Server" ID="ltReport"></asp:Literal>
<br /><br /><br />
</body>
</html>
