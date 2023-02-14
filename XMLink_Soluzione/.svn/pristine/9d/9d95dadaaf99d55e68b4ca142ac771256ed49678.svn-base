<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="distribuidorpontos.aspx.vb" Inherits="xmlinkwm.distribuidorpontos" %>
<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes.ascx" %>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/ComboBox.ascx" %>

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
                                                            <asp:Label ID="lblDistribuidor" runat="server"></asp:Label>
													    </td>
                                                    </tr>
												</table>
                                            </td>
										</tr>
                                        <tr valign="top" bgcolor="white">
											<td>
												<table width="100%">
													<tr>
                                                        <td class="TextDefault">Operação:<BR>                                            
                                                            <asp:DropDownList runat="server" ID="drpTipoOperacao">
                                                                <asp:ListItem Text="Crédito" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Dédito" Value="0"></asp:ListItem>
                                                            </asp:DropDownList>
													    </td>
                                                        <td class="TextDefault">Valor:<BR>
                                                            <asp:textbox id="txtValor" Runat="server" Width="67%" CssClass="Caixa"></asp:textbox>
                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtValor" Display="Dynamic" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator runat="server" ID="compMeta" ControlToValidate="txtValor" Operator="DataTypeCheck" Type="Currency" Display="Dynamic" ErrorMessage="*" Text="*"></asp:CompareValidator>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
														<td class='TextDefault' colspan="3">Motivo<BR>
															<asp:TextBox Runat="server" ID="txtMotivo" TextMode="MultiLine" Width="100%" Rows="4" CssClass="Caixa" />
                                                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtMotivo" Display="Dynamic" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
														</td>
													</tr>
                                                    <tr>
														<td class='TextDefault' colspan="3" align="right">
                                                            <asp:Button CssClass="Botao" ID="btnGravar" Text="  Gravar  " Runat="server" ></asp:Button>
                                                            <asp:Button CssClass="Botao" ID="btnVoltar" Text="  Voltar  " Runat="server" CausesValidation="false" ></asp:Button>
                                                        </td>
                                                    </tr>
												</table>
                                            </td>
										</tr>
                                        <tr>
                                            <td>
                                                <asp:datagrid id="dtgGridPontosDistribuidor" BorderStyle="none" CssClass="TextDefault" AllowSorting="True" AutoGenerateColumns="False" Width="100%" Runat="server">
													<HeaderStyle ForeColor="White" CssClass='Header' />
													<ItemStyle CssClass="GridItem" />
													<PagerStyle PrevPageText="Anterior" NextPageText="Próximo" HorizontalAlign="right" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
													<Columns>
                                                        <asp:BoundColumn DataField='Registro' HeaderText='Registro'  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                                        <asp:BoundColumn DataField='Data' HeaderText='Data'  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                                        <asp:BoundColumn DataField='Tipo' HeaderText='Tipo'  ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                                        <asp:BoundColumn DataField='Motivo' HeaderText='Motivo' />
                                                        <asp:BoundColumn DataField='Pontos' HeaderText='Pontos' ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
													</Columns>
												</asp:datagrid>
                                                <table width="100%">
													<tr>
                                                        <td class="TextDefault" colspan="2">Saldo Inicial:</td>
													    <td class="TextDefault"><asp:Label ID="lblSaldoInicial" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TextDefault" colspan="2">Total de Créditos:</td>
													    <td class="TextDefault"><asp:Label ID="lblTotalCreditos" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TextDefault" colspan="2">Total de Débitos:</td>
													    <td class="TextDefault"><asp:Label ID="lblTotalDebitos" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TextDefault" colspan="2">Saldo Final:</td>
													    <td class="TextDefault"><asp:Label ID="lblSaldoFinal" runat="server"></asp:Label></td>
                                                    </tr>
												</table>
												<table width="100%">
													<tr class="GridItem" align="right">
														<td colSpan="6"><asp:linkbutton id="lnkPrevious" Runat="server" CausesValidation="False" OnCommand="DataGrid_Command" CommandArgument="0" CommandName="Paginate">Anterior</asp:linkbutton>&nbsp;
															<asp:linkbutton id="lnkNext" Runat="server" CausesValidation="False" OnCommand="DataGrid_Command" CommandArgument="1" CommandName="Paginate">Próximo</asp:linkbutton></td>
													</tr>
												</table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                
                                            </td>
                                        </tr>
									</table>

                                    <br>
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
