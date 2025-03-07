<%@ Page Language="vb" AutoEventWireup="false" Codebehind="roteirocli.aspx.vb" Inherits="xmlinkwm.roteirocli"%>
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
										<uc1:titulo id="Titulo1" runat="server" Titulo="Cadastro de Roteiros" Descricao="Selecione o cliente a ser utilizado no cadastro de roteiro" imagem="imagens/cliente.jpg"></uc1:titulo>
									</td>
								</tr>
								<tr>
									<td>
										<table width="100%"class='frente'>
											<tr class='fundo'>
												<td>
													<table width="100%">
														<tr vAlign="top">
															<td colSpan="4"><font face="Verdana"color="#FFFFFF" size="2"><b>Filtrar os Clientes por:</b></font>
																<img src='imagens/help.gif' alt='Filtra os clientes segundo crit�rios escolhidos nas caixas de combina��o.' align="absBottom">
															</td>
														</tr>
														<tr>
															<td width=30%><font class="TextDefault">Filtro</font><br>
																<asp:TextBox Runat="server" ID='txtFiltro' CssClass='Botao' Width=100% />
															</td>
															<td vAlign="bottom">
																<asp:Button Runat="server" ID='btnFiltrar' Text='Filtrar' ToolTip="Filtrar Clientes" CssClass=Botao></asp:Button>
															</td>
															<td>&nbsp;</td>
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
													<div style="overflow:scroll;height:100%;">
													<asp:DataGrid Runat="server"  AllowPaging=False ID='dtgGrid' Width="100%" DataKeyField="cli_Cliente_int_PK" AutoGenerateColumns="False" AllowSorting="True" CssClass='TextDefault' BorderStyle="none">
														<HeaderStyle ForeColor="White" CssClass='Header' />
														<ItemStyle CssClass="GridItem" />
														<PagerStyle PrevPageText="Anterior" NextPageText="Pr�ximo" HorizontalAlign="right" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
														<Columns>
															<asp:TemplateColumn ItemStyle-Width="20" HeaderText="<input type='checkbox' name='chkSel' onclick='selectAll(document.Form1.chkSelected, document.Form1.chkSel.checked);' title='Selecionar Todos'><img src='imagens/help4.gif' align=absmiddle alt='Selecionar Todos'>">
																<ItemTemplate>
																	<asp:CheckBox Runat="server" name='chkSelected' Checked='<% #VerificaSelecionados(DataBinder.Eval(Container.DataItem, "cli_Cliente_int_PK"))%>'  ID='chkSelected' ></asp:CheckBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField='cli_Cliente_chr' HeaderText='Cliente' SortExpression='Cliente' />
															<asp:BoundColumn HeaderText='C�digo' DataField='cli_Cliente_int_PK' />
														</Columns>
													</asp:DataGrid>
													</div>
													<table width="100%">
														<tr class="GridItem" align="right">
															<td colspan="6">
																<asp:LinkButton CommandName="Paginate" CommandArgument='0' OnCommand='DataGrid_Command' ID="lnkPrevious" Runat="server">Anterior</asp:LinkButton>
																&nbsp;
																<asp:LinkButton CommandName="Paginate" CommandArgument='1' OnCommand='DataGrid_Command' ID="lnkNext" Runat="server">Pr�ximo</asp:LinkButton>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr valign="top">
									<td height="40">
										<table width="100%" class='fundo'>
											<tr>
												<td align=right width=100%>
													<asp:Button ID=btnAdicionarClientes Cssclass="Botao" Runat=server Text="Incluir Clientes"></asp:Button>
												</td>
												<td>
													<asp:Button ID=btnVoltarRoteiros Cssclass="Botao" Text=" Voltar " Runat=server></asp:Button>
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
