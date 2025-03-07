<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Relatorios.aspx.vb" Inherits="Pages.Reports.Relatorios" title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register src="../controls/Letras.ascx" tagname="Letras" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language='javascript'>
				    function openReport(p_Guid, p_ReportName) {

				        var win = window.open('rptShowReport.aspx?repId=' + p_Guid, p_ReportName, 'width=450, height=300, scrollbars=yes');
			            win.focus();
				    }
    </script>
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
				<div class='FiltroItem'>
					<asp:Label runat="server" id="lblFiltrarPor">Filtrar por</asp:Label>
					<br>
					<asp:TextBox Runat="server" ID='txtFiltro' style="width:250px;" />
				</div> 
		        <div class='FiltroItem'>Usu&aacute;rio<br>
		            <asp:DropDownList runat="server" ID="cboIDUsuario" DataTextField="Usuario" DataValueField="IDUsuario" />
		        </div>
		        <div class='FiltroItem'>Ativo<br>
		            <asp:DropDownList runat='server' ID='cboAtivo'>
		            	<asp:ListItem value="0">Todos</asp:ListItem>
		            </asp:DropDownList>
		        </div>
		        <div class='FiltroItem cb' style="width:350px;">Data de<br>
                        <asp:TextBox runat='server' ID='txtDataInicial' onkeydown="FormataData(this, event);" onblur="VerificaData(this);" MaxLength="10" />
						<asp:CompareValidator runat='server'  ID='valCompDataInicial' Display='None' ErrorMessage='Data inicial inv&aacute;lida' ControlToValidate='txtDataInicial' Operator='DataTypeCheck' Type='Date' />
						<cc1:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataInicial" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
		        		at&eacute;
						<asp:TextBox runat='server' ID='txtDataFinal' onkeydown="FormataData(this, event);" onblur="VerificaData(this);" MaxLength="10" />
						<cc1:CalendarExtender  ID="cal_DataFinal" runat="server" TargetControlID="txtDataFinal" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
						<asp:CompareValidator runat='server'  ID='valCompDataFinal' Display='None' ErrorMessage='Data final inv&aacute;lida' ControlToValidate='txtDataFinal' Operator='DataTypeCheck' Type='Date' />
		        </div>
				<div class='FiltroLetras'>
					<uc2:Letras ID="Letras1" runat="server" />
				</div>
				<div class='FiltroBotao'>
					<asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				</div>
			</div>	
	    </ContentTemplate>
	</asp:UpdatePanel> 
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter='1000' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
                        <asp:BoundField HeaderText="Relat&oacute;rio" DataField="Relatorio" SortExpression="Relatorio" />
						<asp:BoundField HeaderText="Usuario" DataField="Usuario" SortExpression="Usuario" />
						<asp:BoundField HeaderText="Data" DataField="Data" SortExpression="Data" />
                        <asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Status" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <%# IIf(Eval("IdStatus") = 2 Or Eval("IdStatus") = 1, "<a href=""javas" & "cript:openReport('" & Eval("IDRelatorio").ToString() & "', 'ABRIRRELATORIO')"">Abrir Relatório</a>", "")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow'>
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; Relatorios com o filtro selecionado!
							</asp:Label>
					    </div>
					</EmptyDataTemplate>
				</asp:GridView>
                <uc1:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes'>
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Relatorio.aspx?idrelatorio=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
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

