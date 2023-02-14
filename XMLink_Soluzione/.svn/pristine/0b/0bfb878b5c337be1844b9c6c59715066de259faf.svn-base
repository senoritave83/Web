<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/ComboBox.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="produtos.aspx.vb" Inherits="xmlinkwm.produtos"%>
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
									<uc1:titulo id="Titulo1" runat="server" Titulo="Lista de Produtos" Descricao="Cadastre e edite os dados dos produtos da sua empresa" imagem="imagens/responsavel6060.jpg"></uc1:titulo>
								</td>
							</tr>
							<tr>
								<td>
									<table width="100%"class='frente'>
										<tr class='fundo'>
											<td>
												<table width="100%">
													<tr vAlign="top">
														<td colSpan="4"><font face="Verdana"color="#FFFFFF" size="2"><b>Filtrar as condiçoes de 
																	pagamentos por:</b></font> <img src='imagens/help.gif' alt='Filtra as condições de pagamento segundo critérios escolhidos nas caixas de combinação.' align="absBottom">
														</td>
													</tr>
													<tr>
														<td><font class='TextDefault'>Categoria</font><br>
															<asp:DropDownList Runat="server" ID='cboFiltroCategoria' DataTextField='cat_Categoria_chr' DataValueField='cat_Categoria_int_PK'></asp:DropDownList>
														</td>
														<td width="30%"><font class="TextDefault">Filtro</font><br>
															<asp:TextBox Runat="server" ID='txtFiltro' CssClass='Botao' Width="100%" />
														</td>
														<td>&nbsp;</td>
														<td vAlign="bottom">
															<asp:Button Runat="server" ID='btnFiltrar' Text='Filtrar' ToolTip="Filtrar Clientes" CssClass="Botao" CausesValidation=False></asp:Button>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr valign="top" height="100%">
								<td colspan="2">
									<table width="100%" cellpadding="1" bgcolor="dimgray" height="100%">
										<tr valign="top" bgcolor="white">
											<td height="100%">
												<asp:DataGrid Runat="server" ID='dtgGrid' Width="100%" AutoGenerateColumns="False" AllowSorting="True" CssClass='TextDefault' BorderStyle="none">
													<HeaderStyle ForeColor="White" CssClass='Header' />
													<ItemStyle CssClass="GridItem" />
													<PagerStyle PrevPageText="Anterior" NextPageText="Próximo" HorizontalAlign="right" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
													<Columns>
														<asp:TemplateColumn ItemStyle-Width="20" HeaderText="<input type='checkbox' title='Selecionar Todas' name='chkSel' onclick='selectAll(document.Form1.chkSelected, document.Form1.chkSel.checked);'><img src='imagens/help4.gif' align=absmiddle alt='Selecionar Todos'>">
															<ItemTemplate>
																<input type=checkbox name='chkSelected' value='<%# DataBinder.Eval(Container.DataItem, "prd_Produto_int_PK")%>' />
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:HyperLinkColumn ItemStyle-Width="20%" DataTextField='prd_Codigo_chr' DataNavigateUrlField='prd_Produto_int_PK' DataNavigateUrlFormatString='produtodet.aspx?idproduto={0}' HeaderText='Produto' />
														<asp:BoundColumn DataField='prd_Descricao_chr' HeaderText='Descrição' />
														<asp:BoundColumn DataField='prd_PrecoUnitario_cur' HeaderText='Preço' ItemStyle-Width="70" ItemStyle-HorizontalAlign="left" DataFormatString='{0:C}' />
														<asp:BoundColumn DataField='prd_Estoque_int' HeaderText='Estoque' ItemStyle-HorizontalAlign="Center" />
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
								<td height="150" colspan="2">
									<table width="100%" class='fundo'>
										<tr>
											<td width="100%" colspan="4">
												<TABLE width="100%">
													<TR>
														<TD class="TextDefault"><font color=white>Código</font>
															<asp:RequiredFieldValidator Runat="server" ID='valtxtCodigo' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' ControlToValidate='txtCodigo' />
															<BR>
															<asp:TextBox id="txtCodigo" Width="100%" CssClass="Caixa" Runat="server"></asp:TextBox></TD>
														<td class='TextDefault' colspan="2"><font color=white>Descrição</font>
															<asp:RequiredFieldValidator Runat="server" ID="valtxtDescricao" ControlToValidate='txtDescricao' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!'></asp:RequiredFieldValidator>
															<br>
															<asp:TextBox Runat="server" ID="txtDescricao" CssClass="Caixa" Width="100%" />
														</td>
													</TR>
													<TR>
														<TD class="TextDefault" width="33%"><font color=white>Categoria</font>
															<BR>
															<uc1:ComboBox id="cboCategoria" runat="server" DataValueField='cat_Categoria_int_PK' DataTextField='cat_Categoria_chr'></uc1:ComboBox>
														</TD>
														<TD class="TextDefault" width="33%"><font color=white>Estoque</font>
															<asp:RequiredFieldValidator Runat="server" ID="Requiredfieldvalidator1" ControlToValidate='txtEstoque' Display="Dynamic" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' />
															<asp:CompareValidator runat="server" id='valComEstoque' ControlToValidate="txtEstoque" Type="Integer" Operator="DataTypeCheck" ErrorMessage='<img src="imagens/exclam2.gif"> Valor inválido!' Display="Dynamic" />
															<BR>
															<asp:TextBox id="txtEstoque" Width="100%" CssClass="Caixa" Runat="server"></asp:TextBox>
														</TD>
														<TD class="TextDefault" width="33%"><font color=white>Preço Unitário</font>
															<asp:RequiredFieldValidator Runat="server" ID="Requiredfieldvalidator2" ControlToValidate='txtPrecoUnitario' Display="Dynamic" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!'></asp:RequiredFieldValidator>
															<asp:CompareValidator runat="server" id="Comparevalidator1" ControlToValidate="txtPrecoUnitario" Type="Currency" Operator="DataTypeCheck" ErrorMessage='<img src="imagens/exclam2.gif"> Valor inválido!' Display="Dynamic" />
															<BR>
															<asp:TextBox id="txtPrecoUnitario" Width="100%" CssClass="Caixa" Runat="server"></asp:TextBox>
														</TD>
													</TR>
												</TABLE>
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
											<b>Adicionar:</b>
										Adicione um novo Produto à lista de Produtos.
										<li>
											<b>Excluir:</b> Exclua um ou mais produtos selecionados pelas caixas de 
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
