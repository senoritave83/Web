<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="roteiro.aspx.vb" Inherits="xmlinkwm.roteirodet" %>

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
						<table height="100%" width="730">
							<tr vAlign="middle" height="60">
								<td><uc1:titulo id="Titulo1" runat="server" imagem="imagens/cliente.jpg" Descricao="Cadastre e edite seus roteiros"
										Titulo="Cadastro de roteiros"></uc1:titulo></td>
							</tr>
							<!-- INICIO CONTEUDO -->
					<form id="Form1" method="post" runat="server">

							<tr vAlign="top" height="100%">
								<td colSpan="2">
									<table cellPadding="1" width="100%" bgColor="black">
										<tr>
											<td class="Header"><b>Dados do Roteiro</b></td>
										</tr>
										<tr vAlign="top" bgColor="white">
											<td>
												<table width="100%">
													<tr>
														<td class="TextDefault" width="15%" runat="server" id="Td1"><b>C�digo do Roteiro</b><br>
															<asp:label id="lblRoteiro" Runat="server" Width="15%" CssClass="Caixa" />
														</td>
													</tr>
													<tr>
														<td class="TextDefault" width="15%" runat="server" id="Td2"><b>Descri��o do Roteiro</b><br>
															<asp:TextBox id="txtNomeRoteiro" MaxLength="50" Runat="server" Width="80%" CssClass="Caixa" ></asp:TextBox>
															<asp:RequiredFieldValidator Runat=server ControlToValidate=txtNomeRoteiro CssClass="TextDefault" ErrorMessage="<b>Obrigat�rio</b>" Display=Dynamic></asp:RequiredFieldValidator>
														</td>
													</tr>
													<tr>
														<td class="TextDefault" width="15%" runat="server" id='tdCodigo'><b>Vendedor</b><br>
															<asp:label id="lblVendedor" Runat="server" Width="45%" CssClass="Caixa" />
														</td>
													</tr>

                                                    <tr>
		                                                <td class='TextDefault'>
			                                                Vendedor:<br />
		                                                    <asp:DropDownList runat='server' ID='SelVendedor' DataTextField='SelVendedor' DataValueField='SelVendedor' AutoPostBack="false" Visible="false" /> 
		                                                </td>
                                                    </tr>	
                                                    												<tr>
														<td class='TextDefault'><b>Semana do M�s</b>&nbsp;<asp:RequiredFieldValidator Runat=server ControlToValidate=chlSemana CssClass="TextDefault" ErrorMessage="<b>Obrigat�rio</b>" Display=Dynamic ID="Requiredfieldvalidator1"></asp:RequiredFieldValidator><br>
															<asp:RadioButtonList ID="chlSemana" Runat="server" CssClass="TextDefault">
																<asp:ListItem Value="1">1� Semana</asp:ListItem>
																<asp:ListItem Value="2">2� Semana</asp:ListItem>
																<asp:ListItem Value="3">3� Semana</asp:ListItem>
																<asp:ListItem Value="4">4� Semana</asp:ListItem>
																<asp:ListItem Value="5">5� Semana</asp:ListItem>
															</asp:RadioButtonList>
															
														</td>
													</tr>
													<tr>
														<td class="TextDefault"><b>Dia da Semana</b>&nbsp;<asp:RequiredFieldValidator Runat=server ControlToValidate=chlDiaSemana CssClass="TextDefault" ErrorMessage="<b>Obrigat�rio</b>" Display=Dynamic ID="Requiredfieldvalidator2"></asp:RequiredFieldValidator><br>
															<asp:RadioButtonList ID="chlDiaSemana" CssClass="TextDefault" Runat="server" Width="100%" RepeatDirection="Horizontal"
																RepeatColumns="7">
																<asp:ListItem Value="1">Domingo</asp:ListItem>
																<asp:ListItem Value="2">Segunda-Feira</asp:ListItem>
																<asp:ListItem Value="3">Ter�a-Feira</asp:ListItem>
																<asp:ListItem Value="4">Quarta-Feira</asp:ListItem>
																<asp:ListItem Value="5">Quinta-Feira</asp:ListItem>
																<asp:ListItem Value="6">Sexta-Feira</asp:ListItem>
																<asp:ListItem Value="7">S�bado</asp:ListItem>
															</asp:RadioButtonList>
															
														</td>
													</tr>
													<tr>
														<td class="TextDefault"><b>Lista de Clientes Selecionados</b><br></td>
														<tr valign="top" height="100%">
															<td>
																<table width="100%" cellpadding="1" bgcolor="dimgray" height="100%">
																	<tr valign="top" bgcolor="white">
																		<td height="100%">
																			<asp:DataGrid Runat="server" ID='dtgGridClientes' Width="100%" DataKeyField="cli_Cliente_int_PK" AutoGenerateColumns="False" AllowSorting="True" CssClass='TextDefault' BorderStyle="none">
																				<HeaderStyle ForeColor="White" CssClass='Header' />
																				<ItemStyle CssClass="GridItem" />
																				<Columns>
																					<asp:BoundColumn DataField='POS' HeaderText='N�' ItemStyle-HorizontalAlign=Center ItemStyle-Width=10/>
																					<asp:BoundColumn DataField='cli_Cliente_chr' HeaderText='Cliente' />
																					<asp:BoundColumn HeaderText='C�digo' DataField='cli_Cliente_int_PK' />
																					<asp:ButtonColumn ItemStyle-HorizontalAlign=Center ItemStyle-Width='31' ButtonType='LinkButton' Text='<img src="imagens/up.gif" border="0" alt="subir" />' CommandName='UP' />
																					<asp:ButtonColumn ItemStyle-HorizontalAlign=Center ItemStyle-Width='31' ButtonType='LinkButton' Text='<img src="imagens/Down.gif" border="0" alt="descer" />' CommandName='DOWN' />
																				</Columns>
																			</asp:DataGrid>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
													  <TR>
														<td colspan=4 align=right>
															<asp:Button CssClass="botao" ID="btnEditaClientes" Runat="server" Text="Editar Clientes" ></asp:Button>
                                                            <asp:Button CssClass="botao" ID="btnCopiaRoteiro" Runat="server" Text="Copiar Roteiro" Visible="False" ></asp:Button>
														</td>
													  </TR>
												</table>
												<uc1:barrabotoes id="BarraBotoes" runat="server"></uc1:barrabotoes>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td vAlign="top">
									<ul class="TextDefault">
										<li>
											<b>Novo:</b>
										Adicione um novo roteiro � Lista de roteiros.
										<li>
											<b>Excluir:</b>
										Exclua o roteiro representado pelos dados acima.
										<li>
											<b>Salvar:</b> Grava os dados do roteiro e o coloca dispon�vel na Lista de 
											roteiros.
										</li>
									</ul>
								</td>
							</tr>
						</table></FORM>
					<!-- FIM CONTEUDO -->
				</td>
			</tr>
		</table>
		<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
	</body>
</HTML>
