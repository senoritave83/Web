<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="usuariodet.aspx.vb" Inherits="xmlinkwm.usuariodet" %>
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
						<tr valign="top" height="100%">
							<td>
								<table width="100%" cellpadding="1" bgcolor="dimgray">
									<tr valign="top" bgcolor="white">
										<td>
											<table width="100%">
												<tr>
													<td class='TextDefault'>Nome do Operador
														<asp:RequiredFieldValidator Runat="server" ID='velReqNome' ControlToValidate='txtNome' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório' />
														<br>
														<asp:TextBox Runat="server" ID='txtNome' CssClass="Caixa" Width="100%" />
													</td>
												</tr>
												<TR runat=server id='rowPermissoes' valign=top>
													<TD class="TextDefault">
														<table width=100%>
															<tr>
																<td class='Header' colspan=2>Permissões <img src='imagens/help.gif' alt='Determina quais permissões este usuário irá ter.' align="absBottom">
															</tr>
															<tr>
																<td class='GridItem' colspan=2>
																	<asp:CheckBoxList Runat="server" ID='lstPermissoes' CssClass='TextDefault'></asp:CheckBoxList>
																</td>
															</tr>
															<tr>
																<td class='TextDefault' width="35%">
																	Administrador<br>
																	<asp:CheckBox Runat="server" ID='chkAdmin' CssClass='Check' />
																</td>
																<td>
																	<img src='imagens/help.gif' alt='Determina se o usuário será Operador ou Administrador' align="absBottom">
																</td>
															</tr>
														</table> 
													</TD>
												</TR>
												<tr>
													<td class='fundo'><asp:Button Runat="server" ID='btnLogin' Text='Editar dados de Acesso'></asp:Button>
														<img src='imagens/help.gif' alt='Edita os dados de acesso do Operador/Administrador' align="absBottom">
													</td>
												</tr>
											</table>
											<br>
											<asp:Panel Runat="server" ID='pnlAcesso' Visible="False">
												<TABLE width="100%">
													<TR>
														<TD class="TextDefault" width="35%">Login
															<asp:RequiredFieldValidator id="Requiredfieldvalidator2" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório' ControlToValidate="txtLogin" Runat="server"></asp:RequiredFieldValidator><BR>
															<asp:TextBox id="txtLogin" Runat="server" Width="100%" CssClass="Caixa"></asp:TextBox></TD>
														<TD class="TextDefault" width="35%">Senha
															<asp:RequiredFieldValidator id="Requiredfieldvalidator1" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório' ControlToValidate="txtSenha" Runat="server"></asp:RequiredFieldValidator><BR>
															<asp:TextBox id="txtSenha" Runat="server" Width="100%" CssClass="Caixa" TextMode="Password"></asp:TextBox></TD>
													</TR>
												</TABLE>
											</asp:Panel>
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
										<b>Editar dados de acesso:</b>
									Editar os dados de acesso do usuário como login e senha.
									<li>
										<b>Novo:</b>
									Adicione um novo Operador/Administrador à lista de Operadores e 
									Administradores.
									<li>
										<b>Excluir:</b> Exclua o Operador/Administrador do sistema.</li>
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
