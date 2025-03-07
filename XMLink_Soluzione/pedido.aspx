<%@ Page Language="vb" AutoEventWireup="false" Codebehind="pedido.aspx.vb" Inherits="xmlinkwm.pedido"%>
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
						<script language='javascript'>

							function fncAbreMapa()
							{
								var posCli = "";
								if (document.getElementById('latCli').value != 0 && document.getElementById('latCli').value != '')
									posCli = "&lat2=" + document.getElementById('latCli').value + "&lon2=" + document.getElementById('lonCli').value;
								
								var wh = window.open("http://www.xmwap.com.br/xmlinkwm/mapa.aspx?lat=<%=lblLatitude.Text%>&lon=<%=lblLongitude.Text%>" + posCli, "mapa", "width=600, height=500, toolbars=no")	;
								wh.focus();
							}
							
						</script>
						<form id="Form1" method="post" runat="server">
							<table height="100%" width="730">
								<tr vAlign="center">
									<td height="60">
										<uc1:titulo id="Titulo1" runat="server" Titulo="Detalhes do Pedido" Descricao="Visualize os pedidos enviados para o XMLink pelos seus vendedores" imagem="imagens/pedidos.gif"></uc1:titulo>
									</td>
								</tr>
								<tr vAlign="top">
									<td>
										<table width="100%" cellpadding="1" bgcolor="dimgray">
											<tr>
												<td>
													<table width=100% height=40 cellpadding=0 cellspacing=0>
														<tr>
															<td>
																<table width="100%" cellpadding="2" cellspacing="0" bgcolor="white" height=40>
																	<tr class='fundo'>
																		<td height="40">
																			<font face=Verdana size='2'><b>
																			Pedido n�:<asp:Label Runat="server" ID='lblNumero'></asp:Label>
																			</b></font>
																		</td>
																		<td align="center" class='TextDefault' width=30%>
																			Status <br><asp:Label Runat="server" ID="lblStatus" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																		<td align="right" class='TextDefault' width=30%>
																			Data de Emiss�o: <br><asp:Label Runat="server" ID="lblDataEmissao" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																	</tr>
																</table> 
															</td>
														</tr>
														<tr>
															<td>
																<table width="100%" cellpadding="2" cellspacing="0" bgcolor="white" height=100%>
																	<tr>
																		<td class=TextDefault>
																			C�digo Interno: <asp:Label Runat="server" ID="lblCodigo" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																		<td class=TextDefault>
																			Data de Entrega: <asp:Label Runat="server" ID="lblDataEntrega" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																	</tr>
																	<tr>
																		<td class=TextDefault>
																			Cliente: <asp:Label Runat="server" ID="lblCliente" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																		<td class=TextDefault>
																			Vendedor: <asp:Label Runat="server" ID="lblVendedor" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																	</tr>
																	<tr>
																		<td class=TextDefault>
																			Condi��o de Pagamento: <asp:Label Runat="server" ID="lblCondicao" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																		<td class=TextDefault>
																			Forma de Pagamento: <asp:Label Runat="server" ID="lblForma" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																	</tr>
																	<tr>
																		<td class=TextDefault>
																			Campanha Promocional:<br /><asp:Label Runat="server" ID="lblCampanha" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																		<td class=TextDefault>
																			Seq. Pedido Campanha: <asp:Label Runat="server" ID="lblCampanhaSeq" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																	</tr>
																	<tr runat=server id="rowPosicao">
																		<td class=TextDefault>
																			Latitude: <asp:Label Runat="server" ID="lblLatitude" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																		<td class=TextDefault>
																			Longitude: <asp:Label Runat="server" ID="lblLongitude" CssClass="TextDefault" Font-Bold=True></asp:Label>
																		</td>
																	</tr>
																	<tr runat=server id='rowObservacao'>
																		<td colspan=2 class='TextDefault'>
																			Observa��es:<asp:Label Runat=server ID='lblObservacao' CssClass='TextDefault' Font-Bold=True></asp:Label>
																		</td>
																	</tr>
																	<tr runat=server id="rowMostraMapa">
																		<td colspan=2 class='TextDefault'>
																			<input type='button' name='InputAbreMapa' value='Ver localiza��o no mapa' onclick='fncAbreMapa()' style='WIDTH:152px' class="Botao">
																			<asp:Image Runat=server ImageUrl="imagens\Gobe1.png" ID="globe"></asp:Image>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
													</table> 
												</td>
											</tr>
										</table>
										<br>
									</td>
								</tr>
								<tr valign="top">
									<td>
										<table width="100%" cellpadding="1" bgcolor="dimgray">
											<tr valign="top" bgcolor="white">
												<td height="100%">
													<asp:DataGrid Runat="server" ID='dtgItens' Width="100%" AutoGenerateColumns="False" AllowSorting="True" CssClass='TextDefault' BorderStyle="none">
														<HeaderStyle ForeColor="White" CssClass='Header' />
														<ItemStyle CssClass="GridItem" />
														<PagerStyle PrevPageText="Anterior" NextPageText="Pr�ximo" HorizontalAlign="right" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
														<Columns>
															<asp:BoundColumn DataField='ITP_QUANTIDADE_INT' HeaderText='Qtd.' />
															<asp:BoundColumn DataField='PRD_CODIGO_CHR' HeaderText='C�digo' />
															<asp:BoundColumn DataField='PRD_Descricao_CHR' HeaderText='Descri��o' />
															<asp:BoundColumn DataField='ITP_VALORUNITARIO_CUR' HeaderText='Pre�o Unit.' DataFormatString='{0:C}' />
															<asp:BoundColumn DataField='ITP_TOTAL_CUR' HeaderText='Total' DataFormatString='{0:C}' />
														</Columns>
													</asp:DataGrid>
												</td>
											</tr>
											<tr>
												<td>
													<table width="100%" cellpadding="2" cellspacing="0" class='fundo' height=100%>
														<tr>
															<td rowspan=3 width=50%>&nbsp;</td>
															<td class=TextDefault align=right>
																Sub-Total: 
															</td>
															<td class=TextDefault width=120>
																<asp:Label Runat="server" ID="lblSubTotal" CssClass="TextDefault" Font-Bold=True></asp:Label><br>
															</td>
														</tr>
														<tr>
															<td class=TextDefault align=right>
																<asp:Label cssclass='TextDefault' Runat="server" id='lblDescontoTitulo'>Desconto:</asp:Label>
															</td>
															<td class=TextDefault>
																<asp:Label Runat="server" ID="lblDesconto" CssClass="TextDefault" Font-Bold=True></asp:Label><br>
															</td>
														</tr>
														<tr>
															<td class=TextDefault align=right>
																Total: 
															</td>
															<td class=TextDefault>
																<asp:Label Runat="server" ID="lblTotal" CssClass="TextDefault" Font-Bold=True></asp:Label><br>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
										<br>
									</td>
								</tr>
								<tr valign="top">
									<td height="60">
										<table width="100%" class='fundo'>
											<tr>
												<td width="25%">
													<asp:Button Runat="server" ID="btnAprovar" Text='Aprovar' CssClass="Botao" />
												</td>
												<td width="25%">
													<asp:Button Runat="server" ID="btnCancelar" Text='Cancelar' CssClass="Botao" />
												</td>
												<td>&nbsp;</td>
												<td width="25%">
													<input type="button" class="Botao" value=" Voltar " onclick='location.href="principal.aspx"'>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="top" height=100%>
										<ul class='TextDefault'>
											<li>
												<b>Aprovar:</b>
											Aprova o pedido selecionado
											<li>
												<b>Cancelar:</b>
											Cancela o pedido selecionado
										</ul>
									</td>
								</tr>
							</table>
						</form>
					<!-- FIM CONTEUDO -->
				</td>
			</tr>
		</table>
		<input type="hidden" runat="server" id="latCli" value=""/>
		<input type="hidden" runat="server" id="lonCli" value=""/>
		<!-- HTML Alterado-->
	<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
	</body>
</HTML>
