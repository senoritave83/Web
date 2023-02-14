<%@ Page Language="vb" AutoEventWireup="false" Codebehind="relatorios.aspx.vb" Inherits="xmlinkwm.relatorios" %>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/ComboBox.ascx" %>
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
						<script>
							function fncImprimir()
							{

							    var vTipo = document.getElementById("<%= cboRelatorio.ClientID%>");
							    var vIdvendedor = ("<%= cboVendedor.value %>");
							    var vNomeVendedor = ("<%= cboVendedor.text %>");
							    var vMes = document.getElementById("<%= txtMes.ClientID%>");
							    var vAno = document.getElementById("<%= txtAno.ClientID%>");
							    var vDataInicial = document.getElementById("<%= txtDataInicial.ClientID%>");
							    var vDataFinal = document.getElementById("<%= txtDataFinal.ClientID%>");

							    if (vTipo[vTipo.selectedIndex].value.toLowerCase() == 'atendimento')
								{

								    var wh = window.open('relatorio/atendimento.aspx?mes=' + vMes.value + '&ano=' + vAno.value + '&ven=' + vIdvendedor + '&nome=' + vNomeVendedor);
									wh.focus();
								}
					            else if (vTipo[vTipo.selectedIndex].value.toLowerCase() == 'roteiro')
								{
								    var wh = window.open('relatorio/roteiro.aspx?ven=' + vIdvendedor + '&nome=' + vNomeVendedor);
									wh.focus();
								}
					            else if (vTipo[vTipo.selectedIndex].value.toLowerCase() == 'visitas')
								{
								    var wh = window.open('relatorio/visitas.aspx?datainicio=' + vDataInicial.value + '&datafinal=' + vDataFinal.value + '&ven=' + vIdvendedor + '&nome=' + vNomeVendedor);
									wh.focus();
					            }
							}
						</script>
						<form id="Form1" method="post" runat="server" >
							<table height="100%" width="730">
								<tr vAlign="middle" height="60">
									<td>
										<uc1:titulo id="Titulo1" runat="server" Titulo="Relatório de uso do Sistema" Descricao="Visualize gráficos das Ordens de Serviço por Status, Responsável, Clientes e Período" imagem="imagens/reports.gif"></uc1:titulo>
									</td>
								</tr>
								<tr valign="top">
									<td>
										<table width="100%" class='frente'>
											<tr class='fundo'>
												<td>
													<table width="100%">
														<tr valign="top">
															<td colspan="6">
																<font face='Verdana'color="#FFFFFF" size="2"><b>Exibir relatório:</b></font>
															</td>
														</tr>
														<tr>
															<td colspan="3">
																<font class='TextDefault'>Relatório</font><br>
																<asp:DropDownList Runat="server" ID='cboRelatorio' AutoPostBack=True>
																	<asp:ListItem Selected="True" Value='status'>Pedidos por Status</asp:ListItem>
																	<asp:ListItem Value='vendedor'>Vendas por Vendedor</asp:ListItem>
																	<asp:ListItem Value='produtos'>Velocidade de Vendas</asp:ListItem>
																	<asp:ListItem Value='atendimento'>Atendimento a Clientes</asp:ListItem>
																	<asp:ListItem Value='roteiro'>Roteiro</asp:ListItem>
																	<asp:ListItem Value='visitas'>Visitas</asp:ListItem>
																	<asp:ListItem Value='campanhas'>Vendas por Campanha</asp:ListItem>
																</asp:DropDownList>
																<img src='imagens/help.gif' alt='Escolhe o tipo de relatório' align="absBottom">
															</td>
														</tr>
														<tr>
															<td runat=server id="colDtIni">
																<font class='TextDefault'>De</font>
																<asp:RequiredFieldValidator Runat="server" ID='valReqInicio' ControlToValidate='txtDataInicial' ErrorMessage='Campo obrigatório' Display="Dynamic" CssClass="TextDefault" />
																<asp:CompareValidator Runat="server" ID='valCompInicio' ControlToValidate='txtDataInicial' ErrorMessage='Data inválida' Display="Dynamic" CssClass="TextDefault" Type="Date" Operator="DataTypeCheck" />
																<br>
																<asp:TextBox Runat="server" ID="txtDataInicial" CssClass="Caixa" />
																<img src='imagens/help.gif' alt='Data de início do relatório' align="absBottom">
															</td>
															<td runat=server id="colDtFim">
																<font class='TextDefault'>Até</font>
																<asp:RequiredFieldValidator Runat="server" ID="valReqFinal" ControlToValidate='txtDataFinal' ErrorMessage='Campo obrigatório' Display="Dynamic" CssClass="TextDefault" />
																<asp:CompareValidator Runat="server" ID="varCompFinal" ControlToValidate='txtDataFinal' ErrorMessage='Data inválida' Display="Dynamic" CssClass="TextDefault" Type="Date" Operator="DataTypeCheck" />
																<asp:CompareValidator Runat="server" ID="Comparevalidator1" ControlToValidate='txtDataFinal' ErrorMessage='Intervalo inválido' Display="Dynamic" CssClass="TextDefault" Type="Date" Operator="GreaterThan" ControlToCompare='txtDataInicial' />
																<br>
																<asp:TextBox Runat="server" ID='txtDataFinal' CssClass="Caixa" />
																<img src='imagens/help.gif' alt='Data de término do relatório' align="absBottom">
															</td>
															<td runat=server id="colVendedor">
																<font class='TextDefault'>Vendedor</font>
																<uc1:combobox id="cboVendedor" runat="server" DefaultValue="" EnableValidation="False" DataValueField="ven_vendedor_int_PK" DataTextField="ven_Vendedor_chr"></uc1:combobox>
															</td>
															<td runat=server id="colMes">
																<font class='TextDefault'>Mes</font>
																<br>
																<asp:TextBox Runat="server" ID="txtMes" Width="50px" CssClass="Caixa" />																
															</td>
															<td runat=server id="colAno">
																<font class='TextDefault'>Ano</font>
																<br>
																<asp:TextBox Runat="server" ID="txtAno" Width="50px" CssClass="Caixa" />																
															</td>
														</tr>
														<tr>
															<td runat=server id="colExib" valign="bottom">
																<asp:Button Runat="server" ID='btnExibir' CssClass="Botao" Text='Exibir' ToolTip='Exibe relatório selecionado' />
															</td>
															<td runat=server align=right colspan=6 id="tdImprime" visible=False>
																<input type='button' name='btnImprime' value='Versão para Impressão' onclick='fncImprimir()' style='WIDTH:150px' class="Botao">
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr valign="top">
									<td align="middle" height=100% width=100%>
										<iframe id="frmRelatorio" name="frmRelatorio" src="relatorio/status.aspx" frameBorder="no" width="100%" runat="server" height="100%"></iframe>
									</td>
								</tr>
								<tr>
									<td valign="bottom">
										<ul class='TextDefault'>
											<li>
												<b>Exibir:</b> Exibe o relatório de acordo com o período e modelo de gráfico 
												selecionado pelo operador.</li>
											<li>
												<b>OBS: </b>Se você deseja criar relatórios personalizados, basta exportar os 
												dados para o seu computador. Para isso clique no botão "Exportar" que fica na 
												página principal do sistema.</li>
										</ul>
									</td>
								</tr>
							</table>
						</form>
						</form>
						<!-- FIM CONTEUDO -->
					</td>
				</tr>
			</table>
			<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
	</body>
</HTML>
