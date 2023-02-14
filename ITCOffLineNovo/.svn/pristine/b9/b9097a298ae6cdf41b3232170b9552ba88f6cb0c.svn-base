<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PropostaAdicOrc.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.PropostaAdicOrc"%>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>

<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<script language=javascript>
					
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
					else if(document.getElementById('<%=txtValor.ClientId%>').value==''){
						alert('Digite o Valor do Plano!');
						return false;
					}
					else if(document.getElementById('<%=txtCondPagamento.ClientId%>').value==''){
						alert('Digite as Condições de Pagamento do Plano!');
						return false;
					}
					else if(document.getElementById('<%=txtPrazo.ClientId%>').value==''){
						alert('Digite o Periodo do Plano!');
						return false;
					}
					else if(document.getElementById('<%=txtValorRenovacao.ClientId%>').value==''){
						alert('Digite o Valor da renovação para o Plano!');
						return false;
					}
					else if(document.getElementById('<%=txtExpiraOrcamento.ClientId%>').value==''){
						alert('Digite a Data de Expiração do Orçamento!');
						return false;
					}
				}
											
			}
			/*
			function fncConfirm(Img)
			{				
				if (Img == 1)
				{ 
					if(document.getElementById('<%=txtExpiraOrcamento.ClientId%>').value=='')
					{
						alert('Informe corretamente a Data de Expiração!');
						return false;
					}
				}
				if(confirm('Tem certeza que deseja gravar estes dados ?')==false) 
				{
					return false;
				}
			}
			*/
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
			
			function fncConfirmExc()
			{
				if (confirm("Tem certeza que deseja Apagar este Orçamento?")==true)
					return true;
				else
					return false;
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
					<form id="frmCad" action="PropostaAdicOrc.aspx" runat="server">
						<IMG height="40" src="imagens/TituloInclusaoOrcamento.jpg" width="443" border="0">
						<table id="tblProposta"  borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="90%" border="1" runat="server" visible="false">						
							<tr>
								<td>
									<table id="tblAssociadosDet" borderColor="#003c6e" border="0" runat="server" CellSpacing="2" CellPadding="1" width="100%" bgColor="#EFEFEF">
										<tr bgcolor="#003C6E">
											<td color="#FFFFFF" Align="Center" Class="f8" Colspan="10"><font color=White /><b>CADASTRO PRINCIPAL</td>
										</tr>
										<tr>
											<td Class="f8">Tipo da Proposta</td>
											<td colspan="2">
												<asp:dropdownlist CssClass="f8" enabled="false" id="cboIdTipoProposta" runat="server"></asp:dropdownlist>
											</td>
											<td Class="f8">Posição</td>
												<td colspan="2">
													<asp:dropdownlist CssClass="f8" id="cboIdPosicao" runat="server"></asp:dropdownlist>
												</td>
											</tr>
										<tr>
											<td Class="f8">Status da Proposta&nbsp;</td>
											<td colspan="2">
												<asp:dropdownlist CssClass="f8" enabled="false" id="cboIdStatus" runat="server"></asp:dropdownlist>
											</td>																									
											<td Class="f8">Número da Proposta&nbsp;</td>
											<td colspan="2">
												<asp:Label ID="lblIdProposta" Runat="server" CssClass="f8"></asp:Label>
											</td>
										</tr>
										<tr>
											<td Class="f8">Vendedor&nbsp;</td>
											<td colspan="2">
												<asp:dropdownlist ID="cboIdVendedor" Runat="server" width="80%"></asp:dropdownlist>
											</td>
											<td Class="f8">Data da Proposta&nbsp;</td>
											<td colspan="2">
												<asp:TextBox ID="txtData_Proposta" Runat="server" CssClass="f8"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td Class="f8">Nome da Empresa&nbsp;</td>
											<td colspan="2">
												<asp:Label ID="lblRazaoSocial" Runat="server" CssClass="f8"></asp:Label>
											</td>
											<td Class="f8">C&oacute;digo da Empresa&nbsp;</td>
											<td colspan="2">
												<asp:Label ID="lblIdAssociado" Runat="server" CssClass="f8"></asp:Label>
											</td>
										</tr>
										<tr>
											<td Class="f8">Endereço&nbsp;</td>
											<td colspan="2">
												<asp:TextBox ID="txtEndereco" Runat="server" CssClass="f8" width="80%"></asp:TextBox>
											</td>
											<td Class="f8">Complemento&nbsp;</td>
											<td colspan="2">
												<asp:TextBox ID="txtComplemento" Runat="server" CssClass="f8" width="80%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td Class="f8">Cidade&nbsp;</td>
											<td colspan="2">
												<asp:TextBox ID="txtCidade" Runat="server" CssClass="f8"></asp:TextBox>
											</td>
											<td Class="f8">Estado&nbsp;</td>
											<td colspan="2">
												<asp:dropdownlist ID="cboIdEstado" Runat="server" ></asp:dropdownlist>
											</td>
										</tr>
										<tr>
											<td Class="f8">CEP&nbsp;</td>
											<td colspan="2">
												<asp:TextBox ID="txtCep" Runat="server" CssClass="f8"></asp:TextBox>
											</td>
											<td Class="f8">CNPJ&nbsp;</td>
											<td colspan="2">
												<asp:Label ID="lblCnpj" Runat="server" CssClass="f8"></asp:Label>
											</td>
										</tr>
										<tr>
											<td Class="f8">Fone&nbsp;</td>
											<td colspan="2">
												<asp:TextBox ID="txtTelefone" Runat="server" MaxLength="9" CssClass="f8"></asp:TextBox>
											</td>
											<td Class="f8">Fax&nbsp;</td>
											<td colspan="2">
												<asp:TextBox ID="txtFax" Runat="server" MaxLength="9" CssClass="f8"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td Class="f8">WebSite&nbsp;</td>
											<td colspan="2">
												<asp:TextBox ID="txtWebSite" Runat="server" CssClass="f8" width="80%"></asp:TextBox>
											</td>
											<td Class="f8">E-mail Principal&nbsp;</td>
											<td colspan="2">
												<asp:TextBox ID="txtEmailPrincipal" Runat="server" CssClass="f8"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td Class="f8">Contato&nbsp;</td>
											<td colspan="2">
												<asp:TextBox ID="txtContatoCad" Runat="server" CssClass="f8"></asp:TextBox>
											</td>
											<td Class="f8">E-mail Contato&nbsp;</td>
											<td colspan="2">
												<asp:TextBox ID="txtEmailContato" Runat="server" MaxLength="50" CssClass="f8"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td Class="f8">Fone Contato&nbsp;</td>
											<td colspan="2">
												<asp:TextBox ID="txtTelefoneContato" Runat="server" MaxLength="9" CssClass="f8"></asp:TextBox>
											</td>
											<td Class="f8">Celular Contato&nbsp;</td>
											<td>
												<asp:TextBox ID="txtCelContato" Runat="server" MaxLength="9" CssClass="f8"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td Class="f8">Fax Contato&nbsp;</td>
											<td colspan="2">
												<asp:TextBox ID="txtFaxContato" Runat="server" MaxLength="9" CssClass="f8"></asp:TextBox>
											</td>
										</tr>
										<tr BackColor="#003C6E">
											<td forecolor="#FFFFFF" HorizontalAlign="Center" CssClass="f8" Text="Contatos" Colspan="4" />
										</tr>
										<tr>
											<td Class="f8">Proposta Válida Até:</td>
											<td colspan="2">
												<asp:TextBox CssClass="f8" ID="txtValidadeProposta" Runat="server" Width="80px" MaxLength="10" onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);"></asp:TextBox>
											</td>
											<td id="tdImgRenovacao" runat="server" visible="false" Class="f8">Proposta Renovada&nbsp;
												<asp:Image Runat=server ID='imgRenovacao' ImageUrl='Imagens/Check1.png' Width="25px" Height="25px" BorderStyle=None></asp:Image>													
											</td>										
										</tr>
									</table>
								</td>
							</tr>
						</table>					
						<br>
						<table id="tblOrcamento" borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="90%" border="1" runat="server">
							<tr>
								<td>
									<table id="tblPlanos" runat="server" CellSpacing="2" CellPadding="1" width="100%" border="0" bgcolor="#EFEFEF">
										<tr bgcolor="#003C6E">
											<td class="f8" color="#FFFFFF" Colspan="6">
												<font color=White><b>ORÇAMENTO N.</b></font>
												<b><asp:Label ID="lblIdOrcamento" Runat="server" ForeColor="white"></asp:Label></b>
											</td>
										</tr>
										<tr>
											<td colspan="4">
												<asp:DropDownList AutoPostBack=True id="cboIdPlano" runat="server" Width="28%"></asp:DropDownList>&nbsp;&nbsp;
												<asp:Label ID="lblPlanoEspecifico" CssClass="f8" Enabled="False" runat="server" text="Digite o plano"></asp:Label>&nbsp;
												<asp:TextBox CssClass="f8" Enabled="False" runat="server" Width="50%" ID="txtPlanoEspecifico" MaxLength="1000" ></asp:TextBox>
											</td>
											<td Class="f8" id="tdExpiraOrcamento" visible="false" runat="server" Wrap="False">Expira em:
												<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtExpiraOrcamento" MaxLength="10" onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td visible="False" runat="server" Class="f8" Wrap="False">Inicio
												<asp:TextBox CssClass="f8" runat="server" Width="80px" ID="txtDataInicio" MaxLength="10" onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);"></asp:TextBox>
											</td>
											<td visible="False" runat="server" Class="f8" Wrap="False">Término
												<asp:TextBox CssClass="f8" runat="server" Width="80px" ID="txtDataTermino" MaxLength="10" onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);"></asp:TextBox>
											</td>
											<td Class="f8" Wrap="False" width="20%">Valor R$
												<asp:TextBox CssClass="f8" runat="server" Width="70px" ID="txtValor" MaxLength="10" onKeyPress="return(MascaraMoeda(this,'.',',',event))" ></asp:TextBox>															
											</td>										
											<td Class="f8" id="tdRenovacao" runat="server" visible="false" Wrap="False" width="20%">Valor Renovação R$
												<asp:TextBox CssClass="f8" runat="server" Width="70px" ID="txtValorRenovacao" MaxLength="10" onKeyPress="return(MascaraMoeda(this,'.',',',event))" ></asp:TextBox>															
											</td>
											<td Class="f8" Wrap="False" width="20%">Cond. de Pagamento
												<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtCondPagamento" MaxLength="100" ></asp:TextBox>															
											</td>	
											<td Class="f8" Wrap="False" width="20%">Periodo
												<asp:TextBox CssClass="f8" runat="server" Width="80px" ID="txtPrazo" MaxLength="50"></asp:TextBox>
											</td>
											<td width="20%">
												<asp:Button CssClass="f8" ID="btnAddItem" Text="Gravar Plano" Runat="server" />
											</td>
										</tr>
										<tr >
											<td CssClass="f8" Text="" Wrap="False" Colspan="6">
												<asp:DataGrid id="dtgPlanos" CssClass="f8" runat="server" AllowPaging="False" AllowSorting="False" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
													<HeaderStyle ForeColor="#ffffff" BackColor="#003C6E"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdPropostaItem")%>' CommandName="deleteItem" runat="server" ID="btnDeleteItem" Text="<img src='Imagens/excluir.gif' alt='' border='0'>" >
																</asp:LinkButton>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField='Plano' HeaderText="Plano" />
														<asp:BoundColumn Visible="False" DataField='Inicio' HeaderText="Inicio" />
														<asp:BoundColumn Visible="False" DataField='Termino' HeaderText="Término" />
														<asp:BoundColumn DataField='Valor' HeaderText="Valor R$" DataFormatString="{0:n}"/>
														<asp:BoundColumn DataField='ValorRenovacao' HeaderText="Valor Renovação R$" DataFormatString="{0:n}" ItemStyle-Width="130" ItemStyle-HorizontalAlign="Center" Visible="False"/>
														<asp:BoundColumn DataField='CondPagamento' HeaderText="Cond. de Pagamento" />
														<asp:BoundColumn DataField='Periodo' HeaderText="Periodo" />
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdPropostaItem")%>' CommandName="editItem" runat="server" ID="btnEditItem" Text="<img src='Imagens/editar.png' alt='' border='0'>" >
																</asp:LinkButton>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:DataGrid>
											</td>
										</tr>
										<tr id="trDetalhesPagto" runat="server" bgcolor="#EFEFEF">											
											<td Class="f8" Wrap="False" Colspan="2" ><b>Total do Orçamento R$:</b>&nbsp;
												<asp:Label CssClass="f8" ReadOnly="True" runat="server" Width="100px" ID="lblTotal" MaxLength="10" ></asp:Label>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<br>				
						<table id="Table3"  borderColor="#003c6e" cellSpacing="0" cellPadding="10" width="90%" border="1" runat="server" BgColor="#EFEFEF">						
							<tr>
								<td>
									<table borderColor="#003c6e" id="tblBotoes" runat="server" BorderWidth="0" CellSpacing="0" CellPadding="0" width="100%" BgColor="#EFEFEF">
										<tr>
											<td width="25%" align="center">
												<asp:ImageButton AlternateText="Apaga o Orçamento" ImageUrl='imagens/BotaoApagarOrcamento.gif' runat="server" id="btnApagarOrcamento"></asp:ImageButton>
											</td>
											<td width="25%" align="center">
												<asp:ImageButton AlternateText="Volta para a Tela da Proposta" ImageUrl='imagens/BotaoVoltarProposta.gif' runat="server" id="btnVoltarProposta"></asp:ImageButton>
											</td>
										</tr>
									</table>									
								</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>						
		</table><uc1:rodape id="Rodape1" runat="server"></uc1:rodape>
	</body>
</HTML>
