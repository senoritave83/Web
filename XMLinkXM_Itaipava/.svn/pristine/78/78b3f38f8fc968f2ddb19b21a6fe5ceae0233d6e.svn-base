<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Pedido.aspx.vb" Inherits="Pages.Pedidos.Pedido" title="Untitled Page" %>

<%@ Register src="../controls/Localizacao.ascx" tagname="Localizacao" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat='server' ID='ScriptManager1' />
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server' id='trNumeroPedido' visible='<%$Settings: visible, Pedido.NumeroPedido, true %>' >
				<div class='tdFieldHeader cb fl'>
					N&uacute;mero do Pedido:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblNumeroPedido' Font-Bold='true' />
				</div>
			</div>
			<div class='trField fr' runat='server' style="width:40%"  id='trStatusPedido' visible='<%$Settings: visible, Pedido.StatusPedido, true %>' >
				<div class='tdFieldHeader fl'>
					Status:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblStatus' Font-Bold='true' />
				</div>
			</div>
			<div class='trField fr' runat='server' style="width:40%"  id='trTipoPedido' visible='<%$Settings: visible, Pedido.TipoPedido, true %>' >
				<div class='tdFieldHeader fl'>
					Tipo de Pedido:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblTipoPedido' Font-Bold='true' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCliente' visible='<%$Settings: visible, Visita.Cliente, true %>' >
				<div class='tdFieldHeader cb fl'>
					Cliente:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCliente' />
				</div>
			</div>
            <div class='trField fr' runat='server' style="width:40%"  id='trVendedor' visible='<%$Settings: visible, Pedido.Vendedor, true %>' >
				<div class='tdFieldHeader fl'>
					Vendedor:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblVendedor' />
				</div>
			</div>

			<div class='trField cb' runat='server'  id='trDataEmissao' >
				<div class='tdFieldHeader cb fl'>
					Data de Emiss&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblDataEmissao' />
				</div>
			</div>
			<div class='trField fr' runat='server' style="width:40%" id='trIDCondicao' >
				<div class='tdFieldHeader fl'>
					Condi&ccedil;&atilde;o de Pagto:
				</div>
				<div class='tdField fl'>
                     <asp:DropDownList runat='server' ID='cboIDCondicaoPagto' DataValueField='IDCondicao' DataTextField='Condicao' Enabled='false' />
                     <asp:LinkButton runat="server" ID='lnkCondicaoPagto' Text='Alterar' Visible="false"/>
                     <asp:Button runat="server" ID='btnGravarCondicao' Text='Gravar' Visible="false" />
                     <asp:Button runat="server" ID='btnVoltarCondicao' Text='Voltar' Visible="false" />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trIDVisita' visible='<%$Settings: visible, Pedido.IDVisita, true %>' >
				<div class='tdFieldHeader cb fl'>
					Visita:
				</div>
				<div class='tdField fl'>
					<asp:HyperLink runat='server' ID='lnkVisita' />
				</div>
			</div>
			<div class='trField fr' style="width:40%" runat='server'  id='trlocalizacao' visible='<%$Settings: visible, Pedido.Localizacao, true %>' >
				<div class='tdFieldHeader fl'>
					Localiza&ccedil&atilde;o:
				</div>
				<div class='tdField fl'>
					<uc1:Localizacao ID="Localizacao1" runat="server" />
				</div>
			</div>		
			<div class='trField cb' runat='server'  id='trSituacaoPedido' visible='<%$Settings: visible, Pedido.SituacaoPedido, false %>' >
				<div class='tdFieldHeader cb fl'>
					Situa&ccedil;&atilde;o do Pedido:
				</div>
				<div class='tdField fl'>
					<asp:Label runat="server" ID="lblSituacao" />
				</div>
			</div>		
			<div class='trField fr' runat='server'  style="width:40%" id='trDataEntrega' visible='<%$Settings: visible, Pedido.DataEntrega, false %>' >
				<div class='tdFieldHeader fl'>
					Data de Entrega:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblDataEntrega' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='Div1' visible='<%$Settings: visible, Pedido.Historico, true %>' >
				<div class='tdFieldHeader cb fl'>
					Hist&oacute;rico:
				</div>
				<div class='tdField fl'>
	                <asp:GridView runat='server' ID='grdHistorico' AutoGenerateColumns='false' SkinID='GridHistorico'>
	                    <Columns>
	                        <asp:TemplateField>
	                            <ItemTemplate>
	                                <%# Eval("Data") %> - <%#Eval("Historico")%>
	                            </ItemTemplate>
	                        </asp:TemplateField>
	                    </Columns>
	                </asp:GridView>
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
                <asp:TemplateField HeaderText="Tipo">
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#IIf(Eval("Tipo")=1,"V","B")%>
					    </font>
				    </ItemTemplate>
			    </asp:TemplateField>
                <asp:TemplateField HeaderText="Produto Bonific." ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#Eval("IdProdutoReferencia")%>
					    </font>
				    </ItemTemplate>
			    </asp:TemplateField>
				<asp:TemplateField HeaderText="Excluir Item">
					<ItemTemplate>
                        <asp:ImageButton ID="imgRot" Visible="false" runat='server' CommandName="ExcluirItem" CommandArgument='<%# Eval("IDItemPedido") %>' ImageUrl="~/imagens/Excluir.gif" />
					</ItemTemplate>
				</asp:TemplateField>
		    </Columns>
	    </asp:GridView>
	    <div id='divTotal'>
	        <asp:PlaceHolder runat='server' ID='plhTotal'>
    		    <asp:Literal ID="ltrTotal" Runat="server">Total R$ 0,00</asp:Literal>
	        </asp:PlaceHolder>
	    </div>
    </div> 	
    <div class='AreaBotoes'>
                <asp:Button runat="server" ID="btnVoltar" CssClass="Botao" Text=" Voltar " />
                <asp:Button runat='server' ID='btnAprovar' Text='Aprovar Pedido' />
                <asp:Button runat='server' ID='btnReprovar' Text='Reprovar Pedido' />
                <asp:Label runat='server' ID='lblEntrarMotivo' Text='Digite o motivo' ForeColor='White' />
                <asp:TextBox runat='server' ID='txtMotivo' TextMode='MultiLine' Rows='3' Width='300px'></asp:TextBox>
                <asp:Button runat='server' ID='btnConfirmar' Text='Confirmar' />
                <asp:Button runat='server' ID='btnCancelar' Text='Cancelar' />
                <asp:Button runat='server' ID='btnCancelarExportacao' OnClientClick="return confirm('Confirma o cancelamento da exportação do pedido ?')" Text='Cancelar Exporta&ccedil;&atilde;o' Visible='false' />
                <asp:Button runat='server' ID='btnExportar' OnClientClick="return confirm('Confirma a exportação do pedido ?')" Text='Exportar Pedido' Visible='false' />
                <asp:Button runat='server' ID='btnCancelarPedido' OnClientClick="return confirm('Confirma o cancelamento do pedido ?')" Text='Cancelar Pedido' Visible='false' />
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

