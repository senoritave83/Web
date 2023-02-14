<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="negociacao.aspx.vb" Inherits="Pedidos_negociacao" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class='EditArea'>
		<div class='divEditArea' style="width:100%">
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField fl' style="width:49%" runat='server' id='trNumeroPedido' visible='<%$Settings: visible, Negociacao.NumeroPedido, true %>' >
				<div class='tdFieldHeader cb fl'>
					N. da Negocia&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblNumeroPedido' Font-Bold='true' />
				</div>
			</div>
			<div class='trField fl' style="width:49%" runat='server'  id='trDataEmissao' >
				<div class='tdFieldHeader cb fl'>
					Data de Emiss&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblDataEmissao' Font-Bold='true' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl' style="width:49%" runat='server'  id='Div1' visible='<%$Settings: visible, Negociacao.Codigo, true %>' >
				<div class='tdFieldHeader fl'>
					C&oacute;digo Interno:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblCodigo' Font-Bold='true' />
				</div>
			</div>
			<div class='trField fl' style="width:49%" runat='server' id='trDataEntrega' visible='<%$Settings: visible, Negociacao.DataEntrega, true %>' >
				<div class='tdFieldHeader fl'>
					Data de Entrega:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblDataEntrega' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl' style="width:49%" runat='server'  id='trCliente' visible='<%$Settings: visible, Visita.IDCliente, true %>' >
				<div class='tdFieldHeader cb fl'>
					C&oacute;digo Cliente:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblIDCliente' />
				</div>
			</div>
            <div class='trField fl' style="width:49%"  runat='server' id='Div3' visible='<%$Settings: visible, Negociacao.CodigoVendedor, true %>' >
				<div class='tdFieldHeader fl'>
					C&oacute;digo Vendedor:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCodigoVendedor' />
				</div>
			</div>
			<div class='trField fl' style="width:49%" runat='server'  id='Div2' visible='<%$Settings: visible, Visita.Cliente, true %>' >
				<div class='tdFieldHeader cb fl'>
					Nome do Cliente:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCliente' />
				</div>
			</div>
            <div class='trField fl' style="width:49%"  runat='server' id='trVendedor' visible='<%$Settings: visible, Negociacao.Vendedor, true %>' >
				<div class='tdFieldHeader fl'>
					Nome do Vendedor:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblVendedor' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl' style="width:49%"  runat='server'  id='trIDCondicao' visible='<%$Settings: visible, Negociacao.Condicao, true %>' >
				<div class='tdFieldHeader fl'>
					Condi&ccedil;&atilde;o de Pagto:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblCondicao' />
				</div>
			</div>
			<div class='trField fl' style="width:49%" >
				<div class='tdFieldHeader fl'>
					Refer&ecirc;ncia:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblReferencia' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl' style="width:49%" >
				<div class='tdFieldHeader fl'>
					Status da Ordem:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblOrdemHeader' />
				</div>
			</div>
			<div class='trField fl' style="width:49%" >
				<div class='tdFieldHeader fl'>
					Negocia&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblMarketCode' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl' style="width:49%" >
				<div class='tdFieldHeader fl'>
					Prioridade:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblPrioridade' />
				</div>
			</div>
			<div class='trField fl' style="width:49%" >
				<div class='tdFieldHeader fl'>
					N&uacute;mero Compra:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblNumeroCompra' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl' style="width:100%">
				<div class='tdFieldHeader fl'>
					Observa&ccedil&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblObservacao'></asp:Label>
				</div>
			</div>		
		</div>
	</div>
	Itens da Negocia&ccedil;&atilde;o
	<div class='ListArea'>
	    <asp:GridView runat='server' ID='grdItens' AutoGenerateColumns='false' ShowFooter='true'>
	        <HeaderStyle HorizontalAlign='Left' />
			<Columns>
			    <asp:BoundField DataField='Codigo' HeaderText='C&oacute;digo' />
			    <asp:BoundField DataField='DESCRICAO' HeaderText='Descri&ccedil;&atilde;o' />
			    <asp:BoundField DataField='Status' HeaderText='Status' />
			    <asp:BoundField DataField='Quantidade' HeaderText='Qtd.' />
			    <asp:TemplateField HeaderText="Vl Total Tabela" visible='<%$Settings: visible, Negociacao.TotalTabela, true %>'>
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#FormatCurrency(Soma.Add(Eval("PrecoBase") * Eval("Quantidade"), "TotalTabela"), 2)%>
					    </font>
				    </ItemTemplate>
				    <FooterTemplate>
				        <%# FormatCurrency(Soma.Item("TotalTabela").Sum, 2) %>
				    </FooterTemplate>
			    </asp:TemplateField>
			    <asp:TemplateField HeaderText="Desconto" visible='<%$Settings: visible, Negociacao.ItemDesconto, true %>'>
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#FormatPercent(Eval("Desconto"), 2)%>
					    </font>
				    </ItemTemplate>
				    <FooterTemplate>
				        <%#FormatPercent(Me.CalcularDesconto(Soma.Item("TotalTabela").Sum, Soma.Item("TotalNegociado").Sum), 3)%>
				    </FooterTemplate>
			    </asp:TemplateField>
			    <asp:TemplateField HeaderText="Vl Total Neg" visible='<%$Settings: visible, Negociacao.TotalNegociado, true %>'>
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#FormatCurrency((Soma.Add(Eval("VALORUNITARIO") * Eval("Quantidade"), "TotalNegociado")),2)%>
					    </font>
				    </ItemTemplate>
				    <FooterTemplate>
				        <%# FormatCurrency(Soma.Item("TotalNegociado").Sum, 2) %>
				    </FooterTemplate>
			    </asp:TemplateField>
			    <asp:TemplateField HeaderText="Vl Unit Neg" ItemStyle-Width="80" visible='<%$Settings: visible, Negociacao.Unitario, true %>'>
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#FormatCurrency(Eval("VALORUNITARIO"), 2)%>
					    </font>
				    </ItemTemplate>
			    </asp:TemplateField>
		    </Columns>
	    </asp:GridView>
	    <div id='divTotal'>
	        <asp:PlaceHolder runat='server' ID='plhTotal' visible='<%$Settings: visible, Negociacao.Total, true %>'>
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

