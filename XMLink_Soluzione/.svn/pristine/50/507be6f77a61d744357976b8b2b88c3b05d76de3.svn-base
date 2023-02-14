<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes.ascx" %>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/ComboBox.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="vendedordet.aspx.vb" Inherits="xmlinkwm.vendedordet"%>

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
					<!-- INICIO CONTEUDO -->
					<form id="Form1" method="post" runat="server">
						<table height="100%" width="730">
							<tr vAlign="middle" height="60">
								<td>
									<uc1:titulo id="Titulo2" runat="server" Titulo="Cadastro de Vendedor" Descricao="Cadastre e edite os dados dos vendedores" imagem="imagens/responsavel6060.jpg"></uc1:titulo>
								</td>
							</tr>
							<tr valign="top" height="100%">
								<td>
									<TABLE cellPadding="1" width="100%" bgColor="dimgray">
										<TR vAlign="top" bgColor="white">
											<TD>
												<TABLE width="100%">
													<TR>
														<TD class="TextDefault" runat=server id='tdCodigo'>Código
															<asp:requiredfieldvalidator id="Requiredfieldvalidator2" Runat="server" ControlToValidate="txtCodigo" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!'></asp:requiredfieldvalidator><BR>
															<asp:textbox id="txtCodigo" CssClass="Caixa" Width="100%" Runat="server"></asp:textbox></TD>
														<TD class="TextDefault" colspan="2">Nome
															<asp:RequiredFieldValidator Runat="server" ID='valNome' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' ControlToValidate='txtNome' />
															<BR>
															<asp:TextBox id="txtNome" Width="100%" CssClass="Caixa" Runat="server"></asp:TextBox></TD>
													</TR>
													<TR>
														<TD class="TextDefault" colspan="3">Grupos <img src='imagens/help.gif' alt='Determina a qual grupo esse usuário vai pertencer.' align="absBottom">
															<BR>
															<asp:CheckBoxList Runat="server" ID='lstGrupo' CssClass='TextDefault'></asp:CheckBoxList>
														</TD>
													</TR>
													<tr>
														<td class='TextDefault' width='33%'>
															Telefone <font style='COLOR:green;FONT-SIZE:6pt'>(Formato: 1177777777)</font>
															<asp:RequiredFieldValidator Enabled="False" Runat="server" ID="valReqTel" ControlToValidate='txtTelefone' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' Display="Dynamic"></asp:RequiredFieldValidator>
															<asp:RegularExpressionValidator id="valRegTel" runat="server" ControlToValidate="txtTelefone" ErrorMessage='<img src="imagens/exclam2.gif"> Número inválido!' ValidationExpression="\d{10}" Display="Dynamic" />
															<br>
															<asp:TextBox Runat="server" ID="txtTelefone" CssClass="Caixa" Width="100%" />
														</td>
														<td class="TextDefault" width='33%'>
															ID <font style='COLOR:green;FONT-SIZE:6pt'>(Formato: 55*111*111)</font>
															<asp:RequiredFieldValidator Enabled="False" Runat="server" ID="Requiredfieldvalidator1" ControlToValidate='txtID' Display="Dynamic" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!'></asp:RequiredFieldValidator>
															<asp:RegularExpressionValidator id="Regularexpressionvalidator1" runat="server" ControlToValidate="txtID" Display="Dynamic" ErrorMessage='<img src="imagens/exclam2.gif"> Formato inválido!' ValidationExpression="55\*\d{1,6}\*\d{1,6}" />
															<BR>
															<asp:TextBox id="txtID" Width="100%" CssClass="Caixa" Runat="server"></asp:TextBox>
														</td>
														<td class="TextDefault" width='33%'>
															Desconto Máximo
															<asp:requiredfieldvalidator id="Requiredfieldvalidator3" Runat="server" ControlToValidate="txtDesconto" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' Display="Dynamic" />
															<asp:CompareValidator Runat="server" ControlToValidate='txtDesconto' Operator="DataTypeCheck" Type="Double" ErrorMessage='<img src="imagens/exclam2.gif"> Valor inválido!' Display="Dynamic" id="CompareValidator1" />
															<asp:textbox id="txtDesconto" CssClass="Caixa" Width="100%" Runat="server"></asp:textbox>
														</td>
													</tr>
													<tr>
														<td class='TextDefault'>
															Login
															<asp:requiredfieldvalidator id="Requiredfieldvalidator4" Runat="server" ControlToValidate="txtLogin" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' Display="Dynamic" />
															<asp:textbox id="txtLogin" CssClass="Caixa" Width="100%" Runat="server"></asp:textbox>
														</td>
														<td class='TextDefault'>
															<asp:Panel Runat="server" ID='pnlSenha' Visible="False" Width="100%">
																Senha<BR>
<asp:textbox id=txtSenha Runat="server" Width="100%" CssClass="Caixa"></asp:textbox>
															</asp:Panel>
														</td>
														<td class='TextDefault'>
															Status<br>
															<asp:DropDownList Runat=server ID='cboAtivo' CssClass="Caixa"></asp:DropDownList>															
														</td>
													</tr>
													<tr>
														<td class='TextDefault'>
															<br>
															<asp:CheckBox Runat="server" ID="chkAcessoWeb" Text='Acesso WEB'></asp:CheckBox>
														</td>
													</tr>
													<tr>
														<td class='TextDefault'>
															<br>
															<asp:CheckBox Runat="server" ID='chkTodosClientes' Text='Visualiza Todos os Clientes'></asp:CheckBox>
														</td>
													</tr>
													<tr>
														<td class='TextDefault' colspan="3">Observação<br>
															<asp:TextBox Runat="server" ID="txtObservacao" TextMode="MultiLine" Width="100%" Rows="4" CssClass="Caixa" />
														</td>
													</tr>
												</TABLE>
												<uc1:BarraBotoes id="BarraBotoes1" runat="server"></uc1:BarraBotoes></TD>
										</TR>
									</TABLE><br>
									<table width="100%" border=1 bordercolor=#000000 cellpadding=0 cellspacing=1>
										<tr>
											<td>
												<table width="100%" border=0 cellpadding=1 cellspacing=0>
													<tr bgcolor=black>
														<a href="javascript:void(0)" id='lnkRoteiro' runat=server></ASP:ADROTATOR><td class='TextDefault' width="100%">
																<font color=white><b>Exibir Roteiros</b></font>
														</td></a>
														<td>
															<a href="javascript:void(0)" id='lnkRoteiro2' runat=server><img align=right src="imagens/drop.gif" border=0 ></a>
														</td>
													</tr>
													<tr id='tblRoteiro' runat=server visible=false>
														<td colspan=2 class="TextDefault">
															<table width="100%" cellpadding="1" bgcolor="FFFFFF" height="100%">
																<tr valign="top" bgcolor="white">
																	<td height="100%">
																		<asp:DataGrid Runat="server" ID='dtgGridRoteiros' Width="100%" AutoGenerateColumns="False" AllowSorting="True" CssClass='TextDefault' BorderStyle="none">
																			<HeaderStyle ForeColor="White" CssClass='Header' />
																			<ItemStyle CssClass="GridItem" />
																			<PagerStyle PrevPageText="Anterior" NextPageText="Próximo" HorizontalAlign="right" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
																			<Columns>
																				<asp:TemplateColumn ItemStyle-Width="20%" HeaderText="Código do Roteiro" ItemStyle-Wrap="False" HeaderStyle-Font-Bold="True">
																					<ItemTemplate>
																						<a href="roteiro.aspx?idvendedor=<%# DataBinder.Eval(Container.DataItem, "ven_vendedor_int_fk")%>&idroteiro=<%# DataBinder.Eval(Container.DataItem, "rot_roteiro_int_pk")%>">
																						<asp:Label ID="lblCodigo" Runat="server"><%# DataBinder.Eval(Container.DataItem, "rot_roteiro_int_pk")%></asp:Label>
																						</a>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn ItemStyle-Width="35%" HeaderText="Nome" ItemStyle-Wrap="False" HeaderStyle-Font-Bold="True">
																					<ItemTemplate>
																						<a href="roteiro.aspx?idvendedor=<%# DataBinder.Eval(Container.DataItem, "ven_vendedor_int_fk")%>&idroteiro=<%# DataBinder.Eval(Container.DataItem, "rot_roteiro_int_pk")%>">
																						<asp:Label ID="Label2" Runat="server"><%# DataBinder.Eval(Container.DataItem, "rot_Nome_chr")%></asp:Label>
																						</a>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn ItemStyle-Width="15%" HeaderText="Semana" ItemStyle-Wrap="False" HeaderStyle-Font-Bold="True">
																					<ItemTemplate>
																						<a href="roteiro.aspx?idvendedor=<%# DataBinder.Eval(Container.DataItem, "ven_vendedor_int_fk")%>&idroteiro=<%# DataBinder.Eval(Container.DataItem, "rot_roteiro_int_pk")%>">
																						<asp:Label ID="lblSemana" Runat="server"><%# DataBinder.Eval(Container.DataItem, "rot_Semana_chr")%></asp:Label>
																						</a>
																					</ItemTemplate>
																				</asp:TemplateColumn>
                                                                                <asp:TemplateColumn ItemStyle-Width="15%" HeaderText="Dia da Semana" ItemStyle-Wrap="False" HeaderStyle-Font-Bold="True">
																					<ItemTemplate>
																						<a href="roteiro.aspx?idvendedor=<%# DataBinder.Eval(Container.DataItem, "ven_vendedor_int_fk")%>&idroteiro=<%# DataBinder.Eval(Container.DataItem, "rot_roteiro_int_pk")%>">
																						<asp:Label ID="lblDiaSemana" Runat="server"><%# DataBinder.Eval(Container.DataItem, "rot_DiaSemana_chr")%></asp:Label>
																						</a>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn ItemStyle-Width="15%" HeaderText="Criado Em" ItemStyle-Wrap="False" HeaderStyle-Font-Bold="True">
																					<ItemTemplate>
																						<a href="roteiro.aspx?idvendedor=<%# DataBinder.Eval(Container.DataItem, "ven_vendedor_int_fk")%>&idroteiro=<%# DataBinder.Eval(Container.DataItem, "rot_roteiro_int_pk")%>">
																						<asp:Label ID="Label1" Runat="server"><%# DataBinder.Eval(Container.DataItem, "rot_data_dtm")%></asp:Label>
																						</a>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			</Columns>			
																		</asp:DataGrid>
																		<table width="100%" id=tblPaginacao runat=server>
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
																<tr bgcolor=#ffffff>
																	<td>
																		<asp:Label ID=lblMensagem Runat=server CssClass="TextDefault">Nenhum Roteiro Encontrado!</asp:Label>
																	</td>
																</tr>
															</table>
															<tr>
																<td align=right>
																	<asp:Button Runat="server" CssClass="Botao" ID="btnCadastrarRoteiro" Text="Novo Roteiro"></asp:Button>
																</td>
															</tr>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td valign="top">
									<ul class='TextDefault'>
										<li>
											<b>Novo:</b>Cadastre um novo Vendedor.
										<li>
											<b>Excluir:</b>
										Exclua este registro da Lista de Vendedores.
										<li>
											<b>Salvar:</b> Grave este registro na Lista de Vendedores.</li>
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
