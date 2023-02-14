<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Visita.aspx.vb" Inherits="Pages.Visita.Visita" title="XM Promotores - Yes Mobile" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>

<%@ Register src="../controls/Localizacao.ascx" tagname="Localizacao" tagprefix="uc2" %>

<%@ Register src="../controls/ImageRotator.ascx" tagname="ImageRotator" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<table id='tblEditArea' border='0'>
			<tr class="trEditHeader">
			    <td colspan='4'>&nbsp;</td>
			</tr>
			<tr class='trEditSpace'>
			    <td colspan='4'>
                </td>
			</tr>
            <tr class='trField'>
                <td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoDataRoteiro'>
						Data do Roteiro:
					</asp:Label> 
				</td>
				<td class='tdField' colspan='2'>
				    <asp:Label runat='server' ID='lblDataRoteiro' />
				</td>
            </tr>
            <tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoDataEnvio'>
						Data do Envio:
					</asp:Label> 
				</td>
				<td class='tdField' colspan='2'>
				    <asp:Label runat='server' ID='lblDataEnvio' />
				</td>
                <td class='tdFieldHeader' rowspan='5' valign='top' width='300px;' >
                    <div style="width:400px;">
                        <table width='100%' border='0'>
                            <tr>
                                <td colspan='2'>
                                    <asp:GridView runat='server' ID='grdSumario' SkinID='GridInterno' Width='100%' AutoGenerateColumns='false' AllowSorting='true'>
                                        <HeaderStyle HorizontalAlign='Left' />
                                        <Columns>
                                            <asp:BoundField HeaderText='Segmento' DataField='segmento' SortExpression='Segmento' />
                                            <asp:BoundField HeaderText='Previsto' DataField='Previsto' SortExpression='Previsto' />
                                            <asp:BoundField HeaderText='Coletado' DataField='Coletado' SortExpression='Coletado' />
                                            <asp:TemplateField HeaderText='%' SortExpression='Porc'>
                                                <ItemTemplate><%#FormatPercent((Eval("Coletado") / Eval("Previsto")), 2)%></ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            &nbsp;
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                			    <td class='tdFieldHeader2'>
				                    <asp:Label runat='server' ID='Label1'>
						                Produtos a serem pesquisados:
					                </asp:Label> 
				                </td>
				                <td class='tdField'>
				                    <asp:Label runat='server' ID='lblTotalProdutos' />
				                </td>
                            </tr>
                            <tr>
                                <td class='tdFieldHeader2'>
				                    <asp:Label runat='server' ID='Label3'>
						                Produtos Pesquisados:
					                </asp:Label> 
				                </td>
				                <td class='tdField'>
				                    <asp:Label runat='server' ID='lblProdutoPesquisados' />
				                </td>
                            </tr>
                        </table>
                    </div>
				</td>
            </tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoIDLoja'>
						Loja:
					</asp:Label> 
				</td>
				<td class='tdField' colspan='2'>
                    <asp:label runat='server' ID="lblLoja"></asp:label>
                    <asp:DropDownList runat="server" ID="cboIDLoja" DataTextField="CodigoLoja" DataValueField="IDLoja" />
					<asp:RequiredFieldValidator runat='server' ID='valReqIDLoja' Display='None' ErrorMessage='Loja &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDLoja' />
				 </td>
            </tr>
            <tr class='trField' runat='server' id='tr2'  visible='<%$Settings: visible, Visita.Localizacao, true %>'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='Label9'>
					    Posi&ccedil;&atilde;o da Loja:
					</asp:Label> 
				</td>
				<td class='tdField'>
				    <uc2:Localizacao ID="locDadosLocalizacaoLoja" runat="server" />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='Label8'>
						Endereço:
					</asp:Label> 
				</td>
				<td class='tdField' colspan='2'>
				    <asp:Label runat='server' ID='lblEndereco' />
				</td>
            </tr>
            <tr class="trField">
				<td class='tdFieldHeader' >
				    <asp:Label runat='server' ID='lblTextoIDPromotor'>
						Promotor:
					</asp:Label> 
				</td>
				<td class='tdField' colspan='2'>
                <asp:DropDownList runat="server" ID="cboIDPromotor" DataTextField="Promotor" DataValueField="IDPromotor" />
					<asp:RequiredFieldValidator runat='server' ID='valReqIDPromotor' Display='None' ErrorMessage='Promotor &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDPromotor' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoDataInicio'>
						In&iacute;cio:
					</asp:Label> 
				</td>
				<td class='tdField' colspan='2'>
				    <asp:Label runat='server' ID='lblDataInicio' />
				</td>
            </tr>
            <tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoDataFinalizacao'>
						Finaliza&ccedil;&atilde;o:
					</asp:Label> 
				</td>
				<td class='tdField' colspan='2'>
				    <asp:Label runat='server' ID='lblDataFinalizacao' />
				</td>
			</tr>
			<tr class='trField' runat='server' id='trLocalizacao'  visible='<%$Settings: visible, Visita.Localizacao, true %>'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='Label2'>
						Localiza&ccedil&atilde;o Inicial:
					</asp:Label> 
				</td>
				<td class='tdField'>
				    <uc2:Localizacao ID="locDadosLocalizacaoInicial" runat="server" />
				</td>
            </tr>
            <tr class='trField' runat='server' id='tr1'  visible='<%$Settings: visible, Visita.Localizacao, true %>'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='Label5'>
					    Localiza&ccedil&atilde;o Final:
					</asp:Label> 
				</td>
				<td class='tdField'>
				    <uc2:Localizacao ID="locDadosLocalizacaoFinal" runat="server" />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoStatus'>
						Status:
					</asp:Label> 
				</td>
				<td class='tdField' >
				    <asp:Label runat='server' ID='lblStatus' />
				</td>
				<td class='tdFieldHeader2'>
				    <asp:Label runat='server' ID='Label10'>
						Situação:
					</asp:Label> 
				</td>
				<td class='tdField'>
                    <asp:DropDownList runat="server" ID="cboIDStatusVisita">
                        <asp:ListItem Text="Ativa" Value="1" />
                        <asp:ListItem Text="Inativa" Value="0" />
                    </asp:DropDownList>
				</td>
            </tr>
            <tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoIDTipoJustificativa'>
						Justificativa:
					</asp:Label> 
				</td>
				<td class='tdField'>
					<asp:DropDownList runat="server" ID="cboIDTipoJustificativa" DataTextField="TipoJustificativa" DataValueField="IDTipoJustificativa" />
					<asp:RequiredFieldValidator runat='server' ID='valReqIDTipoJustificativa' Display='None' ErrorMessage='TipoJustificativa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDTipoJustificativa' />
				</td>
                <td class='tdFieldHeader2'>
				    <asp:Label runat='server' ID='lblTeste'>
						Teste:
					</asp:Label> 
				</td>
				<td class='tdField'>
                    <asp:DropDownList runat="server" ID="cboTeste">
                        <asp:ListItem Text="Não" Value="0" />
                        <asp:ListItem Text="Sim" Value="1" />
                    </asp:DropDownList>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
				    <asp:Label runat='server' ID='lblTextoResponsavel'>&nbsp;</asp:Label> 
				</td>
				<td class='tdField'>
				    <asp:Label runat='server' ID='lblResponsavel'>&nbsp;</asp:Label> 
				</td>
				<td class='tdFieldHeader2' style="width:200px;">
				    <asp:Label runat='server' ID='lblMotivoUsoFormTit'>
						Motivo de Uso do formulário on-line:
					</asp:Label> 
				</td>
				<td class='tdField'>
                    <asp:Label runat='server' ID='lblMotivoUsoForm'></asp:Label>
				</td>
			</tr>
			<tr class="trEditFooter">
			    <td colspan='4'>&nbsp;</td>
			</tr>
		</table>
	</div>
	<div id='AreaVisitaProdutos'>
	    <asp:ScriptManager runat='server' ID='srcManager'></asp:ScriptManager>
	    <asp:UpdatePanel runat='server' ID='pnlProdutos'>
	        <ContentTemplate>
			    <div class='Filtro'>
				    <div class='FiltroItem'>
					    <asp:Label runat="server" id="lblFiltrarPor">Filtrar por</asp:Label>
					    <br>
					    <asp:TextBox Runat="server" ID='txtFiltro' />
				    </div> 
				    <div class='FiltroItem'>
				        <asp:Label runat="server" id="Label7">Status do Produto</asp:Label>
					    <br>
					    <asp:DropDownList runat='server' ID='cboFiltrarPor'>
					        <asp:ListItem Text='N&atilde;o pesquisados' Value='0' />
					        <asp:ListItem Text='Pesquisados' Value='1'  />
					        <asp:ListItem Text='Todos' Value='2' Selected='True' />
					    </asp:DropDownList>
				    </div> 
				    <div class='FiltroItem'>
    				    <asp:Label runat="server" id="Label4">Segmento</asp:Label>
					    <br>
					    <asp:DropDownList AutoPostBack='true' runat='server' ID='cboSegmento' DataTextField="Categoria" DataValueField="IdCategoria">
					        <asp:ListItem Text="TODOS" Value="0"></asp:ListItem>
					    </asp:DropDownList>
				    </div> 
				    <div class='FiltroItem'>
					    <asp:Label runat="server" id="Label6">Categoria</asp:Label>
					    <br>
					    <asp:DropDownList runat='server' ID='cboCategoria' DataTextField="SubCategoria" DataValueField="IdSubCategoria">
					        <asp:ListItem Text="TODOS" Value="0"></asp:ListItem>
					    </asp:DropDownList>
				    </div> 
				    <div class='FiltroBotao'>
					    <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				    </div>
			    </div>	
                <asp:GridView runat='server' ID='dtgProdutos' SkinID='GridInterno' Width='100%' AutoGenerateColumns='false' AllowSorting='true'>
                    <HeaderStyle HorizontalAlign='Left' />
                    <Columns>
                        <asp:BoundField HeaderText='Segmento' DataField='segmento' SortExpression='Segmento' />
                        <asp:BoundField HeaderText='Categoria' DataField='categoria' SortExpression='Categoria' />
                        <asp:TemplateField HeaderText='Cod Produto' SortExpression='CodProduto'>
                            <ItemTemplate><%# Eval("Produto")%></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText='Produto' SortExpression='Produto'>
                            <ItemTemplate><%# Eval("Descricao")%></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText='Encontrado' SortExpression='Encontrado'>
                            <ItemTemplate><%#IIf(isEncontrado(Eval("Pesquisado")), Encontrado(Eval("Encontrado")), "")%></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText='Preco' SortExpression='Preco'>
                            <ItemTemplate><%#IIf(isEncontrado(Eval("Pesquisado")), IIf(isEncontrado(Eval("Encontrado")), GetPreco(Eval("Preco")), ""), "")%></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText='Visualizou Estoque' SortExpression='VisualizouEstoque'>
                            <ItemTemplate><%#IIf(isEncontrado(Eval("Pesquisado")), IIf(isEncontrado(Eval("Encontrado")), IIf(GetNullable(Eval("VisualizouEstoque")) = "1", "Sim", IIf(GetNullable(Eval("VisualizouEstoque")) = "2", "N&atilde;o permitido", "N&atilde;o")), ""), "")%></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText='Estoque' SortExpression='Estoque'>
                            <ItemTemplate><%#IIf(isEncontrado(Eval("Pesquisado")), IIf(isEncontrado(Eval("Encontrado")), GetNullable(Eval("Estoque")), ""), "")%></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText='Pesquisado' SortExpression='Pesquisado'>
                            <ItemTemplate><%#IIf(isEncontrado(Eval("Pesquisado")), "Sim", "N&atilde;o")%></ItemTemplate>
                        </asp:TemplateField>
						<asp:HyperLinkField DataNavigateUrlFields="IDVisita,IDProduto" DataNavigateUrlFormatString="VisitaProduto.aspx?IDVisita={0}&IDProduto={1}" Text='Visualizar' HeaderText="" SortExpression=""  />
                    </Columns>
                    <EmptyDataTemplate>
                        <div style="color:Black;font-size:10pt;font-weight:bold;"> N&atilde;o h&aacute; produtos pesquisados nesta visita!</div>
                    </EmptyDataTemplate>
                </asp:GridView>
                <uc1:Paginate ID="pagProdutos" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel> 
	</div>
	<div id='AreaLojaPergunta'>
        <asp:GridView runat='server' ID='dtgPerguntas' SkinID='GridInterno' Width='100%' AutoGenerateColumns='false'>
            <HeaderStyle HorizontalAlign='Left' />
            <Columns>
                <asp:BoundField HeaderText='Pergunta' DataField='Pergunta' SortExpression='Pergunta' ReadOnly='true' />
                <asp:TemplateField HeaderText='Resposta'>
                    <ItemTemplate>
                    </ItemTemplate>
                </asp:TemplateField>
				<asp:HyperLinkField DataNavigateUrlFields="IDVisita,IDPergunta" DataNavigateUrlFormatString="VisitaPerguntaResposta.aspx?IDVisita={0}&IDPergunta={1}" Text='Visualizar' HeaderText="" SortExpression=""  />
            </Columns>
            <EmptyDataTemplate>
                <div style="color:Black;font-size:10pt;font-weight:bold;"> N&atilde;o h&aacute; perguntas respondidas para esta loja!</div>
            </EmptyDataTemplate>
        </asp:GridView>
	</div>
	<div id='AreaLojaPergunta'>
        <asp:GridView runat='server' ID='grdEventosLoja' SkinID='GridInterno' Width='100%' AutoGenerateColumns='false'>
            <HeaderStyle HorizontalAlign='Left' />
            <Columns>
                <asp:BoundField HeaderText='TipoEvento' DataField='TipoEvento' SortExpression='TipoEvento' ReadOnly='true' />
                <asp:BoundField HeaderText='Data de Início' DataField='DataInicio' SortExpression='DataInicio' ReadOnly='true' />
                <asp:BoundField HeaderText='Data de Finalização' DataField='DataFinalizacao' SortExpression='DataFinalizacao' ReadOnly='true' />
                <asp:BoundField HeaderText='Observação Início' DataField='ObservacaoInicio' SortExpression='ObservacaoInicio' ReadOnly='true' />
                <asp:BoundField HeaderText='Observação Final' DataField='ObservacaoFinalizacao' SortExpression='ObservacaoFinalizacao' ReadOnly='true' />
            </Columns>
            <EmptyDataTemplate>
                <div style="color:Black;font-size:10pt;font-weight:bold;"> N&atilde;o h&aacute; eventos para esta loja!</div>
            </EmptyDataTemplate>
        </asp:GridView>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Visitas.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
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
    <script type='text/javascript'>
        function fncImageClick(sender, e) {
            var wh = window.open(e.key, "images", "height=400, width=500");
        }
    </script>
</asp:Content>

