<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="VisitaPesquisas.aspx.vb" Inherits="Pesquisas_VisitaPesquisaDet" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register src="../controls/Letras.ascx" tagname="Letras" tagprefix="uc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
		        <div class='FiltroItem' style="margin-right:2px;">Filtro<br>
		            <asp:TextBox runat="server" ID="txtFiltro" Width="95%"  />
		        </div>
		        <div class='FiltroItem' style="padding-left:9px;">Gerente de Vendas<br>
		            <asp:DropDownList runat="server" ID="cboIdGerenteVendas" DataTextField="GerenteVendas" DataValueField="IdGerenteVendas" AutoPostBack="true" Width="80%" />
		        </div>
		        <div class='FiltroItem'>Supervisor<br>
		            <asp:DropDownList runat="server" ID="cboIDSupervisor" DataTextField="Supervisor" DataValueField="IDSupervisor" AutoPostBack="true" Width="80%" />
		        </div>
		        <div class='FiltroItem'>Vendedor<br>
		            <asp:DropDownList runat="server" ID="cboIdVendedor" DataTextField="CodVendedor" DataValueField="IDVendedor" Width="80%" />
		        </div>
		        <div class='FiltroItem' style="width:11%;">Status<br>
		            <asp:DropDownList runat="server" ID="cboIDJustificativa" DataTextField="Justificativa" DataValueField="IDJustificativa" />
		        </div>
		        <div class='FiltroItem' style="width:400px">Data<br>
						<asp:TextBox runat='server' ID='txtDataInicial' MaxLength="10" Width='80' />
						<asp:CompareValidator runat='server'  ID='valCompDataInicial' Display='None' ErrorMessage='Data inicial inv&aacute;lida' ControlToValidate='txtDataInicial' Operator='DataTypeCheck' Type='Date' />
						<cc1:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataInicial" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
		        		at&eacute;
						<asp:TextBox runat='server' ID='txtDataFinal' MaxLength="10" Width='80' />
						<cc1:CalendarExtender  ID="cal_DataFinal" runat="server" TargetControlID="txtDataFinal" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
						<asp:CompareValidator runat='server'  ID='valCompDataFinal' Display='None' ErrorMessage='Data final inv&aacute;lida' ControlToValidate='txtDataFinal' Operator='DataTypeCheck' Type='Date' />
		        </div>
				<span class='FiltroBotao' style="width:16%; float:right;">
					<asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				</span>
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
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='IDVisita'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
					    <asp:ButtonField ButtonType='Link' CommandName='Select' DataTextField='IDVisita' HeaderText='Visita' SortExpression='IDVisita' />
						<asp:BoundField HeaderText="Cliente" DataField="Cliente" SortExpression="Cliente" ItemStyle-Wrap='false' />
						<asp:BoundField HeaderText="Vendedor" DataField="Vendedor" SortExpression="Vendedor" />
						<asp:BoundField HeaderText="Data de Inicio" DataField="Inicio" SortExpression="Inicio" />
                        <asp:BoundField HeaderText="Data de Fim" DataField="Termino" SortExpression="Fim" />
                        <asp:TemplateField HeaderText="Tempo da Visita">
                            <ItemTemplate>
                                <%# fncDiferencaEntreDatas(Eval("Inicio") & "", Eval("Termino") & "")%>
                            </ItemTemplate>
                        </asp:TemplateField>
						<asp:BoundField HeaderText="Status" DataField="Status"/>
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow' >
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; pesquisas com o filtro selecionado!
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
	<div>
	    <asp:UpdatePanel runat='server' ID='updDetalhes'>
	        <ContentTemplate>
	            <asp:PlaceHolder runat='server' ID='plhDetalhes' Visible='false'>
                    <div class='EditArea'>
		                <div class='divEditArea'>
		                    <div class='divHeader'>&nbsp;Visita: <asp:Label runat='server' ID='lnkVisita'>0</asp:Label></div>
			                <div class='trField cb' runat='server'  id='trIDCliente' visible='<%$Settings: visible, Visita.IDCliente, true %>' >
				                <div class='tdFieldHeader cb fl'>
					                Cliente:
				                </div>
				                <div class='tdField fl'>
					                <asp:Label runat="server" ID="lblCliente" />
				                </div>
			                </div>
			                <div class='trField fr' runat='server' style="width:40%" id='trIDVendedor' visible='<%$Settings: visible, Visita.IDVendedor, true %>' >
				                <div class='tdFieldHeader fl'>
					                Vendedor:
				                </div>
				                <div class='tdField fl'>
					                <asp:Label runat="server" ID="lblVendedor" />
				                </div>
			                </div>
			                <div class='trField cb' runat='server'  id='Div1' visible='<%$Settings: visible, Visita.Endereco, true %>' >
				                <div class='tdFieldHeader cb fl'>
					                Endere&ccedil;o Cliente:
				                </div>
				                <div class='tdField fl'>
					                <asp:Label runat="server" ID="lblEndereco" />
				                </div>
			                </div>
			                <div class='trField cb' runat='server'  id='trData' visible='<%$Settings: visible, Visita.Data, true %>' >
				                <div class='tdFieldHeader cb fl'>
					                Data da Visita:
				                </div>
				                <div class='tdField fl'>
					                <asp:Label  runat='server' ID='lblData' />
				                </div>
			                </div>
			                <div class='trField fr' runat='server' style="width:40%" id='trIDJustificativa' visible='<%$Settings: visible, Visita.IDJustificativa, true %>' >
				                <div class='tdFieldHeader fl'>
					                Status:
				                </div>
				                <div class='tdField fl'>
					                <asp:Label runat='server' ID='lblStatus'></asp:Label>
				                </div>
			                </div>
			                <div class='trField cb' runat='server'  id='trInicio' visible='<%$Settings: visible, Visita.Inicio, true %>' >
				                <div class='tdFieldHeader cb fl'>
					                In&iacute;cio da Visita:
				                </div>
				                <div class='tdField fl'>
					                <asp:Label runat='server' ID='lblInicio' />
				                </div>
			                </div>
			                <div class='trField cb' runat='server'  id='trTermino' visible='<%$Settings: visible, Visita.Termino, true %>' >
				                <div class='tdFieldHeader cb fl'>
					                Termino da Visita:
				                </div>
				                <div class='tdField fl'>
					                <asp:Label runat='server' ID='lblTermino' />
				                </div>
			                </div>
                            <div class='trField cb' runat='server'  id='divReincidencia' >
                                <div class='tdFieldHeader cb fl'>
					                Marcada para reincidência:
				                </div>
				                <div class='tdField fl'>
					                <asp:Label runat='server' ID='lblMarcadaParaReincidencia' >Sim</asp:Label>
				                </div>
			                </div>
                            <div class='AreaBotoes cb'>
                                <asp:Button style="width:200px;" CssClass="Botao" OnClientClick="return confirm('Deseja forçar a reincidência desta visita');" Text=" Forçar reincidência " runat="server" ID='btnForcarReincidencia' />
                            </div>
		                </div>
                        <div>
                            <asp:GridView runat='server' id='grdItensPesquisa' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='IDVisita'>
				                <HeaderStyle HorizontalAlign='Left' />
					            <columns>
						            <asp:BoundField HeaderText="Marca" DataField="Marca" SortExpression="Marca" ItemStyle-Wrap='false' />
						            <asp:BoundField HeaderText="Produto" DataField="ProdutoPesquisa" SortExpression="ProdutoPesquisa" />
                                    <asp:BoundField HeaderText="Quantidade" DataField="Quantidade" SortExpression="Quantidade" />
						            <asp:BoundField HeaderText="Volume" DataField="Volume" SortExpression="Volume" />
                                    <asp:BoundField HeaderText="Preço Ponta" DataField="PrecoPonta" SortExpression="PrecoPonta" />
                                    <asp:BoundField HeaderText="Preço Varejo" DataField="PrecoVarejo" SortExpression="PrecoVarejo" />
					            </columns>
					            <EmptyDataTemplate>
				                    <div class='GridHeader'>&nbsp;</div>					    
					                <div class='divEmptyRow' >
							            <asp:Label runat='server' ID='lblNaoEncontrados'>
								            N&atilde;o h&aacute; itens para essa pesquisa!
							            </asp:Label>
					                </div>
					            </EmptyDataTemplate>
				            </asp:GridView>
                        </div>
	                </div>
	            </asp:PlaceHolder>
	        </ContentTemplate>
	    </asp:UpdatePanel>
	</div>
    <div class='AreaBotoes'>
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

