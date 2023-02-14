<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PesquisaEmpresas.aspx.vb"  ValidateRequest="False" Inherits="ITC.PesquisaEmpresas"%>
<%@ Register TagPrefix="uc1" TagName="BarraNavegacao" Src="Inc/BarraNavegacao.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
  <HEAD>
	<!-- #include file='inc/header.aspx' -->
	<script language="javascript">
	
		function getForm()
		{
			var theform;
			if (window.navigator.appName.toLowerCase().indexOf("microsoft") > -1) {
				theform = document.frmCad;
			}
			else {
				theform = document.forms["frmCad"];
			}

			return theform;

		}
	
		function setCheckedItens()
			{
			
				getForm().hdAtividades.value = '';
				getForm().hdEstados.value = '';
								
				for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
					var strId = e.id;
					if (e.type=='checkbox' && strId.indexOf('chkAtividade')>-1)
					{
							if(e.checked == true)
								getForm().hdAtividades.value += e.value  + ',';
							
					}
				}
											
				for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
					var strId = e.id;
					if (e.type=='checkbox' && strId.indexOf('chkEstado')>-1)
					{
							if(e.checked == true)
								getForm().hdEstados.value += e.value  + ',';
							
					}
				}
																
			}
				
		function CA(p_Obj)
		{
			for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
					if ((e.name != 'allbox') && (e.type=='checkbox'))
						{
							e.checked = p_Obj.checked;
						}
				}
		}
		
		function CO(p_Obj, a)
		{
		
			var objeto = p_Obj;
			for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
					var f = e.name;
					if(f != undefined)
					{
						if ((f.indexOf(objeto) != -1) && (e.type=='checkbox'))
							{
								e.checked = a.checked;
							}
					}
				}
		}
		

/*		function CP(a, b, c, d, u, j)
		{
			for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
					var f = e.name;
					if(f != undefined)
					{
						if (((f.indexOf(a) != -1) || (f.indexOf(b) != -1) || (f.indexOf(c) != -1) || (f.indexOf(d) != -1) || (f.indexOf(u) != -1)) && (e.type=='checkbox'))
							{
								e.checked = j.checked;
							}
					}
				}
		}
*/

		function CP(a, j)
		{
		
			var p_itens = a.split(',');
						
			for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
					var f = e.id
					if(f != undefined)
					{
						if(e.type=='checkbox')
						{
							//alert(f + ' - ' + a);
							for(var it = 0; it < p_itens.length; it++)
							{
								var chk = p_itens[it];
								//alert(chk);
								//return;
								if (f.indexOf(chk) != -1)
								{
									e.checked = j.checked;
								}
							}
						}
					}
				}
		}
						
		function CCA(CB){
		if (CB.checked)
		hL(CB);
		else
		dL(CB);
		var TB=TO=0;
		for (var i=0;i<getForm().elements.length;i++)
		{
		var e = getForm().elements[i];
		if ((e.name != 'allbox') && (e.type=='checkbox'))
		{
		TB++;
		if (e.checked)
		TO++;
		}
		}
		if ((folderID == "F000000005") && (ie))
		{
		if (TO > 1)
		document.all.notbulkmail.disabled = true;
		else
		document.all.notbulkmail.disabled = false;
		if (document.all.nullbulkmail)
		document.all.nullbulkmail.disabled = document.all.notbulkmail.disabled;
		}
		if (TO==TB)
		getForm().allbox.checked=true;
		else
		getForm().allbox.checked=false;
		}

									
		function XM_ITC_GetIds(){
			var valores;
			valores = '';
			
			for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
					if (e.name != 'allbox' && e.id != 'btnMarcarTodos' && e.type=='checkbox')
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
		
		
		function XM_ITC_GetOrdem(){
			var valor;
			valor = '';
			
			var t;
			t = '';
					
			t=document.getElementById('hddOrdem');
			valor = t.value;
			
			return valor;
			}
		
					
		function XM_ITC_Exportar(){
			var valores = XM_ITC_GetIds();
			if(valores != ''){
				var win = window.open('relatorioempexportar.aspx?o=' + valores , 'ITCNET_EXPORTAR_OBRAS', 'height=200, width=200, top=10, left=10, toolbar=yes, scrollbars=yes, resizable=yes');
			}
		}
		
		function XM_ITC_Pesquisar(){
			var valores = XM_ITC_GetIds();
			var ordem = XM_ITC_GetOrdem();
			var t;
			t = 1;
			for (var i=0;i<getForm().elements.length;i++)
			{
				var e = getForm().elements[i];
				if ((e.type=='radio' && e.name == 'TipoRelatorio' && e.checked == true))
				{
					t = e.value;
				}
			}
			if(valores != ''){
				window.open('relatorioempresas.aspx?auth=' + document.getElementById('hidAuth').value + '&o=' + valores + '&t=' + t + '&q=' + ordem, 'ITCNET_PESQUISAR_OBRAS', 'height=600, width=800, top=10, left=10, toolbar=yes, scrollbars=yes, resizable=yes');
			}
		}
		
		function XM_ITC_GetLink(){
				if(confirm('Confirma o envio do link ?')==false)return false;
				var valores = XM_ITC_GetIds();
				var t;
				t = 1;
				var ordem = XM_ITC_GetOrdem();
				for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
					if ((e.type=='radio' && e.name == 'TipoRelatorio' && e.checked == true))
					{
						t = e.value;
					}
				}
				
				if(valores != '')
				{
					getForm().hidLink.value = 'relatorioempresas.aspx?dt=<%=Now()%>&o=' + valores + '&t=' + t + '&q=' + ordem;
					return true;
				}
				
				alert('Seleção das obras é obrigatório.');
				
				return false;
			}

		function xmRefresh() {

            <% =getPostBack() %>

        }
            				
	</script>
	</HEAD>
	<body onload="vertical();horizontal();" >
		<form id="frmCad" runat="server">
			<input type="hidden" id="hdAtividades" name="hdAtividades" runat="Server">
			<input type="hidden" id="hdEstados" name="hdEstados" runat="Server">
			<div id=Tudo runat=server>
			
				<div id="Topo" runat="server">
					<uc1:Top id="Top1" runat="server"></uc1:Top>
								
								
					<table id="tblSalvar" runat="server" width=100%>
						<tr>
							<td width="100%">
								<h3>Salvando Pesquisa</h3>
							</td>
						</tr>
						<tr>
							<td>
								<label>Digite o nome que você deseja para sua pesquisa</label>
							</td>
						</tr>
						<tr>
							<td Align="center">
								<asp:TextBox AUTOCOMPLETE="off" CssClass="f8" runat="server" Width="90%" ID="txtNome" MaxLength="50"></asp:TextBox>
								<br>
								<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator1" Runat="server" ErrorMessage="O nome da pesquisa é obrigatório" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
							</td>
						</tr>
						<tr>
							<td>
								<asp:Button CssClass="f8" Runat="server" ID="btnSalvarAgora" Text="Salvar Pesquisa" CausesValidation="True"></asp:Button>
							</td>
						</tr>
						<tr bgcolor=#ffffff>
							<td>
								&nbsp;
							</td>
						</tr>
					</table>
					
					<div id=PesquisaEmpresas runat=server>				
						<h3>Pesquisa de Empresas</h3>
						<br />
						<p>
							<asp:Label ID="lblMensagemTopo" Runat="server" Font-Size="8" Font-Name="verdana"><b>Selecione todos os itens desejados em sua pesquisa e clique no botão PESQUISAR.</b> <BR>Caso não selecione nenhum critério, retornarão as empresas disponíveis.</asp:Label>
						</p>
					</div>

					<br class="clear" />
				</div>
				
				<div id="Selecao" runat=server>
					<h3>Entre Datas</h3>
					<fieldset>
						<legend>Datas</legend>
		            
						<div style="float:left">
                			<label>Data Inicial</label>
							<asp:textbox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" id="txtDataInicial" Runat="server" CssClass="inputG" Width="70" MaxLength="10" onfocus="displayCalendar(document.forms[0].txtDataInicial,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataInicial,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataInicial,'dd/mm/yyyy',this)" style="cursor:pointer;" ></asp:textbox>
							<br />
               			</div>
               			
               			<div>
							<label>Data Final</label>
							<asp:textbox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" id="txtDataFinal" Runat="server" CssClass="inputG" Width="70" MaxLength="10" onfocus="displayCalendar(document.forms[0].txtDataFinal,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataFinal,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataFinal,'dd/mm/yyyy',this)" style="cursor:pointer;" ></asp:textbox>
							<br />
               			</div>
               			
					</fieldset>
					<br />
					
					<h3>Regiões do Brasil <input type=checkbox id=regTodas name=regTodas onclick='javascript:CP("chkEstadosNr,chkEstadosSd,chkEstadosSl,chkEstadosNo,chkEstadosCo", this);'/></h3>
					
					<fieldset>
						<h3><input type=checkbox id=nrTodos name=nrTodos onclick='javascript:CP("chkEstadosNr", this);'/> Nordeste</h3>
						<asp:DataList CssClass="f8" DataKeyField="IDESTADO" id="dtlEstadosNr" runat="server" CellPadding="0" GridLines="none" width="100%"  RepeatColumns="3" RepeatDirection=Vertical>
							<ItemTemplate>
								<label><%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTADO")%></label><input type=checkbox <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMITIDO")=1, "", "disabled='disabled'")%> <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> ID='chkEstadosNr' value="<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>" onClick="javascript:Ativa(2, this, 'chkEstadosNr');" />
							</ItemTemplate>
						</asp:DataList>
					</fieldset>
	
					<h3><input type=checkbox id=sdTodos name=sdTodos onclick='javascript:CP("chkEstadosSd", this);'/> Sudeste</h3>
					<fieldset>
						<asp:DataList DataKeyField="IDESTADO" id="dtlEstadosSd" runat="server" GridLines="none" width="100%" RepeatColumns="3" RepeatDirection='Vertical'>
							<ItemTemplate>
								<label><%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTADO")%></label><input type=checkbox <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMITIDO")=1, "", "disabled='disabled'")%> <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> ID='chkEstadosSd' value="<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>" onClick="javascript:Ativa(2, this, 'chkEstadosSd');" />
							</ItemTemplate>
						</asp:DataList>
					</fieldset>

					<fieldset>
						<h3><input type=checkbox id=slTodos name=slTodos onclick='javascript:CP("chkEstadosSl", this);'/> Sul</h3>
						<asp:DataList CssClass="f8" DataKeyField="IDESTADO" id="dtlEstadosSl" runat="server" CellPadding="0" GridLines="none" width="100%" RepeatColumns="3" RepeatDirection=Vertical>
							<ItemTemplate>
								<label><%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTADO")%></label><input type=checkbox <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMITIDO")=1, "", "disabled='disabled'")%> <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> ID='chkEstadosSl' value="<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>" onClick="javascript:Ativa(2, this, 'chkEstadosSl');" />
							</ItemTemplate>
						</asp:DataList>
					</fieldset>
				
					<fieldset>
						<h3><input type=checkbox id=noTodos name=noTodos onclick='javascript:CP("chkEstadosNo", this);'/> Norte</h3>
						<asp:DataList CssClass="f8" DataKeyField="IDESTADO" id="dtlEstadosNo" runat="server" CellPadding="0" GridLines="none" width="100%" RepeatColumns="3" RepeatDirection=vertical>
							<ItemTemplate>
								<label><%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTADO")%></label><input type=checkbox <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMITIDO")=1, "", "disabled='disabled'")%> <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> ID='chkEstadosNo' value="<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>" onClick="javascript:Ativa(2, this, 'chkEstadosNo');" />
							</ItemTemplate>
						</asp:DataList>
					</fieldset>
					
					<fieldset>
						<h3><input type=checkbox id=coTodos name=coTodos onclick='javascript:CP("chkEstadosCo", this);'/> Centro-Oeste</h3>
						<asp:DataList DataKeyField="IDESTADO" id="dtlEstadosCo" runat="server" CellPadding="0" GridLines="none" width="100%" RepeatColumns="3" RepeatDirection=Vertical>
							<ItemTemplate>
								<label><%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTADO")%></label><input type=checkbox <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMITIDO")=1, "", "disabled='disabled'")%> <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> ID='chkEstadosCo' value="<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>" onClick="javascript:Ativa(2, this, 'chkEstadosCo');" />
							</ItemTemplate>
						</asp:DataList>
					</fieldset>
					<br />
					
					<h3>Segmentos de Atuação</h3>
					<fieldset>
						<legend>Atividades</legend>
		            
						<asp:DataList Width='100%' ItemStyle-Width="30%" cssclass="f8" id="dtlAtividades" DataKeyField="IdAtividade" runat="server" GridLines="None" CellSpacing="0" CellPadding="0" RepeatColumns="3"  RepeatDirection=Horizontal>
							<ItemTemplate>
								<label><%# DataBinder.Eval(Container.DataItem, "DESCRICAOATIVIDADE")%></label><input type=checkbox <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> ID='chkAtividades<%# DataBinder.Eval(Container.DataItem, "IDATIVIDADE")%>' value="<%# DataBinder.Eval(Container.DataItem, "IDATIVIDADE")%>" onClick="javascript:Ativa(2, this, 'chkAtividades');" />
							</ItemTemplate>
						</asp:DataList>
					</fieldset>
					<br />
					
					<h3>Filtros especificos</h3>
					<fieldset>
						<legend>Filtros especificos</legend>
						
						<div style="float:left;"> 	
							<label>Nome Fantasia</label>
							<asp:TextBox CssClass="f8" ID="txtFantasia" MaxLength="50" Width="200" Runat="server"></asp:TextBox>
							<br />
						</div>

						<div style="float:left;"> 
							<label>Razão Social</label>
							<asp:TextBox CssClass="f8" ID="txtRazaoSocial" MaxLength="50" Width="200" Runat="server"></asp:TextBox>&nbsp;&nbsp;
						</div>
						<br />
						<br />
						
			            <div style="float:left;"> 	
							<label>Endereço</label>
							<asp:TextBox Runat="server" Width="200" MaxLength="50" ID="txtEndereco" CssClass="f8"></asp:TextBox>
							<br />
						</div>

						<div style="float:left;"> 
							<label>Bairro</label>
							<asp:TextBox Runat="server" Width="200" MaxLength="50" ID="txtBairro" CssClass="f8"></asp:TextBox>
						</div>
						<br />
						<br />
						
						<div style="float:left;width:343px;"> 	
							<label>Estado</label>
							<uc1:ComboBox CssClass="f8" AutoPostBack="true" id="cboIdEstado" runat="server"></uc1:ComboBox>
							<br />
						</div>

						<div style="float:left;"> 
               				<label>Cidade</label>
               				<uc1:ComboBox CssClass="f8" id="cboCidade" runat="server"></uc1:ComboBox>
						</div>
						<br />
						<br />
						
						<div style="float:left;width:343px;"> 	
							<label>CEP Inicial</label>
							<asp:TextBox Runat="server" Width="70" MaxLength="9" ID="txtCepDe" onKeyDown="javascript:FormataCEP(this, event);" CssClass="f8"></asp:TextBox>
							<br />
						</div>

						<div style="float:left;"> 
                			<label>CEP Final</label>
							<asp:TextBox Runat="server" Width="70" MaxLength="9" ID="txtCepAte" onKeyDown="javascript:FormataCEP(this, event);" CssClass="f8"></asp:TextBox>
						</div>
						<br />
						<br />
	            
						<div style="float:left;">    
                			<label>CNPJ</label>
							<asp:TextBox Runat="server" onKeyDown="javascript:FormataCNPJ(this, event);" Width="120" MaxLength="18" ID="txtCNPJ" CssClass="f8"></asp:TextBox>
							<br />
						</div><br /><br />
			            
               			<div style="float:left;"> 	
							<label>Site WEB</label>
							<asp:TextBox Runat="server" Width="200" MaxLength="50" ID="txtSite" CssClass="f8"></asp:TextBox>
							<br />
						</div>

						<div style="float:left;"> 
							<label>E-Mail</label>
							<asp:TextBox Runat="server" Width="200" MaxLength="50" ID="txtEMail" CssClass="f8"></asp:TextBox>
						</div>
						<br />					
						<br />
						
						<div style="float:left;"> 
							<label>Ordenação</label>
							<uc1:ComboBox id="cboOrdenar" runat="server" name='cboOrdenar'></uc1:ComboBox>
                            <br />
                        </div>
								
                        <div style="float:left;"> 
						    <label style="text-align: left; padding-left: 9px; width: 103px;">Status atual do SIG</label>
						    <uc1:combobox id="cboStatusSIG" runat="server"></uc1:combobox>
					    </div>
					</fieldset>

					<br />	
					
					<h3>Pesquisas Salvas</h3>
					<fieldset>
						<legend>Filtros especificos</legend>
						
						<div> 
							<uc1:ComboBox id="cboPesquisasSalvas" runat="server"></uc1:ComboBox>
						</div>
						
						<br />
							
						<table width="100%">
							<tr>
								<td width=25%>
									<asp:Button CssClass="F8" Runat="server" ID="btnExcluirPesquisa" Text="Excluir Pesquisa"></asp:Button>
								</td>
								<td width=25%>
									<asp:Button ID="btnSalvarPesquisa" Runat="server" CssClass="f8" Text="Salvar Pesquisa"></asp:Button>
								</td>
								<td width=25%>
									<asp:Button Runat="server" ID="btnNovaPesquisa" Text="Nova Pesquisa" CssClass="f8"></asp:Button>
								</td>
								<td width=25%>
									<asp:Button ID="btnPesquisar" Runat="server" CssClass="f8" Text="Pesquisar"></asp:Button>
								</td>
							</tr>
						</table>

					</fieldset>
					
				</div>

								
				<table width="100%" runat="server" id="tblResultados">
					<tr>
						<td width="100%" colspan="5">
							<input type="hidden" id="hidLink" value="" runat="server" NAME="hidLink"/>
							<input type="hidden" id="hidAuth" value="" runat="server" NAME="hidAuth"/>
							<asp:Literal Runat="server" Text="" ID="ltScript"></asp:Literal>
							<uc1:BarraNavegacao id="Barranavegacao2" runat="server"></uc1:BarraNavegacao>
							<asp:DataGrid CssClass="f9" DataKeyField="Codigo" id="dtgProdutos" AllowSorting="True" PageSize="50" AllowPaging=True runat="server" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
								<HeaderStyle Font-Bold=True BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderStyle-HorizontalAlign="left" HeaderStyle-Width="1%" HeaderText='<input type="checkbox" onclick="javascript:CA(this);" class="f8" value="Todos" id=btnMarcarTodos NAME="btnMarcarTodos">'>
										<ItemTemplate>
											<input type=checkbox ID="chkItemResultado" value="<%# DataBinder.Eval(Container.DataItem, "CODIGO")%>">
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="30%" HeaderText="Razão Social">
										<ItemTemplate>
											<font Color="#000000">
												<b><%# DataBinder.Eval(Container.DataItem, "RAZAOSOCIAL")%></b>
											</font>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="19%" HeaderText="Nome Fantasia">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "FANTASIA")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="30%" HeaderText="Endereço">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "ENDERECO")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="7%" HeaderText="Estado">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "UF")%>
										</ItemTemplate>
									</asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderStyle-Width="16%" HeaderText="SIG Status Atual">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "STATUSSIG")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="1" HeaderText="" HeaderStyle-Wrap=False>
										<ItemTemplate>
											<a href='#' target:"_blank" onclick="window.open('followupempresadetmini.aspx?idempresa=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "CODIGO"))%>', 'Pagina', 'STATUS=NO, TOOLBAR=NO, LOCATION=NO, DIRECTORIES=NO, RESISABLE=NO, SCROLLBARS=YES, TOP=10, LEFT=10, WIDTH=775, HEIGHT=355');"><img src='imagens/arrow-right.gif' border=0 alt="Adicionar/Editar Follow-UP de <%# DataBinder.Eval(Container.DataItem, "FANTASIA")%>"></a>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
									<PagerStyle  Visible=False HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
							<br>
							<uc1:BarraNavegacao id="BarraNavegacao1" runat="server"></uc1:BarraNavegacao>
							<input type=hidden id='hddOrdem' name='hddOrdem' runat=server />
						</td>
					</tr>
					<tr>
						<td width=20% align=center>
							<asp:Button Runat="server" ID="btnNovaPesquisa2" Text="Nova Pesquisa" CssClass="f8"></asp:Button>
						</td>
						<td width=20%  align=center>
							<input type=button ID="btnImprimir" Value="Visualizar Pesquisa" Class="f8" onclick='javascript:XM_ITC_Pesquisar();'/>
						</td>
						<td width=20% align=center>
							<asp:button id="btnGravarLink" Runat="server" CssClass="f8" Text="Enviar Link"></asp:button>
						</td>
						<td width=20% align=center>
							<input type="button" ID="btnExportar" Runat="server" Class="f8" value="Exportar Pesquisa" />
						</td>
                        <td width=20% align=center>
                            <input type="button" ID="btnTeste" Runat="server" Class="f8" Value="Atualizar página" />
                        </td>
					</tr>
					<tr>
						<td nowrap align="right"><font class="f8"><b>Tipo de Relatório: </b></font>
						</td>
						<td width="50%" align="left">
							<font class=f8>Relatório Sequencial</font>
							<input type=radio id=TipoRelatorio name=TipoRelatorio value=1 checked>
                        </td>
                        <td width="50%" align="left" colspan="4">
							<font class=f8>Um Resultado por Página</font>	
							<input type=radio id=TipoRelatorio name=TipoRelatorio value=2 >
						</td>
					</tr>
					<tr>
						<td noWrap align="right"><font class="f8"><b>Forma de envio do link: </b></font>
						</td>
						<td align="left" width="50%">
							<font class=f8>MS. Outlook / outros</font>
							<input type=radio id=rdFormaEnvioLinkOut runat="server" name=FormaEnvioLink value=1 checked>
						</td>
						<td align="left" width="50%">
							<font class=f8>Lotus Notes</font>	
							<input type=radio id=rdFormaEnvioLinkLot runat="server" name=FormaEnvioLink value=2 >
						</td>
					</tr>
				</table>

				<br class=clear />
				
				<uc1:Rodape id="Rodapé1" runat="server"></uc1:Rodape>
			</div>
		</form>
	</body>
</HTML>
