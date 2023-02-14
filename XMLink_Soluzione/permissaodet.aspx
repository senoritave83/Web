<%@ Page Language="vb" AutoEventWireup="false" Codebehind="permissaodet.aspx.vb" Inherits="xmlinkwm.Permissaodet"%>
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
			<td width="750" valign="top" align="middle">
				<!-- INICIO CONTEUDO -->
				<form id="Form1" method="post" runat="server">
					<table height="100%" width="730">
						<tr vAlign="center" height="60">
							<td>
								<uc1:titulo id="Titulo1" runat="server" Titulo="Cadastro de permissões" Descricao="Cadastre e edite as permissões dos usuários do sistema" imagem="imagens/security.gif"></uc1:titulo>
							</td>
						</tr>
						<tr valign="top" height="100%">
							<td colspan="2">
								<table width="100%" cellpadding="1" bgcolor="dimgray">
									<tr valign="top" bgcolor="white">
										<td>
											<table width="100%">
												<tr>
													<td class='TextDefault' width="35%">Nome da Permissão
														<asp:RequiredFieldValidator Runat="server" ID="valMensagem" ControlToValidate="txtNome" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' />
														<br>
														<asp:TextBox Runat="server" ID='txtNome' CssClass="Caixa" Width="100%" />
													</td>
												</tr>
												<TR>
													<TD class="TextDefault">Usuários <img src='imagens/help.gif' alt='Seleciona os usuários que irão participar desta permissão.' align="absBottom">
														<BR>
														<asp:CheckBoxList Runat="server" ID='lstUsuarios' CssClass='TextDefault'></asp:CheckBoxList>
													</TD>
												</TR>
												<tr>
													<td align=center>
														<font style='font-family:Verdana;font-size:10pt;font-weight:bold;'>Ações atribuidas</font>
													</td>
												</tr>
												<tr valign=top>
													<td>
														<asp:DataList Runat=server ID='lstSecoes' BorderWidth=0 CellPadding=2 CellSpacing=0 Width=100% RepeatColumns=3 ItemStyle-VerticalAlign=Top>
															<ItemTemplate>
																<table border="0" cellpadding="0" cellspacing="0" width="100%">
																	<tr>
																		<td valign="top" class='Header'>
																			<%# DataBinder.Eval(Container.DataItem, "aca_Secao_chr") %>
																		</td>
																	</tr>
																	<tr>
																		<td Class="GridItem">
																			<asp:TemplateColumn>
																				<asp:DataGrid runat=server ID='dtgGrid' DataSource='<%# ListarAcoes(DataBinder.Eval(Container.DataItem, "aca_Secao_chr")) %>' Width=100% ShowHeader=False AutoGenerateColumns=False>
																					<Columns>
																						<asp:TemplateColumn>
																							<ItemTemplate>
																								<input type=checkbox name='chkAcoes' value='<%# DataBinder.Eval(Container.DataItem, "aca_Acao_int_PK")%>' <%# iif(DataBinder.Eval(Container.DataItem, "permissao") = 1, "checked", "")%> />
																							</ItemTemplate>
																						</asp:TemplateColumn>
																						<asp:BoundColumn DataField='aca_Acao_chr' ItemStyle-CssClass=GridItem></asp:BoundColumn>
																					</Columns>
																				</asp:DataGrid> 
																			</asp:TemplateColumn>
																		</td> 
																	</tr> 
																</table> 
															</ItemTemplate>
														</asp:DataList>
													</td>
												</tr>
											</table>
											<br>
											<br>
											<br>
											<uc1:BarraBotoes id="BarraBotoes1" runat="server"></uc1:BarraBotoes>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td valign="top">
								<ul class='TextDefault'>
									<li>
										<b>Novo:</b>Crie um novo grupo de permissões.
									</li>
									<li>
										<b>Excluir:</b>Exclua o grupo de permissões selecionado.
									</li> 
									<li>
										<b>Salvar:</b> Salva as alterações efetuadas no Grupo de Permissões.</li>
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
</html> 
