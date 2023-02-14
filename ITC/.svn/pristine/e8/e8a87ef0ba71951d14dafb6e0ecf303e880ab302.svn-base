<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Demonstracao2.aspx.vb"  ValidateRequest="False" Inherits="ITC.Demonstracao2"%>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraNavegacao" Src="Inc/BarraNavegacao.ascx" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<script language="javascript">
		
			function XM_GOTO(p_Page)
			{
				document.location.href = p_Page;
			}

			function Ativa(p_Tipo, p_Check)
			{
				/*
				OBETIVO: ROTINA QUE HABILITA OU DESABILITA OS CHECKBOX DO FASES E ESTÁGIOS
						 QUANDO É TIRADO O CHECK DE UM DELES TODOS DEVEM ESTAR HABILITADOS
						 QUANDO É COLOCADO O CHECK EM UM DELES O OUTRO DEVE SER DESABILITADO
				AUTOR:	 MARCELO R. M. SOUZA
				*/
				
				var blnChecked = p_Check.checked;
				var blnAllUnChecked = true;
				
				for (var i=0;i<frmCad.elements.length;i++)
				{
					var e = frmCad.elements[i];
					if (e.type=='checkbox')
					{
						var strId = e.id;
						if(p_Tipo==1)
						{
							if(strId.indexOf('dtlFases')>-1)
								if(blnAllUnChecked==true && e.checked==true)
									blnAllUnChecked=false;
							
						}
						else
						{
							if(strId.indexOf('dtlEstagios')>-1)
								if(blnAllUnChecked==true && e.checked==true)
									blnAllUnChecked=false;
						}
					}
				}				
				
				var blnEnable;
				
				for (var i=0;i<frmCad.elements.length;i++)
				{
					var e = frmCad.elements[i];
					if (e.type=='checkbox')
					{
						var strId = e.id;
						if(p_Tipo==1 && blnAllUnChecked)
						{
							/*
							O USUÁRIO CLICOU EM UMA FASE E TODAS AS FASES ESTÃO UNCHECKED
							*/		
							if(strId.indexOf('dtlEstagios')>-1)
							{
								e.disabled = false;
							}								
						}
						else if(p_Tipo==1 && blnAllUnChecked == false)
						{
							/*
							O USUÁRIO CLICOU EM UMA FASE E E PELO MENO UMA FASE ESTÁ CHECKED
							*/
							if(strId.indexOf('dtlEstagios')>-1)
							{
								e.disabled = true;
								e.checked = false;
							}							
							
						}
						else if(p_Tipo==2 && blnAllUnChecked)
						{
							/*
							O USUÁRIO CLICOU EM UM ESTÁGIO E TODOS OS ESTÁGIOS ESTÃO UNCHECKED
							*/
							if(strId.indexOf('dtlFases')>-1)
							{
								e.disabled = false;
							}
							
						}
						else if(p_Tipo==2 && blnAllUnChecked == false)
						{
							/*
							O USUÁRIO CLICOU EM UM ESTÁGIO E PELO MENOS UM ESTÁGIO ESTÁ CHECKED
							*/							
							if(strId.indexOf('dtlFases')>-1)
							{
								e.disabled = true;
								e.checked = false;
							}
						}
					}
				}
			}
		
			function CA()
			{
				var trk=0;
				for (var i=0;i<frmCad.elements.length;i++)
					{
						var e = frmCad.elements[i];
						if ((e.name != 'allbox') && (e.type=='checkbox'))
							{
								e.checked = true;
							}
					}
			}
		
			function EE(IdObra, IdEmpresa, IdModalidade, NomeEmpresa)
			{
			
				if(confirm("Confirma Exclusão da Empresa\n" + NomeEmpresa.toUpperCase()))
				{
					var win = window.open('ObraExcluirEmpresa.aspx?IdObra=' + IdObra + '&IdEmpresa=' + IdEmpresa + '&IdModalidade=' + IdModalidade,'ExcluirEmpresa', 'width=300, height=100, top=100, left=100');
				}
			
			}		

		</script>
		<table height="450" cellSpacing="0" cellPadding="0" width="100%">
			<tr>
				<td vAlign="top" align="middle">
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
				<td vAlign="top" align="middle">
					<form id="frmCad" runat="server">
						<table align="center" id="tblTopo" width="96%" border="0" runat="server">
							<tr>
								<td align="middle">
									<IMG src="imagens/TituloPesquisaObras.jpg" border="0"><br>
									<asp:label id="lblMensagemTopo" Runat="server" CssClass="f8">SELECIONE TODOS OS ITENS DESEJADOS EM SUA PESQUISA E CLIQUE NO BOTÃO PESQUISAR.</asp:label><br>
									<asp:label id="lblMensagemTopo2" Runat="server" CssClass="f8">Caso não selecione nenhum critério, retornarão as obras disponíveis.</asp:label><br>
								</td>
							</tr>
						</table>
						<table id="tblSelecao" width="96%" border="0" runat="server">
							<tr>
								<td vAlign="top" width="33%">
									<table width="100%" bgColor="#003c6e" border="0">
										<tr>
											<td noWrap align="middle"><font class="f8" color="#ffffff"><b>ENTRE DATAS</b></font></td>
										</tr>
									</table>
									<table width="100%" border="0" bgcolor=#EFEFEF>
										<tr>
											<td noWrap align="left"><asp:label id="Label4" Runat="server" forecolor=#FF0000 CssClass="f8">Data Inicial</asp:label></td>
											<td align="left" width="100%"><asp:textbox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" TabIndex=1 id="txtDataInicio" Runat="server" CssClass="f8" size="15" MaxLength="10"></asp:textbox> <font class=f8>(ddmmaa)</font></td>
										</tr>
										<tr>
											<td noWrap align="left"><asp:label id="Label2" Runat="server" forecolor=#FF0000 CssClass="f8">Data Final</asp:label></td>
											<td align="left" width="100%"><asp:textbox id="txtDataFim" onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" TabIndex=2 Runat="server" CssClass="f8" size="15" MaxLength="10"></asp:textbox> <font class=f8>(ddmmaa)</font></td>
										</tr>
									</table>
									<br>
									<table width="100%" bgColor="#003c6e" border="0">
										<tr>
											<td noWrap align="middle"><font class="f8" color="#ffffff"><b>SELECIONE A FASE</b></font></td>
										</tr>
									</table>
									<asp:datalist id="dtlFases" TabIndex=3 runat="server" RepeatColumns=3 RepeatDirection=Horizontal  CssClass="f8" width="100%" GridLines="none" CellPadding="3" BackColor="#EFEFEF" BorderStyle=Outset BorderColor="#999999" DataKeyField="IdFase" BorderWidth="1">
										<ItemTemplate>
											<asp:CheckBox onClick="javascript:Ativa(1, this);"  runat=server Enabled='TRUE' Text='<%# DataBinder.Eval(Container.DataItem, "DESCRICAOFASE")%>' Checked='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, true, false)%>' ID="chkFases" />
										</ItemTemplate>
									</asp:datalist><br>
									<table width="100%" bgColor="#003c6e" border="0">
										<tr>
											<td noWrap align="middle"><font class="f8" color="#ffffff"><b>SELECIONE O ESTÁGIO</b></font></td>
										</tr>
									</table>
									<asp:datalist id="dtlEstagios" TabIndex=4 runat="server" CssClass="f8" width="100%" GridLines="none" CellSpacing=0 CellPadding=0  BackColor="#EFEFEF" BorderStyle=Outset BorderColor="#999999" DataKeyField="IdEstagio" BorderWidth="1">
										<ItemTemplate>
											<asp:CheckBox BackColor=#EFEFEF Name="chkEstagios" runat=server Enabled=true Text='<%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTAGIO")%>' Checked='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, true, false)%>' ID="chkEstagios" onClick="javascript:Ativa(2, this);" />
										</ItemTemplate>
									</asp:datalist></td>
								<td vAlign="top" width="67%" colspan=2>
									<table width="100%" bgColor="#003c6e" border="0">
										<tr>
											<td noWrap align="middle"><font class="f8" color="#ffffff"><b>SELECIONE O ESTADO</b></font></td>
										</tr>
									</table>
									<asp:datalist id="dtlEstados" TabIndex=5 ItemStyle-Width=33% runat="server" CssClass="f8" width="100%" RepeatColumns=3 RepeatDirection=Vertical GridLines="none" CellSpacing=0 CellPadding=0 BackColor="#EFEFEF" BorderStyle=Outset BorderColor="#999999" DataKeyField="IDESTADO" BorderWidth="1">
										<ItemTemplate>
											<asp:CheckBox name=chkEstados runat=server Enabled='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "Permitido")=0, false, true)%>' Text='<%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTADO")%>' Checked='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, true, false)%>' ID="chkEstados" />
										</ItemTemplate>
									</asp:datalist>
								<br>
								<table width="100%" bgColor="#003c6e" border="0">
									<tr>
										<td noWrap align="middle"><font class="f8" color="#ffffff"><b>SELECIONE O TIPO</b></font></td>
									</tr>
								</table>
									<asp:datalist TabIndex=6 BackColor=#EFEFEF ItemStyle-Width=50% id="dtlPesquisaTipos" runat="server" CssClass="f8" width="100%" RepeatColumns=2 RepeatDirection=Vertical GridLines="none" CellSpacing=0 CellPadding=0  BorderStyle=Outset BorderColor="#999999" DataKeyField="IdTipo" BorderWidth="1">
										<ItemTemplate>
											<asp:CheckBox BackColor=#EFEFEF name=chkTipos runat=server Enabled='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "Permitido")=0, false, true)%>' Text='<%# DataBinder.Eval(Container.DataItem, "DESCRICAOTIPO")%>' Checked='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, true, false)%>' ID="chkTipos" />
										</ItemTemplate>
									</asp:datalist>
									<br>
								</td>
							</tr>
							<tr>
								<td align="middle" width="100%" colSpan="3">&nbsp;
								</td>
							</tr>
							<tr>
								<td vAlign="top" width="100%" colSpan="3" align=center>
									<table borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="550" border="1">
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
															<table width="550" border="0" cellspacing=0>
																<tr>
																	<td noWrap width=10% align="right"><asp:label id="Label19" Runat="server" CssClass="f8" NAME="Label7">Código da Obra</asp:label></td>
																	<td align="left" ><asp:textbox TabIndex=7 id="txtCodigoObra" Runat="server" CssClass="f8" Width="200" MaxLength="50"></asp:textbox></td>
																	<td width=40% noWrap align="right"><asp:label id="Label12" Runat="server" CssClass="f8" NAME="Label7">Nome da Obra</asp:label></td>
																	<td align="left" ><asp:textbox id="txtNomeObra" TabIndex=8 Runat="server" CssClass="f8" Width="200" MaxLength="50"></asp:textbox></td>
																</tr>
																<tr>
																	<td align="right"><asp:label id="Label7" Runat="server" CssClass="f8" NAME="Label7">Endereço</asp:label></td>
																	<td align="left"><asp:textbox id="txtEndereco" TabIndex=9 Runat="server" CssClass="f8" Width="200" MaxLength="50"></asp:textbox></td>
																	<td nowrap align=right><asp:label id="Label18" Runat="server" CssClass="f8" NAME="Label7">Descrição da Obra</asp:label></td>
																	<td align="left"><asp:textbox id="txtDescricaoObra" TabIndex=10 Runat="server" CssClass="f8" Width="200" MaxLength="100"></asp:textbox></td>
																</tr>
																<tr>
																	<td align="right"><asp:label id="Label17" Runat="server" CssClass="f8" NAME="Label7">Bairro</asp:label></td>
																	<td align="left">
																		<asp:textbox id="txtBairro" Runat="server" TabIndex=11 CssClass="f8" Width="200" MaxLength="50"></asp:textbox>
																	</td>
																	<td align="right">
																		<asp:label id="Label8" Runat="server" CssClass="f8" NAME="Label7">Cidade</asp:label>
																	</td>
																	<td align="left">
																		<asp:textbox id="txtCidade" Runat="server" TabIndex=12 CssClass="f8" Width="200" MaxLength="50"></asp:textbox>
																	</td>
																</tr>
																<tr>
																	<td width=128 nowrap align=right><asp:label id="Label22" Runat="server" CssClass="f8" NAME="Label6">Cep Inicial&nbsp;</asp:label></td>
																	<td width=100% align=left><asp:textbox TabIndex=13 id="txtCepDe"  onkeydown="javascript:FormataCEP(this, event);" Runat="server" CssClass="f8" Width="70" MaxLength="9"></asp:textbox></td>
																	<td width=110 nowrap align=right><asp:label id="Label23" Runat="server" CssClass="f8" NAME="Label6">Término da Obra&nbsp;</asp:label></td>
																	<td width=100% align=left><asp:textbox TabIndex=15 id="txtTerminoObra" onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);" Runat="server" CssClass="f8" Width="70" MaxLength="10"></asp:textbox><font class=f8>(ddmmaa)</font></td>
																</tr>
																<tr>
																	<td width=128 nowrap align=right><asp:label id="Label21" Runat="server" CssClass="f8" NAME="Label6">Cep Final&nbsp;</asp:label></td>
																	<td width=100% align=left><asp:textbox TabIndex=14 id="txtCepAte" onkeydown="javascript:FormataCEP(this, event);" Runat="server" CssClass="f8" Width="70" MaxLength="9"></asp:textbox></td>
																	<td width=110 nowrap align=right><asp:label id="Label3" Runat="server" CssClass="f8" NAME="Label6">Início da Obra&nbsp;</asp:label></td>
																	<td width=100% align=left><asp:textbox TabIndex=16 id="txtInicioObra" onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);" Runat="server" CssClass="f8" Width="70" MaxLength="10"></asp:textbox><font class=f8>(ddmmaa)</font></td>
																</tr>
																<tr>
																	<td noWrap align="right"><asp:label id="Label15" Runat="server" CssClass="f8" NAME="Label6">Nº da Revisão</asp:label></td>
																	<td noWrap align="left">
																		<table>
																			<tr>
																				<td><uc1:combobox tabindex=17 id="cboChecagemNrRevisao" runat="server"></uc1:combobox></td>
																				<td><asp:textbox tabindex=18 id="txtNumeroRevisao" Runat="server" CssClass="f8" Width="70" MaxLength="9"></asp:textbox></td>
																			</tr>
																		</table>
																	</td>
																	<td align="right"><asp:label id="Label9" Runat="server" CssClass="f8" NAME="Label7">Pesquisador</asp:label></td>
																	<td align="left"><uc1:combobox tabindex=19 id="cboPesquisador" runat="server"></uc1:combobox></td>
																</tr>
																<tr>
																	<td noWrap align="right"><asp:label id="Label10" Runat="server" CssClass="f8" NAME="Label7">Área Construída (m&#178;)</asp:label></td>
																	<td align="left" nowrap>
																			<uc1:combobox tabindex=20 id="cboFatorAreaConstruida" runat="server"></uc1:combobox>
																			<asp:textbox tabindex=21 id="txtAreaConstruida" Runat="server" CssClass="f8" Width="120" MaxLength="50"></asp:textbox>
																	</td>
																	<td noWrap align="right"><asp:label id="Label11" Runat="server" CssClass="f8" NAME="Label7">Valor R$</asp:label></td>
																	<td noWrap align="left">
																		<uc1:combobox id="cboFatorValor" tabindex=22 runat="server"></uc1:combobox>
																		<asp:textbox id="txtValor" tabindex=23 Runat="server" CssClass="f8" Width="120" MaxLength="50"></asp:textbox>
																	</td>
																</tr>
																<tr>
																	<td noWrap align="right"><asp:label id="Label16" Runat="server" CssClass="f8" NAME="Label7">Empresa Participante</asp:label></td>
																	<td align="left"><asp:textbox tabindex=24 id="txtEmpresaParticipante" Runat="server" CssClass="f8" Width="200" MaxLength="100"></asp:textbox></td>
																	<td noWrap align="right"><asp:label id="Label20" Runat="server" CssClass="f8" NAME="Label7">Modalidade</asp:label></td>
																	<td align="left"><uc1:combobox tabindex=25 id="cboIdMolidade" runat="server"></uc1:combobox></td>
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
									<table bgcolor=#EFEFEF borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="550" border="1">
										<tr>
											<td noWrap align="middle">

												<table borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td>
															<table width="100%" bgcolor=#EFEFEF ><!-- bgColor="#f7f7d8"-->
																<tr>
																	<td noWrap width="33%">
																		<asp:label id="Label5" Runat="server" CssClass="f8">ORDENAR POR:</asp:label>&nbsp;
																		<uc1:combobox id="cboOrdenar" tabindex=31 runat="server" CssClass="f8"></uc1:combobox>
																	</td>
																	<td noWrap width="33%">
																		<asp:label id="Label6" Runat="server" CssClass="f8">MOSTRAR:</asp:label>&nbsp;
																		<uc1:combobox id="cboMostrar" tabindex=32 EnableValidation="false" runat="server" CssClass="f8"></uc1:combobox>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
												<table borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td>
															<table width="100%" bgColor="#EFEFEF">
																<tr>
																	<td align="middle" width="33%"><asp:imagebutton TabIndex=28 id="btnNovaPesquisa" Runat="server" CssClass="f8"  ImageUrl="imagens/botaonovapesquisa.gif" BorderStyle="None"></asp:imagebutton></td>
																	<td align="middle" width="33%"><asp:imagebutton TabIndex=29 id="btnPesquisar" Runat="server" CssClass="f8"  ImageUrl="imagens/botaopesquisar.gif" BorderStyle="None"></asp:imagebutton></td>
																	<td align="middle" width="34%"><a href="javascript:XM_GOTO('default.aspx');"><img src = 'imagens/botaohome.gif' Class="f8"  Border="0"></a></td>
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
						<table id="tblResultados" width="96%" runat="server">
							<tr>
								<td width="100%" colSpan="2">
									<uc1:BarraNavegacao id="Barranavegacao2" runat="server"></uc1:BarraNavegacao>
									<asp:datagrid id="dtgResultados" runat="server" CssClass="f9" width="96%" AutoGenerateColumns="False" GridLines="none" CellPadding="3" BackColor="White" BorderColor="#999999" DataKeyField="CODIGO" BorderWidth="1" HorizontalAlign="Center" AllowPaging=True PageSize="50" AllowSorting="True">
										<HeaderStyle BackColor="#003C6E" ForeColor="#FFFFFF"></HeaderStyle>
										<Columns>
											<asp:TemplateColumn ItemStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Name="verdana" ItemStyle-Font-Size="10" HeaderStyle-Width="1%" HeaderText='<input type="button" onclick="javascript:CA();" class="f8" value="Todos" id=btnMarcarTodos NAME="btnMarcarTodos">'>
												<ItemTemplate>
													<input type=checkbox ID="chkItemResultado" value="<%# DataBinder.Eval(Container.DataItem, "CODIGO")%>">
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderStyle-Width="10%" HeaderText="<B>CÓDIGO ITC</B>">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "CODIGOANTIGO")%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderStyle-Width="30%" HeaderText="<B>NOME DA OBRA</B>">
												<ItemTemplate>
													<b><%# DataBinder.Eval(Container.DataItem, "PROJETO")%></b>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderStyle-Width="30%" HeaderText="<B>ENDEREÇO</B>">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "ENDERECO")%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderStyle-Width="30%" HeaderText="<B>NOME FANTASIA DA EMPRESA</B>">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "FANTASIA")%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="<B>CIDADE</B>">
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "CIDADE")%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderStyle-Width="10" HeaderText="" HeaderStyle-Wrap=False>
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "CODIGO")%>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle  Visible=False HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
									<uc1:BarraNavegacao id="BarraNavegacao1" runat="server"></uc1:BarraNavegacao>
									<br>
									<script language=javascript>
										
										function XM_ITC_GetIds(){
											var valores;
											valores = '';
											
											for (var i=0;i<frmCad.elements.length;i++)
												{
													var e = frmCad.elements[i];
													if ((e.name != 'allbox') && (e.type=='checkbox'))
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
										
										function XM_ITC_Exportar(){
											var valores = XM_ITC_GetIds();
											if(valores != ''){
												var win = window.open('relatorioobraexportar.aspx?o=' + valores , 'ITCNET_EXPORTAR_OBRAS', 'height=200, width=200, top=10, left=10');
											}
										}
										
										function XM_ITC_Pesquisar(){
											var valores = XM_ITC_GetIds();
											var t;
											t = 1;
											for (var i=0;i<frmCad.elements.length;i++)
											{
												var e = frmCad.elements[i];
												if ((e.type=='radio' && e.name == 'TipoRelatorio' && e.checked == true))
												{
													t = e.value;
												}
											}
											if(valores != ''){
												window.open('relatorioobras.aspx?dt=<%=Now()%>&o=' + valores + '&t=' + t , 'ITCNET_PESQUISAR_OBRAS', 'height=600, width=800, top=10, left=10, toolbar=yes, scrollbars=yes, resizable=yes');
											}
										}
										
										function XM_ITC_Resumo(){
											var valores = XM_ITC_GetIds();
											if(valores != ''){
												window.open('relatorioobrasresumo.aspx?dt=<%=Now()%>&o=' + valores , 'ITCNET_RESUMO_OBRAS', 'height=600, width=800, top=10, left=10, toolbar=yes, scrollbars=yes, resizable=yes');
											}
										}
										
									</script>
									<table id="tblBotoesResultados" borderColor="#003c6e" cellSpacing="0" cellPadding="0" width="80%" align="center" border="1" runat="server">
										<tr>
											<td>
												<table width="100%" align="center" bgColor="#f7f7d8">
													<tr>
														<td align="middle" width="33%"><asp:imagebutton id="btnNovaPesquisa2" Runat="server" CssClass="f8"  ImageUrl="imagens/botaonovapesquisa.gif" BorderStyle="None"></asp:imagebutton></td>
														<td align="middle" width="33%"><asp:image id="btnImprimirResumo" style="cursor: hand;" Runat="server" CssClass="f8"  ImageUrl="imagens/botaovisualizarpesquisa.gif" BorderStyle="None"></asp:image></td>
														<td align="middle" width="34%"><a href="javascript:XM_GOTO('default.aspx');"><img src = 'imagens/botaohome.gif' Class="f8"  Border="0"></a></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<br>
								</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
		</table>
		<uc1:Rodape id="Rodapé1" runat="server"></uc1:Rodape>
	</body>
</HTML>