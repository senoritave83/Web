<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="resumo.aspx.vb" Inherits="pedidos_resumo" title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat='server' />
   <div class='EditArea' >
		<table id='tblEditArea'>
			<tr class="trEditHeader">
			    <td colspan='4'>&nbsp;</td>
			</tr>
			<tr class='trEditSpace'>
			    <td colspan='4'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    Cliente:
				</td>
				<td class='tdField' colspan='3'>
					<asp:Label runat='server' ID='lblCliente' />
				</td>
			</tr>
            <tr class='trField'>
				<td class='tdFieldHeader'>
				    Codigo:
				</td>
				<td class='tdField' width="30%">
					<asp:Label runat='server' ID='lblCodigoCliente' />
				</td>
			    <td class='tdFieldHeader'>
			        CNPJ:
				</td>
			    <td class='tdField'>
				    <asp:Label runat='server' ID='lblCNPJ' />
			    </td>
		    </tr>
            <tr class='trField'>
				<td class='tdFieldHeader'>
				    Tipo:
				</td>
				<td class='tdField'>
                    <asp:Label runat='server' ID='lblIDTipoPedido' />
				</td>
                 <td class='tdFieldHeader'>
			        Opção:
				</td>
			    <td class='tdField'>
				    <asp:Label runat='server' ID='lblIDOpcao' />
			    </td>
            </tr>
            <tr class='trField'>
				<td class='tdFieldHeader'>
				    Condição de Pagto:
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblIDCondicao' />
				</td>
			    <td class='tdFieldHeader'>
			        Forma de Pagto:
				</td>
			    <td class='tdField'>
				    <asp:Label runat='server' ID='lblIDFormaPagamento' />
			    </td>
		    </tr>
		    <tr class='trField'>
                <td class='tdFieldHeader'>
                    Data de Criação:
                </td>
                <td class='tdField'>
					<asp:Label runat='server' ID='lblDataCriacao' />
				</td>
                <td class='tdFieldHeader'>
                    Data de Emissão:
                </td>
                <td class='tdField'>
                    <asp:Label runat='server' ID='lblDataEmissao' />
				</td>
		    </tr>
		    <tr class='trField'>
				<td class='tdFieldHeader'>
				    Data de Entrega:
				</td>
				<td class='tdField' colspan='3'>
					<asp:Label runat='server' ID='lblDataEntrega' /> 
				</td>
		    </tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    Observação: 
				</td>
				<td class='tdField' colspan='3'>
					<asp:Label runat='server' ID='lblObservacao' />
				</td>
			</tr>
			<tr class="trEditFooter">
			    <td colspan='4'>&nbsp;</td>
			</tr>
		</table>
	</div>
    <br />
    <div class='ListArea'>
	<asp:GridView runat='server' ID='grdProdutos' AutoGenerateColumns="false" DataKeyNames="IDItemPedido">
            <HeaderStyle HorizontalAlign='Left' />
            <Columns>
                <asp:BoundField DataField='Codigo' HeaderText='Codigo' />
                <asp:BoundField DataField='Descricao' HeaderText='Produto' />
                <asp:BoundField DataField='Quantidade' HeaderText='Quantidade' />
                <asp:BoundField DataField='ValorUnitario' HeaderText='Pre&ccedil;o Base' DataFormatString='{0:c}' Visible='false'/>
                <asp:BoundField DataField='Desconto' HeaderText='Desconto' />
                <asp:TemplateField HeaderText='Valor Venda' Visible='false'>
                    <ItemTemplate>
                        <%# FormatCurrency( Eval("ValorUnitario") * (100-Eval("Desconto")) / 100, 2)  %>
                    </ItemTemplate> 
                </asp:TemplateField>
                <asp:BoundField DataField='SubTotal' HeaderText='Sub-total' DataFormatString='{0:c}' Visible='false'/>
            </Columns>
        </asp:GridView>
        <div id='divTotal' style='display:none;' >
            <asp:PlaceHolder runat='server' ID='plhSubTotal' Visible='false'>
                Sub-Total: <b><asp:Literal runat='server' ID='ltrSubTotal'></asp:Literal></b><br />
                Desconto: <b><asp:Literal runat='server' ID='ltrDesconto'></asp:Literal></b><br />    
            </asp:PlaceHolder>
            Total: <b><asp:Literal runat='server' ID='ltrTotal'></asp:Literal></b>
	    </div>
	</div> 
    
    <asp:Button runat='server' ID='btnVoltar' Text='Voltar' />
    <asp:Button runat='server' ID='btnGravar' Text='Gravar' />

</asp:Content>

