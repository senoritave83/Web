<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Visita.aspx.vb" Inherits="Pages.Visita.Visita" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/Posicao.ascx" tagname="Posicao" tagprefix="uc2" %>
<%@ Register src="../controls/ImageRotator.ascx" tagname="ImageRotator" tagprefix="uc3" %>
<%@ Register src="../controls/pergunta.ascx" tagname="pergunta" tagprefix="uc4" %>
<%@ Register src="../controls/respostas.ascx" tagname="respostas" tagprefix="uc5" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea' style="width:78%;">
		<ul id="edit-visita">
			<li>
			    <strong><asp:Label runat='server' ID='lblTextoDataRoteiro'>Data do Roteiro:</asp:Label></strong><br/>
			    <asp:Label runat='server' ID='lblDataRoteiro' />		    				
			</li>
			<li>
				 <strong><asp:Label runat='server' ID='lblTextoDataEnvio'>Data do Envio:</asp:Label></strong><br/>				 
				 <asp:Label runat='server' ID='lblDataEnvio' />		
			</li>	
			<li>
			    <strong><asp:Label runat='server' ID='lblTextoIDLoja'>Loja:</asp:Label></strong><br/> 
			    <asp:label runat='server' ID="lblLoja"></asp:label>	
	            <asp:DropDownList runat="server" ID="cboIDLoja" DataTextField="CodigoLoja" DataValueField="IDLoja" CssClass="Select" Width="265px" />
				<asp:RequiredFieldValidator runat='server' ID='valReqIDLoja' Display='None' ErrorMessage='Loja &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDLoja' />	        
			</li>
			<li>
			    <strong><asp:Label runat='server' ID='Label8'>Endere&ccedil;o:</asp:Label></strong><br/>
				<asp:Label runat='server' ID='lblEndereco' />		    					
			</li>
			<li>
			    <strong><asp:Label runat='server' ID='lblTextoIDPromotor'>Usu&aacute;rio:</asp:Label></strong><br/> 
	            <asp:DropDownList runat="server" ID="cboIDPromotor" DataTextField="UsuarioCargo" DataValueField="IDUsuario" CssClass="Select" />
				<asp:RequiredFieldValidator runat='server' ID='valReqIDPromotor' Display='None' ErrorMessage='Promotor &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDPromotor' />
			</li>	
			<li>
			    <strong><asp:Label runat='server' ID='lblTextoDataInicio' >In&iacute;cio:</asp:Label></strong><br/>				 
				<asp:Label runat='server' ID='lblDataInicio' />		
			</li>
			<li>
			    <strong><asp:Label runat='server' ID='lblTextoDataFinalizacao'>Finaliza&ccedil;&atilde;o:</asp:Label></strong><br/>
				<asp:Label runat='server' ID='lblDataFinalizacao' />				
			</li>
			<li runat='server' id='trLocalizacao'  visible='<%$Settings: visible, Visita.Localizacao, true %>'>
			    <strong><asp:Label runat='server' ID='Label2' >Localiza&ccedil;&atilde;o Inicial</asp:Label></strong><br/>			 
			    <uc2:Posicao ID="locDadosLocalizacaoInicial" runat="server" />
			</li>
			<li runat='server' id='tr1'  visible='<%$Settings: visible, Visita.Localizacao, true %>'>
			    <strong><asp:Label runat='server' ID='Label5'>Localiza&ccedil;&atilde;o Final:</asp:Label></strong><br/> 		
			    <uc2:Posicao ID="locDadosLocalizacaoFinal" runat="server" />		
			</li>
			<li>
			    <strong><asp:Label runat='server' ID='lblTextoStatus'>Status:</asp:Label></strong><br/>
			    <asp:Label runat='server' ID='lblStatus' />					
			</li>
			<li>
			    <strong><asp:Label runat='server' ID='lblTextoIDTipoJustificativa'>Justificativa:</asp:Label></strong><br/>			 
				<asp:DropDownList runat="server" ID="cboIDTipoJustificativa" DataTextField="TipoJustificativa" DataValueField="IDTipoJustificativa" CssClass="Select" />
				<asp:RequiredFieldValidator runat='server' ID='valReqIDTipoJustificativa' Display='None' ErrorMessage='TipoJustificativa &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDTipoJustificativa' />			
			</li>
			<li>
				<asp:Label runat='server' ID='lblTextoResponsavel'>&nbsp;</asp:Label> 
				<asp:Label runat='server' ID='lblResponsavel'>&nbsp;</asp:Label> 					
			</li>	
			<li>
			    <strong><asp:Label runat='server' ID='Label10'>Situa&ccedil;&atilde;o:</asp:Label></strong><br/> 			
	            <asp:DropDownList runat="server" ID="cboIDStatusVisita" CssClass="Select">
	                <asp:ListItem Text="Ativa" Value="1" />
	                <asp:ListItem Text="Inativa" Value="0" />
	            </asp:DropDownList>		
			</li>	
			<li>
			    <strong><asp:Label runat='server' ID='lblTeste'>Teste:</asp:Label></strong><br/>			
	            <asp:DropDownList runat="server" ID="cboTeste" CssClass="Select">
	                <asp:ListItem Text="N&atilde;o" Value="0" />
	                <asp:ListItem Text="Sim" Value="1" />
	            </asp:DropDownList>			
			</li>
			<li>
			    <strong><asp:Label runat='server' ID='lblMotivoUsoFormTit'>Motivo de Uso do formul&aacute;rio on-line:</asp:Label></strong><br/>
				<asp:Label runat='server' ID='lblMotivoUsoForm'></asp:Label>		    				
			</li>
		</ul>
		<asp:GridView runat='server' ID='grdSumario' SkinID='GridInterno' Width='100%' AutoGenerateColumns='false' AllowSorting='true'>
            <HeaderStyle HorizontalAlign='Left' />
            <Columns>
                <asp:BoundField HeaderText='<%$Settings: Caption, Categoria, "Segmento"%>' DataField='segmento' SortExpression='Segmento' />
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
        <div>	
	        <p><strong><asp:Label runat='server' ID='Label1'><asp:Literal ID="Literal7" runat="server" Text='<%$Settings: texto, Produtos.Mensagens.Mensagem7, "Produtos a serem pesquisados"%>' />:</asp:Label></strong><asp:Label runat='server' ID='lblTotalProdutos' /></p>       
	        <p><strong><asp:Label runat='server' ID='Label3'><asp:Literal ID="Literal8" runat="server" Text='<%$Settings: texto, Produtos.Mensagens.Mensagem8, "Produtos pesquisados:"%>' />:</asp:Label></strong><asp:Label runat='server' ID='lblProdutoPesquisados' /></p>          
        </div>
	</div>
	<div id='AreaVisitaEntidades'>
	    <asp:UpdatePanel>
	        <ContentTemplate>
			    <div class='Filtro'>
				    <div class='FiltroItem'>
					    <asp:Label runat="server" id="lblFiltrarPor">Filtrar por</asp:Label><br>
					    <asp:TextBox Runat="server" ID='txtFiltro' />
				    </div> 
				    <div class='FiltroItem'>
				        <asp:Literal runat="server" text='<%$Settings: texto, Produto.Mensagens.Mensagem9, "Status do Produto"%>'></asp:Literal><br>
					    <asp:DropDownList runat='server' ID='cboFiltrarPor'>
					        <asp:ListItem Text='N&atilde;o pesquisados' Value='0' />
					        <asp:ListItem Text='Pesquisados' Value='1'  />
					        <asp:ListItem Text='Todos' Value='2' Selected='True' />
					    </asp:DropDownList>
				    </div> 
				    <div class='FiltroItem'>
    				    <asp:Label runat="server" id="Label4"><asp:Literal ID="Literal1" runat='server' Text='<%$Settings: Caption, Categoria, "Segmento"%>'></asp:Literal>:</asp:Label><br>
					    <asp:DropDownList AutoPostBack='true' runat='server' ID='cboSegmento' DataTextField="Categoria" DataValueField="IdCategoria">
					        <asp:ListItem Text="TODOS" Value="0"></asp:ListItem></asp:DropDownList></div><div class='FiltroItem'>
					    <asp:Label runat="server" id="Label6"><asp:Literal ID="Literal2" runat='server' Text='<%$Settings: Caption, SubCategoria, "Categoria"%>' ></asp:Literal>:</asp:Label><br>
					    <asp:DropDownList runat='server' ID='cboCategoria' DataTextField="SubCategoria" DataValueField="IdSubCategoria">
					        <asp:ListItem Text="TODOS" Value="0"></asp:ListItem></asp:DropDownList></div><div class='FiltroBotao'>
					    <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				    </div>
			    </div>	
                <asp:Repeater runat='server' ID='rptEntidades' Visible='false'>
                    <HeaderTemplate>
                        <table border='1'>
                            <thead>
                                <tr>
                                    <th><asp:Literal ID="Literal1" runat='server' Text='<%$Settings: Caption, Categoria, "Segmento"%>'></asp:Literal></th><th><asp:Literal ID="Literal3" runat='server' Text='<%$Settings: Caption, SubCategoria, "Categoria"%>'></asp:Literal></th><th>Cod.</th><th><asp:Literal ID="Literal4" runat='server' Text='<%$Settings: Caption, Produto, "Produto"%>'></asp:Literal></th><th>Encontrado</th><th>Pre&#231;o</th><th>Visualizou Estoque</th><th>Estoque</th><th>Pesquisado</th></tr></thead><tbody>
                    </HeaderTemplate>
                    <ItemTemplate>  
                                <tr>
                                    <td rowspan='<%#Eval("Registros") %>'>
                                        <%#Eval("Categoria")%>
                                    </td>
                        <asp:Repeater runat='server' ID='rptSubCategorias' DataSource='<%#BindSubCategorias(Eval("IDCategoria"))%>'>
                            <ItemTemplate>
                                    <td rowspan='<%#Eval("Registros") %>'>
                                        <%#Eval("SubCategoria")%>
                                    </td>
                                    <asp:Repeater runat='server' ID='rtpProdutos' DataSource='<%#BindProdutos(Eval("IDSUbCategoria"))%>'>
                                        <ItemTemplate>
                                    <td>
                                        <%#Eval("Produto")%>
                                    </td>
                                    <td>
                                        <%#Eval("Descricao")%>
                                    </td>
                                    <td>
                                        <%#IIf(isEncontrado(Eval("Pesquisado")), Encontrado(Eval("Encontrado")), "")%>
                                    </td>
                                    <td>
                                        <%#IIf(isEncontrado(Eval("Pesquisado")), IIf(isEncontrado(Eval("Encontrado")), GetPreco(Eval("Preco")), ""), "")%>
                                    </td>
                                    <td>
                                        <%#IIf(isEncontrado(Eval("Pesquisado")), IIf(isEncontrado(Eval("Encontrado")), Encontrado(Eval("VisualizouEstoque")), ""), "")%>
                                    </td>
                                    <td>
                                        <%#IIf(isEncontrado(Eval("Pesquisado")), IIf(isEncontrado(Eval("Encontrado")), GetNullable(Eval("Estoque")), ""), "")%>
                                    </td>
                                    <td>
                                        <%#IIf(isEncontrado(Eval("Pesquisado")), "Sim", "N&atilde;o")%>
                                    </td>
                                </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>                   
                            </ItemTemplate>
                        </asp:Repeater>
                    </ItemTemplate>
                    <FooterTemplate>
                            </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
	        </ContentTemplate>
	    </asp:UpdatePanel>
	    <asp:UpdatePanel runat='server' ID='pnlProdutos'>
	        <ContentTemplate>
                <div id='AreaLojaPergunta'>
                    <h2>Pesquisas efetuadas</h2><asp:GridView runat='server' ID='dtgProdutos' SkinID='GridInterno' AutoGenerateColumns='false' AllowSorting='true' CellSpacing="1" CellPadding="1" style="width:100%;">
                        <HeaderStyle HorizontalAlign='Left' />
                        <Columns>
                            <asp:BoundField HeaderText='<%$Settings: Caption, Categoria, "Segmento"%>' DataField='segmento' SortExpression='Segmento' />
                            <asp:BoundField HeaderText='<%$Settings: Caption, SubCategoria, "Categoria"%>' DataField='categoria' SortExpression='Categoria' />
                            <asp:TemplateField HeaderText='Cod <%$Settings: Caption, Produto, "Produto"%>' SortExpression='CodProduto'>
                                <ItemTemplate><%# Eval("Produto")%></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText='<%$Settings: Caption, Produto, "Produto"%>' SortExpression='Produto'>
                                <ItemTemplate><%# Eval("Descricao")%></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText='Encontrado' SortExpression='Encontrado'>
                                <ItemTemplate><%#IIf(isEncontrado(Eval("Pesquisado")), Encontrado(Eval("Encontrado")), "")%></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText='Preco' SortExpression='Preco'>
                                <ItemTemplate><%#IIf(isEncontrado(Eval("Pesquisado")), IIf(isEncontrado(Eval("Encontrado")), GetPreco(Eval("Preco")), ""), "")%></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText='Visualizou Estoque' SortExpression='VisualizouEstoque'>
                                <ItemTemplate><%#IIf(isEncontrado(Eval("Pesquisado")), IIf(isEncontrado(Eval("Encontrado")), Estoque(Eval("VisualizouEstoque")), ""), "")%></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText='Estoque' SortExpression='Estoque'>
                                <ItemTemplate><%#IIf(isEncontrado(Eval("Pesquisado")), IIf(isEncontrado(Eval("Encontrado")), GetNullable(Eval("Estoque")), ""), "")%></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText='Pesquisado' SortExpression='Pesquisado'>
                                <ItemTemplate><%#IIf(Eval("RupturaAplicada") = "1", "Sim&nbsp; <img title='Produto considerado como Ruptura ap&oacute;s aplica&ccedil;&atilde;o de Justificativa que permite esta a&ccedil;&atilde;o.' src=../imagens/exclamacao_ico.png>", IIf(isEncontrado(Eval("Pesquisado")), "Sim", "N&atilde;o"))%></ItemTemplate>
                            </asp:TemplateField>
						    <asp:HyperLinkField DataNavigateUrlFields="IDVisita,IDProduto" DataNavigateUrlFormatString="VisitaProduto.aspx?IDVisita={0}&IDProduto={1}" Text='Visualizar' HeaderText="" SortExpression=""  />
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="color:Black;font-size:10pt;font-weight:bold;"><asp:Literal runat="Server" Text='<%$Settings: texto, Produto.Mensagens.Mensagem10, "N&atilde;o h&aacute; produtos pesquisados nesta visita!"%>'></asp:Literal></div></EmptyDataTemplate></asp:GridView><xm:Paginate ID="pagProdutos" runat="server" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel> 
	</div>
    <div id='AreaLojaPergunta' runat="server" visible="false">
        <h2>Pesquisas</h2><asp:GridView runat='server' ID='grdPesquisas' Visible=false AutoGenerateColumns='false' style="width:100%">
            <HeaderStyle HorizontalAlign='Left' />
            <Columns>
                <asp:BoundField HeaderText='Pesquisa' DataField='Pesquisa' />
                <asp:BoundField HeaderText='Realizadas' DataField='Realizadas' />
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='pesquisa.aspx?idvisita=<%# cls.IDVisita %>&tipoentidade=11&idpesquisa=<%# Eval("IDPesquisa")%>' target='_blank'>Visualizar</a></ItemTemplate></asp:TemplateField></Columns><EmptyDataTemplate>
                <div style="color:Black;font-size:10pt;font-weight:bold;"> N&atilde;o existem pesquisas para esta visita!</div></EmptyDataTemplate></asp:GridView></div><div id='AreaLojaPergunta'>
   	    <h2>Perguntas de Loja</h2><asp:GridView runat='server' ID='dtgPerguntas' SkinID='GridInterno' Width='100%' AutoGenerateColumns='false' style="width:100%;" CssClass="gridRespostas">
            <HeaderStyle  HorizontalAlign='left'  />
            <Columns>
                <asp:BoundField HeaderText='Pergunta' DataField='Pergunta' SortExpression='Pergunta' ReadOnly='true' ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="Titulo_perguntas" />
                <asp:TemplateField HeaderText='Resposta' ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-CssClass="Titulo_perguntas" >
                    <ItemTemplate>
                        <uc3:ImageRotator ID="imgRotatorLoja" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
				<asp:HyperLinkField Visible="false" DataNavigateUrlFields="IDVisita,IDPergunta" DataNavigateUrlFormatString="VisitaPerguntaResposta.aspx?IDVisita={0}&IDPergunta={1}" Text='Visualizar' HeaderText="" SortExpression=""  />
            </Columns>
            <EmptyDataTemplate>
                <div style="color:Black;font-size:10pt;font-weight:bold;"> N&atilde;o existem perguntas respondidas para esta visita!</div></EmptyDataTemplate></asp:GridView></div><div id='AreaLojaPergunta'>
   	    <h2><asp:Literal runat="server" Text='<%$Settings: texto, Categoria.Mensagens.Mensagem6, "Perguntas de segmento"%>'></asp:Literal></h2><asp:GridView runat='server' ID='dtgPerguntasSegmento' SkinID='GridInterno' Width='100%' AutoGenerateColumns='false' style="width:100%;" CssClass="gridRespostas">
            <HeaderStyle HorizontalAlign='left'  />
            <Columns>
                <asp:BoundField HeaderText='<%$Settings: Caption, Categoria, "Segmento"%>' DataField='Referencia' SortExpression='Segmento' ReadOnly='true' ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="Titulo_perguntas"/>
                <asp:BoundField HeaderText='Pergunta' DataField='Pergunta' SortExpression='Pergunta' ReadOnly='true' ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="Titulo_perguntas" />
                <asp:TemplateField HeaderText='Resposta' ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-CssClass="Titulo_perguntas" >
                    <ItemTemplate>
                        <uc3:ImageRotator ID="imgRotatorSegmento" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
				<asp:HyperLinkField Visible="false" DataNavigateUrlFields="IDVisita,IDPergunta" DataNavigateUrlFormatString="VisitaPerguntaResposta.aspx?IDVisita={0}&IDPergunta={1}" Text='Visualizar' HeaderText="" SortExpression=""  />
            </Columns>
            <EmptyDataTemplate>
                <div style="color:Black;font-size:10pt;font-weight:bold;"><asp:Literal ID="Literal6" runat="server" Text='<%$Settings: texto, Categoria.Mensagens.Mensagem7, "N&atilde;o existem perguntas de segmento respondidas para esta visita!"%>'></asp:Literal></div></EmptyDataTemplate></asp:GridView></div><div id='AreaLojaPergunta'>
   	    <h2><asp:Literal ID="Literal5" runat="server" Text='<%$Settings: texto, SubCategoria.Mensagens.Mensagem6, "Perguntas de categoria"%>'></asp:Literal></h2><asp:GridView runat='server' ID='dtgPerguntasCategoria' SkinID='GridInterno' Width='100%' AutoGenerateColumns='false' style="width:100%;" CssClass="gridRespostas">
            <HeaderStyle HorizontalAlign='left'  />
            <Columns>
                <asp:BoundField HeaderText='<%$Settings: Caption, SubCategoria, "Categoria"%>' DataField='Referencia' SortExpression='Categoria' ReadOnly='true' ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="Titulo_perguntas" />
                <asp:BoundField HeaderText='Pergunta' DataField='Pergunta' SortExpression='Pergunta' ReadOnly='true' ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="Titulo_perguntas" />
                <asp:TemplateField HeaderText='Resposta' ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-CssClass="Titulo_perguntas" >
                    <ItemTemplate>
                        <uc3:ImageRotator ID="imgRotatorCategoria" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
				<asp:HyperLinkField Visible="false" DataNavigateUrlFields="IDVisita,IDPergunta" DataNavigateUrlFormatString="VisitaPerguntaResposta.aspx?IDVisita={0}&IDPergunta={1}" Text='Visualizar' HeaderText="" SortExpression=""  />
            </Columns>
            <EmptyDataTemplate>
                <div style="color:Black;font-size:10pt;font-weight:bold;"><asp:Literal ID="Literal6" runat="server" Text='<%$Settings: texto, SubCategoria.Mensagens.Mensagem7, "N&atilde;o existem perguntas de categoria respondidas para esta visita!"%>'></asp:Literal></div></EmptyDataTemplate></asp:GridView></div><div id='AreaLojaPergunta'>
   	    <h2>Perguntas de Amostragem</h2><asp:GridView runat='server' ID='grdPerguntasAmostragem' SkinID='GridInterno' Width='100%' AutoGenerateColumns='false' style="width:100%;" CssClass="gridRespostas">
            <HeaderStyle  HorizontalAlign='left'  />
            <Columns>
                <asp:BoundField HeaderText='Pergunta' DataField='Pergunta' SortExpression='Pergunta' ReadOnly='true' ItemStyle-HorizontalAlign="Left" HeaderStyle-CssClass="Titulo_perguntas" />
                <asp:TemplateField HeaderText='Resposta' ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" HeaderStyle-CssClass="Titulo_perguntas" >
                    <ItemTemplate>
                        <uc3:ImageRotator visible="false" ID="imgRotatorAmostragem" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
				<asp:HyperLinkField Visible="false" DataNavigateUrlFields="IDVisita,IDPergunta" DataNavigateUrlFormatString="VisitaPerguntaResposta.aspx?IDVisita={0}&IDPergunta={1}" Text='Visualizar' HeaderText="" SortExpression=""  />
            </Columns>
            <EmptyDataTemplate>
                <div style="color:Black;font-size:10pt;font-weight:bold;"> N&atilde;o existem perguntas de amostragem respondidas para esta visita!</div></EmptyDataTemplate></asp:GridView></div><div id='AreaLojaPergunta'>
	    <h2>Eventos</h2><asp:GridView runat='server' ID='grdEventosLoja' SkinID='GridInterno' Width='100%' AutoGenerateColumns='false' style="width:100%;">
            <HeaderStyle HorizontalAlign='Left' />
            <Columns>
                <asp:BoundField HeaderText='Tipo de Evento' DataField='TipoEvento' SortExpression='TipoEvento' ReadOnly='true' />
                <asp:BoundField HeaderText='Data de In&iacute;cio' DataField='DataInicio' SortExpression='DataInicio' ReadOnly='true' />
                <asp:BoundField HeaderText='Data de Finaliza&ccedil;&atilde;o' DataField='DataFinalizacao' SortExpression='DataFinalizacao' ReadOnly='true' />
                <asp:BoundField HeaderText='Posi&ccedil;&atilde;o In&iacute;cio' DataField='PosicaoInicio' SortExpression='PosicaoInicio' ReadOnly='true' />
                <asp:BoundField HeaderText='Posi&ccedil;&atilde;o Final' DataField='PosicaoFinalizacao' SortExpression='PosicaoFinalizacao' ReadOnly='true' />
                <asp:BoundField HeaderText='Obs. In&iacute;cio' DataField='ObservacaoInicio' SortExpression='ObservacaoInicio' ReadOnly='true' />
                <asp:BoundField HeaderText='Obs. Final' DataField='ObservacaoFinalizacao' SortExpression='ObservacaoFinalizacao' ReadOnly='true' />
            </Columns>
            <EmptyDataTemplate>
                <div style="color:Black;font-size:10pt;font-weight:bold;"> N&atilde;o existem eventos para esta visita!</div></EmptyDataTemplate></asp:GridView></div><div id='AreaLojaPergunta'>
	    <h2>Tarefas executadas na loja</h2><asp:GridView runat='server' ID='grdTarefas' SkinID='GridInterno' Width='100%' AutoGenerateColumns='false' style="width:100%;">
            <HeaderStyle HorizontalAlign='Left' />
            <Columns>
                <asp:BoundField HeaderText='Tipo de Tarefa' DataField='TipoTarefa' SortExpression='TipoTarefa' ReadOnly='true' />
                <asp:BoundField HeaderText='Data da execu&ccedil;&atilde;o' DataField='Data' SortExpression='Data' ReadOnly='true' />
                <asp:BoundField HeaderText='Status' DataField='Status' SortExpression='Status' ReadOnly='true' />
                <asp:BoundField HeaderText='Observa&ccedil;&otilde;es' DataField='Observacao' SortExpression='Observacao' ReadOnly='true' />
            </Columns>
            <EmptyDataTemplate>
                <div style="color:Black;font-size:10pt;font-weight:bold;"> N&atilde;o existem tarefas para esta visita!</div></EmptyDataTemplate></asp:GridView></div><div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Visitas.aspx'" /> </div><div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaGravar'>
			        <b>Gravar:</b>
				    Grava as altera&ccedil;&otilde;es efetuadas no banco.
		        </asp:Localize></li><li>
		        <asp:Localize runat='server' ID='lclAjudaApagar'>
			        <b>Apagar:</b>
				    Apaga o registro atual.
		        </asp:Localize></li><li>
		        <asp:Localize runat='server' ID='lclAjudaNovo'>
			        <b>Novo:</b>
				    Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		        </asp:Localize></li><li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize></li></ul></div><script type='text/javascript'>
        function fncImageClick(sender, e) {
            var wh = window.open(e.key, "images", "height=200, width=300");
        }
    </script></strong></asp:Content>