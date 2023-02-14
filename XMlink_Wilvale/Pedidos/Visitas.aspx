<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Visitas.aspx.vb" Inherits="Pages.Visita.Visitas" title="XM Promotores" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <script type="text/javascript">
        function printReport() {
            var url = "Visitas_prn.aspx?";
            url += "Filtro=" + document.getElementById('<%=txtFiltro.ClientID%>').value;
            url += "&IDVendedor=" + document.getElementById('<%=cboIDVendedor.ClientID%>').value;
            url += "&Inicio=" + document.getElementById('<%=txtDataInicial.ClientID%>').value;
            url += "&Fim=" + document.getElementById('<%=txtDataFinal.ClientID%>').value;
            url += "&Justificativa=" + document.getElementById('<%=cboIDJustificativa.ClientID%>').value;
            url += "&QtdRegistros=" + document.getElementById('<%=hidQtdeReg.ClientID%>').value;
            url += "&Secao=<%=SecaoAtual %>";

            window.open(url, 'IMPRIMIR_RELATORIO_VISITAS', 'width=850,height=650,status=no,scrollbars=yes,toolbar=no,top=20,left=20');
        }
    </script>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
				<div class='FiltroItem'>
					<asp:Label runat="server" id="lblFiltrarPor">Filtrar por</asp:Label>
					<br>
					<asp:TextBox Runat="server" ID='txtFiltro' />
				</div> 
		        <div class='FiltroItem'>Vendedor<br>
		            <asp:DropDownList runat="server" ID="cboIDVendedor" DataTextField="Vendedor" DataValueField="IDVendedor" />
		        </div>
		        <div class='FiltroItem'>Justificativa<br>
		            <asp:DropDownList runat="server" ID="cboIDJustificativa" DataTextField="TipoJustificativa" DataValueField="IDTipoJustificativa" />
		        </div>
		        <br class='cb' />
		        <div class='FiltroItem' style="width:400px;">Data<br>
						<asp:TextBox onkeydown="FormataData(this, event);" onblur="VerificaData(this);" runat='server' ID='txtDataInicial' MaxLength="10" />
						<ajaxToolkit:CalendarExtender  ID="cal_txtDataInicial" 
													runat="server" 
													TargetControlID="txtDataInicial"
													PopupPosition="Right"
													PopupButtonID="imgCalendarInicial"
													Format="dd/MM/yyyy"
													/>
										<asp:ImageButton ID="imgCalendarInicial" runat="server" ImageUrl="~/imagens/Calendario.png" />
						<asp:CompareValidator runat='server'  ID='valCompDataInicioInicial' Display='None' ErrorMessage='DataInicio inicial inv&aacute;lida' ControlToValidate='txtDataInicial' Operator='DataTypeCheck' Type='Date' />
		        		ate
						<asp:TextBox onkeydown="FormataData(this, event);" onblur="VerificaData(this);" runat='server' ID='txtDataFinal' MaxLength="10" />
						<ajaxToolkit:CalendarExtender ID="cal_txtDataFinal" 
													runat="server" 
													TargetControlID="txtDataFinal"
													PopupPosition="Right"
													PopupButtonID="imgCalendarFinal"
													Format="dd/MM/yyyy"
													Animated="true"
													/><asp:ImageButton ID="imgCalendarFinal" runat="server" ImageUrl="~/imagens/Calendario.png" />
						<asp:CompareValidator runat='server'  ID='valCompDataInicioFinal' Display='None' ErrorMessage='DataInicio final inv&aacute;lida' ControlToValidate='txtDataFinal' Operator='DataTypeCheck' Type='Date' />
		        </div>
				<div class='FiltroBotao'>
					<asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				</div>
			</div>	
	    </ContentTemplate>
	</asp:UpdatePanel> 
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDVisita" DataNavigateUrlFormatString="Visita.aspx?IDVisita={0}" DataTextField="IDVisita" HeaderText="Visita" SortExpression="IDVisita"  />
						<asp:BoundField HeaderText="Cliente" DataField="Cliente" SortExpression="Cliente" />
						<asp:BoundField HeaderText="Vendedor" DataField="Vendedor" SortExpression="Vendedor" />
						<asp:BoundField HeaderText="Data" DataField="Data" SortExpression="Data" />
						<asp:BoundField HeaderText="Justificativa" DataField="TipoJustificativa" SortExpression="TipoJustificativa" />
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow'>
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; Visitas com o filtro selecionado!
							</asp:Label>
					    </div>
					</EmptyDataTemplate>
				</asp:GridView>
                <input type="hidden" id="hidQtdeReg" runat="server" />
                <uc1:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes'>
        <input type="button" runat='server' id='btnNovo' visible="false" class="Botao" value=" Novo " onclick="location.href='Visita.aspx?idvisita=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='../controle/default.aspx'" />
		<asp:Button runat='server' ID='btnExportar' Text='Exportar' class="Botao" />
        <input type="button" onclick="javascript:printReport();" value="Imprimir" class='Botao' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Novo:</b>
				Abre para edi&ccedil;&atilde;o um novo registro.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

