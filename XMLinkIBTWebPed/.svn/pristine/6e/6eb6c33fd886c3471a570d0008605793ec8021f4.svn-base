<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="cliente.aspx.vb" Inherits="pedidos_cliente" title="XMLink" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
				<td class='tdField'>
					<asp:Label runat='server' ID='lblCodigo' />
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
				    Data:
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblData' />
				</td>
			    <td class='tdFieldHeader'>
			        Status:
				</td>
			    <td class='tdField'>
				    <asp:Label runat='server' ID='lblStatus' />
			    </td>
		    </tr>
			<tr class='trField' runat='server' id='trJustificativa'>
				<td class='tdFieldHeader'>
				    Justificativa: 
				</td>
				<td class='tdField' colspan='3'>
                    <asp:Label runat='server' ID='lblJustificativa' />    
				</td>
			</tr>

			<tr class="trEditFooter">
			    <td colspan='4'>&nbsp;</td>
			</tr>
		</table>
	</div>
    Pedidos realizados
	<div class='ListArea'>
        <asp:GridView runat='server' id='grdPedidos' AutoGenerateColumns='false'>
            <HeaderStyle HorizontalAlign='Left' />
            <columns>
                <asp:BoundField DataField='NumeroPedido' HeaderText='Numero' />
                <asp:BoundField DataField='StatusPedido' HeaderText='Status' />
                <asp:BoundField DataField='DataEmissao' HeaderText='Data' />
                <asp:BoundField DataField='Itens' HeaderText='Itens' />
                <asp:TemplateField HeaderText='Total'>
                    <ItemTemplate>
                        <%# formatCurrency(Eval("Total"),2) %>
                    </ItemTemplate> 
                </asp:TemplateField> 
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='<%# "produtos.aspx?idpedido=" & Server.URLEncode(Eval("IDPedido").toString()) & "&idcliente=" & Eval("IDCliente") %>' runat='server' id="lnkEditar" >Editar</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </columns>
        </asp:GridView>
    </div> 
    <br />
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnVoltar' Text='Voltar' />
        <asp:Button runat='server' ID='btnNovoPedido' Text='Novo Pedido' />
        <asp:Button runat='server' ID='btnBonificacao' Text='Bonifica&ccedil;&atilde;o' Visible='False' />
        <asp:Button runat='server' ID='btnJustificar' Text='Justificar' />
        <asp:Button runat='server' ID='btnCancelarJustificativa' Text='Cancelar Justificativa' />
        <asp:Button runat='server' ID='btnFechar' Text='Fechar atendimento' />
        <asp:Button runat='server' ID='btnReabrir' Text='Reabrir atendimento' />
    </div>


</asp:Content>

