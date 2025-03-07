<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes.ascx" %>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/ComboBox.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="distribuidoresDet.aspx.vb" Inherits="xmlinkwm.distribuidoresDet"%>

<HTML>
	<head>
        <style type="text/css">
            .Caixa
            {}
        </style>
    </head>
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
									<uc1:titulo id="Titulo2" runat="server" Titulo="Cadastro de Distribuidor" Descricao="Cadastre e edite os dados dos distribuidores" imagem="imagens/responsavel6060.jpg"></uc1:titulo>
								</td>
							</tr>
							<tr valign="top" height="300">
								<td>
									<table cellpadding="1" width="100%" bgcolor="dimgray">
										<tr valign="top" bgcolor="white">
											<td>
												<table width="100%">
													<tr>
                                                        <td class="TextDefault" colspan="2">Distribuidor:
														    <BR>                                            
                                                            <uc1:ComboBox id="cboDistribuidorCliente" runat="server" DataValueField='IDCliente' DataTextField='Cliente'></uc1:ComboBox>
													    </td>
													    <td class="TextDefault" runat=server id='tdCodigo'>
                                                            Pontos:<BR>                                                            
                                                            <a href='distribuidorpontos.aspx?idistribuidor=<%=ViewState("IDistribuidor")%>'><asp:Label ID="lblPontos" runat="server"></asp:Label></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
														<td colspan="2" class="TextDefault" colspan="3">
                                                            Email:<BR>
														    <asp:TextBox id="txtEmail" Width="93%" CssClass="Caixa" Runat="server"></asp:TextBox>
                                                        </td>
													</TR>
													<tr>
														<td class='TextDefault'>
															Login:<BR>
                                                            <asp:textbox id="txtLogin" Runat="server" Width="84%" CssClass="Caixa"></asp:textbox>
                                                            <asp:RequiredFieldValidator runat="server" ID="reqLogin" ControlToValidate="txtLogin" Display="Dynamic" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
														</td>
														<td class='TextDefault'><BR>
															<asp:Panel Runat="server" ID='pnlSenha' Visible="False" Width="100%">
																Senha:<BR>
                                                                <asp:textbox id="txtSenha" Runat="server" Width="83%" CssClass="Caixa"></asp:textbox>
                                                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtSenha" Display="Dynamic" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
														    </asp:Panel>&nbsp;
														</td>
														<td class='TextDefault'>
															Status:<BR>
															<asp:DropDownList Runat="server" ID='cboAtivo' CssClass="Caixa"></asp:DropDownList>															
														</td>
													</tr>
                                                    <tr>
														<td class='TextDefault'>
															Fator Tabela:<BR>
                                                            <asp:textbox id="TxtFator" Runat="server" Width="53%" CssClass="Caixa" value="1"></asp:textbox>
                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="TxtFator" Display="Dynamic" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator runat="server" ID="CompareValidator2" ControlToValidate="TxtFator" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ErrorMessage="*" Text="*"></asp:CompareValidator>
														</td>
														<td class='TextDefault'>
														    Meta Anual:<BR>
                                                            <asp:textbox id="txtMeta" Runat="server" Width="67%" CssClass="Caixa"></asp:textbox>
                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtMeta" Display="Dynamic" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator runat="server" ID="compMeta" ControlToValidate="txtMeta" Operator="DataTypeCheck" Type="Currency" Display="Dynamic" ErrorMessage="*" Text="*"></asp:CompareValidator>
														</td>
														<td class='TextDefault'>
															Desconto:<BR>
															<asp:textbox id="txtDesconto" Runat="server" Width="74%" CssClass="Caixa" value="0"></asp:textbox>														
                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtDesconto" Display="Dynamic" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator runat="server" ID="CompareValidator1" ControlToValidate="txtDesconto" Operator="DataTypeCheck" Type="Double" Display="Dynamic" ErrorMessage="*" Text="*"></asp:CompareValidator>
														</td>
													</tr>
													<tr>
														<td class='TextDefault' colspan="3">Observação<BR>
															<asp:TextBox Runat="server" ID="txtObservacao" TextMode="MultiLine" Width="100%" Rows="4" CssClass="Caixa" />
														</td>
													</tr>
												</table>
												<uc1:BarraBotoes id="BarraBotoes1" runat="server"></uc1:BarraBotoes>
                                            </td>
										</tr>
									</table>
                                    <br>
								</td>
							</tr>
							<tr>
								<td valign="top">
									<ul class='TextDefault'>
										<li>
											<b>Novo:			<ul class='TextDefault'>
										<li>
											<b>Novo:</b>Cadastre um novo Distribuidor.
										<li>
											<b>Excluir:</b>
										Exclua este registro da Lista de Distribuidores.
										<li>
											<b>Salvar:</b> Grave este registro na Lista de Distribuidores.</li>
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