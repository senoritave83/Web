<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes.ascx" %>
<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="condicaodet.aspx.vb" Inherits="xmlinkwm.condicaodet"%>
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
									<uc1:titulo id="Titulo1" runat="server" Titulo="Cadastro de Condições" Descricao="Cadastre e edite as Condições de Pagamentos" imagem="imagens/group6060.jpg"></uc1:titulo>
								</td>
							</tr>
							<tr valign="top" height="100%">
								<td colspan="2">
									<table width="100%" cellpadding="1" bgcolor="dimgray">
										<tr valign="top" bgcolor="white">
											<td>
												<table width="100%">
													<tr>
														<td class='TextDefault' width="35%" runat=server id='tdCodigo'>Código
															<asp:RequiredFieldValidator Runat="server" ID="Requiredfieldvalidator3" ControlToValidate="txtCodigo" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' Display="Dynamic" />
															<br>
															<asp:TextBox Runat="server" ID="txtCodigo" CssClass="Caixa" Width="100%" />
														</td>
														<td>&nbsp;</td>
													</tr>
													<tr>
														<td class='TextDefault' colspan="2">Nome da Condição de Pagamento
															<asp:RequiredFieldValidator Runat="server" ID="valMensagem" ControlToValidate="txtCondicao" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' />
															<br>
															<asp:TextBox Runat="server" ID='txtCondicao' CssClass="Caixa" Width="100%" />
														</td>
													</tr>
													<TR>
														<td class='TextDefault' valign="bottom">Correção
															<asp:RequiredFieldValidator Runat="server" ID="Requiredfieldvalidator1" ControlToValidate='txtCorrecao' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' Display="Dynamic" />
															<asp:CompareValidator Runat="server" ID="Requiredfieldvalidator2" ControlToValidate='txtCorrecao' ErrorMessage='<img src="imagens/exclam2.gif"> Valor inválido!' Display="Dynamic" operator="DataTypeCheck" type='Currency' />
															<br>
															<asp:TextBox Runat="server" ID="txtCorrecao" CssClass="Caixa" Width="100%" />
														</td>
														<td>&nbsp;</td>
													</TR>
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
											<b>Novo:</b>
										Crie um nova Condição de Pagamento.
										<li>
											<b>Excluir:</b>
										Exclua a Condição selecionada.
										<li>
											<b>Salvar:</b> Salva as alterações efetuadas na Condição de Pagamento.</li>
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
