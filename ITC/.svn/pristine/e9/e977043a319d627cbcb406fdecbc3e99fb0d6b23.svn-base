<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraLateral" Src="Inc/BarraLateral2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Login" Src="Inc/Login.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GuiaFornecedores.aspx.vb"  ValidateRequest="False" Inherits="ITC.GuiaFornecedores"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<%@ Register TagPrefix="uc1" TagName="Top2" Src="Inc/Top2.ascx" %>
			<table cellSpacing="0" cellpadding=0 width="100%" border="0"><tr><td><uc1:top2 id="top" runat="server"></uc1:top2></td></tr></table>
			<table id="Table1" borderColor="#809eb7" cellpadding=0 cellSpacing="0" width="100%" border="1">
				<tr>
					<td vAlign="top" noWrap width="170" bgColor="#809eb7"><uc1:barralateral id="BarraLateral1" runat="server"></uc1:barralateral></td>
					<td vAlign="top" align="middle"><IMG src="Imagens/TituloGuiaFornecedores.jpg" border="0"><br>
						<table cellspacing=0 cellpadding=0 width="80%" border="0" bordercolor="#003C6E">
							<tr>
								<td><br>
									<font class=f10>
										Neste Guia você terá acesso fácil as informações de produtos e serviços da Construção.
										Clique na letra inicial da busca desejada e o resultado trará todos os itens cadastrados.
									</font>
								</td>
							</tr>
						</table>
						<br>
						<table cellspacing=0 cellpadding=0 width="80%" border="1" bordercolor="#003C6E">
							<tr>
								<td align=center>
									<table cellspacing=0 cellpadding=0 width="100%" border="0" bgcolor="#003C6E">
										<tr>
											<td width="20%" colspan="5" align="middle">
												<asp:label Runat=server CssClass="f10" ForeColor=#FFFFFF ID="Label4"><strong>BUSCA</strong></asp:Label>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td align=center>
									<asp:datalist id="dtlLetras" CssClass="f10" Runat="server" RepeatDirection="Horizontal" RepeatColumns="28">
										<ItemTemplate>
											<a href="guiafornecedores.aspx?letra=<%# DataBinder.Eval(Container.DataItem, "Letter")%>">&nbsp;<asp:Label ID=lblLetra Runat=server ><%# DataBinder.Eval(Container.DataItem, "Letter")%></asp:Label>&nbsp;</a>
										</ItemTemplate>
									
									</asp:datalist>
									
								</td>
							</tr>
						</TABLE>
						<br>
						<table cellspacing=0 cellpadding=0 width="80%" border="1" bordercolor="#003C6E">
							<tr>
								<td align=center>
									<table cellspacing=0 cellpadding=0 width="100%" border="0" bgcolor="#003C6E">
										<tr>
											<td align="middle">
												<asp:label Runat=server CssClass="f10" ForeColor=#FFFFFF ID="Label2"><strong>PRODUTOS E SERVIÇOS</strong></asp:Label>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td align=center>
									<asp:datalist id="dtlProdutos" CssClass="f10" Runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
										<ItemStyle HorizontalAlign=Left></ItemStyle>
										<ItemTemplate>
											<a href="guiafornecedoresdet.aspx?p=<%# xmWeb.CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdProduto"))%>">&nbsp;<asp:Label ID="Label1" Runat=server ><%# DataBinder.Eval(Container.DataItem, "DescricaoProduto")%></asp:Label>&nbsp;</a>
										</ItemTemplate>
									</asp:datalist>
								</td>
							</tr>
						</table>
						<br><br>
					</td>
				</tr>
			</table>
			<uc1:rodape id="Rodapé1" runat="server"></uc1:rodape></form>
	</body>
</HTML>
