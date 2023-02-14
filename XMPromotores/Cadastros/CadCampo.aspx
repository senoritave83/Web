<%@ Page Title="" Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="CadCampo.aspx.vb" Inherits="Pages.Cadastros.Cadastros_CadCampo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:Panel runat='server' ID='updLista'>
        <div class='EditArea'>

            <div class='Filtro'>
                <div class='FiltroItem'>Filtrar por<br>
                    <asp:TextBox Runat="server" ID='txtFiltro'/>
                </div> 
                <div class='FiltroBotao'>
                    <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
                </div>
            </div>	

            <div style='width:100%;'>
	            <div>
                    <asp:Panel cssclass='AreaProdutoPesquisasa' runat='server' ID='pnlLista'>
                        <div class='ListaItens'>
		                    <asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='Opcao' SkinID='GridInterno'>
		                        <HeaderStyle HorizontalAlign='Left' />
			                    <columns>
                                    <asp:BoundField DataField="Opcao" HeaderText="Opções disponíveis" SortExpression="Opcao"  />
				                    <asp:ButtonField ButtonType="Image" CommandName='Excluir' ImageUrl="~/imagens/excluir_ico.png" />
			                    </columns>
			                    <EmptyDataTemplate>
		                            <div class='GridHeader'>&nbsp;</div>					    
			                        <div class='divEmptyRow'>
					                    <asp:Label runat='server' ID='lblNaoEncontrados'>
						                    N&atilde;o h&aacute; cadastros com o filtro selecionado!
					                    </asp:Label>
			                        </div>
			                    </EmptyDataTemplate>
		                    </asp:GridView>
		                </div> 
	                </asp:Panel> 
                </div>
	        </div>
            <br class='cb' />
            <asp:Panel runat='server' ID='pnlInsert'>
		        <div id='AdicionarProdutoPesquisa2' >
		            <table id='tblProdutos2' border='1'>
		                <tr>
		                    <td style="white-space:nowrap;">
		                        Adicionar <asp:Literal runat='server' ID='ltNome'></asp:Literal>:
		                    </td>
		                    <td width='250px'>
		                        <asp:TextBox Width="250" runat='server' ID='txtNovo'></asp:TextBox>
		                    </td>
		                    <td width=100%>
		                        <asp:Button runat='server' ID='btnAdicionar' Text='Adicionar' />
		                    </td>
		                </tr>
		            </table> 
		        </div> 
	        </asp:Panel>
        </div>
	    <br class='cb' />
        <div id='divErros'>
            <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
            <asp:ValidationSummary runat='server' ID='valSummary' />
        </div>
        <div class='AreaAjuda'>
	        <ul class='TextDefault'>
		        <li>
		            <asp:Localize runat='server' ID='lclAjudaNovo'>
			            <b>Novo:</b>
				        Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		            </asp:Localize>
		        </li> 
	        </ul>
        </div>
    </asp:Panel>

</asp:Content>

