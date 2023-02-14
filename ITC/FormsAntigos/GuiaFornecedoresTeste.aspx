<%@ Register TagPrefix="uc1" TagName="Login" Src="Inc/Login.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraLateral" Src="Inc/BarraLateral.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GuiaFornecedoresTeste.aspx.vb"  ValidateRequest="False" Inherits="ITC.GuiaFornecedoresTeste"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td width="100%"><uc1:top id="Top1" runat="server"></uc1:top></td>
				</tr>
				<tr>
					<td width="100%" bgColor="#809eb7"><uc1:login id="Login1" runat="server"></uc1:login></td>
				</tr>
			</table>
			<table id="Table1" borderColor="#809eb7" cellSpacing="0" width="100%" border="1">
				<tr>
					<td vAlign="top" noWrap width="170" bgColor="#edf0f2"><uc1:barralateral id="BarraLateral1" runat="server"></uc1:barralateral></td>
					<td vAlign="top" align="middle"><IMG src="Imagens/TituloGuiaFornecedores.jpg" border="0">
						<table cellspacing="0" cellpadding="0" width="90%" border="0" bordercolor="#003c6e">
							<tr>
								<td><br>
									<font class="f10">Neste Guia de Fornecedores as empresas cadastradas estão 
										subdivididas em produtos e serviços da Construção Civil, basta clicar na letra 
										inicial do item desejado. Caso seja de seu interesse divulgar produtos e 
										serviços, entre em contato com o ITC através do e–mail <a href="mailto:itc@itc.et.br">
											<font class="f10">itc@itc.et.br</font></a> </font>
								</td>
							</tr>
						</table>
						<br>
						<TABLE width="90%" cellspacing="0" cellpadding="0">
							<TBODY>
								<TR>
									<TD class="f8" vAlign="top" width="230">
										<asp:datalist id="dtlTitulos" CssClass="f10" Runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
											<ItemTemplate>
												<B>Acessórios e Produtos</B><BR>
												<asp:datalist id="dtlItens" CssClass="f10" Runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
													<ItemTemplate>
														<SPAN class="f8"><A href="http://www.itc.etc.br?acao=sel_empresa&amp;id_sup_cat=1&amp;id_cat=7">
																Acessórios em Geral</A> , <A href="http://www.itc.etc.br?acao=sel_empresa&amp;id_sup_cat=1&amp;id_cat=134">
																Alambrados</A> , <A href="http://www.itc.etc.br?acao=sel_empresa&amp;id_sup_cat=1&amp;id_cat=10">
																Capachos</A> , <A href="http://www.itc.etc.br?acao=sel_empresa&amp;id_sup_cat=1&amp;id_cat=11">
																Cesta-Básica / Cesta-Natalina</A> , ... </SPAN>
													</ItemTemplate>
												</asp:datalist>
											</ItemTemplate>
										</asp:datalist>
									</TD>
								</TR>
							</TBODY>
						</TABLE>
						<br>
						<!-- OFERECIMENTO -->
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TBODY>
								<TR>
									<TD>
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TBODY>
												<TR>
													<TD vAlign="center">
														<TABLE cellSpacing="0" cellPadding="0" width="100%" bgColor="#000000" border="0">
															<TBODY>
																<TR>
																	<TD><IMG height="2" src="" width="1" border="0"></TD>
																</TR>
															</TBODY>
														</TABLE>
													</TD>
													<TD width="100">
														<DIV align="center"><FONT face="Verdana, Arial, Helvetica, sans-serif" size="1"><B>OFERECIMENTO</B></FONT></DIV>
													</TD>
													<TD vAlign="center">
														<TABLE cellSpacing="0" cellPadding="0" width="100%" bgColor="#000000" border="0">
															<TBODY>
																<TR>
																	<TD><IMG height="2" src="" width="1" border="0"></TD>
																</TR>
															</TBODY>
														</TABLE>
													</TD>
												</TR>
											</TBODY>
										</TABLE>
										<TABLE cellSpacing="2" cellPadding="2" width="100%" border="0">
											<TBODY>
												<TR>
													<TD width="12%"><A href="http://www.sindiconet.com.br/cotacoes/hotsite.asp?hotsite=matias"><IMG height="35" alt="Administradora de condomínios" src="imagens/logo_matias.gif" width="94" border="0"></A></TD>
													<TD align="middle" width="12%"><A href="http://www.planetaimovel.com.br/" target="_blank"><IMG height="35" alt="Maior portal de imóveis da América Latina" src="imagens/logo_planeta.gif" width="65" border="0"></A></TD>
													<TD align="middle" width="12%"><A href="http://www.sindico.com.br/informese/view.asp?id=99"><IMG height="35" alt="Associação das Administradoras" src="imagens/logo_aabic.gif" width="51" border="0"></A></TD>
													<TD align="middle" width="12%">
														<DIV align="center"><A href="http://www.sindiconet.com.br/cotacoes/hotsite.asp?hotsite=otis"><IMG height="35" alt="Software de administração" src="imagens/logo_otis.gif" width="74" border="0"></A></DIV>
													</TD>
													<TD align="middle" width="12%"><A href="http://www.sindiconet.com.br/cotacoes/hotsite.asp?hotsite=net"><IMG height="35" alt="TV por Assinatura Coletiva NET" src="imagens/logo_net.gif" width="70" border="0"></A></TD>
													<TD align="middle" width="12%"><A href="http://www.sindiconet.com.br/cotacoes/hotsite.asp?hotsite=mundial"><IMG height="35" alt="Terceirização de serviços" src="imagens/logo_mundial.gif" width="51" border="0"></A></TD>
													<TD align="middle" width="12%">
														<DIV align="center"><A href="http://www.sindiconet.com.br/cotacoes/hotsite.asp?hotsite=vtonline"><IMG height="35" alt="Vales e benefícios" src="imagens/logo_vtonline.gif" width="74" border="0"></A></DIV>
													</TD>
													<TD align="middle" width="12%"><A href="http://www.sindiconet.com.br/cotacoes/hotsite.asp?hotsite=janiking"><IMG height="35" alt="Limpeza e conservação" src="imagens/logo_janiking.gif" width="56" border="0"></A></TD>
												</TR>
											</TBODY>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD bgColor="#9c9629"><IMG height="1" src="" width="1" border="0"></TD>
								</TR>
							</TBODY>
						</TABLE>
					</td>
				</tr>
			</table>
			<uc1:rodape id="Rodapé1" runat="server"></uc1:rodape></form>
	</body>
</HTML>
