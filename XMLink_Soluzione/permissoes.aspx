<%@ Page Language="vb" AutoEventWireup="false" Codebehind="permissoes.aspx.vb" Inherits="xmlinkwm.permissoes"%>
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
									<uc1:titulo id="Titulo1" runat="server" Titulo="Lista de permissões de usuários" Descricao="Cadastre e edite as permissões dos usuários do sistema" imagem="imagens/security.gif"></uc1:titulo>
								</td>
							</tr>
							<tr>
								<td>
									<table width="100%"class='frente'>
										<tr class='fundo'>
											<td>
												<table width="100%">
													<tr vAlign="top">
														<td colSpan="4"><font face="Verdana"color="#FFFFFF" size="2"><b>Filtrar as Permissões de 
																	Usuários por:</b></font> <img src='imagens/help.gif' alt='Filtra as permissões de usuários com o texto digitado abaixo.' align="absBottom">
														</td>
													</tr>
													<tr>
														<td width="30%"><font class="TextDefault">Filtro</font><br>
															<asp:TextBox Runat="server" ID='txtFiltro' CssClass='Botao' Width="100%" />
														</td>
														<td>&nbsp;</td>
														<td vAlign="bottom">
															<asp:Button Runat="server" ID='btnFiltrar' Text='Filtrar' ToolTip="Filtrar Grupos" CssClass="Botao" CausesValidation="False"></asp:Button>
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
														<asp:TemplateColumn ItemStyle-Width="20" HeaderText="<input type='checkbox' name='chkSel' onclick='selectAll(document.Form2.chkSelected, document.Form2.chkSel.checked);' title='Selecionar Todos'><img src='imagens/help4.gif' align=absmiddle alt='Selecionar Todos'>">
															<ItemTemplate>
																<input type=checkbox name='chkSelected' value='<%# DataBinder.Eval(Container.DataItem, "per_Permissao_int_PK")%>' />
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:HyperLinkColumn DataTextField='per_Permissao_chr' DataNavigateUrlField='per_Permissao_int_PK' DataNavigateUrlFormatString='permissaodet.aspx?idpermissao={0}' HeaderText='Permissão' />
														<asp:BoundColumn HeaderText="Criado em" DataFormatString='{0:d}' DataField='per_Criado_dtm' />
													</Columns>
												</asp:DataGrid>
												<table width="100%">
													<tr class="GridItem" align="right">
														<td colspan="6">
															<asp:LinkButton CommandName="Paginate" CommandArgument='0' OnCommand='DataGrid_Command' ID="lnkPrevious" Runat="server" CausesValidation="False">Anterior</asp:LinkButton>
															&nbsp;
															<asp:LinkButton CommandName="Paginate" CommandArgument='1' OnCommand='DataGrid_Command' ID="lnkNext" Runat="server" CausesValidation="False">Próximo</asp:LinkButton>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr valign="top">
								<td height="60">
									<table width="100%" class='fundo'>
										<tr>
											<td class='TextDefault' colspan="4">Nome da Permissão
												<asp:RequiredFieldValidator Runat="server" ID='valRequired' ControlToValidate='txtNome' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' />
												<br>
												<asp:TextBox Runat="server" ID='txtNome' CssClass="Caixa" Width="100%" />
											</td>
										</tr>
										<tr>
											<td width="25%">
												<asp:Button Runat="server" ID='btnNovo' Text='Adicionar' CssClass="Botao" />
											</td>
											<td width="25%">
												<asp:Button Runat="server" ID="btnApagar" Text='Excluir' CssClass="Botao" CausesValidation="False" />
											</td>
											<td width="25%">&nbsp;</td>
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
											<b>Adicionar:</b> Adicione uma nova permissão do sistema.</li>
										<li>
											<b>Excluir:</b> Exclua as permissões selecionadas pela caixa de seleção.</li>
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
