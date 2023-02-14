<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="~/Controle/estvendedoresdet.aspx.vb" Inherits="vendedores_consignado" title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
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
			<tr class="trEditFooter">
			    <td colspan='4'>&nbsp;</td>
			</tr>
		</table>
	</div>
    <div class='ListArea'>	
        <asp:UpdatePanel Runat="server" ID='pnlProdutos'>
            <ContentTemplate>
                <div class='ListaItens'>
                    <asp:GridView runat='server' ID='grdProdutos' AutoGenerateColumns='false' Width='100%' DataKeyNames='IDProduto'>
                        <Columns>
                            <asp:BoundField DataField='Codigo' HeaderText='Codigo' HeaderStyle-HorizontalAlign='Left' />
                            <asp:BoundField DataField='Produto' HeaderText='Produto' HeaderStyle-HorizontalAlign='Left' />
                            <asp:TemplateField HeaderText='Estoque' HeaderStyle-HorizontalAlign='Left'>
                                <ItemTemplate>
                                    <asp:Label runat='server' ID='lblEstoque' Visible='<%# not Editing%>' Text='<%# Eval("Estoque") %>' />
                                    <asp:TextBox runat='server' ID='txtEstoque' Visible='<%# Editing%>' Text='<%# Eval("Estoque") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText='Histórico' HeaderStyle-HorizontalAlign='Left'>
                                <ItemTemplate>
                                    <a href='estvendedoreshistorico.aspx?idproduto=<%# Eval("IDProduto") %>&idvendedor=<%=ViewState(VW_IDVENDEDOR) %>'>Visualizar</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                        <EmptyDataTemplate>
                            <table class="TextDefault" width='100%' cellspacing="0" cellpadding="4" border="0" >
                                <tr class="GridHeader">
                                    <td>
                                        Produtos do estoque do vendedor
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        N&atilde;o h&aacute; produtos no estoque do vendedor
                                    </td>
                                </tr>
                               </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div> 
                <div class='AreaBotoes'>
                    <asp:Button runat='server' ID='btnEditar' Text="Editar" CssClass='Botao' Visible="false" />
                    <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' Visible='false' />
                    <asp:Button runat='server' ID='btnAdicionar' Text="Adicionar Produtos" CssClass='Botao' Visible='True' />
                    <asp:Button runat='server' ID='btnDevolver' Text="Devolução de Produtos" Width="200px" CssClass='Botao' Visible='True' />
                    <asp:Button runat='server' ID='btnCancelar' Text="Cancelar" CssClass='Botao' Visible='false' />
                    <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='consigvendedores.aspx'" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel> 
    </div>
</asp:Content>


