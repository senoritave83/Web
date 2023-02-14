<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Pedido.aspx.vb" Inherits="Pages.Pedidos.Pedido" title="Untitled Page" %>

<%@ Register src="../controls/Localizacao.ascx" tagname="Localizacao" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class='EditArea'>
		<div class='divEditArea' style="width:100%">
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField fl' style="width:24%" runat='server' id='trNumeroPedido' visible='<%$Settings: visible, Pedido.NumeroPedido, true %>' >
				<div class='tdFieldHeader cb fl'>
					N&uacute;mero do Pedido:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblNumeroPedido' Font-Bold='true' />
				</div>
			</div>
			<div class='trField fl' style="width:30%"  runat='server'  id='trStatusPedido' visible='<%$Settings: visible, Pedido.StatusPedido, true %>' >
				<div class='tdFieldHeader fl'>
					Status:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblStatus' Font-Bold='true' />
				</div>
			</div>
			<div class='trField fl' style="width:40%" runat='server'  id='trDataEmissao' >
				<div class='tdFieldHeader cb fl'>
					Data de Emiss&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblDataEmissao' Font-Bold='true' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl'  style="width:49%" runat='server' id='Div1' visible='<%$Settings: visible, Pedido.Codigo, true %>' >
				<div class='tdFieldHeader fl'>
					C&oacute;digo Interno:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCodigo' />
				</div>
			</div>
			<div class='trField fl' style="width:49%" runat='server' id='trDataEntrega' visible='<%$Settings: visible, Pedido.DataEntrega, true %>' >
				<div class='tdFieldHeader fl'>
					Data de Entrega:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblDataEntrega' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl' style="width:49%" runat='server'  id='Div4' visible='<%$Settings: visible, Visita.IDCliente, true %>' >
				<div class='tdFieldHeader cb fl'>
					C&oacute;digo Cliente:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblIDCliente' />
				</div>
			</div>
			<div class='trField fl' style="width:49%" runat='server'  id='trCliente' visible='<%$Settings: visible, Visita.Cliente, true %>' >
				<div class='tdFieldHeader cb fl'>
					Cliente:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCliente' />
				</div>
			</div>
            <div class='trField fl' style="width:49%"  runat='server' id='Div5' visible='<%$Settings: visible, Pedido.CodigoVendedor, true %>' >
				<div class='tdFieldHeader fl'>
					C&oacute;digo Vendedor:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCodigoVendedor' />
				</div>
			</div>
            <div class='trField fl' style="width:49%"  runat='server' id='trVendedor' visible='<%$Settings: visible, Pedido.Vendedor, true %>' >
				<div class='tdFieldHeader fl'>
					Vendedor:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblVendedor' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl' style="width:49%"  runat='server'  id='trIDCondicao' visible='<%$Settings: visible, Pedido.Condicao, true %>' >
				<div class='tdFieldHeader fl'>
					Condi&ccedil;&atilde;o de Pagto:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblCondicao' />
				</div>
			</div>
			<div class='trField fl' style="width:49%"  runat='server'  id='trFormaPagamento' visible='<%$Settings: visible, Pedido.FormaPagamento, true %>' >
				<div class='tdFieldHeader fl'>
					Forma de Pagto:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblFormaPagamento' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl' style="width:49%"  runat='server'  id='trTransporte' visible='<%$Settings: visible, Pedido.Transporte, true %>' >
				<div class='tdFieldHeader fl'>
					Transporte:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblTransporte' />
				</div>
			</div>
			<div class='trField fl' style="width:49%"  runat='server'  id='trInsumo' visible='<%$Settings: visible, Pedido.Insumo, true %>' >
				<div class='tdFieldHeader fl'>
					Insumo:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblInsumo' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl' style="width:100%" runat='server'  id='trEndereco' visible='<%$Settings: visible, Pedido.EnderecoEntrega, true %>' >
				<div class='tdFieldHeader fl'>
					Endere&ccedil;o de Entrega:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblEnderecoEntrega' />
				</div>
			</div>
			<div class='trField fl' style="width:100%" runat='server'  id='Div2' visible='<%$Settings: visible, Pedido.EnderecoFaturamento, true %>' >
				<div class='tdFieldHeader fl'>
					Endere&ccedil;o de Faturamento:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblEnderecoFaturamento' />
				</div>
			</div>
			<div class='trField fl' style="width:100%" runat='server'  id='Div3' visible='<%$Settings: visible, Pedido.EnderecoCobranca, true %>' >
				<div class='tdFieldHeader fl'>
					Endere&ccedil;o de Cobran&ccedil;a:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblEnderecoCobranca' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl' style="width:49%" runat='server'  id='trDesconto' visible='<%$Settings: visible, Pedido.Desconto, false %>' >
				<div class='tdFieldHeader fl'>
					Desconto:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblDesconto' />
				</div>
			</div>
			<div class='trField fl' style="width:49%" runat='server' id='trSituacaoPedido' visible='<%$Settings: visible, Pedido.SituacaoPedido, false %>' >
				<div class='tdFieldHeader fl'>
					Situa&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat="server" ID="lblSituacao" />
				</div>
			</div>		
			<div class='trField fl' style="width:49%" runat='server'  id='trIDVisita' visible='<%$Settings: visible, Pedido.IDVisita, false %>' >
				<div class='tdFieldHeader fl'>
					Visita:
				</div>
				<div class='tdField fl'>
					<asp:HyperLink runat='server' ID='lnkVisita' />
				</div>
			</div>
			<div class='trField fl' style="width:49%" runat='server'  id='trlocalizacao' visible='<%$Settings: visible, Pedido.Localizacao, false %>' >
				<div class='tdFieldHeader fl'>
					Localiza&ccedil&atilde;o:
				</div>
				<div class='tdField fl'>
					<uc1:Localizacao ID="Localizacao1" runat="server" />
				</div>
			</div>		
		</div>
	</div>
	Itens do Pedido
	<div class='ListArea'>
	    <asp:GridView runat='server' ID='grdItens' AutoGenerateColumns='false'>
	        <HeaderStyle HorizontalAlign='Left' />
			<Columns>
			    <asp:BoundField DataField='Codigo' HeaderText='C&oacute;digo' />
			    <asp:BoundField DataField='DESCRICAO' HeaderText='Descri&ccedil;&atilde;o' />
			    <asp:TemplateField HeaderText="Pre&ccedil;o Unit." visible='<%$Settings: visible, Pedido.PrecoBase, true %>'>
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#FormatCurrency(Eval("PrecoBase"), 2)%>
					    </font>
				    </ItemTemplate>
			    </asp:TemplateField>
			    <asp:TemplateField HeaderText="Desc." visible='<%$Settings: visible, Pedido.ItemDesconto, true %>'>
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#FormatPercent(Eval("Desconto"), 2)%>
					    </font>
				    </ItemTemplate>
			    </asp:TemplateField>
			    <asp:TemplateField HeaderText="Pre&ccedil;o Final" visible='<%$Settings: visible, Pedido.PrecoUnitario, true %>'>
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#FormatCurrency(Eval("VALORUNITARIO"), 2)%>
					    </font>
				    </ItemTemplate>
			    </asp:TemplateField>
			    <asp:BoundField DataField='Quantidade' HeaderText='Qtd.' />
			    <asp:TemplateField HeaderText="Total" ItemStyle-Width="80" visible='<%$Settings: visible, Pedido.ItemTotal, true %>'>
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#FormatCurrency(Eval("Total"), 2)%>
					    </font>
				    </ItemTemplate>
			    </asp:TemplateField>
		    </Columns>
	    </asp:GridView>
	    <div id='divTotal'>
	        <asp:PlaceHolder runat='server' ID='plhTotal' visible='<%$Settings: visible, Pedido.Total, true %>'>
    		    <asp:Literal ID="ltrSubTotal" Runat="server"></asp:Literal>
    		    <asp:Literal ID="ltrDesconto" Runat="server"></asp:Literal>
    		    <asp:Literal ID="ltrTotal" Runat="server">Total R$ 0,00</asp:Literal>
	        </asp:PlaceHolder>
	    </div>
    </div> 	
    <div class='AreaBotoes'>
        <asp:Button runat="server" ID="btnVoltar" CssClass="Botao" Text=" Voltar " />
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

