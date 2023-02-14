<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Horario.aspx.vb" Inherits="xmlinkwm.Horario"%>
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
										<uc1:titulo id="Titulo1" runat="server" Titulo="Controle de Horário" Descricao="Determine os horários que seus Vendedores não poderão utilizar o XMLink" imagem="imagens/security.gif"></uc1:titulo>
									</td>
								</tr>
								<tr valign="top" height="100%">
									<td>
										<table width="100%" cellpadding="1" bgcolor="dimgray" height="100%">
											<tr valign="top" bgcolor="white">
												<td height="100%">
													<asp:Repeater Runat="server" ID='rptGrid'>
														<HeaderTemplate>
															<table width=100% bgcolor=Gainsboro class='TextDefault' align=center>
																<tr>
																	<td align=center>00:00</td>
																	<td align=center>03:00</td>
																	<td align=center>06:00</td>
																	<td align=center>09:00</td>
																	<td align=center>12:00</td>
																	<td align=center>15:00</td>
																	<td align=center>18:00</td>
																	<td align=center>21:00</td>
																	<td align=center>24:00</td>
																</tr>
															</table>
														</HeaderTemplate>
														<ItemTemplate>
															<table width=100% cellpadding=0 cellspacing=0>
																<tr>
																	<td width=6%>
																		<input type=checkbox name='chkSelected' value='<%# DataBinder.Eval(Container.DataItem, "hof_HorarioFuncionamento_int_PK")%>'>
																	</td>
																	<td width=88%>
																		<table width=100% class='TextDefault' align=center border=0 cellpadding=0 cellspacing=0>
																			<tr>
																				<td align=center width='<%# (DataBinder.Eval(Container.DataItem, "hof_HorarioInicial_int") * 100 / 2400) %>%'><img src='imagens/pt.gif'></td>
																				<td align=center bgcolor=Red width='<%# ((DataBinder.Eval(Container.DataItem, "hof_HorarioFinal_int") - DataBinder.Eval(Container.DataItem, "hof_HorarioInicial_int")) * 100 / 2400)%>%'>&nbsp;</td>
																				<td align=center width='<%# 100 - (DataBinder.Eval(Container.DataItem, "hof_HorarioFinal_int") * 100 / 2400)%>%'><img src='imagens/pt.gif'></td>
																			</tr>
																			<tr>
																				<td colspan=3 align=center>
																					<%# DataBinder.Eval(Container.DataItem, "hof_Horario_chr")%> das 
																					<%# Cint(DataBinder.Eval(Container.DataItem, "hof_HorarioInicial_int")).toString("00:00")%> até as 
																					<%# Cint(DataBinder.Eval(Container.DataItem, "hof_HorarioFinal_int")).toString("00:00")%>
																				</td>
																			</tr>
																		</table>
																	</td>
																	<td>&nbsp;</td>
																</tr>
															</table>
														</ItemTemplate>
														<SeparatorTemplate>
															<table width=100% bgcolor=Gainsboro class='TextDefault' align=center>
																<tr>
																	<td align=center>00:00</td>
																	<td align=center>03:00</td>
																	<td align=center>06:00</td>
																	<td align=center>09:00</td>
																	<td align=center>12:00</td>
																	<td align=center>15:00</td>
																	<td align=center>18:00</td>
																	<td align=center>21:00</td>
																	<td align=center>24:00</td>
																</tr>
															</table>
														</SeparatorTemplate>
													</asp:Repeater>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr valign="top">
									<td height="60">
										<table width="100%" class='fundo'>
											<tr>
												<td class='TextDefault' colspan="2">Descrição
													<asp:RequiredFieldValidator Runat="server" ID='valRequired' ControlToValidate='txtNome' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' Display="Dynamic" />
													<br>
													<asp:TextBox Runat="server" ID='txtNome' CssClass="Caixa" Width="100%" />
												</td>
												<td class='TextDefault'>Das
													<asp:RequiredFieldValidator Runat="server" ID="Requiredfieldvalidator1" ControlToValidate='cboInicio' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' Display="Dynamic" />
													<br>
													<asp:DropDownList runat="server" ID='cboInicio'></asp:DropDownList>
												</td>
												<td class='TextDefault'>Até
													<asp:RequiredFieldValidator Runat="server" ID="Requiredfieldvalidator2" ControlToValidate='cboFinal' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' Display="Dynamic" />
													<br>
													<asp:DropDownList runat="server" ID="cboFinal"></asp:DropDownList>
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
												<b>Adicionar:</b>
											Adicione um novo bloqueio de acesso ao Controle de Horários.
											<li>
												<b>Excluir:</b> Exclua as regras selecionadas pela caixa de seleção.</li>
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
