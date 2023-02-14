<%@ Control Language="vb" AutoEventWireup="false" Codebehind="BarraNavegacao.ascx.vb" Inherits="ITC.BarraNavegacao" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table id="tblbarranavegacao" borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="100%" align="right" border="0" runat="server">
	<tr>
		<td align="right">
			<asp:LinkButton id="Firstbutton" onclick="PagerButtonClick" runat="server" CssClass="f8" Text="<img alt='Vai para a primeira p�gina' src='imagens/botaoprimeirapagina.gif' border=0>" CommandArgument="first"></asp:linkbutton>
			&nbsp;&nbsp;
			<asp:linkbutton id="Prevbutton" onclick="PagerButtonClick" runat="server" CssClass="f8" Text="<img alt='Vai para a p�gina anterior' src='imagens/botaopaginaanterior.gif' border=0>" CommandArgument="prev"></asp:linkbutton>
			&nbsp;&nbsp;
			<asp:linkbutton id="Nextbutton" onclick="PagerButtonClick" runat="server" CssClass="f8" Text="<img alt='Vai para a pr�xima p�gina' src='imagens/botaoproximapagina.gif' border=0>" CommandArgument="next"></asp:linkbutton>
			&nbsp;&nbsp;
			<asp:linkbutton id="Lastbutton" onclick="PagerButtonClick" runat="server" CssClass="f8" Text="<img alt='Vai para a �ltima p�gina' src='imagens/botaoultimapagina.gif' border=0>" CommandArgument="last"></asp:linkbutton>
		</td>
	</tr>
	<tr>
		<td align="right"><asp:Label ID="lblDescricao" CssClass="f8" Runat="server"></asp:Label></td>
	</tr>
</table>
