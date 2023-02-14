<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Pedido.aspx.vb" Inherits="Pages.Pedidos.Pedido" title="Untitled Page" %>

<%@ Register src="../controls/Localizacao.ascx" tagname="Localizacao" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
					C&oacute;digo Interno:
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblCodigo' />
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
	        <tr class='trField'>
		        <td class='tdFieldHeader'>
		            <asp:Label runat='server' ID='lblTextoIDOperacao'>
				        Condi&ccedil;&atilde;o de Pagto:
			        </asp:Label> 
		        </td>
		        <td class='tdField'>
			        <asp:Label runat='server' ID='lblCondicao' />
		        </td>
		        <td class='tdFieldHeader'>
		            <asp:Label runat='server' ID='lblTextoCodigoJDE'>
				        Forma de Pagto:
			        </asp:Label> 
		        </td>
		        <td class='tdField'>
			        <asp:Label runat='server' ID='lblForma' />
		        </td>
	        </tr>
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
			<tr runat=server id='rowObservacao' class='trField'>
			    <td class='tdFieldHeader'>
			        Observa&ccedil;&otilde;es:
			    </td>
			    <td class='tdField' colspan='3'>
				    <asp:Label Runat=server ID='lblObservacao'></asp:Label>
			    </td>
			</tr>
			<tr class="trEditFooter">
			    <td colspan='4'>&nbsp;</td>
			</tr>
		</table>
	</div>
	<asp:PlaceHolder runat='server' ID='plhListaItens'>
	    <div class='ListArea'>
	        <asp:GridView runat='server' ID='grdItens' AutoGenerateColumns='false'>
	            <HeaderStyle HorizontalAlign='Left' />
			    <Columns>
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
	            <br />
	            <asp:PlaceHolder runat='server' ID='plhSubTotal'>
		        <asp:Literal ID="ltrSubTotal" Runat="server">SubTotal R$ 0,00</asp:Literal><br />
		        <asp:Literal ID="ltrDesconto" Runat="server">Desconto R$ 0,00</asp:Literal><br />
	            </asp:PlaceHolder>
		        <asp:Literal ID="ltrTotal" Runat="server">Total R$ 0,00</asp:Literal>
	        </div>
	        <div>
	            <asp:Literal ID="ltrQuantidadeItens" Runat="server"></asp:Literal>
	        </div>
        </div> 	
        <div class='AreaBotoes'>
            <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Pedidos.aspx'" />
            <asp:Button runat='server' ID='btnAprovar' Text='Aprovar' />
            <asp:Button runat='server' ID='btnCancelar' Text='Cancelar' />
        </div>
	</asp:PlaceHolder>
	<asp:PlaceHolder runat='server' ID='plhAprovacao' Visible='False'>
        <div class='AreaBotoes'>
            <asp:Label Runat='server' ID='lblMensagem' CssClass='TextDefault' Font-Size='10pt' Font-Bold='True' />
            <br />
            <asp:PlaceHolder runat='server' ID='plhMotivo'>
                <br /><br />
                Motivo:<br />
                <asp:TextBox Runat=server ID='txtMotivo' TextMode=MultiLine Width=100% Rows=4></asp:TextBox>
                <br />
            </asp:PlaceHolder>
            <asp:Button Runat=server ID='btnSim' CssClass='Botao' Text=' Sim ' />
            <asp:Button Runat=server ID="btnNao" CssClass='Botao' Text=' N&atilde;o ' />
        </div> 
	</asp:PlaceHolder>
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

