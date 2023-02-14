<%@ Page Language="vb" AutoEventWireup="false" Codebehind="pedidoalterar.aspx.vb" Inherits="xmlinkwm.pedidoalterar"%>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
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
							<table height="100%" width="730">
								<tr vAlign="center" height="60">
									<td>
										<uc1:titulo id="Titulo1" runat="server" Titulo="Detalhes do Pedido" Descricao="Visualize os pedidos enviados para o XMLink pelos seus vendedores" imagem="imagens/pedidos.gif"></uc1:titulo>
									</td>
								</tr>
								<tr vAlign="top" height="100%">
									<td>
										<table width="100%" cellpadding="1" bgcolor="dimgray" height="50%">
											<tr>
												<td>
													<table width=100% height=100% cellpadding=0 cellspacing=0>
														<tr>
															<td height=40>
																<table width="100%" cellpadding="2" cellspacing="0" bgcolor="white" height=40>
																	<tr class='fundo'>
																		<td height="40">
																			<font face=Verdana size='2'><b>
																			Pedido nº:<asp:Label Runat="server" ID='lblNumero'></asp:Label>
																			</b></font>
																		</td>
																		<td align="center" class='TextDefault' width=30%>
																			Status <br><asp:Label Runat="server" ID="lblStatus" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																		<td align="right" class='TextDefault' width=30%>
																			Data de Emissão: <br><asp:Label Runat="server" ID="lblDataEmissao" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																	</tr>
																</table> 
															</td>
														</tr>
														<tr>
															<td>
																<table width="100%" cellpadding="2" cellspacing="0" bgcolor="white" height=100%>
																	<tr>
																		<td class=TextDefault colspan=2 align=center>
																			<asp:Label Runat=server ID='lblMensagem' CssClass='TextDefault' Font-Size=10pt Font-Bold=True />
																			<br />
																			<br />
																		</td>
																	</tr>
																	<tr>
																		<td colspan=2>
																			<asp:DataGrid Runat="server" ID='dtgMotivos' Width="100%" AutoGenerateColumns="False" AllowSorting="True" CssClass='TextDefault' BorderStyle="none">
																				<HeaderStyle ForeColor="White" CssClass='Header' />
																				<ItemStyle CssClass="GridItem" />
																				<PagerStyle PrevPageText="Anterior" NextPageText="Próximo" HorizontalAlign="center" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
																				<Columns>
																					<asp:BoundColumn DataField='his_Historico_chr' HeaderText='Última Ação Realizada Neste Pedido' />
																				</Columns>
																			</asp:DataGrid>
																		</td>																	
																	</tr>
																	<tr runat=server id='trMotivo'>
																		<td class='TextDefault' colspan=2>
																			<font class='TextDefault'>
																				Motivo:<br>
																			</font>
																			<asp:TextBox Runat=server ID='txtMotivo' TextMode=MultiLine Width=100% Rows=4></asp:TextBox>
																		</td>
																	</tr>
																	<tr>
																		<td width=50% align=center>
																			<asp:Button Runat=server ID='btnSim' CssClass='Botao' Text=' Sim ' />
																		</td>
																		<td align=center>
																			<asp:Button Runat=server ID="btnNao" CssClass='Botao' Text=' Não ' />
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
													</table> 
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
