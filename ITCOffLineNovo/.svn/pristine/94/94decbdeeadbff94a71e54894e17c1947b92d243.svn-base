<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PedidosDet.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.PedidosDet" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>

<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<script language=javascript>			
			function fncConfirm(idStauts)
			{
				if (idStauts == 2)
				{
					if (confirm("Depois de aprovado o pedido não poderá ser modificado!")==true)
						return true;
					else
						return false;
				}
				else if (idStauts == 4)
				{
					if (confirm("Deseja cancelar o pedido?")==true)
						return true;
					else
						return false;
				}
			}
			function fncValida(dtg)
			{
				if (dtg == "dtgPlano")
				{			
					if((document.getElementById('<%=cboIdPlano.ClientId%>').value==101) && (document.getElementById('<%=txtPlanoEspecifico.ClientId%>').value=='')){
						alert('Digite o nome do Plano Específico!');
						return false;
					}
					else if(document.getElementById('<%=cboIdPlano.ClientId%>').selectedIndex==0){
						alert('Selecione o Plano!');
						return false;
					}
					else if(document.getElementById('<%=txtDataInicio.ClientId%>').value==''){
						alert('Digite a Data de Início do Plano!');
						return false;
					}
					else if(document.getElementById('<%=txtDataTermino.ClientId%>').value==''){
						alert('Digite a Data de Término do Plano!');
						return false;
					}
					else if(document.getElementById('<%=txtValor.ClientId%>').value==''){
						alert('Digite o Valor do Plano!');
						return false;
					}
					else if(document.getElementById('<%=txtCondPagamento.ClientId%>').value==''){
						alert('Digite as Condições de Pagamento do Plano!');
						return false;
					}
					else if(document.getElementById('<%=txtPeriodo.ClientId%>').value==''){
						alert('Digite o Periodo de Validade do Plano!');
						return false;
					}
				}
											
			}
			function openWindow(idpedido, idTipoPedido, fichaRosa)
			{
				//alert(idTipoPedido)
				if (fichaRosa == 1)
				{
					window.open('ficharosa.aspx?idpedido=' + idpedido + '&idtipopedido=' + idTipoPedido , 'Pagina', 'STATUS=NO, TOOLBAR=YES, LOCATION=NO, SCROLLBARS=YES, LEFT=200, WIDTH=680');					
				}
				else
				{
					window.open('formulariopedido.aspx?idpedido=' + idpedido + '&idtipopedido=' + idTipoPedido , 'Pagina', 'STATUS=NO, TOOLBAR=YES, LOCATION=NO, SCROLLBARS=YES, LEFT=200, WIDTH=680');
				}
			}
			
			function versoPedido()
			{
				window.open('VersoPedido.aspx' , 'Pagina', 'STATUS=NO, TOOLBAR=YES, LOCATION=NO, SCROLLBARS=YES, LEFT=200, WIDTH=720');
			}
			
			function EnviaEmail(idPed, Tipo)
			{
				window.open('EmailPedido.aspx?idped=' + idPed + '&tipo=' + Tipo , 'Pagina', 'width=400, height=200, scrollbars=no');
			}
			function MascaraMoeda(objTextBox, SeparadorMilesimo, SeparadorDecimal, e)
			{
				var sep = 0;
				var key = '';
				var i = j = 0;
				var len = len2 = 0;
				var strCheck = '0123456789';
				var aux = aux2 = '';
				var whichCode = (window.Event) ? e.which : e.keyCode;
				if (whichCode == 13) return true;
				key = String.fromCharCode(whichCode); // Valor para o código da Chave
				if (strCheck.indexOf(key) == -1) return false; // Chave inválida
				len = objTextBox.value.length;
				for(i = 0; i < len; i++)
					if ((objTextBox.value.charAt(i) != '0') && (objTextBox.value.charAt(i) != SeparadorDecimal)) break;
				aux = '';
				for(; i < len; i++)
					if (strCheck.indexOf(objTextBox.value.charAt(i))!=-1) aux += objTextBox.value.charAt(i);
				aux += key;
				len = aux.length;
				if (len == 0) objTextBox.value = '';
				if (len == 1) objTextBox.value = '0'+ SeparadorDecimal + '0' + aux;
				if (len == 2) objTextBox.value = '0'+ SeparadorDecimal + aux;
				if (len > 2) {
					aux2 = '';
					for (j = 0, i = len - 3; i >= 0; i--) {
						if (j == 3) {
							aux2 += SeparadorMilesimo;
							j = 0;
						}
						aux2 += aux.charAt(i);
						j++;
					}
					objTextBox.value = '';
					len2 = aux2.length;
					for (i = len2 - 1; i >= 0; i--)
					objTextBox.value += aux2.charAt(i);
					objTextBox.value += SeparadorDecimal + aux.substr(len - 2, len);
				}
				return false;
			}
			function MascaraTelefone (keypress, objeto)
			{
				campo = eval (objeto);

				separador1 = '(';
				separador2 = ')';
				separador3 = '-';
				conjunto1 = 0;
				conjunto2 = 3;
				conjunto3 = 8;
				
				if (campo.value.length == conjunto1){
					campo.value = campo.value + separador1;
				}
				if (campo.value.length == conjunto2){
					campo.value = campo.value + separador2;
				}
				if (campo.value.length == conjunto3){
					campo.value = campo.value + separador3;
				}
			}			
		</script>
			<table height="450" cellSpacing="0" cellPadding="0" width="100%" style="POSITION: absolute; TOP: 0px; LEFT: 0px">
				<tr>
					<td vAlign="top" align="center">
						<table cellSpacing="0" width="100%" bgColor="#809eb7">
							<tr>
								<td width="100%"><uc1:top id="Top1" runat="server"></uc1:top></td>
							</tr>
							<tr>
								<td width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="top" align="center">
						<form id="frmCad" action="PedidosDet.aspx" runat="server">
							<IMG height="40" src="imagens/TituloCadastroPedidos.jpg" width="443" border="0">
							<table id="tblPedido" bgColor="#003c6e" cellSpacing="0" cellPadding="0" width="90%" border="1" runat="server">
								<tr>
									<td>
										<table id="tblAssociadosDet" Class="f8" runat="server" BorderWidth="1" CellSpacing="2" CellPadding="1"
											width="100%" BgColor="#EFEFEF">
											<tr bgcolor="#003C6E" >
												<td style="color:'#FFFFFF';" Align="Center" ColSpan="4" ><b>CADASTRO PRINCIPAL</b></td>
											</tr>
											<tr>
												<td >Tipo do Pedido</td>
												<td>
													<uc1:ComboBox id="cboIdTipoPedido" CssClass="f8" runat="server"></uc1:ComboBox>
												</td>
											</tr>
											<tr>
												<td >Posição</td>
												<td>
													<uc1:ComboBox id="cboIdPosicao" runat="server"></uc1:ComboBox>
												</td>
												<td >Status do Pedido</td>
												<td>
													<uc1:ComboBox enabled="false" id="cboIdStatus" CssClass="f8" runat="server"></uc1:ComboBox>
												</td>
											</tr>
											<tr>
												<td>Fantasia*</td>
												<td Align="Left">
													<asp:TextBox CssClass="f8" runat="server" Width="80%" ID="txtFantasia" MaxLength="255" ReadOnly="True"></asp:TextBox>	
													<asp:RequiredFieldValidator ID="Requiredfieldvalidator2" Runat="server" ErrorMessage="Obrigatório!" ControlToValidate="txtFantasia"></asp:RequiredFieldValidator>
												</td>
												<td >C&oacute;digo</td>
												<td ColSpan="3">
													<asp:Label CssClass="f8" ID="lblCodigo" Runat="server" ></asp:Label>
												</td>
											</tr>
											<tr>
												<td >Razão Social*</td>
												<td ColSpan="4">
													<asp:TextBox CssClass="f8" Width="95%" runat="server" ID="txtRazaoSocial" ReadOnly="True"></asp:TextBox>
													<asp:RequiredFieldValidator ID="Requiredfieldvalidator3" Runat="server" ErrorMessage="Obrigatório!" ControlToValidate="txtRazaoSocial"></asp:RequiredFieldValidator>
												</td>
											</tr>
											<tr>
												<td >CNPJ*</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="200px" ID="txtCNPJ" onKeyDown="FormataCNPJ(this, event);" MaxLength="18" ReadOnly="True"></asp:TextBox>
													<asp:RequiredFieldValidator ID="Requiredfieldvalidator7" Runat="server" ErrorMessage="Obrigatório!" ControlToValidate="txtCNPJ"></asp:RequiredFieldValidator>
												</td>
												<td >IE*</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="200px" ID="txtInscricaoEstadual" MaxLength="50" ReadOnly="True"></asp:TextBox>
													<asp:RequiredFieldValidator ID="Requiredfieldvalidator5" Runat="server" ErrorMessage="Obrigatório!" ControlToValidate="txtInscricaoEstadual"></asp:RequiredFieldValidator>
												</td>
											</tr>
											<tr>
												<td >Ramo</td>
												<td>
													<uc1:ComboBox id="cboIdRamo" runat="server" ReadOnly="True"></uc1:ComboBox>
												</td>
												<td >Atividade</td>
												<td>
													<uc1:ComboBox id="cboIdAtividade" CssClass="f8" runat="server" ReadOnly="True"></uc1:ComboBox>
												</td>
											</tr>
											<tr>
												<td >Web Site</td>
												<td ColSpan="3">
													<asp:TextBox CssClass="f8" runat="server" Width="96%" ID="txtWebSite" MaxLength="150" ReadOnly="True"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td >E-Mail</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="300px" ID="txtEmail" MaxLength="150" ReadOnly="True"></asp:TextBox>
												</td>
												<td >Primeiro Contrato</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="200px" ID="txtContrato" MaxLength="10" onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);" ReadOnly="True"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td >Telefone</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtTelefone" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);"></asp:TextBox>
												</td>
												<td >Fax</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtFax" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td >Contato</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="200px" ID="txtContato" MaxLength="100"></asp:TextBox>
												</td>
												<td >Fone</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtFone" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td >E-mail</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="200px" ID="txtEmailContato" MaxLength="200"></asp:TextBox>
												</td>
												<td >Celular</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtCelular" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);"></asp:TextBox>
												</td>
											</tr>
											<tr BgColor="#003C6E">
												<td style="color:'#FFFFFF';" Align="Center" ColSpan="4" ><b>ENDEREÇO DE ENTREGA</b></td>
											</tr>
											<tr>
												<td >Endere&ccedil;o*</td>
												<td ColSpan="3">
													<asp:TextBox CssClass="f8" runat="server" Width="96%" ID="txtEndereco" MaxLength="255" ReadOnly="True"></asp:TextBox>
													<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator4" Runat="server" ErrorMessage="Obrigatório!" ControlToValidate="txtEndereco"></asp:RequiredFieldValidator>
												</td>
											</tr>
											<tr>
												<td >Bairro</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtComplemento" MaxLength="255" ReadOnly="True"></asp:TextBox>
												</td>
												<td >CEP</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="200px" ID="txtCEP" ReadOnly="True" onKeyDown="javascript:FormataCEP(this, event);" MaxLength="9"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td >UF</td>
												<td>
													<uc1:ComboBox autopostback="true" id="cboIdEstado" runat="server"></uc1:ComboBox>
												</td>
												<td >Cidade</td>
												<td>
													<uc1:ComboBox id="cboCidade" runat="server"></uc1:ComboBox>
												</td>
											</tr>
											<tr>
												<td >Telefone</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtTelEntrega" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);"></asp:TextBox>
												</td>
												<td >Fax</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtFaxEntrega" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);"></asp:TextBox>
												</td>
											</tr>
											<tr BgColor="#003C6E">
												<td style="color:'#FFFFFF';" Align="Center" ColSpan="4" ><b>ENDEREÇO DE COBRANÇA</b></td>
											</tr>
											<tr>
												<td>Endere&ccedil;o*</td>
												<td ColSpan="3">
													<asp:TextBox CssClass="f8" runat="server" Width="96%" ID="txtEnderecoCobranca" MaxLength="255" ReadOnly="True"></asp:TextBox>
													<asp:RequiredFieldValidator ID="Requiredfieldvalidator6" Runat="server" ErrorMessage="Obrigatório!" ControlToValidate="txtEnderecoCobranca"></asp:RequiredFieldValidator>
												</td>
											</tr>
											<tr>
												<td>Bairro</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtComplementoCobranca" MaxLength="255" ReadOnly="True"></asp:TextBox>
												</td>
												<td>CEP</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="200px" ReadOnly="True" onKeyDown="javascript:FormataCEP(this, event);" ID="txtCEPCobranca" MaxLength="9"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td>UF</td>
												<td>
													<uc1:ComboBox autopostback="true" id="cboIdEstadoCobranca" runat="server"></uc1:ComboBox>
												</td>
												<td>Cidade</td>
												<td>
													<uc1:ComboBox id="cboCidadeCobranca" runat="server"></uc1:ComboBox>
												</td>
											</tr>
											<tr>
												<td>Telefone</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtTelCobranca" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);"></asp:TextBox>
												</td>
												<td>Fax</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtFaxCobranca" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td></td>
												<td></td>
												<td></td>
											</tr>
											<tr bgcolor="#003C6E">
												<td style="color:'#FFFFFF';" Align="Center" ColSpan="4" ><b>ENDEREÇO DE FATURAMENTO</b></td>
											</tr>
											<tr>
												<td >Endere&ccedil;o*</td>
												<td ColSpan="3">
													<asp:TextBox CssClass="f8" runat="server" Width="96%" ID="txtEnderecoFaturamento" MaxLength="255" ReadOnly="True"></asp:TextBox>
													<asp:RequiredFieldValidator ID="Requiredfieldvalidator9" Runat="server" ErrorMessage="Obrigatório!" ControlToValidate="txtEnderecoFaturamento"></asp:RequiredFieldValidator>
												</td>
											</tr>
											<tr>
												<td >Bairro</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtComplementoFaturamento" MaxLength="255" ReadOnly="True"></asp:TextBox>
												</td>
												<td >CEP</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="200px" ReadOnly="True" onKeyDown="javascript:FormataCEP(this, event);" ID="txtCEPFaturamento" MaxLength="9"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td >UF</td>
												<td>
													<uc1:ComboBox autopostback="true" id="cboIdEstadoFaturamento" runat="server"></uc1:ComboBox>
												</td>
												<td >Cidade</td>
												<td>
													<uc1:ComboBox id="cboCidadeFaturamento" runat="server"></uc1:ComboBox>
												</td>
											</tr>
											<tr>
												<td >Telefone</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtTelFaturamento" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);"></asp:TextBox>
												</td>
												<td >Fax</td>
												<td>
													<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtFaxFaturamento" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);"></asp:TextBox>
												</td>
											</tr>
											<tr bgcolor="#003C6E">
												<td Align="Center" ColSpan="4" >
													<b><asp:LinkButton ID="lnkLog" forecolor="#FFFFFF" Runat="server" text="EXIBIR LOG DE ALTERAÇÕES DO PEDIDO"></asp:LinkButton></b>
												</td>
											</tr>
											<tr ID="trLog" Visible="False" runat="server" Style="Width='95%';">
												<td VAlign="Middle" Align="left" ColSpan="4">
													<div Style="overflow:'auto'; Width='800px'; Height='85px';">
														<asp:ListBox ID="lstLog" CssClass="f8" Runat="server" DataValueField="Log" Rows="5"></asp:ListBox>
													</div>											
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							<br>
							<table bgColor="#003c6e" cellSpacing="0" cellPadding="0" Class="f8" width="90%" border="1">
								<tr>
									<td colSpan="3">
										<table id="tblObservacao" Class="f8" runat="server" BorderWidth="0" CellSpacing="2" CellPadding="1"
											width="100%" BgColor="#EFEFEF">
											<tr bgcolor="#003C6E">
												<td style="color:'#FFFFFF';" Align="Left" ColSpan="4" ><b>OBSERVAÇÃO</b></td>
											</tr>
											<tr>
												<td vAlign="Middle" Align="left" ColSpan="4">
													<asp:TextBox CssClass="f8" ID="txtObservacao" Runat="server" TextMode="MultiLine" Rows="3" Width="100%"></asp:TextBox>
												</td>
											</tr>
											<tr bgcolor="#003C6E">
												<td style="color:'#FFFFFF';" Align="Left" ColSpan="4" ><b>PRODUTOS</b></td>
											</tr>
											<tr>
												<td vAlign="Middle" Align="left" ColSpan="4">
													<asp:TextBox CssClass="f8" ID="txtProdutos" Runat="server" TextMode="MultiLine" Rows="3" Width="100%"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td VAlign="Middle" Align="left">
													<asp:Label CssClass="f8" ID="Label3" Runat="server" Text="Vendedor(a): "></asp:Label>
													<b><asp:Label CssClass="f8" ID="lblVendedor" Runat="server" Text="Vendedor(a)"></asp:Label></b>
												</td>
												<td vAlign="Middle" Align="left">
													<asp:Label CssClass="f8" ID="lblData" Runat="server" Text="Data do Pedido: "></asp:Label>
													<b><asp:Label CssClass="f8" runat="server" ID="lblDataPedido"></asp:Label></b>
												</td>
												<td vAlign="Middle" Align="left">
													<asp:Label CssClass="f8" ID="lblNumPedido" Runat="server" Text="Número do Pedido: "></asp:Label>
													<b><asp:Label CssClass="f8" runat="server" ID="lblNumeroPedido"></asp:Label></b>
												</td>
												<td vAlign="Middle" Align="left">
													<asp:Label CssClass="f8" ID="Label6" Runat="server" Text="Primeiro Vencto:* "></asp:Label>
													<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtPrimeiroVencto" MaxLength="10" onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);"></asp:TextBox>
													<asp:RequiredFieldValidator ID="Requiredfieldvalidator1" Runat="server" ErrorMessage="Obrigatório!" ControlToValidate="txtPrimeiroVencto"></asp:RequiredFieldValidator>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							<br>
							<table id="tblContatos" bgColor="#003c6e" Class="f8" cellSpacing="0" cellPadding="0" width="90%" border="1" runat="server">
								<tr>
									<td colspan="3">
										<table cellSpacing="0" cellPadding="0" width="100%" bgColor="#003c6e" border="0">
											<tr>
												<td align="center" width="100%">
													<b><font class="f8" color="#ffffff">Contatos</font></b>
												</td>
											</tr>
										</table>
										<asp:datagrid id="dtgContatos" runat="server" CellPadding="3" width="100%" BackColor="White" AutoGenerateColumns="False"
											GridLines="none" BorderStyle="None" BorderColor="#999999" AllowSorting="False" AllowPaging="False" CssClass="f8">
											<HeaderStyle ForeColor="#ffffff" BackColor="#003C6E"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn>
													<ItemTemplate>
														<asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdContato")%>' CommandName="deleteItem" runat="server" ID="btnDeleteContato" Text="<img src='imagens/Excluir.gif' alt='' border='0'>" >
														</asp:LinkButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField='NomeContato' HeaderText="Nome" />
												<asp:BoundColumn DataField='DescricaoCargo' HeaderText="Cargo" />
												<asp:BoundColumn DataField='CTelefone' HeaderText="Telefone/Celular" />
												<asp:BoundColumn DataField='EMail' HeaderText="E-Mail" />
                                                <asp:BoundColumn DataField='Skype' HeaderText="Skype" />
											</Columns>
										</asp:datagrid>
									</td>
								</tr>
								<tr id="trAddContato" runat="server" bgcolor="#EFEFEF">
									<td>
										<b><asp:Label ID="lblContato" Text=" Novo Contato" CssClass="f8" Runat="server"></asp:Label></b>
										<asp:DropDownList id="cboIdContato" runat="server"></asp:DropDownList>
										<asp:Button ID="btnAddContato" CssClass="f8" Text="Adicionar Contato" Runat="server" />
									</td>
								</tr>
							</table>
							<br>
							<table id="tblPlanos" borderColor="#003c6e" cellSpacing="0" Class="f8" cellPadding="0" width="90%" border="1" runat="server">										
								<tr>
									<td>
										<table id="tblServico" runat="server" Border="0" CellSpacing="2" CellPadding="1" width="100%" BgColor="#EFEFEF" Class="f8">												
											<tr>
												<td style="color:#ffffff;" BgColor="#003C6E" Align="Center" ColSpan="6"><b>Planos</b></td>
											</tr>
											<tr>
												<td colspan="6">
													<asp:DropDownList AutoPostBack=True id="cboIdPlano" runat="server" Width="28%"></asp:DropDownList>&nbsp;&nbsp;
													<asp:Label CssClass="f8" ID="lblPlanoEspecifico" Enabled="False" runat="server" text="Digite o plano"></asp:Label>&nbsp;
													<asp:TextBox CssClass="f8" Enabled="False" runat="server" Width="50%" ID="txtPlanoEspecifico" MaxLength="1000" ></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td width="13%">Inicio
													<asp:TextBox CssClass="f8" runat="server" Width="80px" ID="txtDataInicio" MaxLength="10" onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);"></asp:TextBox>
												</td>
												<td width="13%">Término
													<asp:TextBox CssClass="f8" runat="server" Width="80px" ID="txtDataTermino" MaxLength="10" onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);"></asp:TextBox>
												</td>
												<td width="13%">Valor R$
													<asp:TextBox CssClass="f8" runat="server" Width="70px" ID="txtValor" MaxLength="10" onKeyPress="return(MascaraMoeda(this,'.',',',event))" ></asp:TextBox>															
												</td>
												<td width="22%">Cond. de Pagamento
													<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtCondPagamento" MaxLength="100" ></asp:TextBox>															
												</td>	
												<td width="16%">Periodo
													<asp:TextBox CssClass="f8" runat="server" Width="80px" ID="txtPeriodo" MaxLength="50"></asp:TextBox>
												</td>
												<td width="16%">
													<asp:Button ID="btnAddItem" CssClass="f8" Text="Gravar Plano" Runat="server" />
												</td>
											</tr>
											<tr>
												<td ColSpan="6">
													<asp:DataGrid id="dtgPlanos" CssClass="f8" runat="server" AllowPaging="False" AllowSorting="False" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
														<HeaderStyle ForeColor="#ffffff" BackColor="#003C6E"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdPedidoItem")%>' CommandName="deleteItem" runat="server" ID="btnDeleteItem" Text="<img src='Imagens/excluir.gif' alt='' border='0'>" >
																	</asp:LinkButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField='IdPlano' HeaderText="Plano" />
															<asp:BoundColumn DataField='Inicio' HeaderText="Inicio" />
															<asp:BoundColumn DataField='Termino' HeaderText="Término" />
															<asp:BoundColumn DataField='Valor' HeaderText="Valor R$" DataFormatString="{0:n}" ItemStyle-HorizontalAlign="left" />
															<asp:BoundColumn DataField='CondPagamento' HeaderText="Cond. de Pagto" />
															<asp:BoundColumn DataField='Periodo' HeaderText="Periodo" />
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdPedidoItem")%>' CommandName="editItem" runat="server" ID="btnEditItem" Text="<img src='Imagens/editar.png' alt='' border='0'>" >
																	</asp:LinkButton>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:DataGrid>
												</td>
											</tr>
											<tr>
												<td colspan="2"><b>Total do Pedido R$</b>
													<asp:TextBox CssClass="f8" ReadOnly="True" runat="server" Width="100px" ID="txtPedidoRS" MaxLength="10" ></asp:TextBox>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							
							<table id="tblAssociado" runat="server" Class="f8" cellspacing=0 cellpadding=0 width=90% >
								<tr>
									<td>
										<table cellspacing=0 cellpadding=0 width=100% border=1 bordercolor=#003C6E>
											<tr>
												<td>
													<table cellspacing=0 cellpadding=0 width="100%" border="0" bgcolor="#003C6E">
														<tr>
															<td width="20%" colspan="5" align="middle">
																<asp:Label CssClass="f8" Runat=server ForeColor=#FFFFFF ID="Label4"><strong>PESQUISA DE ASSOCIADO</strong></asp:Label>
															</td>
														</tr>
													</table>
													<table width="100%" border="0" bgcolor=#FFFFFF>
														<tr>
															<td nowrap width=50%>
																<asp:Label CssClass="f8" Runat=server ID="Label1">Razão Social ou Fantasia</asp:Label><br>
																<asp:TextBox CssClass="f8" ID="txtRazaoFantasia" Runat="server" MaxLength="100" Width="100%"></asp:TextBox>
															</td>
															<td nowrap width=50%>
																<asp:Label CssClass="f8" Runat=server ID="Label2">Código</asp:Label><br>
																<asp:TextBox CssClass="f8" ID="txtCodigoAss" Style="width:100%" Runat="server" MaxLength="20"></asp:TextBox>
															</td>
															<td valign=middle align=center rowspan=2><asp:Button runat="server" ID="btnProcurar" Text="OK" CssClass="Botao" CausesValidation="false" /></asp:ImageButton></td>
														</tr>
														<tr>															
															<td >
																<asp:Label CssClass="f8" Runat="server" id="Label5">Mostrar:&nbsp;</asp:Label><br>
																<uc1:ComboBox Style="width:100%"  EnableValidation="false" id="cboRegistros" runat="server"></uc1:ComboBox>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
										<br>
										<table cellspacing=0 cellpadding=0 width=100% Class="f8" border=1 bgcolor=#003C6E>
											<tr>
												<td>
													<asp:DataGrid CssClass="f8" id="dtgAssociados" runat="server" AllowPaging="True" OnPageIndexChanged="doPaging" AllowSorting="True" PageSize="10" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
														<HeaderStyle BackColor=#003C6E ForeColor=#FFFFFF></HeaderStyle>
														<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
														<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
														<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
														<Columns>
															<asp:TemplateColumn ItemStyle-Width=25>
															</asp:TemplateColumn>
															<asp:TemplateColumn ItemStyle-VerticalAlign=Middle HeaderText="CÓDIGO ITC" ItemStyle-Wrap=False HeaderStyle-Font-Bold=True>
																<ItemTemplate>
																	<asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Codigo")%>' CommandName="carregaDados" runat="server" ID="lnkCarregaDados" Text='<%# DataBinder.Eval(Container.DataItem, "Codigo")%>' ></asp:LinkButton>																	
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="RazaoSocial" HeaderText="EMPRESA" HeaderStyle-Font-Bold=True></asp:BoundColumn>
															<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="CNPJ" HeaderText="CNPJ" HeaderStyle-Font-Bold=True></asp:BoundColumn>
																<asp:TemplateColumn ItemStyle-VerticalAlign=Middle HeaderText="" >
																	<ItemTemplate>
																		<%# iif(DataBinder.Eval(Container.DataItem, "ApagarRegistro")=1, "<IMG SRC='IMAGENS/CLOCK3.GIF' BORDER='0' ALT='AGUARDANDO ATUALIZAÇÃO'>", IIf(DataBinder.Eval(Container.DataItem, "AtualizarSite")=1, "<IMG SRC='IMAGENS/CLOCK3.GIF' BORDER='0' ALT='AGUARDANDO ATUALIZAÇÃO'>", "&nbsp;"))%>
																	</ItemTemplate>
																</asp:TemplateColumn>
														</Columns>
													</asp:DataGrid>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
				
							<br>
							<table bgColor="#003c6e" cellSpacing="0" cellPadding="0" width="90%" border="1">
								<tr>
									<td>
										<table id="tblBotoes" runat="server" BorderWidth="0" CellSpacing="2" CellPadding="1" width="100%" BgColor="#EFEFEF">
											<tr>
												<td Align="Center">
													<uc1:BarraBotoes id="Barra" runat="server"></uc1:BarraBotoes>
													<table width="100%">
														<tr>
															<td width="25%" align="center">
																<a href='#' onclick="openWindow('<%=CryptographyEncoded(ViewState("IdPedido"))%>', '<%=cboIdTipoPedido.value%>', '0')"><img src='imagens/btn_imprimir.png'  runat='server' id='btnImprimir' border=0 ></a>
															</td>
															<td width="25%" align="center">
																<a href='#' onclick="versoPedido()"><img src='imagens/btn_imprimir_v.png'  runat='server' id="btnImprimirVerso" border=0 ></a>
															</td>
															<td width="25%" align="center">
																<a href='#' onclick="openWindow('<%=CryptographyEncoded(ViewState("IdPedido"))%>', '<%=cboIdTipoPedido.value%>', '1')"><img src='imagens/btn_f_rosa.png'  runat='server' id="btnFichaRosa" border=0 ></a>
															</td>
															<td width="25%" align="center">
																<a href='#' onclick="EnviaEmail('<%=CryptographyEncoded(ViewState("IdPedido"))%>', '<%=cboIdTipoPedido.value%>')"><img src='imagens/btn_enviar_email.png'  runat='server' id="btnEnviarEmail" border=0 ></a>
															</td>
														</tr>
														<tr>
															<td align="center">
																<asp:ImageButton AlternateText="Confirma a aprovação do Pedido" ImageUrl='imagens/btn_confirmar.png' runat='server' id="btnConfirmar"></asp:ImageButton>																		
															</td>
															<td align="center">
																<asp:ImageButton AlternateText="Cancela o Pedido" ImageUrl='imagens/btn_cancelar.png' runat='server' id="btnCancelar"></asp:ImageButton>
															</td>															
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</form>
					</td>
				</tr>
			</table>
			<uc1:rodape id="Rodape1" runat="server"></uc1:rodape>
	</body>
</HTML>
