<%@ Page Language="vb" AutoEventWireup="false" Codebehind="campanhas.aspx.vb" Inherits="xmlinkwm.campanhas"%>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes.ascx" %>
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
				<td width="750" valign="top" align="center">
					<form id="Form1" method="post" runat="server">
						<table height="100%" width="730">
							<tr vAlign="middle" height="60">
								<td>
									<uc1:titulo id="Titulo2" runat="server" Titulo="Cadastro de Campanha" Descricao="Cadastre e visualize suas campanhas" imagem="imagens/responsavel6060.jpg"></uc1:titulo>
								</td>
							</tr>
							<!-- INICIO CONTEUDO -->
							<tr valign="top" height="100%">
								<td>
									<TABLE cellPadding="1" width="100%" bgColor="dimgray">
										<TR vAlign="top" class='fundo'>
											<TD>
												<table width="100%">
													<tr vAlign="top">
														<td colSpan="2"><font face="Verdana"color="#ffffff" size="2"><b>Filtrar as campanhas cadastradas por nome:</b></font> 
														<img src='imagens/help.gif' alt='Filtra as condi��es de pagamento segundo crit�rios escolhidos na caixa texto.' align="absBottom">
														</td>
													</tr>
													<tr>
														<td width="30%"><font class="TextDefault">C�digo</font><br>
															<asp:TextBox Runat="server" ID='txtFiltro' CssClass='Botao' Width="100%" />
														</td>
														<td vAlign="bottom">
															<asp:Button Runat="server" ID='btnFiltrar' Text='Filtrar' ToolTip="Filtrar Campanhas" CssClass="Botao" CausesValidation=False></asp:Button>
														</td>
													</tr>
												</table>
											</TD>
										</TR>
									</TABLE>
									<TABLE TABLE cellPadding="1" width="100%" bgColor="white">
										<TR>
											<TD>
												<table width="100%" cellpadding="1" bgcolor="dimgray" height="100%" >
													<tr valign="top" bgcolor="white">
														<td height="100%">
															<asp:DataGrid Runat="server" ID='dtgGrid' Width="100%" AutoGenerateColumns="False" AllowSorting="True" CssClass='TextDefault' BorderStyle="none">
																<HeaderStyle ForeColor="White" CssClass='Header' />
																<ItemStyle CssClass="GridItem" />
																<PagerStyle PrevPageText="Anterior" NextPageText="Pr�ximo" HorizontalAlign="right" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
																<Columns>
																	<asp:HyperLinkColumn ItemStyle-Width="15%" DataTextField='cmp_Codigo_chr' DataNavigateUrlField='cmp_Campanha_int_PK' DataNavigateUrlFormatString='Campanhas.aspx?idcampanha={0}' HeaderText='C�digo' />
																	<asp:BoundColumn DataField='cmp_Descricao_chr' HeaderText='Campanha' />
																	<asp:BoundColumn DataField='cmp_ValidIni_dtm' HeaderText='In�cio' ItemStyle-Width="75" ItemStyle-HorizontalAlign="center" />
																	<asp:BoundColumn DataField='cmp_ValidFim_dtm' HeaderText='T�rmino' ItemStyle-Width="75" ItemStyle-HorizontalAlign="center" />
																</Columns>
															</asp:DataGrid>
															<table width="100%">
																<tr class="GridItem" align="right">
																	<td colspan="6">
																		<asp:LinkButton CommandName="Paginate" CommandArgument='0' OnCommand='DataGrid_Command' ID="lnkPrevious" Runat="server" CausesValidation=False>Anterior</asp:LinkButton>
																		&nbsp;
																		<asp:LinkButton CommandName="Paginate" CommandArgument='1' OnCommand='DataGrid_Command' ID="lnkNext" Runat="server" CausesValidation=False>Pr�ximo</asp:LinkButton>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</TD>
										</TR>
										<tr>
											<td>
												<table width="100%" class='fundo'>
													<tr>
														<td width="100%" colspan="4">
															<table width="100%">
                                                                <tr style="vertical-align: top;">
                                                                    <td class="TextDefault" width='33%' rowspan="4" style="padding:10px 10px 10px 0px;">
                                                                        <asp:Image runat="server" ID="imgOS" ImageUrl="~/imagens/campanhas/noimage.png" Width="280" BorderWidth="1" BorderColor="White" />
                                                                        <br />
                                                                        <asp:FileUpload runat="server" ID="flImgOS" />
                                                                        <br />
                                                                        <asp:Button runat="server" ID="btnSalvarFoto" Text="Salvar Imagem" CssClass="Botao" />
                                                                    </td>
																	<td class="TextDefault" runat="server" id="Td1">
                                                                        <font color="white">C�digo da Campanha:</font><br />
																		<asp:textbox id="txtCodigo" CssClass="Caixa" Width="50%" Runat="server"></asp:textbox>
																	</td>
																	<td class='TextDefault' width='33%'>
                                                                        <font color="white">Descri��o:</font>
																		<asp:RequiredFieldValidator Enabled="False" Runat="server" ID="Requiredfieldvalidator8" ControlToValidate='txtNome' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigat�rio!' Display="Dynamic"></asp:RequiredFieldValidator>
																		<br>
																		<asp:TextBox Runat="server" ID="txtNome" CssClass="Caixa" Width="90%" MaxLength="300" />
																	</td>
                                                                </tr>
																<tr style="vertical-align: top; height: 10px;">
																	<td class="TextDefault" width='33%'>
                                                                        <font color="white">Valor M�nimo por per�odo:</font>
																		<asp:RequiredFieldValidator Enabled="False" Runat="server" ID="Requiredfieldvalidator9" ControlToValidate='txtValor' Display="Dynamic" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigat�rio!'></asp:RequiredFieldValidator>
																		<BR>
																		<asp:TextBox id="txtValor" Width="50%" CssClass="Caixa" Runat="server"></asp:TextBox>
																	</td>
																	<td class='TextDefault'>
                                                                        <font color="white">N� de Parcelas:	</font> 
																		<asp:RadioButtonList ID="rblParcelas" RepeatDirection="Horizontal" BorderWidth="1" BorderColor="#993300" CssClass="Caixa" Runat="server" AutoPostBack="True">
																			<asp:ListItem Value="1" Selected="True"><font color="white">�nica</font></asp:ListItem>
																			<asp:ListItem Value="2" Selected="False"><font color="white">Parcelas</font></asp:ListItem>
																		</asp:RadioButtonList>
																		<asp:requiredfieldvalidator id="Requiredfieldvalidator1" Runat="server" ControlToValidate="rblParcelas" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigat�rio!' Display="Dynamic" />
                                                                        
																		<asp:TextBox id="txtParcelas" Visible="False" CssClass="Caixa" Runat="server" Width="50%"></asp:TextBox>
																	</td>
																</tr>
																<tr style="vertical-align: top;">
																	<td class="TextDefault" width='33%'>
                                                                        <font color="white">Data de In�cio:</font><br>
																		<asp:requiredfieldvalidator id="Requiredfieldvalidator5" Runat="server" ControlToValidate="txtDataIni" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigat�rio!' Display="Dynamic" />
																		<asp:textbox id="txtDataIni" CssClass="Caixa" Width="50%" Runat="server"></asp:textbox>
																	</td>
																	<td class='TextDefault'>
                                                                        <font color="white">Data de T�rmino:</font><br>
																		<asp:textbox id="txtDataFim" CssClass="Caixa" Width="50%" Runat="server"></asp:textbox>
																	</td>
																</tr>
                                                                <tr style="vertical-align: top;">
                                                                    <td class="TextDefault" width='33%'>
                                                                        <font color="white">Pontos:</font><br>
                                                                        <asp:TextBox ID="txtPontos" CssClass="Caixa" Width="50%" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="TextDefault" width='33%'>
                                                                        <font color="white">Detalhes:</font><br>
                                                                        <asp:TextBox ID="txtDetalhes" CssClass="Caixa" TextMode="MultiLine" Rows="2" Width="100%" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
															</table>
														</td>
													</tr>
													<tr>
														<td width="25%">
															<asp:Button Runat="server" ID='btnSalvar' Text='Salvar Campanha' ForeColor="Red" CssClass="Botao" Width="80%" />
														</td>
														<td width="25%">
															<asp:Button Runat="server" ID="btnLimpar" Text='Limpar' CssClass="Botao" />
														</td>
														<td width="25%">
															<asp:Button Runat="server" ID="btnDesativar" Text='Desativar' CssClass="Botao" />
														</td>
														<td width="25%">
															<input type="button" class="Botao" value=" Voltar " onclick='location.href="cadastros.aspx"'>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</TABLE>
								</td>
							</tr>
							<tr>
								<td valign="top">
									<ul class='TextDefault'>
										<li>
											<b>Adicionar:</b> 
                                            Cadastre uma nova campanha.               
										<li>
											<b>Limpar:</b> Limpe o formul�rio de campanhas. 
              							<li>
											<b>Desativar:</b> Desative a(s) campanha(s) selecionada(s).
										</li>
									</ul>
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
