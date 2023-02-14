<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Pesquisa.aspx.vb" Inherits="Pages.Cadastros.Pesquisa" title="XM Promotores - Yes Mobile" %>
<%@ Register Src="../controls/Roteiro.ascx" TagName="Roteiro" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat='server' ID='ScriptManager1' />
    <div class='EditArea'>
		<table id='tblEditArea'>
			<tr class="trEditHeader">
			    <td colspan='2'>&nbsp;</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Pesquisa:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtPesquisa' MaxLength='50' Width='90%' />
					<asp:RequiredFieldValidator runat='server' ID='valReqPesquisa' Display='None' ErrorMessage='Pesquisa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtPesquisa' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Concorrente:
				</td>
				<td class='tdField'>
					<asp:DropDownList runat='server' ID='cboConcorrente' >
					    <asp:ListItem Value='0'>N&atilde;o</asp:ListItem>
					    <asp:ListItem Value='1'>Sim</asp:ListItem>
					    <asp:ListItem Value='2'>Todos</asp:ListItem>
					</asp:DropDownList>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Criado:
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblCriado' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Pesquisa de:
				</td>
				<td class='tdField'>
				    <table id='tblEditAcao'>
				        <tr>
				            <td>
				                <asp:CheckBox runat='server' ID='chkEstoque' /> Estoque 
				            </td>
				            <td>
				                <asp:CheckBox runat='server' ID='chkPreco' /> pre&ccedil;o
				            </td>
				            <td>
				                <asp:CheckBox runat='server' ID='chkPerguntas' /> Perguntas
				            </td>
				        </tr>
				    </table>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Ativo:
				</td>
				<td class='tdField'>
					<asp:CheckBox runat='server' ID='chkAtivo' />
				</td>
			</tr>
		</table>
        <div id="divRoteiro1" runat="server">
            <uc2:Roteiro ID="Roteiro1" runat="server" showSemanaMes='<%$Settings: Visible, Pesquisa.SemanaMes, "false"%>' />	
        </div>
       	
	</div>
	<asp:PlaceHolder runat='server' ID='phlOpcoes'>
        <div id='AreaProdutoPesquisa'>
            <asp:Panel runat='server' ID='pnlSegmentacao'>
                <asp:UpdatePanel runat='server' ID='pnlUpdate'>
                    <ContentTemplate>
                        <h4>Exibir a pesquisa para os seguintes produtos:</h4>
                        <table id='Table2' width='100%'>
			                <tr class='trField'>
				                <td colspan='2' width='100%'>
					                <asp:RadioButtonList CellPadding='0' CellSpacing='0' runat="server" ID='rdTipoBusCaProduto' RepeatDirection='Horizontal'>
                                        <asp:ListItem Text="Segmento" Value='Segmento' Selected='True'></asp:ListItem>
                                        <asp:ListItem Text="Categoria" Value='Categoria'></asp:ListItem>
                                        <asp:ListItem Text="Produto" Value='Produto'></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="pnlUpdate" DisplayAfter='1000' DynamicLayout='false'>
                                        <ProgressTemplate>
                                            <asp:Image ID="Image12" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
                                        </ProgressTemplate>
                                    </asp:UpdateProgress> 
				                </td>
			                </tr>
			                <tr class='trField'>
				                <td class='tdField' width='80%'>
					                <asp:TextBox runat="server" ID='txtBuscaProduto' Width='100%'></asp:TextBox>
				                </td>
                                <td>
                                    <asp:Button runat='server' ID='btnBuscarProdutos' Text='Buscar' class='BotaoAdicionar' />
                                </td>
                            </tr>
                        </table>
                        <div class='ListaItens'>
                            <asp:GridView runat='server' ID='grdProdutos' Width='100%' SkinID='GridInterno' DataKeyNames='IDPesquisaProduto' AutoGenerateColumns='false'>
                                <HeaderStyle HorizontalAlign='Left' />
                                <Columns>
                                    <asp:BoundField DataField='Categoria' HeaderText='Segmentos' />
                                    <asp:BoundField DataField='SubCategoria' HeaderText='Categorias' />
                                    <asp:BoundField DataField='Produto' HeaderText='Produto' />
                                    <asp:ButtonField  CommandName='RetirarProduto' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir.gif"/>' />
                                </Columns>
                                <EmptyDataTemplate>
                                    N&atilde;o h&aacute; produtos cadastrados para essa pesquisa!
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div id='AdicionarProdutoPesquisa'>
		                    <table id='tblProduto'>
			                    <tr class='trField'>
				                    <td colspan='3'>
					                    <h4>Adicionar um novo produto</h4>
				                    </td>
			                    </tr>
			                    <tr class='trField'>
				                    <td class='tdField'>
					                    Segmento:<br />
				                        <asp:DropDownList runat='server' ID='cboCategoria' DataTextField='Categoria' DataValueField='IDCategoria' AutoPostBack="true" /> 
				                    </td>
                                </tr>
                                <tr class='trField'>
				                    <td class='tdField'>
					                    Categoria:<br />
				                        <asp:DropDownList runat='server' ID='cboSubCategoria' DataTextField='SubCategoria' DataValueField='IDSubCategoria' AutoPostBack="true" /> 
				                    </td>
                                </tr>
                                <tr class='trField'>
				                    <td class='tdField'>
				                        Produto:<br />
				                        <asp:DropDownList runat='server' ID='cboProduto' DataTextField='Codigo' DataValueField='IDProduto' /> 
				                    </td>
			                    </tr>
			                    <tr>
    		                        <td colspan='3'>
                                        <asp:Button runat='server' ID='btnAddSegmentacao' Text='Adicionar produto' class='BotaoAdicionar' />
			                        </td>
			                    </tr>
		                    </table>
	                    </div>
                     </ContentTemplate> 
                </asp:UpdatePanel> 
            </asp:Panel>
        </div> 
        <div id='AreaSegmentoPesquisa'>
            <asp:Panel runat='server' ID='Panel1'>
                <asp:UpdatePanel runat='server' ID='pnlSegmentos'>
                    <ContentTemplate>
                        <h4>Exibir a pesquisa para os seguintes crit&eacute;rios de lojas:</h4>
                        <table id='Table3' width='100%'>
			                <tr class='trField'>
				                <td colspan='2' width='100%'>
					                <asp:RadioButtonList CellPadding='0' CellSpacing='0' runat="server" ID='tdTipoBuscaLoja' RepeatDirection='Horizontal'>
                                        <asp:ListItem Text="Bandeira" Value='Bandeira' Selected='True'></asp:ListItem>
                                        <asp:ListItem Text="Loja" Value='Loja'></asp:ListItem>
                                        <asp:ListItem Text="Cidade" Value='Cidade'></asp:ListItem>
                                        <asp:ListItem Text="UF" Value='UF'></asp:ListItem>
                                    </asp:RadioButtonList>
				                </td>
			                </tr>
			                <tr class='trField'>
				                <td class='tdField' width='80%'>
					                <asp:TextBox runat="server" ID='txtBuscaLoja' Width='100%'></asp:TextBox>
				                </td>
                                <td>
                                    <asp:Button runat='server' ID='btnBuscaLoja' Text='Buscar' class='BotaoAdicionar' />
                                </td>
                            </tr>
                        </table>
                        <div class='ListaItens'>
                            <asp:GridView runat='server' ID='grdSegmentos' Width='100%' SkinID='GridInterno' AutoGenerateColumns='false' DataKeyNames='IDPesquisaSegmento'>
                                <HeaderStyle HorizontalAlign='Left' />
                                <Columns>
                                    <asp:BoundField DataField='UF' HeaderText='UF' />
                                    <asp:BoundField DataField='Cidade' HeaderText='Cidade' />
                                    <asp:BoundField DataField='Cliente' HeaderText='Bandeira' />
                                    <asp:BoundField DataField='Loja' HeaderText='Loja' />
                                    <asp:BoundField DataField='Regiao' HeaderText='Regiao' />
                                    <asp:BoundField DataField='TipoLoja' HeaderText='<%$ Settings: caption, Loja.TipoLoja, "Tipo Loja" %>' />
                                    <asp:ButtonField  CommandName='RetirarSegmento' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir.gif"/>' />
                                </Columns>
                                <EmptyDataTemplate>
                                    N&atilde;o h&aacute; crit&eacute;ios de lojas cadastradas para essa pesquisa!
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div> 
                        <div id='AdicionarSegmentoPesquisa'>
		                    <table id='Table1' border='1'>
			                    <tr class='trField'>
				                    <td colspan='2'>
					                    <h4>Adicionar um novo crit&eacute;rio</h4>
				                    </td>
                                    <td>
                                        <asp:UpdateProgress ID="UpdateProgress23" runat="Server" AssociatedUpdatePanelID="pnlSegmentos" DisplayAfter='1000' DynamicLayout='false'>
                                            <ProgressTemplate>
                                                <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
                                            </ProgressTemplate>
                                        </asp:UpdateProgress> 
                                    </td>
			                    </tr>
			                    <tr class='trField'>
				                    <td class='tdFieldHeader' style="width:50px;">
					                    UF:
				                    </td>
				                    <td class='tdField' colspan='2'>
					                    <asp:DropDownList DataTextField="UF" DataValueField="UF" runat="server" ID="cboUF" ValidationGroup='AdicionarSegmento' AutoPostBack='true' />
				                    </td>
			                    </tr>
			                    <tr class='trField'>
				                    <td class='tdFieldHeader'>
					                    Cidade:
				                    </td>
				                    <td class='tdField' colspan='2'>
					                    <asp:TextBox runat='server' ID='txtCidade' MaxLength='100' CssClass='txtCidade' />
				                    </td>
			                    </tr>
			                    <tr class='trField'>
				                    <td class='tdFieldHeader'>
					                    Regi&atilde;o:
				                    </td>
				                    <td class='tdField' colspan='2'>
					                    <asp:DropDownList runat="server" ID="cboIDRegiao" DataTextField="Regiao" DataValueField="IDRegiao" AutoPostBack='true'  />
				                    </td>
			                    </tr>
			                    <tr class='trField'>
				                    <td class='tdFieldHeader'>
					                    <asp:Literal ID="ltrTipoLoja" runat="server" Text='<%$ Settings: caption, Loja.TipoLoja, "Tipo de Loja" %>' />:
				                    </td>
				                    <td class='tdField' colspan='2'>
					                    <asp:DropDownList runat="server" ID="cboIDTipoLoja" DataTextField="TipoLoja" DataValueField="IDTipoLoja" AutoPostBack='true'  />
				                    </td>
			                    </tr>
			                    <tr class='trField'>
				                    <td class='tdFieldHeader'>
					                    Bandeira:
				                    </td>
				                    <td class='tdField' colspan='2'>
					                    <asp:DropDownList runat="server" ID="cboIDCliente" DataTextField="Fantasia" DataValueField="IDCliente" AutoPostBack='true' />
				                    </td>
			                    </tr>
			                    <tr class='trField'>
				                    <td class='tdFieldHeader'>
					                    Loja:
				                    </td>
				                    <td class='tdField' colspan='2'>
					                    <asp:DropDownList runat="server" ID="cboIDLoja" DataTextField='<%$Settings: CampoLoja, Pesquisa.SegmentoLoja, "Loja"%>' DataValueField="IDLoja" />
				                    </td>
			                    </tr>
			                    <tr>
    		                        <td colspan='3'>
                                        <asp:Button runat='server' ID='btnAdicionarSegmento' Text='Adicionar sele&ccedil;&atilde;o' class='BotaoAdicionar' />
			                        </td>
			                    </tr>
		                    </table>
	                    </div>
                     </ContentTemplate> 
                </asp:UpdatePanel> 
            </asp:Panel>
        </div> 



        <div id='AreaPerguntaPesquisa'>
            <asp:Panel runat='server' ID='Panel2'>
                <asp:UpdatePanel runat='server' ID='UpdatePanel3'>
                    <ContentTemplate>
                        <h4>Exibir a pesquisa para as seguintes perguntas:</h4>
                        <table id='Table4' width='100%'>
			                <tr class='trField'>
				                <td colspan='2' width='100%'>
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="pnlUpdate" DisplayAfter='1000' DynamicLayout='false'>
                                        <ProgressTemplate>
                                            <asp:Image ID="Image13" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
                                        </ProgressTemplate>
                                    </asp:UpdateProgress> 
				                </td>
			                </tr>
			                <tr class='trField'>
				                <td class='tdField' width='80%'>
					                <asp:TextBox runat="server" ID='txtBuscaPergunta' Width='100%'></asp:TextBox>
				                </td>
                                <td>
                                    <asp:Button runat='server' ID='btnBuscaPergunta' Text='Buscar' class='BotaoAdicionar' />
                                </td>
                            </tr>
                        </table>
                        <div class='ListaItens'>
                            <asp:GridView runat='server' ID='grdPerguntas' Width='100%' SkinID='GridInterno' AutoGenerateColumns='false' DataKeyNames='IDPergunta'>
                                <HeaderStyle HorizontalAlign='Left' />
                                <Columns>
                                    <asp:BoundField DataField='Pergunta' HeaderText='Pergunta' />
                                    <asp:ButtonField  CommandName='RetirarPergunta' ButtonType='Link' Text='<img class="imgBtnAdd" src="../imagens/excluir.gif"/>' />
                                </Columns>
                                <EmptyDataTemplate>
                                    N&atilde;o h&aacute; perguntas cadastrados para essa pesquisa!
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                        <div id='AdicionarPerguntaPesquisa'>
		                    <table id='Table5'>
			                    <tr class='trField'>
				                    <td colspan='3'>
					                    <h4>Adicionar uma nova pergunta</h4>
				                    </td>
			                    </tr>
			                    <tr class='trField'>
				                    <td class='tdField'>
					                    Pergunta:<br />
				                        <asp:DropDownList runat='server' ID='cboPergunta' DataTextField='Pergunta' DataValueField='IDPergunta' /> 
				                    </td>
                                </tr>
			                    <tr>
    		                        <td colspan='3'>
                                        <asp:Button runat='server' ID='btnAddPergunta' Text='Adicionar Pergunta' class='BotaoAdicionar' />
			                        </td>
			                    </tr>
		                    </table>
	                    </div>
                     </ContentTemplate> 
                </asp:UpdatePanel> 
            </asp:Panel>
        </div>



        <br class='cb' />
    </asp:PlaceHolder> 
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Pesquisa.aspx?idpesquisa=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Pesquisas.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Gravar:</b>
				Grava as altera&ccedil;&otilde;es efetuadas no banco.
		    </li> 
		    <li>
			    <b>Apagar:</b>
				Apaga o registro atual.
		    </li> 
		    <li>
			    <b>Novo:</b>
				Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

