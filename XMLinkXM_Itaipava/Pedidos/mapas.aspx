<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="mapas.aspx.vb" Inherits="Pages.Pedidos.Mapas" title="Untitled Page" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../controls/Localizacao.ascx" tagname="Localizacao" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        function fncCompareValidator(p_Ativar) {
            document.getElementById('<%=CompValcboIDMotorista.ClientId%>').enabled = p_Ativar;
            document.getElementById('<%=CompValcboIDVeiculo.ClientId%>').enabled = p_Ativar;
        }
    </script>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
		        <div class='FiltroItem'>Cliente<br>
		            <asp:TextBox runat="server" ID="txtCliente" />
		        </div>
		        <div class='FiltroItem'>Motorista<br>
		            <asp:TextBox runat="server" ID="txtMotorista" />
		        </div>
		        <div class='FiltroItem' style="width:210px;">Supervisor<br>
		            <asp:DropDownList runat="server" ID="cboIDSupervisor" DataTextField="Supervisor" DataValueField="IDSupervisor" />
		        </div>
		        <div class='FiltroItem'>Grupo<br>
		            <asp:DropDownList runat="server" ID="cboIdGrupo" DataTextField="Grupo" DataValueField="IDGrupo" />
		        </div>
		        <div class='FiltroItem'>Vendedor<br>
		            <asp:TextBox runat="server" ID="txtVendedor" />
		        </div>
		        <div class='FiltroItem'>Status<br>
		            <asp:DropDownList runat="server" ID="cboIDStatus" DataTextField="Status" DataValueField="IDStatus" />
		        </div>
		        <br class='cb' />
		        <div class='FiltroItem' style="width:400px">Data<br>
						<asp:TextBox runat='server' ID='txtDataInicial' MaxLength="10" Width='80' />
						<asp:CompareValidator runat='server'  ID='valCompDataInicial' Display='None' ErrorMessage='Data inicial inv&aacute;lida' ControlToValidate='txtDataInicial' Operator='DataTypeCheck' Type='Date' />
						<cc1:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="txtDataInicial" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
		        		at&eacute;
						<asp:TextBox runat='server' ID='txtDataFinal' MaxLength="10" Width='80' />
						<cc1:CalendarExtender  ID="cal_DataFinal" runat="server" TargetControlID="txtDataFinal" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />
						<asp:CompareValidator runat='server'  ID='valCompDataFinal' Display='None' ErrorMessage='Data final inv&aacute;lida' ControlToValidate='txtDataFinal' Operator='DataTypeCheck' Type='Date' />
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
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='IDMapa, TipoPedido'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
					    <asp:ButtonField ButtonType='Link' CommandName='Select' DataTextField='IDMapa' HeaderText='Mapa' SortExpression='IDMapa' />
						<asp:BoundField HeaderText="Veículo" DataField="Placa" SortExpression="Placa" />
						<asp:BoundField HeaderText="Motorista" DataField="Motorista" SortExpression="Motorista" />
						<asp:BoundField HeaderText="Rota" DataField="IDPasta" SortExpression="IDPasta" />
						<asp:TemplateField HeaderText="Vendedor"  SortExpression="Vendedor">
						    <ItemTemplate>
						        <%# Eval("IDVendedor") %> - <%# Eval("Vendedor") %>
						    </ItemTemplate>
						</asp:TemplateField>
						<asp:BoundField HeaderText="Data" DataField="Data" SortExpression="Data" DataFormatString='{0:d}' />
						<asp:BoundField HeaderText="Status" DataField="Status" SortExpression="Status" />
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
		                    <div class='divHeader'>&nbsp;Mapa: <asp:HyperLink runat='server' ID='lnkVisita' ForeColor='White'>0</asp:HyperLink></div>
			                <div class='trField cb' runat='server'  id='trVendedor' visible='<%$Settings: visible, Visita.Vendedor, true %>' >
				                <div class='tdFieldHeader cb fl'>
					                Vendedor:
				                </div>
				                <div class='tdField fl'>
					                <asp:Label runat="server" ID="lblVendedor" />
				                </div>
			                </div>
			                <div class='trField fr' runat='server' style="width:40%" visible='<%$Settings: visible, Visita.Rota, true %>' >
				                <div class='tdFieldHeader fl'>
					                Rota:
				                </div>
				                <div class='tdField fl'>
					                <asp:Label runat='server' ID='lblRota' />
				                </div>
			                </div>
			                <div class='trField cb' runat='server'  id='trData' visible='<%$Settings: visible, Visita.Data, true %>' >
				                <div class='tdFieldHeader cb fl'>
					                Data:
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
                            <div class='trField cb' runat='server'  id='trMotorista' visible='<%$Settings: visible, Mapa.Motorista, true %>' >
				                <div class='tdFieldHeader cb fl'>
					                Motorista:
				                </div>
				                <div class='tdField fl'>
					                <asp:Label  runat='server' ID='lblMotorista' />
                                    <asp:DropDownList runat="server" ID='cboIDMotorista' DataTextField='Motorista' DataValueField='IDMotorista' Visible='false'></asp:DropDownList>
                                    <asp:comparevalidator ID="CompValcboIdMotorista" name="CompValcboIDMotorista" Enabled="false" runat="server" Display="Dynamic" Operator="GreaterThan" ErrorMessage="*" ControlToValidate="cboIDMotorista" ValueToCompare="0"></asp:comparevalidator>
				                </div>
			                </div>
                            <div class='trField fr' runat='server' style="width:40%" id='trVeiculo' visible='<%$Settings: visible, Mapa.Veiculo, true %>' >
				                <div class='tdFieldHeader fl'>
					                Ve&iacute;culo:
				                </div>
				                <div class='tdField fl'>
					                <asp:Label runat='server' ID='lblVeiculo'></asp:Label>
                                    <asp:DropDownList runat="server" ID='cboVeiculo' DataTextField='Placa' DataValueField='Placa' Visible='false'></asp:DropDownList>
                                    <asp:comparevalidator ID="CompValcboIdVeiculo" runat="server" Enabled="false" Display="Dynamic" Operator="GreaterThan" ErrorMessage="*" ControlToValidate="cboVeiculo" ValueToCompare="0"></asp:comparevalidator>
				                </div>
			                </div>
                            <div class='trField cb' runat='server' style="width:40%" id='trAlterar' visible='<%$Settings: visible, Mapa.Alterar, false %>' >
					            <asp:Button runat='server' ID='btnAlterar' Text='Alterar' />
				            </div>
                            <asp:PlaceHolder runat='server' ID='plhGravar' visible='<%$Settings: visible, Mapa.Gravar, false %>'>
                                <div class='trField cb' runat='server' style="width:40%" id='trGravar'  >
					                <asp:Button runat='server' ID='btnGravar' Text='Gravar' />
                                    <asp:Button runat='server' ID='btnCancelar' Text='Cancelar' />
                                </div>
                            </asp:PlaceHolder>                            
                            <div class='trField cb' runat='server'  id='trConfirmacao' visible='<%$Settings: visible, Mapa.Confirmacao, false %>'>
                                <div style="text-align:center;color:green;font-weight:bold;">
					                O Mapa foi alterado para o Ve&iacute;culo e o Motorista selecionado(s)!
                                </div>
				            </div>
                            <div class='trField cb' runat='server'  id='trObservacao' visible='<%$Settings: visible, Mapa.Observacao, false %>'>
                                <div style="text-align:center;color:red;font-weight:bold;">
					                O Motorista e o ve&iacute;culo selecionado j&aacute; est&aacute; efetuando uma entrega.<br />Por favor, selecione outra combina&ccedil;&atilde;o ou espere a finaliza&ccedil;&atilde;o da entrega!
                                </div>
				            </div>
			                <asp:PlaceHolder runat='server' ID='plhInicio'>
			                    <div class='trField cb' runat='server'  id='trInicio' visible='<%$Settings: visible, Visita.Inicio, true %>' >
				                    <div class='tdFieldHeader cb fl'>
					                    In&iacute;cio:
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
			                </asp:PlaceHolder>
			                <asp:PlaceHolder runat='server' ID='plhFinal'>
			                    <div class='trField cb' runat='server'  id='trTermino' visible='<%$Settings: visible, Visita.Termino, true %>' >
				                    <div class='tdFieldHeader cb fl'>
					                    Termino:
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
			                </asp:PlaceHolder>
		                </div>
	                </div>
	                <div class='ListaPedidos'>
	                <asp:PlaceHolder runat='server' ID='plhPedidos'>
	                    <asp:Repeater runat='server' ID='grdPedidos2'>
	                        <ItemTemplate>
	                            <asp:HiddenField runat='server' ID='hidIDMapa' Value='<%#Eval("IDMapa") %>' />
	                            <div class='Pedido'>
		                            <div style="width:100%">
		                                <div class='divHeader'>
			                                <div class='trField fl' runat='server' id='trNumeroPedido' visible='<%$Settings: visible, Pedido.NumeroPedido, true %>' >
				                                <div class='tdFieldHeader fl'>
					                                N&uacute;mero do Pedido:&nbsp;
				                                </div>
				                                <div class='tdField fl'>
					                                <%#Eval("NumeroPedido")%>
				                                </div>
			                                </div>
			                                <div class='trField fr' runat='server' id='trStatusPedido' visible='<%$Settings: visible, Pedido.StatusPedido, true %>' >
				                                <div class='tdFieldHeader fl'>
					                                Status:
				                                </div>
				                                <div class='tdField fl'>
					                                <%#Eval("Status")%>
				                                </div>
			                                </div>
			                            </div>
			                            <div class='bloco'>
			                                <div class='trField fl' runat='server' style="width:49%" id='trIDCondicao' >
				                                <div class='tdFieldHeader fl'>
					                                Condi&ccedil;&atilde;o de Pagto:
				                                </div>
				                                <div class='tdField fl'>
					                                 <asp:Label runat='server' ID='lblCondicao' Text='<%#Eval("Condicao") %>' />
				                                </div>
			                                </div>
	                                        <div id='divTotal'>
	                                            <asp:PlaceHolder runat='server' ID='plhTotal'>
    		                                        Total: <b>R$ <%#FormatNumber(Eval("ValorPedido"), 2)%></b>
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
                                                        Motivo da reprovação:<br />
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
	                    <asp:GridView runat='server' ID='grdPedidos' AutoGenerateColumns='false'>
	                        <HeaderStyle HorizontalAlign='Left' />
	                        <columns>
			                    <asp:BoundField HeaderText="NumeroPedido" DataField="NumeroPedido" SortExpression="NumeroPedido" />
			                    <asp:BoundField HeaderText="Vendedor" DataField="Vendedor" SortExpression="Vendedor" />
			                    <asp:BoundField HeaderText="Cliente" DataField="Cliente" SortExpression="Cliente" />
			                    <asp:BoundField HeaderText="Total" DataField="ValorPedido" DataFormatString='{0:C}' />
			                    <asp:BoundField HeaderText="Dinheiro" DataField="Dinheiro" DataFormatString='{0:C}' />
			                    <asp:BoundField HeaderText="Cheque" DataField="Cheque" DataFormatString='{0:C}' />
			                    <asp:BoundField HeaderText="Boleto" DataField="Boleto" DataFormatString='{0:C}' />
			                    <asp:BoundField HeaderText="Total Recebido" DataField="TotalRecebido" DataFormatString='{0:C}' />
			                    <asp:BoundField HeaderText="Status" DataField="Status" SortExpression="StatusPedido" />
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

