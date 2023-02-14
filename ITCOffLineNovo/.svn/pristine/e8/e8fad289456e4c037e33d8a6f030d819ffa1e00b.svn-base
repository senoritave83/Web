<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Proposta.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.Proposta" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoesProposta" Src="Inc/BarraBotoesProposta.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>

<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<script language=javascript>
		
			function fncVerificaCamposObrigatorios()
			{
				var blnReturn = true;	
				var spans = document.getElementsByTagName("span");
				var p_IdOrcamento = ''
				for (var i=0;i<spans.length;i++)
					{
						p_IdOrcamento = ''
						if (spans[i].Condicao != undefined)
							{
								if(spans[i].Condicao=='')
								{
									p_IdOrcamento = spans[i].IdOrcamento
									blnReturn =false
									alert('Informe corretamente os dados de Condição de Pagamento no orçamento ' + p_IdOrcamento);									
									break;									
								}
							}
						else if (spans[i].PrimeiroVenc != undefined)
							{
								if(spans[i].PrimeiroVenc=='')
								{
									p_IdOrcamento = spans[i].IdOrcamento
									blnReturn =false
									alert('Informe corretamente os dados do Primeiro Vencimento e a Data de Expiração no Orçamento ' + p_IdOrcamento);
									break;
								}
							}
						else if (spans[i].ExpiraEm != undefined)
							{
								if(spans[i].ExpiraEm=='')
								{
									p_IdOrcamento = spans[i].IdOrcamento
									blnReturn =false
									break;
								}
							}
							
					}
				if(fncVerificaValorRenovacao()==false)
					{						
						blnReturn =false;
					}
				return blnReturn;
			}
			
			
			function fncVerificaValorRenovacao() 
			{
				for (var i=0;i<frmCad.elements.length;i++)
				{
					var e = frmCad.elements[i];
					if ((e.name == 'hidOrc') && (e.type=='hidden'))
					{
						if(e.value==0 || e.value=='')
						{
							alert('Informe o Valor da Renovação no Plano ' + e.plano);
							return false;
						}
					}
				}
				return true;
			}
			
			function fncVerificaInicioeTermino() 
			{
				
				var blnReturn = true;
			
				for (var i=0;i<frmCad.elements.length;i++)
				{
					var e = frmCad.elements[i];
					if ((e.name == 'hidOrcIn') && (e.type=='hidden'))
					{						
						var p_IdOrcamento = e.id;
						var p_Index = p_IdOrcamento.indexOf("_");
						var p_IdOrcamento = p_IdOrcamento.substring(p_Index + 1);;
						var p_chkIdOrcamento = document.getElementById('rdOrcamento' + p_IdOrcamento);
						
						if(p_chkIdOrcamento.checked)
						{
							var grupo = p_chkIdOrcamento.getAttribute("grupo");;
							for (var i=0;i<frmCad.elements.length;i++)
							{
							
								var gr = frmCad.elements[i];
								if(gr.grupo == grupo && gr.type == 'hidden')
								{
									if(gr.value=='') blnReturn = false;
								}
							
							}
						}
						
					}
					
					if (blnReturn == false)
					{
						alert('Informe corretament as datas de Inicio e Termino do Plano  ' + e.plano + '  no Orçamento N. ' + e.Orcamento);
						return false;
					}
				
				}
				return fncConfirm(5);
			}
						
			function fncMarcaOrcamento(objOrc)
			{
					if(objOrc.checked==true)
					{
						for (var i=0;i<frmCad.elements.length;i++)
						{
							var e = frmCad.elements[i];
							if ((e.name == 'rdOrcamento') && (e.type=='checkbox'))
								{
									/*if(e.id==objOrc.id)
										e.checked=true;
									else
										e.checked=false;*/
									
									e.checked=(e.id==objOrc.id);
								}
								
						}
					}		
			}
			
			function fncVerificaOrcamentoMarcado()
			{
		
					for (var i=0;i<frmCad.elements.length;i++)
					{
						var e = frmCad.elements[i];
						if ((e.name == 'rdOrcamento') && (e.type=='checkbox'))
							{							
								if(e.checked==true)
								return true;
							}
						
					}
					return false;
			}		
		
			function fncConfirm(idStatus)
			{
				if (idStatus == 1)
				{
					if (confirm("Tem certeza que deseja Aprovar esta Proposta?")==true)
						return true;
					else
						return false;
				}
				else if (idStatus == 4)
				{
					if (confirm("Tem certeza que deseja Reprovar esta Proposta?")==true)
						return true;
					else
						return false;
				}
				else if (idStatus == 2)
				{
					if(fncVerificaCamposObrigatorios()==true)
					{
						if (confirm("Tem certeza que deseja Finalizar a Proposta?")==true)
							return true;
						else
							return false;
					}
					else
						return false;
				}
				else if (idStatus == 3)
				{
					if (confirm("Deseja Cancelar a Proposta?")==true)
						return true;
					else
						return false;
				}
				else if(idStatus == 5)
				{
					if(fncVerificaOrcamentoMarcado()==false)
					{
						alert('Selecione um orçamento antes de aprovar a proposta!');
						return false;
					} 
					return fncConfirm(1);
				}								
				else if(idStatus == 6)
				{
					if (confirm("Confirma a Geração do Pedido?")==true)
						return true;
					else
						return false;
				}
				else if(idStatus == 7)
				{
					if(confirm("Tem certeza que deseja Renovar esta Proposta?")==true)
						return true;
					else
						return false;
				}
			}
			
			function fncValida(dtg)
			{
				 if (dtg == "dtgContatos")
				{
					if(document.getElementById('<%=cboIdContato.ClientId%>').selectedIndex==0)
					{
						alert('Escolha o Contato a ser Adicionado!');
						return false;
					}
				}
												
			}
			
			function fncValidaCampo()
			{
				if(document.getElementById('<%=txtContatoCad.ClientId%>').value=='')
				{
					alert('Informe o Contato para a Proposta!');
					return false;
				}
				else if(document.getElementById('<%=txtEmailContato.ClientId%>').value=='')
				{
					alert('Informe o E-mail do Contato!');
					return false;
				}
				else if(document.getElementById('<%=txtValidadeProposta.ClientId%>').value=='')
				{
					alert('Informe a Validade da Proposta!');
					return false;
				}
				else if(document.getElementById('<%=cboIdTipoProposta.ClientId%>').value==0)
				{
					alert('Informe o Tipo da Proposta!');
					return false;
				}
				else
					{
						return fncConfirm(2);
						
					}
			}
									
			function openWindow(IdProposta, IdTipoProposta)
			
			{
			    window.open('FormularioProposta.aspx?IdProposta=' + IdProposta + '&idtipoproposta=' + IdTipoProposta, 'Pagina', 'STATUS=NO, TOOLBAR=YES, LOCATION=NO, SCROLLBARS=YES, LEFT=20, WIDTH=840, HEIGHT=750');
			}
			
			function EnviaEmail(idProp, tipoProp, emailCont, nomeAss, emailVend, idPosicao)
			{
			    window.open('EmailProposta.aspx?IdProposta=' + idProp + '&tipoProp=' + tipoProp + '&emailCont=' + emailCont + '&na=' + nomeAss + '&ev=' + emailVend + '&idPos=' + idPosicao, 'Pagina', 'width=400, height=200, scrollbars=no');
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
					<form id="frmCad" action="Proposta.aspx" runat="server">
                    		<asp:Literal ID="ltrMsgBox" Runat="server" />
                            <asp:HiddenField runat="server" ID="IRP" />
						<IMG height="40" src="imagens/TituloCadastroPropostas.jpg" width="443" border="0">
						<asp:PlaceHolder Runat=server ID="plcMensagem" Visible=False>
							<table id="Table2" borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="90%" border="1" runat="server">						
								<tr>
									<td>
										<table id="Table4" borderColor="#003c6e" border="0" runat="server" CellSpacing="2" CellPadding="1" width="100%" bgColor="#EFEFEF">
											<tr bgcolor="#003C6E">
												<td color="#FFFFFF" Align="Center" Class="f8"><font color=White /><b>MENSAGEM</td>
											</tr>
											<tr>
												<td align=center><asp:Label ID="lblMensagem" Runat="server" CssClass="f8">Teste de Mensagem</asp:Label></td>
											</tr>
											<tr>
												<td align=center><asp:BUTTON ID="btnOKMensagem" Runat="server" CssClass="f8" Text="OK"></asp:BUTTON></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</asp:PlaceHolder>
						<asp:PlaceHolder Runat=server ID='plcMain'>
							<table id="tblProposta"  borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="90%" border="1" runat="server">						
								<tr>
									<td>
										<table id="tblAssociadosDet" borderColor="#003c6e" border="0" runat="server" CellSpacing="2" CellPadding="1" width="100%" bgColor="#EFEFEF">
											<tr bgcolor="#003C6E">
												<td color="#FFFFFF" Align="Center" Class="f8" Colspan="9"><font color=White /><b>CADASTRO PRINCIPAL</b></td>
											</tr>
											<tr>
												<td Class="f8">Tipo da Proposta <b>*</b></td>
												<td colspan="2">
													<asp:dropdownlist CssClass="f8" id="cboIdTipoProposta" runat="server"></asp:dropdownlist>
												</td>
												<td Class="f8">Posição</td>
												<td colspan="2">
													<asp:dropdownlist CssClass="f8" id="cboIdPosicao" runat="server"></asp:dropdownlist>
												</td>
											</tr>
											<tr>
												<td Class="f8">Status da Proposta</td>
												<td colspan="2">
													<asp:dropdownlist CssClass="f8" enabled="false" id="cboIdStatus" runat="server"></asp:dropdownlist>
												</td>																									
												<td Class="f8">Número da Proposta</td>
												<td colspan="2">
													<asp:Label ID="lblIdProposta" Runat="server" CssClass="f8"></asp:Label>
												</td>
											</tr>
											<tr>
												<td Class="f8">Vendedor</td>
												<td colspan="2">
													<asp:dropdownlist ID="cboIdVendedor" Runat="server" width="80%"></asp:dropdownlist>
												</td>
												<td Class="f8">Data da Proposta</td>
												<td colspan="2">
													<asp:TextBox ID="txtData_Proposta" Runat="server" CssClass="f8" MaxLength="10" onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td Class="f8">Nome da Empresa</td>
												<td colspan="2">
													<asp:Label ID="lblRazaoSocial" Runat="server" CssClass="f8"></asp:Label>
												</td>
												<td Class="f8">C&oacute;digo da Empresa</td>
												<td colspan="2">
													<asp:Label ID="lblIdAssociado" Runat="server" CssClass="f8"></asp:Label>
												</td>
											</tr>
											<tr>
												<td Class="f8">Endereço</td>
												<td colspan="2">
													<asp:TextBox ID="txtEndereco" Runat="server" CssClass="f8" width="80%"></asp:TextBox>
												</td>
												<td Class="f8">Complemento</td>
												<td colspan="2">
													<asp:TextBox ID="txtComplemento" Runat="server" CssClass="f8" width="80%"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td Class="f8">Cidade</td>
												<td colspan="2">
													<asp:TextBox ID="txtCidade" Runat="server" CssClass="f8"></asp:TextBox>
												</td>
												<td Class="f8">Estado</td>
												<td colspan="2">
													<asp:dropdownlist ID="cboIdEstado" Runat="server" ></asp:dropdownlist>
												</td>
											</tr>
											<tr>
												<td Class="f8">CEP</td>
												<td colspan="2">
													<asp:TextBox ID="txtCep" MaxLength="9" Runat="server" CssClass="f8"></asp:TextBox>
												</td>
												<td Class="f8">CNPJ</td>
												<td colspan="2">
													<asp:Label ID="lblCnpj" Runat="server" CssClass="f8"></asp:Label>
												</td>
											</tr>
											<tr>
												<td Class="f8">Fone</td>
												<td colspan="2">
													<asp:TextBox ID="txtTelefone" Runat="server" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);" CssClass="f8"></asp:TextBox>
												</td>
												<td Class="f8">Fax</td>
												<td colspan="2">
													<asp:TextBox ID="txtFax" Runat="server" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);" CssClass="f8"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td Class="f8">WebSite</td>
												<td colspan="2">
													<asp:TextBox ID="txtWebSite" Runat="server" CssClass="f8" width="80%"></asp:TextBox>
												</td>
												<td Class="f8">E-mail Principal</td>
												<td colspan="2">
													<asp:TextBox ID="txtEmailPrincipal" Runat="server" CssClass="f8" width="80%"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td Class="f8">Contato <b>*</b></td>
												<td colspan="2">
													<asp:TextBox ID="txtContatoCad" Runat="server" CssClass="f8"></asp:TextBox>
												</td>
												<td Class="f8">E-mail Contato <b>*</b></td>
												<td colspan="2">
													<asp:TextBox ID="txtEmailContato" Runat="server" MaxLength="50" CssClass="f8" width="80%"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td Class="f8">Fone Contato</td>
												<td colspan="2">
													<asp:TextBox ID="txtTelefoneContato" Runat="server" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);" CssClass="f8"></asp:TextBox>
												</td>
												<td Class="f8">Celular Contato</td>
												<td colspan="2">
													<asp:TextBox ID="txtCelContato" Runat="server" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);" CssClass="f8"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td Class="f8">Fax Contato</td>
												<td colspan="2">
													<asp:TextBox ID="txtFaxContato" Runat="server" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);" CssClass="f8"></asp:TextBox>
												</td>
											</tr >
											<tr id="trNumPedido">
												<td Class="f8">Número do Pedido Gerado:&nbsp;</td>
												<td colspan="5">
													<asp:Label ID="lblNumPedido" CssClass="f8" Runat="server"></asp:Label>
												</td>
											</tr>											
											<tr>
												<td Class="f8">Proposta Válida Até: <b>*</b></td>
												<td colspan="2">
													<asp:TextBox CssClass="f8" ID="txtValidadeProposta" Runat="server" Width="80px" MaxLength="10" onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);"></asp:TextBox>
												</td>
												<td id="tdRenovacao" runat="server" visible="false" Class="f8" colspan="2" style="font:bold;">Renovação a partir da Proposta n&ordm;&nbsp;<asp:label ID="lblIdPropostaPai" CssClass="f8" Runat="server"></asp:label>
												</td>									
											</tr>
										</table>
									</td>
								</tr>
							</table>
							<br>
							<table id="Table1"  borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="90%" runat="server">						
								<tr>
									<td>
										<table id="tblContatos" borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="100%" border="1" runat="server">
											<tr bgcolor="#003C6E">
												<td align="center" width="100%">
													<b><font class="f8" color="#ffffff">CONTATOS</font></b>
												</td>
											</tr>
											<tr>
												<td>
													<asp:datagrid id="dtgContatos" runat="server" CellPadding="3" width="100%" BackColor="White" AutoGenerateColumns="False"
														GridLines="none" BorderStyle="None" BorderColor="#999999" AllowSorting="False" AllowPaging="False" CssClass="f8">
														<HeaderStyle ForeColor="#ffffff" BackColor="#003C6E"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdContato")%>' CommandName="deleteItem" runat="server" ID="btnDeletePlano" Text="<img src='imagens/Excluir.gif' alt='' border='0'>" >
																	</asp:LinkButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField='NomeContato' HeaderText="Nome" />
															<asp:BoundColumn DataField='DescricaoCargo' HeaderText="Cargo" />
															<asp:BoundColumn DataField='CTelefone' HeaderText="Telefone/Celular" />
															<asp:BoundColumn DataField='EMail' HeaderText="E-Mail" />
														</Columns>
													</asp:datagrid>
												</td>
											</tr>
											<tr id="trAddContato" runat="server" bgcolor="#EFEFEF">
												<td>
													<b><asp:Label ID="lblContato" Text=" Novo Contato" CssClass="f8" Runat="server"></asp:Label></b>
													<asp:DropDownList id="cboIdContato" runat="server"></asp:DropDownList>
													<asp:Button CssClass="f8" ID="btnAddContato" Text="Adicionar Contato" Runat="server" />
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							<br>
							<asp:Repeater id="rptOrcamentos" runat="server" OnItemDataBound="rptIndi_ItemDataBound" >
								<HeaderTemplate>
								</HeaderTemplate>
									<ItemTemplate>
										<table id="tblOrcamento"  borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="90%" border="1" runat="server">						
										<tr>
											<td>
												<table id="tblPlanos" borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="100%" runat="server" border="0" CssClass="f8">
													<tr id= trlkOrcamento bgcolor="#003C6E">
														<td CssClass="f8" Wrap="False" align="center" Colspan="4">
															<b><%# IIf(ViewState("IdStatus")<>5 and ViewState("IdStatus")<>2 and ViewState("IdStatus")<>7,"<font class='f8' color='#ffffff'>ORÇAMENTO N.&nbsp;" & DataBinder.Eval(Container.DataItem, "IdOrcamento") & "</font>","<a style='color:white;' href='PropostaAdicOrc.aspx?IDProposta=" & CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdProposta")) & "&IDOrcamento=" & CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdOrcamento")) & "'><font class='f8' color='#ffffff'>ORÇAMENTO N.&nbsp;" & DataBinder.Eval(Container.DataItem, "IdOrcamento") & "</font></a>")%></b>
															<asp:Image Runat=server ID='imgStatus' ImageUrl='Imagens/Check1.png' BorderStyle=None Visible='<%#((ViewState("IdStatus")=1 or ViewState("IdStatus")=6) AND DataBinder.Eval(Container.DataItem, "Aprovado") = 1)%>'></asp:Image>
															<input grupo="<%# DataBinder.Eval(Container.DataItem, "IdOrcamento")%>" <%# IIf(ViewState("IdStatus")=1,"disabled","")%> Style='visibility:<%# IIf(ViewState("IdStatus")=2,"visible","hidden")%>' type=checkbox id='rdOrcamento<%#DataBinder.Eval(Container.DataItem, "IdOrcamento")%>' name="rdOrcamento" value='<%#DataBinder.Eval(Container.DataItem, "IdOrcamento")%>' onclick="fncMarcaOrcamento(this);">
														</td>
													</tr>
													<tr >
														<td CssClass="f8" Text="" Wrap="False" Colspan="4">
															<asp:DataGrid id="dtgPlanos" CssClass="f8" runat="server" AllowPaging="False" DataSource='<%# ListarOrcamentosItem(DataBinder.Eval(Container.DataItem, "IdOrcamento"))%>' AllowSorting="False" BorderColor="#999999"
																BorderStyle="None" BackColor="White" CellPadding="7" GridLines="none" AutoGenerateColumns="False" width="100%" OnItemDataBound='dtgPlanos_ItemDataBound'>
																<HeaderStyle ForeColor="#ffffff" BackColor="#003C6E"></HeaderStyle>
																<Columns>
																	<asp:BoundColumn DataField='Plano' HeaderText="Plano" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%"/>
																	<asp:TemplateColumn Visible="False" HeaderText='Inicio' ItemStyle-HorizontalAlign="left" ItemStyle-Width="20%">
																		<ItemTemplate>
																			<asp:Label runat="server" ID="lblInicio" Text='<%# DataBinder.Eval(Container.DataItem, "Inicio")%>' ></asp:Label>
																			<input type=hidden grupo="<%# DataBinder.Eval(Container.DataItem, "IdOrcamento")%>" id='hidOrcIn<%# DataBinder.Eval(Container.DataItem, "IdPropostaItem")%>_<%# DataBinder.Eval(Container.DataItem, "IdOrcamento")%>' name='hidOrcIn' value='<%# DataBinder.Eval(Container.DataItem, "Inicio")%>' plano='<%# DataBinder.Eval(Container.DataItem, "Plano")%>' Orcamento='<%# DataBinder.Eval(Container.DataItem, "IdOrcamento")%>' >
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn Visible="False" HeaderText='Termino' ItemStyle-HorizontalAlign="left" ItemStyle-Width="20%">
																		<ItemTemplate>
																			<asp:Label runat="server" ID="lblTermino" Text='<%# DataBinder.Eval(Container.DataItem, "Termino")%>' ></asp:Label>
																			<input type=hidden grupo="<%# DataBinder.Eval(Container.DataItem, "IdOrcamento")%>" id='hidOrcTe<%# DataBinder.Eval(Container.DataItem, "IdPropostaItem")%>_<%# DataBinder.Eval(Container.DataItem, "IdOrcamento")%>' name='hidOrcTe' value='<%# DataBinder.Eval(Container.DataItem, "Termino")%>' plano='<%# DataBinder.Eval(Container.DataItem, "Plano")%>' Orcamento='<%# DataBinder.Eval(Container.DataItem, "IdOrcamento")%>' >
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn DataField='Valor' HeaderText="Valor R$" DataFormatString="{0:n}" ItemStyle-Width="20%" />
																	<asp:TemplateColumn HeaderText='Valor Renovação R$' ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%">
																		<ItemTemplate>
																			<asp:Label runat="server" ID="lblValorRenovacao" Text='<%#FormatNumber(DataBinder.Eval(Container.DataItem, "ValorRenovacao"),2)%>' ></asp:Label>
																			<input type=hidden id='hidOrc<%# DataBinder.Eval(Container.DataItem, "IdPropostaItem")%>' name='hidOrc' value='<%# DataBinder.Eval(Container.DataItem, "ValorRenovacao")%>' plano='<%# DataBinder.Eval(Container.DataItem, "Plano")%>' >
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:BoundColumn DataField='CondPagamento' HeaderText="Cond. de Pagamento" ItemStyle-Width="20%"/>
																	<asp:BoundColumn DataField='Periodo' HeaderText="Periodo" ItemStyle-Width="20%" />										
																</Columns>
															</asp:DataGrid>
														</td>
													</tr>
													<tr>
														<td></td>
														<td></td>
														<td></td>
													</tr>
													<tr>
														<td></td>
														<td></td>
														<td></td>
													</tr>
													<tr bgcolor="#EFEFEF">
														<td Class="f8" Wrap="False" ><b>Total do Orçamento R$:</b>&nbsp;
															<asp:Label CssClass="f8" runat="server" ID="lblOrcamentoRS" Width="50"></asp:Label>
														</td>
														<td Class="f8" visible='<%#IIf(DataBinder.Eval(Container.DataItem, "Renovacao")=1,true,false)%>'><b>Expira Em:</b>&nbsp;
															<asp:Label IdOrcamento='<%#DataBinder.Eval(Container.DataItem, "IdOrcamento")%>' ExpiraEm='<%# DataBinder.Eval(Container.DataItem, "ExpiraOrcamento")%>' CssClass="f8" ID="lblExpiraOrcamento" Runat="server" Width="50"><%# DataBinder.Eval(Container.DataItem, "ExpiraOrcamento")%></asp:Label>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										</table>			
										<br>
									</ItemTemplate>
							</asp:Repeater>
							<table borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="90%" border="1">
								<tr>
									<td colSpan="3">
										<asp:table id="tblObservacao" runat="server" BorderWidth="0" CellSpacing="2" CellPadding="1" width="100%" BackColor="#EFEFEF">
											<asp:TableRow backcolor="#003C6E">
												<asp:TableCell forecolor="#FFFFFF" HorizontalAlign="Left" CssClass="f8" Text="OBSERVAÇÃO" ColumnSpan="4" />
											</asp:TableRow>
											<asp:TableRow>
												<asp:TableCell Wrap="False" VerticalAlign="Middle" HorizontalAlign="left" >
													<asp:TextBox CssClass="f8" ID="txtObservacao" Runat="server" TextMode="MultiLine" Rows="3" Width="100%"></asp:TextBox>
												</asp:TableCell>
											</asp:TableRow>
										</asp:table>
									</td>
								</tr>
							</table>
							<br>
							<table id="Table3"  borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="90%" border="1" runat="server">						
								<tr>
									<td>
										<table borderColor="#003c6e" id="tblBotoes" runat="server" BorderWidth="0" CellSpacing="0" CellPadding="1" width="100%" BgColor="#EFEFEF">
											<tr>
												<td HorizontalAlign="Center" text="">
													<uc1:BarraBotoesProposta id="BarraBotoesProposta" runat="server"></uc1:BarraBotoesProposta>
													<table width="100%" border="0">
														<tr>
															<td width="25%" align="center">
																<a href='#' onclick="openWindow('<%=CryptographyEncoded(ViewState("IdProposta"))%>', '<%=cboIdTipoProposta.SelectedValue%>')"><img src='imagens/BotaoImprimirProposta.gif'  runat='server' id="btnImprimir" border=0 ></a>
															</td>
															<td width="25%" align="center">
																<a href='#' onclick="EnviaEmail('<%=CryptographyEncoded(ViewState("IdProposta"))%>', '<%=cboIdTipoProposta.SelectedValue%>', '<%=txtEmailContato.text%>', '<%=lblRazaoSocial.text%>', '<%=ViewState("EmailVendedor")%>', '<%=cboIdPosicao.SelectedValue%>')"><img src='imagens/BotaoEnviarEmail.gif'  runat='server' id="btnEnviarEmail" border=0 ></a>
															</td>
															<td width="25%" align="center">
																<asp:ImageButton AlternateText="Adiciona um novo Orçamento" ImageUrl='imagens/BotaoIncluirOrcamento.gif' runat='server' id="btnAddOrcamento" visible="false"></asp:ImageButton>
															</td>
															<td align="center">
																<asp:ImageButton AlternateText="Cancela a Proposta" ImageUrl='imagens/BotaoCancelarProposta.gif' runat='server' id="btnCancelarProp"></asp:ImageButton>
															</td>
														</tr>
														<tr>
															<td width="25%" align="center">
																<asp:ImageButton AlternateText="Finaliza a Proposta" ImageUrl='imagens/BotaoFinalizarProposta.gif' runat="server" id="btnFinalizarProp"></asp:ImageButton>
															</td>
															<td width="25%" align="center">
																<asp:ImageButton AlternateText="Aprova a Proposta" ImageUrl='imagens/BotaoAprovarProposta.gif' runat="server" id="btnAprovarProp"></asp:ImageButton>
															</td>
															<td width="25%" align="center">
																<asp:ImageButton AlternateText="Reprova a Proposta" ImageUrl='imagens/BotaoReprovarProposta.gif' runat='server' id="btnReprovarProp" visible="false"></asp:ImageButton>
															</td>
															<td width="25%" align="center">
																<asp:ImageButton AlternateText="Envia a Proposta Para o Módulo de Pedidos" ImageUrl='imagens/BotaoGerarPedido.gif' runat='server' id="btnGerarPedido" visible="false"></asp:ImageButton>
															</td>
														</tr>
														<tr>
															<td width="25%" align="center" colspan="4">
																<asp:ImageButton AlternateText="Duplica a Proposta em Modo de Renovação" ImageUrl='imagens/BotaoRenovarProposta.gif' runat='server' id="btnRenovacao" visible="false"></asp:ImageButton>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</table>									
									</td>
								</tr>
							</table>						
						</asp:PlaceHolder>
					</form>
				</td>
			</tr>						
		</table><uc1:rodape id="Rodape1" runat="server"></uc1:rodape>
	</body>
</HTML>
