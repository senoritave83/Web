<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PesquisaObraD.aspx.vb" Inherits="ITC.PesquisaObraD"%>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/TopDemo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraNavegacao" Src="Inc/BarraNavegacao.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
  <HEAD>
		<!-- #include file='inc/headerdemo.aspx' -->
		<script language="javascript">
		
			function setLoadedItens(p_Name, p_Object)
			{
					
				var blnChecked = true;
													
				for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
					var strId = e.id;
					
					if (
							e.type=='checkbox' && 
							strId.indexOf(p_Name)>-1 && 
							Right(strId, 2) != '_0'
						)
					{
						if(e.checked == false)
						{
							blnChecked = false;
							break;
						}
					}
				}
				document.getElementById(p_Object).checked = blnChecked;
			
			}
			
			function setItens()
			{

        		setLoadedItens('chkSegmentoTipo_1', 'chkSegmentoTipo_1_0');
        		setLoadedItens('chkSegmentoTipo_2', 'chkSegmentoTipo_2_0');
        		setLoadedItens('chkSegmentoTipo_3', 'chkSegmentoTipo_3_0');
        		
        		setLoadedItens('chkEstadosNr_', 'nrTodos');
        		setLoadedItens('chkEstadosSd_', 'sdTodos');
        		setLoadedItens('chkEstadosSl_', 'slTodos');
        		setLoadedItens('chkEstadosNo_', 'noTodos');
        		setLoadedItens('chkEstadosCo_', 'coTodos');

				document.getElementById('regTodas').checked = (
															document.getElementById('nrTodos').checked	&&
															document.getElementById('noTodos').checked	&&
															document.getElementById('coTodos').checked	&&
															document.getElementById('slTodos').checked	&&
															document.getElementById('sdTodos').checked	
													  )
			}
			
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
						
				getForm().hdFases.value = '';
				getForm().hdEstagios.value = '';
				getForm().hdEstados.value = '';
				getForm().hdTipos.value = '';
				
				if(document.getElementById('chkFasesEstagios_1_0').checked == true)
					getForm().hdFases.value += '1';
				if(document.getElementById('chkFasesEstagios_2_0').checked == true)
					getForm().hdFases.value += ',2';
				if(document.getElementById('chkFasesEstagios_3_0').checked == true)
					getForm().hdFases.value += ',3';
				
				for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
					var strId = e.id;
					if (e.type=='checkbox' && strId.indexOf('chkFases')>-1)
					{
							if(e.checked == true && getCheckBoxValue(e,2) > 0 && e.disabled ==false)
								getForm().hdEstagios.value += e.value  + ',';
							
					}
				}
				
				for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
					var strId = e.id;
					if (e.type=='checkbox' && strId.indexOf('chkSegmento')>-1)
					{
							if(e.checked == true && getCheckBoxValue(e,2) > 0 && e.disabled ==false)
								getForm().hdTipos.value += e.value  + ',';
							
					}
				}
				
				for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
					var strId = e.id;
					if (e.type=='checkbox' && strId.indexOf('chkEstados')>-1)
					{
							if(e.checked == true && e.disabled ==false)
							{
								getForm().hdEstados.value += e.value  + ',';
							}
					}
				}
												
			}
		
			function getCheckBoxValue(p_Item, p_Index)
			{
			
				
				var p_checkItem = p_Item.id;
				var p_colItemId = p_checkItem.split("_");
				return p_colItemId[p_Index];
			
			}
		
			function Ativa(p_Tipo, p_Check, p_Name)
			{
				/*
				
				OBETIVO:	ROTINA QUE HABILITA OU DESABILITA OS CHECKBOX DO FASES E ESTÁGIOS
							QUANDO É TIRADO O CHECK DE UM DELES TODOS DEVEM ESTAR HABILITADOS
							QUANDO É COLOCADO O CHECK EM UM DELES O OUTRO DEVE SER DESABILITADO
				AUTOR:		MARCELO R. M. SOUZA
				
				ALTERAÇÃO:	14/07/2009 - MARCELO R. M. SOUZA
				
				*/
				
				var blnChecked = p_Check.checked;
				var blnAllUnChecked = true;
				var p_IdFase = getCheckBoxValue(p_Check, 1);
				var p_IdEstagio = getCheckBoxValue(p_Check, 2);
								
				for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
					var strId = e.id;
					if (e.type=='checkbox' && strId.indexOf(p_Name)>-1)
					{
							if(p_IdEstagio == 0 && getCheckBoxValue(e, 1) == p_IdFase && getCheckBoxValue(e,2) > 0 )
								e.checked = blnChecked;
							
					}
				}				
				
				var blnEnable;
				
				for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
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
		
		/*function CP(a, b, c, d, u, j)
		{
		
			alert(a);
			alert(b);
			alert(c);
			alert(d);
			alert(u);
			alert(j);
	
			for (var i=0;i<getForm().elements.length;i++)
				{
					var e = getForm().elements[i];
					var f = e.id
					if(f != undefined)
					{
						if(e.type=='checkbox')
						{
							//alert(f + ' - ' + a);
							if (
								(f.indexOf(a) != -1) || 
								(f.indexOf(b) != -1) || 
								(f.indexOf(c) != -1) || 
								(f.indexOf(d) != -1) || 
								(f.indexOf(u) != -1)
							   )
								{
									e.checked = j.checked;
								}
						}
					}
				}
		}*/
		
			function EE(IdObra, IdEmpresa, IdModalidade, NomeEmpresa)
			{
			
				if(confirm("Confirma Exclusão da Empresa\n" + NomeEmpresa.toUpperCase()))
				{
					var win = window.open('ObraExcluirEmpresa.aspx?IdObra=' + IdObra + '&IdEmpresa=' + IdEmpresa + '&IdModalidade=' + IdModalidade,'ExcluirEmpresa', 'width=300, height=100, top=100, left=100');
				}
			
			}		

										
			function XM_ITC_GetIds(){
				var valores;
				valores = '';
				
				for (var i=0;i<getForm().elements.length;i++)
					{
						var e = getForm().elements[i];
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
			
			function XM_ITC_Exportar(){
				var valores = XM_ITC_GetIds();
				if(valores == '')
				{
					alert('Selecione as obras desejadas antes de clicar em EXPORTAR');
					return false;
				}
				var win = window.open('relatorioobraexportar.aspx?o=' + valores , 'ITCNET_EXPORTAR_OBRAS', 'height=200, width=200, top=10, left=10');
			}
			
			function XM_ITC_Pesquisar(){
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
				if(valores == '')
				{
					alert('Selecione as obras desejadas antes de clicar em VISUALIZAR PESQUISA');
					return false;
				}
				window.open('relatorioobrasd.aspx?auth=' + document.getElementById('hidAuth').value + '&dt=<%=Now()%>&o=' + valores + '&t=' + t + '&q=' + ordem, 'ITCNET_PESQUISAR_OBRAS', 'height=600, width=800, top=10, left=10, toolbar=yes, scrollbars=yes, resizable=yes');
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
					getForm().hidLink.value = 'relatorioobrasd.aspx?dt=<%=Now()%>&o=' + valores + '&t=' + t + '&q=' + ordem;
					return true;
				}
				
				alert('Seleção das obras é obrigatório.');
				
				return false;
			}
			
			function XM_ITC_Resumo(){
				var valores = XM_ITC_GetIds();
				var ordem = XM_ITC_GetOrdem();
				
				if(valores == '')
				{
					alert('Selecione as obras desejadas antes de clicar em VISUALIZAR RESUMO');
					return false;
				}
				window.open('relatorioobrasresumod.aspx?dt=<%=Now()%>&o=' + valores + '&q=' + ordem, 'ITCNET_RESUMO_OBRAS', 'height=600, width=800, top=10, left=10, toolbar=yes, scrollbars=yes, resizable=yes');
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
										
		</script>
	</HEAD>
	<body>
		<form id="frmCad" runat="server">
			<input type="hidden" id="hdFases" name="hdFases" runat="Server">
			<input type="hidden" id="hdEstagios" name="hdEstagios" runat="Server">
			<input type="hidden" id="hdTipos" name="hdTipos" runat="Server">
			<input type="hidden" id="hdEstados" name="hdEstados" runat="Server">
			
			<div id="Tudo">
				<div id="Topo" runat="server">
					<uc1:Top id="Top1" runat="server"></uc1:Top>
				
				</div>
				
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
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtNome" MaxLength="50"></asp:TextBox>
							<br>
							<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator1" Runat="server" ErrorMessage="O nome da pesquisa é obrigatório" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td>
							<asp:Button CssClass="f8" Runat="server" ID="btnSalvarAgora" Text="Salvar Pesquisa"></asp:Button>
						</td>
					</tr>
					<tr bgcolor=#ffffff>
						<td>
							&nbsp;
						</td>
					</tr>
				</table>
									
				<div id="Selecao" runat=server>
				
					<div>
						<h3>Pesquisa de Obras</h3>
						<br />
						
						<p>
							<asp:Label ID="lblMensagemTopo" Runat="server" Font-Bold="True" Font-Size="8" Font-Name="verdana">Selecione todos os itens desejados e clique no botão PESQUISAR.</asp:Label><br><br>
							<asp:label id="lblMensagemTopo2" Runat="server" CssClass="f8">Se nenhum item for selecionado, retornarão todas as obras disponíveis na DEMONSTRAÇÃO.</asp:label><br><br>
							<asp:label id="lblMensagemTopo3" Runat="server" CssClass="f8">** O sistema permite ainda, aos Associados ITCnet, o agendamento automático dos contatos realizados direto do Relatório de Obras e aviso por e-mail dos retornos do dia, através do SIG - Sistema Integrado de Gerenciamento, tornando o acesso mais fácil e rápido de operar.</asp:label>
						</p>
											
						<br class="clear" />

					</div>
				
					<div>
        				<h3>Entre Datas</h3>
						<fieldset>
							<legend>Entre as datas</legend>
			                
			                <div style="float:left">
								<label>Data Inicial:</label>
								<asp:textbox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" cssclass="inputP" id="txtDataInicio" Runat="server" size="15" MaxLength="10" onfocus="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)" style="cursor:pointer;" />
							</div>
			                <div>
								<label>Data Final:</label>
								<asp:textbox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" id="txtDataFim" Runat="server" CssClass="inputP" size="15" MaxLength="10" onfocus="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)" style="cursor:pointer;"></asp:textbox>
							</div>
						</fieldset>
					</div>
					<br />	

					<h3>Selecione as Fases</h3>
					<asp:datalist id="dtlFases" runat="server" RepeatDirection='vertical' DataKeyField="IdFase" Width="100%"  RepeatLayout=Table>
						<ItemTemplate>
							<fieldset>
								<Label><font color=#EC6400><%# DataBinder.Eval(Container.DataItem, "DESCRICAOFASE")%></font></Label><input type=checkbox onClick="javascript:Ativa(1, this, 'chkFases');" <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> id='chkFasesEstagios_<%# DataBinder.Eval(Container.DataItem, "IDFASE")%>_0' />
								<asp:datalist DataSource='<%# ListaEstagios(DataBinder.Eval(Container.DataItem, "IDFASE"))%>' id="dtlEstagios" runat="server" CssClass="f8" RepeatColumns=3 RepeatDirection=Vertical width="100%" GridLines="None" BorderStyle=Outset DataKeyField="IdEstagio" >
									<ItemTemplate>
										<label><%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTAGIO")%></label><input type=checkbox  <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> ID="chkFasesEstagios_<%# DataBinder.Eval(Container.DataItem, "IDFASE")%>_<%# DataBinder.Eval(Container.DataItem, "IDESTAGIO")%>" value="<%# DataBinder.Eval(Container.DataItem, "IDESTAGIO")%>" onClick="javascript:Ativa(2, this, 'chkFases');" />
									</ItemTemplate>
								</asp:datalist>
								<br>
							</fieldset>
						</ItemTemplate>
					</asp:datalist>
						
					<h3>Segmentos de Atuação</h3>
					<asp:datalist id="dtlSegmentos" runat="server" RepeatDirection=vertical DataKeyField="IdSegmento" Width='100%'>
						<ItemTemplate>
						<fieldset>
							<label><font color=#EC6400><%# DataBinder.Eval(Container.DataItem, "SEGMENTO")%></font></label>
							<input type=checkbox onClick="javascript:Ativa(1, this, 'chkSegmento');" <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> id='chkSegmentoTipo_<%# DataBinder.Eval(Container.DataItem, "IDSEGMENTO")%>_0' />
								<asp:datalist DataSource='<%# ListaTipos(DataBinder.Eval(Container.DataItem, "IDSEGMENTO"))%>' id="dtlPesquisaTipos" runat="server" CssClass="f8" RepeatColumns=3 RepeatDirection=Vertical GridLines="none" BorderStyle=Outset DataKeyField="IdTipo" Width='100%'>
									<ItemTemplate>
										<label><%# DataBinder.Eval(Container.DataItem, "DESCRICAOTIPO")%></label><input type='checkbox' <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> ID='chkSegmentoTipo_<%# DataBinder.Eval(Container.DataItem, "IDSEGMENTO")%>_<%# DataBinder.Eval(Container.DataItem, "IDTIPO")%>' value="<%# DataBinder.Eval(Container.DataItem, "IDTIPO")%>" onClick="javascript:Ativa(2, this, 'chkFases');" />
									</ItemTemplate>
								</asp:datalist>
						</fieldset>
						</ItemTemplate>
					</asp:datalist>
        			<br />

					<h3>Regiões do Brasil <input type=checkbox id=regTodas name=regTodas onclick='javascript:CP("chkEstadosNr,chkEstadosSd,chkEstadosSl,chkEstadosNo,chkEstadosCo,nrTodos,sdTodos,slTodos,coTodos,noTodos", this);'/></h3>
					
					<fieldset>
						<h3><input type=checkbox id=nrTodos name=nrTodos onclick='javascript:CP("chkEstadosNr", this);'/> Nordeste</h3>
						<asp:DataList CssClass="f8" DataKeyField="IDESTADO" id="dtlEstadosNr" runat="server" CellPadding="0" GridLines="none" width="100%"  RepeatColumns="3" RepeatDirection=Vertical>
							<ItemTemplate>
								<label><%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTADO")%></label><input type=checkbox  <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> ID='chkEstadosNr_<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>' value="<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>" onClick="javascript:Ativa(2, this, 'chkEstadosNr');" />
							</ItemTemplate>
						</asp:DataList>
					</fieldset>
	
					<fieldset>
						<h3><input type=checkbox id=sdTodos name=sdTodos onclick='javascript:CP("chkEstadosSd", this);'/> Sudeste</h3>
						<asp:DataList DataKeyField="IDESTADO" id="dtlEstadosSd" runat="server" GridLines="none" width="100%" RepeatColumns="3" RepeatDirection='Vertical'>
							<ItemTemplate>
								<label><%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTADO")%></label><input type=checkbox <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> ID='chkEstadosSd_<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>' value="<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>" onClick="javascript:Ativa(2, this, 'chkEstadosSd');" />
							</ItemTemplate>
						</asp:DataList>
					</fieldset>

					<fieldset>
						<h3><input type=checkbox id=slTodos name=slTodos onclick='javascript:CP("chkEstadosSl", this);'/> Sul</h3>
						<asp:DataList CssClass="f8" DataKeyField="IDESTADO" id="dtlEstadosSl" runat="server" CellPadding="0" GridLines="none" width="100%" RepeatColumns="3" RepeatDirection=Vertical>
							<ItemTemplate>
								<label><%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTADO")%></label><input type=checkbox <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> ID='chkEstadosSl_<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>' value="<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>" onClick="javascript:Ativa(2, this, 'chkEstadosSl');" />
							</ItemTemplate>
						</asp:DataList>
					</fieldset>
				
					<fieldset>
						<h3><input type=checkbox id=noTodos name=noTodos onclick='javascript:CP("chkEstadosNo", this);'/> Norte</h3>
						<asp:DataList CssClass="f8" DataKeyField="IDESTADO" id="dtlEstadosNo" runat="server" CellPadding="0" GridLines="none" width="100%" RepeatColumns="3" RepeatDirection=vertical>
							<ItemTemplate>
								<label><%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTADO")%></label><input type=checkbox <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> ID='chkEstadosNo_<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>' value="<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>" onClick="javascript:Ativa(2, this, 'chkEstadosNo');" />
							</ItemTemplate>
						</asp:DataList>
					</fieldset>
					
					<fieldset>
						<h3><input type=checkbox id=coTodos name=coTodos onclick='javascript:CP("chkEstadosCo", this);'/> Centro-Oeste</h3>
						<asp:DataList DataKeyField="IDESTADO" id="dtlEstadosCo" runat="server" CellPadding="0" GridLines="none" width="100%" RepeatColumns="3" RepeatDirection=Vertical>
							<ItemTemplate>
								<label><%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTADO")%></label><input type=checkbox <%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "CAMPOPESQUISA")=1, "checked", "")%> ID='chkEstadosCo_<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>' value="<%# DataBinder.Eval(Container.DataItem, "IDESTADO")%>" onClick="javascript:Ativa(2, this, 'chkEstadosCo');" />
							</ItemTemplate>
						</asp:DataList>
					</fieldset>
					
					<br />        			
					<h3>Filtros especificos</h3>
					<fieldset>
						<legend>Filtros especificos</legend>
						
						<table width=100%>
							<tr>
								<td width=10%>
									<label>Nome da Obra</label>
								</td>
								<td width=20%>
									<asp:textbox id="txtNomeObra" Runat="server" CssClass="inputG3" Width="193" MaxLength="50"></asp:textbox>
								</td>
								<td width=15%>
                					<label>Código da Obra</label>
								</td>
								<td width=35%>
									<asp:textbox id="txtCodigoObra" Runat="server" CssClass="inputG3" Width="200" MaxLength="50"></asp:textbox>
								</td>
							</tr>
							
							<tr>
								<td width=10%>
									<label>Endereço</label>
								</td>
								<td width=20%>
									<asp:textbox id="txtEndereco" Runat="server" CssClass="inputG3" Width="193" MaxLength="50"></asp:textbox>
								</td>
								<td width=15%>
									<label>Bairro</label>
								</td>
								<td width=35%>
									<asp:textbox id="txtBairro" Runat="server" CssClass="inputG3" Width="200" MaxLength="50"></asp:textbox>
								</td>
							</tr>
							
							<tr>
								<td width=15%>
		 							<label>Estado</label>
								</td>
								<td width=35%>
									<asp:DropDownList Runat="SERVER" AutoPostBack="FALSE" ONCHANGE="XM_PopulateList('CID', XM_GetSelectedItems('cboIdEstado', 2), 'CIDADE', 'IDCIDADE', 'cboCidade')" id="cboIdEstado" runat="server"></asp:DropDownList>
								</td>
								<td width=15%>
									<label>Cidade</label>
								</td>
								<td width=35%>
									<SELECT id="cboCidade" runat="server" Class="f8" NAME="cboCidade">
										<option value="0">Selecione...</option>
									</SELECT>
								</td>
							</tr>
							
							<tr>
								<td width=15%>
									<label>CEP Inicial</label>
								</td>
								<td width=35%>
									<asp:textbox id="txtCepDe" onkeydown="javascript:FormataCEP(this, event);" Runat="server" CssClass="inputP" Width="70" MaxLength="9"></asp:textbox></td>
								</td>
								<td width=15%>
									<label>CEP Final</label>
								</td>
								<td width=35%>
									<asp:textbox id="txtCepAte" onkeydown="javascript:FormataCEP(this, event);" Runat="server" CssClass="inputP" Width="70" MaxLength="9"></asp:textbox></td>
								</td>
							</tr>
							
							<tr>
								<td width=15%>
									<label>Área Construída(m²)</label>
								</td>
								<td width=40%>
									<uc1:combobox id="cboFatorAreaConstruida" runat="server"></uc1:combobox>
									<asp:textbox id="txtAreaConstruida" Runat="server" Width="70" MaxLength="50"></asp:textbox>
								</td>
								<td width=15%>
									<label>Valor do Investimento</label>
								</td>
								<td width=30%>
									<uc1:combobox id="cboFatorValor" runat="server"></uc1:combobox>
									<asp:textbox id="txtValor" Runat="server" Width="80" MaxLength="50"></asp:textbox>
								</td>
							</tr>
							
							<tr>

								<td width=15%>
									<label>Empresa Participante</label>
								</td>
								<td width=35%>
									<asp:textbox id="txtEmpresaParticipante" Runat="server" CssClass="inputG" Width="193" MaxLength="100"></asp:textbox>
								</td>
								<td width=15%>
                					<label>Modalidade</label>
								</td>
								<td width=35%>
									<uc1:combobox id="cboIdMolidade" runat="server" cssclass=selectG></uc1:combobox>
								</td>
							</tr>
							
							<tr>
								<td width=15%>
									<label>Descrição</label>
								</td>
								<td width=35%>
									<asp:textbox id="txtDescricaoObra" Runat="server" CssClass="inputG3" Width="193" MaxLength="100"></asp:textbox>
								</td>
								<td width=15%>
									<label>Número de Revisão</label>
								</td>
								<td width=35%>
									<uc1:combobox id="cboChecagemNrRevisao" runat="server"></uc1:combobox>
									<asp:textbox id="txtNumeroRevisao" Runat="server" Width="80" MaxLength="50"></asp:textbox>
								</td>
							</tr>
							
							<tr>
								<td width=15%>
									<label>Início da Obra</label>
								</td>
								<td width=35%>
									<asp:textbox id="txtInicioObra" Runat="server" CssClass="inputG" Width="70" MaxLength="10" onfocus="displayCalendar(document.forms[0].txtInicioObra,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtInicioObra,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtInicioObra,'dd/mm/yyyy',this)" style="cursor:pointer;" ></asp:textbox>
								</td>
								<td width=15%>
									<label>Término da Obra</label>	
								</td>
								<td width=35%>
									<asp:textbox id="txtTerminoObra" Runat="server" CssClass="inputG" Width="70" MaxLength="10" onfocus="displayCalendar(document.forms[0].txtTerminoObra,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtTerminoObra,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtTerminoObra,'dd/mm/yyyy',this)" style="cursor:pointer;" ></asp:textbox>
								</td>
							</tr>
							<tr runat="server" id="trPesquisador">
								<td width=15%>
									<label>Pesquisador</label>	
								</td>
								<td width=35%>
									<uc1:combobox id="cboPesquisador" runat="server"></uc1:combobox>
								</td>
							</tr>
							
						</table>

					</fieldset>
					<br />
					
					<h3>Pesquisas Salvas</h3>
					<fieldset>
						<legend>Pesquisas Salvas</legend>
						
						<div align="center" class="botoes-pesquisa">
			            	
							<p style="width:210px;">
                				Pesquisas Salvas<br />
								<uc1:combobox id="cboPesquisasSalvas" runat="server" CssClass="f8"></uc1:combobox>
							</p>
			                
							<p style="width:230px;">
                				Ordenar por<br />
								<uc1:combobox id="cboOrdenar" runat="server" CssClass="f8"></uc1:combobox>
							</p>
			                
							<p style="width:180px;">
                				Mostrar<br />
								<uc1:combobox id="cboMostrar" EnableValidation="false" runat="server" CssClass="f8"></uc1:combobox>
							</p>
            				<br class="clear" />
							<br />
							<table width="100%">
								<tr>
									<td align=center width=5%></td>
									<td align="middle" width="25%"><asp:button id="btnPesquisar" Runat="server" CssClass="f8" Text="Pesquisar"></asp:button></td>
									<td align="middle" width="25%"><asp:button id="btnNovaPesquisa" Runat="server" CssClass="f8" Text="Nova Pesquisa"></asp:button></td>
									<td align="middle" width="25%"><asp:button id="btnSalvarPesquisa" Runat="server" CssClass="f8"  Text="Salvar Pesquisa"></asp:button></td>
									<td align="middle" width="25%"><asp:button id="btnExcluirPesquisa" Runat="server" CssClass="F8" Text="Excluir Pesquisa"></asp:button></td>
								</tr>
							</table>
						</div>
					</fieldset>
					<script language='javascript'>setItens();</script>
				</div>
				<table id="Resultados" width="100%" runat="server">
					<tr>
						<td width="100%" colSpan="4">
							<input type="hidden" id="hidLink" value="" runat="server" NAME="hidLink"/>
							<input type="hidden" id="hidAuth" value="" runat="server" NAME="hidAuth"/>
							<input type="hidden" id="hidCidade" value="" runat="server" NAME="hidCidade"/>
							<asp:Literal Runat="server" Text="" ID="ltScript"></asp:Literal>
							<uc1:BarraNavegacao id="Barranavegacao" runat="server"></uc1:BarraNavegacao>
							<asp:datagrid id="dtgResultados" runat="server" CssClass="f9" width="100%" AutoGenerateColumns="False" GridLines="none" CellPadding="3" BackColor="White" BorderColor="#999999" DataKeyField="CODIGO" HorizontalAlign="Center" AllowPaging=True PageSize="50" AllowSorting="True">
								<HeaderStyle Font-Bold=True BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
								<Columns>
									<asp:TemplateColumn ItemStyle-Font-Bold="True" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Name="verdana" ItemStyle-Font-Size="10" HeaderStyle-Width="1%" HeaderText='<input type="checkbox" onclick="javascript:CA(this);" class="f8" value="Todos" id=btnMarcarTodos NAME="btnMarcarTodos">'>
										<ItemTemplate>
											<input type=checkbox ID="chkItemResultado" value="<%# DataBinder.Eval(Container.DataItem, "CODIGO")%>">
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="12%" HeaderText="<B>Código ITC</B>">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "CODIGOANTIGO")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="29%" HeaderText="<B>Nome da Obra</B>">
										<ItemTemplate>
											<b><%# DataBinder.Eval(Container.DataItem, "PROJETO")%></b>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="30%" HeaderText="<B>Endereço</B>">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "ENDERECO")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-Width="29%" HeaderText="<B>Nome Fantasia</B>">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "FANTASIA")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="<B>Cidade</B>">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "CIDADE")%>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="<B>Atualização</B>">
										<ItemTemplate>
											<%# DataBinder.Eval(Container.DataItem, "PUBLICACAO")%>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle  Visible=False HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:datagrid>
							<uc1:BarraNavegacao id="BarraNavegacao1" runat="server"></uc1:BarraNavegacao>
							<br>
						</td>
					</tr>
					
					<tr>
						<td colspan=5 align=center>
							<table align=center border=1>
								<tr>
									<td align="center" width="20%"><asp:button id="btnNovaPesquisa2" Runat="server" CssClass="f8" Text="Nova Pesquisa"></asp:button></td>
									<td align="center" width="22%"><input type=button id="btnImprimirResumo" Class="f8" value="Visualizar Resumo" onclick="javascript:XM_ITC_Resumo();"></td>
									<td align="center" width="15%"><asp:button id="btnGravarLink" Runat="server" CssClass="f8" Text="Enviar Link"></asp:button></td>
									<td align="center" width="22%"><input type=button id="btnImprimir" Value="Visualizar Pesquisa" OnClick='javascript:XM_ITC_Pesquisar();' /></td>
									<td align="center" width="20%"><input runat="server" type=button id="btnExportar" Value="Exportar" OnClick='javascript:XM_ITC_Exportar();' NAME="btnExportar"/></td>
								</tr>
							</table>
						</td>
					</tr>
					
					<tr>
						<td noWrap align="right"><font class="f8"><b>Tipo de Relatório: </b></font>
						</td>
						<td align="left" width="30%">
							<font class=f8>Relatório Sequencial</font>
							<input type=radio id=TipoRelatorio name=TipoRelatorio value=1 checked>
						</td>
						<td align="left" width="55%">
							<font class=f8>Um Resultado por Página</font>	
							<input type=radio id=TipoRelatorio name=TipoRelatorio value=2 >
						</td>
					</tr>
				</table>

				<br class=clear />
				
				<uc1:Rodape id="Rodapé" runat="server"></uc1:Rodape>
			</div>
											<input type=Hidden id='hddOrdem' name='hddOrdem' runat=server />
		</form>
	</body>
</HTML>
