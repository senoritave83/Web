<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FichaRosa.aspx.vb" Inherits="ITCOffLine.FichaRosa"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>Ficha Rosa</title> 
		<!-- saved from url=(0022)http://internet.e-mail -->
		<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
		<style type="text/css" >
			table.sample {
				border-width: 2px;
				border-spacing: 0px;
				border-style: solid;
				border-color: #ff9933;
				border-collapse: collapse;
				background-color: white;
			}
			table.sample th {
				border-width: 1px;
				padding: 1px;
				border-style: solid;
				border-color: #ff9933;
				background-color: white;
				-moz-border-radius: ;
			}
			table.sample td {
				border-width: 1px;
				padding: 1px;
				border-style: solid;
				border-color: #ff9933;
				-moz-border-radius: ;
			}	
			.Dadosuperior { FONT-FAMILY: Arial; COLOR: #333; FONT-SIZE: 10px }
			.dadossuperior { FONT-FAMILY: Arial; COLOR: #333; FONT-SIZE: 10px }
			.tituloformulario { FONT-FAMILY: Arial; COLOR: #333; FONT-SIZE: 12px }
			.tabela1 { FONT-FAMILY: Arial; FONT-SIZE: 10px}
			.tabela11 { FONT-FAMILY: Arial; FONT-SIZE: 10px; FONT-WEIGHT: bold}
			.tabela3 { FONT-FAMILY: Arial; COLOR: #333; FONT-SIZE: 10px }
			.tabela4 { FONT-FAMILY: Arial; COLOR: #333; FONT-SIZE: 10px }
			.autorização { FONT-FAMILY: Arial; FONT-SIZE: 12px; FONT-WEIGHT: bold }
			.tabela2 { FONT-FAMILY: Arial; FONT-SIZE: 10px }
			.vias { FONT-FAMILY: Arial; FONT-SIZE: 12px }
			.assinatura { FONT-FAMILY: Arial; FONT-SIZE: 12px; FONT-WEIGHT: bold }
	</style>
	</HEAD>
	<body>
		<table border="0" cellSpacing="0" width="640">
			<tr>
				<td width="50%">
					<%= iif(ViewState("IdTipoPedido")=2, "<IMG alt='' src='Imagens/Guia_Negocios.png' width='100' longDesc='Imagens/Guia_Negocios.png' height='30'>" ,"<IMG alt='' src='Imagens/logoitcPed.png' width='100' longDesc='Imagens/logoitcPed.png' height='30'>")%>
				</td>
			</tr>
		</table>
		<table border="1" class="sample" cellSpacing="0" width="640">
			<tr>
				<td width="65%" colSpan="4"><span class="tabela1">FANTASIA:&nbsp;<asp:label id="lblFantasia" Class="tabela11" Runat="server"></asp:label>
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
				<td width="30%"><span class="tabela1">CNPJ: 
						<asp:label id="lblCnpj" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td colSpan="2"><span class="tabela1">IE: 
						<asp:label id="lblIE" Class="tabela11" Runat="server"></asp:label>
					</span></td>
				<td colSpan="3">
					<span class="tabela1">Vendedor(a):&nbsp;<asp:label id="lblVendedor" Class="tabela11" Runat="server"></asp:label></span></td>
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
				<td colSpan="5"><span class="tabela1">ENDERE&Ccedil;O DE ENTREGA: 
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
				<td colSpan="6" height="30" valign="top">
					<span class="tabela1">OBSERVA&Ccedil;&Atilde;O:&nbsp;</span>
					<asp:label id="lblObservacao" Class="tabela11" Runat="server"></asp:label>
				</td>				
			</tr>
			<tr>
				<td colSpan="6" height="30" valign="top">
					<span class="tabela1">PRODUTOS:&nbsp;</span>
					<asp:label id="lblProdutos" Class="tabela11" Runat="server"></asp:label>
				</td>
			</tr>
		</table>
		<div style="height:5px;"></div>	
		<table border="1" cellSpacing="0" class="sample" width="640" height="85">
			<tr class="tabela2" >
				<td colSpan="3" valign="top">
					<asp:datagrid id="dtgPlanos" CssClass="f8" AllowPaging="False" AllowSorting="False" BorderColor="#999999" BorderStyle="None" GridLines="none" AutoGenerateColumns="False" BackColor="White" width="100%" CellPadding="3" runat="server">
						<HeaderStyle ForeColor="black" BackColor="#ff9933" Font-Bold="True"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField='IdPlano' HeaderText="Informa&ccedil;&otilde;es de Obras nos Segmentos:"/>
							<asp:BoundColumn DataField='Inicio' HeaderText="Inicio" />
							<asp:BoundColumn DataField='Termino' HeaderText="T&eacute;rmino" ItemStyle-Font-Bold="True" />
							<asp:BoundColumn DataField='Valor' HeaderText="Valor R$" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="Right"/>
							<asp:BoundColumn DataField='CondPagamento' HeaderText="Cond. de Pagto" />
							<asp:BoundColumn DataField='Periodo' HeaderText="Periodo" />
						</Columns>						
					</asp:datagrid>
				</td>
			</tr>
			<tr>
				<td><span class="tabela3"><strong>Valor do Pedido(R$): </strong>
						<asp:label id="lblTotalPedido" Runat="server"></asp:label>
					</span></td>
				<td><span class="tabela3"><strong>Posi&ccedil;&atilde;o: </strong>
						<b><asp:label id="lblPosicao" Runat="server"></asp:label></b>					
					</span></td>
			</tr>
		</table>
		<div style="height:5px;"></div>	
		<table border="1" class="sample" cellSpacing="0" width="640" height="90">
			<tr class="tabela2">
				<td colSpan="3" valign="top"><asp:datagrid id="dtgContatos" CssClass="f8" AllowPaging="False" AllowSorting="False" BorderColor="#999999"
						BorderStyle="None" GridLines="none" AutoGenerateColumns="False" BackColor="White" width="100%" CellPadding="3"
						runat="server">
						<HeaderStyle CssClass="sample" ForeColor="black" BackColor="#ff9933" Font-Bold="True"></HeaderStyle>
						<Columns>
							<asp:BoundColumn DataField='NomeContato' HeaderText="Nome" />
							<asp:BoundColumn DataField='DescricaoCargo' HeaderText="Cargo" />
							<asp:BoundColumn DataField='CTelefone' HeaderText="Telefone/Celular" />
							<asp:BoundColumn DataField='EMail' HeaderText="E-Mail"/>
                            <asp:BoundColumn DataField='Skype' HeaderText="Skype"/>
						</Columns>
					</asp:datagrid></td>
			</tr>
		</table>
		<div style="height:5px;"></div>	
		<table border="1" cellSpacing="0" width="640" class="sample">
			<tr bgcolor="#ff9933">
				<td align="center" width="80">
					<span class="tabela2"><strong>DATA</strong></span>
				</td>
				<td align="center"  width="320">
					<span class="tabela2"><strong>HIST&Oacute;RICO</strong></span>
				</td>
				<td align="center" width="60">
					<span class="tabela2"><strong>OP&Ccedil;&Otilde;ES</strong></span>
				</td>
				<td align="center"  width="100">
					<span class="tabela2"><strong>VISTO</strong></span>
				</td>
				<td align="center"  width="80">
					<span class="tabela2"><strong>DATA</strong></span>
				</td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>ITC OFF</strong></span>
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>Internet</strong></span>
				</td>
				<td>
					<span class="tabela2"><strong>(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;) (&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)</strong></span>
				</td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>ITC News</strong></span>
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>SIG</strong></span>
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>FINANCEIRO</strong></span>
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>PESQ</strong></span>
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>RELAC.</strong></span>
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>GUIA</strong></span>
				</td>
				<td></td>
				<td></td>
			</tr>
			<!--CANCELADOS-->
			<tr bgcolor="#ff9933">
				<td colSpan="5" align="center">
					<span class="tabela2"><strong>CANCELADOS</strong></span>
				</td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>ITC OFF</strong></span>
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>Internet</strong></span>
				</td>
				<td>
					<span class="tabela2"><strong>(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;) (&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)</strong></span>
				</td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>ITC News</strong></span>
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>SIG</strong></span>
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>FINANCEIRO</strong></span>
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>PESQ</strong></span>
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>RELAC.</strong></span>
				</td>
				<td></td>
				<td></td>
			</tr>
			<tr>
				<td></td>
				<td></td>
				<td>
					<span class="tabela2"><strong>GUIA</strong></span>
				</td>
				<td></td>
				<td></td>
			</tr>
		</table>
	</body>
</HTML>
