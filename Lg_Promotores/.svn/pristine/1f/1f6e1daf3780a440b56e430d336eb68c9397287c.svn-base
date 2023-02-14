<%@ Page Title="XM Promotores - Relatório de Performance" Language="VB" AutoEventWireup="false" CodeFile="rptPerformanceDet.aspx.vb" Inherits="reports_rptPerformanceDet" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XM Promotores - Relatório de Performance</title>
    <style type="text/css">
        
        .Relatorio
        {
            font-family: verdana, arial;
            font-size: 11px;
            font-weight: normal;
            border-right: 1px solid #000000;
            border-bottom: 1px solid #000000;
        }
        .Relatorio TD
        {
        	border-bottom: 0px solid #000000;
        	border-top: 1px solid #000000;
        	border-left: 1px solid #000000;
        	border-right: 0px solid #000000;
        }
        .ItemNome
        {
            text-align:left;
        }
        .Item
        {
            text-align:center;
        }
        .ItemNomeNeg
        {
            text-align:left;
            font-weight:bold;
        }
        .ItemNeg
        {
            text-align:center;
            font-weight:bold;
        }
        .Titulo
        {
            font-weight:bold;
            text-align:center;
        }
        .TituloRelatorio
        {
            font-family: verdana, arial;
            font-size: 18px;
            font-weight:bold;
            text-align:center;
        	border-bottom: 0px solid #000000;
        	border-top: 0px solid #000000;
        	border-left: 0px solid #000000;
        	border-right: 0px solid #000000;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <table width="800" cellpadding="1" cellspacing="1">
	                    <tr valign="middle">
		                    <td>
			                    <asp:Image runat="server" id='imgImagem' AlternateText="" ImageUrl="~/imagens/logo_default.png" SkinID='ReportImage' />
		                    </td>
		                    <td width="100%">
			                    <asp:Label Runat="server" ID='lblTitulo' SkinID='XMTitulo.Titulo'></asp:Label><br/>
			                    <img src='../imagens/pt.gif' id='imgLinha'><br/>
			                    <asp:Label Runat="server" ID='lblDescricao' SkinID='XMTitulo.Descricao'></asp:Label>
		                    </td>
		                    <td align="right"><img src='../imagens/xmpromotores.jpg'/></td>
	                    </tr>
	                </table>
                    <table width="800" class="Relatorio" cellspacing="0">
                        <tr>
                            <td class="TituloRelatorio" colspan="2">Relatório de Perfomance</td>
                        </tr>
                        <tr>
                            <td>Emissão <%=Format(Now(), "dd/MM/yyyy")%></td>
                        </tr>
                    </table>
                    <br />
                    <asp:Literal runat="Server" ID="ltReport"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
