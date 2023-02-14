<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="visita.aspx.vb" Inherits="formulario_visita" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <asp:ScriptManager runat='server' />
                
                <div class='EditArea'>
		            <table id='tblEditArea' border="0">
			            <tr class="trEditHeader">
			                <td colspan='2'>&nbsp;</td>
			            </tr>
			            <tr class='trField'>
				            <td class='tdFieldHeader'>
					            Promotor:
				            </td>
				           <td class='tdField'>
				                <asp:Label runat='server' ID='lblPromotor' />        
				           </td>
				        </tr>
			            <tr class='trField'>
				            <td class='tdFieldHeader'>
					            Loja:
				            </td>
				           <td class='tdField'>
				                <asp:Label runat='server' ID='lblLoja' />
				           </td>
				        </tr>
			            <tr class='trField'>
				            <td class='tdFieldHeader'>
					            Data:
				            </td>
				           <td class='tdField'>
				                <asp:Label runat='server' ID='lblData' />
				           </td>
				        </tr>
				    </table>
				</div> 
                <div id='PerguntasVisitas'>
                    <asp:Panel runat='server' ID='pnlPerguntasLoja'>
                        <asp:Label runat='server' ID='lblPerguntasLoja' />
                        <asp:GridView runat='server' ID='grdPerguntasLoja' DataKeyNames='IDPergunta' AutoGenerateColumns='false'>
                            <HeaderStyle HorizontalAlign='Left' />
                            <Columns>
                                 <asp:ButtonField ButtonType='Link' DataTextField='Pergunta' CommandName='Abrir'  HeaderText='Produto' />
                                 <asp:BoundField DataField='Status' HeaderText='Status' />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
                <div id='ProdutosVisita'>
                    <asp:UpdatePanel runat='server' ID='updProdutos'>
                        <ContentTemplate>
                            <asp:LinkButton runat='server' ID='lnkVoltarCat' Text='Segmento' />
                            <asp:LinkButton runat='server' ID='lnkVoltarFornecedor' Text='Marca' />
                            <asp:Label runat='server' ID='lblAtual'></asp:Label>
                            <br />
                            <br />
                            <asp:GridView runat='server' ID='grdCategorias' DataKeyNames='IDCategoria' AutoGenerateColumns='False'>
                                <HeaderStyle HorizontalAlign='Left' />
                                <Columns>
                                    <asp:ButtonField ButtonType='Link' DataTextField='Categoria' CommandName='Abrir'  HeaderText='Segmento' />
                                    <asp:TemplateField HeaderText='Realizado'>
                                        <ItemTemplate>
                                            <%#IIf((Eval("Total") = Eval("Respondidos")), "OK", Eval("Total") & "/" & Eval("Respondidos"))%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:Panel runat='server' ID='pnlCategorias'>
                                Segmento: <asp:Label runat='server' ID='lblCategoria' /> 
                                <asp:GridView runat='server' ID='grdFornecedores' DataKeyNames='IDFornecedor' AutoGenerateColumns='False'>
                                    <HeaderStyle HorizontalAlign='Left' />
                                    <Columns>
                                        <asp:ButtonField ButtonType='Link' DataTextField='Fornecedor' CommandName='Abrir'  HeaderText='Marca' />
                                        <asp:TemplateField HeaderText='Realizado'>
                                            <ItemTemplate>
                                                <%#IIf((Eval("Total") = Eval("Respondidos")), "OK", Eval("Total") & "/" & Eval("Respondidos"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Panel runat='server' ID='pnlFornecedores'>
                                    Marca: <asp:Label runat='server' ID='lblFornecedor' /> 
                                    <div style='overflow:auto;height:300px;'>
                                    <asp:GridView runat='server' ID='grdProdutos' DataKeyNames='IDProduto' AutoGenerateColumns='False'>
                                        <HeaderStyle HorizontalAlign='Left' />
                                        <Columns>
					    <asp:BoundField DataField='Descricao' HeaderText='Produto' />
                                            <asp:BoundField DataField='Status' HeaderText='Realizado' />
                                        </Columns>
                                    </asp:GridView>
                                    </div> 
                                </asp:Panel>
                            </asp:Panel>
                            <input type='button' runat='server' id='btnEditar' value='Editar Produtos' class='botao' onclick='fncAbrirEdicao(0,0,0)' />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <script type='text/javascript'>
                        function fncAbrirEdicao(vIDCategoria, vIDSubCategoria, vIDFornecedor) {
                            var wh = window.open('produtos.aspx?cat=' + vIDCategoria + '&sct=' + vIDSubCategoria + '&for=' + vIDFornecedor + '&idvisita=<%=VIEWSTATE("IDVISITA")%>', 'edicao', 'resizable=yes, scrollbars=yes, width=800, height=600');
                            wh.focus();
                        }
                        function refresh(vIDCat, vIDSub, vIDFor) {
                            location.href = 'visita.aspx?idvisita=<%=ViewState("IDVISITA") %>&cat=' + vIDCat + '&for=' + vIDFor;
                        }
                    </script>
                 </div> 
                 <br class='cb' />
                 <div id='VisitaRodape'>
                    <asp:UpdatePanel runat='server' ID='updConfirmarFinalizacaoVisita'>
                        <ContentTemplate>
                            <asp:Button runat='server' ID='btnFinalizar' Text='Finalizar Visita' OnClientClick="return confirm('Deseja realmente finalizar a visita ?');" />
                            <table runat='server' id='tblMotivoUsoForm' visible='false'>
                                <tr>
                                    <td>Motivo da utilização do formulário on-line</td>
                                    <td>
                                        <asp:DropDownList DataTextField="MotivoUsoForm" DataValueField="IdMotivoUsoForm" runat='server' ID='drpMotivoUsoForm'>
                                        </asp:DropDownList>
                                        <asp:CompareValidator runat="server" ID="valMotivo" ControlToValidate="drpMotivoUsoForm" ValueToCompare="0" ErrorMessage="Selecione uma opção" Operator="GreaterThan"></asp:CompareValidator>
                                    </td>
                                    <td><asp:Button runat='server' ID='btnConfirmarFinalizacao' Text='Confirmar' /></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                 </div>
</asp:Content>

