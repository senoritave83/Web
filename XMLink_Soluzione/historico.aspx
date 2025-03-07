<%@ Page Language="vb" AutoEventWireup="false" Codebehind="historico.aspx.vb" Inherits="xmlinkwm.historico"%>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/ComboBox.ascx" %>
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
						<table height="100%" cellPadding="5" width="730" border="0">
							<tr vAlign="center" height="60">
								<td>
									<uc1:titulo id="Titulo1" runat="server" Titulo="Hist�rico de Pedidos" Descricao="Visualize os pedidos enviados pelos seus vendedores" imagem="imagens/historico.gif"></uc1:titulo>
								</td>
							</tr>
							<tr vAlign="top" height="400">
								<td>
									<table height="100%" cellPadding="1" width="100%" bgColor="dimgray">
										<tr vAlign="top" bgColor="white">
											<td>
                                                <iframe id="frmGrid" name="frmLista" src="lista.aspx" frameBorder="no" width="100%" runat="server" height="100%"></iframe>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table width="100%"class='frente'>
										<tr class='fundo'>
											<td>
												<table width="100%">
													<tr vAlign="top">
														<td colSpan="3"><font face="Verdana"color="#FFFFFF" size="2"><b>Filtrar os Pedidos por:</b></font>
															<img src='imagens/help.gif' alt='Filtra os Pedidos enviados segundo crit�rios escolhidos nas caixas de combina��o.' align="absBottom">
														</td>
													</tr>
													<tr>
														<td width=33%><font class="TextDefault">Cliente</font><br>
															<asp:TextBox Runat=server ID='txtCliente' />
														</td>
														<td width=33%><font class="TextDefault">Vendedor</font><br>
															<asp:TextBox Runat=server ID="txtVendedor" />	
														</td>
														<td width=33%><font class="TextDefault">Status</font><br>
                                                            <uc1:combobox id="cboStatus" runat="server" DefaultValue="Todos" EnableValidation="False" DataValueField="sta_Status_int_PK" DataTextField="sta_Status_chr"></uc1:combobox>
                                                        </td>
													</tr>
													<tr>
														<td><font class="TextDefault">Data Inicial</font>
															<asp:RequiredFieldValidator Runat="server" ID='valReqInicio' ControlToValidate='txtDataInicio' ErrorMessage='Campo obrigat�rio' Display="Dynamic" CssClass="TextDefault"  />
															<asp:CompareValidator Runat="server" ID='valCompInicio' ControlToValidate='txtDataInicio' ErrorMessage='Data inv�lida' Display="Dynamic" CssClass="TextDefault" Type="Date" Operator="DataTypeCheck" />
															<br>
															<asp:TextBox Runat="server" ID='txtDataInicio' />
															<img src='imagens/help.gif' alt='Data inicial do filtro' align="absBottom">
														</td>
														<td><font class="TextDefault">Data Final</font>
															<asp:RequiredFieldValidator Runat="server" ID="Requiredfieldvalidator1" ControlToValidate='txtDataFinal' ErrorMessage='Campo obrigat�rio' Display="Dynamic" CssClass="TextDefault" />
															<asp:CompareValidator Runat="server" ID="Comparevalidator1" ControlToValidate='txtDataFinal' ErrorMessage='Data inv�lida' Display="Dynamic" CssClass="TextDefault" Type="Date" Operator="DataTypeCheck" />
															<br>
															<asp:TextBox Runat="server" ID='txtDataFinal' />
															<img src='imagens/help.gif' alt='Data Final do filtro' align="absBottom">
														</td>
														<td vAlign="bottom">
                                                            <asp:Button CssClass="Botao" runat='server' ID="btFiltrar" Text="Filtrar" ToolTip="Filtar Pedidos." />
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table width="100%" class='fundo'>
										<tr>
											<td align="middle" width="75%">&nbsp;</td>
											<td align="middle" width="25%">
                                                <input class="Botao" onclick='location.href="principal.aspx";' type="button" value="Voltar" title='Voltar para a tela principal.'>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>

						<%--<script type="text/javascript">

						    function fncFiltrar() {
						        var vUrl = 'lista.aspx?cliente=' + document.Form1.txtCliente.value + '&vendedor=' + document.Form1.txtVendedor.value + '&idstatus=' + document.Form1.cboStatus_DropDownList1.options[document.Form1.cboStatus_DropDownList1.selectedIndex].value + '&datainicio=' + escape(document.Form1.txtDataInicio.value) + '&datafinal=' + escape(document.Form1.txtDataFinal.value);
						        frmGrid.document.location.href = vUrl;
						    }

						</script>--%>

					</form>
					<!-- FIM CONTEUDO -->
				</td>
			</tr>
		</table>
		<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
	</body>
</HTML>
