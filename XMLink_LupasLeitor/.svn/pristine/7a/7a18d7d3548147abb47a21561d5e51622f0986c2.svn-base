<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="PedidoEstoqueVendedor.aspx.vb" Inherits="Pages.Cadastros.PedidoEstoqueVendedor" title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolKit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptMaster" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <script language="javascript" type="text/javascript">
        function fncPrint() {
            var url = "pedidoestoquevendedor_print.aspx?";
            url += "idpev=" + <%=ViewState(VW_IDPEDIDOESTOQUEVENDEDOR)%>;
            window.open(url, 'IMPRIMIR_RELATORIO_PEDIDOS_ESTOQUE_VENDEDOR', 'width=850, height=800,status=no,scrollbars=yes,toolbar=no,top=20,left=20');
        }

        function SomenteNumero() {
            if (event.keyCode < 48 || event.keyCode > 57) {
                return false;
            }
        } 
                        
    </script>
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="updProdutos" DisplayAfter='0' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
    <asp:UpdatePanel runat="server" ID="updProdutos">
        <ContentTemplate>
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
				            <asp:Label runat='server' ID='lblTextoGrupo'>
						        Tipo de Movimentação:
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
					        <asp:DropDownList ValidationGroup="Principal" runat='server' ID='cboTipoPedido'>
		            	        <asp:ListItem value="0">Selecione...</asp:ListItem>
                                <asp:ListItem value="1">Inclusão</asp:ListItem>
                                <asp:ListItem value="2">Devolução</asp:ListItem>
		                    </asp:DropDownList>
			                <asp:CompareValidator ValidationGroup="Principal" runat="server"  ID="CompareValidator1" Display="None" ErrorMessage="Tipo de movimentação inválido" ControlToValidate="cboTipoPedido" Operator="GreaterThan" ValueToCompare="0" />
				        </td>
                        <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='Label5'>
						        Status:
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
					        <asp:Label runat="server" ID="lblStatus"></asp:Label>
				        </td>
			        </tr>
			        <tr class='trField'>
				        <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='lblTextoCriado'>
						        Vendedor
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
					        <asp:DropDownList ValidationGroup="Principal" runat="server" ID="cboIDVendedor" DataTextField="Vendedor" DataValueField="IDVendedor" />
					        <asp:CompareValidator ValidationGroup="Principal" runat="server"  ID="valCompIDVendedor" Display="None" ErrorMessage="Vendedor inv&aacute;lido" ControlToValidate="cboIDVendedor" Operator="GreaterThan" ValueToCompare="0" />
					        <asp:RequiredFieldValidator ValidationGroup="Principal" runat='server' ID='valReqIDVendedor' Display='None' ErrorMessage='Vendedor &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDVendedor' />
				        </td>
			            <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='Label2'>
					            Responsável:
				            </asp:Label> 
			            </td>
                        <td class='tdField'>
                            <asp:Label runat='server' ID='lblUsuario'></asp:Label>
                        </td>
                    </tr>
                    <tr class='trField'>
				        <td class='tdFieldHeader'>
				            <asp:Label runat='server' ID='Label1'>
						        Data:
					        </asp:Label> 
				        </td>
				        <td class='tdField'>
                           
                <asp:RequiredFieldValidator Runat="server" ID='valReqInicio' ControlToValidate='DataCriado' ErrorMessage='Por favor selecione a data inicial' Display="None" CssClass="TextDefault" />
	        	<asp:TextBox runat='server' ID='DataCriado' MaxLength="10" Width='75px' />		
                <ajaxToolkit:CalendarExtender  ID="cal_DataInicial" runat="server" TargetControlID="DataCriado" PopupPosition="Right" PopupButtonID="imgCalendarDataInicial" Format="dd/MM/yyyy" />		
		    
                        </td>
                        <td colspan='2'>&nbsp;</td>
                    </tr>
			        <tr class="trEditFooter">
			            <td colspan=4>&nbsp;</td>
			        </tr>
		        </table>
	        </div>
            <div class='AreaBotoes'>
                <asp:Button runat='server' ID='btnGravar' ValidationGroup="Principal" Text="Gravar" CssClass='Botao' />
                <asp:Button runat='server' ID='btnFinalizar' ValidationGroup="Principal" Text="Finalizar movimentação" CssClass='Botao' Width="200" />
                <asp:Button runat='server' ID='btnCancelar' CausesValidation="false" Text="Cancelar movimentação" CssClass='Botao' Width="200" />
                <input type="button" runat='server' id='btnImprimir' class="Botao"  style="width:200;" value=" Imprimir movimentação " onclick="javascript:fncPrint()" />
                <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='pedidoestoquevendedor.aspx?idpev=0'" />
                <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='pedidoestoquevendedores.aspx'" />
            </div>
            <br class="cb" />
            <asp:Panel runat="server" ID="pnlProdutos"  Width="80%">
	            <div class='ListArea' runat="server" id="divAdicionarProduto">
                    <table id='tblAdicionarProduto' runat="server" width="100%">
			            <tr class="trEditHeader">
			                <td colspan='5'>Categorias</td>
			            </tr>
			            <tr class='trEditSpace'>
			                <td colspan='5'>&nbsp;</td>
			            </tr>
			            <tr class='trField'>
				            <td class='tdFieldHeader' width="15%">
				                <asp:Label runat='server' ID='Label3'>Categoria:</asp:Label> 
				            </td>
				            <td class='tdField'>
					            <asp:DropDownList runat='server' ID='drpCategoria' AutoPostBack="true" DataTextField="Categoria" DataValueField="IDCategoria" ValidationGroup="Itens" />
				            </td>
			            </tr>
                    </table>
                    <br class="cb" />
                </div>
                <br class="cb" />
                <div class='ListArea' runat="server" ID="divMovItens" visible="false">
                  <asp:Label runat="server" Font-Bold="true" ID="lblCategoria" />
	                <asp:GridView runat='server' ID='grdProdutos' AutoGenerateColumns='false'>
	                    <HeaderStyle HorizontalAlign='Left' />
			            <Columns>
			                <asp:BoundField DataField='Codigo' HeaderText='C&oacute;digo' />
			                <asp:BoundField DataField='Produto' ItemStyle-Width="30%" HeaderText='Produto' />
                            <asp:TemplateField HeaderText="Quantidade">
                                <ItemTemplate>
                                    <asp:HiddenField runat="server" ID="hidIdProduto" Value='<%#Eval("IdProduto")%>' />
                                    <asp:TextBox runat="server" autocomplete="off" ValidationGroup="Itens" ID="txtQuantidade" OnKeyPress="return SomenteNumero(this)" />
			                        <asp:CompareValidator ValidationGroup="Itens" runat="server" ID="CompareValidator4" Display="Dynamic" ErrorMessage="Quantidade inválida" ControlToValidate="txtQuantidade" Operator="DataTypeCheck" Type="Integer" />
                                    <asp:CompareValidator ValidationGroup="Itens" runat="server" ID="CompareValidator2" Display="Dynamic" ErrorMessage="Quantidade inválida" ControlToValidate="txtQuantidade" Operator="GreaterThan" ValueToCompare="0" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
	                </asp:GridView>
                    <asp:Button runat='server' ID='btnAdicionarProduto' ValidationGroup="Itens" Text="Adicionar" CssClass='Botao' style="float:none;margin-left:835;" />
                </div>
                <br class="cb" />
                <div class='ListArea' runat="server" id="divGridItens">
	                <asp:GridView runat='server' ID='grdItens' AutoGenerateColumns='false'>
	                    <HeaderStyle HorizontalAlign='Left' />
			            <Columns>
                            <asp:BoundField DataField='Categoria' HeaderText='Categoria' />
			                <asp:BoundField DataField='Codigo' HeaderText='C&oacute;digo' ItemStyle-Width="20%" />
			                <asp:BoundField DataField='DESCRICAO' ItemStyle-Width="30%" HeaderText='Produto' />
                            <asp:BoundField DataField='Quantidade' HeaderText='Qtd. Movimentada' />
                            <asp:BoundField DataField='TotalVendedor' />
                            <asp:TemplateField HeaderText="Excluir Item" Visible="false">
					            <ItemTemplate>
                                    <asp:ImageButton ID="imgRot" runat='server' OnClientClick="return confirm('Confirmar exclusão do item ?');" CommandName="ExcluirItem" CommandArgument='<%# Eval("IdProduto") %>' ImageUrl="~/imagens/Excluir.gif" />
					            </ItemTemplate>
				            </asp:TemplateField>
                        </Columns>
	                </asp:GridView>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id='divErros'>
        <asp:BulletedList ValidationGroup="Principal" runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary ValidationGroup="Principal" runat='server' ID='valSummary' />
        <asp:BulletedList ValidationGroup="Itens2" runat='server' ID='BulletedList1' SkinID='lstErros' />
        <asp:ValidationSummary ValidationGroup="Itens2" runat='server' ID='ValidationSummary1' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaGravar'>
			        <b>Gravar:</b>
				    Grava as altera&ccedil;&otilde;es efetuadas no banco.
		        </asp:Localize>
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

