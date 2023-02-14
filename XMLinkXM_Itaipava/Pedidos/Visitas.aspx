<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Visitas.aspx.vb" Inherits="Pages.Pedidos.Visitas" title="Untitled Page" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register src="../controls/Letras.ascx" tagname="Letras" tagprefix="uc2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../controls/Localizacao.ascx" tagname="Localizacao" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
		        <div class='FiltroItem' style="margin-right:2px;">Cliente<br>
		            <asp:TextBox runat="server" ID="txtCliente" Width="95%"  />
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
		        <div class='FiltroItem'>Grupo<br>
		            <asp:DropDownList runat="server" ID="cboIdGrupo" DataTextField="Grupo" DataValueField="IDGrupo" Width="88%" />
		        </div>
		        <div class='FiltroItem' style="width:11%;">Status<br>
		            <asp:DropDownList runat="server" ID="cboIDJustificativa" DataTextField="Justificativa" DataValueField="IDJustificativa" />
		        </div>
                <div class='FiltroItem'>Caracteristica da Visita<br>
		            <asp:DropDownList runat="server" ID="cboIdVisForaRota" Width="60%" />
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
                <asp:Panel runat="server" Visible="false">
		        <div class='FiltroItem'>Com Investimento<br>
		            <asp:CheckBox runat='server' ID='chkInvestimento' />
		        </div>
                </asp:Panel>
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
						<asp:TemplateField>
						    <ItemTemplate>
						        <img id="Img1" src="~/imagens/exclam.jpg" runat='server' visible='<%# IIF(Eval("Obs") = 1, true, false) %>' />
						    </ItemTemplate>
						</asp:TemplateField>
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
								N&atilde;o h&aacute; Visitas com o filtro selecionado!
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
		                    <div class='divHeader'>&nbsp;Visita: <asp:HyperLink runat='server' ID='lnkVisita' ForeColor='White'>0</asp:HyperLink></div>
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
			                <div class='trField fr' runat='server' style="width:40%" id='Div2' visible='<%$Settings: visible, Visita.LocalizacaoCliente, true %>' >
				                <div class='tdFieldHeader fl'>
					                Localiza&ccedil;&atilde;o Cliente:
				                </div>
				                <div class='tdField fl'>
					                <uc3:Localizacao ID="LocalizacaoCliente" runat="server" />
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
			                <div class='trField fr' runat='server' style="width:40%" id='trLocalizacaoInicio' visible='<%$Settings: visible, Visita.LocalizacaoInicio, true %>' >
				                <div class='tdFieldHeader fl'>
					                Localiza&ccedil;&atilde;o In&iacute;cial:
				                </div>
				                <div class='tdField fl'>
					                <uc3:Localizacao ID="LocalizacaoInicio" runat="server" />
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
			                <div class='trField fr' runat='server' style="width:40%" id='trLocalizacaoFinal' visible='<%$Settings: visible, Visita.LocalizacaoFinal, true %>' >
				                <div class='tdFieldHeader fl'>
					                Localiza&ccedil;&atilde;o Final:
				                </div>
				                <div class='tdField fl'>
					                <uc3:Localizacao ID="LocalizacaoFinal" runat="server" />
				                </div>
			                </div>                            
			                <div class='trField cb' runat='server' style="width:40%" id='trVisForaRota' visible='<%$Settings: visible, Visita.ForaRota, true %>' >
				                <div class='tdFieldHeader cb fl'>
					                Fora de Rota:
				                </div>
				                <div class='tdField fl'>
					                <asp:CheckBox runat='server' ID='chkVisForaRota' Enabled="false" />
				                </div>
			                </div>
		                </div>
	                </div>
	                <div class='ListaPedidos'>
	                <asp:PlaceHolder runat='server' ID='plhPedidos'>
	                    <asp:Repeater runat='server' ID='grdPedidos'>
	                        <ItemTemplate>
	                            <asp:HiddenField runat='server' ID='hidIDPedido' Value='<%#Eval("IDPedido") %>' />
	                            <div class='Pedido'>
		                            <div style="width:100%">
		                                <div class='divHeader'>
			                                <div class='trField fl' runat='server' id='trNumeroPedido' visible='<%$Settings: visible, Pedido.NumeroPedido, true %>' >
				                                <div class='tdFieldHeader fl'>
					                                N&uacute;mero do Pedido:&nbsp;
				                                </div>
				                                <div class='tdField fl'>
					                                <a href='Pedido.aspx?IDPedido=<%#Eval("IDPedido")%>&idvisita=<%#Eval("IDVisita")%>'><%#Eval("NumeroPedido")%></a>
				                                </div>
			                                </div>
			                                <div class='trField fr' runat='server' id='trStatusPedido' visible='<%$Settings: visible, Pedido.StatusPedido, true %>' >
				                                <div class='tdFieldHeader fl'>
					                                Status:
				                                </div>
				                                <div class='tdField fl'>
					                                <%#Eval("StatusPedido")%>
				                                </div>
			                                </div>
			                            </div>
			                            <div class='bloco'>
			                                <div class='trField fl' runat='server' style="width:49%"  id='trTipoPedido' visible='<%$Settings: visible, Pedido.TipoPedido, true %>' >
				                                <div class='tdFieldHeader fl'>
					                                Tipo de Pedido:
				                                </div>
				                                <div class='tdField fl'>
					                               <%#Eval("TipoPedido") %>
				                                </div>
			                                </div>
			                                <div class='trField fl' runat='server' style="width:49%" id='trIDCondicao' visible='<%# IIF(Cint("0" & Eval("IDTipoPedido")) = 1, true, false) %>' >
				                                <div class='tdFieldHeader fl'>
					                                Condi&ccedil;&atilde;o de Pagto:
				                                </div>
				                                <div class='tdField fl'>
					                                 <asp:Label runat='server' ID='lblCondicao' Text='<%#Eval("Condicao") %>' />
				                                </div>
			                                </div>
	                                        <asp:GridView runat='server' ID='grdItens' SkinID='GridItensPedido' AutoGenerateColumns='false' DataSource='<%# ped.ListItensPedido(Eval("IDPedido").ToString) %>'>
	                                            <HeaderStyle HorizontalAlign='Left' />
			                                    <Columns>
			                                        <asp:BoundField DataField='Quantidade' HeaderText='Qtd.' />
			                                        <asp:BoundField DataField='Codigo' HeaderText='C&oacute;digo' />
			                                        <asp:BoundField DataField='DESCRICAO' HeaderText='Descri&ccedil;&atilde;o' />
			                                        <asp:BoundField DataField='Tabela' HeaderText='Tabela de Pre&ccedil;o' />
			                                        <asp:TemplateField HeaderText="Pre&ccedil;o Unit&aacute;rio">
				                                        <ItemTemplate>
					                                        <font class="TextDefault">
						                                        <%#FormatCurrency(Eval("VALORUNITARIO"), 2)%>
					                                        </font>
				                                        </ItemTemplate>
			                                        </asp:TemplateField>
			                                        <asp:TemplateField HeaderText="Total" ItemStyle-Width="80">
				                                        <ItemTemplate>
					                                        <font class="TextDefault">
						                                        <%#FormatCurrency(Eval("Total"), 2)%>
					                                        </font>
				                                        </ItemTemplate>
			                                        </asp:TemplateField>
		                                        </Columns>
	                                        </asp:GridView>
	                                        <div id='divTotal'>
	                                            <asp:PlaceHolder runat='server' ID='plhTotal'>
    		                                        Total: <b>R$ <%#FormatNumber(Eval("Total"), 2)%></b>
	                                            </asp:PlaceHolder>
	                                        </div>
	                                        <div class='divBotoes'>
	                                            <asp:PlaceHolder runat='server' ID='plhBotoesAprovar'>
                                                    <asp:Button runat='server' ID='btnAprovar' Text='Aprovar Pedido'  CommandName='Aprovar' />
                                                    <asp:Button runat='server' ID='btnReprovar' Text='Reprovar Pedido' CommandName="Reprovar" />
	                                            </asp:PlaceHolder>
                                                <asp:PlaceHolder runat='server' ID='plhReprovar' Visible='false'>
                                                    <br />
                                                    <div class='Reprovacao'>
                                                        Motivo da reprova&ccedil;&atilde;o:<br />
                                                        <asp:TextBox runat='server' ID='txtMotivo' TextMode='MultiLine' Width='100%' Rows='3' ></asp:TextBox>
                                                        <asp:Button runat='server' ID='btnConfirmarReprovar' Text='Confirmar reprovação' CommandName="ConfirmarReprovar" />
                                                        <asp:Button runat='server' ID='btnCancelarReprovar' Text='Cancelar reprovação' CommandName="CancelarReprovar" />
                                                    </div>
                                                </asp:PlaceHolder>
	                                        </div>
			                            </div>
			                         </div> 
	                            </div>
	                        </ItemTemplate>
	                    </asp:Repeater>
	                    <asp:GridView runat='server' ID='grdPedidos2' AutoGenerateColumns='false'>
	                        <HeaderStyle HorizontalAlign='Left' />
	                        <columns>
			                    <asp:HyperLinkField DataNavigateUrlFields="IDPedido, IDVisita" DataNavigateUrlFormatString="Pedido.aspx?IDPedido={0}&idvisita={1}" DataTextField="NumeroPedido" HeaderText="N&uacute;mero" SortExpression="NumeroPedido"  />
			                    <asp:BoundField HeaderText="Vendedor" DataField="Vendedor" SortExpression="Vendedor" />
			                    <asp:BoundField HeaderText="Cliente" DataField="Cliente" SortExpression="Cliente" />
			                    <asp:BoundField HeaderText="Data de Emissao" DataField="DataEmissao" SortExpression="DataEmissao" />
			                    <asp:BoundField HeaderText="Status" DataField="StatusPedido" SortExpression="StatusPedido" />
			                    <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString='{0:C}' />
		                    </columns>
	                    </asp:GridView>
                    </asp:PlaceHolder> 
	                </div>
	                <br class='cb' />
	                <asp:PlaceHolder runat='server' ID='plhInvestimentos'>
                        <br />
                        <br />
                        Pesquisa de investimentos
	                    <div class='ListArea'>
	                        <asp:GridView runat='server' ID='grdInvestimentos' AutoGenerateColumns='False'>
	                            <HeaderStyle HorizontalAlign='Left' />
			                    <Columns>
			                        <asp:BoundField DataField='Investimento' HeaderText='Investimento' />
			                        <asp:BoundField DataField='Quantidade' HeaderText='Quantidade' />
			                    </Columns>
	                        </asp:GridView>
                        </div> 	
                    </asp:PlaceHolder>
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

