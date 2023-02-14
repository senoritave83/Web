<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="resumo.aspx.vb" Inherits="xmlinkwm.resumo"%>
<HTML>
	<!-- #INCLUDE FILE='inc/inc_header.ascx' -->
	<body MS_POSITIONING="GridLayout" topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
		<!-- #INCLUDE FILE='inc/inc_top.ascx' -->
		<table width="100%" cellpadding="0" cellspacing="0" height="100%">
			<tr>
				<td>
					<uc1:inc_menu id="Inc_menu1" runat="server"></uc1:inc_menu>
				</td>
				<td class='BackgrStripes' rowspan="2">&nbsp;</td>
			</tr>
			<tr height="100%">
				<td width="750" valign="top" align="middle">
					<!-- INICIO CONTEUDO -->
						<form id="Form1" method="post" runat="server">
							<table width="730">
								<tr vAlign="center" height="60">
									<td>
										<uc1:titulo id="Titulo1" runat="server" Titulo="Resumo dos pedidos" Descricao="Obtenha uma visão geral do status de todos os pedidos que estão no sistema" imagem="imagens/resumo.gif"></uc1:titulo>
									</td>
								</tr>
								<tr valign="top">
									<td>
										<asp:Label Runat="server" id='lblMessage' CssClass="TextDefault" />
										<img src='imagens/help.gif' alt='Quantidade total de pedidos no sistema' align="absBottom">
									</td>
								</tr>
								<tr valign="top">
									<td>
										<table width="100%" cellpadding="1" bgcolor="dimgray">
											<tr valign="top" bgcolor="white">
												<td>
													<asp:DataGrid Runat="server" ID='dtgGrid' Width="100%" AutoGenerateColumns="False">
														<HeaderStyle ForeColor="White" CssClass='Header' />
														<ItemStyle CssClass="GridItem" />
														<Columns>
															<asp:BoundColumn DataField='Qtd' HeaderText='Total' />
															<asp:BoundColumn DataField='sta_Status_chr' HeaderText='Status' />
														</Columns>
													</asp:DataGrid>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td>
										<table width="100%">
											<tr>
												<td align="middle">
													<input type='button' value=' Voltar ' onclick='location.href="principal.aspx";' class="Botao">
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</form>
					<!-- FIM CONTEUDO -->
				</td>
			</tr>
		</table>
		<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
	</body>
</HTML>
