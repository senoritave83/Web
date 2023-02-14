<%@ Page Language="vb" AutoEventWireup="false" Codebehind="usuarios.aspx.vb" Inherits="xmlinkwm.usuarios" %>
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
							<tr vAlign="middle" height="60">
								<td>
									<uc1:titulo id="Titulo1" runat="server" Titulo="Lista de operadores e administradores" Descricao="Cadastre e edite os dados dos Operadores/Administradores do sistema" imagem="imagens/operator4848.png"></uc1:titulo>
								</td>
							</tr>
							<tr>
								<td>
									<table width="100%" class='frente'>
										<tr class='fundo'>
											<td>
												<table width="100%">
													<tr vAlign="top">
														<td colSpan="4"><font face="Verdana"color="#FFFFFF" size="2"><b>Filtrar os usuários por:</b></font>
															<img src='imagens/help.gif' alt='Filtra os usuários segundo critérios escolhidos nas caixas de combinação.' align="absBottom">
														</td>
													</tr>
													<tr>
														<td width=30%><font class="TextDefault">Filtro</font><br>
															<asp:TextBox Runat="server" ID='txtFiltro' CssClass='Botao' Width=100% />
														</td>
														<td>&nbsp;</td>
														<td vAlign="bottom">
															<asp:Button Runat="server" ID='btnFiltrar' Text='Filtrar' ToolTip="Filtrar Usuários" CssClass=Botao CausesValidation=False></asp:Button>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr valign="top" height="100%">
								<td>
									<table width="100%" cellpadding="1" bgcolor="dimgray" height="100%">
										<tr valign="top" bgcolor="white">
											<td height="100%">
												<asp:DataGrid Runat="server" ID='dtgGrid' Width="100%" AutoGenerateColumns="False" AllowSorting="True" CssClass='TextDefault' BorderStyle="none">
													<HeaderStyle ForeColor="White" CssClass='Header' />
													<ItemStyle CssClass="GridItem" />
													<PagerStyle PrevPageText="Anterior" NextPageText="Próximo" HorizontalAlign="right" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
													<Columns>
														<asp:TemplateColumn ItemStyle-Width="20" HeaderText="<input type='checkbox' name='chkSel' onclick='selectAll(document.Form1.chkSelected, document.Form1.chkSel.checked);' title='Selecionar Todos'><img src='imagens/help4.gif' align=absmiddle alt='Selecionar Todos'>">
															<ItemTemplate>
																<input type=checkbox name='chkSelected' value='<%# DataBinder.Eval(Container.DataItem, "usu_Usuario_int_PK")%>' />
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:HyperLinkColumn DataTextField='usu_Usuario_chr' DataNavigateUrlField='usu_Usuario_int_PK' DataNavigateUrlFormatString='usuariodet.aspx?idusuario={0}' HeaderText='Operador' ItemStyle-Width="70%" />
														<asp:BoundColumn HeaderText='Tipo' DataField='usu_Tipo_chr' />
													</Columns>
												</asp:DataGrid>
												<table width="100%">
													<tr class="GridItem" align="right">
														<td colspan="6">
															<asp:LinkButton CommandName="Paginate" CommandArgument='0' OnCommand='DataGrid_Command' ID="lnkPrevious" Runat="server" CausesValidation=False>Anterior</asp:LinkButton>
															&nbsp;
															<asp:LinkButton CommandName="Paginate" CommandArgument='1' OnCommand='DataGrid_Command' ID="lnkNext" Runat="server" CausesValidation=False>Próximo</asp:LinkButton>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr valign="top">
								<td height="150">
									<table width="100%" cellpadding="1">
										<tr valign="top">
											<td colspan="4">
												<table width="100%" class='fundo'>
													<tr>
														<td width="50%" class='TextDefault'><font color=#fffff>Nome do Operador</font>
															<asp:RequiredFieldValidator Runat="server" ID='velReqNome' ControlToValidate='txtNome' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório' />
															<br>
															<asp:TextBox Runat="server" ID='txtNome' CssClass="Caixa" Width="100%" />
														</td>
														<TD>
															<table>
																<tr>
																	<td class="TextDefault"><font color=#fffff>Login</font>
																		<asp:RequiredFieldValidator Runat="server" ID='valReqLogin' ControlToValidate='txtLogin' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório' />
																		<BR>
																		<asp:TextBox id="txtLogin" Width="170" CssClass="Caixa" Runat="server" MaxLength="20"></asp:TextBox>
																	</td>
																	<td valign="bottom">
																		<img src='imagens/help.gif' alt='Nome utilizado para entrar no sistema' align="absBottom">
																	</td>
																</tr>
															</table>
														</TD>
													</tr>
													<TR>
														<td>
															<table>
																<tr>
																	<td class="TextDefault"><font color=#fffff>Senha</font>
																		<asp:RequiredFieldValidator Runat="server" ID="valReqSenha" ControlToValidate='txtSenha' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório' />
																		<BR>
																		<asp:TextBox id="txtSenha" Width="170" CssClass="Caixa" Runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
																	</td>
																	<td valign="bottom">
																		<img src='imagens/help.gif' alt='Senha utilizada para entrar no sistema' align="absBottom">
																	</td>
																</tr>
															</table>
														</td>
														<td>
															<table>
																<tr>
																	<td class="TextDefault"><font color=#fffff>Administrador</font><br>
																		<asp:CheckBox Runat="server" ID='chkAdmin' CssClass='Check' />
																	</td>
																	<td valign="bottom">
																		<img src='imagens/help.gif' alt='Determina se o usuário é Operador ou Administrador' align="absBottom">
																	</td>
																</tr>
															</table>
														</td>
													</TR>
												</table>
											</td>
										</tr>
										<tr>
											<td width="25%">
												<asp:Button Runat="server" ID='btnNovo' Text='Adicionar' CssClass="Botao" Tooltip='Adicionar um novo Operador/Administrador.' />
											</td>
											<td width="25%">
												<asp:Button Runat="server" ID="btnApagar" Text='Excluir' CssClass="Botao" CausesValidation="False" tooltip='Exclui um ou mais operadores selecionados pelas caixas de seleção.' />
											</td>
											<td width="25%">&nbsp;</td>
											<td width="25%">
												<input type="button" class="Botao" value=" Voltar " onclick='location.href="cadastros.aspx"'>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td valign="top">
									<ul class='TextDefault'>
										<li>
											<b>Adicionar:</b> Adicione um novo Operador/Administrador à lista de Operadores 
											e Administradores.</li>
										<li>
											<b>Excluir:</b> Exclua um ou mais operadores selecionados pelas caixas de 
											seleção.</li>
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
