<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="~/Controle/estvendedoreshistorico.aspx.vb" Inherits="Controle_ConsignacaoVendedores_Historico" title="Untitled Page" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>


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
				    <asp:Label runat='server' ID='lblTextoCodigo'>
						C&oacute;digo:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblCodigo' />
				</td>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoCNPJ'>
						CNPJ:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblCNPJ'  />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoVendedor'>
						Nome:
					</asp:Label> 
				</td>
				<td class='tdField' colspan='3'>
					<asp:Label runat='server' ID='lblVendedor' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='Label1'>
						Produto:
					</asp:Label> 
				</td>
				<td class='tdField' colspan='3'>
					<asp:Label runat='server' ID='lblProdutoCodigo' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='Label2'>
						Descrição:
					</asp:Label> 
				</td>
				<td class='tdField' colspan='3'>
					<asp:Label runat='server' ID='lblProdutoDescricao' />
				</td>
			</tr>
			<tr class="trEditFooter">
			    <td colspan='4'>&nbsp;</td>
			</tr>
		</table>
	</div>
    <div class='ListArea'>	
        <div class='ListaItens'>
            <asp:GridView runat='server' ID='grdHistorico' AutoGenerateColumns='false' Width='100%'>
                <Columns>
                    <asp:BoundField DataField='Data' HeaderText='Data' HeaderStyle-HorizontalAlign='Left' />
                    <asp:BoundField DataField='Modulo' HeaderText='Modulo' HeaderStyle-HorizontalAlign='Left' />
                    <asp:BoundField DataField='Usuario' HeaderText='Usuario' HeaderStyle-HorizontalAlign='Left' />
                    <asp:BoundField DataField='EstoqueAnterior' HeaderText='EstoqueAnterior' HeaderStyle-HorizontalAlign='Left' />
                    <asp:BoundField DataField='EstoqueAtual' HeaderText='EstoqueAtual' HeaderStyle-HorizontalAlign='Left' />
                </Columns>
            </asp:GridView>
            <uc1:Paginate ID="Paginate1" runat="server" />
        </div> 
        <div class='AreaBotoes'>
            <asp:Button runat='server' ID='btnVoltar' Text="Voltar" CssClass='Botao' Visible='True' CausesValidation='False' />
        </div>
    </div>
</asp:Content>

