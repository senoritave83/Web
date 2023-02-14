<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rptPerformanceVisDet.aspx.vb" Inherits="reports_rptPerformanceVisDet" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
        .ItemLeft
        {
            text-align:left;
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
			                    <img border="0" runat="server" id='imgImagem' alt="" src="../imagens/img_logo.gif" />
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
                            <td class="TituloRelatorio" colspan="2">Relatório de Perfomance - Detalhes</td>
                        </tr>
                        <tr>
                            <td style="width:80px;border-left:1px solid black;border-bottom:none;border-right:none;"><b>Emissão</b></td>
                            <td style="border-left:1px solid black;border-bottom:none;border-left:none;"><%=Format(Now(), "dd/MM/yyyy")%></td>
                        </tr>
                        <tr>
                            <td style="border-left:1px solid black;border-bottom:none;border-top:none;border-right:none;"><b>Coordenador:</b></td>
                            <td style="border-left:1px solid black;border-bottom:none;border-top:none;border-left:none;"><asp:Label runat="server" ID="lblCoordenador"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="border-left:1px solid black;border-bottom:none;border-top:none;border-right:none;"><b>Líder:</b></td>
                            <td style="border-left:1px solid black;border-bottom:none;border-top:none;border-left:none;"><asp:Label runat="server" ID="lblLider"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="border-left:1px solid black;border-top:none;border-right:none;"><b>Promotor:</b></td>
                            <td style="border-left:1px solid black;border-top:none;border-left:none;"><asp:Label runat="server" ID="lblPromotor"></asp:Label></td>
                        </tr>
                    </table>
                    <table width="800" cellspacing="0">
                        <tr>
                            <td align="right"><a runat="server" id="urlBack" href='javascript:history.go(-1);'><asp:Image runat="server" ID="imgBack" ImageUrl="~/imagens/set-pb-back.gif" /></a></td>
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
