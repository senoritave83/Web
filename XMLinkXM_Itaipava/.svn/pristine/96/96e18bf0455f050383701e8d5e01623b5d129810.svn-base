<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Visita.aspx.vb" Inherits="Pages.Pedidos.Visita" title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="../controls/Localizacao.ascx" tagname="Localizacao" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager runat='server'></asp:ScriptManager>
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
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
					Endere&ccedil;o do Cliente:
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
	                <uc1:Localizacao ID="LocalizacaoCliente" runat="server" />
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
					<uc1:Localizacao ID="LocalizacaoInicio" runat="server" />
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
					<uc1:Localizacao ID="LocalizacaoFinal" runat="server" />
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
	                        <asp:GridView runat='server' ID='grdItens' SkinID='GridItensPedido' AutoGenerateColumns='false' DataSource='<%# ped.ListItensPedido(Eval("IDPedido").ToString) %>' style="float:left;">
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
    
    <div class='AreaBotoes'>
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

