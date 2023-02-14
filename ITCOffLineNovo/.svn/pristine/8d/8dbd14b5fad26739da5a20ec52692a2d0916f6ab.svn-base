<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FormularioPedido.aspx.vb" Inherits="ITCOffLine.FormularioPedido"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
  <HEAD>
		<title>Formul&aacute;rio de Pedidos</title> 
		<!-- saved from url=(0022)http://internet.e-mail -->
		<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
		<style type="text/css" >
			TABLE.Frente {
				BORDER-BOTTOM: #ff9933 2px solid;
				BORDER-LEFT: #ff9933 2px solid;
				BACKGROUND-COLOR: white;
				BORDER-SPACING: 0px;
				BORDER-COLLAPSE: collapse;
				BORDER-TOP: #ff9933 2px solid;
				BORDER-RIGHT: #ff9933 2px solid
			}
			TABLE.Frente TH {
				BORDER-BOTTOM: #ff9933 1px solid;
				BORDER-LEFT: #ff9933 1px solid;
				PADDING-BOTTOM: 1px;
				BACKGROUND-COLOR: white;
				PADDING-LEFT: 1px;
				PADDING-RIGHT: 1px;
				BORDER-TOP: #ff9933 1px solid;
				BORDER-RIGHT: #ff9933 1px solid;
				PADDING-TOP: 1px;
				-moz-border-radius:
			}
			TABLE.Frente TD {
				BORDER-BOTTOM: #ff9933 1px solid;
				BORDER-LEFT: #ff9933 1px solid;
				PADDING-BOTTOM: 1px;
				PADDING-LEFT: 1px;
				PADDING-RIGHT: 1px;
				BORDER-TOP: #ff9933 1px solid;
				BORDER-RIGHT: #ff9933 1px solid;
				PADDING-TOP: 1px;
				-moz-border-radius: 
			}
			.Dadosuperior { FONT-FAMILY: Arial; COLOR: #333; FONT-SIZE: 10px }
			.dadossuperior { FONT-FAMILY: Arial; COLOR: #333; FONT-SIZE: 10px }
			.tituloformulario { FONT-FAMILY: Arial; COLOR: #333; FONT-SIZE: 12px }
			.tabela1 { FONT-FAMILY: Arial; FONT-SIZE: 12px }
			.tabela11 { FONT-FAMILY: Arial; FONT-SIZE: 12px; FONT-WEIGHT: bold }
			.tabela3 { FONT-FAMILY: Arial; COLOR: #333; FONT-SIZE: 12px }
			.tabela4 { FONT-FAMILY: Arial; COLOR: #333; FONT-SIZE: 12px }
			.autorização { FONT-FAMILY: Arial; FONT-SIZE: 10px; FONT-WEIGHT: bold }
			.tabela2 { FONT-FAMILY: Arial; FONT-SIZE: 12px }
			.vias { FONT-FAMILY: Arial; FONT-SIZE: 10px }
			.assinatura { FONT-FAMILY: Arial; FONT-SIZE: 10px; FONT-WEIGHT: bold }
			.dtg {font-size: 12px; FONT-FAMILY: Arial, Verdana, Tahoma; }
		</style>
		<!--css_verso-->
</HEAD>
	<body>
		<table border="0" cellSpacing="0" width="640">
			<tr>
				<td width="50%">
					<%= iif(ViewState("IdTipoPedido")=1, "<IMG alt='' src='Imagens/logoitcPed.png' width='200' longDesc='Imagens/logoitcPed.png' height='50'>", "<IMG alt='' src='Imagens/Guia_Negocios.png' width='150' longDesc='Imagens/Guia_Negocios.png' height='50'>")%>
				</td>
				<td width="50%">
					<div class="dadossuperior" align="left">Din&acirc;mica Editora de Publica&ccedil;&otilde;es Peri&oacute;dicas 
						EIRELI EPP<br>
						Rua Conselheiro Brotero,589 - SL 02 - Barra Funda - SP<br>
						CEP: 01154-001 - Fone/Fax (11) 3527-7500 - www.itc.etc.br<br>
						vendas@itc.etc.br - CNPJ: 06.946.365/0001-90 - IE:116.952.043.116</div>
				</td>
			</tr>
		</table>
		<table border="0" cellSpacing="0" width="640">
			<tr>
				<td>
					<p class="tituloformulario" align="center"><b>PEDIDO <%= iif(ViewState("IdTipoPedido")=1, "DE FORNECIMENTO DE INFORMA&Ccedil;&Otilde;ES", "GUIA DE NEG&Oacute;CIO")%></b><br>
						Dados Cadastrais</p>
				</td>
			</tr>
		</table>
		<table border="1" class="Frente" cellSpacing="0" width="640">
			<tr>
				<td width="80%" colSpan="4"><span class="tabela1">FANTASIA:&nbsp;<asp:label id="lblFantasia" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td colSpan="2"><span class="tabela1">C&oacute;digo:&nbsp;<asp:label id="lblCodigo" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td colSpan="6"><span class="tabela1">Raz&atilde;o Social:  
						<asp:label id="lblRazaoSocial" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td width="58%" colSpan="3"><span class="tabela1">CNPJ: 
						<asp:label id="lblCnpj" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td colSpan="3"><span class="tabela1">IE: 
						<asp:label id="lblIE" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td width="28%"><span class="tabela1">Ramo: 
						<asp:label id="lblRamo" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td colSpan="2"><span class="tabela1">Atividade: 
						<asp:label id="lblAtividade" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td colSpan="3"><span class="tabela1">Data do 1&ordm; Contrato: 
						<asp:label id="lblPrimeiroContrato" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td colSpan="3"><span class="tabela1">E-mail Principal: 
						<asp:label id="lblEmail" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td colSpan="3"><span class="tabela1">Site: 
						<asp:label id="lblSite" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td width="224" colSpan="2"><span class="tabela1">Telefone: 
						<asp:label id="lblTelefone" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td colSpan="4"><span class="tabela1">FAX: 
						<asp:label id="lblFax" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td width="78%" colSpan="5"><span class="tabela1">Contato: 
						<asp:label id="lblContato" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td width="226"><span class="tabela1">Fone: 
						<asp:label id="lblFone" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td colSpan="5"><span class="tabela1">E-mail: 
						<asp:label id="lblEmailContato" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td><span class="tabela1">Celular: 
						<asp:label id="lblCelular" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td colSpan="5"><span class="tabela1">ENDERE&Ccedil;O  DE ENTREGA: 
						<asp:label id="lblEnderecoEntrega" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td><span class="tabela1">CEP: 
						<asp:label id="lblCepEntrega" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td colSpan="2"><span class="tabela1">Bairro: 
						<asp:label id="lblBairroEntrega" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td colSpan="3"><span class="tabela1">Cidade: 
						<asp:label id="lblCidadeEntrega" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td><span class="tabela1">UF: 
						<asp:label id="lblUfEntrega" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td colSpan="3"><span class="tabela1">Telefone: 
						<asp:label id="lblTelefoneEntrega" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td colSpan="3"><span class="tabela1">Fax: 
						<asp:label id="lblFaxEntrega" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td colSpan="5"><span class="tabela1">ENDERE&Ccedil;O DE COBRAN&Ccedil;A: 
						<asp:label id="lblEnderecoCobranca" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td><span class="tabela1">CEP: 
						<asp:label id="lblCepCobranca" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td colSpan="2"><span class="tabela1">Bairro: 
						<asp:label id="lblBairroCobranca" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td colSpan="3"><span class="tabela1">Cidade: 
						<asp:label id="lblCidadeCobranca" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td><span class="tabela1">UF: 
						<asp:label id="lblUfCobranca" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td colSpan="3"><span class="tabela1">Telefone: 
						<asp:label id="lblTelefoneCobranca" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td colSpan="3"><span class="tabela1">Fax: 
						<asp:label id="lblFaxCobranca" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td colSpan="5"><span class="tabela1">ENDERE&Ccedil;O DE FATURAMENTO: 
						<asp:label id="lblEnderecoFaturamento" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td><span class="tabela1">CEP: 
						<asp:label id="lblCepFaturamento" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td colSpan="2"><span class="tabela1">Bairro: 
						<asp:label id="lblBairroFaturamento" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td colSpan="3"><span class="tabela1">Cidade: 
						<asp:label id="lblCidadeFaturamento" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td><span class="tabela1">UF: 
						<asp:label id="lblUfFaturamento" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
			<tr>
				<td colSpan="3"><span class="tabela1">Telefone: 
						<asp:label id="lblTelefoneFaturamento" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td colSpan="3"><span class="tabela1">Fax: 
						<asp:label id="lblFaxFaturamento" Class="tabela11" Runat="server"></asp:label>
					</span></td>
			</tr>
		</table>
		<div style="HEIGHT:7px"></div>
		<table border="1" cellSpacing="0" class="Frente" width="640" height="105">
			<tr class="tabela2" >
				<td colSpan="4" valign="top">
					<asp:datagrid id="dtgPlanos" CssClass="dtg" AllowPaging="False" AllowSorting="False" BorderColor="#999999"
						BorderStyle="None" GridLines="none" AutoGenerateColumns="False" BackColor="White" width="100%" CellPadding="3"
						runat="server">
						<HeaderStyle ForeColor="black" BackColor="#ff9933" Font-Bold="True"></HeaderStyle>
						<Columns>
							<asp:TemplateColumn HeaderText="Informa&ccedil;&otilde;es de Obras nos Segmentos:">
								<ItemTemplate>
									<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "IdPlano"))%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn DataField='Inicio' HeaderText="Inicio" />
							<asp:BoundColumn DataField='Termino' HeaderText="Termino" />
							<asp:BoundColumn DataField='Valor' HeaderText="Valor R$" DataFormatString="{0:n}" />
							<asp:BoundColumn DataField='CondPagamento' HeaderText="Cond. de Pagto" />
							<asp:BoundColumn DataField='Periodo' HeaderText="Periodo" />
						</Columns>
						
					</asp:datagrid>
				</td>
			</tr>
			<tr>
				<td><span class="tabela3"><strong>Total do Pedido(R$): </strong>
						<asp:label id="lblTotalPedido" Runat="server"></asp:label>
					</span></td>
				<td><span class="tabela3"><strong>1&ordm; Vencto: </strong>
						<asp:label id="lblVencimento" Runat="server"></asp:label>
					</span></td>
				<td><span class="tabela3"><strong>Posi&ccedil;&atilde;o: </strong>
						<asp:label id="lblPosicao" Runat="server"></asp:label>						
					</span></td>
			</tr>
		</table>
		<div style="HEIGHT:7px"></div>
		<table border="1" class="Frente" cellSpacing="0" width="640" height="153">
			<tr class="tabela2">
				<td colSpan="3" valign="top" height="115"><asp:datagrid id="dtgContatos" CssClass="dtg" AllowPaging="False" AllowSorting="False" BorderColor="#999999"
						BorderStyle="None" GridLines="none" AutoGenerateColumns="False" BackColor="White" width="100%" CellPadding="3"
						runat="server">
						<HeaderStyle CssClass="Frente" ForeColor="black" BackColor="#ff9933" Font-Bold="True"></HeaderStyle>
						<Columns>
							<asp:TemplateColumn HeaderText="Nome">
								<ItemTemplate>
									<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "NomeContato"))%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Cargo">
								<ItemTemplate>
									<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "DescricaoCargo"))%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:BoundColumn DataField='CTelefone' HeaderText="Telefone/Celular" />
							<asp:BoundColumn DataField='EMail' HeaderText="E-Mail"/>
                            <asp:BoundColumn DataField='Skype' HeaderText="Skype"/>
						</Columns>
					</asp:datagrid></td>
			</tr>
			<tr class="tabela4">
				<td height="28" vAlign="top" align="center" width="33%">
					<div align="center"><strong>Vendedor (a)</strong></div>
					<asp:label id="lblVendedor" Runat="server"></asp:label></td>
				<td vAlign="top" align="center" width="33%">
					<div align="center"><strong>Data</strong></div>
					<asp:label id="lblDataPedido" Runat="server"></asp:label></td>
				<td vAlign="top" align="center" width="34%">
					<div align="center"><strong>N&uacute;mero do pedido</strong></div>
					<asp:label id="lblNumeroPedido" Runat="server"></asp:label></td>
			</tr>
		</table>
		<div style="HEIGHT:7px"></div>
		<table border="1" cellSpacing="0" width="640" class="Frente">
			<tr bgcolor="#ff9933">
				<td colSpan="4"><span class="tabela2"><strong>OBSERVA&Ccedil;&Atilde;O</strong></span></td>
			</tr>
			<tr>
				<td height="35" colSpan="4"><span class="tabela3"><asp:label id="lblObservacao" Runat="server"></asp:label></span>
				</td>
			</tr>
		</table>
		<table border="1" cellSpacing="0" width="640" class="Frente">
			<tr bgcolor="#ff9933">
				<td colSpan="4"><span class="tabela2"><strong>PRODUTOS</strong></span></td>
			</tr>
			<tr>
				<td height="35" colSpan="4"><span class="tabela3"><asp:label id="lblProdutos" Runat="server"></asp:label>
					</span></td>
			</tr>
		</table>
		<table border="0" cellSpacing="0" width="640">
			<tr>
				<td vAlign="top" height="50">
					<div class="autorização" align="center">Autorizo a execu&ccedil;&atilde;o deste pedido conforme 
						pre&ccedil;o, forma de pagamento acima e condi&ccedil;&otilde;es descritas no verso</div>
				</td>
			</tr>
			<tr>
				<td vAlign="top" align="center">
					<br><span class="tabela2"><strong>________________________________________</strong></span>
					<div align="center">
						<span class="assinatura">Assinatura e carimbo da empresa </span></div><br>
				</td>
			</tr>
			<tr>
				<td>
					<div class="vias" align="center"><strong>1&ordm; Via ITC/2&ordm; Via Cliente </strong></div>
				</td>
			</tr>
		</table>
	</body>
</HTML>
