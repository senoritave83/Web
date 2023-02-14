<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Pedido.aspx.vb" Inherits="Pages.Pedidos.Pedido" title="Untitled Page" %>

<%@ Register src="../controls/Localizacao.ascx" tagname="Localizacao" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type='text/javascript'>
    function fncConfirmDelete() {
        if (confirm("O Pedido será apagado do sistema!") == true)
            return true;
        else
            return false;
    }

    function MascaraMoeda(objTextBox, SeparadorMilesimo, SeparadorDecimal, e) {
        var sep = 0;
        var key = '';
        var i = j = 0;
        var len = len2 = 0;
        var strCheck = '0123456789';
        var aux = aux2 = '';
        var whichCode = (window.Event) ? e.which : e.keyCode;
        if (whichCode == 13) return true;
        key = String.fromCharCode(whichCode); // Valor para o código da Chave
        if (strCheck.indexOf(key) == -1) return false; // Chave inválida
        len = objTextBox.value.length;
        for (i = 0; i < len; i++)
            if ((objTextBox.value.charAt(i) != '0') && (objTextBox.value.charAt(i) != SeparadorDecimal)) break;
        aux = '';
        for (; i < len; i++)
            if (strCheck.indexOf(objTextBox.value.charAt(i)) != -1) aux += objTextBox.value.charAt(i);
        aux += key;
        len = aux.length;
        if (len == 0) objTextBox.value = '';
        if (len == 1) objTextBox.value = '0' + SeparadorDecimal + '0' + aux;
        if (len == 2) objTextBox.value = '0' + SeparadorDecimal + aux;
        if (len > 2) {
            aux2 = '';
            for (j = 0, i = len - 3; i >= 0; i--) {
                if (j == 3) {
                    aux2 += SeparadorMilesimo;
                    j = 0;
                }
                aux2 += aux.charAt(i);
                j++;
            }
            objTextBox.value = '';
            len2 = aux2.length;
            for (i = len2 - 1; i >= 0; i--)
                objTextBox.value += aux2.charAt(i);
            objTextBox.value += SeparadorDecimal + aux.substr(len - 2, len);
        }
        return false;
    }

</script>
<asp:Literal ID="ltrMsgBox" runat='server' Text="" />
    <div class='EditArea'>
		<table id='tblEditArea'>
			<tr class="trEditHeader">
			    <td colspan='4'>&nbsp;</td>
			</tr>
			<tr class='trEditSpace'>
			    <td colspan='4'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoIDCliente'>
						Cliente:
					</asp:Label> 
				</td>
				<td class='tdField' colspan='3'>
					<asp:Label runat='server' ID='lblCliente' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoIDVendedor'>
						Vendedor:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblVendedor' />
				</td>
			    <td class='tdFieldHeader'>
					Localiza&ccedil&atilde;o:
			    </td>
			    <td class='tdField'>
			        <uc1:Localizacao ID="Localizacao1" runat="server" />
			    </td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoNumeroPedido'>
						N&uacute;mero do Pedido:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblNumeroPedido' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoDataEmissao'>
						Data de Emiss&atilde;o:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblDataEmissao' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoTipoPedido'>
						Tipo do Pedido:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblTipoPedido' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoStatusPedido'>
						Status:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblStatus' />
				</td>
			</tr>
			<asp:PlaceHolder runat='server' ID='plhPedidoComum' Visible='False'>
			    <tr class='trField'>
				    <td class='tdFieldHeader'>
				        <asp:Label runat='server' ID='lblTextoDesconto'>
						    Desconto:
					    </asp:Label> 
				    </td>
				    <td class='tdField'>
					    <asp:Label runat='server' ID='lblDesconto' />
				    </td>
				    <td class='tdFieldHeader'>
				        <asp:Label runat='server' ID='lblTextoDataEntrega'>
						    Data de Entrega:
					    </asp:Label> 
				    </td>
				    <td class='tdField'>
					    <asp:Label runat='server' ID='lblDataEntrega' />
				    </td>
			    </tr>
			    <tr class='trField'>
				    <td class='tdFieldHeader'>
				        <asp:Label runat='server' ID='Label1'>
						    Op&ccedil;&atilde;o:
					    </asp:Label> 
				    </td>
				    <td class='tdField'>
					    <asp:Label runat='server' ID='lblOpcao' />
				    </td>
			    </tr>
			</asp:PlaceHolder>
			<asp:PlaceHolder runat='server' ID='plhPedidoFaturado' Visible='False'>
		        <tr class='trField'>
			        <td class='tdFieldHeader'>
			            <asp:Label runat='server' ID='lblTextoIDOperacao'>
					        Condi&ccedil;&atilde;o de Pagto:
				        </asp:Label> 
			        </td>
			        <td class='tdField'>
                        <asp:DropDownList runat="server" ID="cboIDCondicao" DataTextField="Condicao" DataValueField="IDCondicao" />
			        </td>
			        <td class='tdFieldHeader'>
			            <asp:Label runat='server' ID='lblTextoCodigoJDE'>
					        Forma de Pagto:
				        </asp:Label> 
			        </td>
			        <td class='tdField'>
                        <asp:DropDownList runat="server" ID="cboIDFormaPagamento" DataTextField="FormaPagamento" DataValueField="IDFormaPagamento" />
			        </td>
		        </tr>
                <tr>                    
                    <td class='tdFieldHeader'></td>
				    <td class='tdField'>
					    <asp:Button runat='server' ID='btnAlterar' Text="Alterar" />
				    </td>
                </tr>
		    </asp:PlaceHolder>
            <tr class='trField' runat='server'  id='trHistorico'>
		        <td valign="top" class='tdFieldHeader'>
			        Hist&oacute;rico:
		        </td>
                <td colspan='3'>
	                <asp:GridView runat='server' ID='grdHistorico' AutoGenerateColumns='false' SkinID='GridHistorico'>
	                    <Columns>
	                        <asp:TemplateField>
	                            <ItemTemplate>
	                                <%# Eval("Data") %> - <%#Eval("Historico")%>
	                            </ItemTemplate>
	                        </asp:TemplateField>
	                    </Columns>
	                </asp:GridView>
		        </td>
            </tr>    
			<tr class="trEditFooter">
			    <td colspan='4'>&nbsp;</td>
			</tr>
		</table>
	</div>		
	Itens Faturados
	<div class='ListArea'>
	    <asp:GridView runat='server' ID='grdItens' AutoGenerateColumns='false'>
	        <HeaderStyle HorizontalAlign='Left' />
			<Columns>
                 <asp:TemplateField HeaderText="" ItemStyle-Width="50">
				    <ItemTemplate>
				        <asp:ImageButton runat='server' ID="imgExc" Visible="true" CommandName="ExcluirItem" CommandArgument='<%# Eval("IDItemPedido") %>' ImageUrl="~/imagens/Excluir.gif" />
				    </ItemTemplate>
			    </asp:TemplateField>
			    <asp:BoundField DataField='Quantidade' HeaderText='Qtd.' />
			    <asp:BoundField DataField='Codigo' HeaderText='C&oacute;digo' />
			    <asp:BoundField DataField='DESCRICAO' HeaderText='Descri&ccedil;&atilde;o' />
			    <asp:TemplateField HeaderText="Pre&ccedil;o Unit&aacute;rio">
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#FormatCurrency(Eval("VALORUNITARIO"), 2)%>
					    </font>
				    </ItemTemplate>
			    </asp:TemplateField>
			    <asp:TemplateField HeaderText="Desc/Acresc">
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#FormatPercent(Eval("Desconto"), 2)%>
					    </font>
				    </ItemTemplate>
			    </asp:TemplateField>
			    <asp:TemplateField HeaderText="Total">
				    <ItemTemplate>
					    <font class="TextDefault">
						    <%#FormatCurrency(Eval("Total"), 2)%>
					    </font>
				    </ItemTemplate>
			    </asp:TemplateField>
                <asp:TemplateField>
				    <ItemTemplate>
					    <asp:LinkButton runat="server" ID="btnEditarItem" Visible="true" CommandName="EditarItem" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDItemPedido")%>' Text="<img src='../imagens/Editar.png' alt='' border='0'>" />
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

    <div runat="server" id="divEditarItemPed" class="EditArea" visible="false">
        <div class="txtBtn">Novo Preço Unitário R$:
            <asp:TextBox runat="server" ID="txtPrecoUnitario" MaxLength="10" onKeyPress="return(MascaraMoeda(this,'.',',',event))" ></asp:TextBox>
            <input type="button" runat='server' ID="btnGravarItemPedido" value="Gravar" />
        </div>            
    </div>

    <asp:PlaceHolder runat='server' ID='plhReposicao'>
        <br />
        <br />
        Itens Reposi&ccedil;&atilde;o
	    <div class='ListArea'>
	        <asp:GridView runat='server' ID='grdReposicao' AutoGenerateColumns='false'>
	            <HeaderStyle HorizontalAlign='Left' />
			    <Columns>
			        <asp:BoundField DataField='QuantidadeReposta' HeaderText='Qtd. Reposi&ccedil;&atilde;o' />
			        <asp:BoundField DataField='Codigo' HeaderText='C&oacute;digo' />
			        <asp:BoundField DataField='DESCRICAO' HeaderText='Descri&ccedil;&atilde;o' />
		        </Columns>
	        </asp:GridView>
        </div> 	
    </asp:PlaceHolder>
    <div class='AreaBotoes'>
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Pedidos.aspx'" />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" Enabled="false"/>
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
            <asp:Localize runat='server' ID='lclAjudaAlterar'>
		        <li>
			        <b>Alterar:</b> Altera a condi&ccedil;&atilde;o e a forma de pagamento.
                </li>
		    </asp:Localize>
            <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
            <li>
			    <b>Apagar:</b> Apaga o pedido do sistema.
            </li>
	    </ul>
    </div>
</asp:Content>

