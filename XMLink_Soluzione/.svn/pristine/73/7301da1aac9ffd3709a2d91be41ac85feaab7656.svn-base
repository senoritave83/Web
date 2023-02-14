<%@ Page Language="vb" AutoEventWireup="false" Codebehind="importacao.aspx.vb" Inherits="DTSGenerico.Importacao"%>
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
										<uc1:titulo id="Titulo1" runat="server" Titulo="Importação de Dados" Descricao="Importe os dados gerados pelo sistema para dentro do XMLink" imagem="imagens/importar.gif"></uc1:titulo>
									</td>
								</tr>
								<tr vAlign="top" height="100%">
									<td>
										<table width="100%" cellpadding="1" bgcolor="dimgray" height="100%">
											<tr valign="top" bgcolor="white">
												<td height="100%">
													<table width="100%"class='frente'>
														<tr class='fundo'>
															<td>
																<table width="100%">
																	<tr vAlign="top">
																		<td colSpan="6"><font face="Verdana"color="#FFFFFF" size="2"><b>Filtrar por:</b></font>
																			<img src='imagens/help.gif' alt='Filtra os arquivos enviados segundo critérios escolhidos nas caixas de combinação.' align="absBottom">
																		</td>
																	</tr>
																	<tr>
																		<td><font class="TextDefault">Tipo de Arquivo</font><br>
																			<asp:DropDownList id="cboFiltroTipo" runat="server" DefaultValue="Todos" EnableValidation="False" DataValueField="tip_Tipo_int_PK" DataTextField="tip_Tipo_chr"></asp:DropDownList></td>
																		<td><font class="TextDefault">Status</font><br>
																			<asp:DropDownList id="cboFiltroStatus" runat="server" DefaultValue="Todos" EnableValidation="False">
																				<asp:ListItem Value='0'>Todos</asp:ListItem>
																				<asp:ListItem Value='1'>Recebido</asp:ListItem>
																				<asp:ListItem Value='2'>Processado</asp:ListItem>
																				<asp:ListItem Value='3'>Cancelado</asp:ListItem>
																				<asp:ListItem Value='4'>Formato Inválido</asp:ListItem>
																				<asp:ListItem Value='5'>Processando...</asp:ListItem>
																			</asp:DropDownList>
																		</td>
																		<td vAlign="bottom">
																			<asp:Button Runat=server cssclass="Botao" id="btnFiltrar" Text='Filtrar' title='Filtrar arquivos.' CausesValidation=False /> 
																		</td>
																		<td>&nbsp;</td>
																	</tr>
																</table>
															</td>
														</tr>
													</table>
													<asp:DataGrid Runat="server" ID='dtgGrid' Width="100%" AutoGenerateColumns="False" AllowSorting="True" CssClass='TextDefault' BorderStyle="none" DataKeyField='pro_Arquivo_chr' OnItemCommand='dtgGrid_ItemCommand'>
														<HeaderStyle ForeColor="White" CssClass='Header' />
														<ItemStyle CssClass="GridItem" />
														<PagerStyle PrevPageText="Anterior" NextPageText="Próximo" HorizontalAlign="right" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
														<Columns>
															<asp:TemplateColumn ItemStyle-Width="20" HeaderText="<input type='checkbox' name='chkSel' onclick='selectAll(document.Form2.chkSelected, document.Form2.chkSel.checked);' title='Selecionar Todos'><img src='imagens/help4.gif' align=absmiddle alt='Selecionar Todos'>">
																<ItemTemplate>
																	<input type=checkbox name='chkSelected' value='<%# DataBinder.Eval(Container.DataItem, "pro_Arquivo_chr")%>' />
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField='pro_DataInclusao_dtm' HeaderText='Data de Inclusão' />
															<asp:BoundColumn DataField='pro_Arquivo_chr' HeaderText='Arquivo' />
															<asp:BoundColumn DataField='pro_Tipo_chr' HeaderText='Tipo' />
															<asp:BoundColumn DataField='pro_Status_chr' HeaderText='Status' />
															<asp:BoundColumn DataField='pro_Obs_chr' HeaderText='Observações' />
															<asp:ButtonColumn CommandName='Processar' ButtonType=PushButton Text='Proc'></asp:ButtonColumn>
														</Columns>
													</asp:DataGrid>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr valign="top">
									<td height="60">
										<table width="100%" class='fundo'>
											<tr>
												<td class='TextDefault' colspan="2">Tipo de Arquivo<br>
													<asp:DropDownList id="cboTipo" runat="server"  DataValueField="tip_Tipo_int_PK" DataTextField="tip_Tipo_chr" />
												</td>
												<td class='TextDefault'>Arquivo
													<asp:RequiredFieldValidator Runat="server" ID='valRequired' ControlToValidate='filArquivo' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' />
													<br>
													<input type="file" runat="server" id='filArquivo'>
												</td>
												<td width="25%"><br>
													<asp:Button Runat="server" ID='btnEnviar' Text='Enviar' CssClass="Botao" />
												</td>
											</tr>
											<tr>
												<td width="25%">
													<asp:Button Runat="server" ID="btnApagar" Text='Excluir' CssClass="Botao" CausesValidation="False" />
												</td>
												<td width="50%">&nbsp;</td>
												<td width="25%">
													<input type="button" class="Botao" value=" Voltar " onclick='location.href="configuracoes.aspx"'>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td valign="top">
										<ul class='TextDefault'>
											<li>
												<b>Enviar:</b>
											Envia o arquivo indicado para o sistema de importações do XMLink.
											<li>
												<b>Excluir:</b> Exclua os arquivos selecionados pela caixa de seleção.
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
