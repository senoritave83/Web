<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="pedido.aspx.vb" Inherits="pedidos_pedido" title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:ScriptManager runat='server' />
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
				<td class='tdField'>
					<asp:Label runat='server' ID='lblCliente' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    Codigo:
				</td>
				<td class='tdField'>
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
                    <asp:DropDownList runat="server" ID="drpIdTipoPedido" >
                        <asp:ListItem Text="Venda" Value="1"></asp:ListItem>
                    </asp:DropDownList>
				</td>
                 <td class='tdFieldHeader'>
			        Opção:
				</td>
			    <td class='tdField'>
				    <asp:DropDownList runat="server" ID="drpIdOpcao" >
                        <asp:ListItem Text="Selecione a opção" Value="0" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Opção 1" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Opção 2" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator  runat='server' ID='CompareValidator4' Operator="GreaterThan" Type="Integer" ValueToCompare="0" ControlToValidate='drpIdOpcao' ErrorMessage='Selecione uma opção' Display='Dynamic' Text="*" />
			    </td>
            </tr>
            <tr class='trField'>
				<td class='tdFieldHeader'>
				    Condição de Pagto:
				</td>
				<td class='tdField'>
					<asp:DropDownList runat="server" ID="cboIDCondicao" DataTextField="Condicao" DataValueField="IDCondicao" />
                    <asp:CompareValidator  runat='server' ID='CompareValidator1' Operator="GreaterThan" Type="Integer" ValueToCompare="0" ControlToValidate='cboIDCondicao' ErrorMessage='Selecione uma condição de pagamento' Display='Dynamic' Text="*" />
				</td>
			    <td class='tdFieldHeader'>
			        Forma de Pagto:
				</td>
			    <td class='tdField'>
				    <asp:DropDownList runat="server" ID="cboIDFormaPagamento" DataTextField="FormaPagamento" DataValueField="IDFormaPagamento" />
                    <asp:CompareValidator  runat='server' ID='CompareValidator2' Operator="GreaterThan" Type="Integer" ValueToCompare="0" ControlToValidate='cboIDFormaPagamento' ErrorMessage='Selecione uma forma de pagamento' Display='Dynamic' Text="*" />
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
                    <asp:TextBox runat='server' ID='txtDataEmissao'></asp:TextBox>
                    <cc1:CalendarExtender  ID="cal_txtDataEmissao" 
													        runat="server" 
													        TargetControlID="txtDataEmissao"
													        PopupPosition="Right"
													        PopupButtonID="imgCalendarInicial"
													        Format="dd/MM/yyyy"
													        />
                    <asp:CompareValidator  runat='server' ID='CompareValidator5' Operator='DataTypeCheck' Type="Date" ControlToValidate='txtDataEmissao' ErrorMessage='Por favor preencha corretamente a data de emissão' Display='Dynamic' Text="*" />
                    <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' ControlToValidate='txtDataEmissao' ErrorMessage='Por favor preencha a data de emissão' Display='Dynamic' Text="*" />
				</td>
		    </tr>
            <tr class='trField'>
				<td class='tdFieldHeader'>
				    Data de Entrega:
				</td>
				<td class='tdField'>
                    <asp:TextBox runat='server' ID='txtDataEntrega'></asp:TextBox>
                    <cc1:CalendarExtender  ID="cal_txtDataInicial" 
													        runat="server" 
													        TargetControlID="txtDataEntrega"
													        PopupPosition="Right"
													        PopupButtonID="imgCalendarInicial"
													        Format="dd/MM/yyyy"
													        />
                    <asp:CompareValidator  runat='server' ID='CompareValidator3' Operator='DataTypeCheck' Type="Date" ControlToValidate='txtDataEntrega' ErrorMessage='Por favor preencha corretamente a data de entrega' Display='Dynamic' Text="*" />
                    <asp:CompareValidator  runat='server' ID='valCompDataentrega' Operator="GreaterThanEqual" Type="Date" ControlToValidate='txtDataEntrega' ErrorMessage='A data de entrega não pode ser inferior a 1 dia' Display='Dynamic' Text="*" />
                    <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator4' ControlToValidate='txtDataEntrega' ErrorMessage='Por favor preencha a data de entrega' Display='Dynamic' Text="*" />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    Observação: 
				</td>
				<td class='tdField' colspan='3'>
					<asp:TextBox TextMode="MultiLine" Columns=100 Rows=5 runat='server' ID='txtObservacao' MaxLength='30'></asp:TextBox> 
				</td>
			</tr>
			<tr class="trEditFooter">
			    <td colspan='4'>&nbsp;</td>
			</tr>
		</table>
	</div>
	Itens do Pedido
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
        <div id='divTotal' style="display:none;">
            Total: <b><asp:Literal runat='server' ID='ltrTotal'></asp:Literal></b>
	    </div>
	</div> 
	<br />
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnVoltar' Text='Voltar' CausesValidation='false' />
        <asp:Button runat='server' ID='btnAvancar' Text='Avancar' />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='ValidationSummary1' />
    </div>    
</asp:Content>

