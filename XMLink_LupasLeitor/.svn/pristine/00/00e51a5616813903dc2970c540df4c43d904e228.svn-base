<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="estvendedoresdevolver.aspx.vb" Inherits="Controle_estvendedoresdevolver" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>

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
					<asp:Label runat='server' ID='lblCodigo'  />
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
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="pnlProdutos" DisplayAfter='1000' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
    <div class='ListArea'>	
        <asp:UpdatePanel Runat="server" ID='pnlProdutos'>
            <ContentTemplate>
                <div id='divAddProdutosConsignados'>
                    <table>
                        <tr>
                            <td id='tdProcurar'>
                                <h4>Procurar Produtos</h4>
                                <p>
                					<asp:TextBox Runat="server" ID='txtFiltro' />
                		            <asp:DropDownList runat="server" ID="cboIDCategoria" DataTextField="Categoria" DataValueField="IDCategoria" />
                					<asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
                                </p>
                                <br class='cb' />
                                <asp:GridView runat='server' ID='grdProdutos' AutoGenerateColumns='false' Width='100%' DataKeyNames='IDProduto'>
					                <columns>
						                <asp:BoundField DataField="Codigo" HeaderText="C&oacute;digo" SortExpression="Codigo"  />
						                <asp:BoundField HeaderText="Descri&ccedil;&atilde;o" DataField="Descricao" SortExpression="Descricao" />
						                <asp:BoundField HeaderText="Categoria" DataField="Categoria" SortExpression="Categoria" />
                                        <asp:ButtonField  CommandName='AdicionarProduto' ButtonType="Link" Text='<img class="imgBtnAdd" src="../imagens/set-pb.gif" alt="Adicionar produto"/>' />
                                    </columns>
					                <EmptyDataTemplate>
				                        <div class='GridHeader'>&nbsp;</div>					    
					                    <div class='divEmptyRow'>
							                <asp:Label runat='server' ID='lblNaoEncontrados'>
								                N&atilde;o h&aacute; Produtos com o filtro selecionado!
							                </asp:Label>
					                    </div>
					                </EmptyDataTemplate>
                                </asp:GridView>
                                <uc1:Paginate ID="Paginate1" runat="server" />
                            </td>
                            <td id='tdDetalhes'>
                                <asp:PlaceHolder runat='server' ID='plhAdicionar' Visible='False'>
                                    <h4>Detalhes do produto a ser adicionado</h4>
                                    <br />
                                    <b>Codigo:</b><asp:Label runat='server' ID='lblProdutoCodigo' /><br />
                                    <b>Descricao:</b><asp:Label runat='server' ID='lblProdutoDescricao' /><br />
                                    <b>Quantidade:</b><asp:TextBox runat='server' ID='txtQuantidade' /><br />
                                    <asp:RequiredFieldValidator runat='server' ID='valReqQuantidade' ControlToValidate='txtQuantidade' Display='None' ErrorMessage='A quantidade do produto em consignação é obrigatória' ValidationGroup='AdicionarProduto' />
                                    <asp:CompareValidator runat='server' ID='valCompQuantidade' ControlToValidate='txtQuantidade' Display='None' ErrorMessage='Quantidade do produto inválida' Type='Integer' Operator='DataTypeCheck' ValidationGroup='AdicionarProduto' />
                                    <asp:CompareValidator runat='server' ID='CompareValidator1' ControlToValidate='txtQuantidade' Display='None' ErrorMessage='A quantidade do produto em consignação deve ser maior que 0' Type='Integer' Operator="GreaterThan" ValueToCompare='0' ValidationGroup='AdicionarProduto' />
                                    <asp:Button runat='server' ID='btnAdicionar' Text='Adicionar' CssClass='Botao' ValidationGroup='AdicionarProduto' />
                                    <asp:ValidationSummary runat='server' ID='valSummary' DisplayMode='BulletList' ShowSummary='false' ShowMessageBox='true'  ValidationGroup='AdicionarProduto' />
                                </asp:PlaceHolder>
                                <asp:Label runat='server' ID='lblMensagem' EnableViewState='false' CssClass='Mensagem' />
                            </td>
                        </tr>
                    </table>                            
                </div> 
                <div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel> 
        <div class='AreaBotoes'>
            <asp:Button runat='server' ID='btnVoltar' Text="Voltar" CssClass='Botao' Visible='True' CausesValidation='False' />
        </div>
    </div>
</asp:Content>

