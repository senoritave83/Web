<%@ Control Language="VB" AutoEventWireup="false" CodeFile="produtoconcorrente.ascx.vb" Inherits="controls_produtoconcorrente" %>
<asp:Panel runat='server' ID='pnlConcorrente'>
    <div id='AreaConcorrente' style="<%=me.Style%>" >
        <asp:UpdatePanel runat='server' ID='pnlUpdate'>
            <ContentTemplate>
                <h4><asp:Literal runat='server' ID='ltrTitle'>Produtos Concorrentes:</asp:Literal></h4>
                <div id='AreaLista'>
                    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="pnlUpdate" DisplayAfter='1000' DynamicLayout='false'>
                        <ProgressTemplate>
                            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...</ProgressTemplate>
                    </asp:UpdateProgress> 
                    <div class='ListaItens'>
                        <asp:GridView runat='server' ID='grdProdutos' Width='95%' SkinID='GridInterno' AutoGenerateColumns='false' DataKeyNames='IDProdutoConcorrente'>
                            <HeaderStyle HorizontalAlign='Left' />
                            <Columns>
                                <asp:BoundField DataField='Fornecedor' HeaderText='Marca' />
                                <asp:BoundField DataField='Categoria' HeaderText='Segmento' />
                                <asp:BoundField DataField='SubCategoria' HeaderText='Categoria' />
                                <asp:BoundField DataField='Produto' HeaderText='Produto' />
                                <asp:ButtonField  CommandName='RetirarProduto' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir.gif"/>' />
                            </Columns>
                            <EmptyDataTemplate>
                                N&atilde;o existem produtos concorrentes cadastrados!
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
                <div id='AdicionarConcorrentes'>
                    <table id='tblConcorrente'>
	                    <tr class='trField'>
		                    <td>
			                    <h4>Adicionar concorrente</h4>
		                    </td>
	                    </tr>
                        <tr class='trField' runat='server' id='trMarca'>
		                    <td class='tdField'>
			                    Marca:<br />
		                        <asp:DropDownList runat='server' ID='cboIDMarca' DataTextField='Fornecedor' DataValueField='IDFornecedor' AutoPostBack="true" /> 
		                    </td>
                        </tr>
                        <tr class='trField' runat='server' id='trCategoria'>
		                    <td class='tdField'>
			                    Segmento:<br />
		                        <asp:DropDownList runat='server' ID='cboIDCategoria' DataTextField='Categoria' DataValueField='IDCategoria' AutoPostBack="true" /> 
		                    </td>
                        </tr>
                        <tr class='trField' runat='server' id='trSubCategoria'>
		                    <td class='tdField'>
			                    Categoria:<br />
		                        <asp:DropDownList runat='server' ID='cboIDSubCategoria' DataTextField='SubCategoria' DataValueField='IDSubCategoria' AutoPostBack="true" /> 
		                    </td>
                        </tr>
                        <tr class='trField'>
		                    <td class='tdField'>
		                        Produto:<br />
		                        <asp:DropDownList runat='server' ID='cboIDProduto' DataTextField='Descricao' DataValueField='IDProduto' /> 
		                        <asp:CompareValidator runat='server' ID='valIDProduto' ErrorMessage='Selecione o produto concorrente' ValidationGroup='AdicionarProdutoConcorrente' ControlToValidate='cboIDProduto' Operator='GreaterThan' ValueToCompare='0'>*</asp:CompareValidator>
		                    </td>
	                    </tr>
	                    <tr>
	                        <td>
                                <asp:Button runat='server' ID='btnAddSegmentacao' Text='Adicionar produto' class='BotaoAdicionar' ValidationGroup='AdicionarProdutoConcorrente' />
	                        </td>
	                    </tr>
                    </table>
                </div>
             </ContentTemplate> 
        </asp:UpdatePanel> 
    </div> 
</asp:Panel>
