<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Pedido.aspx.vb" Inherits="Pages.Pedidos.Pedido" title="Untitled Page" %>

<%@ Register src="../controls/Localizacao.ascx" tagname="Localizacao" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class='EditArea'>
		<div class='divEditArea' style="width:100%">
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField fl' style="width:49%" runat='server' id='trNumeroPedido' visible='<%$Settings: visible, Pedido.NumeroPedido, true %>' >
				<div class='tdFieldHeader cb fl'>
					N&uacute;mero do Pedido:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblNumeroPedido' Font-Bold='true' />
				</div>
			</div>
			<div class='trField fl' style="width:49%"  runat='server'  id='trStatusPedido' visible='<%$Settings: visible, Pedido.StatusPedido, true %>' >
				<div class='tdFieldHeader fl'>
					Status:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblStatus' Font-Bold='true' />
				</div>
			</div>
			<div class='trField fl' style="width:100%" runat='server'  id='trCliente' visible='<%$Settings: visible, Visita.Cliente, true %>' >
				<div class='tdFieldHeader cb fl'>
					Cliente:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCliente' />
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
			<div class='trField fl' style="width:49%" runat='server'  id='trDataEmissao' >
				<div class='tdFieldHeader cb fl'>
					Data de Emiss&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblDataEmissao' />
				</div>
			</div>
			<div class='trField fl' style="width:49%"  runat='server' id='trDataEntrega' visible='<%$Settings: visible, Pedido.DataEntrega, false %>' >
				<div class='tdFieldHeader fl'>
					Data de Entrega:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblDataEntrega' />
				</div>
			</div>
			<div class='trField fl' style="width:49%"  runat='server'  id='trIDCondicao' visible='<%$Settings: visible, Pedido.Condicao, false %>' >
				<div class='tdFieldHeader fl'>
					Condi&ccedil;&atilde;o de Pagto:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblCondicao' />
				</div>
			</div>
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
			<div class='trField fl' style="width:49%" runat='server'  id='trIDVisita' visible='<%$Settings: visible, Pedido.IDVisita, true %>' >
				<div class='tdFieldHeader fl'>
					Visita:
				</div>
				<div class='tdField fl'>
					<asp:HyperLink runat='server' ID='lnkVisita' />
				</div>
			</div>
			<div class='trField fl' style="width:49%" runat='server'  id='trlocalizacao' visible='<%$Settings: visible, Pedido.Localizacao, true %>' >
				<div class='tdFieldHeader fl'>
					Localiza&ccedil&atilde;o:
				</div>
				<div class='tdField fl'>
					<uc1:Localizacao ID="Localizacao1" runat="server" />
				</div>
			</div>	
			<div class='trField fl' style='width:100%' runat='server'  id='trObservacao' visible='<%$Settings: visible, Pedido.Observacao, true %>'>
				<div class='tdFieldHeader fl'>
					Observa&ccedil&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblObservacao'></asp:Label>
				</div>
			</div>
		</div>
	</div>
	Itens do Pedido
	<div class='ListArea'>
	    <asp:GridView runat='server' ID='grdItens' AutoGenerateColumns='false'>
	        <HeaderStyle HorizontalAlign='Left' />
			<Columns>
			    <asp:BoundField DataField='Quantidade' HeaderText='Qtd.' />
			    <asp:BoundField DataField='Codigo' HeaderText='C&oacute;digo' />
			    <asp:BoundField DataField='DESCRICAO' HeaderText='Descri&ccedil;&atilde;o' />
			    <asp:TemplateField HeaderText="Pre&ccedil;o Unit&aacute;rio" visible='<%$Settings: visible, Pedido.PrecoUnitario, false %>'>
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#FormatCurrency(Eval("VALORUNITARIO"), 2)%>
					    </font>
				    </ItemTemplate>
			    </asp:TemplateField>
			    <asp:TemplateField HeaderText="Desconto" visible='<%$Settings: visible, Pedido.ItemDesconto, true %>'>
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#FormatNumber(Eval("Desconto"), 2)%>
					    </font>
				    </ItemTemplate>
			    </asp:TemplateField>
			    <asp:TemplateField HeaderText="Total" ItemStyle-Width="80" visible='<%$Settings: visible, Pedido.ItemTotal, false %>'>
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#FormatCurrency(Eval("Total"), 2)%>
					    </font>
				    </ItemTemplate>
			    </asp:TemplateField>
		    </Columns>
	    </asp:GridView>
	    <div id='divTotal'>
	        <asp:PlaceHolder runat='server' ID='plhTotal' visible='<%$Settings: visible, Pedido.Total, false %>'>
    		    <asp:Literal ID="ltrSubTotal" Runat="server"></asp:Literal>
    		    <asp:Literal ID="ltrDesconto" Runat="server"></asp:Literal>
    		    <asp:Literal ID="ltrTotal" Runat="server">Total R$ 0,00</asp:Literal>
	        </asp:PlaceHolder>
	    </div>
    </div> 	
    <div class='AreaBotoes'>
        <asp:Button runat="server" ID="btnVoltar" CssClass="Botao" Text=" Voltar " />
        <asp:Button runat="server" ID="btnCancelar" CssClass="Botao" Text=" Cancelar " 
            Visible="False" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior. &nbsp &nbsp
		        </asp:Localize>
		        <asp:Localize runat='server' ID='lblCancelar' Visible="False">
			        <b>Cancelar:</b> Cancelar o pedido no banco de dados.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

