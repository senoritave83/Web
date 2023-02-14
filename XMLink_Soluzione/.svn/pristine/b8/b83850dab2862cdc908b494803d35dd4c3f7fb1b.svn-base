<%@ Page Language="vb" AutoEventWireup="false" Codebehind="principal.aspx.vb" Inherits="xmlinkwm.principal" %>
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
									<uc1:titulo id="Titulo1" runat="server" Titulo="Últimos Pedidos" Descricao="Monitore os Últimos Pedidos enviados pelos seus vendedores" imagem="imagens/listaos.gif"></uc1:titulo>
								</td>
							</tr>
							<tr vAlign="top" height="400">
								<td>
									<table height="100%" cellPadding="1" width="100%" bgColor="dimgray">
										<tr vAlign="top" bgColor="white">
											<td><iframe id="frmGrid" name="frmLista" src="lista.aspx?tm=<%# Now()%>" frameBorder="no" width="100%" runat="server" height="100%"></iframe>
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
														<td colSpan="6"><font face="Verdana"color="#FFFFFF" size="2"><b>Filtrar os Pedidos por:</b></font>
															<img src='imagens/help.gif' alt='Filtra os Pedidos enviados segundo critérios escolhidos nas caixas de combinação.' align="absBottom">
														</td>
													</tr>
													<tr>
														<td><font class="TextDefault">Cliente</font><br>
															<asp:TextBox Runat=server ID='txtCliente' />
														</td>
														<td><font class="TextDefault">Vendedor</font><br>
															<asp:TextBox Runat=server ID="txtVendedor" />
														<td><font class="TextDefault">Status</font><br>
															<uc1:combobox id="cboStatus" runat="server" DefaultValue="Todos" EnableValidation="False" DataValueField="sta_Status_int_PK" DataTextField="sta_Status_chr"></uc1:combobox>
                                                        </td>
														<td vAlign="bottom">
                                                            <asp:Button CssClass="Botao" runat='server' ID="btFiltrar" Text="Filtrar" ToolTip="Filtrar O.S." />
														</td>
														<td>&nbsp;</td>
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
											<td align="middle" width="25%">&nbsp;</td>
											<td align="middle" width="25%"><input class="Botao" onclick='location.href="recados.aspx";' type="button" value="Recados" title='Visualizar recados digitais ' runat=server id='btnRecados'>
											</td>
											<td align="middle" width="25%"><input class="Botao" onclick='location.href="resumo.aspx";' type="button" value="Resumo" title='Visualizar resumo' runat=server id='btnResumo'>
											</td>
											<td align="middle" width="25%"><input class="Botao" onclick='location.href="historico.aspx";' type="button" value="Histórico" title='Visualizar histórico de pedidos.' runat=server id='btnHistorico'>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td valign="top">
									<ul class='TextDefault'>
										<li>
											<b>Exportar:</b>
										Exporte os pedidos para o desenvolvimento de relatórios gerencias ou para 
										importação no sistema interno (somente para administradores).
										<li>
											<b>Recados:</b>
										Envie mensagens de texto unidirecionais para os seus vendedores.
										<li>
											<b>Resumo:</b>
										Visualize o sumário dos pedidos enviados até o momento.
										<li>
											<b>Histórico:</b> Visualize e gerencie os pedidos enviados anteriormente, 
											armazenadas na sessão Histórico.</li>
									</ul>
								</td>
							</tr>
						</table>

						<%--<script>

						    function fncFiltrar()
							    {
							    var vUrl = 'lista.aspx?cliente=' + document.Form1.txtCliente.value + '&vendedor=' + document.Form1.txtVendedor.value + '&idstatus=' + document.Form1.cboStatus_DropDownList1.options[document.Form1.cboStatus_DropDownList1.selectedIndex].value;
							    frmGrid.document.location.href= vUrl;
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
