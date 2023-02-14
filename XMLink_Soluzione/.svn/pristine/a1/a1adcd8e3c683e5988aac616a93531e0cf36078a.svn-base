<%@ Page Language="vb" AutoEventWireup="false" Codebehind="clientesdet.aspx.vb" Inherits="xmlinkwm.clientesdet" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes.ascx" %>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>

<HTML>
	<!-- #INCLUDE FILE='inc/inc_header.ascx' -->
	<script language='javascript'>

		function fncAbreMapa(p_Latitude, p_Longitude)
		{
			
			p_Latitude = p_Latitude.replace(',','.');
			p_Longitude = p_Longitude.replace(',','.');
			var wh = window.open("http://www.xmwap.com.br/xmlinkwm/mapa.aspx?lat=" + p_Latitude + "&lon=" + p_Longitude, "mapa", "width=600, height=500, toolbars=no")	;
			wh.focus();
		}
		
	</script>
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
									<td><uc1:titulo id="Titulo1" runat="server" imagem="imagens/cliente.jpg" Descricao="Cadastre e edite os dados dos seus clientes" Titulo="Cadastro de clientes"></uc1:titulo></td>
								</tr>
								<tr vAlign="top" height="100%">
									<td colSpan="2">
										<table cellPadding="1" width="100%" bgColor="dimgray">
											<tr>
												<td class="Header">Dados do cliente</td>
											</tr>
											<tr vAlign="top" bgColor="white">
												<td>
													<table width="100%">
														<tr>
															<td class="TextDefault" width="15%" runat="server" id='tdCodigo'>Código<br>
																<asp:textbox id="txtCodigo" Runat="server" Width="100%" CssClass="Caixa" />
															</td>
															<td class="TextDefault" width="35%">Nome do Cliente
																<asp:requiredfieldvalidator id="valNome" ControlToValidate="txtNome" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' Runat="server"></asp:requiredfieldvalidator><br>
																<asp:textbox id="txtNome" Runat="server" Width="100%" CssClass="Caixa"></asp:textbox>
															</td>
															<td class="TextDefault" width="20%">CNPJ <font style='COLOR:green;FONT-SIZE:7pt'>(11.111.111/0001-11)</font>
																<br>
																<asp:textbox id="txtCNPJ" onkeydown="return fncOnlyInteger();" onblur="fncFormatText(this);" onfocus="fncCleanFormat(this);" Runat="server" Width="100%" CssClass="Caixa"></asp:textbox>
															</td>
														</tr>
														<tr>
															<td class="TextDefault" colSpan="2">Endereço
																<br>
																<asp:textbox id="txtEndereco" Runat="server" Width="100%" CssClass="Caixa"></asp:textbox>
															</td>
															<td class="TextDefault">Local de referência<br>
																<asp:textbox id="txtReferencia" Runat="server" Width="100%" CssClass="Caixa"></asp:textbox>
															</td>
														</tr>
														<tr>
															<td class="TextDefault">Bairro<br>
																<asp:textbox id="txtBairro" Runat="server" Width="100%" CssClass="Caixa"></asp:textbox>
															</td>
															<td class="TextDefault">Cidade<br>
																<asp:textbox id="txtCidade" Runat="server" Width="100%" CssClass="Caixa"></asp:textbox>
															</td>
															<td class="TextDefault">CEP <font style='COLOR:green;FONT-SIZE:7pt'>(11111-111)</font><br>
																<asp:textbox id="txtCep" Runat="server" Width="100%" CssClass="Caixa"></asp:textbox>
															</td>
														</tr>
														<tr>
															<td class='TextDefault'>UF<br>
																<asp:TextBox Runat="server" ID="txtUF" CssClass="Caixa" Width="100%" />
															</td>
															<td class='TextDefault'>Contato<br>
																<asp:TextBox Runat="server" ID="txtContato" CssClass="Caixa" Width="100%" />
															</td>
															<td class='TextDefault'>Telefone<br>
																<asp:TextBox Runat="server" ID="txtTelefone" CssClass="Caixa" Width="100%" />
															</td>
														</tr>
														<tr>
															<td class="TextDefault">Tabela de Preço<br>
																<asp:textbox id="txtTabelaPreco" Runat="server" Width="100%" CssClass="Caixa"></asp:textbox></td>
															<td class="TextDefault">Desconto Máx.<br>
																<asp:textbox id="txtDescontoMax" Runat="server" Width="100%" CssClass="Caixa"></asp:textbox></td>
															<td class="TextDefault">Limite de Crédito.<br>
																<asp:textbox id="txtLimite" Runat="server" Width="100%" CssClass="Caixa"></asp:textbox></td>
														</tr>
														<tr>
															<td class="TextDefault" colSpan="3">Observação<br>
																<asp:textbox id="txtObservacao" Runat="server" Width="100%" CssClass="Caixa" Rows="4" TextMode="MultiLine"></asp:textbox><br><br></td>
														</tr>
														<tr >
															<td width="100%" class="Header" colspan=3>Localização no Mapa</td>
														</tr>
														<tr>
															<td class='TextDefault'>Latitude<br>
																<asp:TextBox Runat="server" ID="txtLatitude" CssClass="Caixa" Width="100%"></asp:TextBox>
															</td>
															<td class='TextDefault'>Longitude<br>
																<asp:TextBox Runat="server" ID="txtLongitude" CssClass="Caixa" Width="42%"></asp:TextBox>
															</td>
															<td id='tdLocalizacao' runat=server>
																<a href='javascript:void(0)' onclick='javascript:fncAbreMapa(document.Form1.txtLatitude.value, document.Form1.txtLongitude.value)'><asp:ImageButton ImageUrl='Imagens/Gobe1.png' ID='imgLocalizacao' runat=server></asp:ImageButton><font size=1>Localização no Mapa</font></a><br><br>
															</td>
														</tr>
													</table>
													<uc1:barrabotoes id="BarraBotoes1" runat="server"></uc1:barrabotoes></td>
											</tr>
										</table>
										<asp:Panel Runat="server" ID='pnlVendedores'><BR><BR>
            <TABLE cellPadding=1 width="100%" bgColor=dimgray>
              <TR>
                <TD class=Header>Vendedores autorizados</TD></TR>
              <TR vAlign=top bgColor=white>
                <TD>
<asp:Panel id=pnlMensagem Runat="server" Visible="False">
                  <TABLE 
                  style="BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; WIDTH: 100%; BORDER-COLLAPSE: collapse; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none" 
                  class=TextDefault border=1 rules=all cellSpacing=0>
                    <TR class=GridItem>
                      <TD height=25>Todos os Vendedores 
                  </TD></TR></TABLE></asp:Panel>
<asp:datagrid id=dtgVendedores CssClass="TextDefault" Width="100%" Runat="server" ShowHeader="False" BorderStyle="none" AllowSorting="True" AutoGenerateColumns="False" OnItemCommand="dtgVendedores_OnItemCommand">
															<ItemStyle CssClass="GridItem" />
															<PagerStyle PrevPageText="Anterior" NextPageText="Próximo" HorizontalAlign="right" Width="100%" Mode="NextPrev" CssClass="GridItem"></PagerStyle>
															<Columns>
																<asp:BoundColumn DataField='ven_Vendedor_chr' HeaderText='Vendedor' />
																<asp:TemplateColumn>
																	<ItemTemplate>
																		<asp:LinkButton Runat=server ID='btnExcluir' CommandName='Excluir' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ven_Vendedor_int_PK") %>' Visible='<%# (Container.DataItem("ven_Vendedor_chr") & "" <> "")%>' Text="<img src='imagens/excluir.gif' border=0 alt='Retirar Vendedor'>" />
																	</ItemTemplate>
																</asp:TemplateColumn>
															</Columns>
														</asp:datagrid>
<asp:DropDownList id=cboVendedor Runat="server" DataValueField="ven_Vendedor_int_PK" DataTextField="ven_Vendedor_chr"></asp:DropDownList>
<asp:ImageButton id=btnAdicionar Runat="server" CausesValidation="False" ImageUrl="imagens/ir.gif"></asp:ImageButton></TD></TR></TABLE> 
										</asp:Panel>
									</td>
								</tr>
								<tr>
									<td vAlign="top">
										<ul class="TextDefault">
											<li>
												<b>Novo:</b>
											Adicione um novo cliente à Lista de Clientes.
											<li>
												<b>Excluir:</b>
											Exclua o cliente representado pelos dados acima.
											<li>
												<b>Salvar:</b> Grava os dados do cliente e o coloca disponível na Lista de 
												Clientes.
											</li>
										</ul>
									</td>
								</tr>
							</table>
							<script>
								function fncCheckAdd()
									{
									if (document.Form1.cboVendedor.selectedIndex == -1)
										return false;
									}
								document.Form1.cboVendedor.selectedIndex = -1;
							</script>
						</form>
					<!-- FIM CONTEUDO -->
				</td>
			</tr> 
		</table>
		<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
	</body>
</HTML>
