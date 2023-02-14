<%@ Register TagPrefix="xm" Namespace="XMSistemas.WebControls" Assembly="XMCombo" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="wapconfig.aspx.vb" Inherits="xmlinkwm.wapconfig"%>
<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
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
									<uc1:titulo id="Titulo1" runat="server" Titulo="Configuração do WAP" Descricao="Configure o comportamento do XMLink WAP para seus vendedores" imagem="imagens/config.gif"></uc1:titulo>
								</td>
							</tr>
							<tr vAlign="top" height="100%">
								<td>
									<table width="100%">
										<tr>
											<td class='TextDefault'>Itens por página<br>
												<asp:DropDownlist Runat="server" id="cboItensPerPage">
													<asp:ListItem Value="10" Selected="True">10</asp:ListItem>
													<asp:ListItem Value="20">20</asp:ListItem>
													<asp:ListItem Value="30">30</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='Determina o número máximo de itens a ser exibido nas listagens' align="absBottom">
											</td>
											<td class='TextDefault'>Busca Produto<br>
												<asp:DropDownlist Runat="server" id="cboBuscaProduto">
													<asp:ListItem Value="0" Selected="True">Busca por Nome</asp:ListItem>
													<asp:ListItem Value="1">Busca por Código</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='Determina o modo de procura de produto na listagem de produtos' align="absBottom">
											</td>
										</tr>
										<tr>
											<td class='TextDefault'>Visualiza Estoque<br>
												<asp:DropDownlist Runat="server" id="cboVisualizaEstoque">
													<asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
													<asp:ListItem Value="1">Sim</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='O Vendedor poderá visualizar o estoque do produto' align="absBottom">
											</td>
											<td class='TextDefault'>Busca Cliente<br>
												<asp:DropDownlist Runat="server" id="cboBuscaCliente">
													<asp:ListItem Value="0" Selected="True">Busca por Nome</asp:ListItem>
													<asp:ListItem Value="1">Busca por Código</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='Determina o modo de entrada de cliente no pedido' align="absBottom">
											</td>
										</tr>
										<tr>
											<td class='TextDefault'>Entrada de Produto<br>
												<asp:DropDownlist Runat="server" id="cboEntradaProduto">
													<asp:ListItem Value="0" Selected="True">Busca por Nome</asp:ListItem>
													<asp:ListItem Value="1">Busca por Código</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='Determina o modo de entrada de produtos no pedido' align="absBottom">
											</td>
											<td class='TextDefault'>Venda sem estoque<br>
												<asp:DropDownList Runat="server" id="cboVendaSEstoque">
													<asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
													<asp:ListItem Value="1">Sim</asp:ListItem>
												</asp:DropDownList>
												<img src='imagens/help.gif' alt='O Vendedor poderá realizar venda de um produto que esta em falta no estoque' align="absBottom">
											</td>
										</tr>
										<tr>
											<td class='TextDefault'>Mostra itens no Resumo<br>
												<asp:DropDownlist Runat="server" id="cboMostraResumo">
													<asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
													<asp:ListItem Value="1">Sim</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='Será exibido ao vendedor a listagem de produtos no resumo do pedido' align="absBottom">
											</td>
											<td class='TextDefault'>Exibir informações de cliente<br>
												<asp:DropDownlist Runat="server" id="cboInformacaoCliente">
													<asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
													<asp:ListItem Value="1">Sim</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='O Vendedor poderá visualizar as últimas compras dos clientes' align="absBottom">
											</td>
										</tr>
										<tr>
											<td class='TextDefault'>Venda c/ Desconto Excessivo<br>
												<asp:DropDownlist Runat="server" id="cboDescontoExcessivo">
													<asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
													<asp:ListItem Value="1">Sim</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='O Vendedor poderá realizar uma venda com desconto acima do permitido' align="absBottom">
											</td>
											<td class='TextDefault'>Visualizar Cliente de outro vendedor<br>
												<asp:DropDownlist Runat="server" id="cboClienteOutroVendedoir">
													<asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
													<asp:ListItem Value="1">Sim</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='O Vendedor poderá visualizar e efetuar vendas para clientes de outro vendedor' align="absBottom">
											</td>
										</tr>
										<tr>
											<td class='TextDefault'>Alterar Preço do Produto<br>
												<asp:DropDownlist Runat="server" id="cboDigitaPreco">
													<asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
													<asp:ListItem Value="1">Sim</asp:ListItem>
													<asp:ListItem Value="2">Por Percentual</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='O Vendedor poderá digitar o preço do produto para a venda ou digitar um percentual do preço' align="absBottom">
											</td>
											<td class='TextDefault'>Digita Desconto Final<br>
												<asp:DropDownlist Runat="server" id="cboDigitaDesconto">
													<asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
													<asp:ListItem Value="1">Sim</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='O Vendedor poderá digitar o desconto final aplicado no pedido' align="absBottom">
											</td>
										</tr>
										<tr>
											<td class='TextDefault'>Filtrar Produtos por categoria<br>
												<asp:DropDownlist Runat="server" id="cboFiltrarCategoria">
													<asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
													<asp:ListItem Value="1">Sim</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='Filtrar os produtos pela categoria antes de abrir a tela de pesquisa' align="absBottom">
											</td>
											<td class='TextDefault'>Digitar data de entrega<br>
												<asp:DropDownlist Runat="server" id="cboDigitaDataEntrega">
													<asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
													<asp:ListItem Value="1">Sim</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='O vendedor irá digitar a data de entrega do pedido' align="absBottom">
											</td>
										</tr> 
										<tr>
											<td class='TextDefault'>Digitar Observação no Pedido<br>
												<asp:DropDownlist Runat="server" id="cboDigitaObservacao">
													<asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
													<asp:ListItem Value="1">Sim</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='O vendedor irá digitar uma observacao no pedido' align="absBottom">
											</td>
											<td class='TextDefault'>Visualizar resumo de pedidos<br>
												<asp:DropDownlist Runat="server" id="cboTotalPedidos">
													<asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
													<asp:ListItem Value="1">Sim</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='O Vendedor poderá visualizar o total de pedidos faturados' align="absBottom">
											</td>
										</tr>
										<tr>
											<td class='TextDefault'>Considerar limite de crédito<br>
												<asp:DropDownlist Runat="server" id="cboLimiteCredito">
													<asp:ListItem Value="0" Selected="True">Não</asp:ListItem>
													<asp:ListItem Value="1">Sim</asp:ListItem>
												</asp:DropDownlist>
												<img src='imagens/help.gif' alt='Permitir pedidos acima do limite de crédito do cliente' align="absBottom">
											</td>
											<td>&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table width="100%" class='fundo'>
										<tr>
											<td width="25%">
												<asp:Button Runat="server" ID='btnSalvar' Text='Salvar' CssClass="Botao"></asp:Button>
											</td>
											<td>&nbsp;</td>
											<td align="middle" width="25%">
												<input class="Botao" onclick='location.href="configuracoes.aspx";' type="button" value="Voltar" title='Voltar para a tela de configurações'>
											</td>
										</tr>
									</table>
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
