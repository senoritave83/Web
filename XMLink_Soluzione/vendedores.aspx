7<%@ Page Language="vb" AutoEventWireup="false" Codebehind="vendedores.aspx.vb" Inherits="xmlinkwm.vendedores"%>
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
								<td><uc1:titulo id="Titulo1" runat="server" imagem="imagens/responsavel6060.jpg" Descricao="Cadastre e edite os dados dos vendedores" Titulo="Lista de Vendedores"></uc1:titulo></td>
							</tr>
							<tr>
								<td>
									<table width="100%"class='frente'>
										<tr class='fundo'>
											<td>
												<table width="100%">
													<tr vAlign="top">
														<td colSpan="4"><font face="Verdana"color="#FFFFFF" size="2"><b>Filtrar os vendedores por:</b></font>
															<IMG alt="Filtra os vendedores segundo critérios escolhidos nas caixas de combinação." src="imagens/help.gif" align="absBottom">
														</td>
													</tr>
													<tr>
														<td width="30%"><font class="TextDefault">Filtro</font><br>
															<asp:textbox id="txtFiltro" CssClass="Botao" Width="100%" Runat="server"></asp:textbox></td>
														<td>&nbsp;</td>
														<td vAlign="bottom"><asp:button id="btnFiltrar" CssClass="Botao" Runat="server" Text="Filtrar" CausesValidation="False" ToolTip="Filtrar Vendedores"></asp:button></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr vAlign="top" height="100%">
								<td colSpan="2">
									<table height="100%" cellPadding="1" width="100%" bgColor="dimgray">
										<tr vAlign="top" bgColor="white">
											<td height="100%"><asp:datagrid id="dtgGrid" BorderStyle="none" CssClass="TextDefault" AllowSorting="True" AutoGenerateColumns="False" Width="100%" Runat="server">
													<HeaderStyle ForeColor="White" CssClass='Header' />
													<ItemStyle CssClass="GridItem" />
													<PagerStyle PrevPageText="Anterior" NextPageText="Próximo" HorizontalAlign="right" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
													<Columns>
														<asp:TemplateColumn ItemStyle-Width="20" HeaderText="<input type='checkbox' title='Selecionar Todas' name='chkSel' onclick='selectAll(document.Form1.chkSelected, document.Form1.chkSel.checked);'><img src='imagens/help4.gif' align=absmiddle alt='Selecionar Todos'>">
															<ItemTemplate>
																<input type=checkbox name='chkSelected' value='<%# DataBinder.Eval(Container.DataItem, "ven_Vendedor_int_PK")%>' />
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:HyperLinkColumn ItemStyle-Width="50%" DataTextField='ven_Vendedor_chr' DataNavigateUrlField='ven_Vendedor_int_PK' DataNavigateUrlFormatString='vendedordet.aspx?idvendedor={0}' HeaderText='Vendedor' />
														<asp:BoundColumn DataField='grp_Grupo_chr' HeaderText='Grupo' />
														<asp:BoundColumn DataField='ven_Status_chr' HeaderText='Status' ItemStyle-Width="70" ItemStyle-HorizontalAlign="left" />
														<asp:BoundColumn DataField='ven_Criado_dtm' HeaderText='Criado em' DataFormatString='{0:d}' ItemStyle-Width="80" ItemStyle-HorizontalAlign="Center" />
													</Columns>
												</asp:datagrid>
												<table width="100%">
													<tr class="GridItem" align="right">
														<td colSpan="6"><asp:linkbutton id="lnkPrevious" Runat="server" CausesValidation="False" OnCommand="DataGrid_Command" CommandArgument="0" CommandName="Paginate">Anterior</asp:linkbutton>&nbsp;
															<asp:linkbutton id="lnkNext" Runat="server" CausesValidation="False" OnCommand="DataGrid_Command" CommandArgument="1" CommandName="Paginate">Próximo</asp:linkbutton></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr vAlign="top">
								<td colSpan="2" height="150">
									<table width="100%" class='fundo'>
										<tr>
											<td width="25%"><input type="button" value="Adicionar" onclick='location.href="vendedordet.aspx?idvendedor=0";' Title='Adicionar Vendedor' class='Botao' runat=server id='btnNovo'></td>
											<td width="25%"><asp:button id="btnApagar" CssClass="Botao" Runat="server" Text="Excluir" CausesValidation="False"></asp:button></td>
											<td width="25%">&nbsp;</td>
											<td width="25%"><input class="Botao" onclick='location.href="cadastros.aspx"' type="button" value=" Voltar ">
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td vAlign="top">
									<ul class="TextDefault">
										<li>
											<b>Adicionar:</b>
										Adicione um novo Vendedor à lista de Vendedores.
										<li>
											<b>Excluir:</b> Exclua um ou mais vendedores selecionados pelas caixas de 
											seleção.
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
