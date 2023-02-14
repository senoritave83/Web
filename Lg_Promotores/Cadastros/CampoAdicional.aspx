<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="CampoAdicional.aspx.vb" Inherits="Pages.Cadastros.CampoAdicional" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat='server'></asp:ScriptManager>
    <div class='EditArea'>
        <div style='width:100%;'>
        <div style='width:50%;float:left;'>
		    <div class='divEditArea' style='height:300px;'>
		        <div class='divHeader'>&nbsp;</div>
		        <div class='trField cb' runat='server'  id='trEntidade' visible='<%$Settings: visible, CampoAdicional.Entidade, true %>' >
			        <div class='tdFieldHeader cb fl'>
				        Entidade:
			        </div>
			        <div class='tdField fl'>
				        <asp:Label runat='server' ID='lblEntidade' />
			        </div>
		        </div>
		        <div class='trField cb' runat='server'  id='trNome' visible='<%$Settings: visible, CampoAdicional.Nome, true %>' >
			        <div class='tdFieldHeader cb fl'>
				        Nome:
			        </div>
			        <div class='tdField fl'>
				        <asp:TextBox runat='server' ID='txtNome' MaxLength='100' Width="300" />
				        <asp:RequiredFieldValidator runat='server' ID='valReqNome' Enabled='<%$Settings: Required, CampoAdicional.Nome, true %>' Display='None' ErrorMessage='Nome &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtNome' />
			        </div>
		        </div>
		        <div class='trField cb' runat='server'  id='trFormato' visible='<%$Settings: visible, CampoAdicional.Formato, false %>' >
			        <div class='tdFieldHeader cb fl'>
				        Formato:
			        </div>
			        <div class='tdField fl'>
				        <asp:TextBox runat='server' ID='txtFormato' MaxLength='30' />
			        </div>
		        </div>
		        <div class='trField cb' runat='server'  id='trRequirido' visible='<%$Settings: visible, CampoAdicional.Requirido, true %>' >
			        <div class='tdFieldHeader cb fl'>
				        Obrigatório:
			        </div>
			        <div class='tdField fl'>
				        <asp:CheckBox runat='server' ID='chkRequirido' />
			        </div>
		        </div>
		        <div class='trField cb' runat='server'  id='trTipo' visible='<%$Settings: visible, CampoAdicional.Tipo, true %>'>
			        <div class='tdFieldHeader cb fl'>
				        Tipo:
			        </div>
			        <div class='tdField fl'>
				        <asp:DropDownList runat='server' ID='cboTipo' AutoPostBack='true'>
				            <asp:ListItem Selected='True' Value='0'>Caixa de texto</asp:ListItem>
				            <asp:ListItem Value='1'>Caixa de seleção</asp:ListItem>
				        </asp:DropDownList>
			        </div>
		        </div>
		        <div class='trField' runat='server'  id='Div1' visible='<%$Settings: visible, CampoAdicional.Tamanho, true %>' >
			        <div class='tdFieldHeader cb fl'>
				        Tamanho (Width):
			        </div>
			        <div class='tdField fl'>
				        <asp:TextBox runat='server' ID='txtTamanho' MaxLength='3' Width="50" />
			        </div>
		        </div>
		        <div class='trField cb' runat='server'  id='Div2' visible='<%$Settings: visible, CampoAdicional.TamanhoMaximo, true %>' >
			        <div class='tdFieldHeader cb fl'>
				        Tamanho Máximo de Texto (MaxLength):
			        </div>
			        <div class='tdField fl'>
				        <asp:TextBox runat='server' ID='txtTamanhoMaximoTexto' MaxLength='3' Width="50" />
			        </div>
		        </div>
		        <div class='trField cb' runat='server'  id='Div3' visible='<%$Settings: visible, CampoAdicional.QuebraLinha, true %>' >
			        <div class='tdFieldHeader cb fl'>
				        Quebra de Linha (BR):
			        </div>
			        <div class='tdField fl'>
				        <asp:CheckBox runat='server' ID='chkQuebraLinha' />
			        </div>
		        </div>
			    <div class='divFooter'>&nbsp;<br /></div>
		    </div>
            <div class='AreaBotoes'>
                <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
                <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' CausesValidation='false' />
                <asp:Button runat='server' ID='btnNovo'   Text="Novo"   Cssclass="Botao" CausesValidation='false' />
                <asp:Button runat="server" ID="btnVoltar" Text="Voltar" CssClass="Botao" CausesValidation='false' />
            </div>
	    </div> 
	    <div id='AreaProdutoPesquisa' style='float:right;height:310px;'>
            <asp:UpdatePanel ID="updLista" runat="server">
                <ContentTemplate>
                    <asp:Panel cssclass='AreaProdutoPesquisasa' runat='server' ID='pnlLista'>
                        <h4>Lista de opções disponíveis para o campo</h4> 
                        <div class='ListaItens'>
		                <asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='Opcao' SkinID='GridInterno'>
		                    <HeaderStyle HorizontalAlign='Left' />
			                <columns>
				                <asp:BoundField DataField="Opcao" HeaderText="Opções disponíveis" SortExpression="Opcao"  />
				                <asp:ButtonField ButtonType="Image" CommandName='Excluir' ImageUrl="~/imagens/Excluir.gif" />
			                </columns>
			                <EmptyDataTemplate>
		                        <div class='GridHeader'>&nbsp;</div>					    
			                    <div class='divEmptyRow'>
					                <asp:Label runat='server' ID='lblNaoEncontrados'>
						                N&atilde;o h&aacute; campo adicionais com o filtro selecionado!
					                </asp:Label>
			                    </div>
			                </EmptyDataTemplate>
		                </asp:GridView>
		                </div> 
		                <asp:Panel runat='server' ID='pnlInsert'>
		                    <div id='AdicionarProdutoPesquisa'>
		                        <table id='tblProdutos' width='100%'>
		                            <tr>
		                                <td align='right'>
		                                    Adicionar opção:
		                                </td>
		                                <td>
		                                    <asp:TextBox runat='server' ID='txtNovo'></asp:TextBox>
		                                </td>
		                                <td>
		                                    <asp:Button runat='server' ID='btnAdicionar' Text='Adicionar' />
		                                </td>
		                            </tr>
		                        </table> 
		                    </div> 
		                </asp:Panel>
	                </asp:Panel> 
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID='cboTipo' EventName='SelectedIndexChanged' />
                </Triggers>
            </asp:UpdatePanel>		
            </div> 
	    </div>
    </div>
	<br class='cb' />
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaGravar'></asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaApagar'>
			        <b>Apagar:</b>
				    Apaga o registro atual.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaNovo'>
			        <b>Novo:</b>
				    Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

