<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PesquisaAssociados.aspx.vb"  ValidateRequest="False" Inherits="ITC.PesquisaAssociados"%>
<%@ Register TagPrefix="uc1" TagName="BarraNavegacao" Src="Inc/BarraNavegacao.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
  <HEAD>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<script language="javascript">
		
			function CA(p_Obj)
			{
				for (var i=0;i<frmCad.elements.length;i++)
					{
						var e = frmCad.elements[i];
						if ((e.name != 'allbox') && (e.type=='checkbox'))
							{
								e.checked = p_Obj.checked;
							}
					}
			}
			
		</script>
	</HEAD>
	<body onload="vertical();horizontal();" >
		<form id="frmCad" runat="server">
			<div id=Tudo runat=server>
			
				<uc1:Top id="Top1" runat="server"></uc1:Top>
				<table align="center" id="tblTopo" width="100%" runat="server">
					<tr>
						<td align="middle">
							<asp:label id="lblMensagemTopo" Runat="server" CssClass="f8">SELECIONE TODOS OS ITENS DESEJADOS EM SUA PESQUISA E CLIQUE NO BOTÃO PESQUISAR.</asp:label><br>
							<asp:label id="lblMensagemTopo2" Runat="server" CssClass="f8">Caso não selecione nenhum critério, retornarão todos os associados.</asp:label><br>
						</td>
					</tr>
				</table>
				<table id="tblSelecao" width="100%" border="0" runat="server">
					<tr>
						<td vAlign="top" width="33%">
							<table width="100%" bgColor="#003c6e" border="0">
								<tr>
									<td noWrap align="middle"><font class="f8" color="#ffffff"><b>PLANOS FINALIZADOS (Entre datas)</b></font></td>
								</tr>
							</table>
							<table width="100%" border="0" bgcolor=#EFEFEF>
								<tr>
									<td noWrap align="left"><asp:label id="Label4" Runat="server" forecolor=#FF0000 CssClass="f8">De</asp:label></td>
									<td align="left" width="100%"><asp:textbox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" MaxLength="10" Width="100" Runat="server" id="txtDataInicio" CssClass="f8" onfocus="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)" style="cursor:pointer;" ></asp:textbox> <font class=f8>(ddmmaa)</font></td>
								</tr>
								<tr>
									<td noWrap align="left"><asp:label id="Label2" Runat="server" forecolor=#FF0000 CssClass="f8">Até</asp:label></td>
									<td align="left" width="100%"><asp:textbox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" MaxLength="10" Width="100" Runat="server" id="txtDataFim" CssClass="f8" onfocus="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)" style="cursor:pointer;" </asp:textbox> <font class=f8>(ddmmaa)</font></td>
								</tr>
							</table>
							<br>
							<table width="100%" bgColor="#003c6e" border="0">
								<tr>
									<td noWrap align="middle"><font class="f8" color="#ffffff"><b>POSIÇÃO</b></font></td>
								</tr>
							</table>
							<asp:datalist id="dtlPosicao" ItemStyle-Width=33% runat="server" CssClass="f8" width="100%" RepeatColumns=2 RepeatDirection=Vertical GridLines="none" CellSpacing=0 CellPadding=0 BackColor="#EFEFEF" BorderStyle=Outset BorderColor="#999999" DataKeyField="IdPosicao" BorderWidth="1">
								<ItemTemplate>
									<asp:CheckBox name=chkEstados runat=server Text='<%# DataBinder.Eval(Container.DataItem, "DESCRICAOPOSICAO").ToUpper()%>'  ID="chkPosicao" />
								</ItemTemplate>
							</asp:datalist>
						</td>
						<td vAlign="top" width="33%">
							<table width="100%" bgColor="#003c6e" border="0">
								<tr>
									<td noWrap align="middle"><font class="f8" color="#ffffff"><b>PLANOS CANCELADOS (Entre datas)</b></font></td>
								</tr>
							</table>
							<table width="100%" border="0" bgcolor=#EFEFEF>
								<tr>
									<td noWrap align="left"><asp:label id="Label3" Runat="server" forecolor=#FF0000 CssClass="f8">De</asp:label></td>
									<td align="left" width="100%"><asp:textbox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" id="txtCancInicial" Runat="server" CssClass="f8" Width="100" MaxLength="10" onfocus="displayCalendar(document.forms[0].txtCancInicial,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtCancInicial,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtCancInicial,'dd/mm/yyyy',this)" style="cursor:pointer;"></asp:textbox> <font class=f8>(ddmmaa)</font></td>
								</tr>
								<tr>
									<td noWrap align="left"><asp:label id="Label6" Runat="server" forecolor=#FF0000 CssClass="f8">Até</asp:label></td>
									<td align="left" width="100%"><asp:textbox id="txtCancFinal" onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" Runat="server" CssClass="f8" Width="100" MaxLength="10" onfocus="displayCalendar(document.forms[0].txtCancFinal,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtCancFinal,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtCancFinal,'dd/mm/yyyy',this)" style="cursor:pointer;"></asp:textbox> <font class=f8>(ddmmaa)</font></td>
								</tr>
							</table>
							<br>
							<table width="100%" bgColor="#003c6e" border="0">
								<tr>
									<td noWrap align="middle"><font class="f8" color="#ffffff"><b>RAMO</b></font></td>
								</tr>
							</table>
							<asp:datalist BackColor=#EFEFEF ItemStyle-Width=50% id="dtlRamos" runat="server" CssClass="f8" width="100%" RepeatColumns=2 RepeatDirection=Vertical GridLines="none" CellSpacing=0 CellPadding=0  BorderStyle=Outset BorderColor="#999999" DataKeyField="IdRamo" BorderWidth="1">
								<ItemTemplate>
									<asp:CheckBox BackColor=#EFEFEF name=chkTipos runat=server Text='<%# DataBinder.Eval(Container.DataItem, "DESCRICAORAMO").ToUpper()%>' ID="chkRamo" />
								</ItemTemplate>
							</asp:datalist>
						</td>
						<td vAlign="top" width="33%">
							<table width="100%" bgColor="#003c6e" border="0">
								<tr>
									<td noWrap align="middle"><font class="f8" color="#ffffff"><b>STATUS</b></font></td>
								</tr>
							</table>
							<asp:datalist id="dtlStatus" runat="server" CssClass="f8" width="100%" GridLines="none" CellSpacing=0 CellPadding=0  BackColor="#EFEFEF" BorderStyle=Outset BorderColor="#999999" DataKeyField="IdStatus" BorderWidth="1" RepeatColumns=3 RepeatDirection=Horizontal>
								<ItemTemplate>
									<asp:CheckBox runat=server Enabled=true Text='<%# Ucase(DataBinder.Eval(Container.DataItem, "DescricaoStatus"))%>' Checked='false' ID="chkStatus" />
								</ItemTemplate>
							</asp:datalist>
							<br>
							<table width="100%" bgColor="#003c6e" border="0">
								<tr>
									<td noWrap align="middle"><font class="f8" color="#ffffff"><b>FORMA DE PAGAMENTO</b></font></td>
								</tr>
							</table>
							<asp:datalist id="dtlFormaPagto" runat="server" CssClass="f8" width="100%" GridLines="none" CellSpacing=0 CellPadding=0  BackColor="#EFEFEF" BorderStyle=Outset BorderColor="#999999" DataKeyField="IdFormaPagamento" BorderWidth="1" RepeatColumns=3 RepeatDirection=Horizontal>
								<ItemTemplate>
									<asp:CheckBox runat=server Enabled=true Text='<%# Ucase(DataBinder.Eval(Container.DataItem, "Descricao"))%>' Checked='false' ID="chkFormaPagto" />
								</ItemTemplate>
							</asp:datalist>
						</td>
					</tr>
					<tr>
						<td vAlign="top" width="100%" colspan=3>
							<table width="100%" bgColor="#003c6e" border="0">
								<tr>
									<td noWrap align="middle"><font class="f8" color="#ffffff"><b>PRODUTOS</b></font></td>
								</tr>
							</table>
							<asp:datalist id="dtlProdutos" runat="server" RepeatColumns=3 RepeatDirection=Horizontal  CssClass="f8" width="100%" GridLines="none" CellSpacing=0 CellPadding=0 BackColor="#EFEFEF" BorderStyle=Outset BorderColor="#999999" DataKeyField="IdProduto" BorderWidth="1">
								<ItemTemplate>
									<asp:CheckBox runat=server Enabled='TRUE' Text='<%# DataBinder.Eval(Container.DataItem, "DESCRICAOPRODUTO")%>' Checked='false' ID="chkProdutos" />
								</ItemTemplate>
							</asp:datalist>
						</td>
					</tr>
					<tr>
						<td vAlign="top" colspan=3>
							<table width="100%" bgColor="#003c6e" border="0">
								<tr>
									<td noWrap align="middle"><font class="f8" color="#ffffff"><b>ATIVIDADE</b></font></td>
								</tr>
							</table>
							<asp:datalist id="dtlAtividade" runat="server" CssClass="f8" width="100%" GridLines="none" CellSpacing=0 CellPadding=0  BackColor="#EFEFEF" BorderStyle=Outset BorderColor="#999999" DataKeyField="IDATIVIDADERAMO" BorderWidth="1" RepeatColumns=3 RepeatDirection=Horizontal >
								<ItemTemplate>
									<asp:CheckBox runat=server Enabled=true Text='<%# DataBinder.Eval(Container.DataItem, "DESCRICAOATIVIDADERAMO")%>' Checked='false' ID="chkAtividade" />
								</ItemTemplate>
							</asp:datalist>
						</td>
					</tr>
					<tr>
						<td align="middle" width="100%" colSpan="3">&nbsp;
						</td>
					</tr>
					<tr>
						<td vAlign="top" width="100%" colSpan="3" align=center>
							<table borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="100%" border="1">
								<tr>
									<td noWrap align="middle">
										<table width="100%" bgColor="#003c6e" border="0">
											<tr>
												<td noWrap align="middle"><font class="f8" color="#ffffff"><b>MAIS FILTROS</b></font></td>
											</tr>
										</table>
										<table width="100%" bgColor="#EFEFEF" border="0">
											<tr>
												<td noWrap align="middle">
													<table width="100%" border="0" cellspacing=0>
														<tr>
															<td noWrap width=10% align="right"><asp:label id="Label19" Runat="server" CssClass="f8" NAME="Label7">Fantasia</asp:label></td>
															<td align="left" ><asp:textbox id="txtFantasia" Runat="server" CssClass="f8" Width="200" MaxLength="50"></asp:textbox></td>
															<td width=10% noWrap align="right"><asp:label id="Label12" Runat="server" CssClass="f8" NAME="Label7">Razão Social</asp:label></td>
															<td align="left" ><asp:textbox id="txtRazaoSocial" Runat="server" CssClass="f8" Width="200" MaxLength="50"></asp:textbox></td>
														</tr>
														<tr>
															<td noWrap width=10% align="right"><asp:label id="Label1" Runat="server" CssClass="f8" NAME="Label7">Vendedor(a)</asp:label></td>
															<td align="left" ><uc1:combobox id="cboVendedor" cssClass="f8" EnableValidation=false runat="server"></uc1:combobox></td>
															<td noWrap width=10% align="right"><asp:label id="lblEstado" Runat="server" CssClass="f8" NAME="Label7">Estado</asp:label></td>
															<td align="left" ><asp:DropDownList id="cboIdEstado" cssClass="f8" runat="server"></asp:DropDownList></td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td align="middle" width="100%" colSpan="3">&nbsp;
							<br>
						</td>
					</tr>
					<tr>
						<td align="middle" width="100%" colSpan="3">
							<table bgcolor=#EFEFEF borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="100%" border="1">
								<tr>
									<td noWrap align="middle">
										<table borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="80%" border="0">
											<tr>
												<td>
													<table width="100%" bgColor="#EFEFEF">
														<tr>
															<td align="middle" width="33%"><asp:imagebutton id="btnNovaPesquisa" Runat="server" CssClass="f8"  ImageUrl="imagens/botaonovapesquisa.gif" BorderStyle="None"></asp:imagebutton></td>
															<td align="middle" width="33%"><asp:imagebutton id="btnPesquisar" Runat="server" CssClass="f8"  ImageUrl="imagens/botaopesquisar.gif" BorderStyle="None"></asp:imagebutton></td>
															<td noWrap align="right" width="25%"><asp:label id="Label5" Runat="server" CssClass="f8">ORDENAR POR:								<input type=Hidden id='hddOrdem' name='hddOrdem' runat=server /></asp:label></td>
															<td noWrap align="left" width="25%"><uc1:combobox id="cboOrdenar" cssClass="f8" EnableValidation=false runat="server"></uc1:combobox></td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
				<table id="tblResultados" width="100%" runat="server">
					<tr>
						<td width="100%" colSpan="2">
							<uc1:BarraNavegacao id="Barranavegacao2" runat="server"></uc1:BarraNavegacao>
							<asp:datagrid id="dtgResultados" runat="server" CssClass="f9" width="100%" AutoGenerateColumns="False" GridLines="none" CellPadding="3" BackColor="White" BorderColor="#999999" DataKeyField="CODIGO" BorderWidth="0" HorizontalAlign="Center" AllowPaging=True PageSize="50" AllowSorting="True">
								<HeaderStyle BackColor="#003C6E" ForeColor="#FFFFFF"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn ItemStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="left" ItemStyle-Font-Name="verdana" ItemStyle-Font-Size="10" HeaderStyle-Width="1%" HeaderText='<input type="checkbox" onclick="javascript:CA(this);" class="f8" value="Todos" id=btnMarcarTodos NAME="btnMarcarTodos">'>
										<ItemTemplate>
											<input type=checkbox ID="chkItemResultado" value="<%# DataBinder.Eval(Container.DataItem, "CODIGO")%>">&nbsp;<%# DataBinder.Eval(Container.DataItem, "CODIGO")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="30%" HeaderText="<B>RAZÃO SOCIAL</B>">
										<ItemTemplate>
											<b><%# DataBinder.Eval(Container.DataItem, "RAZAOSOCIAL")%></b>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="30%" HeaderText="<B>FANTASIA</B>">
										<ItemTemplate>
											<b><%# DataBinder.Eval(Container.DataItem, "FANTASIA")%></b>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="30%" HeaderText="<B>VENDEDOR</B>">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "VENDEDOR")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="<B>CIDADE</B>">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "CIDADE")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="<B>UF</B>">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "UF")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="10" HeaderText="" HeaderStyle-Wrap=False>
										<ItemTemplate>
											<a href='followupassocdet.aspx?idassociado=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "CODIGO"))%>'><img src='imagens/arrow-right.gif' border=0 alt="Adicionar/Editar Follow-UP de <%# DataBinder.Eval(Container.DataItem, "FANTASIA")%>"></a>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle  Visible=False HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
							<uc1:BarraNavegacao id="BarraNavegacao1" runat="server"></uc1:BarraNavegacao>
							<input type=hidden id=Ord name=Ord runat=server>
							<br>
							<script language=javascript>
								
								function XM_ITC_GetIds(){
									var valores;
									valores = '';
									
									for (var i=0;i<frmCad.elements.length;i++)
										{
											var e = frmCad.elements[i];
											if ((e.name != 'allbox') && e.id != 'btnMarcarTodos' && (e.type=='checkbox'))
												{
													if(e.checked == true){
														if(valores!=''){
															valores = valores + ',';
														}
														valores += e.value;
													}
												}
										}
									return valores;
								}
								
								function XM_ITC_Pesquisar(){
									var valores = XM_ITC_GetIds();
									if(valores != ''){
										window.open('relatorioassociados.aspx?dt=<%=Now()%>&or=' + document.frmCad.Ord.value + '&o=' + valores , 'ITCNET_PESQUISAR_OBRAS', 'height=600, width=800, top=10, left=10, toolbar=yes, scrollbars=yes, resizable=yes');
									}
								}
								
								function XM_ITC_PesquisarResumo(){
									var valores = XM_ITC_GetIds();
									if(valores != ''){
										window.open('relatorioassociadosresumo.aspx?dt=<%=Now()%>&or=' + document.frmCad.Ord.value + '&o=' + valores , 'ITCNET_PESQUISAR_OBRAS', 'height=600, width=800, top=10, left=10, toolbar=yes, scrollbars=yes, resizable=yes');
									}
								}
																		
							</script>
							<table id="tblBotoesResultados" borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="80%" align="center" border="1" runat="server">
								<tr>
									<td>
										<table width="100%" align="center" bgColor="#f7f7d8">
											<tr>
												<td align="middle" width="33%"><asp:imagebutton id="btnNovaPesquisa2" Runat="server" CssClass="f8"  ImageUrl="imagens/botaonovapesquisa.gif" BorderStyle="None"></asp:imagebutton></td>
												<td align="middle" width="33%"><asp:image id="btnImprimir" style="cursor: hand;" Runat="server" CssClass="f8"  ImageUrl="imagens/botaovisualizarpesquisa.gif" BorderStyle="None"></asp:image></td>
												<td align="middle" width="33%"><asp:image id="btnImprimirResumo" style="cursor: hand;" Runat="server" CssClass="f8"  ImageUrl="imagens/botaovisualizarresumo.gif" BorderStyle="None"></asp:image></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							<br>
							<table id="Table1" borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="65%" align="center" border="1" runat="server">
								<tr>
									<td>
										<table width="100%" align="center" bgColor="#f7f7d8">
											<tr>
												<td noWrap align="right"><font class="f8">Tipo de Relatório: </font>
												</td>
												<td align="left" width="100%">
													<asp:RadioButtonList CssClass="f8" RepeatDirection="Horizontal" Runat="server" ID="TipoRelatorio">
														<asp:ListItem Value="1" Selected="True">Relatório Sequencial</asp:ListItem>
														<asp:ListItem Value="2">1 Resultado por Página</asp:ListItem>
													</asp:RadioButtonList></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							</td>
						</tr>
					</table>
				</div>
			</form>
		</body>
	<uc1:Rodape id="Rodapé1" runat="server"></uc1:Rodape>
</HTML>
